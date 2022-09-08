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


namespace WpfAlcootest
{
    class DatabaseA
    {
        // Base de données locale fait avec SQLite

        public List<Personne> GetDB()
        {
            List<Personne> listePersonne = new List<Personne>();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            /* Création de la table
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "CREATE TABLE listeF (id integer primary key, nom varchar(15), prenom varchar(15), sexe varchar(3), poids varchar(10), alcoolemie varchar(10), tempsR varchar(8), sam varchar(8), numero varchar(15), adresse varchar(20));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();
            */
            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM listeF";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {

                // Test
                // Print out the content of the text field:
                //System.Console.WriteLine(sqlite_datareader["text"]);
                /*
                MessageBox.Show(sqlite_datareader.GetValue(0).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(1).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(2).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(3).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(4).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(5).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(6).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(7).ToString());
                MessageBox.Show(sqlite_datareader.GetValue(8).ToString());
                */

                Personne personne = new Personne(sqlite_datareader.GetValue(0).ToString(), sqlite_datareader.GetString(1).ToString(), sqlite_datareader.GetString(2).ToString(), sqlite_datareader.GetString(3).ToString(), Int32.Parse(sqlite_datareader.GetString(4).ToString()), Double.Parse(sqlite_datareader.GetString(5).ToString()), sqlite_datareader.GetString(6).ToString(), sqlite_datareader.GetString(7).ToString(), sqlite_datareader.GetString(8).ToString(), sqlite_datareader.GetString(9).ToString());
                listePersonne.Add(personne);
            }
            sqlite_conn.Close();
            return listePersonne;
        }
    }
}
