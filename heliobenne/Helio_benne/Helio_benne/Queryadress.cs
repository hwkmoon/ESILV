using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Helio_benne
{
    class Queryadress : INotifyPropertyChanged
    {
        private string valeurtextboxq1 = "";
        private string valeurtextboxq2 = "";
        private string valeurtextboxq3 = "";
        private string valeurtextboxq4 = "";
        private string valeurtextboxq5 = "";
        private string valeurtextboxq6 = "";
        private string valeurtextboxq7 = "";
        private string valeurtextboxq8 = "";
        private string valeurtextboxq9 = "";
        private string valeurtextboxq10 = "";
        private string valeurtextboxq11 = "";

        public string ValeurTextBoxQ1
        {
            get { return valeurtextboxq1; }
            set
            {
                valeurtextboxq1 = value;
                NotifyPropertyChanged("ValeurTextBoxQ1");

            }
        }

        public string ValeurTextBoxQ2
        {
            get { return valeurtextboxq2; }
            set
            {
                valeurtextboxq2 = value;
                NotifyPropertyChanged("ValeurTextBoxQ2");

            }
        }
        public string ValeurTextBoxQ3
        {
            get { return valeurtextboxq3; }
            set
            {
                valeurtextboxq3 = value;
                NotifyPropertyChanged("ValeurTextBoxQ3");

            }
        }
        public string ValeurTextBoxQ4
        {
            get { return valeurtextboxq4; }
            set
            {
                valeurtextboxq4 = value;
                NotifyPropertyChanged("ValeurTextBoxQ4");

            }
        }
        public string ValeurTextBoxQ5
        {
            get { return valeurtextboxq5; }
            set
            {
                valeurtextboxq5 = value;
                NotifyPropertyChanged("ValeurTextBoxQ5");

            }
        }
        public string ValeurTextBoxQ6
        {
            get { return valeurtextboxq6; }
            set
            {
                valeurtextboxq6 = value;
                NotifyPropertyChanged("ValeurTextBoxQ6");

            }
        }
        public string ValeurTextBoxQ7
        {
            get { return valeurtextboxq7; }
            set
            {
                valeurtextboxq7 = value;
                NotifyPropertyChanged("ValeurTextBoxQ7");

            }
        }

        public string ValeurTextBoxQ8
        {
            get { return valeurtextboxq8; }
            set
            {
                valeurtextboxq8 = value;
                NotifyPropertyChanged("ValeurTextBoxQ8");

            }
        }
        public string ValeurTextBoxQ9
        {
            get { return valeurtextboxq9; }
            set
            {
                valeurtextboxq9 = value;
                NotifyPropertyChanged("ValeurTextBoxQ9");

            }
        }
        public string ValeurTextBoxQ10
        {
            get { return valeurtextboxq10; }
            set
            {
                valeurtextboxq10 = value;
                NotifyPropertyChanged("ValeurTextBoxQ10");

            }
        }
        public string ValeurTextBoxQ11
        {
            get { return valeurtextboxq11; }
            set
            {
                valeurtextboxq11 = value;
                NotifyPropertyChanged("ValeurTextBoxQ11");

            }
        }
        
        public string TheMaps()
        {

            string maps = "";
            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("https://maps.yahoo.com/directions/?lat=48.89629572302868&lon=2.235063314437866&bb=48.89997746%2C2.22464561%2C48.89261372%2C2.24548101");
                maps=queryaddress.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return maps;
        }
        public string Depart()
        {
            return ValeurTextBoxQ1;
        }

        #region implémentation de l'interface System.ComponentModel
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
        
    }
}
