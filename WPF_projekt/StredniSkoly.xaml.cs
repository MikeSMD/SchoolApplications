using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Data.Sqlite;
using ORMLibrary;

namespace WPF_projekt
{
    public partial class StredniSkoly : Window
    {

        public ObservableCollection<Stredni_skola> skoly { get; set; } = new ObservableCollection<Stredni_skola>();
        private SqliteConnection dbConnection;

        public StredniSkoly()
        {
            this.dbConnection = new SqliteConnection("Data source=../../../../database.db");

            DataContext = this;
            nacteniDat();

            InitializeComponent();
        }

        public async Task nacteniDat()
        {
            try
            {
                await this.dbConnection.OpenAsync();
                List<Stredni_skola> t = await this.dbConnection.Select<Stredni_skola>();
                foreach (Stredni_skola q in t)
                {
                    skoly.Add(q);
                }
            }
            finally
            {
                await this.dbConnection.CloseAsync();
            }
        }

        public void VymazSkolu(object sender, RoutedEventArgs rea)
        {
            Stredni_skola ss = (sender as Button).DataContext as Stredni_skola;
            try
            {
                dbConnection.Open();
                dbConnection.Delete(ss);
            }
            finally
            {
                dbConnection.Close();
            }
            skoly.Remove(ss);
        }

        public void UpravitSkolu(object sender, RoutedEventArgs rea)
        {
            Stredni_skola ss = (sender as Button).DataContext as Stredni_skola;
            UpravSkolu us = new UpravSkolu(ss);
            us.Show();
        }

        public void AddSkola(object sender, EventArgs ea)
        {
            PridatSkolu ps = sender as PridatSkolu;
            Stredni_skola ss = ps.DataContext as Stredni_skola;
            try
            {
                dbConnection.Open();
                dbConnection.Insert(ss);
            }
            finally
            {
                dbConnection.Close();
            }
            skoly.Add(ss);
        }

        public void PridatSkolu(object sender, RoutedEventArgs rea)
        {
            PridatSkolu ps = new PridatSkolu();
            ps.SkolaSaved += AddSkola;
            ps.Show();
        }

        public void ZobrazProgramy(object sender, RoutedEventArgs rea)
        {
            Stredni_skola ss = (sender as Button).DataContext as Stredni_skola;
            SkolaProgram skolaProgram = new SkolaProgram(ss.id_skoly);
            skolaProgram.Show();
        }

        public void ZobrazStudijniProgramy(object sender, RoutedEventArgs rea)
        {
            studijniProgram sp = new studijniProgram();
            sp.Show();
        }
    }
}
