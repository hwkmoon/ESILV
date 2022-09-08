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
using System.Net.Mail;

namespace Helio_benne
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        private C_Inscription inscription;

        public Inscription()
        {
            InitializeComponent();
            inscription = new C_Inscription();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            inscription.ValeurTextBox1 = textBox1.Text;
            inscription.ValeurTextBox2 = textBox2.Text;
            inscription.ValeurTextBox3 = textBox3.Text;
            inscription.ValeurTextBox4 = textBox4.Text;
            inscription.ValeurTextBox5 = textBox5.Text;
            inscription.ValeurTextBox6 = textBox6.Text;
            if(inscription.Sinscrire()==true)
            {
                inscription.EnregistrementBD();
                inscription.SendEmail();
                MessageBox.Show("Bravo, vous êtes enregistrés, si tout ce passe bien, vous allez recevoir dans quelques instants un email dans votre boite mail");
                MainWindow mainwindow = new MainWindow();
                mainwindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                mainwindow.Show();
                this.Close();
            }
            else
            {
                textBlock2.Text = inscription.Message;
            }
        }
    }
}
