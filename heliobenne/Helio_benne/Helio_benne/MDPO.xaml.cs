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

namespace Helio_benne
{
    /// <summary>
    /// Logique d'interaction pour MDPO.xaml
    /// </summary>
    public partial class MDPO : Window
    {
        private M_Connexion mdpoc;
        public MDPO()
        {
            InitializeComponent();
            mdpoc = new M_Connexion();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mdpoc.Usernameo = textBox1.Text;
            mdpoc.Email = textBox2.Text;
            mdpoc.Update();
            mdpoc.SendMDPO();
            MessageBox.Show("Email envoyé!");
        }
    }
}
