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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMSConfigurator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Moduls m_moduls;
        List<Modul> powerModuls;
        public MainWindow()
        {
            InitializeComponent();
            m_moduls = new Moduls();
            powerModuls = m_moduls.SearchModulsByType(ModulType.Power);
            string str="";
            foreach (var item in powerModuls)
            {
                str =str+item.Name;
                str += "\n";
            }
            MessageBox.Show(str);
        }

        private void M3000_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            PWR3_sp.IsEnabled = true;
            PWR4_sp.IsEnabled = true;
            OUT7_sp.IsEnabled = true;
            OUT8_sp.IsEnabled = true;
            OUT9_sp.IsEnabled = true;
            OUT10_sp.IsEnabled = true;
        }

        private void M1000_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            PWR3_sp.IsEnabled = false;
            PWR4_sp.IsEnabled = false;
            OUT7_sp.IsEnabled = false;
            OUT8_sp.IsEnabled = false;
            OUT9_sp.IsEnabled = false;
            OUT10_sp.IsEnabled = false;
        }

        private void Double_CLK_chBx_Checked(object sender, RoutedEventArgs e)
        {
            CLK2_sp.IsEnabled = true;
            RSC_sp.IsEnabled = true;
        }

        private void Double_CLK_chBx_Unchecked(object sender, RoutedEventArgs e)
        {
            CLK2_sp.IsEnabled = false;
            RSC_sp.IsEnabled = false;
        }

       

        private void CPU_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            Modul mod = m_moduls.SearchModul("IMS - CPU", ModulType.Processor);
            CPU_name.Text = mod.Name;
            CPU_ID.Text = mod.ID;
            CPU_discription.Text = mod.Discription;
            CPU_price.Text = mod.Price.ToString();
        }

        private void CPU_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            CPU_name.Text = "Модуль";
            CPU_ID.Text = "ID";
            CPU_discription.Text = "Описание";
            CPU_price.Text = "Цена";
        }

        private void PWR1_chBx_Unchecked(object sender, RoutedEventArgs e)
        {
            PWR1_name.IsEnabled = false;
        }

        private void PWR2_chBx_Unchecked(object sender, RoutedEventArgs e)
        {
            PWR2_name.IsEnabled = false;
        }

        private void PWR3_chBx_Unchecked(object sender, RoutedEventArgs e)
        {
            PWR3_name.IsEnabled = false;
        }

        private void PWR4_chBx_Unchecked(object sender, RoutedEventArgs e)
        {
            PWR4_name.IsEnabled = false;
        }

        private void PWR1_chBx_Checked(object sender, RoutedEventArgs e)
        {
            PWR1_name.IsEnabled = true;
        }

        private void PWR2_chBx_Checked(object sender, RoutedEventArgs e)
        {
            PWR2_name.IsEnabled = true;
        }

        private void PWR3_chBx_Checked(object sender, RoutedEventArgs e)
        {
            PWR3_name.IsEnabled = true;
        }

        private void PWR4_chBx_Checked(object sender, RoutedEventArgs e)
        {
            PWR4_name.IsEnabled = true;
        }
    }
}
