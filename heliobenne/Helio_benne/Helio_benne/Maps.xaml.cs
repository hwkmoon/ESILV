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
using System.Windows.Shapes;
using System.Data.SQLite;

namespace Helio_benne
{
    /// <summary>
    /// Logique d'interaction pour Maps.xaml
    /// </summary>
    public partial class Maps : Window
    {
        private Queryadress queryadress;
        public Maps()
        {
            Itineraire itineraire = new Itineraire();
            queryadress = new Queryadress();
            StringBuilder adressefinale = new StringBuilder();
            adressefinale.Append(queryadress.TheMaps());
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            

            for (int i = 1; i <= 11; ++i)
            {
                
                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT adresse FROM base_adresse where id="+i+"";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                
                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    // Print out the content of the text field:
                    //System.Console.WriteLine(sqlite_datareader["text"]);
                    string data = sqlite_datareader.GetString(0);
                    MessageBox.Show(data);
                    if(i==1)
                    {
                        adressefinale.Append("&o="+data);
                    }
                    else if(i==2)
                    {
                        adressefinale.Append("&d=" + data);
                    }
                    else if(i>=3)
                    {
                        int j = 0;
                        adressefinale.Append("&w" + j + "=" + data);
                        j++;
                    }
                    // We are ready, now lets cleanup and close our connection:
                }
                sqlite_conn.Close();


                InitializeComponent();

                webBrowser1.Navigate(adressefinale.ToString());
            }
        }
        public WebBrowser webBrowser()
        {
            WebBrowser webBrowser1 = new WebBrowser();
            return webBrowser1;
        }
        //webBrowser1=webBroser();
    }
}
