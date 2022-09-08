using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace MVC_GRD_KORTBI_Hicham
{

    public class M_GestionnaireDonnees
    {
        List<M_Fonctionnaire> liste_fonctionnaire = new List<M_Fonctionnaire>();
        public M_GestionnaireDonnees() { }
        public MySqlConnection Connexion()
        {
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=S6_MVC_Chicago;UID=esilvs6;PASSWORD=esilvs6;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return connection;
        }
        public List<M_Fonctionnaire> GetFonctionnaire()
        {
            
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=S6_MVC_Chicago;UID=esilvs6;PASSWORD=esilvs6;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM (employee join position on position.id=employee.positionID)join department on employee.departementID=department.id;";


            MySqlDataReader reader;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string valueAsString = reader.GetValue(i).ToString();
                    currentRowAsString += valueAsString + ", ";
                }
                Console.WriteLine();
                string[] temp = currentRowAsString.Split(',');
                M_Departement dpt = new M_Departement(temp[4], temp[9]);
                M_Poste position = new M_Poste(temp[3], temp[7]);
                M_Fonctionnaire n_fonctionnaire = new M_Fonctionnaire(temp[0], temp[1], temp[2], position, dpt, temp[5]);
                liste_fonctionnaire.Add(n_fonctionnaire);
            }
            connection.Close();
            return liste_fonctionnaire;
        }

        public List<M_Fonctionnaire> ListeF
        {
            get { return this.liste_fonctionnaire; }
        }
    }
}
