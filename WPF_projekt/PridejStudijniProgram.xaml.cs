using Microsoft.Data.Sqlite;
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
    /// Interakční logika pro PridejStudijniProgram.xaml
    /// </summary>
    public partial class PridejStudijniProgram : Window
    {
        public Studijni_program studijni_Program { get; set; } = new Studijni_program();
        public event EventHandler programSave;
        public PridejStudijniProgram()
        {
            this.DataContext = studijni_Program;
            InitializeComponent();
        }

        public void Ulozit(object sender, RoutedEventArgs rea)
        {
            programSave?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
