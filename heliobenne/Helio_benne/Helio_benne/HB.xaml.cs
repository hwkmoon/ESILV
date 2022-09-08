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
using System.Data.SQLite;
namespace Helio_benne
{
    /// <summary>
    /// Logique d'interaction pour HB.xaml
    /// </summary>
    public partial class HB : Page
    {

        private MV_HB hb;
        public HB()
        {
            InitializeComponent();
            hb = new MV_HB();
            listView.ItemsSource = hb;

        }
        private void buttonEtat(object sender, RoutedEventArgs e)
        {
            Etat etat = new Etat();
            this.NavigationService.Navigate(etat);
        }
        private void buttonAccueil(object sender, RoutedEventArgs e)
        {
            Accueil accueil = new Accueil();
            this.NavigationService.Navigate(accueil);
        }
        private void buttonHB(object sender, RoutedEventArgs e)
        {
            HB hb = new HB();
            this.NavigationService.Navigate(hb);
        }
        private void buttonTrajet(object sender, RoutedEventArgs e)
        {
            Itineraire itineraire = new Itineraire();
            this.NavigationService.Navigate(itineraire);
        }
        private void buttonStatistiques(object sender, RoutedEventArgs e)
        {
            Statistiques stats = new Statistiques();
            this.NavigationService.Navigate(stats);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            hb.ValeurTextBoxA1 = textBoxReference.Text;
            hb.ValeurTextBoxA2 = textBoxNumeroDeRue.Text;
            hb.ValeurTextBoxA3 = textBoxTypeDeRue.Text;
            hb.ValeurTextBoxA4 = textBoxNomDeLaRue.Text;
            hb.ValeurTextBoxA5 = textBoxCodePostale.Text;
            hb.ValeurTextBoxA6 = textBoxVille.Text;
            if (hb.BAjouter() != true)
            {
                textBlock3.Text = hb.MessageA;
            }
            else
            {
                hb.Ajouter();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = null;
            listView.Items.Clear();
            listView.ItemsSource = hb;
                hb.ValeurTextBoxA1 = textBoxReference.Text;
                hb.ValeurTextBoxA2 = textBoxNumeroDeRue.Text;
                hb.ValeurTextBoxA3 = textBoxTypeDeRue.Text;
                hb.ValeurTextBoxA4 = textBoxNomDeLaRue.Text;
                hb.ValeurTextBoxA5 = textBoxCodePostale.Text;
                hb.ValeurTextBoxA6 = textBoxVille.Text;
                hb.actualiser();
            
        }

      

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "DELETE from helio_benne ;";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            textBoxReference.Text="";
            textBoxNumeroDeRue.Text="";
            textBoxTypeDeRue.Text="";
            textBoxNomDeLaRue.Text="";
            textBoxCodePostale.Text="";
            textBoxVille.Text="";
        }

        private void buttondeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    }

