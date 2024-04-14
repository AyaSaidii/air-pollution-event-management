using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ControleCodeFirst.View
{
    public partial class LoginForm : Form
    {
       
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Définir la commande SQL
            string sqlQuery = "SELECT * FROM Login WHERE username=@username AND pass=@pass";
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDPol;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox4.Text;

            // Définir la commande de sélection pour l'adaptateur de données
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // Remplir le DataTable avec les données
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Vérifier si des données ont été retournées
            if (table.Rows.Count == 1)
            {
                // Les informations d'identification sont correctes, ouvrir la nouvelle forme
                Menu form = new Menu();
                form.Show();
                this.Hide();
            }
            else
            {
                // Afficher un message d'erreur si les informations d'identification sont incorrectes
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
