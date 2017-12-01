using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PersonenZoeker.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string bestandsNaam;
        List<string[]> personen;

        public MainWindow()
        {
            InitializeComponent();
            ComboFill();
            haalRootBestandOp();
        }

        void ComboFill()
        {
            cmbLand.Items.Add("België");
            cmbLand.Items.Add("Nederland");

            cmbGeslacht.Items.Add("M");
            cmbGeslacht.Items.Add("V");
        }

        void haalRootBestandOp()
        {
            bestandsNaam = GetRootPath() + "personen.txt";
            personen = ZetBestandOm(bestandsNaam, '|');
            ToonAlleInfo();
        }

        #region Werken met tekstbestanden

        //Geeft de map waarin de uitgevoerde exe zich bevindt.
        string GetRootPath()
        {
            string rootPad = AppDomain.CurrentDomain.BaseDirectory;
            return rootPad;
        }

        List<string[]> ZetBestandOm(string bestandsPad, char scheidingsteken)
        {
            List<string> omzettingLijnen = new List<string>();
            List<string[]> omgezet = new List<string[]>();
            //Elke lijn uit het bestand wordt omgezet naar een item in de list
            omzettingLijnen = LeesBestand(bestandsPad);
            //elk item in de omzettingLijnen wordt 
            omgezet = CharSeperatedListNaarArrayList(omzettingLijnen, scheidingsteken);
            return omgezet;
        }

        /// <summary>
        /// Zet een tekstbetand om naar en list van strings, waarbij elke regel uit het bestand een element van de list wordt
        /// In de parameter bestandsPad wordt het volledige pad van het tekstbestand meegegeven
        /// </summary>
        /// <param name="bestandsPad">Plaats en naam het het bestand</param>
        /// <param name="scheidingsteken">scheidingsteken dat de verschillende gegevens onderscheidt</param>
        /// <returns></returns>
        List<string> LeesBestand(string bestandsPad)
        {
            List<string> ingelezenRijen = new List<string>();
            //Via de StreamReader overlopen we het tekstbestand lijn voor lijn
            StreamReader reader = new StreamReader(bestandsPad, System.Text.Encoding.Default,true);
            //de eerste lijn wordt ingelezen en in de variabele huidigeLijn opgeslagen
            string huidigeLijn = reader.ReadLine();
            //zolang er minimum één karakter zit in huidigeLijn blijven we doorgaan
            while (huidigeLijn != null)
            {
                //De ingelezen lijn wordt toegevoegd aan List<string> ingelezenRijen
                ingelezenRijen.Add(huidigeLijn);
                //De volgende lijn uit het tekstbestand wordt ingelezen en in de variabele huidigeLijn opgeslagen
                huidigeLijn = reader.ReadLine();
            }
            return ingelezenRijen;
        }

        /// <summary>
        /// Een list met strings waarin de gegevens  wordt omgezet naar een list van string-arrays
        /// </summary>
        /// <param name="charSeperatedString">List met strings waarin de gegevens telkens door een scheidingsteken onderscheiden worden</param>
        /// <param name="scheidingsteken">Het scheidingsteken dat de gegevens in elke string onderscheidt</param>
        /// <returns></returns>
        List<string[]> CharSeperatedListNaarArrayList(List<string> charSeperatedString, char scheidingsteken)
        {
            //Declaratie van een array van strings. 
            //De elementen uit charSeperatedString zullen telkens omgezet worden naar een array van strings
            string[] arrayRecord;
            //Er wordt een instance aangemaakt van een List<string[]>. Hierin komen de arrayRecords in terecht
            List<string[]> omgezet = new List<string[]>();
            //csvStrings wordt overlopen van het 0de tot en met het laatste element
            foreach (string record in charSeperatedString)
            {
                //Elke csv-string wordt omgezet naar een array.
                //De elementen worden van elkaar gescheiden door een ;
                arrayRecord = record.Split(scheidingsteken);
                //Het aldus omgezette element wordt toegevoegd aan de list
                omgezet.Add(arrayRecord);
            }
            return omgezet;
        }

        /// <summary>
        /// Een list met string-arrays wordt omgezet naar een list van character seperated strings
        /// </summary>
        /// <param name="stringArrays"></param>
        /// <returns>list van csv-strings</returns>
        List<string> ArrayListNaarCharacterSeparatedList(List<string[]> stringArrays, string scheidingsteken)
        {
            string characterSeperatedString;
            //Er wordt een instance aangemaakt van een List<string> waarin de omgezet arrays opgeslagen worden
            List<string> omgezet = new List<string>();
            //Alle arrays in de list worden één voor één overlopen
            foreach (string[] record in stringArrays)
            {
                //Elke array wordt omgezet naar een  csv-string.
                //Tussen elk element wordt een ; geplaatst
                characterSeperatedString = String.Join(scheidingsteken, record);
                //De aldus bekomen string wordt toegevoegd aan de list
                omgezet.Add(characterSeperatedString);
            }
            return omgezet;
        }

        /// <summary>
        /// Opent een dialoogvenster om een bestand te selecteren. Standaard: tekstbestanden
        /// </summary>
        /// <returns>string met volledige pad van het gekozen bestand</returns>
        /// vb. filter: "Text documents (.txt)|*.txt|Comma seperated values (.csv)|*.csv"
        string KiesBestand(string filter)
        {
            string gekozenBestandsPad = "";
            OpenFileDialog kiesBestand = new OpenFileDialog();
            //Enkel de bestanden met de doorgegeven extensie(s) worden getoond
            kiesBestand.Filter = filter;

            // Toon het dialoogvenster
            Nullable<bool> result = kiesBestand.ShowDialog();
            gekozenBestandsPad = kiesBestand.FileName;
            return gekozenBestandsPad;
        }

        /// <summary>
        /// Schrijft een tekstbestand weg op basis van een list van strings
        /// Elk element van de list wordt een lijn in het tekstbestand
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bestandsPad"></param>
        /// <returns>boolean die aanduidt of het gelukt is om het bestand op te slaan</returns>
        bool SchrijfBestand(List<string> data, string bestandsPad)
        {
            //in de bool gelukt zal opgeslagen of het opslaan geslaagd is
            bool gelukt = false;
            //Via een instance van een Streamwriter wordt een bestand aangemaakt met een opgegeven pad
            using (StreamWriter sw = new StreamWriter(
                new FileStream(bestandsPad, FileMode.Create, FileAccess.ReadWrite), System.Text.Encoding.UTF8))
            {
                //Elke element van de List<string> data wordt overlopen
                foreach (string tekstLijn in data)
                {
                    //Het ingelezen element wordt toegevoegd aan het tekstbestand op een nieuwe lijn.
                    sw.WriteLine(tekstLijn);
                }
                sw.Close();
                gelukt = true;
            }
            return gelukt;
        }

        #endregion

        private void btnOpenBestand_Click(object sender, RoutedEventArgs e)
        {
            bestandsNaam = KiesBestand("Text documents (.txt)|*.txt");
            if (bestandsNaam == "")
            {
                MessageBox.Show("Kies a.u.b. een bestand","Operatie mislukt");
            }
            else
            {
                personen = ZetBestandOm(bestandsNaam, '|');
            }            
        }

        private void btnToonAlles_Click(object sender, RoutedEventArgs e)
        {
            ToonAlleInfo();
        }

        void ToonAlleInfo()
        {
            //Drie manieren om de info binnen de foreach te tonen: Join, persoon[0] of foreach.
            lstResultaat.Items.Clear();
            foreach (string[] persoon in personen)
            {
                string infoOverpersoon = "";
                //infoOverpersoon = persoon[0] + " - " + persoon[1] + " - " + persoon[2] + " - " + persoon[3] + " - " + persoon[4] + " - " + persoon[5];
                infoOverpersoon = String.Join(" - ",persoon); //Beter dan foreach. Hier komt er ook geen streepje na het laatste element.
                                
                //foreach (string informatie in persoon)
                //{
                //    infoOverpersoon += informatie + " - ";
                    
                //}
                lstResultaat.Items.Add(infoOverpersoon);
            }
        }

        private void cmbLand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstResultaat.Items.Clear();
            string land = cmbLand.SelectedValue.ToString();

            string infoOverPersoon = "";
            string landPersoon = "";
            foreach (string[] persoon in personen)
            {
                landPersoon = persoon[3];
                if (land == landPersoon)
                {
                    infoOverPersoon = $"{persoon[0]} {persoon[1]} uit {persoon[3]}";
                    lstResultaat.Items.Add(infoOverPersoon);
                }
            }
        }

        private void cmbGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lstResultaat.Items.Clear();
            //string land = cmbLand.SelectedValue.ToString();
            //string geslacht = cmbGeslacht.SelectedValue.ToString();


            //foreach (string[] persoon in personen)
            //{
            //    string infoOverPersoon = "";
            //    string landPersoon = "";
            //    string geslachtPersoon = "";
            //    landPersoon = persoon[3];
            //    if (land == landPersoon && geslacht == geslachtPersoon)
            //    {
            //        infoOverPersoon = $"{persoon[1]} {persoon[0]} uit {persoon[3]}";
            //        lstResultaat.Items.Add(infoOverPersoon);
            //    }
            //}


            lstResultaat.Items.Clear();
            string geslacht = cmbGeslacht.SelectedValue.ToString();
            string infoOverPersoon = "";
            string landPersoon = "";
            string geslachtPersoon = "";
            if (cmbLand.SelectedIndex > -1)
            {
                string land = cmbLand.SelectedValue.ToString();
                foreach (string[] persoon in personen)
                {
                    landPersoon = persoon[3];
                    geslachtPersoon = persoon[4];
                    if (land == landPersoon && geslacht == geslachtPersoon)
                    {
                        infoOverPersoon = String.Join(" - ", persoon);
                        lstResultaat.Items.Add(infoOverPersoon);
                    }
                }
            }
            else
            {
                foreach (string[] persoon in personen)
                {
                    geslachtPersoon = persoon[4];
                    if (geslacht == geslachtPersoon)
                    {
                        infoOverPersoon = String.Join(" - ", persoon);
                        lstResultaat.Items.Add(infoOverPersoon);
                    }
                }
            }
        }

        string ToonDecennium(string leeftijd)
        {
            string decennium = "";
            switch (leeftijd)
            {
                case "1":
                    decennium = "tiener";
                    break;
                case "2":
                    decennium = "twintiger";
                    break;
                case "3":
                    decennium = "dertiger";
                    break;
                case "4":
                    decennium = "veertiger";
                    break;
                default:
                    decennium = "50 +";
                    break;
            }
            return decennium;
        }

        private void btnDecennium_Click(object sender, RoutedEventArgs e)
        {
            lstResultaat.Items.Clear();
            foreach (string[] persoon in personen)
            {
                string infoOverPersoon = "";
                string decennium, leeftijd;
                leeftijd = persoon[5];
                char eersteLetterLeeftijd = leeftijd[0]; //eerste char uit de leeftijd
                string eersteLetterVanDeLeeftijd = eersteLetterLeeftijd.ToString();
                decennium = ToonDecennium(eersteLetterVanDeLeeftijd);
                infoOverPersoon = $"{persoon[1]} {persoon[0]} uit {persoon[3]} is een {decennium} ";
                lstResultaat.Items.Add(infoOverPersoon);

                //string leeftijdNaam = ToonDecennium(eersteLetterLeeftijd);
                //infoOverPersoon = $"{persoon[1]} {persoon[0]} uit {persoon[3]} is een {leeftijdNaam} ";
                //lstResultaat.Items.Add(infoOverPersoon);
            }
        }

        private void btnZoekNaam_Click(object sender, RoutedEventArgs e)
        {
            string zoekterm = txtZoekNaam.Text.ToUpper();
            ToonPersonen(zoekterm, true);
        }

        void ToonPersonen(string zoekterm, bool eerste)
        {
            lstResultaat.Items.Clear();
            foreach (string[] persoon in personen)
            {
                string naam = persoon[0];
                if (naam.ToUpper().Contains(zoekterm))
                {
                    string infoOverPersoon = "";
                    if (persoon[4] == "M") infoOverPersoon = $"{persoon[1]} {persoon[0]} komt uit {persoon[3]} en woont in {persoon[2]}. Hij is {persoon[5]} jaar.";
                    else infoOverPersoon = $"{persoon[1]} {persoon[0]} komt uit {persoon[3]} en woont in {persoon[2]}. Ze is {persoon[5]} jaar.";
                    lstResultaat.Items.Add(infoOverPersoon);
                    if (eerste) break;
                }
            }
        }

        private void txtFilterNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = txtFilterNaam.Text.ToUpper();
            ToonPersonen(filter, false);
        }
    }
}
