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

namespace WpfSelectie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime momenteel;
        public MainWindow()
        {
            InitializeComponent();
            momenteel = DateTime.Now;
            lblTijd.Content = Weekdag() + " " + momenteel.ToString("d MMMM yyyy hh:mm");
            VulCombo();
            cmbLeeftijd.SelectedIndex = 0;
        }

        void VulCombo()
        {
            for (int i = 0; i <= 100; i++)
            {
                cmbLeeftijd.Items.Add(i);
            }
            //Vul cmbLeeftijd met de getallen van 0 tot en met 100
        }

        bool isAvond(int uur)
        {
            //Als avond nemen we de uren van 18 t.e.m. 23 uur
            bool avond = false;
            if (18 <= uur && uur < 23) return true;
            //Tik hier je code
            return avond;
        }

        void isNacht(int uur)
        {
            bool nacht = false;
            //Als nacht nemen we de uren van 23 uur tot 6 uur 's morgens
            MessageBox.Show("Om " + uur + " uur: " + nacht.ToString(), "Is het nacht?");
        }

        string Weekdag()
        {
            string dagNaam;
            DateTime momenteel = DateTime.Now;
            DayOfWeek dag = momenteel.DayOfWeek;
            switch (dag)
            {
                case DayOfWeek.Sunday:
                    dagNaam = "zondag";
                    break;
                case DayOfWeek.Monday:
                    dagNaam = "maandag";
                    break;
                case DayOfWeek.Tuesday:
                    dagNaam = "dinsdag";
                    break;
                case DayOfWeek.Wednesday:
                    dagNaam = "woensdag";
                    break;
                case DayOfWeek.Thursday:
                    dagNaam = "donderdag";
                    break;
                case DayOfWeek.Friday:
                    dagNaam = "vrijdag";
                    break;
                default:
                    dagNaam = "zaterdag";
                    break;
            }
            return dagNaam;
        }

        private void btnWeekDag_Click(object sender, RoutedEventArgs e)
        {
            string dagNaam;
            DateTime momenteel = DateTime.Now;
            DayOfWeek dag = momenteel.DayOfWeek;
            if (dag == DayOfWeek.Sunday)
                dagNaam = "zondag";
            else if (dag == DayOfWeek.Monday)
                dagNaam = "maandag";
            else if (dag == DayOfWeek.Tuesday)
                dagNaam = "dinsdag";
            else if (dag == DayOfWeek.Wednesday)
                dagNaam = "woensdag";
            else if (dag == DayOfWeek.Thursday)
                dagNaam = "donderdag";
            else if (dag == DayOfWeek.Friday)
                dagNaam = "vrijdag";
            else dagNaam = "zaterdag";
            MessageBox.Show("Vandaag is het " + dagNaam, "Dag van de week");
        }

        private void btnLeeftijd_Click(object sender, RoutedEventArgs e)
        {
            string feedback = "";
            bool checkLeeftijd = int.TryParse(cmbLeeftijd.SelectedValue.ToString(), out int leeftijd);
            if (leeftijd > 17) feedback = $"Op de leeftijd van {leeftijd} jaar ben je meerderjarig";
            else feedback = $"Op de leeftijd van {leeftijd} jaar ben je nog niet meerderjarig";
            MessageBox.Show(feedback);
            //Lees de waarde uit in cmbLeeftijd
            //Is die waarde groter dan 17, toon de de tekst "Op de leeftijd van x jaar ben je meerderjarig"
            //Is de waarde kleiner dan 18, toon de de tekst "Op de leeftijd van x jaar ben je nog niet meerderjarig"
        }

        private void btnAvondcheck_Click(object sender, RoutedEventArgs e)
        {
            int uur = momenteel.Hour;
            int minuten = momenteel.Minute;
            bool isHetAvond = isAvond(uur);
            string feedback;
            if (isHetAvond) feedback = $"Om {uur} uur is het avond";
            //if (isHetAvond) feedback =  "Om " + uur + " uur is het avond"; --> Dit is de andere manier voor string concatenatie.
            else if (uur < 18) feedback = $"Om {uur} is het nog geen avond";
            else feedback = $"Om {uur} is het al nacht";
            MessageBox.Show(feedback);

            //Als het avond is, toon dan een boodschap: "Om x is het avond"
            //Is het voor 18 uur, toon dan een boodschap: "Om x is het nog geen avond"
            //Is het 23 uur of later (maar voor middernacht), toon dan een boodschap: "Om x is het al nacht"


        }
    }
}
