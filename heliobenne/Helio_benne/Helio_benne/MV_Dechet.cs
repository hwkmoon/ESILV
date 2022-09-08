using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helio_benne
{
    class MV_Dechet
    {
        private string time;
        private string nombreDechets;

        public MV_Dechet(string time, string nbd)
        {
            this.time = time;
            this.nombreDechets = nbd;
        }
        public string Time
        {
            get { return this.time; }
            set { time = value; }
        }
        public string NombreDechets
        {
            get { return this.nombreDechets; }
            set { nombreDechets = value; }
        }
    }
}
