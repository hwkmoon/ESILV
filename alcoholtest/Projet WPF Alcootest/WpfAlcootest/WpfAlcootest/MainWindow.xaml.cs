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
using System.Data.SQLite;

namespace WpfAlcootest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculA calcul;

        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            calcul = new CalculA();
            listView.ItemsSource = calcul;
            calcul.actualiser();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            calcul.ValeurTextBox1 = textBoxNom.Text;
            calcul.ValeurTextBox2 = textBoxPrenom.Text;
            calcul.CheckBox1 = checkBoxM.IsChecked.Value;
            calcul.CheckBox2 = checkBoxF.IsChecked.Value;
            calcul.ValeurTextBox3 = textBoxPoids.Text;
            calcul.CheckBox3 = checkBoxOui.IsChecked.Value;
            calcul.CheckBox4 = checkBoxNon.IsChecked.Value;
            calcul.ValeurTextBox4 = textBoxNumero.Text;
            calcul.ValeurTextBox5 = textBoxVille.Text;
            calcul.ValeurTextBox6 = textBoxPremiere.Text;
            calcul.ValeurTextBox7 = textBoxDerniere.Text;
            calcul.ValeurTextBox8 = textBoxBiere.Text;
            calcul.ValeurTextBox9 = textBoxBiereL.Text;
            calcul.ValeurTextBox10 = textBoxVin.Text;
            calcul.ValeurTextBox11 = textBoxSpiritueux.Text;
            if (calcul.ChampVide() == false)
            {
                MessageBox.Show("Un ou plusieurs champs sont vides ou vous avez coché une fois de trop!");
                return;
            }
            else if(calcul.DureeNegative()==false)
            {
                MessageBox.Show("La durée entre vos consammations est négatif");
                return;
            }
            else if (calcul.CheckType()==true)
            {
                MessageBox.Show("Veuillez rentrer votre poids correctement!");
                return;
            }
            else
            {
                if (calcul.Sam() == "Oui")
                {
                    if (calcul.ChampVide2()==false)
                    {
                        MessageBox.Show("Un ou plusieurs champs sont vides ou vous avez coché une fois de trop!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vous ne serez pas SAM !");
                }
                label8.Content = Convert.ToString(calcul.Alcoolemie());
                label13.Content = calcul.TempsR();
                if (calcul.Alcoolemie() >= 0.08)
                {
                    label10.Content = "Vous ne devez pas conduire";
                    label10.Background = Brushes.Red;
                }
                else if (calcul.Alcoolemie() < 0.08 && calcul.Alcoolemie() > 0.05)
                {
                    label10.Content = "Risque élevé, soyez prudent";
                    label10.Background = Brushes.Yellow;
                }
                else if (calcul.Alcoolemie() <= 0.05)
                {
                    label10.Content = "Pas de problèmes";
                    label10.Background = Brushes.Green;
                }
                listView.ItemsSource = calcul;
                calcul.Ajouter();
                calcul.actualiser();
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            int numeB;
            if (textBoxBiere.Text=="0")
            {
                numeB = 0;
            }
            else
            {
                numeB = Int32.Parse(textBoxBiere.Text);
            }   
            numeB += 1;
            textBoxBiere.Text = Convert.ToString(numeB);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            int numeBL;
            if (textBoxBiereL.Text == "0")
            {
                numeBL = 0;
            }
            else
            {
                numeBL = Int32.Parse(textBoxBiereL.Text);
            }
            numeBL += 1;
            textBoxBiereL.Text = Convert.ToString(numeBL);
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            int numeV;
            if (textBoxVin.Text == "0")
            {
                numeV = 0;
            }
            else
            {
                numeV = Int32.Parse(textBoxVin.Text);
            }
            numeV += 1;
            textBoxVin.Text = Convert.ToString(numeV);
        }


        private void button_Copy2_Click_1(object sender, RoutedEventArgs e)
        {
            int numeS;
            if (textBoxSpiritueux.Text == "0")
            {
                numeS = 0;
            }
            else
            {
                numeS = Int32.Parse(textBoxSpiritueux.Text);
            }
            numeS += 1;
            textBoxSpiritueux.Text = Convert.ToString(numeS);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;


            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = "DELETE from listeF ;";

            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            listView.ItemsSource = null;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int numeP;
            if (textBoxPremiere.Text == "0")
            {
                numeP = 0;
            }
            else
            {
                numeP = Int32.Parse(textBoxPremiere.Text);
            }
            numeP += 1;
            textBoxPremiere.Text = Convert.ToString(numeP);
        }

        private void button4_Copy_Click(object sender, RoutedEventArgs e)
        {
            int numeD;
            if (textBoxDerniere.Text == "0")
            {
                numeD = 0;
            }
            else
            {
                numeD = Int32.Parse(textBoxDerniere.Text);
            }
            numeD += 1;
            textBoxDerniere.Text = Convert.ToString(numeD);
        }

        private void button4_Copy1_Click(object sender, RoutedEventArgs e)
        {
            int numeP = Int32.Parse(textBoxPremiere.Text);
            if (textBoxPremiere.Text != "0")
            {
                numeP -= 1;
            }
            else
            {
                numeP = 0;
            }
            textBoxPremiere.Text = Convert.ToString(numeP);
        }

        private void button4_Copy2_Click(object sender, RoutedEventArgs e)
        {
            int numeD = Int32.Parse(textBoxDerniere.Text);
            if (textBoxDerniere.Text != "0")
            {
                numeD -= 1;
            }
            else
            {
                numeD = 0;
            }
            textBoxDerniere.Text = Convert.ToString(numeD);
        }
    }
}
