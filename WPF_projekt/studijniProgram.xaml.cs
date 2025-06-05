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
    public partial class studijniProgram : Window
    {

        public ObservableCollection<Studijni_program> programList { get; set; }=new ObservableCollection<Studijni_program>();
        SqliteConnection connection;

        public studijniProgram()
        {
            this.connection = new SqliteConnection("Data source=../../../../database.db");
            nacteniDat();

            DataContext = this;
            InitializeComponent();
        }
        public async Task nacteniDat()
        {
            try
            {
                await this.connection.OpenAsync();
                List<Studijni_program> t = await this.connection.Select<Studijni_program>();
                foreach (Studijni_program q in t)
                {
                    programList.Add(q);
                }
            }
            finally
            {
                await this.connection.CloseAsync();
            }
        }

        public void AddStudijniProgram(object sender, EventArgs ea)
        {
            PridejStudijniProgram ps = sender as PridejStudijniProgram;
            Studijni_program sp = ps.DataContext as Studijni_program;

            try
            {
                connection.Open();
                connection.Insert(sp);
            }
            finally
            {
                connection.Close();
            }
            programList.Add(sp);
        }
        public void pridejStudijniProgram(object sender, RoutedEventArgs rea)
        {
            PridejStudijniProgram t = new PridejStudijniProgram();
            t.programSave += AddStudijniProgram;
            t.Show();
        }

        public void smazStudijniProgram(object sender, RoutedEventArgs rea)
        {
            Studijni_program t = (sender as Button).DataContext as Studijni_program;

            try
            {
                connection.Open();
                connection.Delete(t);
            }
            finally
            {
                connection.Close();
            }
            programList.Remove(t);
        }

        public void editStudijniProgram(object sender, RoutedEventArgs rea)
        {
            EditStudijniProgram esp = new EditStudijniProgram((sender as Button).DataContext as Studijni_program);
            esp.Show();
        }
    }
}
