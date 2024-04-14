using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.View
{
    public partial class Form1 : Form
    {
        Evenement evenm = new Evenement();
        DatabaseContext db = new DatabaseContext();
        private IEvenementRepository evenRep;
        public static int id = -1;
        public Form1()
        {
            InitializeComponent();
           evenRep = new EventRepository(db);



        }
       
        private void insert_Click(object sender, EventArgs e)
        {
            Evenement evenm = new Evenement();
            evenm.date = tdate.Value;
            evenRep.Add(evenm);
            loadDataEvent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataEvent();
        }

        private void loadDataEvent()
        {
            var evenements = evenRep.GetAll();
           dataGridView1.DataSource = evenements;

        }

        private void insert_Click_1(object sender, EventArgs e)
        {
            evenm.date = tdate.Value;

            // Ajouter l'objet Evenement à votre repository ou service
            evenRep.Add(evenm);

            // Recharger les données des événements
            loadDataEvent();
            MessageBox.Show("L'evenement a ete ajouter avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void update_Click(object sender, EventArgs e)
        {
           
            if (id > 0)
            {
               
                try
                {
                    Evenement evenm = db.Evenements.Where(m => m.Id == id).SingleOrDefault();

                    evenm.date = tdate.Value;
                    evenRep.Update(evenm);
                    loadDataEvent();
                    MessageBox.Show("L'evenement a ete modifie avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Votre code pour sauvegarder les données dans la base de données
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


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                      id = (int) selectedRow.Cells["id"].Value;
                    string date = selectedRow.Cells["date"].Value.ToString();
                    DateTime datevalue;
                    if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out datevalue))
                    {
                        tdate.Value = datevalue;

                    }
                    else
                    {
                        MessageBox.Show(date, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            
            if (id > 0)
            {
                DialogResult res = MessageBox.Show("Vous etes sure", "MessageConfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res== DialogResult.Yes)
                {
                    try
                    {
                        Evenement evenm = db.Evenements.Find(id);

                        evenRep.Remove(evenm);
                        loadDataEvent();
                        MessageBox.Show("L'evenement a  ete supprmer avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("L'evenement n'a pas ete supprmer avec succes !!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
              
            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuGestion form = new MenuGestion();
            form.Show();
            this.Hide();
        
        }
    }
}
