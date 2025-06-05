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
    /// <summary>
    /// Interakční logika pro SkolaProgram.xaml
    /// </summary>
    public partial class SkolaProgram : Window
    {
        public ObservableCollection<Skola_program> skolaProgramList { get; set; }=new ObservableCollection<Skola_program>();
        private SqliteConnection connection;
        private readonly int id_skola;

        public SkolaProgram(int id_skola)
        {
            this.id_skola = id_skola;
            this.connection = new SqliteConnection("Data source=../../../../database.db");
            DataContext = this;

            InitializeComponent();
            nacteniDat();
        }


        public async Task nacteniDat()
        {
            try
            {
                await this.connection.OpenAsync();
                List<Skola_program> t = await this.connection.Select<Skola_program>("id_skoly", this.id_skola);
                foreach (Skola_program q in t)
                {
                    skolaProgramList.Add(q);
                }
            }
            finally
            {
                await this.connection.CloseAsync();
            }
        }

        public void AddProgramKeSkole(object sender, EventArgs rea)
        {
            Skola_program sp = (sender as PridatProgramKeSkole).DataContext as Skola_program;
            sp.id_skoly = id_skola;

            try
            {
                connection.Open();
                connection.Insert(sp);
            }
            finally
            {
                connection.Close();
            }

            this.skolaProgramList.Add(sp);
        }

        public void pridatProgramKeSkole(object sender, RoutedEventArgs rea)
        {
            PridatProgramKeSkole ppks = new PridatProgramKeSkole();
            ppks.saveProgram += AddProgramKeSkole;
            ppks.Show();
        }

        public void smazatProgramUSkoly(object sender, RoutedEventArgs rea)
        {
            Skola_program sp = (sender as Button).DataContext as Skola_program;

            try
            {
                connection.Open();
                connection.Delete(sp);
            }
            finally
            {
                connection.Close();
            }
            skolaProgramList.Remove(sp);
        }
    }
}
