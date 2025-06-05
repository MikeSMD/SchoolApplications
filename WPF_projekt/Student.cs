using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Student : INotifyPropertyChanged
    {
        private int _id_studenta;
        public int id_studenta { get => _id_studenta; set { setValue(ref _id_studenta, value); } }

        private string _jmeno;
        public string jmeno { get => _jmeno; set { setValue(ref _jmeno, value); } }

        private string _prijmeni;
        public string prijmeni { get => _prijmeni; set { setValue(ref _prijmeni, value); } }

        private string _mesto;
        public string mesto { get => _mesto; set { setValue(ref _mesto, value); } }

        private string _ulice;
        public string ulice { get => _ulice; set { setValue(ref _ulice, value); } }

        private string _psc;
        public string psc { get => _psc; set { setValue(ref _psc, value); } }

        private string _email;
        public string email { get => _email; set { setValue(ref _email, value); } }

        private string _misto_narozeni;
        public string misto_narozeni { get => _misto_narozeni; set { setValue(ref _misto_narozeni, value); } }

        private string _datum_narozeni;
        public string datum_narozeni { get => _datum_narozeni; set { setValue(ref _datum_narozeni, value); } }

        private string _statni_obcanstvi;
        public string statni_obcanstvi { get => _statni_obcanstvi; set { setValue(ref _statni_obcanstvi, value); } }

        private string _rodne_cislo;
        public string rodne_cislo { get => _rodne_cislo; set { setValue(ref _rodne_cislo, value); } }

        private string _stat;
        public string stat { get => _stat; set { setValue(ref _stat, value); } }

        private string _telefon = "";
        public string telefon { get => _telefon; set { setValue(ref _telefon, value); } }

        public void setValue<T>(ref T prop, T value, [CallerMemberName] string t = null)
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(t));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
