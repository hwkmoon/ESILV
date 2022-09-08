using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_GRD_KORTBI_Hicham
{
   public  class M_Poste
    {
        private string posteId;
        private string title;

        public M_Poste(string id, string title)
        {
            this.posteId = id;
            this.title = title;
        }
        public string NomPoste
        {
            get { return title; }
            set { title = value; }
        }
    }
}
