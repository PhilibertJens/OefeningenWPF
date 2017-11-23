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

namespace Sliders.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        string VergelijkGetallen(int getal1, int getal2)
        {
            string feedback = "";
            if (getal1 == getal2) feedback = getal1 + " (slider1) is gelijk aan " + getal2 + " (slider2)";
            else if (getal1 > getal2) feedback = getal1 + " (slider1) is groter dan " + getal2 + " (slider2)";
            else feedback = getal2 + " (slider2) is groter dan " + getal1 + " (slider1)";
            return feedback;
        }

        private void sldGetal1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int getal1 = (int)sldGetal1.Value;
            int getal2 = (int)sldGetal2.Value;
            lblBoodschap.Content = VergelijkGetallen(getal1, getal2);
            if (getal1 < getal2) sldGetal2.Value = sldGetal1.Value;
        }


        private void btnTestSliders_Click(object sender, RoutedEventArgs e)
        {
            //int getal1 = (int)sldGetal1.Value;
            //int getal2 = (int)sldGetal2.Value;
            //lblBoodschap.Content = VergelijkGetallen(getal1, getal2);
        }

        private void sldGetal2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int getal1 = (int)sldGetal1.Value;
            int getal2 = (int)sldGetal2.Value;
            lblBoodschap.Content = VergelijkGetallen(getal1, getal2);
            if (getal2 > getal1) sldGetal1.Value = sldGetal2.Value;
        }
    }
}
