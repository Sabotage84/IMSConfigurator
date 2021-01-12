using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMSConfigurator.Models
{
    [Serializable]
    public class Metronome3000:IMSMetronome
    {
        public Metronome3000()
        {

        }
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

        internal override err CheckRightCount(List<Modul> m3000)
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
                    i++;
            }
            if (g>gMax)
                return new err { message = "Неверное количество генераторов!", check = false };
            if (p>pMax)
                return new err { message = "Неверное количество модулей электропитания!", check = false };
            if (c>cMax)
                return new err { message = "Неверное количество модулей центрального процессора!", check = false };
            if (o >oMax)
                return new err { message = "Неверное количество выходных модулей!", check = false };
            if (s>sMax)
                return new err { message = "Неверное количество модулей переключения!", check = false };
            if (i>0)
                if(i<=iMax)
                {
                    int m = 0, e = 0;
                    foreach (var item in m3000.Where(n=>n.Type==ModulType.Input))
                    {
                        if (item.Name.ToLower().Contains("mri"))
                            m++;
                        if (item.Name.ToLower().Contains("esi"))
                            e++;
                    }
                    if (e>1 || m>1)
                        return new err { message = "Неверное количество входных модулей!", check = false };
                }
            else
                return new err { message = "Неверное количество входных модулей!", check = false };


            return new err { message = "OK", check = true };
        }
    }

    

}
