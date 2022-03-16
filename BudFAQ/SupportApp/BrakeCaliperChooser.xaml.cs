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
using System.Collections.ObjectModel;
using Model;

namespace SupportApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BrakeCaliperChooser : Window
    {
        public List<BrakeCaliper> CheckedCalipers = new();
        public BrakeCaliperChooser()
        {
            InitializeComponent();
        }

        public BrakeCaliperChooser(List<BrakeCaliper> used, List<BrakeCaliper> nonUsed)
        {
            InitializeComponent();
            NonUsedBrakeCalipers.ItemsSource = nonUsed;
            NonUsedBrakeCalipers.Items.Refresh();
            UsedBrakeCalipers.ItemsSource = used;
            UsedBrakeCalipers.Items.Refresh();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckedCalipers.Add((sender as CheckBox).DataContext as BrakeCaliper);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckedCalipers.Remove((sender as CheckBox).DataContext as BrakeCaliper);
        }
    }
}
