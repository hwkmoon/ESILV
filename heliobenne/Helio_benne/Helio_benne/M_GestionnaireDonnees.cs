using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Helio_benne
{
    class M_GestionnaireDonnees
    {
        public List<M_Dechet> GetDechets()
        {
            List<M_Dechet> dechets = new List<M_Dechet>();
            try
            {

               
                string connectionString = "SERVER=db4free.net;PORT=3306;DATABASE=base_donnees;UID=heliobenne;PASSWORD=heliobenneping2016;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT time,capteurm FROM arduino1;";

                MySqlDataReader reader;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    M_Dechet dechet = new M_Dechet(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());
                    dechets.Add(dechet);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion à la base de donnée sur db4free.net, la base de données n'est pas accessible pour le moment, en attendant dirigez-vous vers le site www.helio-benne.esy.es pour connaitre l'état actuel de votre hélio-benne  "+ex+" ");
            }
            return dechets;
        }
        public List<M_Vie> GetPresenceVie()
        {
            List<M_Vie> lavie = new List<M_Vie>();
            string connectionString = "SERVER=db4free.net;PORT=3306;DATABASE=base_donnees;UID=heliobenne;PASSWORD=heliobenneping2016;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT time,capteurv FROM arduino2;";

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                M_Vie vie = new M_Vie(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());
                lavie.Add(vie);
            }
            return lavie;
        }
    }
}
