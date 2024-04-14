using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository.ChercheurR;
using ControleCodeFirst.Repository.LieuR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.View
{
    public partial class ChercheurFor : Form
    {
        Chercheur chercheur = new Chercheur();
        DatabaseContext db = new DatabaseContext();
        private IChercheurRepository cherchRep;
        public static int id = -1;
        public ChercheurFor()
        {
            InitializeComponent();
            cherchRep = new ChercheurRepository(db);
        }

        private void ChercheurFor_Load(object sender, EventArgs e)
        {
            loadDataEvent();
        }
        private void loadDataEvent()
        {
            var chercheurs = cherchRep.GetAll();
            dataGridView1.DataSource = chercheurs;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = textBox1.Text;
                string prenom = textBox2.Text;
                string email = textBox3.Text;

                // Créer une nouvelle instance de Chercheur avec les données saisies
                Chercheur chercheur = new Chercheur(nom, prenom, email);

                // Ajouter le chercheur à votre repository ou service
                cherchRep.Add(chercheur);

                // Sauvegarder les changements dans la base de données
                db.SaveChanges();

                // Recharger les données des chercheurs
                loadDataEvent();

                MessageBox.Show("Chercheur ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbEntityValidationException ex)
            {
                // Parcourir les erreurs de validation pour obtenir des détails
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }

                // Afficher un message d'erreur générique en cas d'échec de la validation
                MessageBox.Show("Une erreur de validation s'est produite lors de l'ajout du chercheur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur générique en cas d'échec de l'ajout du chercheur pour d'autres raisons
                MessageBox.Show("Une erreur s'est produite lors de l'ajout du chercheur: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                Chercheur chercheur = db.Chercheurs.Where(m => m.ChercheurId == id).SingleOrDefault();

                chercheur.Nom = textBox1.Text;
                chercheur.Prenom = textBox2.Text;
                chercheur.Email = textBox3.Text;
                cherchRep.Update(chercheur);
                loadDataEvent();
                MessageBox.Show("Le chercheur a ete modifie avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DialogResult res = MessageBox.Show("Vous etes sure", "MessageConfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        Chercheur chercheur = db.Chercheurs.Find(id);

                        cherchRep.Remove(chercheur);
                        loadDataEvent();
                        MessageBox.Show("Le chercheur  a  ete supprmer avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Le chercheur n'a pas ete supprmer avec succes !!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    id = (int)selectedRow.Cells["ChercheurId"].Value;

                    string Nom = selectedRow.Cells["Nom"].Value.ToString();
                    textBox1.Text = Nom;

                    string Prenom = selectedRow.Cells["Prenom"].Value.ToString();
                    textBox2.Text = Prenom;
                    string Email = selectedRow.Cells["Email"].Value.ToString();
                    textBox3.Text = Email;




                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu_de_Gestion_des_chercheurs form = new Menu_de_Gestion_des_chercheurs();
            form.Show();
            this.Hide();
        }
    }
}
