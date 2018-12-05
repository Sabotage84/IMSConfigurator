using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMSConfigurator
{
    static class CheckM3000Model
    {
        public static bool Check(List<Modul> m3000)
        {
            if (!CheckForNull(m3000).check)
            {
                MessageBox.Show("Wrong modul!");
                return false;
            }
                
            return true;
        }

        private static err CheckForNull(List<Modul> m3000)
        {
            foreach (var item in m3000)
            {
                if (item == null)
                    return new err{ message = m3000.IndexOf(item).ToString(), check = false };
            }
            return new err {message="OK", check=true };
        }
    }

    class err
    {
        public string message;
        public bool check;
    }
}
