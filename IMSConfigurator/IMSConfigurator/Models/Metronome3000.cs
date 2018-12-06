using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMSConfigurator.Models
{
    class Metronome3000
    {
        bool allOK = false;
        ModulForKP[] chs = new ModulForKP[1];
        ModulForKP[] clk = new ModulForKP[2];
        ModulForKP[] rsc = new ModulForKP[1];
        ModulForKP[] cpu = new ModulForKP[1];
        ModulForKP[] ots = new ModulForKP[10];
        ModulForKP[] pwr = new ModulForKP[4];

        public Metronome3000(List<Modul> m3000)
        {
            if (!CheckAll(m3000).check)
            {
                MessageBox.Show(CheckForNull(m3000).message);
                AllOK = false;
            }
            else
            {
                AllOK = true;
            }

        }

        public bool AllOK { get => allOK; set => allOK = value; }

        private err CheckAll(List<Modul> m3000)
        {
            if (!CheckForNull(m3000).check)
                return CheckForNull(m3000);
            if (!CheckRightCount(m3000).check)
                return CheckRightCount(m3000);

            return new err { message = "OK", check = true };
        }

        private err CheckForNull(List<Modul> m3000)
        {
            foreach (var item in m3000)
            {
                if (item == null)
                    return new err { message = m3000.IndexOf(item).ToString(), check = false };
            }
            return new err { message = "OK", check = true };
        }

        private err CheckRightCount(List<Modul> m3000)
        {

            int g = 0, gMax = 2;
            int p = 0, pMax = 4;
            int c = 0, cMax = 1;
            int o = 0, oMax = 10;
            int s = 0, sMax = 1;
            int i = 0, iMax = 2;
            foreach (var item in m3000)
            {
                
                if (item.Type == ModulType.Generator)
                    g++;
                if (item.Type == ModulType.Power)
                    p++;
                if (item.Type == ModulType.Processor)
                    c++;
                if (item.Type == ModulType.Output || item.Type== ModulType.Input)
                    o++;
                if (item.Type == ModulType.Switcher)
                   s++;
                if (item.Type == ModulType.Input)
                    s++;
            }
            if (g>gMax)
                return new err { message = "Wrong generator count!", check = false };
            if (p>pMax)
                return new err { message = "Wrong power count!", check = false };
            if (c>cMax)
                return new err { message = "Wrong cpu count!", check = false };
            if (o >oMax)
                return new err { message = "Wrong outputs count!", check = false };
            if (s>sMax)
                return new err { message = "Wrong rsc count!", check = false };
            if (i>iMax)
                return new err { message = "Wrong input count!", check = false };


            return new err { message = "OK", check = true };
        }



    }

    class err
    {
        public string message;
        public bool check;
    }

    class ModulForKP:Modul
    {
        int count;
    }

}
