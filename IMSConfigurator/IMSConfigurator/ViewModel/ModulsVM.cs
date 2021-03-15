using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.ViewModel
{
    class ModulsVM:BaseVM
    {
        List<string> moduls;
        
        public ModulsVM()
        {
            Models.Moduls modelModuls = Models.Moduls.modulInstance;
            List<Modul> allModuls=modelModuls.GetAllModuls();
            Moduls = new List<string>();
            foreach (var item in allModuls)
            {
                Moduls.Add(item.Name);
            }
        }

        public List<string> Moduls { get => moduls; set => moduls = value; }
    }
}
