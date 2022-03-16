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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace BudFAQ
{
    /// <summary>
    /// Interaction logic for Forside.xaml
    /// </summary>
    /// 
    

public partial class Forside : Page
    {

        SearchViewModel mvm;
        DatabaseHelper databaseHelper;


        public Forside()
        {
            InitializeComponent();
            mvm = new();
            databaseHelper = new();
            lb_SearchWords.ItemsSource = databaseHelper.getAllUsedKeywords();
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            mvm.searchquery(new string[] { tb_Search.Text });
            Oplysninger InformationPage = new Oplysninger(mvm.ArticlesFound, mvm.Videosfound);

            //InformationPage.Articles.Items.Clear();
            this.NavigationService.Navigate(InformationPage);


        }

        public void ListBox_OnPreviewMouseDown(object sender, RoutedEventArgs e)
        {
           tb_Search.Text = (string)((ListBoxItem)sender).Content;
        }

        public void lb_Search(object sender, RoutedEventArgs r)
        {
            
        }

        private void RemoveText(object sender, MouseButtonEventArgs e)
        {
   
            if (tb_Search.Text == "Indsæt keywords")
            {
                tb_Search.Clear();
            }          
        }
    }
}
