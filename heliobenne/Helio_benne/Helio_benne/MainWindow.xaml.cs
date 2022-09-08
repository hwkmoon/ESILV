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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private M_Connexion connect;
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            connect = new M_Connexion();
            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            connect.Username = textBox1.Text;
            connect.Motdepasse = textBox2.Text;
            if(connect.Select(connect.Username,connect.Motdepasse)==true)
            {
                MessageBox.Show("Connexion réussie");
                Navigation navigation = new Navigation();
                navigation.Show();
                this.Close();
            }
            else
            {
                textBlock3.Text = connect.Messagec;
            }


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Inscription inscription = new Inscription();
            inscription.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            inscription.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MDPO mdpo = new MDPO();
            mdpo.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mdpo.Show();
        }
        /*
   // [snip] - As C# is purely object-oriented the following lines must be put into a class:

   // We use these three SQLite objects:
   SQLiteConnection sqlite_conn;
   SQLiteCommand sqlite_cmd;
   SQLiteDataReader sqlite_datareader;

   // create a new database connection:
   sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

   // open the connection:
   sqlite_conn.Open();

   // create a new SQL command:
   sqlite_cmd = sqlite_conn.CreateCommand();

   // Let the SQLiteCommand object know our SQL-Query:
   sqlite_cmd.CommandText = "CREATE TABLE base_donnees (id integer primary key, pseudo varchar(12), mdp varchar(12), nom varchar(15), prenom varchar(15), email varchar(20) );";

   // Now lets execute the SQL ;D
   sqlite_cmd.ExecuteNonQuery();

   // Lets insert something into our new table:
   sqlite_cmd.CommandText = "INSERT INTO base_donnees (id, pseudo,mdp,nom,prenom,email) VALUES (NULL, 'chamok','lemotdepasse','kortbi','hicham','cham.2too@gmail.com');";

   // And execute this again ;D
   sqlite_cmd.ExecuteNonQuery();

   // ...and inserting another line:
   //sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (2, 'Test Text 2');";

   // And execute this again ;D
   //sqlite_cmd.ExecuteNonQuery();

   // But how do we read something out of our table ?
   // First lets build a SQL-Query again:
   sqlite_cmd.CommandText = "SELECT * FROM base_donnees";

   // Now the SQLiteCommand object can give us a DataReader-Object:
   sqlite_datareader = sqlite_cmd.ExecuteReader();

   // The SQLiteDataReader allows us to run through the result lines:
   while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
   {
       // Print out the content of the text field:
       //System.Console.WriteLine(sqlite_datareader["text"]);
       string data = sqlite_datareader.GetString(1);
       MessageBox.Show(data);
   }

   // We are ready, now lets cleanup and close our connection:
   sqlite_conn.Close();
   */
    }
}
