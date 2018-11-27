using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMSConfigurator.ViewModel
{
    class OutputModulsVM : INotifyPropertyChanged
    {
        string searchOutsName;
        public ObservableCollection<Modul> modListMV;
        public List<Modul> allModuls;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Modul> ModListMV { get => modListMV;
            set {
                modListMV = value;
                OnPropertyChanged(nameof(ModListMV));
               
            }
        }
        public string SearchOutsName { get => searchOutsName;
            set {
                searchOutsName = value;
                OnPropertyChanged(nameof(SearchOutsName));
                UdateList(SearchOutsName);
            }
        }

        private void OnPropertyChanged([CallerMemberName]string prop="" )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void UdateList(string searchOutsName)
        {
            //MessageBox.Show("Test");
            List<Modul> s_Moduls =new List<Modul>();
            foreach (var item in allModuls)
            {
                if (item.Name.Contains(searchOutsName))
                {
                    s_Moduls.Add(item);
                }

            }
            if (s_Moduls.Count==0)
            {
                ModListMV = new ObservableCollection<Modul> (allModuls);
                
            }
            else
            {
                //ModListMV.Clear();
                //foreach (var item in collection)
                //{

                //}
                
                ModListMV = new  ObservableCollection<Modul>(s_Moduls);
            }
        }

        public OutputModulsVM()
        {
            Moduls m = new Moduls();
            allModuls = m.SearchModulsByType(ModulType.Output);
            allModuls.AddRange(m.SearchModulsByType(ModulType.Input));
            modListMV = new ObservableCollection<Modul>(allModuls);
        }
    }
}
