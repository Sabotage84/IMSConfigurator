using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace IMSConfigurator.Models
{
    [Serializable]
     public class History 
    {
        public History()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<List<Modul>>));
            using (FileStream fs = new FileStream("history.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    imsList = (List<List<Modul>>)formatter.Deserialize(fs);
                }
                catch
                {

                    MessageBox.Show("History file not foud!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                  

                }

            }
            foreach (var item in imsList)
            {
                AddToHistoryLog(item);
            }
        }
        
        public void SaveHistory()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<List<Modul>>));
            using (FileStream fs = new FileStream("history.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, imsList);
            }
            
        }

        public void AddToHistoryLog(List<Modul> moduls)
        {
            IMSMetronome item;
            if (moduls[0].Name.Contains("1000"))
            {
                item = new Metronome1000(moduls);
            }
            else
            {
                item = new Metronome3000(moduls);
            }
            HistoryLog.Add(item.FullName, moduls);
        }

        Dictionary<string, List<Modul>> historyLog = new Dictionary<string, List<Modul>>();
        List<List<Modul>> imsList = new List<List<Modul>>();

        public Dictionary<string, List<Modul>> HistoryLog { get => historyLog; set => historyLog = value; }

        public void AddElement(List<Modul> item)
        {
            imsList.Add(item);
        }
        
        
    }
}
