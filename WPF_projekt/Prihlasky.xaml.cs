using Microsoft.Data.Sqlite;
using ORMLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
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
    /// Interakční logika pro Prihlasky.xaml
    /// </summary>
    public partial class Prihlasky : Window
    {
        public ObservableCollection<Prihlaska> prihlasky { get; set; } = new ObservableCollection<Prihlaska>();
        private SqliteConnection sqliteConnection;

        public Prihlasky()
        {
            sqliteConnection = new SqliteConnection("Data source=../../../../database.db");

            nacteniDat();

            DataContext = this;

            InitializeComponent();
        }

        public async Task nacteniDat()
        {
            try
            {
                await this.sqliteConnection.OpenAsync();
                List<Prihlaska> t = await this.sqliteConnection.Select<Prihlaska>();
                foreach (Prihlaska q in t)
                {
                    prihlasky.Add(q);
                }
            }
            finally
            {
                await this.sqliteConnection.CloseAsync();
            }
        }

        public void openStudenti(object sender, RoutedEventArgs rea)
        {
            Studenti t = new Studenti();
            t.Show();
        }
        public void smazatPrihlasku(object sender, RoutedEventArgs rea)
        {
            
            Prihlaska sp = (sender as Button).DataContext as Prihlaska;

            try
            {
                sqliteConnection.Open();
                sqliteConnection.Delete(sp);
            }finally {
                sqliteConnection.Close();
            }

            prihlasky.Remove(sp);
        }
    }
}
