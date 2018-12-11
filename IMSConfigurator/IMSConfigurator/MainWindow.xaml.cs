using IMSConfigurator.ExcelProv;
using IMSConfigurator.Models;
using IMSConfigurator.ViewModel;
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
            Modul m = (Modul)CLK1_name.SelectedValue;
            CLK2_name.Text = m.Name;
            CLK2_ID.Text = m.ID;
            CLK2_discription.Text = m.Discription;
            CLK2_price.Text = m.Price.ToString();
            if (M3000_rbtn.IsChecked == true)
            {
                Modul rsc = m_moduls.SearchModul("IMS - RSC M3000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }
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

        private void PWR1_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelPWR(PWR1_name, PWR1_ID, PWR1_discription, PWR1_price, (Modul)PWR1_name.SelectedValue);
        }

        private void FeelPWR(ComboBox combo, TextBlock id, TextBlock disc, TextBlock price, Modul m)
        {
            combo.IsEditable = false;
             
            id.Text = m.ID;
            disc.Text = m.Discription;
            price.Text = m.Price.ToString();
        }

        private void PWR2_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelPWR(PWR2_name, PWR2_ID, PWR2_discription, PWR2_price, (Modul)PWR2_name.SelectedValue);
        }

        private void PWR3_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelPWR(PWR3_name, PWR3_ID, PWR3_discription, PWR3_price, (Modul)PWR3_name.SelectedValue);
        }

        private void PWR4_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelPWR(PWR4_name, PWR4_ID, PWR4_discription, PWR4_price, (Modul)PWR4_name.SelectedValue);
        }

        private void CLK1_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Double_CLK_chBx.IsEnabled = true;
            Modul m= (Modul)CLK1_name.SelectedValue;        
            CLK1_name.IsEditable = false;
            CLK1_ID.Text = m.ID;
            CLK1_discription.Text = m.Discription;
            CLK1_price.Text = m.Price.ToString();
            if (Double_CLK_chBx.IsEnabled==true && Double_CLK_chBx.IsChecked==true)
            {
                CLK2_name.Text = m.Name;
                CLK2_ID.Text = m.ID;
                CLK2_discription.Text = m.Discription;
                CLK2_price.Text = m.Price.ToString();
            }

        }

        private void OUT1_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT1_name.IsEnabled = true;
        }

        private void OUT2_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT2_name.IsEnabled = true;
        }

        private void OUT3_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT3_name.IsEnabled = true;
        }

        private void OUT4_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT4_name.IsEnabled = true;
        }

        private void OUT5_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT5_name.IsEnabled = true;
        }

        private void OUT6_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT6_name.IsEnabled = true;
        }

        private void OUT7_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT7_name.IsEnabled = true;
        }

        private void OUT8_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT8_name.IsEnabled = true;
        }

        private void OUT9_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT9_name.IsEnabled = true;
        }

        private void OUT10_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT10_name.IsEnabled = true;
        }

        private void OUT1_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT1_name.IsEnabled = false;
        }

        private void OUT2_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT2_name.IsEnabled = false;
        }

        private void OUT3_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT3_name.IsEnabled = false;
        }

        private void OUT4_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT4_name.IsEnabled = false;
        }

        private void OUT5_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT5_name.IsEnabled = false;
        }

        private void OUT6_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT6_name.IsEnabled = false;
        }

        private void OUT7_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT7_name.IsEnabled = false;
        }

        private void OUT8_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT8_name.IsEnabled = false;
        }

        private void OUT9_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT9_name.IsEnabled = false;
        }

        private void OUT10_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT10_name.IsEnabled = false;
        }

        private void OUT1_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT1_tooltip.Visibility= Visibility.Visible;
            OUT2_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT1_name.Text);
        }

        private void OUT1_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT1_tooltip.Visibility = Visibility.Hidden;
            OUT2_name.Visibility = Visibility.Visible;
            
        }

        private void OUT2_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT2_tooltip.Visibility = Visibility.Visible;
            OUT3_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT2_name.Text);
        }

        private void OUT2_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT2_tooltip.Visibility = Visibility.Hidden;
            OUT3_name.Visibility = Visibility.Visible;
            
        }

        private void OUT3_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT3_tooltip.Visibility = Visibility.Visible;
            OUT4_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT3_name.Text);
        }

        private void OUT3_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT3_tooltip.Visibility = Visibility.Hidden;
            OUT4_name.Visibility = Visibility.Visible;
            
        }

        private void OUT4_sp_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void OUT4_sp_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void OUT4_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT4_tooltip.Visibility = Visibility.Visible;
            OUT5_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT4_name.Text);
        }

        private void OUT4_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT4_tooltip.Visibility = Visibility.Hidden;
            OUT5_name.Visibility = Visibility.Visible;
        }

        private void OUT5_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT5_tooltip.Visibility = Visibility.Visible;
            OUT6_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT5_name.Text);
        }

        private void OUT5_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT5_tooltip.Visibility = Visibility.Hidden;
            OUT6_name.Visibility = Visibility.Visible;
        }

        private void OUT6_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT6_tooltip.Visibility = Visibility.Visible;
            OUT7_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT6_name.Text);
        }

        private void OUT6_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT6_tooltip.Visibility = Visibility.Hidden;
            OUT7_name.Visibility = Visibility.Visible;
        }

        private void OUT7_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT7_tooltip.Visibility = Visibility.Visible;
            OUT8_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT7_name.Text);
        }

        private void OUT7_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT7_tooltip.Visibility = Visibility.Hidden;
            OUT8_name.Visibility = Visibility.Visible;
        }

        private void OUT8_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT8_tooltip.Visibility = Visibility.Visible;
            OUT9_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT8_name.Text);
        }

        private void OUT8_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT8_tooltip.Visibility = Visibility.Hidden;
            OUT9_name.Visibility = Visibility.Visible;

        }

        private void OUT9_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT9_tooltip.Visibility = Visibility.Visible;
            OUT10_name.Visibility = Visibility.Hidden;
            SearchModuls(OUT9_name.Text);
        }

        private void OUT9_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT9_tooltip.Visibility = Visibility.Hidden;
            OUT10_name.Visibility = Visibility.Visible;
        }

        private void OUT10_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT10_tooltip.Visibility = Visibility.Visible;
            SearchModuls(OUT10_name.Text);
        }

        private void OUT10_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT10_tooltip.Visibility = Visibility.Hidden;
        }

        private void OUT4_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT4_name.Text);
        }

        private void SearchModuls(string searchText)
        {
            OutputModulsVM temp = (OutputModulsVM)OUTs_grp_bx.DataContext;
            temp.UdateList(searchText);
        }

        private void OUT1_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT1_name.Text);
        }

        private void OUT2_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT2_name.Text);
        }

        private void OUT3_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT3_name.Text);
        }

        private void OUT5_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT5_name.Text);
        }

        private void OUT6_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT6_name.Text);
        }

        private void OUT7_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT7_name.Text);
        }

        private void OUT8_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT8_name.Text);
        }

        private void OUT9_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT9_name.Text);
        }

        private void OUT10_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchModuls(OUT10_name.Text);
        }

        private void OUT1_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT1_tooltip.SelectedItem, OUT1_name, OUT1_ID, OUT1_discription, OUT1_price);
        }

        private void FeelOutModul(Modul m, TextBox name, TextBlock ID, TextBlock dis, TextBlock price)
        {
            if (m != null)
            {
                ID.Text = m.ID;
                dis.Text = m.Discription;
                price.Text = m.Price.ToString();
                string str = m.Name;
                name.Text = str;
            }
        }

        private void OUT2_name_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void OUT2_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT2_tooltip.SelectedItem, OUT2_name, OUT2_ID, OUT2_discription, OUT2_price);
        }

        private void OUT3_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT3_tooltip.SelectedItem, OUT3_name, OUT3_ID, OUT3_discription, OUT3_price);
        }

        private void OUT4_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT4_tooltip.SelectedItem, OUT4_name, OUT4_ID, OUT4_discription, OUT4_price);
        }

        private void OUT5_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT5_tooltip.SelectedItem, OUT5_name, OUT5_ID, OUT5_discription, OUT5_price);
        }

        private void OUT6_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT6_tooltip.SelectedItem, OUT6_name, OUT6_ID, OUT6_discription, OUT6_price);
        }

        private void OUT7_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT7_tooltip.SelectedItem, OUT7_name, OUT7_ID, OUT7_discription, OUT7_price);
        }

        private void OUT8_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT8_tooltip.SelectedItem, OUT8_name, OUT8_ID, OUT8_discription, OUT8_price);
        }

        private void OUT9_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT9_tooltip.SelectedItem, OUT9_name, OUT9_ID, OUT9_discription, OUT9_price);
        }

        private void OUT10_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeelOutModul((Modul)OUT10_tooltip.SelectedItem, OUT10_name, OUT10_ID, OUT10_discription, OUT10_price);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (M1000_rbtn.IsChecked==true)
            {
                CreateM1000_Offer();
            }
            else if (M3000_rbtn.IsChecked==true)
            {
                CreateM3000_Offer();
            }
            else
                MessageBox.Show("Выбирите шасси!");
        }

        private void CreateM3000_Offer()
        {
            
            List<Modul> m3000 = new List<Modul>();
            m3000=CollectAllModuls();
            Metronome3000 m3 = new Metronome3000(m3000);
            if (m3.Status.check)
                MessageBox.Show(m3.Status.message);
            else
                MessageBox.Show(m3.Status.message);

            MessageBox.Show(m3.FullName);
            CreateExcelOffer(m3);
        }

        private void CreateExcelOffer(Metronome3000 m3)
        {
             ExcelProvider e = new ExcelProvider();
            
        }

        private List<Modul> CollectAllModuls()
        {
            List<Modul> temp = new List<Modul>();
            temp.Add(m_moduls.SearchModul("Метроном-3000", ModulType.Chassis));
            temp.AddRange(GetCLKModuls());
            temp.AddRange(GetCPUModul());
            temp.AddRange(GetOutModuls());
            temp.AddRange(GetPWRModuls());
            return temp;
        }

        private List<Modul> GetOutModuls()
        {
            List<Modul> temp = new List<Modul>();
            if (OUT1_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT1_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT1_name.Text, ModulType.Output));
            if (OUT2_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT2_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT2_name.Text, ModulType.Output));
            if (OUT3_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT3_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT3_name.Text, ModulType.Output));
            if (OUT4_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT4_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT4_name.Text, ModulType.Output));
            if (OUT5_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT5_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT5_name.Text, ModulType.Output));
            if (OUT6_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT6_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT6_name.Text, ModulType.Output));
            if (OUT7_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT7_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT7_name.Text, ModulType.Output));
            if (OUT8_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT8_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT8_name.Text, ModulType.Output));
            if (OUT9_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT9_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT9_name.Text, ModulType.Output));
            if (OUT10_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT10_name.Text))
                    temp.Add(m_moduls.SearchModul(OUT10_name.Text, ModulType.Output));
            return temp;
        }

        private List<Modul> GetCPUModul()
        {
            List<Modul> temp = new List<Modul>();
            if (CPU_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(CPU_name.Text))
                 temp.Add(m_moduls.SearchModul(CPU_name.Text, ModulType.Processor));
            return temp;
        }

        private List<Modul> GetPWRModuls()
        {
            List<Modul> temp = new List<Modul>();
            if (PWR1_chBx.IsChecked == true)
                temp.Add( GetPwr(PWR1_name.Text));
            if (PWR2_chBx.IsChecked == true)
                temp.Add(GetPwr(PWR2_name.Text));
            if (PWR3_chBx.IsChecked == true)
                temp.Add(GetPwr(PWR3_name.Text));
            if (PWR4_chBx.IsChecked == true)
                temp.Add(GetPwr(PWR4_name.Text));

            return temp;
        }

        private Modul GetPwr(string p_name)
        {
            if (!string.IsNullOrEmpty(p_name))
                return m_moduls.SearchModul(p_name, ModulType.Power);
            else
                return null;
        }

        private List<Modul> GetCLKModuls()
        {
            List<Modul> temp = new List<Modul>();
            if (!string.IsNullOrEmpty(CLK1_name.Text))
            {
                Modul m = m_moduls.SearchModul(CLK1_name.Text, ModulType.Generator);
                if (m!=null)
                    temp.Add(m);
            }
            else
            {
                MessageBox.Show("Необходимо выбрать генератор");
            }
            if (Double_CLK_chBx.IsChecked == true)
            {
                temp.Add(m_moduls.SearchModul(CLK1_name.Text, ModulType.Generator));
                temp.Add(m_moduls.SearchModul(RSC_name.Text, ModulType.Switcher));
            }
            return temp;
        }

        private void CreateM1000_Offer()
        {
            throw new NotImplementedException();
        }
    }
}
