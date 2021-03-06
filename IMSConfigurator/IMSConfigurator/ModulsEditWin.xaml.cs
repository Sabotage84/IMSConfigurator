﻿using IMSConfigurator.Models;
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
using System.Windows.Shapes;

namespace IMSConfigurator
{
    /// <summary>
    /// Логика взаимодействия для ModulsEditWin.xaml
    /// </summary>
    public partial class ModulsEditWin : Window
    {
        Moduls allModuls = Moduls.modulInstance;
        ModulsVM mvm;
        public ModulsEditWin()
        {
            InitializeComponent();
            mvm = (ModulsVM)ModulsForEdit_lstbx.DataContext;
            mvm.SortNames();
        }

        private void ModulsForEdit_lstbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModulsForEdit_lstbx.SelectedItem != null)
            {
                Modul changModul = allModuls.SearchModul(ModulsForEdit_lstbx.SelectedItem.ToString());
                if (changModul != null)
                {
                    ModulNameForEdit.Text = changModul.Name;
                    ModulPriceForEdit.Text = changModul.Price.ToString();
                    ModulIDForEdit.Text = changModul.ID;
                    ModulDiscriptionForEdit.Text = changModul.Discription;
                }
                else
                {
                    MessageBox.Show("Модуль не найден!");
                    ModulsForEdit_lstbx.SelectedIndex = 0;
                }
            }
        }

        private void EditModul_btn_Click(object sender, RoutedEventArgs e)
        {
            Modul old = allModuls.SearchModul(ModulsForEdit_lstbx.SelectedItem.ToString());
            Modul newModul = new Modul(ModulNameForEdit.Text, ModulIDForEdit.Text, ModulDiscriptionForEdit.Text, double.Parse(ModulPriceForEdit.Text), old.Type);
             
            mvm.UpdateList(old.Name, newModul.Name);
            
            allModuls.EditModul(old, newModul);
            UpdateMainWinModuls(newModul);
            mvm.SortNames();
        }

        private void UpdateMainWinModuls(Modul newModul)
        {
            MainWindow mw=(MainWindow)Owner;
            
            mw.CheckModulsForEdit(newModul);
        }

        private void cancel_btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ModulNameForEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ModulNameForEdit.Foreground = Brushes.Red;
        }
    }
}
