using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVC_GRD_KORTBI_Hicham
{
    public class M_Fonctionnaire
    {
        private string id;
        private string lastName;
        private string firstName;
        private M_Poste poste;
        private M_Departement dpt;
        private string annualSalary;

        public M_Fonctionnaire(string id, string lName, string fName, M_Poste poste, M_Departement dpt, string salaire)
        {
            this.id = id;
            this.lastName = lName;
            this.firstName = fName;
            this.poste = poste;
            this.dpt = dpt;
            this.annualSalary = salaire;
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public M_Poste Poste
        {
            get { return poste; }
            set { poste = value; }
        }
        public M_Departement Dpt
        {
            get { return dpt; }
        }
        public string FirstName
        {
            get { return firstName; }
        }
        public string Salary
        {
            get { return annualSalary; }
        }
        
    }
}
