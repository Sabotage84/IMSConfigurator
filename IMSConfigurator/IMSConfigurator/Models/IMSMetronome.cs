using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.Models
{
    class IMSMetronome
    {
        err status = new err { message = "OK", check = true };
        List<KPPosition> kpLIST = new List<KPPosition>();
        string fullName = "";

        public err Status { get => status; set => status = value; }
        internal List<KPPosition> KpLIST { get => kpLIST; set => kpLIST = value; }
        public string FullName { get => fullName; set => fullName = value; }

        internal err CheckAll(List<Modul> metronome)
        {
            if (!CheckForNull(metronome).check)
            {
                Status = CheckForNull(metronome);
                return Status;
            }
            if (!CheckRightCount(metronome).check)
            {
                Status = CheckRightCount(metronome);
                return Status;
            }
            if (!CheckNessesaryModuls(metronome).check)
            {
                Status = CheckNessesaryModuls(metronome);
                return Status;
            }

            KpLIST = metronome.GroupBy(x => x).Select(g => (new KPPosition(g.Key, g.Count()))).ToList();
            FullName = GetFullName(KpLIST);

            return new err { message = "OK", check = true };
        }

        internal string GetFullName(List<KPPosition> kpLIST)
        {
            string FullName = "";
            foreach (var item in kpLIST)
            {
                if (item.count > 1)
                {
                    FullName = FullName + item.count + " x " + item.mod.Name;
                    FullName += "\\";
                }
                else
                {
                    FullName = FullName + item.mod.Name;
                    FullName += "\\";
                }
            }
            if (!string.IsNullOrEmpty(FullName))
                FullName = FullName.Substring(0, FullName.Length - 1);
            return FullName;
        }

        internal err CheckForNull(List<Modul> metronome)
        {
            foreach (var item in metronome)
            {
                if (item == null)
                    return new err { message = metronome.IndexOf(item).ToString(), check = false };
            }
            return new err { message = "OK", check = true };
        }

        internal virtual err CheckRightCount(List<Modul> metronome)
        {
            return new err { message = "OK", check = true };
        }

        internal err CheckNessesaryModuls(List<Modul> metronome)
        {
            Modul pwr = null, cpu = null, clk = null;
            foreach (var item in metronome)
            {
                if (item.Type == ModulType.Generator)
                    clk = item;
                if (item.Type == ModulType.Processor)
                    cpu = item;
                if (item.Type == ModulType.Power)
                    pwr = item;
            }
            if (pwr == null || clk == null || cpu == null)
                return new err { message = "Нет необходимых модулей!", check = false };
            return new err { message = "OK", check = true };
        }

    }

    class err
    {
        public string message;
        public bool check;
    }

    class KPPosition
    {
        public Modul mod;
        public int count;

        public KPPosition(Modul m, int c)
        {
            this.mod = m;
            this.count = c;
        }
    }

}
