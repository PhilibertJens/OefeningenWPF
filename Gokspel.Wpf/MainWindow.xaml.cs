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

namespace SelectieOefeningen.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int teGokkenGetal, gegoktGetal, aantalPogingen;

        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            teGokkenGetal = rnd.Next(1, 5);
            Console.WriteLine("teGokkenGetal = " + teGokkenGetal);
            txtGetal.Focus();
        }

        private void txtGetal_TextChanged(object sender, TextChangedEventArgs e)
        {
            GeldigGeheelGetal(txtGetal);
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

        private void btnGok_Click(object sender, RoutedEventArgs e)
        {
            gegoktGetal = int.Parse(txtGetal.Text);
            aantalPogingen++;
            string feedback = lblFeedback.Content.ToString();
            feedback += "\n" + gegoktGetal;
            if (gegoktGetal == teGokkenGetal)
            {
                feedback += "\nU heeft het geraden in \n" + aantalPogingen + " pogingen.";
            }
            else
            {
                txtGetal.Focus();
                txtGetal.SelectAll();
            }
            lblFeedback.Content = feedback;
        }
    }
}
