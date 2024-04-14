using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository;
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
    public partial class LieuForm : Form
    {
        Lieu lieu = new Lieu();
        DatabaseContext db = new DatabaseContext();
        private ILieuRepository lieuRep;
        public static int id = -1;


        public LieuForm()
        {
            InitializeComponent();
            lieuRep = new LieuRepository(db);
        }



        private void Lieu_Load(object sender, EventArgs e)
        {
            loadDataEvent();
        }
        private void loadDataEvent()
        {
            var lieus = lieuRep.GetAll();
            dataGridView1.DataSource = lieus;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adresse = textBox1.Text;
            string ville = textBox2.Text;
            Lieu l = new Lieu(adresse, ville);
            lieuRep.Add(l);
            loadDataEvent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    id = (int)selectedRow.Cells["id"].Value;

                    string ville = selectedRow.Cells[1].Value.ToString();
                    textBox2.Text = ville;

                    string Adresse = selectedRow.Cells[2].Value.ToString();
                    textBox1.Text = Adresse;




                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                  try
                {
                    Lieu lieu = db.Lieus.Where(m => m.Id == id).SingleOrDefault();

                    lieu.adresse = textBox1.Text;
                    lieu.ville = textBox2.Text;
                    lieuRep.Update(lieu);
                    loadDataEvent();
                    MessageBox.Show("Le lieu a ete modifie avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    db.SaveChanges();
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
                }

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
                        Lieu lieu = db.Lieus.Find(id);

                        lieuRep.Remove(lieu);
                        loadDataEvent();
                        MessageBox.Show("Le lieu  a  ete supprimer avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Le lieu n'a pas ete supprimer avec succes !!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuGestion form = new MenuGestion();
            form.Show();
            this.Hide();
        }
    }
}
