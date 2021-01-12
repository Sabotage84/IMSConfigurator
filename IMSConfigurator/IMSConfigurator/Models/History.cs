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
     class History : IEnumerable<IMSMetronome>
    {
        public History()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<IMSMetronome>));
            using (FileStream fs = new FileStream("history.xml", FileMode.OpenOrCreate))
            {

                try
                {
                    imsList = (List<IMSMetronome>)formatter.Deserialize(fs);
                }
                catch
                {

                    MessageBox.Show("History file not foud!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                  

                }

            }
        }
        
        public void SaveHistory()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<IMSMetronome>));
            using (FileStream fs = new FileStream("history.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(fs, imsList);
            }
            
        }


        List<IMSMetronome> imsList = new List<IMSMetronome>();
        
        public void AddElement(IMSMetronome item)
        {
            imsList.Add(item);
        }
        
        public IEnumerator<IMSMetronome> GetEnumerator()
        {
            foreach (var item in imsList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
