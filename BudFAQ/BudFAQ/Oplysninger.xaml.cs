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
    public partial class Oplysninger : Page
    {
        public Oplysninger()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Artikel.xaml", UriKind.Relative));
        }

        private void btn_Manual_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://budweg.com/external/catalog-files/023010N.pdf",
                UseShellExecute = true
            });
        }

        private void btn_Video1_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.youtube.com/watch?v=DaSXcqwuTJM&t",
                UseShellExecute = true
            });
        }

        private void btn_Video2_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.youtube.com/watch?v=aN5gmPanFTA&t",
                UseShellExecute = true
            });
        }

        private void btn_Video3_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.youtube.com/watch?v=wO3JkuslgAQ",
                UseShellExecute = true
            });
        }
    }
}
