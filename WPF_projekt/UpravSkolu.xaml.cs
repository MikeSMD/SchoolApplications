using Microsoft.Data.Sqlite;
using ORMLibrary;
using System;
using System.CodeDom;
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
    /// Interakční logika pro UpravSkolu.xaml
    /// </summary>
    public partial class UpravSkolu : Window
    {

        private Stredni_skola _stredni_skola;
        public Stredni_skola stredni_skola { get; set; }

        public UpravSkolu(Stredni_skola stredni_skola)
        {
            this._stredni_skola = stredni_skola;
            this.stredni_skola = new Stredni_skola { id_skoly = _stredni_skola.id_skoly, email = _stredni_skola.email, mesto = _stredni_skola.mesto, ulice = _stredni_skola.ulice, psc = _stredni_skola.psc, kraj = _stredni_skola.kraj, nazev = _stredni_skola.nazev, typ = _stredni_skola.typ };
            DataContext = this.stredni_skola;
            InitializeComponent();
        }

        public void Ulozit(object sender, RoutedEventArgs rea)
        {
            _stredni_skola.email = stredni_skola.email;
            _stredni_skola.psc = stredni_skola.psc;
            _stredni_skola.mesto = stredni_skola.mesto;
            _stredni_skola.ulice = stredni_skola.ulice;
            _stredni_skola.kraj = stredni_skola.kraj;
            _stredni_skola.nazev = stredni_skola.nazev;
            _stredni_skola.typ = stredni_skola.typ;
            
            using SqliteConnection connection = new SqliteConnection("Data source=../../../../database.db");

            connection.Open();
            connection.Update(this._stredni_skola);
            connection.Close();

            this.Close();
        }
    }
}
