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
        err status = new err { message = "OK", check = true };
        ModulForKP[] chs = new ModulForKP[1];
        ModulForKP[] clk = new ModulForKP[2];
        ModulForKP[] rsc = new ModulForKP[1];
        ModulForKP[] cpu = new ModulForKP[1];
        ModulForKP[] ots = new ModulForKP[10];
        ModulForKP[] pwr = new ModulForKP[4];

        public Metronome3000(List<Modul> m3000)
        {
            if (CheckAll(m3000).check)
            {
                Status.check = true;
            }
            else
            {
                Status.check = false;
               
            }

        }

        public err Status { get => status; set => status = value; }

        private err CheckAll(List<Modul> m3000)
        {
            if (!CheckForNull(m3000).check)
            {
                Status = CheckForNull(m3000);
                return Status;
            }
            if (!CheckRightCount(m3000).check)
            {
                Status =CheckRightCount(m3000);
                return Status;
            }
            if (!CheckNessesaryModuls(m3000).check)
            {
                Status =CheckNessesaryModuls(m3000);
                return Status;
            }
            if (!CheckInputModuls(m3000).check)
            {
                Status = CheckInputModuls(m3000);
                return Status;
            }

            return new err { message = "OK", check = true };
        }

        private err CheckInputModuls(List<Modul> m3000)
        {
            
        }

        private err CheckNessesaryModuls(List<Modul> m3000)
        {
            Modul pwr=null, cpu=null, clk=null;
            foreach (var item in m3000)
            {
                if (item.Type == ModulType.Generator)
                    clk = item;
                if (item.Type == ModulType.Processor)
                    cpu = item;
                if (item.Type == ModulType.Power)
                    pwr = item;
            }
            if (pwr==null || clk==null || cpu==null)
                return new err { message = "Нет необходимых модулей!", check = false };
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
