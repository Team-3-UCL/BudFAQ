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

        SqlConnection sqlCon = new SqlConnection("Server = 10.56.8.36; Database=P1DB03; User Id = P1-03; Password=OPENDB_03;");

        SqlCommand cmd;
        SqlDataReader dr;


        public Forside()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Oplysninger.xaml", UriKind.Relative));


        }

        public void lb_Search(object sender, RoutedEventArgs r)
        {

           

            



        }
    }
}
