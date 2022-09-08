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
namespace MVC_GRD_KORTBI_Hicham
{
    class MV_Recherche : INotifyCollectionChanged, IEnumerable,INotifyPropertyChanged
    {
        private ObservableCollection<MV_Fonctionnaire> liste_mv_fonctionnaire { get; set; }
        M_GestionnaireDonnees bd = new M_GestionnaireDonnees();
        private string valeurTextBox1="";
        private string valeurTextBox2="";

        public MV_Recherche()
        {
            liste_mv_fonctionnaire = new ObservableCollection<MV_Fonctionnaire>();
        }
        public ObservableCollection<MV_Fonctionnaire> ListeMVFonctionnaire
        {
            get { return this.liste_mv_fonctionnaire; }
            set
            {
                liste_mv_fonctionnaire = value;
            }
        }

        public string ValeurTextBox1
        {
            get { return valeurTextBox1.ToUpper(); }
            set
            {  
                    valeurTextBox1 = value;
                    NotifyPropertyChanged("ValeurTextBox1");
                
            }
        }
        public string ValeurTextBox2
        {
            get { return valeurTextBox2.ToUpper(); }
            set
            {   
                    valeurTextBox2 = value;
                    NotifyPropertyChanged("ValeurTextBox2");
                
            }
        }
        
        public ObservableCollection<MV_Fonctionnaire> GetFonctionnaireF()
        {
            MessageBox.Show("Cliquez sur OK et patientez quelques secondes le temps que nous recherchions votre fonctionnaire");
            liste_mv_fonctionnaire.Clear();
            this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            List<M_Fonctionnaire> based = this.bd.GetFonctionnaire();
            foreach (M_Fonctionnaire valeur in based)
            {
                if (ValeurTextBox1 == "" && ValeurTextBox2 == "")
                {
                    //MessageBox.Show("ne contiens rien");
                    MV_Fonctionnaire mv_fonctionnaire = new MV_Fonctionnaire(valeur.LastName, valeur.FirstName, valeur.Poste.NomPoste, valeur.Dpt.NomDpt, valeur.Salary);
                    liste_mv_fonctionnaire.Add(mv_fonctionnaire);
                    this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, mv_fonctionnaire));
                }
                else if(valeur.LastName.Contains(ValeurTextBox1)==true && valeur.Poste.NomPoste.Contains(ValeurTextBox2)==true)
                {
                    MV_Fonctionnaire mv_fonctionnaire = new MV_Fonctionnaire(valeur.LastName, valeur.FirstName, valeur.Poste.NomPoste, valeur.Dpt.NomDpt, valeur.Salary);
                    liste_mv_fonctionnaire.Add(mv_fonctionnaire);
                    this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, mv_fonctionnaire));
                }
                else if (ValeurTextBox1 == ""  && valeur.Poste.NomPoste.Contains(ValeurTextBox2) == true)
                {
                    //MessageBox.Show("contiens le poste");
                    MV_Fonctionnaire mv_fonctionnaire = new MV_Fonctionnaire(valeur.LastName, valeur.FirstName, valeur.Poste.NomPoste, valeur.Dpt.NomDpt, valeur.Salary);
                    liste_mv_fonctionnaire.Add(mv_fonctionnaire);
                    this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, mv_fonctionnaire));
                }
                else if (ValeurTextBox2 == "" && valeur.LastName.Contains(ValeurTextBox1) == true)
                {
                    //MessageBox.Show("contiens le nom");
                    MV_Fonctionnaire mv_fonctionnaire = new MV_Fonctionnaire(valeur.LastName, valeur.FirstName, valeur.Poste.NomPoste, valeur.Dpt.NomDpt, valeur.Salary);
                    liste_mv_fonctionnaire.Add(mv_fonctionnaire);
                    this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, mv_fonctionnaire));
                }
                
            }
            if (liste_mv_fonctionnaire.Count==0)
            {
                MessageBox.Show("Le fonctionnaire que vous cherchez n'est pas dans la base de données");
            }
            return liste_mv_fonctionnaire;
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
            return liste_mv_fonctionnaire.GetEnumerator();
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


        public XmlDocument SaveXML()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no"); //no <=> pas de DTD associée
                //Creation de la balise racine et association dans le document
                XmlElement racine = docXml.CreateElement("resultats");
                docXml.AppendChild(racine);

                XmlElement requete = docXml.CreateElement("requete");
            if (ValeurTextBox1 != "")
            {
                XmlElement nomr = docXml.CreateElement("nom");
                nomr.InnerText = ValeurTextBox1;
                requete.AppendChild(nomr);
            }
            if (ValeurTextBox2 != "")
            {
                XmlElement poster = docXml.CreateElement("poste");
                poster.InnerText = ValeurTextBox2;
                requete.AppendChild(poster);
            }
                racine.AppendChild(requete);

                foreach(MV_Fonctionnaire mv_fonctionnaire in liste_mv_fonctionnaire)
                {

                    //Creation d'une balise pour fonctionnaire
                    XmlElement fonctionnaire = docXml.CreateElement("fonctionnaire");
                    
                    //Balise nom
                    XmlElement nom = docXml.CreateElement("nom");
                    nom.InnerText = mv_fonctionnaire.LastNameFinal;
                    fonctionnaire.AppendChild(nom);

                    //Balise prénom
                    XmlElement prenom = docXml.CreateElement("prenom");
                    prenom.InnerText = mv_fonctionnaire.FirstNameFinal;
                    fonctionnaire.AppendChild(prenom);

                    //Balise poste
                    XmlElement poste = docXml.CreateElement("poste");
                    poste.InnerText = mv_fonctionnaire.PositionFinal;
                    fonctionnaire.AppendChild(poste);

                    //Balise departement
                    XmlElement departement = docXml.CreateElement("departement");
                    departement.InnerText = mv_fonctionnaire.DepartementFinal;
                    fonctionnaire.AppendChild(departement);

                    //Balise salaire
                    XmlElement salaire = docXml.CreateElement("salaire");
                    salaire.InnerText = mv_fonctionnaire.Salaire;
                    fonctionnaire.AppendChild(salaire);
                    

                    racine.AppendChild(fonctionnaire);
                }
            return docXml;
        }


    }
}
    

