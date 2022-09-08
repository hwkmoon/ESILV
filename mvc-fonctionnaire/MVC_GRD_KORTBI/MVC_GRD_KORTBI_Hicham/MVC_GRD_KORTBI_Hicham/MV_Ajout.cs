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
using System.Collections.ObjectModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MVC_GRD_KORTBI_Hicham
{
    class MV_Ajout: INotifyPropertyChanged
    {
        M_GestionnaireDonnees bd = new M_GestionnaireDonnees();
        private string textBoxNom = "";
        private string textBoxPrenom = "";
        private string textBoxPoste = "";
        private string textBoxDpt = "";
        private string textBoxSalaire = "";

        public string TextBoxNom
        {
            get { return textBoxNom.ToUpper(); }
            set
            {
                textBoxNom = value;
                NotifyPropertyChanged("TextBoxNom");
            }
        }
        public string TextBoxPrenom
        {
            get { return textBoxPrenom.ToUpper(); }
            set
            {
                textBoxPrenom = value;
                NotifyPropertyChanged("TextBoxPrenom");
            }
        }
        public string TextBoxPoste
        {
            get { return textBoxPoste.ToUpper(); }
            set
            {
                textBoxPoste = value;
                NotifyPropertyChanged("TextBoxPoste");
            }
        }
        public string TextBoxDpt
        {
            get { return textBoxDpt.ToUpper(); }
            set
            {
                textBoxDpt = value;
                NotifyPropertyChanged("TextBoxDpt");
            }
        }
        public string TextBoxSalaire
        {
            get { return textBoxSalaire.ToUpper(); }
            set
            {
                textBoxSalaire = value;
                NotifyPropertyChanged("TextBoxSalaire");
            }
        }
        public MV_Ajout()
        {
        }
        public bool Saisie()
        {
            bool saisie = false;
            M_GestionnaireDonnees bd = new M_GestionnaireDonnees();
            if (TextBoxNom == " " || TextBoxPrenom == "" || TextBoxPoste == "" || TextBoxDpt == "" || TextBoxSalaire == "")
            {
                saisie = true;
            }
            return saisie;
        }

        public bool Verif()
        {
            bool verif = false;
            int i = 0;
            foreach (M_Fonctionnaire fonct in bd.GetFonctionnaire())
            {
                if (TextBoxDpt != fonct.Dpt.NomDpt ||TextBoxPoste != fonct.Poste.NomPoste)
                {
                    i++;
                }
            }
            if (i != 0)
            {
                        verif=true;
            }
            return verif;
        }
        public bool Message()
        {
            bool msg = false;
            DialogResult result=MessageBox.Show("Le département et/ou la fonction n'existe pas ,\nEtes-vous sur de votre choix?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                msg = true;
            }
            else if (result == DialogResult.Yes)
            {
              
            }
            return msg;
        }
        public void Ajouter()
        {
            Random rnd = new Random();
            int lid = rnd.Next(0, 1000);
            int salaire = Int32.Parse(TextBoxSalaire);
            string sql = "INSERT INTO S6_MVC_Chicago.Employee (lastName, firstName, positionID, departementID, annualSalary) VALUES ('TextBoxName', 'TExyBoxFirstName', 131, 16, 77364)";
            /*exemple
            INSERT INTO S6_MVC_Chicago.Employee(lastName, firstName, positionID, departementID, annualSalary) VALUES('BRAY', 'TERRENCE D', 131, 16, 77364);*/
            MySqlCommand cmd = new MySqlCommand(sql, bd.Connexion());
            cmd.ExecuteNonQuery();
            sql = "INSERT INTO department (name) VALUES ('" + TextBoxDpt + "')";
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand(sql, bd.Connexion());
            sql = "INSERT INTO position (title) VALUES ('" + TextBoxPoste + "')";
            cmd = new MySqlCommand(sql, bd.Connexion());
            cmd.ExecuteNonQuery();
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
