using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helio_benne
{
    class MV_HelioBenne
    {
   
        private string reference;
        private string numeroderue;
        private string typederue;
        private string nomderue;
        private string codepostale;
        private string ville;

        public MV_HelioBenne( string reference, string numero, string type, string nom, string code, string ville)
        {
            this.reference = reference;
            this.numeroderue = numero;
            this.typederue = type;
            this.nomderue = nom;
            this.codepostale = code;
            this.ville = ville;
        }

       
        public string ReferenceFinale
        {
            get { return this.reference; }
            set { reference = value; }
        }
        public string NumeroDeRueFinale
        {
            get { return this.numeroderue; }
            set { numeroderue = value; }
        }
        public string TypeDeRueFinale
        {
            get { return this.typederue; }
            set { typederue = value; }
        }
        public string NomDeRueFinale
        {
            get { return this.nomderue; }
            set { nomderue = value; }
        }
        public string CodePostaleFinale
        {
            get { return this.codepostale; }
            set { codepostale = value; }
        }
        public string VilleFinale
        {
            get { return this.ville; }
            set { ville = value; }
        }
    }
}
