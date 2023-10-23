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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oefening15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int snelsteTijd = 0;
        private string snelsteAthleet;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(TxtSeconden.Text, out int tijd))
            {
                if(snelsteTijd == 0 || tijd < snelsteTijd)
                {
                    snelsteTijd = tijd;
                    snelsteAthleet = TxtNaam.Text;
                }

                TxtNaam.Clear();
                TxtSeconden.Clear();
                TxtNaam.Focus();
            }
        }

        private void BtnSnelste_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"De snelste athleet is {snelsteAthleet}");
            sb.AppendLine($"Totaal aantal seconden: {snelsteTijd}");
            sb.AppendLine();

            TimeSpan interval = new TimeSpan(0, 0, snelsteTijd);

            sb.AppendLine($"Totaal aantal uren: {interval.Hours:N0}");
            sb.AppendLine($"Totaal aantal minuten: {interval.Minutes:N0}");
            sb.AppendLine($"Totaal aantal seconden: {interval.Seconds:N0}");

            TxtResultaat.Text = sb.ToString();
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            TxtNaam.Clear();
            TxtSeconden.Clear();
            TxtResultaat.Clear();

            snelsteTijd = 0;
            snelsteAthleet = string.Empty;
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
