using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Stredni_skola : INotifyPropertyChanged
    {
        private int _id_skoly;
        public int id_skoly { get => _id_skoly; set { setValue(ref _id_skoly, value); } }

        private string _nazev;
        public string nazev { get => _nazev; set { setValue(ref _nazev, value); } }

        private string _kraj;
        public string kraj { get => _kraj; set{ setValue(ref _kraj, value); } }

        private string _mesto;
        public string mesto { get => _mesto; set { setValue(ref _mesto, value); } }

        private string _ulice;
        public string ulice { get => _ulice; set { setValue(ref _ulice, value); } }

        private string _psc;
        public string psc { get => _psc; set { setValue(ref _psc, value); } }

        private string _typ;
        public string typ { get => _typ; set { setValue(ref _typ, value); } }

        private string _email;
        public string email { get => _email; set { setValue(ref _email, value); } }

        private void setValue<T>(ref T prop, T value, [CallerMemberName] string name = null)
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
