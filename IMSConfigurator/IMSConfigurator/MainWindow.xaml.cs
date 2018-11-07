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
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
