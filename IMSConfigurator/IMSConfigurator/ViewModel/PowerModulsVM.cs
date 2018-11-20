using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMSConfigurator.ViewModel
{
    public class PowerModulsVM
    {
        public List<Modul> modListMV;
        public PowerModulsVM()
        {
            Moduls m = new Moduls();
            ModListMV = m.SearchModulsByType(ModulType.Power);
            //string str = "";
            //foreach (var item in modListMV)
            //{
            //    str = str + item.Name;
            //    str += "\n";
            //}
            //MessageBox.Show(str);
        }

        public List<Modul> ModListMV { get => modListMV; set => modListMV = value; }
    }
}
