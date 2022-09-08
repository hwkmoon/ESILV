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

namespace MVC_GRD_KORTBI_Hicham
{
    /// <summary>
    /// Logique d'interaction pour V_Ajout.xaml
    /// </summary>
    public partial class V_Ajout : Window
    {
        private MV_Ajout mv_ajout = new MV_Ajout();
        public V_Ajout()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }

        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            mv_ajout.TextBoxNom = textbox2.Text;
            mv_ajout.TextBoxPrenom = textbox3.Text;
            mv_ajout.TextBoxPoste = textbox4.Text;
            mv_ajout.TextBoxDpt = textbox5.Text;
            mv_ajout.TextBoxSalaire = textbox6.Text;
            
            if(mv_ajout.Saisie()==true)
            {
            MessageBox.Show("Vous n'avez pas saisie toutes les données");
            }
            else if(mv_ajout.Verif()==true)
            {
                if(mv_ajout.Message()==true)
                {
                }
                else
                {
                    mv_ajout.Ajouter();
                }
            }
        }

        private void textBoxPoste_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
