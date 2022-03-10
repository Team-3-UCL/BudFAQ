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
using System.Diagnostics;
using ViewModel.BudFaqVM;


namespace BudFAQ
{
    /// <summary>
    /// Interaction logic for Oplysninger.xaml
    /// </summary>
    public partial class Oplysninger : Page
    {
        public Oplysninger(List<ArticleVM> articles, List<VideoVM> videos)
        {
            InitializeComponent();
            Videos = videos;
            Articles = articles;

            this.DataContext = this;
        }

        public List<ArticleVM> Articles { get; set; }
        public List<VideoVM> Videos { get; set; }

        public void Article_RequestNavigate(object sender, RoutedEventArgs e)
        {
            string chosenArticle = ((Hyperlink)sender).Tag.ToString();
            Artikel artikel = new();
            artikel.ArtikelName.Content = chosenArticle;
            
            foreach(ArticleVM articleVM in Articles)
            {
                if(articleVM.Name == chosenArticle)
                {
                    artikel.Content.Text = articleVM.Text;
                    break;
                }
            }
            this.NavigationService.Navigate(artikel);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
            e.Handled = true;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.GoBack();
        }

    }
}
