using Microsoft.Data.Sqlite;
using ORMLibrary;
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
using System.Windows.Shapes;

namespace WPF_projekt
{
    /// <summary>
    /// Interakční logika pro PridatSkolu.xaml
    /// </summary>
    public partial class PridatSkolu : Window
    {
        public Stredni_skola stredni_skola { get; set; }

        public event EventHandler SkolaSaved;

        public PridatSkolu()
        {
            this.stredni_skola = new Stredni_skola();

            DataContext = stredni_skola;
            InitializeComponent();
        }

        public void Ulozit(object sender, RoutedEventArgs rea)
        {
            SkolaSaved?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
