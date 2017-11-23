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

namespace WpfHTML
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbTeken.Items.Add("aanhalingsteken");
            cmbTeken.Items.Add("&");
            cmbTeken.Items.Add("<");
            cmbTeken.Items.Add(">");
            cmbTeken.Items.Add("spatie");
            cmbTeken.Items.Add("À");
            cmbTeken.Items.Add("Á");
            cmbTeken.Items.Add("Â");
            cmbTeken.Items.Add("Ã");
            cmbTeken.Items.Add("Ä");
            cmbTeken.Items.Add("Å");
            cmbTeken.Items.Add("Æ");
            cmbTeken.Items.Add("Ç");
            cmbTeken.Items.Add("È");
            cmbTeken.Items.Add("É");
            cmbTeken.Items.Add("Ê");
            cmbTeken.Items.Add("Ë");
            cmbTeken.Items.Add("Ì");
            cmbTeken.Items.Add("Í");
            cmbTeken.Items.Add("Î");
            cmbTeken.Items.Add("Ï");
            cmbTeken.Items.Add("Ð");
            cmbTeken.Items.Add("Ñ");
            cmbTeken.Items.Add("Ò");
            cmbTeken.Items.Add("Ó");
            cmbTeken.Items.Add("Ô");
            cmbTeken.Items.Add("Õ");
            cmbTeken.Items.Add("Ö");
            cmbTeken.Items.Add("×");
            cmbTeken.Items.Add("Ø");
            cmbTeken.Items.Add("Ù");
            cmbTeken.Items.Add("Ú");
            cmbTeken.Items.Add("Û");
            cmbTeken.Items.Add("Ü");
            cmbTeken.Items.Add("Ý");
            cmbTeken.Items.Add("Þ");
            cmbTeken.Items.Add("ß");
            cmbTeken.Items.Add("à");
            cmbTeken.Items.Add("á");
            cmbTeken.Items.Add("â");
            cmbTeken.Items.Add("ã");
            cmbTeken.Items.Add("ä");
            cmbTeken.Items.Add("å");
            cmbTeken.Items.Add("æ");
            cmbTeken.Items.Add("ç");
            cmbTeken.Items.Add("è");
            cmbTeken.Items.Add("é");
            cmbTeken.Items.Add("ê");
            cmbTeken.Items.Add("ë");
            cmbTeken.Items.Add("ì");
            cmbTeken.Items.Add("í");
            cmbTeken.Items.Add("î");
            cmbTeken.Items.Add("ï");
            cmbTeken.Items.Add("ð");
            cmbTeken.Items.Add("ñ");
            cmbTeken.Items.Add("ò");
            cmbTeken.Items.Add("ó");
            cmbTeken.Items.Add("ô");
            cmbTeken.Items.Add("õ");
            cmbTeken.Items.Add("ö");
            cmbTeken.Items.Add("÷");
            cmbTeken.Items.Add("ø");
            cmbTeken.Items.Add("ù");
            cmbTeken.Items.Add("ú");
            cmbTeken.Items.Add("û");
            cmbTeken.Items.Add("ü");
            cmbTeken.Items.Add("ý");
            cmbTeken.Items.Add("þ");
            cmbTeken.Items.Add("ÿ");
            cmbTeken.Items.Add("Œ");
            cmbTeken.Items.Add("œ");
            cmbTeken.Items.Add("Š");
            cmbTeken.Items.Add("š");
            cmbTeken.Items.Add("Ÿ");
            cmbTeken.Items.Add("ƒ");
            cmbTeken.Items.Add("ˆ");
            cmbTeken.Items.Add("˜");
        }

