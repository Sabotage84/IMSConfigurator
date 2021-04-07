using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSConfigurator.ViewModel
{
    class ModulsVM:BaseVM
    {
        List<string> moduls;
        
        public ModulsVM()
        {
            Models.Moduls modelModuls = Models.Moduls.modulInstance;
            List<Modul> allModuls=modelModuls.GetAllModuls();
            Moduls = new List<string>();
            foreach (var item in allModuls)
            {
                Moduls.Add(item.Name);
            }
        }

        public List<string> Moduls { get => moduls; set { moduls = value; OnPropertyChanged(); } }

        public void UpdateList(string oldName, string newName)
        {
            //Moduls.Remove(oldName);
            //Moduls.Add(newName);


            //List<string> temp = new List<string>();
            //temp = Moduls;
            //temp.Remove(oldName);
            //temp.Add(newName);
            //Moduls = new List<string>();
            //foreach (var item in temp)
            //{
            //    Moduls.Add(item);
            //}

            int ind = Moduls.IndexOf(oldName);
            Moduls[ind] = newName;
            //OnPropertyChanged();

        }
    }
}
