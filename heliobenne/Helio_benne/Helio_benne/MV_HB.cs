using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SQLite;
namespace Helio_benne
{
    class MV_HB : INotifyPropertyChanged, INotifyCollectionChanged, IEnumerable
    {
        private string valeurtextboxa1 = "";
        private string valeurtextboxa2 = "";
        private string valeurtextboxa3 = "";
        private string valeurtextboxa4 = "";
        private string valeurtextboxa5 = "";
        private string valeurtextboxa6 = "";
        private string messagea = "";
        private ObservableCollection<MV_HelioBenne> liste_mv_hb { get; set; }
        public MV_HB()
        {
             liste_mv_hb = new ObservableCollection<MV_HelioBenne>();
        }
        public ObservableCollection<MV_HelioBenne> ListeMVHelioBenne
        {
            get { return this.liste_mv_hb; }
            set
            {
                liste_mv_hb = value;
            }
        }
        public string ValeurTextBoxA1
        {
            get { return valeurtextboxa1; }
            set
            {
                valeurtextboxa1 = value;
                NotifyPropertyChanged("ValeurTextBoxA1");

            }
        }

        public string ValeurTextBoxA2
        {
            get { return valeurtextboxa2; }
            set
            {
                valeurtextboxa2 = value;
                NotifyPropertyChanged("ValeurTextBoxA2");

            }
        }
        public string ValeurTextBoxA3
        {
            get { return valeurtextboxa3; }
            set
            {
                valeurtextboxa3 = value;
                NotifyPropertyChanged("ValeurTextBoxA3");

            }
        }
        public string ValeurTextBoxA4
        {
            get { return valeurtextboxa4; }
            set
            {
                valeurtextboxa4 = value;
                NotifyPropertyChanged("ValeurTextBoxA4");

            }
        }
        public string ValeurTextBoxA5
        {
            get { return valeurtextboxa5; }
            set
            {
                valeurtextboxa5 = value;
                NotifyPropertyChanged("ValeurTextBoxA5");

            }
        }
        public string ValeurTextBoxA6
        {
            get { return valeurtextboxa6; }
            set
            {
                valeurtextboxa6 = value;
                NotifyPropertyChanged("ValeurTextBoxA6");

            }
        }
        public string MessageA
        {
            get { return messagea; }
            set
            {
                messagea = value;
                NotifyPropertyChanged("MessageA");
            }
        }


        public bool BAjouter()
        {
            bool ok = false;
            M_GestionnaireHB ghb = new M_GestionnaireHB();
            if (ValeurTextBoxA1 != ""  || ValeurTextBoxA2 != ""  || ValeurTextBoxA3 != "" || ValeurTextBoxA4 != "" ||  ValeurTextBoxA5 != "" || ValeurTextBoxA6!="" )
            {
                ok = true;
            }
            else // Un ou plusieurs champs sont vides
            {
                ok = false;
                MessageA = "Un ou plusieurs champs sont vides";
            }
            return ok;
        }
        public ObservableCollection<MV_HelioBenne> actualiser()
        {
            liste_mv_hb.Clear();
            this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            M_GestionnaireHB ghb = new M_GestionnaireHB();
            List<M_HelioBenne> listem_hb = new List<M_HelioBenne>();
            listem_hb = ghb.GetHB();
            foreach(M_HelioBenne hb in listem_hb)
            {
                try
                {
                    string reference = hb.Reference;
                    string numeroderue = hb.NumeroDeRue;
                    string typederue = hb.TypeDeRue;
                    string nomderue = hb.NomDeRue;
                    string codepostale = hb.CodePostale;
                    string ville = hb.Ville;
                    MV_HelioBenne mv_hb = new MV_HelioBenne(reference, numeroderue, typederue, nomderue, codepostale, ville);
                    liste_mv_hb.Add(mv_hb);
                    this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, mv_hb));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error:"+ex);
                }
            }
            return liste_mv_hb;
        }

        public void Ajouter()
        {
            // [snip] - As C# is purely object-oriented the following lines must be put into a class:

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
            sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();


            // Lets insert something into our new table:
            sqlite_cmd.CommandText = "INSERT INTO helio_benne (id, reference,numeroderue,typederue,nomdelarue,codepostale,ville) VALUES (NULL, '"+ValeurTextBoxA1+"','"+ValeurTextBoxA2+"','"+ValeurTextBoxA3+"','"+ValeurTextBoxA4+"','"+ValeurTextBoxA5+"','"+ValeurTextBoxA6+"');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
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
        #region implémentation de l'interface System.Collections.Specialized.INotifyCollectionChanged

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }

        #endregion
        #region implémentation de l'interface  System.Collections.IEnumerable

        public IEnumerator GetEnumerator()
        {
            return liste_mv_hb.GetEnumerator();
        }


        #endregion
    }
}
