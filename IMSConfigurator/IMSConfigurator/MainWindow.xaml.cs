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
		bool firstChoseCLK = true;
        public MainWindow()
        {
            InitializeComponent();
            m_moduls = new Moduls();
            powerModuls = m_moduls.SearchModulsByType(ModulType.Power);
            
        }

        private void M3000_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            PWR1_sp.IsEnabled = true;
            PWR2_sp.IsEnabled = true;
            PWR3_sp.IsEnabled = true;
            PWR4_sp.IsEnabled = true;
            CLK1_sp.IsEnabled = true;
            CPU_sp.IsEnabled = true;
            OUT1_sp.IsEnabled = true;
            OUT2_sp.IsEnabled = true;
            OUT3_sp.IsEnabled = true;
            OUT4_sp.IsEnabled = true;
            OUT5_sp.IsEnabled = true;
            OUT6_sp.IsEnabled = true;
            OUT7_sp.IsEnabled = true;
            OUT8_sp.IsEnabled = true;
            OUT9_sp.IsEnabled = true;
            OUT10_sp.IsEnabled = true;

            LoadDefaultM3000Conf();
        }

        private void LoadDefaultM3000Conf()
        {
            LoadDefaultM1000Conf();
            Modul rsc = m_moduls.SearchModul("IMS-SPT M3000", ModulType.Switcher);
            RSC_name.Text = rsc.Name;
            RSC_ID.Text = rsc.ID;
            RSC_discription.Text = rsc.Discription;
            RSC_price.Text = rsc.Price.ToString();
        }

        private void M1000_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            PWR1_sp.IsEnabled = true;
            PWR2_sp.IsEnabled = true;
            PWR3_sp.IsEnabled = false;
            PWR4_sp.IsEnabled = false;
            CLK1_sp.IsEnabled = true;
            CPU_sp.IsEnabled = true;
            OUT1_sp.IsEnabled = true;
            OUT2_sp.IsEnabled = true;
            OUT3_sp.IsEnabled = true;
            OUT4_sp.IsEnabled = true;
            OUT5_sp.IsEnabled = true;
            OUT6_sp.IsEnabled = true;
            OUT7_sp.IsEnabled = false;
            OUT8_sp.IsEnabled = false;
            OUT9_sp.IsEnabled = false;
            OUT10_sp.IsEnabled = false;
            if (CPU_chkbx.IsChecked == true)
                CloseModuleM1000();
            if (Double_CLK_chBx.IsChecked == true)
                CloseModuleM1000();
            if ( CLK1_name.Text != "Модуль" || string.IsNullOrEmpty(CLK1_name.Text))
                CloseModuleM1000();
            LoadDefaultM1000Conf();
            
            
        }

        private void LoadDefaultM1000Conf()
        {
            Modul m = m_moduls.SearchModul("IMS-PWR-AD10", ModulType.Power);
            PWR1_chBx.IsChecked = true;
            PWR1_name.Text = m.Name;
            PWR1_ID.Text = m.ID;
            PWR1_discription.Text = m.Discription;
            PWR1_price.Text = m.Price.ToString();

            m = m_moduls.SearchModul("IMS-CLK GLN-HQ", ModulType.Generator);
            
            CLK1_name.Text = m.Name;
            CLK1_name.IsEditable = false;
            CLK1_ID.Text = m.ID;
            CLK1_discription.Text = m.Discription;
            CLK1_price.Text = m.Price.ToString();
            
            m = m_moduls.SearchModul("IMS-CPU", ModulType.Processor);
            CPU_chkbx.IsChecked = true;
            CPU_name.Text = m.Name;
            CPU_ID.Text = m.ID;
            CPU_discription.Text = m.Discription;
            CPU_price.Text = m.Price.ToString();

            Double_CLK_chBx.IsChecked = false;
            RSC_name.Text = "";
            RSC_ID.Text = "";
            RSC_discription.Text = "";
            RSC_price.Text = "";
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
                Modul rsc = m_moduls.SearchModul("IMS-RSC M3000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }
			if (M1000_rbtn.IsChecked == true)
			{
				CloseModuleM1000();
			}
        }

        private void Double_CLK_chBx_Unchecked(object sender, RoutedEventArgs e)
        {
            CLK2_sp.IsEnabled = false;
            CLK2_name.Text = "Модуль";
            CLK2_ID.Text = "ID";
            CLK2_discription.Text = "Описание";
            CLK2_price.Text = "Price";
            if (M3000_rbtn.IsChecked == true)
            {
                Modul rsc = m_moduls.SearchModul("IMS-SPT M3000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }
			if (M1000_rbtn.IsChecked == true)
				OpenModuleM1000();

        }

		private void OpenModuleM1000()
		{
			if (!OUT4_sp.IsEnabled)
			{
				OUT4_sp.IsEnabled = true;
				return;
			}
			if (!OUT5_sp.IsEnabled)
			{
				OUT5_sp.IsEnabled = true;
				return;
			}
			if (!OUT6_sp.IsEnabled)
			{
				OUT6_sp.IsEnabled = true;
				return;
			}
		}

		private void CPU_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            Modul mod = m_moduls.SearchModul("IMS-CPU", ModulType.Processor);
            CPU_name.Text = mod.Name;
            CPU_ID.Text = mod.ID;
            CPU_discription.Text = mod.Discription;
            CPU_price.Text = mod.Price.ToString();
			if (M1000_rbtn.IsChecked == true)
				CloseModuleM1000();
        }

        private void CPU_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            CPU_name.Text = "Модуль";
            CPU_ID.Text = "ID";
            CPU_discription.Text = "Описание";
            CPU_price.Text = "Цена";
			if (M1000_rbtn.IsChecked == true)
				OpenModuleM1000();
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
            if (M3000_rbtn.IsChecked == true)
            {
                Modul rsc = m_moduls.SearchModul("IMS-SPT M3000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }
			if (M1000_rbtn.IsChecked == true && firstChoseCLK)
			{
				firstChoseCLK = false;
				CloseModuleM1000();
			}

        }

		private void CloseModuleM1000()
		{
			if (OUT6_sp.IsEnabled)
			{
				OUT6_chkbx.IsChecked = false;
				OUT6_sp.IsEnabled = false;
				return;
			}
			if (OUT5_sp.IsEnabled)
			{
				OUT5_chkbx.IsChecked = false;
				OUT5_sp.IsEnabled = false;
				return;
			}
			if (OUT4_sp.IsEnabled)
			{
				OUT4_chkbx.IsChecked = false;
				OUT4_sp.IsEnabled = false;
				return;
			}

		}

		private void OUT1_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT1_name.IsEnabled = true;
            ClearModulInfo(OUT1_name, OUT1_discription, OUT1_ID, OUT1_price);
            OUT1_name.Focus();
        }

        private void OUT2_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT2_name.IsEnabled = true;
            ClearModulInfo(OUT2_name, OUT2_discription, OUT2_ID, OUT2_price);
            OUT2_name.Focus();
        }

        private void OUT3_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT3_name.IsEnabled = true;
            ClearModulInfo(OUT3_name, OUT3_discription, OUT3_ID, OUT3_price);
            OUT3_name.Focus();
        }

        private void OUT4_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT4_name.IsEnabled = true;
            ClearModulInfo(OUT4_name, OUT4_discription, OUT4_ID, OUT4_price);
            OUT4_name.Focus();
        }

        private void OUT5_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT5_name.IsEnabled = true;
            ClearModulInfo(OUT5_name, OUT5_discription, OUT5_ID, OUT5_price);
            OUT5_name.Focus();
        }

        private void OUT6_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT6_name.IsEnabled = true;
            ClearModulInfo(OUT6_name, OUT6_discription, OUT6_ID, OUT6_price);
            OUT6_name.Focus();
        }

        private void OUT7_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT7_name.IsEnabled = true;
            ClearModulInfo(OUT7_name, OUT7_discription, OUT7_ID, OUT7_price);
            OUT7_name.Focus();
        }

        private void OUT8_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT8_name.IsEnabled = true;
            ClearModulInfo(OUT8_name, OUT8_discription, OUT8_ID, OUT8_price);
            OUT8_name.Focus();
        }

        private void OUT9_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT9_name.IsEnabled = true;
            ClearModulInfo(OUT9_name, OUT9_discription, OUT9_ID, OUT9_price);
            OUT9_name.Focus();
        }

        private void OUT10_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT10_name.IsEnabled = true;
            ClearModulInfo(OUT10_name, OUT10_discription, OUT10_ID, OUT10_price);
            OUT10_name.Focus();
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
            OUT3_name.Visibility = Visibility.Hidden;
            OUT4_name.Visibility = Visibility.Hidden;
            OUT5_name.Visibility = Visibility.Hidden;
            OUT2_Clear.Visibility = Visibility.Hidden;
            OUT3_Clear.Visibility = Visibility.Hidden;
            OUT4_Clear.Visibility = Visibility.Hidden;
            OUT5_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT1_name.Text);
        }

        private void OUT1_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT1_tooltip.Visibility = Visibility.Hidden;
            OUT2_name.Visibility = Visibility.Visible;
            OUT3_name.Visibility = Visibility.Visible;
            OUT4_name.Visibility = Visibility.Visible;
            OUT5_name.Visibility = Visibility.Visible;
            OUT2_Clear.Visibility = Visibility.Visible;
            OUT3_Clear.Visibility = Visibility.Visible;
            OUT4_Clear.Visibility = Visibility.Visible;
            OUT5_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT1_name, OUT1_discription, OUT1_ID, OUT1_price);
        }

        private void CheckOutModulNameAndId(TextBox name, TextBlock dis, TextBlock id, TextBlock price)
        {
            Modul t = m_moduls.SearchModulByIDAndName(id.Text, name.Text);
            if (t == null)
                ClearModulInfo(name, dis, id, price);
        }

        private void OUT2_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT2_tooltip.Visibility = Visibility.Visible;
            OUT3_name.Visibility = Visibility.Hidden;
            OUT4_name.Visibility = Visibility.Hidden;
            OUT5_name.Visibility = Visibility.Hidden;
            OUT6_name.Visibility = Visibility.Hidden;
            OUT3_Clear.Visibility = Visibility.Hidden;
            OUT4_Clear.Visibility = Visibility.Hidden;
            OUT5_Clear.Visibility = Visibility.Hidden;
            OUT6_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT2_name.Text);
        }

        private void OUT2_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT2_tooltip.Visibility = Visibility.Hidden;
            OUT3_name.Visibility = Visibility.Visible;
            OUT4_name.Visibility = Visibility.Visible;
            OUT5_name.Visibility = Visibility.Visible;
            OUT6_name.Visibility = Visibility.Visible;
            OUT3_Clear.Visibility = Visibility.Visible;
            OUT4_Clear.Visibility = Visibility.Visible;
            OUT5_Clear.Visibility = Visibility.Visible;
            OUT6_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT2_name, OUT2_discription, OUT2_ID, OUT2_price);
        }

        private void OUT3_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT3_tooltip.Visibility = Visibility.Visible;
            OUT4_name.Visibility = Visibility.Hidden;
            OUT5_name.Visibility = Visibility.Hidden;
            OUT6_name.Visibility = Visibility.Hidden;
            OUT7_name.Visibility = Visibility.Hidden;
            OUT4_Clear.Visibility = Visibility.Hidden;
            OUT5_Clear.Visibility = Visibility.Hidden;
            OUT6_Clear.Visibility = Visibility.Hidden;
            OUT7_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT3_name.Text);
        }

        private void OUT3_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT3_tooltip.Visibility = Visibility.Hidden;
            OUT4_name.Visibility = Visibility.Visible;
            OUT5_name.Visibility = Visibility.Visible;
            OUT6_name.Visibility = Visibility.Visible;
            OUT7_name.Visibility = Visibility.Visible;
            OUT4_Clear.Visibility = Visibility.Visible;
            OUT5_Clear.Visibility = Visibility.Visible;
            OUT6_Clear.Visibility = Visibility.Visible;
            OUT7_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT3_name, OUT3_discription, OUT3_ID, OUT3_price);
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
            OUT6_name.Visibility = Visibility.Hidden;
            OUT7_name.Visibility = Visibility.Hidden;
            OUT8_name.Visibility = Visibility.Hidden;
            OUT5_Clear.Visibility = Visibility.Hidden;
            OUT6_Clear.Visibility = Visibility.Hidden;
            OUT7_Clear.Visibility = Visibility.Hidden;
            OUT8_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT4_name.Text);
        }

        private void OUT4_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT4_tooltip.Visibility = Visibility.Hidden;
            OUT5_name.Visibility = Visibility.Visible;
            OUT6_name.Visibility = Visibility.Visible;
            OUT7_name.Visibility = Visibility.Visible;
            OUT8_name.Visibility = Visibility.Visible;
            OUT5_Clear.Visibility = Visibility.Visible;
            OUT6_Clear.Visibility = Visibility.Visible;
            OUT7_Clear.Visibility = Visibility.Visible;
            OUT8_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT4_name, OUT4_discription, OUT4_ID, OUT4_price);
        }

        private void OUT5_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT5_tooltip.Visibility = Visibility.Visible;
            OUT6_name.Visibility = Visibility.Hidden;
            OUT7_name.Visibility = Visibility.Hidden;
            OUT8_name.Visibility = Visibility.Hidden;
            OUT9_name.Visibility = Visibility.Hidden;
            OUT6_Clear.Visibility = Visibility.Hidden;
            OUT7_Clear.Visibility = Visibility.Hidden;
            OUT8_Clear.Visibility = Visibility.Hidden;
            OUT9_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT5_name.Text);
        }

        private void OUT5_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT5_tooltip.Visibility = Visibility.Hidden;
            OUT6_name.Visibility = Visibility.Visible;
            OUT7_name.Visibility = Visibility.Visible;
            OUT8_name.Visibility = Visibility.Visible;
            OUT9_name.Visibility = Visibility.Visible;
            OUT6_Clear.Visibility = Visibility.Visible;
            OUT7_Clear.Visibility = Visibility.Visible;
            OUT8_Clear.Visibility = Visibility.Visible;
            OUT9_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT5_name, OUT5_discription, OUT5_ID, OUT5_price);
        }

        private void OUT6_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT6_tooltip.Visibility = Visibility.Visible;
            OUT7_name.Visibility = Visibility.Hidden;
            OUT8_name.Visibility = Visibility.Hidden;
            OUT9_name.Visibility = Visibility.Hidden;
            OUT10_name.Visibility = Visibility.Hidden;
            OUT7_Clear.Visibility = Visibility.Hidden;
            OUT8_Clear.Visibility = Visibility.Hidden;
            OUT9_Clear.Visibility = Visibility.Hidden;
            OUT10_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT6_name.Text);
        }

        private void OUT6_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT6_tooltip.Visibility = Visibility.Hidden;
            OUT7_name.Visibility = Visibility.Visible;
            OUT8_name.Visibility = Visibility.Visible;
            OUT9_name.Visibility = Visibility.Visible;
            OUT10_name.Visibility = Visibility.Visible;
            OUT7_Clear.Visibility = Visibility.Visible;
            OUT8_Clear.Visibility = Visibility.Visible;
            OUT9_Clear.Visibility = Visibility.Visible;
            OUT10_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT6_name, OUT6_discription, OUT6_ID, OUT6_price);
        }

        private void OUT7_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT7_tooltip.Visibility = Visibility.Visible;
            OUT8_name.Visibility = Visibility.Hidden;
            OUT9_name.Visibility = Visibility.Hidden;
            OUT10_name.Visibility = Visibility.Hidden;
            OUT8_Clear.Visibility = Visibility.Hidden;
            OUT9_Clear.Visibility = Visibility.Hidden;
            OUT10_Clear.Visibility = Visibility.Hidden;
            
            SearchModuls(OUT7_name.Text);
        }

        private void OUT7_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT7_tooltip.Visibility = Visibility.Hidden;
            OUT8_name.Visibility = Visibility.Visible;
            OUT9_name.Visibility = Visibility.Visible;
            OUT10_name.Visibility = Visibility.Visible;
            OUT8_Clear.Visibility = Visibility.Visible;
            OUT9_Clear.Visibility = Visibility.Visible;
            OUT10_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT7_name, OUT7_discription, OUT7_ID, OUT7_price);
        }

        private void OUT8_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT8_tooltip.Visibility = Visibility.Visible;
            OUT9_name.Visibility = Visibility.Hidden;
            OUT10_name.Visibility = Visibility.Hidden;
            OUT9_Clear.Visibility = Visibility.Hidden;
            OUT10_Clear.Visibility = Visibility.Hidden;
          
            SearchModuls(OUT8_name.Text);
        }

        private void OUT8_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT8_tooltip.Visibility = Visibility.Hidden;
            OUT9_name.Visibility = Visibility.Visible;
            OUT10_name.Visibility = Visibility.Visible;
            OUT9_Clear.Visibility = Visibility.Visible;
            OUT10_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT8_name, OUT8_discription, OUT8_ID, OUT8_price);

        }

        private void OUT9_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT9_tooltip.Visibility = Visibility.Visible;
            OUT10_name.Visibility = Visibility.Hidden;
            OUT10_Clear.Visibility = Visibility.Hidden;
            SearchModuls(OUT9_name.Text);
        }

        private void OUT9_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT9_tooltip.Visibility = Visibility.Hidden;
            OUT10_name.Visibility = Visibility.Visible;
            OUT10_Clear.Visibility = Visibility.Visible;
            CheckOutModulNameAndId(OUT9_name, OUT9_discription, OUT9_ID, OUT9_price);
        }

        private void OUT10_name_GotFocus(object sender, RoutedEventArgs e)
        {
            OUT10_tooltip.Visibility = Visibility.Visible;
            SearchModuls(OUT10_name.Text);
        }

        private void OUT10_name_LostFocus(object sender, RoutedEventArgs e)
        {
            OUT10_tooltip.Visibility = Visibility.Hidden;
            CheckOutModulNameAndId(OUT10_name, OUT10_discription, OUT10_ID, OUT10_price);
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
            if (M1000_rbtn.IsChecked == true)
            {
                CreateM1000_Offer();
            }
            else if (M3000_rbtn.IsChecked == true)
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
            if (!m3.Status.check)
                MessageBox.Show(m3.Status.message);
            else
                CreateExcelOffer(m3);

            
           
        }

        private void CreateExcelOffer(Metronome3000 m3)
        {
            ExcelProvider ex = new ExcelProvider();
            ex.OpenExcelFile(@"1.xls", true);
            ex.WriteTOcell("F11", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            FillNamesAndDiscriptions(m3, ex);
            FillPrice(m3, ex);
        }

        private static void FillPrice(Metronome3000 m3, ExcelProvider ex)
        {
            double sumPrice = 0;
            double k = 2.25;
            foreach (var item in m3.KpLIST)
            {
                sumPrice += item.count * item.mod.Price * k;
            }
            ex.WriteTOcell("E21", sumPrice.ToString());
        }

        private static void FillNamesAndDiscriptions(Metronome3000 m3, ExcelProvider ex)
        {
            int i = 21;
            foreach (var item in m3.KpLIST)
            {
                if (item.count <= 1)
                    ex.WriteTOcell("B" + i, item.mod.Name);
                else
                    ex.WriteTOcell("B" + i, item.count + "x" + item.mod.Name);
                ex.WriteTOcell("C" + i, item.mod.ID + " " + item.mod.Discription);
                i++;
                if ((i - 21) < m3.KpLIST.Count)
                    ex.InsertRow(i);
                else
                    ex.RemoveRow(i);

            }
        }

        private List<Modul> CollectAllModuls()
        {
            List<Modul> temp = new List<Modul>();
            temp.Add(m_moduls.SearchModul("Устройство синхронизации частоты и времени Метроном - 3000", ModulType.Chassis));
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
            else
                temp.Add(m_moduls.SearchModul(RSC_name.Text, ModulType.Switcher));
            return temp;
        }

        private void CreateM1000_Offer()
        {
            List<Modul> m1000 = new List<Modul>();
            m1000 = CollectModulsForM1000();
            Metronome1000 metr1000 = new Metronome1000(m1000);
            if (!metr1000.Status.check)
                MessageBox.Show(metr1000.Status.message);
            else
                CreateExcelOfferForM1000(metr1000);

            //string str = "";
            //foreach (var item in m1000)
            //{
            //    str += item.Name + "\\";
            //}

            //MessageBox.Show(str);

            
            
        }

        private void CreateExcelOfferForM1000(Metronome1000 metr1000)
        {
            ExcelProvider ex = new ExcelProvider();
            ex.OpenExcelFile(@"1.xls", true);
            ex.WriteTOcell("F11", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            FillNamesAndDiscriptionsForM1000(metr1000, ex);
            FillPriceForM1000(metr1000, ex);
        }

        private void FillPriceForM1000(Metronome1000 metr1000, ExcelProvider ex)
        {
            double sumPrice = 0;
            double k = 2.25;
            foreach (var item in metr1000.KpLIST)
            {
                sumPrice += item.count * item.mod.Price * k;
            }
            ex.WriteTOcell("E21", sumPrice.ToString());
        }

        private void FillNamesAndDiscriptionsForM1000(Metronome1000 metr1000, ExcelProvider ex)
        {
            int i = 21;
            foreach (var item in metr1000.KpLIST)
            {
                if (item.count <= 1)
                    ex.WriteTOcell("B" + i, item.mod.Name);
                else
                    ex.WriteTOcell("B" + i, item.count + "x" + item.mod.Name);
                ex.WriteTOcell("C" + i, item.mod.ID + " " + item.mod.Discription);
                i++;
                if ((i - 21) < metr1000.KpLIST.Count)
                    ex.InsertRow(i);
                else
                    ex.RemoveRow(i);

            }
        }

        private List<Modul> CollectModulsForM1000()
        {
            List<Modul> temp = new List<Modul>();
            temp.Add(m_moduls.SearchModul("Устройство синхронизации частоты и времени Метроном - 1000", ModulType.Chassis));
            temp.Add(m_moduls.SearchModul("IMS-ACM M1000", ModulType.Cooler));
            if (GetCLKModulsForM1000()!=null)
                temp.AddRange(GetCLKModulsForM1000());
            temp.AddRange(GetCPUModul());
            temp.AddRange(GetOutModulsForM1000());
            temp.AddRange(GetPWRModulsF0rM1000());
            return temp;
        }

        private List<Modul> GetOutModulsForM1000()
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
            
            return temp;
        }

        private List<Modul> GetPWRModulsF0rM1000()
        {
            List<Modul> temp = new List<Modul>();
            if (PWR1_chBx.IsChecked == true)
                temp.Add(GetPwr(PWR1_name.Text));
            if (PWR2_chBx.IsChecked == true)
                temp.Add(GetPwr(PWR2_name.Text));
            return temp;
        }

        private List<Modul> GetCLKModulsForM1000()
        {
            List<Modul> temp = new List<Modul>();
            if (!string.IsNullOrEmpty(CLK1_name.Text))
            {
                if (CLK1_name.Text.Contains("DHQ"))
                {
                    MessageBox.Show("В Метрономе-1000 нельзя установить генератор DHQ!");
                    return null;
                }
                else
                {
                    Modul m = m_moduls.SearchModul(CLK1_name.Text, ModulType.Generator);
                    if (m != null)
                        temp.Add(m);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать генератор");
            }
            if (Double_CLK_chBx.IsChecked == true)
            {
                temp.Add(m_moduls.SearchModul(CLK1_name.Text, ModulType.Generator));
            }
            return temp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OUT1_tooltip_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void OUT1_tooltip_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void OUT1_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m!=null)
                OUT1_discription.Text = m.Discription;
        }

        private Modul GetModulUnderMouse(object sender, MouseEventArgs e)
        {
            var b = (ListBox)sender;
            var coordinatesAboutList = e.GetPosition(b);
            var itemInsideContainer = b.InputHitTest(coordinatesAboutList);
            var container = FindContainer(itemInsideContainer, b);
            if (container == null)
                return null;
                ListBoxItem item = (ListBoxItem)container;
            var m = (Modul)item.Content;
            return m;
        }

        private object FindContainer(IInputElement itemInsideContainer, ListBox b)
        {
            ListBoxItem candidate = null;
            for (DependencyObject currentItem = (DependencyObject)itemInsideContainer;
                 currentItem != null;
                 currentItem = VisualTreeHelper.GetParent(currentItem))
            {
                candidate = currentItem as ListBoxItem;
                if (candidate != null)
                    break;
            }
            if (candidate != null)
            {
                for (DependencyObject parent = (DependencyObject)itemInsideContainer;
                     parent != b;
                     parent = VisualTreeHelper.GetParent(parent))
                {
                    if (parent == null)
                        return null;
                }
            }
            return candidate;
        }

        private void OUT2_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT2_discription.Text = m.Discription;
        }

        private void OUT3_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT3_discription.Text = m.Discription;
        }

        private void OUT4_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT4_discription.Text = m.Discription;
        }

        private void StackPanel_MouseMove_1(object sender, MouseEventArgs e)
        {

        }

        private void OUT5_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT5_discription.Text = m.Discription;
        }

        private void StackPanel_MouseMove_2(object sender, MouseEventArgs e)
        {

        }

        private void OUT6_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT6_discription.Text = m.Discription;
        }

        private void StackPanel_MouseMove_3(object sender, MouseEventArgs e)
        {

        }

        private void OUT7_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT7_discription.Text = m.Discription;
        }

        private void OUT8_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT8_discription.Text = m.Discription;
        }

        private void OUT9_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT9_discription.Text = m.Discription;
        }

        private void OUT10_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
                OUT10_discription.Text = m.Discription;
        }

        private void OUT1_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT1_name, OUT1_discription, OUT1_ID, OUT1_price);
        }

        private void ClearModulInfo(TextBox name, TextBlock dis, TextBlock id, TextBlock price)
        {
            name.Text = "";
            dis.Text = "Описание";
            id.Text = "ID";
            price.Text = "Цена";
        }

        private void OUT2_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT2_name, OUT2_discription, OUT2_ID, OUT2_price);
        }

        private void OUT3_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT3_name, OUT3_discription, OUT3_ID, OUT3_price);
        }

        private void OUT4_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT4_name, OUT4_discription, OUT4_ID, OUT4_price);
        }

        private void OUT5_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT5_name, OUT5_discription, OUT5_ID, OUT5_price);
        }

        private void OUT6_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT6_name, OUT6_discription, OUT6_ID, OUT6_price);
        }

        private void OUT7_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT7_name, OUT7_discription, OUT7_ID, OUT7_price);
        }

        private void OUT8_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT8_name, OUT8_discription, OUT8_ID, OUT8_price);
        }

        private void OUT9_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT9_name, OUT9_discription, OUT9_ID, OUT9_price);
        }

        private void OUT10_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfo(OUT10_name, OUT10_discription, OUT10_ID, OUT10_price);
        }
    }
}
