using Microsoft.Data.Sqlite;
using ORMLibrary;
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

namespace WPF_projekt
{
    public partial class Studenti : Window
    {

        public ObservableCollection<Student> studenti { get; set; } = new ObservableCollection<Student>();
        SqliteConnection sqliteConnection;

        public Studenti()
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
                List<Student> t = await this.sqliteConnection.Select<Student>();
                foreach (Student q in t)
                {
                    studenti.Add(q);
                }
            }
            finally
            {
                await this.sqliteConnection.CloseAsync();
            }
        }

        public void smazatStudenta(object sender, RoutedEventArgs rea)
        {         
            Student sp = (sender as Button).DataContext as Student;
            try
            {
                sqliteConnection.Open();
                sqliteConnection.Delete(sp);
            }
            finally
            {
                sqliteConnection.Close();
            }

            studenti.Remove(sp);
        }

        public void editStudent(object sender, RoutedEventArgs rea)
        {
            UpravStudenta us = new UpravStudenta((sender as Button).DataContext as Student);
            us.Show();
        }
    }
}
