using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.ViewModel
{
    class GeneratorsModulsVM
    {
        public List<Modul> modListMV;
        public List<Modul> ModListMV { get => modListMV; set => modListMV = value; }
        public GeneratorsModulsVM()
        {
            Moduls m = new Moduls();
            ModListMV = m.SearchModulsByType(ModulType.Generator);
        }
    }
}
