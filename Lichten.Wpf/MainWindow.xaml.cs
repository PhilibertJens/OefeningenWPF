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

namespace Lichten.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        enum Kleur { groen, oranje, rood }
        Random rnd = new Random();
        int getalLicht;

        public MainWindow()
        {
            InitializeComponent();
            getalLicht = rnd.Next(3);
            lblFeedback.Content = GeefFeedback(getalLicht);
        }

        string GeefFeedback(int getal)
        {
            string feedBack = "";
            SolidColorBrush kleur;

            feedBack = "Het licht is " + (Kleur)getal;
            if (getal == 0)
            {
                feedBack += "\nJe mag doorrijden";
                getalLicht = 1;
                kleur = new SolidColorBrush(Colors.Green);
                elLicht.Fill = kleur;
            }
            else if (getal == 1)
            {
                feedBack += "\nProbeer te stoppen";
                getalLicht = 2;
                kleur = new SolidColorBrush(Colors.Orange);
                elLicht.Fill = kleur;
            }
            else
            {
                feedBack += "\nJe moet stoppen";
                getalLicht = 0;
                kleur = new SolidColorBrush(Colors.Red);
                elLicht.Fill = kleur;
            }

            return feedBack;
        }

        private void btnLicht_Click(object sender, RoutedEventArgs e)
        {
            lblFeedback.Content = GeefFeedback(getalLicht);
        }
    }
}
