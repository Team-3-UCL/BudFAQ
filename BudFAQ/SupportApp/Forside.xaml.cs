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

namespace SupportApp
{
    /// <summary>
    /// Interaction logic for Forside.xaml
    /// </summary>
    public partial class Forside : Page
    {
        public Forside()
        {
            InitializeComponent();
        }

        private void btnArticles_Click(object sender, RoutedEventArgs e)
        {
            ArticleManager articleManager = new();
            this.NavigationService.Navigate(articleManager); 
        }
    }
}
