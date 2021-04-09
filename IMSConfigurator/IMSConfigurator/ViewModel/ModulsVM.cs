using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.ViewModel
{
    class ModulsVM:BaseVM
    {
        ObservableCollection<string> moduls;
        
        public ModulsVM()
        {
            Models.Moduls modelModuls = Models.Moduls.modulInstance;
            List<Modul> allModuls=modelModuls.GetAllModuls();
            Moduls = new ObservableCollection<string>();
            foreach (var item in allModuls)
            {
                Moduls.Add(item.Name);
            }
        }

        public ObservableCollection<string> Moduls { get => moduls; set => moduls = value; }

        public void UpdateList(string oldName, string newName)
        {
            

            int ind = Moduls.IndexOf(oldName);
            Moduls[ind] = newName;
            
            //SortNames();

        }

        private void SortNames()
        {
            List<string> temp = new List<string>();
            foreach (var item in Moduls)
            {
                temp.Add(item);
                temp.Sort();
            }

            Moduls.Clear();
            foreach (var item in temp)
            {
                Moduls.Add(item);
            }
        }
    }
}
