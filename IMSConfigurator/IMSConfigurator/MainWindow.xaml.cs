﻿using IMSConfigurator.ExcelProv;
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
            
            try
            {   
                InitializeComponent();
                m_moduls = Moduls.modulInstance;
                history_cmbx.DataContext = (HistoryVM)(new HistoryVM(new History()));
                
            }
            catch (Exception)
            {
                Application.Current.Shutdown();
            } 
            
            powerModuls = m_moduls.SearchModulsByType(ModulType.Power);
            
        }

        private void M3000_rbtn_Checked(object sender, RoutedEventArgs e)
        {
            ChoseM3000Basic();
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
            ChoseM1000Basic();
        }

        private void LoadDefaultM1000Conf()
        {
            Modul m = m_moduls.SearchModul("IMS-PWR-AD10", ModulType.Power);
            PWR1_chBx.IsChecked = true;
            PWR1_name.Text = m.Name;
            PWR1_ID.Text = m.ID;
            PWR1_discription.Text = m.Discription;
            PWR1_price.Text = m.Price.ToString();

            m = m_moduls.SearchModul("IMS-CLK GNS-HQ", ModulType.Generator);
            
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
                Modul rsc = m_moduls.SearchModul("IMS-RSC M1000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
                Close4to6ModuleM1000();
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
            {
                RSC_name.Text = "Модуль";
                RSC_ID.Text = "ID";
                RSC_discription.Text = "Описание";
                RSC_price.Text = "Price";
                OpenModuleM1000();
            }

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
				Close4to6ModuleM1000();
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
            if(M1000_rbtn.IsChecked == true && CLK1_discription.Text.Contains("DHQ"))
            {
                CLK2_name.Text = "";
                CLK2_ID.Text = "";
                CLK2_discription.Text = "";
                CLK2_price.Text = "";
                Double_CLK_chBx.IsEnabled = false;
                Close4dModuleM1000();
            }
            else
            {
                Open4dModuleM1000();
            }


            if (Double_CLK_chBx.IsEnabled==true && Double_CLK_chBx.IsChecked==true)
            {
                CLK2_name.Text = m.Name;
                CLK2_ID.Text = m.ID;
                CLK2_discription.Text = m.Discription;
                CLK2_price.Text = m.Price.ToString();
            }

            if (M3000_rbtn.IsChecked == true && Double_CLK_chBx.IsChecked==false)
            {
                Modul rsc = m_moduls.SearchModul("IMS-SPT M3000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }

            if (M1000_rbtn.IsChecked == true && Double_CLK_chBx.IsChecked == false)
            {
                Modul rsc = m_moduls.SearchModul("IMS-SPT M1000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }

            if (M3000_rbtn.IsChecked == true && Double_CLK_chBx.IsChecked == true)
            {
                Modul rsc = m_moduls.SearchModul("IMS-RSC M3000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }

            if (M1000_rbtn.IsChecked==true && Double_CLK_chBx.IsChecked==true)
            {
                Modul rsc = m_moduls.SearchModul("IMS-RSC M1000", ModulType.Switcher);
                RSC_name.Text = rsc.Name;
                RSC_ID.Text = rsc.ID;
                RSC_discription.Text = rsc.Discription;
                RSC_price.Text = rsc.Price.ToString();
            }

			if (M1000_rbtn.IsChecked == true && firstChoseCLK)
			{
				firstChoseCLK = false;
				Close4to6ModuleM1000();
			}

        }

		private void Close4to6ModuleM1000()
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

        private void Close4dModuleM1000()
        {
            if (OUT4_sp.IsEnabled)
            {
                OUT4_chkbx.IsChecked = false;
                OUT4_sp.IsEnabled = false;
                return;
            }
        }

        private void Open4dModuleM1000()
        {
            if (!OUT4_sp.IsEnabled)
            {
                OUT4_sp.IsEnabled = true;
                return;
            }
        }

        private void OUT1_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT1_name.IsEnabled = true;
            if (OUT1_name.Text=="Модуль")
            {
                OUT1_name.Text = string.Empty;
            }
           
            OUT1_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT1_name, OUT1_discription, OUT1_ID, OUT1_price);
            OUT1_name.Focus();
        }

        private void OUT2_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT2_name.IsEnabled = true;
            if (OUT2_name.Text == "Модуль")
            {
                OUT2_name.Text = string.Empty;
            }
            OUT2_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT2_name, OUT2_discription, OUT2_ID, OUT2_price);
            OUT2_name.Focus();
        }

        private void OUT3_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT3_name.IsEnabled = true;
            if (OUT3_name.Text == "Модуль")
            {
                OUT3_name.Text = string.Empty;
            }
            OUT3_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT3_name, OUT3_discription, OUT3_ID, OUT3_price);
            OUT3_name.Focus();
        }

        private void OUT4_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT4_name.IsEnabled = true;
            if (OUT4_name.Text == "Модуль")
            {
                OUT4_name.Text = string.Empty;
            }
            OUT4_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT4_name, OUT4_discription, OUT4_ID, OUT4_price);
            OUT4_name.Focus();
        }

        private void OUT5_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT5_name.IsEnabled = true;
            if (OUT5_name.Text == "Модуль")
            {
                OUT5_name.Text = string.Empty;
            }
            OUT5_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT5_name, OUT5_discription, OUT5_ID, OUT5_price);
            OUT5_name.Focus();
        }

        private void OUT6_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT6_name.IsEnabled = true;
            if (OUT6_name.Text == "Модуль")
            {
                OUT6_name.Text = string.Empty;
            }
            OUT6_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT6_name, OUT6_discription, OUT6_ID, OUT6_price);
            OUT6_name.Focus();
        }

        private void OUT7_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT7_name.IsEnabled = true;
            if (OUT7_name.Text == "Модуль")
            {
                OUT7_name.Text = string.Empty;
            }
            OUT7_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT7_name, OUT7_discription, OUT7_ID, OUT7_price);
            OUT7_name.Focus();
        }

        private void OUT8_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT8_name.IsEnabled = true;
            if (OUT8_name.Text == "Модуль")
            {
                OUT8_name.Text = string.Empty;
            }
            OUT8_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT8_name, OUT8_discription, OUT8_ID, OUT8_price);
            OUT8_name.Focus();
        }

        private void OUT9_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT9_name.IsEnabled = true;
            if (OUT9_name.Text == "Модуль")
            {
                OUT9_name.Text = string.Empty;
            }
            OUT9_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT9_name, OUT9_discription, OUT9_ID, OUT9_price);
            OUT9_name.Focus();
        }

        private void OUT10_chkbx_Checked(object sender, RoutedEventArgs e)
        {
            OUT10_name.IsEnabled = true;
            if (OUT10_name.Text == "Модуль")
            {
                OUT10_name.Text = string.Empty;
            }
            OUT10_Clear.IsEnabled = true;
            //ClearModulInfoWithOUTName(OUT10_name, OUT10_discription, OUT10_ID, OUT10_price);
            OUT10_name.Focus();
        }

        private void OUT1_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT1_name.IsEnabled = false;
            OUT1_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT1_name.Text);
        }

        private void CheckForDoubleOutModulUnchecked(string text)
        {
            Modul m = m_moduls.SearchModul(text);
            if (m != null)
            {
                if (m.Type == ModulType.DoubleOut)
                {
                    OpenOutModul();
                }
            }
        }

        private void OpenOutModul()
        {
            if (OUT1_chkbx.IsChecked == false && !OUT1_chkbx.IsEnabled)
            {
                OUT1_chkbx.IsEnabled = true;
                OUT1_name.IsEnabled = true;
            }
            else if (OUT2_chkbx.IsChecked == false && !OUT2_chkbx.IsEnabled)
            {
                OUT2_chkbx.IsEnabled = true;
                OUT2_name.IsEnabled = true;
            }
            else if (OUT3_chkbx.IsChecked == false && !OUT3_chkbx.IsEnabled)
            {
                OUT3_chkbx.IsEnabled = true;
                OUT3_name.IsEnabled = true;
            }
            else if (OUT4_chkbx.IsChecked == false && !OUT4_chkbx.IsEnabled)
            {
                OUT4_chkbx.IsEnabled = true;
                OUT4_name.IsEnabled = true;
            }
            else if (OUT5_chkbx.IsChecked == false && !OUT5_chkbx.IsEnabled)
            {
                OUT5_chkbx.IsEnabled = true;
                OUT5_name.IsEnabled = true;
            }
            else if (OUT6_chkbx.IsChecked == false && !OUT6_chkbx.IsEnabled)
            {
                OUT6_chkbx.IsEnabled = true;
                OUT6_name.IsEnabled = true;
            }
            else if (OUT7_chkbx.IsChecked == false && !OUT7_chkbx.IsEnabled)
            {
                OUT7_chkbx.IsEnabled = true;
                OUT7_name.IsEnabled = true;
            }
            else if (OUT8_chkbx.IsChecked == false && !OUT8_chkbx.IsEnabled)
            {
                OUT8_chkbx.IsEnabled = true;
                OUT8_name.IsEnabled = true;
            }
            else if (OUT9_chkbx.IsChecked == false && !OUT9_chkbx.IsEnabled)
            {
                OUT9_chkbx.IsEnabled = true;
                OUT9_name.IsEnabled = true;
            }
            else if (OUT10_chkbx.IsChecked == false && !OUT10_chkbx.IsEnabled)
            {
                OUT10_chkbx.IsEnabled = true;
                OUT10_name.IsEnabled = true;
            }
        }

        private void OUT2_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT2_name.IsEnabled = false;
            OUT2_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT2_name.Text);
        }

        private void OUT3_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT3_name.IsEnabled = false;
            OUT3_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT3_name.Text);
        }

        private void OUT4_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT4_name.IsEnabled = false;
            OUT4_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT4_name.Text);
        }

        private void OUT5_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT5_name.IsEnabled = false;
            OUT5_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT5_name.Text);
        }

        private void OUT6_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT6_name.IsEnabled = false;
            OUT6_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT6_name.Text);
        }

        private void OUT7_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT7_name.IsEnabled = false;
            OUT7_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT7_name.Text);
        }

        private void OUT8_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT8_name.IsEnabled = false;
            OUT8_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT8_name.Text);
        }

        private void OUT9_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT9_name.IsEnabled = false;
            OUT9_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT9_name.Text);
        }

        private void OUT10_chkbx_Unchecked(object sender, RoutedEventArgs e)
        {
            OUT10_name.IsEnabled = false;
            OUT10_Clear.IsEnabled = false;
            CheckForDoubleOutModulUnchecked(OUT10_name.Text);
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
                ClearModulInfoWithOUTName(name, dis, id, price);
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
            Modul m = (Modul)OUT1_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT1_name, OUT1_ID, OUT1_discription, OUT1_price);
            }
            OUT1_tooltip.SelectedItem = null;
        }

        private bool CheckDoubleForModul(Modul modul)
        {
            if (modul != null) {
                if (modul.Type == ModulType.DoubleOut)
                {
                    if (CheckForFreeOutModul())
                    {
                        CloseOutModul();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Недьзя добавить модуль, так как он занимает два слота!");
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private void CloseOutModul()
        {
            if (OUT1_chkbx.IsChecked == false && OUT1_chkbx.IsEnabled)
            {
                OUT1_chkbx.IsEnabled = false;
                OUT1_name.IsEnabled = false;
            }
            else if (OUT2_chkbx.IsChecked == false && OUT2_chkbx.IsEnabled)
            {
                OUT2_chkbx.IsEnabled = false;
                OUT2_name.IsEnabled = false;
            }
            else if (OUT3_chkbx.IsChecked == false && OUT3_chkbx.IsEnabled)
            {
                OUT3_chkbx.IsEnabled = false;
                OUT3_name.IsEnabled = false;
            }
            else if (OUT4_chkbx.IsChecked == false && OUT4_chkbx.IsEnabled)
            {
                OUT4_chkbx.IsEnabled = false;
                OUT4_name.IsEnabled = false;
            }
            else if (OUT5_chkbx.IsChecked == false && OUT5_chkbx.IsEnabled)
            {
                OUT5_chkbx.IsEnabled = false;
                OUT5_name.IsEnabled = false;
            }
            else if (OUT6_chkbx.IsChecked == false && OUT6_chkbx.IsEnabled)
            {
                OUT6_chkbx.IsEnabled = false;
                OUT6_name.IsEnabled = false;
            }
            else if (OUT7_chkbx.IsChecked == false && OUT7_chkbx.IsEnabled)
            {
                OUT7_chkbx.IsEnabled = false;
                OUT7_name.IsEnabled = false;
            }
            else if (OUT8_chkbx.IsChecked == false && OUT8_chkbx.IsEnabled)
            {
                OUT8_chkbx.IsEnabled = false;
                OUT8_name.IsEnabled = false;
            }
            else if (OUT9_chkbx.IsChecked == false && OUT9_chkbx.IsEnabled)
            {
                OUT9_chkbx.IsEnabled = false;
                OUT9_name.IsEnabled = false;
            }
            else if (OUT10_chkbx.IsChecked == false && OUT10_chkbx.IsEnabled)
            {
                OUT10_chkbx.IsEnabled = false;
                OUT10_name.IsEnabled = false;
            }
        }

        private bool CheckForFreeOutModul()
        {
            if (OUT1_chkbx.IsChecked == false && OUT1_chkbx.IsEnabled==true)
                return true;
            if (OUT2_chkbx.IsChecked == false && OUT2_chkbx.IsEnabled == true)
                return true;
            if (OUT3_chkbx.IsChecked == false && OUT3_chkbx.IsEnabled == true)
                return true;
            if (OUT4_chkbx.IsChecked == false && OUT4_chkbx.IsEnabled == true)
                return true;
            if (OUT5_chkbx.IsChecked == false && OUT5_chkbx.IsEnabled == true)
                return true;
            if (OUT6_chkbx.IsChecked == false && OUT6_chkbx.IsEnabled == true)
                return true;
            if (OUT7_chkbx.IsChecked == false && OUT7_chkbx.IsEnabled == true)
                return true;
            if (OUT8_chkbx.IsChecked == false && OUT8_chkbx.IsEnabled == true)
                return true;
            if (OUT9_chkbx.IsChecked == false && OUT9_chkbx.IsEnabled == true)
                return true;
            if (OUT10_chkbx.IsChecked == false && OUT10_chkbx.IsEnabled == true)
                return true;
            return false;

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
            Modul m = (Modul)OUT2_tooltip.SelectedItem;
            CheckDoubleForModul(m);
            FeelOutModul(m, OUT2_name, OUT2_ID, OUT2_discription, OUT2_price);
            OUT2_tooltip.SelectedItem = null;
        }

        private void OUT3_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT3_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT3_name, OUT3_ID, OUT3_discription, OUT3_price);
            }
            OUT3_tooltip.SelectedItem = null;
        }

        private void OUT4_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT4_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT4_name, OUT4_ID, OUT4_discription, OUT4_price);
            }
            OUT4_tooltip.SelectedItem = null;
        }

        private void OUT5_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT5_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT5_name, OUT5_ID, OUT5_discription, OUT5_price);
            }
            OUT5_tooltip.SelectedItem = null;
        }

        private void OUT6_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT6_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT6_name, OUT6_ID, OUT6_discription, OUT6_price);
            }
            OUT6_tooltip.SelectedItem = null;
        }

        private void OUT7_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT7_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT7_name, OUT7_ID, OUT7_discription, OUT7_price);
            }
            OUT7_tooltip.SelectedItem = null;
        }

        private void OUT8_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT8_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT8_name, OUT8_ID, OUT8_discription, OUT8_price);
            }
            OUT8_tooltip.SelectedItem = null;
        }

        private void OUT9_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT9_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT9_name, OUT9_ID, OUT9_discription, OUT9_price);
            }
            OUT9_tooltip.SelectedItem = null;
        }

        private void OUT10_tooltip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Modul m = (Modul)OUT10_tooltip.SelectedItem;
            if (CheckDoubleForModul(m))
            {
                FeelOutModul(m, OUT10_name, OUT10_ID, OUT10_discription, OUT10_price);
            }
            OUT10_tooltip.SelectedItem = null;
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

        private async void CreateM3000_Offer()
        {
            
            List<Modul> m3000 = new List<Modul>();
            m3000=CollectAllModuls();
            Metronome3000 m3 = new Metronome3000(m3000);
            if (!m3.Status.check)
                MessageBox.Show(m3.Status.message);
            else
            {
                History log = new History();
                log.AddElement(m3000);
                log.SaveHistory();
                await Task.Run(() => CreateExcelOffer(m3));
            }

            
           
        }

        private void CreateExcelOffer(Metronome3000 m3)
        {
            ExcelProvider ex = new ExcelProvider();
            ex.OpenExcelFile(@"1.xls", true);
            ex.WriteTOcell("F11", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            string text = ex.ReadCell("C6");
            text += DateTime.Now.Year;
            ex.WriteTOcell("C6", text, 14,"Arial", true);
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
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT1_ID.Text, OUT1_name.Text));
            if (OUT2_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT2_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT2_ID.Text, OUT2_name.Text));
            if (OUT3_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT3_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT3_ID.Text, OUT3_name.Text));
            if (OUT4_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT4_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT4_ID.Text, OUT4_name.Text));
            if (OUT5_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT5_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT5_ID.Text, OUT5_name.Text));
            if (OUT6_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT6_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT6_ID.Text, OUT6_name.Text));
            if (OUT7_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT7_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT7_ID.Text, OUT7_name.Text));
            if (OUT8_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT8_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT8_ID.Text, OUT8_name.Text));
            if (OUT9_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT9_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT9_ID.Text, OUT9_name.Text));
            if (OUT10_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT10_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT10_ID.Text, OUT10_name.Text));
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

        private async void CreateM1000_Offer()
        {
            List<Modul> m1000 = new List<Modul>();
            m1000 = CollectModulsForM1000();
            Metronome1000 metr1000 = new Metronome1000(m1000);
            if (!metr1000.Status.check)
                MessageBox.Show(metr1000.Status.message);
            else
            {
                History log = new History();
                log.AddElement(m1000);
                log.SaveHistory();
                await Task.Run(() => CreateExcelOfferForM1000(metr1000));
            }
        }

        private void CreateExcelOfferForM1000(Metronome1000 metr1000)
        {
            ExcelProvider ex = new ExcelProvider();
            ex.OpenExcelFile(@"1.xls", true);
            ex.WriteTOcell("F11", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            string text = ex.ReadCell("C6");
            text += DateTime.Now.Year;
            ex.WriteTOcell("C6", text, 14, "Arial", true);
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
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT1_ID.Text, OUT1_name.Text));
            if (OUT2_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT2_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT2_ID.Text, OUT2_name.Text));
            if (OUT3_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT3_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT3_ID.Text, OUT3_name.Text));
            if (OUT4_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT4_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT4_ID.Text, OUT4_name.Text));
            if (OUT5_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT5_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT5_ID.Text, OUT5_name.Text));
            if (OUT6_chkbx.IsChecked == true)
                if (!string.IsNullOrEmpty(OUT6_name.Text))
                    temp.Add(m_moduls.SearchModulByIDAndName(OUT6_ID.Text, OUT6_name.Text));
            
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
                Modul m = m_moduls.SearchModul(CLK1_name.Text, ModulType.Generator);
                if (m != null)
                {
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
                temp.Add(m_moduls.SearchModul(RSC_name.Text, ModulType.Switcher));
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
            if (m != null)
            {
                OUT1_discription.Text = m.Discription;
                OUT1_ID.Text = m.ID;
                OUT1_price.Text = m.Price.ToString();
            }

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
            {
                OUT2_discription.Text = m.Discription;
                OUT2_ID.Text = m.ID;
                OUT2_price.Text = m.Price.ToString();
            }
                
        }

        private void OUT3_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT3_discription.Text = m.Discription;
                OUT3_ID.Text = m.ID;
                OUT3_price.Text = m.Price.ToString();
            }
               
        }

        private void OUT4_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT4_discription.Text = m.Discription;
                OUT4_ID.Text = m.ID;
                OUT4_price.Text = m.Price.ToString();
            }
                
        }

        private void StackPanel_MouseMove_1(object sender, MouseEventArgs e)
        {

        }

        private void OUT5_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT5_discription.Text = m.Discription;
                OUT5_ID.Text = m.ID;
                OUT5_price.Text = m.Price.ToString();
            }
               
        }

        private void StackPanel_MouseMove_2(object sender, MouseEventArgs e)
        {

        }

        private void OUT6_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT6_discription.Text = m.Discription;
                OUT6_ID.Text = m.ID;
                OUT6_price.Text = m.Price.ToString();
            }
                
        }

        private void StackPanel_MouseMove_3(object sender, MouseEventArgs e)
        {

        }

        private void OUT7_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT7_discription.Text = m.Discription;
                OUT7_ID.Text = m.ID;
                OUT7_price.Text = m.Price.ToString();
            }
               
        }

        private void OUT8_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT8_discription.Text = m.Discription;
                OUT8_ID.Text = m.ID;
                OUT8_price.Text = m.Price.ToString();
            }
               
        }

        private void OUT9_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT9_discription.Text = m.Discription;
                OUT9_ID.Text = m.ID;
                OUT9_price.Text = m.Price.ToString();
            }
              
        }

        private void OUT10_tooltip_MouseMove(object sender, MouseEventArgs e)
        {
            Modul m = GetModulUnderMouse(sender, e);
            if (m != null)
            {
                OUT10_discription.Text = m.Discription;
                OUT10_ID.Text = m.ID;
                OUT10_price.Text = m.Price.ToString();
            }
                
        }

        private void OUT1_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT1_name, OUT1_discription, OUT1_ID, OUT1_price);
        }

        private void ClearModulInfoWithOUTName(TextBox name, TextBlock dis, TextBlock id, TextBlock price)
        {
            //name.Text = "";
            dis.Text = "Описание";
            id.Text = "ID";
            price.Text = "Цена";
        }

        private void ClearModulInfoWithName(TextBox name, TextBlock dis, TextBlock id, TextBlock price)
        {
            name.Text = "";
            dis.Text = "Описание";
            id.Text = "ID";
            price.Text = "Цена";
        }

        private void OUT2_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT2_name, OUT2_discription, OUT2_ID, OUT2_price);
        }

        private void OUT3_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT3_name, OUT3_discription, OUT3_ID, OUT3_price);
        }

        private void OUT4_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT4_name, OUT4_discription, OUT4_ID, OUT4_price);
        }

        private void OUT5_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT5_name, OUT5_discription, OUT5_ID, OUT5_price);
        }

        private void OUT6_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT6_name, OUT6_discription, OUT6_ID, OUT6_price);
        }

        private void OUT7_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT7_name, OUT7_discription, OUT7_ID, OUT7_price);
        }

        private void OUT8_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT8_name, OUT8_discription, OUT8_ID, OUT8_price);
        }

        private void OUT9_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT9_name, OUT9_discription, OUT9_ID, OUT9_price);
        }

        private void OUT10_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearModulInfoWithName(OUT10_name, OUT10_discription, OUT10_ID, OUT10_price);
        }

        private void history_cmbx_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void history_cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameServer = history_cmbx.SelectedItem.ToString();
            //MessageBox.Show(nameServer);
            if(nameServer.Contains("Метроном - 1000"))
            {
                History h = new History();
                if (h.HistoryLog.ContainsKey(nameServer))
                {
                    FeelOfferM1000(h.HistoryLog[nameServer]);
                }
            }
            else
            {
                History h = new History();
                if (h.HistoryLog.ContainsKey(nameServer))
                {
                    FeelOfferM3000(h.HistoryLog[nameServer]);
                }
            }
        }

        private void FeelOfferM3000(List<Modul> list)
        {
            M3000_rbtn.IsChecked = true;
            ClearAllModuls();
            FeelModuls(list);
        }

        private void ChoseM3000Basic()
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

        private void FeelModuls(List<Modul> list)
        {
            string temp = "";
            Modul t = new Modul();
            PWR1_chBx.IsChecked = false;
            foreach (var item in list)
            {
                if (item.Type==ModulType.Generator)
                {
                    t = item;
                    foreach (var clkMod in CLK1_name.Items)
                    {
                        Modul tmod = (Modul)clkMod;
                        if (tmod.Name == t.Name)
                            CLK1_name.SelectedItem = clkMod;
                    }
                    CLK1_name.SelectedItem = item;
                    break;
                }
            }
            list.Remove(t);
            foreach (var item in list)
            {
                temp += item.Name + "\n";
                
                switch (item.Type)
                {
                    case ModulType.Power:
                        AddPowerModul(item);
                        break;
                    case ModulType.Generator:
                        break;
                    case ModulType.Processor:
                        break;
                    case ModulType.Output:
                        AddOutModul(item);
                        break;
                    case ModulType.DoubleOut:
                        AddOutModul(item);
                        break;
                    case ModulType.Cooler:
                        break;
                    case ModulType.Input:
                        AddInputModul(item);
                        break;
                    case ModulType.Switcher:
                        AddSwitchModul(item);
                        break;
                    case ModulType.Chassis:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddSwitchModul(Modul item)
        {
            if (item.Name.Contains("RSC"))
            {
                Double_CLK_chBx.IsChecked = true;
            }
            else
            {
                RSC_name.Text = item.Name;
                RSC_ID.Text = item.ID;
                RSC_discription.Text = item.Discription;
                RSC_price.Text = item.Price.ToString();
            }
        }

        private void AddInputModul(Modul item)
        {
            AddOutModulBasic(item);
        }

        private void AddOutModul(Modul item)
        {
            AddOutModulBasic(item);
        }

        private void AddOutModulBasic(Modul item)
        {
            if (OUT1_chkbx.IsChecked==false)
            {
                OUT1_chkbx.IsChecked = true;
                FeelOutModul(item, OUT1_name, OUT1_ID, OUT1_discription, OUT1_price);
               CLK1_name.Focus();
            }
            else if(OUT2_chkbx.IsChecked==false)
            {
                OUT2_chkbx.IsChecked = true;
                FeelOutModul(item, OUT2_name, OUT2_ID, OUT2_discription, OUT2_price);
                CLK1_name.Focus();
            }
            else if (OUT3_chkbx.IsChecked == false)
            {
                OUT3_chkbx.IsChecked = true;
                FeelOutModul(item, OUT3_name, OUT3_ID, OUT3_discription, OUT3_price);
                CLK1_name.Focus();
                
            }
            else if (OUT4_chkbx.IsChecked == false)
            {
                OUT4_chkbx.IsChecked = true;
                FeelOutModul(item, OUT4_name, OUT4_ID, OUT4_discription, OUT4_price);
                CLK1_name.Focus();
            }
            else if (OUT5_chkbx.IsChecked == false)
            {
                OUT5_chkbx.IsChecked = true;
                FeelOutModul(item, OUT5_name, OUT5_ID, OUT5_discription, OUT5_price);
                CLK1_name.Focus();
            }
            else if (OUT6_chkbx.IsChecked == false)
            {
                OUT6_chkbx.IsChecked = true;
                FeelOutModul(item, OUT6_name, OUT6_ID, OUT6_discription, OUT6_price);
                CLK1_name.Focus();
            }
            else if (OUT7_chkbx.IsChecked == false)
            {
                OUT7_chkbx.IsChecked = true;
                FeelOutModul(item, OUT7_name, OUT7_ID, OUT7_discription, OUT7_price);
                CLK1_name.Focus();
            }
            else if (OUT8_chkbx.IsChecked == false)
            {
                OUT8_chkbx.IsChecked = true;
                FeelOutModul(item, OUT8_name, OUT8_ID, OUT8_discription, OUT8_price);
                CLK1_name.Focus();
            }
            else if (OUT9_chkbx.IsChecked == false)
            {
                OUT9_chkbx.IsChecked = true;
                FeelOutModul(item, OUT9_name, OUT9_ID, OUT9_discription, OUT9_price);
                CLK1_name.Focus();
            }
            else if (OUT10_chkbx.IsChecked == false)
            {
                OUT10_chkbx.IsChecked = true;
                FeelOutModul(item, OUT10_name, OUT10_ID, OUT10_discription, OUT10_price);
                CLK1_name.Focus();
            }
        }

        private void AddCLKModul(Modul item)
        {
            throw new NotImplementedException();
        }

        private void AddPowerModul(Modul item)
        {
            if (PWR1_chBx.IsChecked==false)
            {
                PWR1_chBx.IsChecked = true;
                SelectPWRMod(item,PWR1_name);
                
                FeelPWR(PWR1_name, PWR1_ID, PWR1_discription, PWR1_price, item);
            }
            else if(PWR2_chBx.IsChecked==false)
            {
                PWR2_chBx.IsChecked = true;
                SelectPWRMod(item, PWR2_name);
                FeelPWR(PWR2_name, PWR2_ID, PWR2_discription, PWR2_price, item);
            }
            else if (PWR3_chBx.IsChecked==false)
            {
                PWR3_chBx.IsChecked = true;
                SelectPWRMod(item, PWR3_name);
                FeelPWR(PWR3_name, PWR3_ID, PWR3_discription, PWR3_price, item);
            }
            else if(PWR4_chBx.IsChecked==false)
            {
                PWR4_chBx.IsChecked = true;
                SelectPWRMod(item, PWR4_name);
                FeelPWR(PWR4_name, PWR4_ID, PWR4_discription, PWR4_price, item);
            }
        }

        private void SelectPWRMod(Modul item, ComboBox pWR_name)
        {
            foreach (var pMod in pWR_name.Items)
            {
                Modul t = (Modul)pMod;
                if (t.Name == item.Name)
                    pWR_name.SelectedItem = pMod;
            }
        }

        private void ChoseM1000Basic()
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
                Close4to6ModuleM1000();
            if (Double_CLK_chBx.IsChecked == true)
                Close4to6ModuleM1000();
            if (CLK1_name.Text != "Модуль" || string.IsNullOrEmpty(CLK1_name.Text))
                Close4to6ModuleM1000();
            LoadDefaultM1000Conf();
        }

        private void FeelOfferM1000(List<Modul> list)
        {
            M1000_rbtn.IsChecked = true;
            ClearAllModuls();
            FeelModuls(list);
        }

        private void ClearAllModuls()
        {
            PWR1_chBx.IsChecked = false;
            PWR2_chBx.IsChecked = false;
            PWR3_chBx.IsChecked = false;
            PWR4_chBx.IsChecked = false;
            Double_CLK_chBx.IsChecked = false;
            OUT1_chkbx.IsChecked = false;
            OUT2_chkbx.IsChecked = false;
            OUT3_chkbx.IsChecked = false;
            OUT4_chkbx.IsChecked = false;
            OUT5_chkbx.IsChecked = false;
            OUT6_chkbx.IsChecked = false;
            OUT7_chkbx.IsChecked = false;
            OUT8_chkbx.IsChecked = false;
            OUT9_chkbx.IsChecked = false;
            OUT10_chkbx.IsChecked = false;


        }

        private void InfoMenuIt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа для создания КП на IMS серию.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ModulsEditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ModulsEditWin modulswin = new ModulsEditWin();
            modulswin.Owner = this;
            modulswin.ShowDialog();
        }

        public void CheckModulsForEdit(Modul m)
        {

        }
    }
}