private void cmbTeken_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    string teken = cmbTeken.SelectedValue.ToString();
    switch (teken) 
    {
                case "aanhalingsteken": lblHTML.Content = "&quot;"; break;
                case "&": lblHTML.Content = "&amp;"; break;
                case "<": lblHTML.Content = "&lt;"; break;
                case ">": lblHTML.Content = "&gt;"; break;
                case "spatie": lblHTML.Content = "&nbsp;"; break;
                case "À": lblHTML.Content = "&Agrave;"; break;
                case "Á": lblHTML.Content = "&Aacute;"; break;
                case "Â": lblHTML.Content = "&Acirc;"; break;
                case "Ã": lblHTML.Content = "&Atilde;"; break;
                case "Ä": lblHTML.Content = "&Auml;"; break;
                case "Å": lblHTML.Content = "&Aring;"; break;
                case "Æ": lblHTML.Content = "&AElig;"; break;
                case "Ç": lblHTML.Content = "&Ccedil;"; break;
                case "È": lblHTML.Content = "&Egrave;"; break;
                case "É": lblHTML.Content = "&Eacute;"; break;
                case "Ê": lblHTML.Content = "&Ecirc;"; break;
                case "Ë": lblHTML.Content = "&Euml;"; break;
                case "Ì": lblHTML.Content = "&Igrave;"; break;
                case "Í": lblHTML.Content = "&Iacute;"; break;
                case "Î": lblHTML.Content = "&Icirc;"; break;
                case "Ï": lblHTML.Content = "&Iuml;"; break;
                case "Ð": lblHTML.Content = "&ETH;"; break;
                case "Ñ": lblHTML.Content = "&Ntilde;"; break;
                case "Ò": lblHTML.Content = "&Ograve;"; break;
                case "Ó": lblHTML.Content = "&Oacute;"; break;
                case "Ô": lblHTML.Content = "&Ocirc;"; break;
                case "Õ": lblHTML.Content = "&Otilde;"; break;
                case "Ö": lblHTML.Content = "&Ouml;"; break;
                case "×": lblHTML.Content = "&times;"; break;
                case "Ø": lblHTML.Content = "&Oslash;"; break;
                case "Ù": lblHTML.Content = "&Ugrave;"; break;
                case "Ú": lblHTML.Content = "&Uacute;"; break;
                case "Û": lblHTML.Content = "&Ucirc;"; break;
                case "Ü": lblHTML.Content = "&Uuml;"; break;
                case "Ý": lblHTML.Content = "&Yacute;"; break;
                case "Þ": lblHTML.Content = "&THORN;"; break;
                case "ß": lblHTML.Content = "&szlig;"; break;
                case "à": lblHTML.Content = "&agrave;"; break;
                case "á": lblHTML.Content = "&aacute;"; break;
                case "â": lblHTML.Content = "&acirc;"; break;
                case "ã": lblHTML.Content = "&atilde;"; break;
                case "ä": lblHTML.Content = "&auml;"; break;
                case "å": lblHTML.Content = "&aring;"; break;
                case "æ": lblHTML.Content = "&aelig;"; break;
                case "ç": lblHTML.Content = "&ccedil;"; break;
                case "è": lblHTML.Content = "&egrave;"; break;
                case "é": lblHTML.Content = "&eacute;"; break;
                case "ê": lblHTML.Content = "&ecirc;"; break;
                case "ë": lblHTML.Content = "&euml;"; break;
                case "ì": lblHTML.Content = "&igrave;"; break;
                case "í": lblHTML.Content = "&iacute;"; break;
                case "î": lblHTML.Content = "&icirc;"; break;
                case "ï": lblHTML.Content = "&iuml;"; break;
                case "ð": lblHTML.Content = "&eth;"; break;
                case "ñ": lblHTML.Content = "&ntilde;"; break;
                case "ò": lblHTML.Content = "&ograve;"; break;
                case "ó": lblHTML.Content = "&oacute;"; break;
                case "ô": lblHTML.Content = "&ocirc;"; break;
                case "õ": lblHTML.Content = "&otilde;"; break;
                case "ö": lblHTML.Content = "&ouml;"; break;
                case "÷": lblHTML.Content = "&divide;"; break;
                case "ø": lblHTML.Content = "&oslash;"; break;
                case "ù": lblHTML.Content = "&ugrave;"; break;
                case "ú": lblHTML.Content = "&uacute;"; break;
                case "û": lblHTML.Content = "&ucirc;"; break;
                case "ü": lblHTML.Content = "&uuml;"; break;
                case "ý": lblHTML.Content = "&yacute;"; break;
                case "þ": lblHTML.Content = "&thorn;"; break;
                case "ÿ": lblHTML.Content = "&yuml;"; break;
                case "Œ": lblHTML.Content = "&OElig;"; break;
                case "œ": lblHTML.Content = "&oelig;"; break;
                case "Š": lblHTML.Content = "&Scaron;"; break;
                case "š": lblHTML.Content = "&scaron;"; break;
                case "Ÿ": lblHTML.Content = "&Yuml;"; break;
                case "ƒ": lblHTML.Content = "&fnof;"; break;
                case "ˆ": lblHTML.Content = "&circ;"; break;
                case "˜": lblHTML.Content = "&tilde;"; break;
                default: lblHTML.Content = "Onbekend"; break;
    }
}
    }
}
