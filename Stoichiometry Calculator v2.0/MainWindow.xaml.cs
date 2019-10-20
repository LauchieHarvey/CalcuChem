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

namespace Stoichiometry_Calculator_v2._0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new HomePage();
        }

        private void MenuItem_Home_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomePage();
        }
        private void MenuItem_Calculator_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new CalculatorPage();
        }
        private void MenuItem_About_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new AboutPage();
        }
        private void MenuItem_ComingSoon_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new ComingSoonPage();
        }
        private void MenuItem_Exit_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }
}
