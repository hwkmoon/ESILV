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
    /// Logique d'interaction pour Itineraire.xaml
    /// </summary>
    public partial class Itineraire : Page
    {
        public Itineraire()
        {
            InitializeComponent();
            fill_combo();
        }
        string dbConnectionString = "Data Source=database.db;Version=3;New=True;Compress=True;";

        void fill_combo()
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            try
            {
                sqliteCon.Open();
                string Query = "Select reference,numeroderue,typederue,nomdelarue,codepostale,ville from helio_benne" ;
                SQLiteCommand createCommand = new SQLiteCommand(Query,sqliteCon);
                SQLiteDataReader dr = createCommand.ExecuteReader();
                
                while(dr.Read())
                {
                   
                    string reference = dr.GetString(0);
                    //string adresse = dr.GetString(1) + " " + dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5);
                    comboBox.Items.Add(reference);
                }
                sqliteCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox_SelectedIndexChanged(object sender,EventArgs args)
        {
            string sauvegardea = "";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            try
            {
                sqliteCon.Open();
                string Query = "Select numeroderue,typederue,nomdelarue,codepostale,ville from helio_benne where reference='" + comboBox.SelectedItem.ToString() + "' ;";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                SQLiteDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string adresse = dr.GetString(0) + " " + dr.GetString(1) + " " + dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4);
                    sauvegardea = adresse;
                    if (textBox1.Text == "")
                    {
                        textBox1.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text == "")
                    {
                        textBox2.Text = adresse;
                    }
                   
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text == "")
                    {
                        textBox3.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text == "")
                    {
                        textBox4.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text == "")
                    {
                        textBox5.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text == "")
                    {
                        textBox6.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text == "")
                    {
                        textBox7.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text == "")
                    {
                        textBox8.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text == "")
                    {
                        textBox9.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text == "")
                    {
                        textBox10.Text = adresse;
                    }
                    else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text == "")
                    {
                        textBox11.Text = adresse;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqliteCon.Close();
                try
                {


                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

                // open the connection:
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO base_adresse (id, adresse) VALUES (NULL, '" + sauvegardea + "');";


                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();

                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            
            Maps maps = new Maps();
            maps.WindowStartupLocation = WindowStartupLocation.CenterScreen;          
            maps.Show();
            

        }

        private void button2_Click(object sender, RoutedEventArgs e)
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
            sqlite_cmd.CommandText = "DELETE from base_adresse ;";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
           
        }

        private void buttondeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
