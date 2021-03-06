﻿using IMSConfigurator.Models;
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
       
        public ObservableCollection<Modul> modListMV;
        public List<Modul> allModuls;
        public event PropertyChangedEventHandler PropertyChanged;
		
		
		
		
		
		

        public ObservableCollection<Modul> ModListMV { get => modListMV;
            set 
            {
                modListMV = value;
                OnPropertyChanged(nameof(ModListMV));
               
            }
        }
        private void OnPropertyChanged([CallerMemberName]string prop="" )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void UdateList(string searchOutsName)
        {
            List<Modul> s_Moduls =new List<Modul>();
            modListMV = new ObservableCollection<Modul>(allModuls);
            foreach (var item in allModuls)
            {
                if (item.Name.ToLower().Contains(searchOutsName.ToLower()))
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
                ModListMV = new  ObservableCollection<Modul>(s_Moduls);
            }
        }

        public OutputModulsVM()
        {
            Moduls m = Moduls.modulInstance;
            allModuls = m.SearchModulsByType(ModulType.Output);
            allModuls.AddRange(m.SearchModulsByType(ModulType.DoubleOut));
            allModuls.AddRange(m.SearchModulsByType(ModulType.Input));
            modListMV = new ObservableCollection<Modul>(allModuls);
        }
    }
}
