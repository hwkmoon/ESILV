using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_GRD_KORTBI_Hicham
{
    public class M_Departement
    {
        private string dptId;
        private string name;

        public M_Departement(string id, string name)
        {
            this.dptId = id;
            this.name = name;
        }
        public string NomDpt
        {
            get { return name; }
        }
    }
}
