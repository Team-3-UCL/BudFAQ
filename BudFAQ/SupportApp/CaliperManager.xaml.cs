﻿using System;
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
using ViewModel.SupportAppVM;

namespace SupportApp
{
    /// <summary>
    /// Interaction logic for VideoManager.xaml
    /// </summary>
    public partial class CaliperManager : Page
    {

        BrakeCaliperManagerVM mvm;
        public CaliperManager()
        {
            InitializeComponent();
            mvm = new();
            DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void btnNewClick(object sender, RoutedEventArgs e)
        {
            mvm.AddDefaultBrakeCaliper();
            Calipers.ItemsSource = mvm.BrakeCalipers;
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            mvm.DeleteSelectedBrakeCaliper();
            Calipers.ItemsSource = mvm.BrakeCalipers;
        }

        private void ValidateNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            mvm.UpdateSelectedBrakeCaliper();
        }
    }
}
