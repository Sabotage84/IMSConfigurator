using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.Models
{
    class History : IEnumerable<IMSMetronome>
    {
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
