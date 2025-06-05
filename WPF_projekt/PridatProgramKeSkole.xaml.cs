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
    /// Interakční logika pro PridatProgramKeSkole.xaml
    /// </summary>
    public partial class PridatProgramKeSkole : Window
    {
        public Skola_program sp { get; set; } = new Skola_program();

        public EventHandler saveProgram;
        public PridatProgramKeSkole()
        {
            DataContext = sp;
            InitializeComponent();
        }

        public void Ulozit(object sender, RoutedEventArgs rea)
        {
            saveProgram?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
