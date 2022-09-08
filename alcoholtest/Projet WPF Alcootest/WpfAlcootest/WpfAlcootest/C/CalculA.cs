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
using System.Xml;
using System.Data.SQLite;

namespace WpfAlcootest
{
    class CalculA: INotifyCollectionChanged, IEnumerable, INotifyPropertyChanged
    {
        private ObservableCollection<Personne> liste_m_personne { get; set; }
        private string valeurTextBox1 = "";
        private string valeurTextBox2 = "";
        private bool checkBox1 = false;
        private bool checkBox2 = false;
        private string valeurTextBox3 = "";
        private bool checkBox3 = false;
        private bool checkBox4 = false;
        private string valeurTextBox4 = "";
        private string valeurTextBox5 = "";
        private string valeurTextBox6 = "0";
        private string valeurTextBox7 = "0";
        private string valeurTextBox8 = "0";
        private string valeurTextBox9 = "0";
        private string valeurTextBox10 = "0";
        private string valeurTextBox11 = "0";
        private string label1;
        private string label2;
        public CalculA()
        {
            liste_m_personne = new ObservableCollection<Personne>();
        }
        public ObservableCollection<Personne> ListeMPersonne
        {
            get { return this.liste_m_personne; }
            set
            {
                liste_m_personne = value;
            }
        }

        // Nom
        public string ValeurTextBox1
        {
            get { return valeurTextBox1; }
            set
            {
                valeurTextBox1 = value;
                NotifyPropertyChanged("ValeurTextBox1");

            }
        }

        // Prénom
        public string ValeurTextBox2
        {
            get { return valeurTextBox2; }
            set
            {
                valeurTextBox2 = value;
                NotifyPropertyChanged("ValeurTextBox2");

            }
        }

        // Sexe Masculin
        public bool CheckBox1
        {
            get { return checkBox1; }
            set
            {
                checkBox1 = value;
                NotifyPropertyChanged("CheckBoxB1");

            }
        }
        
        // Sexe Féminin
        public bool CheckBox2
        {
            get { return checkBox2; }
            set
            {
                checkBox2 = value;
                NotifyPropertyChanged("CheckBox2");

            }
        }
        
        // Poids
        public string ValeurTextBox3
        {
            get { return valeurTextBox3; }
            set
            {
                valeurTextBox3 = value;
                NotifyPropertyChanged("ValeurTextBox3");

            }
        }

        // SAM Oui
        public bool CheckBox3
        {
            get { return checkBox3; }
            set
            {
                checkBox3 = value;
                NotifyPropertyChanged("CheckBox3");

            }
        }

        // SAM Non
        public bool CheckBox4
        {
            get { return checkBox4; }
            set
            {
                checkBox4 = value;
                NotifyPropertyChanged("CheckBox4");

            }
        }

        // Numéro mobile
        public string ValeurTextBox4
        {
            get { return valeurTextBox4; }
            set
            {
                valeurTextBox4 = value;
                NotifyPropertyChanged("ValeurTextBox4");

            }
        }

        // Adresse (ville)
        public string ValeurTextBox5
        {
            get { return valeurTextBox5; }
            set
            {
                valeurTextBox5 = value;
                NotifyPropertyChanged("ValeurTextBox5");

            }
        }

        // Première heure de consommation
        public string ValeurTextBox6
        {
            get { return valeurTextBox6; }
            set
            {
                valeurTextBox6 = value;
                NotifyPropertyChanged("ValeurTextBox6");

            }
        }

        // Dernière heure de consommation
        public string ValeurTextBox7
        {
            get { return valeurTextBox7; }
            set
            {
                valeurTextBox7 = value;
                NotifyPropertyChanged("ValeurTextBox7");

            }
        }

        // Nombre de bières
        public string ValeurTextBox8
        {
            get { return valeurTextBox8; }
            set
            {
                valeurTextBox8 = value;
                NotifyPropertyChanged("ValeurTextBox8");

            }
        }

