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
     class History 
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
        }
        
        public void SaveHistory()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<List<Modul>>));
            using (FileStream fs = new FileStream("history.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, imsList);
            }
            
        }


        List<List<Modul>> imsList = new List<List<Modul>>();
        
        public void AddElement(List<Modul> item)
        {
            imsList.Add(item);
        }
        
        
    }
}
