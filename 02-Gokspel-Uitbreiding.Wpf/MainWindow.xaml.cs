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

namespace _02_Gokspel_Uitbreiding.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int teGokkenGetal, gegoktGetal, aantalPogingen;
        int getalMax;
        bool[] gegokteGetallen;
        bool gewonnen;

        public MainWindow()
        {
            InitializeComponent();
            getalMax = 10;
            Initialiseer();
        }

        void Initialiseer()
        {
            Random rnd = new Random();
            teGokkenGetal = rnd.Next(1, getalMax + 1);
            gegokteGetallen = new bool[getalMax + 1];
            Console.WriteLine("teGokkenGetal = " + teGokkenGetal);
            txtGetal.Focus();
            txtGetal.Text = "0";
            txtGetal.SelectAll();
            aantalPogingen = 0;
            lblFeedback.Content = "Pogingen";
        }

        private void txtGetal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtGetal.Text != "0")
            {
                VerwerkGok();
            }
            else
            {
                GeldigGeheelGetal(txtGetal);
            }
        }

        private void btnGok_Click(object sender, RoutedEventArgs e)
        {
            if (gewonnen)
            {
                Initialiseer();
                btnGok.Content = "Gok";
                gewonnen = false;
            }
            else
            {
                VerwerkGok();
            }
        }

        void VerwerkGok()
        {
            gegoktGetal = int.Parse(txtGetal.Text);
            if (!gegokteGetallen[gegoktGetal])
            {
                aantalPogingen++;
                string feedback = lblFeedback.Content.ToString();
                feedback += "\n" + gegoktGetal;
                if (gegoktGetal == teGokkenGetal)
                {
                    feedback += "\nU heeft het geraden in \n" + aantalPogingen + " pogingen.";
                    txtGetal.Text = "";
                    btnGok.Content = "Opnieuw";
                    btnGok.Focus();
                    gewonnen = true;
                }
                else
                {
                    txtGetal.SelectAll();
                    txtGetal.Focus();
                }
                lblFeedback.Content = feedback;
                gegokteGetallen[gegoktGetal] = true;
            }
            else
            {
                txtGetal.SelectAll();
                txtGetal.Focus();
            }
        }

        int GeldigGeheelGetal(TextBox input)
        {
            int geheelGetal = 0;
            bool isGeldigGetal = int.TryParse(input.Text, out geheelGetal);
            input.Text = geheelGetal.ToString();
            if (!isGeldigGetal)
            {
                input.SelectAll();
            }
            return geheelGetal;
        }
    }
}
