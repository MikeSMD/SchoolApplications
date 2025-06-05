using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;
using ORMLibrary;

namespace WPF_projekt
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void OpenSchools(object sender, RoutedEventArgs rea)
        {
            StredniSkoly stredniSkoly = new StredniSkoly();
            stredniSkoly.Show();
            this.Close();
        }

        public void OpenPrihlasky(object sender, RoutedEventArgs rea)
        {
            Prihlasky prihlasky = new Prihlasky();
            prihlasky.Show();
            this.Close();
        }

    }
}