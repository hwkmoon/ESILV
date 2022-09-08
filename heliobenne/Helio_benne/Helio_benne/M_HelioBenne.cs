using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helio_benne
{
    class M_HelioBenne
    {
        private string id;
        private string reference;
        private string numeroderue;
        private string typederue;
        private string nomderue;
        private string codepostale;
        private string ville;

        public M_HelioBenne(string id,string reference,string numero,string type,string nom,string code,string ville)
        {
            this.id = id;
            this.reference = reference;
            this.numeroderue = numero;
            this.typederue = type;
            this.nomderue = nom;
            this.codepostale = code;
            this.ville = ville;
        }

        public string Id
        {
            get { return this.id; }
        }
        public string Reference
        {
            get { return this.reference; }
            set { reference = value; }
        }
        public string NumeroDeRue
        {
            get { return this.numeroderue; }
            set { numeroderue = value; }
        }
        public string TypeDeRue
        {
            get { return this.typederue; }
            set { typederue = value; }
        }
        public string NomDeRue
        {
            get { return this.nomderue; }
            set { nomderue = value; }
        }
        public string CodePostale
        {
            get { return this.codepostale; }
            set { codepostale = value; }
        }
        public string Ville
        {
            get { return this.ville; }
            set { ville = value; }
        }
    }
}
