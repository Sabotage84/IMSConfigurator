using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMSConfigurator.ViewModel
{
    class OutputModulsVM
    {
        public List<Modul> modListMV;
        public List<Modul> ModListMV { get => modListMV; set => modListMV = value; }
        public OutputModulsVM()
        {
            Moduls m = new Moduls();
            ModListMV = m.SearchModulsByType(ModulType.Output);
            modListMV.AddRange(m.SearchModulsByType(ModulType.Input));
            MessageBox.Show(modListMV[0].Name);
        }
    }
}
