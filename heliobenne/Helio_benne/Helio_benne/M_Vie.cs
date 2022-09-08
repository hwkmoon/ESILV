using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helio_benne
{
    class M_Vie
    {
        private string time;
        private string viedetecte;

        public M_Vie(string time, string vieon)
        {
            this.time = time;
            this.viedetecte = vieon;
        }
        public string Time
        {
            get { return this.time; }
            set { time = value; }
        }
        public string NombreDechets
        {
            get { return this.viedetecte; }
            set { viedetecte = value; }
        }
    }
}
