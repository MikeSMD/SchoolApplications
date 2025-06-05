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
    /// Interakční logika pro UpravStudenta.xaml
    /// </summary>
    public partial class UpravStudenta : Window
    {
        private Student _student;
        public Student student { get; set; }
        public UpravStudenta(Student student)
        {
            this._student = student;
            this.student = new Student { id_studenta=student.id_studenta, jmeno=student.jmeno, prijmeni=student.prijmeni, mesto=student.mesto, ulice=student.ulice, psc=student.psc, email=student.email, datum_narozeni=student.datum_narozeni, misto_narozeni=student.misto_narozeni, rodne_cislo=student.rodne_cislo, stat=student.stat, statni_obcanstvi=student.statni_obcanstvi, telefon=student.telefon };

            DataContext = this.student;
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            this._student.jmeno=student.jmeno;
            this._student.prijmeni=student.prijmeni;
            this._student.email=student.email;
            this._student.mesto=student.mesto;
            this._student.ulice=student.ulice;
            this._student.psc=student.psc;
            this._student.datum_narozeni = student.datum_narozeni;
            this._student.misto_narozeni = student.misto_narozeni;
            this._student.rodne_cislo = student.rodne_cislo;
            this._student.stat = student.stat;
            this._student.statni_obcanstvi = student.statni_obcanstvi;
            this._student.telefon = student.telefon;

            using SqliteConnection sqliteConnection = new SqliteConnection("Data source=../../../../database.db");
            sqliteConnection.Open();
            sqliteConnection.Update(_student);
            sqliteConnection.Close();

            this.Close();
            
        }
    }
}
