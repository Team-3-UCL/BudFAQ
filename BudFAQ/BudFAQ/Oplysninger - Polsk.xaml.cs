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

namespace BudFAQ
{
    /// <summary>
    /// Interaction logic for Oplysninger.xaml
    /// </summary>
    public partial class OplysningerPolsk : Page
    {
        public OplysningerPolsk(List<ArticleVM> articles, List<VideoVM> videos)
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
            ArtikelPolsk artikelPolsk = new();
            artikelPolsk.ArtikelName.Content = chosenArticle;
            
            foreach(ArticleVM articleVM in Articles)
            {
                if(articleVM.Name == chosenArticle)
                {
                    artikelPolsk.Content.Text = articleVM.Text;
                    break;
                }
            }
            this.NavigationService.Navigate(artikelPolsk);
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
