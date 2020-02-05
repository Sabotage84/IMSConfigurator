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
            Moduls m = Moduls.modulInstance;
            ModListMV = m.SearchModulsByType(ModulType.Power);
        }

        public List<Modul> ModListMV { get => modListMV; set => modListMV = value; }
    }
}