        // Nombre de bière légères
        public string ValeurTextBox9
        {
            get { return valeurTextBox9; }
            set
            {
                valeurTextBox9 = value;
                NotifyPropertyChanged("ValeurTextBox9");

            }
        }

        // Nombre de verres de vin
        public string ValeurTextBox10
        {
            get { return valeurTextBox10; }
            set
            {
                valeurTextBox10 = value;
                NotifyPropertyChanged("ValeurTextBox10");

            }
        }

        // Nombre de verres de spiritueux
        public string ValeurTextBox11
        {
            get { return valeurTextBox11; }
            set
            {
                valeurTextBox11 = value;
                NotifyPropertyChanged("ValeurTextBox11");

            }
        }

        // Taux d'alcoolémie de la personne
        public string Label1
        {
            get { return label1; }
            set
            {
                label1 = value;
                NotifyPropertyChanged("Label1");

            }
        }

        // Temps restant avant élimination totale de l'alcool dans l'organisme de l'individu
        public string Label2
        {
            get { return label2; }
            set
            {
                label2 = value;
                NotifyPropertyChanged("Label2");

            }
        }

        // Vérificiation que les informations de la personnes ont bien été fournies
        public bool ChampVide()
        {
            bool ok = false;
            if (ValeurTextBox1 != "" && ValeurTextBox2 != "" && ValeurTextBox3 != ""  && ValeurTextBox6 != "" && ValeurTextBox7 != "" && ValeurTextBox8 != "" && ValeurTextBox9 != "" && ValeurTextBox10 != "" && ValeurTextBox11 != "")
            {
                if((CheckBox1 == true && CheckBox2 == false)||(CheckBox1==false && CheckBox2==true))
                {
                    if((CheckBox3 == true && CheckBox4 == false) || (CheckBox3 == false && CheckBox4 == true))
                    {
                        ok = true;
                    }
                }

            }
            else // Un ou plusieurs champs sont vides
            {
                ok = false;    
            }
            return ok;
        }

        // Vérification des informations supplémentaires du SAM
        public bool ChampVide2()
        {
            bool ok = false;
            if (ValeurTextBox4 != "" && ValeurTextBox5 != "")
            {
                if ((CheckBox3 == true && CheckBox4 == false) || (CheckBox3 == false && CheckBox4 == true))
                {
                    ok = true;
                }

            }
            else // Un ou plusieurs champs sont vides
            {
                ok = false;
            }
            return ok;
        }


        // Vérification que le poids entré par l'utilisateur est bien rentré dans le format correct (entier)
        public bool CheckType()
        {
            bool ok = false;
            int num;
            if(int.TryParse(ValeurTextBox3,out num)==false)
            {
                // Le poids indiqué sous format String is not a number.
                ok = true;
            }
            return ok;
        }

        // Vérification que la différence entre la première et dernière heure de consommation n'est pas négatif
        public bool DureeNegative()
        {
            bool ok = false;
            int premiere=Int32.Parse(ValeurTextBox6);
            int derniere = Int32.Parse(ValeurTextBox7);
            if (premiere-derniere>=0)
            {
                ok = true;
            }
            return ok;
        }

        // Sexe de la personne
        public string Sexe()
        {
            string sexe = "";
            if(CheckBox1==true)
            {
                //True = M
                sexe = "M";
            }
            else
            {
                //False = F
                sexe="F";
            }
            return sexe;
        }

        // SAM
        public string Sam()
        {
            string sam = "";
            if(CheckBox3==true)
            {
                //True = Oui
                sam = "Oui";
            }
            else
            {
                //False = Non
                sam = "Non";
            }
            return sam;
        }

        // Nombre de consommations consommés par l'individu
        public int NombreConsommation()
        {
            int biere = Int32.Parse(ValeurTextBox8);
            int biereL = Int32.Parse(ValeurTextBox9);
            int vin = Int32.Parse(ValeurTextBox10);
            int spiritueux = Int32.Parse(ValeurTextBox11);
            int numberC = biere + biereL + vin + spiritueux;
            return numberC;
        }

