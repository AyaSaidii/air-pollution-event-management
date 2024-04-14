using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository;
using ControleCodeFirst.Repository.LieuR;
using ControleCodeFirst.Repository.PollutionDataR;
using ControleCodeFirst.Repository.PollutionEvenementR;
using ControleCodeFirst.Repository.PollutionPollutionEvenementR;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Runtime.Remoting.Contexts;

namespace ControleCodeFirst.View
{
    public partial class PollutEventF : Form
    {
        PollutionEvenement pollEvent = new PollutionEvenement();

        DatabaseContext db = new DatabaseContext();
        private IPollutionEventRepository pollEvRep;
        private ILieuRepository lieuRepository;
        private IEvenementRepository evenementRepository;
        private IPollutionDataRepository dataRepository;

        public static int id = -1;
        public PollutEventF()
        {
            InitializeComponent();
            pollEvRep = new PollutionEventRepository(db);
            lieuRepository = new LieuRepository(db);
            evenementRepository = new EventRepository(db);
            dataRepository = new PollutionDataRepository(db);


        }

        private void PollutEventF_Load(object sender, EventArgs e)
        {
            loadLieus();
            loadData();
            loadDataEvent();
        }
        private void loadLieus()
        {
            comboBox1.DataSource = lieuRepository.GetAll().ToList();
            comboBox1.DisplayMember = "ville";
            comboBox1.ValueMember = "Id";

        }

        private void loadData()
        {
            comboBox3.DataSource = lieuRepository.GetAll().ToList();
            comboBox3.DisplayMember = "adresse";
            comboBox3.ValueMember = "Id";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
               


            try
            {
                PollutionEvenement p = new PollutionEvenement
                {
                    nom = textBox1.Text,
                    cause = textBox2.Text,
                    LieuId = (int)comboBox1.SelectedValue,

                    DataId = (int)comboBox3.SelectedValue,
                    date = tdate.Value,



                    /*  evenm.date = tdate.Value;
                     EvenementId = (int)comboBox3.SelectedValue,*/

                };
                pollEvRep.Add(p);
                loadDataEvent();

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
        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
               
                try
                {
                    PollutionEvenement p = db.PollutionEvenements.Where(m => m.Id == id).SingleOrDefault();

                    p.nom = textBox1.Text;
                    p.cause = textBox2.Text;
                    p.LieuId = (int)comboBox1.SelectedValue;

                    p.DataId = (int)comboBox3.SelectedValue;
                    p.date = tdate.Value;
                    pollEvRep.Update(p);
                    loadDataEvent();
                    MessageBox.Show("Les information de l'evenement  pollution ont ete modifie avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        PollutionEvenement p = db.PollutionEvenements.Find(id);

                        pollEvRep.Remove(p);
                        loadDataEvent();
                        MessageBox.Show("L'information a ete bien supprimer avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("L'information n'a pas ete supprimer avec succes !!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        } 
        private void loadDataEvent()
        {
            var pollutEve = pollEvRep.GetAll();
            dataGridView1.DataSource = pollutEve;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    id = (int)selectedRow.Cells["id"].Value;

                    string nom = selectedRow.Cells["nom"].Value.ToString();
                    textBox1.Text = nom;

                    string cause = selectedRow.Cells["cause"].Value.ToString();
                    textBox2.Text = cause;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }
    }
}
