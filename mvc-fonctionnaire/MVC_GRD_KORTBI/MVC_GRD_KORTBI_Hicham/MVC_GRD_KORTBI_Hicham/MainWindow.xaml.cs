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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MVC_GRD_KORTBI_Hicham
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        private void rechercher_Click(object sender, RoutedEventArgs e)
        {

            V_Recherche recherche = new V_Recherche();
            recherche.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            recherche.Show();
            this.Close();
            
        }
        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            V_Ajout ajout = new V_Ajout();
            ajout.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ajout.Show();
            this.Close();
        }
    }
}
