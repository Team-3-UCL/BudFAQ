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
using ViewModel.SupportAppVM;

namespace SupportApp
{
    /// <summary>
    /// Interaction logic for VideoManager.xaml
    /// </summary>
    public partial class ManualManager : Page
    {

        ManualVM mvm;
        public ManualManager()
        {
            InitializeComponent();
            mvm = new();
            DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ValidateNumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            mvm.Link = tbLink.Text;
            mvm.Title = tbTitle.Text;
        }
    }
}
