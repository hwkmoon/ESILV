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

namespace Helio_benne
{
    /// <summary>
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : Page
    {
        public Statistiques()
        {
            InitializeComponent();
            webBrowser2.Navigate("http://www.planetoscope.com/dechets/363-production-de-dechets-dans-le-monde.html");
        }
        public WebBrowser webBrowser()
        {
            WebBrowser webBrowser2 = new WebBrowser();
            return webBrowser2;
        }
        private void buttonEtat(object sender, RoutedEventArgs e)
        {
            Etat etat = new Etat();
            this.NavigationService.Navigate(etat);
        }
        private void buttonAccueil(object sender, RoutedEventArgs e)
        {
            Accueil accueil = new Accueil();
            this.NavigationService.Navigate(accueil);
        }
        private void buttonHB(object sender, RoutedEventArgs e)
        {
            HB hb = new HB();
            this.NavigationService.Navigate(hb);
        }
        private void buttonTrajet(object sender, RoutedEventArgs e)
        {
            Itineraire itineraire = new Itineraire();
            this.NavigationService.Navigate(itineraire);
        }
        private void buttonStatistiques(object sender, RoutedEventArgs e)
        {
            Statistiques stats = new Statistiques();
            this.NavigationService.Navigate(stats);
        }
        private void buttondeconnexion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
