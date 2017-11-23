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

namespace _04_HTMLGetallen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i < 6; i++)
            {
                //if (i == 3) continue; //3 wordt overgeslaan. De loop gaat verder met 4.
                //if (i == 3) break; //De loop stopt bij 3.
                lstGetallen.Items.Add(i);
            }
        }

        private void lstGetallen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string feedback;
            string getalVoluit;
            int gekozenGetal = (int)lstGetallen.SelectedValue;
            switch (gekozenGetal)
            {
                case 1:
                    getalVoluit = "een";
                    break;
                case 2:
                    getalVoluit = "twee";
                    break;
                case 3:
                    getalVoluit = "drie";
                    break;
                case 4:
                    getalVoluit = "vier";
                    break;
                default:
                    getalVoluit = "vijf";
                    break;
            }
            feedback = "Het getal " + gekozenGetal + " schrijf je zo: " + getalVoluit;
            lblGetalVoluit.Content = feedback;
        }
    }
}
