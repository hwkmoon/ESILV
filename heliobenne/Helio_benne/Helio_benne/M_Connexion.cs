using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Mail;
namespace Helio_benne
{
    class M_Connexion:INotifyPropertyChanged
    {
        private bool success = false;
        private string messagec = "";
        private string username = "";
        private string mdp = "";
        private string usernameo = "";
        private string email = "";
        private string newmdp = "";
        public M_Connexion() { }

        public string Newmdp
        {
            get { return newmdp; }
            set { newmdp = value; }
        }
        public string Usernameo
        {
            get { return usernameo; }
            set
            {
                usernameo = value;
                NotifyPropertyChanged("Usernameo");

            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");

            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");

            }
        }
        public string Motdepasse
        {
            get { return mdp; }
            set
            {
                mdp = value;
                NotifyPropertyChanged("Motdepasse");

            }
        }
        public string Messagec
        {
            get { return messagec; }
            set
            {
                messagec = value;
                NotifyPropertyChanged("Messagec");
            }
        }

        public bool Success
        {
            get { return success; }
            set
            {
                success = value;
            }
        }
        public void Insert(string a,string b,string c,string d,string e)
        {
            SQLiteConnection sqlite_conn;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd;
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            // Lets insert something into our new table:
            sqlite_cmd.CommandText = "INSERT INTO base_donnees (id, pseudo,mdp,nom,prenom,email) VALUES (NULL,'" + a + "','" + b + "','" + c + "','" + d + "','" + e + "');";

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        public bool Select(string a,string b)
        {   
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT pseudo,mdp FROM base_donnees";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
               /* MessageBox.Show(sqlite_datareader.GetString(0));
                MessageBox.Show(sqlite_datareader.GetString(1));*/

                 if (sqlite_datareader.GetString(0)==a && sqlite_datareader.GetString(1)==b)
                {   
                    success = true;
                }
            }
            if(success!=true)
            {
                Messagec = "Le pseudo et/ou le mot de passe sont incorrects";
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            return success;
        }

        public void Update()
        {
            char[] lettersnumbers = "abcdefghijklmnopqrstuvwxyz123456789".ToCharArray();
            Random r = new Random();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            // But how do we read something out of our table ?
            // Lets update something into our new table:
            for (int i = 0; i < 10; i++)
            {
                newmdp += lettersnumbers[r.Next(0, 35)].ToString();
            }
            sqlite_cmd.CommandText = "UPDATE base_donnees SET mdp=@newmdp"+" WHERE pseudo=@Usernameo";
            // And execute this again ;D
        
            //sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }
        public void SendMDPO()
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "heliobenne@gmail.com";
            string password = "heliobenneping2016";
            string emailTo = Email ;
            string subject = "Bienvenue";
            string body = "Bonjour " + Usernameo + " voici votre nouveau mot de passe" + Newmdp + "";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new System.Net.NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
        #region implémentation de l'interface System.ComponentModel
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
