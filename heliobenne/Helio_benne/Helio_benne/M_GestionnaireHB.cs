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
    class M_GestionnaireHB
    {
        public List<M_HelioBenne> GetHB()
        {
            List<M_HelioBenne> listehb = new List<M_HelioBenne>();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM helio_benne";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                //System.Console.WriteLine(sqlite_datareader["text"]);
                M_HelioBenne heliobenne = new M_HelioBenne(sqlite_datareader.GetValue(0).ToString(), sqlite_datareader.GetString(1).ToString(), sqlite_datareader.GetString(2).ToString(), sqlite_datareader.GetString(3).ToString(), sqlite_datareader.GetString(4).ToString(), sqlite_datareader.GetString(5).ToString(), sqlite_datareader.GetString(6).ToString());
                listehb.Add(heliobenne);
            }
            sqlite_conn.Close();
            return listehb;
        }
    }
}
