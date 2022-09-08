using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helio_benne
{
    class M_Adresse
    {
        private string numero;
        private string type;
        private string codepostale;
        private string ville;

        public M_Adresse()
        {

        }
        public string Numero
        {
            get { return this.numero; }
            set { numero = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { type = value; }
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
