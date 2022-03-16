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
using ViewModel;
using ViewModel.SupportAppVM;

namespace SupportApp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ArticleManager : Page
    {
        ArticleManagerVM mvm;

        public ArticleManager()
        {
            InitializeComponent();
            mvm = new();
            DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnNewClick(object sender, RoutedEventArgs e)
        {
            mvm.AddDefaultArticle();
            Articles.ItemsSource = mvm.Articles;
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            mvm.DeleteSelectedArticle();
            Articles.ItemsSource = mvm.Articles;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            mvm.UpdateSelectedArticle();
        }
        private void btnBrakeCaliper_Click(object sender, RoutedEventArgs e)
        {
            BrakeCaliperChooser chooser = new();
            chooser.UsedBrakeCalipers.ItemsSource = null;
            chooser.NonUsedBrakeCalipers.ItemsSource = null;
            chooser.UsedBrakeCalipers.ItemsSource = mvm.ChosenArticle.BrakeCalipers;
            chooser.NonUsedBrakeCalipers.ItemsSource = mvm.NonChosenBrakeCalipers;
            chooser.NonUsedBrakeCalipers.Items.Refresh();
            chooser.ShowDialog();
            
            
        }
    }
}
