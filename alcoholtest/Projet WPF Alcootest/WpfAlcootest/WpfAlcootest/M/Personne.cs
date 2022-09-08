using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAlcootest
{
    class Personne
    {
        private string id;
        private string nom;
        private string prenom;
        private string sexe;
        private int poids;
        private double alcoolemie;
        private string sam;
        private string numero;
        private string ville;
        private string tempsR;

        public Personne(string id, string nom, string prenom, string sexe, int poids, double alcoolemie,string tempsR, string sam)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.poids = poids;
            this.sam = sam;
            this.alcoolemie = alcoolemie;
            this.tempsR = tempsR;
        }
        public Personne(string id, string nom, string prenom, string sexe, int poids, double alcoolemie, string tempsR, string sam, string numero, string ville)
        {
            this.id= id;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.poids = poids;
            this.alcoolemie = alcoolemie;
            this.sam = sam;
            this.numero = numero;
            this.ville = ville;
            this.tempsR = tempsR;
        }
        public string Id
        {
            get { return this.id; }
        }
        public string Nom
        {
            get { return this.nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return this.prenom; }
            set { prenom = value; }
        }
        public string Sexe
        {
            get { return this.sexe; }
            set { sexe = value; }
        }
        public int Poids
        {
            get { return this.poids; }
            set { poids = value; }
        }
        public string Sam
        {
            get { return this.sam; }
            set { sam = value; }
        }
        public string Numero
        {
            get { return this.numero; }
            set { numero = value; }
        }
        public string Ville
        {
            get { return this.ville; }
            set { ville = value; }
        }
        public double Alcoolemie
        {
            get { return this.alcoolemie; }
            set { alcoolemie = value; }
        }
        public string TempsR
        {
            get { return this.tempsR; }
            set { tempsR = value; }
        }
    }
}
