using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SQLite;
using System.Net.Mail;
using System.Windows;
namespace Helio_benne
{
    class C_Inscription: INotifyPropertyChanged
    {
        private string valeurtextbox1 = "";
        private string valeurtextbox2 = "";
        private string valeurtextbox3 = "";
        private string valeurtextbox4 = "";
        private string valeurtextbox5 = "";
        private string valeurtextbox6 = "";
        private string message = "";
        private M_Connexion connexion;
        public C_Inscription()
        {
            connexion = new M_Connexion();
        }

        public M_Connexion Connected
        {
            get { return connexion; }
            set { connexion = value; }
        }
        public string ValeurTextBox1
        {
            get { return valeurtextbox1; }
            set
            {
                valeurtextbox1 = value;
                NotifyPropertyChanged("ValeurTextBox1");

            }
        }
        public string ValeurTextBox2
        {
            get { return valeurtextbox2; }
            set
            {
                valeurtextbox2 = value;
                NotifyPropertyChanged("ValeurTextBox2");

            }
        }
        public string ValeurTextBox3
        {
            get { return valeurtextbox3; }
            set
            {
                valeurtextbox3 = value;
                NotifyPropertyChanged("ValeurTextBox3");

            }
        }
        public string ValeurTextBox4
        {
            get { return valeurtextbox4; }
            set
            {
                valeurtextbox4 = value;
                NotifyPropertyChanged("ValeurTextBox4");

            }
        }
        public string ValeurTextBox5
        {
            get { return valeurtextbox5; }
            set
            {
                valeurtextbox5 = value;
                NotifyPropertyChanged("ValeurTextBox5");

            }
        }
        public string ValeurTextBox6
        {
            get { return valeurtextbox6; }
            set
            {
                valeurtextbox6 = value;
                NotifyPropertyChanged("ValeurTextBox6");

            }
        }
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }


        public bool Sinscrire()
        {
            bool ok = false;
            if(ValeurTextBox1!="" || ValeurTextBox2!="" || ValeurTextBox3!="" || ValeurTextBox4!="" || ValeurTextBox5!="" || ValeurTextBox6!="")
            {
                if(ValeurTextBox4==ValeurTextBox5)
                {
                    ok = true;
                }
                else
                {
                    Message = "Les mots de passes sont différents!";
                }
            }
            else // Un ou plusieurs champs sont vides
            {
                Message = "Un ou plusieurs champs sont vides";
            }
            return ok;
        }

        public void EnregistrementBD()
        {
            Connected.Insert(ValeurTextBox3, ValeurTextBox4, ValeurTextBox1, ValeurTextBox2, ValeurTextBox6);
        }

        public void SendEmail()
        {
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "heliobenne@gmail.com";
                string password = "heliobenneping2016";
                string emailTo = ValeurTextBox6;;
                string subject = "Bienvenue";
                string body = "Bienvenue " + ValeurTextBox1+" "+ ValeurTextBox2+ " au projet PING 2016 Helio-benne,\nNous vous remercions d'avoir choisi Hélio-benne et nous espérons que vous serez satisfait du produit.\nVoici votre nom d'utilisateur: "+ValeurTextBox3+"";
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Le message n'a pu être envoyé, si vous utilisez un routeur public, il se peut qu'il ne laisse pas passer le message d'inscription, pour quand même essayer notre application utiliser l'identifiant: heliobenne et le mot de passe: heliobenne   "+e+"");
            }
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
