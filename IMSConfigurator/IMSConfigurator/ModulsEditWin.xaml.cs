using IMSConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IMSConfigurator
{
    /// <summary>
    /// Логика взаимодействия для ModulsEditWin.xaml
    /// </summary>
    public partial class ModulsEditWin : Window
    {
        Moduls allModuls = Moduls.modulInstance;
        public ModulsEditWin()
        {
            InitializeComponent();
        }

        private void ModulsForEdit_lstbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul changModul = allModuls.SearchModul(ModulsForEdit_lstbx.SelectedItem.ToString());
            Modul old = changModul;
            ModulNameForEdit.Text = changModul.Name;
            ModulPriceForEdit.Text = changModul.Price.ToString();
            ModulIDForEdit.Text = changModul.ID;
            ModulDiscriptionForEdit.Text = changModul.Discription;

        }
    }
}
