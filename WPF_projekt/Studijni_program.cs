using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projekt
{
    public class Studijni_program : INotifyPropertyChanged
    {
        private int _id_programu;
        public int id_programu { get => _id_programu; set { setValue(ref _id_programu, value); } }

        private string _nazev;
        public string nazev { get => _nazev; set { setValue(ref _nazev, value); } }

        private string _zkratka;
        public string zkratka { get => _zkratka; set { setValue(ref _zkratka, value); } }

        private string _popis;
        public string popis { get => _popis; set { setValue(ref _popis, value); } }

        public void setValue<T>(ref T prop, T value, [CallerMemberName] string name = null)
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
