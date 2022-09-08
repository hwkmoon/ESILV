using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace MVC_GRD_KORTBI_Hicham
{
    public class MV_Fonctionnaire
    {
        private string position;
        private string departement;
        private string lastName;
        private string firstName;
        private string salary;

        public MV_Fonctionnaire(string lN,string fN,string pos,string dpt,string salaire)
        {
            this.lastName = lN;
            this.firstName = fN;
            this.position = pos;
            this.departement = dpt;
            this.salary = salaire;
        }
        
        public string LastNameFinal
        {
            get { return this.lastName; }
            set {this.lastName=value; }
        }
        public string FirstNameFinal
        {
            get { return this.firstName; }
            set { this.firstName=value; }
        }
        public string Salaire
        {
            get { return this.salary; }
            set { this.salary=value; }
        }
        public string PositionFinal
        {
            get { return this.position; }
            set { this.position=value; }
        }
        public string DepartementFinal
        {
            get { return this.departement; }
            set { this.position=value; }
        }
  
    }
}

