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
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace MVC_GRD_KORTBI_Hicham
{
    /// <summary>
    /// Logique d'interaction pour Recherche.xaml
    /// </summary>
    public partial class V_Recherche : Window
    {
        private MV_Recherche mv_recherche;
        public V_Recherche()
        {
            InitializeComponent();
            mv_recherche = new MV_Recherche();
            listView.ItemsSource = mv_recherche;
            
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainwindow.Show();
            this.Close();
        }
        private void quitter_Click(object sender,RoutedEventArgs e)
        {
            this.Close();
        }

        private void rechercher_Click(object sender, RoutedEventArgs e)
        {
            mv_recherche.ValeurTextBox1 = textbox1.Text;
            mv_recherche.ValeurTextBox2 = textbox2.Text;
            mv_recherche.GetFonctionnaireF();
        }

        private void sauvegarder_Click(object sender, RoutedEventArgs e)
        {   
            XmlDocument document = new XmlDocument();
            document = mv_recherche.SaveXML();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Xml(*.xml|*.xml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                document.Save(saveFileDialog1.FileName);
            }
        }
    }
}
