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
    /// Interakční logika pro EditStudijniProgram.xaml
    /// </summary>
    public partial class EditStudijniProgram : Window
    {
        private Studijni_program _studijni_program;
        public Studijni_program studijni_program { get; set; }

        private SqliteConnection connection;

        public EditStudijniProgram(Studijni_program sp)
        {
            _studijni_program = sp;
            studijni_program = new Studijni_program { id_programu = sp.id_programu, nazev = sp.nazev, popis = sp.popis, zkratka=sp.zkratka };
            DataContext = studijni_program;
            this.connection = new SqliteConnection("Data source=../../../../database.db");
            InitializeComponent();
        }

        public void Save(object sender, RoutedEventArgs rea)
        {
            _studijni_program.id_programu = studijni_program.id_programu;
            _studijni_program.nazev = studijni_program.nazev;
            _studijni_program.zkratka = studijni_program.zkratka;
            _studijni_program.popis = studijni_program.popis;

            try
            {
                this.connection.Open();
                this.connection.Update(_studijni_program);
            }
            finally
            {
                this.connection.Close();
            }

            this.Close();
        }
    }
}