        // Durée totale entre la première et dernière consommation
        public double Duree()
        {
            double dureeF = 0;
            int premiereC = Int32.Parse(ValeurTextBox6);
            int derniereC = Int32.Parse(ValeurTextBox7);
            int duree = premiereC - derniereC;
            if(NombreConsommation()==0)
            {
                return dureeF;
            }
            // L"utilisateur boit uniformément sur la durée + delta à prendre en compte
            double delta = duree / NombreConsommation();
            dureeF = premiereC+derniereC + delta ;
            return dureeF;
        }

        //Calcul du taux d'alcoolémie dans le sang de l'individu
        public double Alcoolemie()
        {
            double biere = Convert.ToDouble(Int32.Parse(ValeurTextBox8));
            double biereL = Convert.ToDouble(Int32.Parse(ValeurTextBox9));
            double vin = Convert.ToDouble(Int32.Parse(ValeurTextBox10));
            double spiritueux = Convert.ToDouble(Int32.Parse(ValeurTextBox11));
            double alcoolemie = 0;
            alcoolemie = (biere * 0.03 + biereL * 0.024 + vin * 0.035 + spiritueux * 0.039);
            int poids = Int32.Parse(ValeurTextBox3);
            // Homme
            if(Sexe()=="M")
            {
                if(poids>=400)
                {
                    alcoolemie = alcoolemie * 0.7;
                }
                else if(poids<=100)
                {
                    alcoolemie = alcoolemie * 1.4;
                }
            }
            // Femme
            else
            {
                if (poids >= 300)
                {
                    alcoolemie = alcoolemie * 0.7;
                }
                else if (poids <= 75)
                {
                    alcoolemie = alcoolemie * 1.4;
                }
            }
            alcoolemie = alcoolemie - 0.03 * Duree();
            return Math.Max(0, alcoolemie);
        }

        // Calcul du temps restant avant élimination totale de l'alcool dans l'organisme de l'individu
        public int TempsR()
        {
            int heuresR = 0;
            double tempsR = 0;
            tempsR = Alcoolemie() / 0.03;
            if(tempsR<1 &&tempsR!=0)
            {
                heuresR = 1;
            }
            else
            {
                heuresR = Convert.ToInt32(tempsR);
            }
            return heuresR;
        }

        // ListView
        public ObservableCollection<Personne> actualiser()
        {
            liste_m_personne.Clear();
            this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            DatabaseA db = new DatabaseA();
            List<Personne> listem = new List<Personne>();
            listem = db.GetDB();
            foreach (Personne pers in listem)
            {
                try
                {
                    liste_m_personne.Add(pers);
                    this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, pers));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                }
            }
            return liste_m_personne;
        }

        // Ajout dans la database locale des informations de la personne
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
            //sqlite_cmd.CommandText = "CREATE TABLE listepersonneF (id integer primary key, nom varchar(15), prenom varchar(15), sexe varchar(2), poids varchar(5), alcoolemie varchar(10), sam varchar(5), numero varchar(12), adresse varchar(15)) ;";

            // Now lets execute the SQL ;D
            //sqlite_cmd.ExecuteNonQuery();


            // Lets insert something into our new table:
            sqlite_cmd.CommandText = "INSERT INTO listeF (id, nom, prenom, sexe, poids, alcoolemie,tempsR, sam, numero, adresse) VALUES (NULL, '" + ValeurTextBox1 + "','" + ValeurTextBox2 + "','" + Sexe() + "','" + ValeurTextBox3 + "','" + Alcoolemie()+ "','" + TempsR()+"','" + Sam() + "','" + ValeurTextBox4 + "','" + ValeurTextBox5 + "');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }



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
            return liste_m_personne.GetEnumerator();
        }


        #endregion

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
