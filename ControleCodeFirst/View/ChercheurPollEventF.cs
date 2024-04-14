using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository;
using ControleCodeFirst.Repository.ChercheurPEvent;
using ControleCodeFirst.Repository.ChercheurR;
using ControleCodeFirst.Repository.CherchPollutionEventPEvent;
using ControleCodeFirst.Repository.LieuR;
using ControleCodeFirst.Repository.PollutionDataR;
using ControleCodeFirst.Repository.PollutionEvenementR;
using ControleCodeFirst.Repository.PollutionPollutionEvenementR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleCodeFirst.View
{
    public partial class ChercheurPollEventF : Form
    {
        PollutionEvenement pollEvent = new PollutionEvenement();

        DatabaseContext db = new DatabaseContext();
        private IPollutionEventRepository pollEvRep;
        private IChercheurRepository cherchRep;
        private IChercheurEventPRepository chercheventRep;
        public static int id = -1;

        public ChercheurPollEventF()
        {
            InitializeComponent();
            pollEvRep = new PollutionEventRepository(db);
            cherchRep = new ChercheurRepository(db);
            chercheventRep = new ChercheurEventPRepository(db);


        }
        private void loadDataEvent()
        {
            var cherpollut = chercheventRep.GetAll();
            dataGridView1.DataSource = cherpollut;

        }
        private void loadChercheur()
        {
            comboBox1.DataSource = cherchRep.GetAll().ToList();
            comboBox1.DisplayMember = "Nom";
            comboBox1.ValueMember = "ChercheurId";

        }
        private void loadPollutionEvent()
        {
            comboBox2.DataSource = pollEvRep.GetAll().ToList();
            comboBox2.DisplayMember = "nom";
            comboBox2.ValueMember = "Id";

        }
        private void ChercheurPollEventF_Load(object sender, EventArgs e)
        {
            loadDataEvent();
            loadChercheur();
            loadPollutionEvent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CherchPollutionEvent p = new CherchPollutionEvent
                {
                    solution = textBox1.Text,
                    ChercheurId = (int)comboBox1.SelectedValue,
                    PollutEventId = (int)comboBox2.SelectedValue,
                };
                chercheventRep.Add(p);
                loadDataEvent();
                MessageBox.Show("La solution que le chercheur a proposee a ete ajoute avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                CherchPollutionEvent p = db.CherchPollutionEvents.Where(m => m.Id == id).SingleOrDefault();

                p.solution = textBox1.Text;
                p.ChercheurId = (int)comboBox1.SelectedValue;
                p.PollutEventId = (int)comboBox2.SelectedValue;

                chercheventRep.Update(p);
                loadDataEvent();
                MessageBox.Show("La solution que le chercheur a proposee a ete modifie avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                        CherchPollutionEvent p = db.CherchPollutionEvents.Find(id);

                        chercheventRep.Remove(p);
                        loadDataEvent();
                        MessageBox.Show("La solution propose par le chercheur  a ete bien supprimer avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("La solution propose par le chercheur n'a pas ete supprimer avec succes !!", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    id = (int)selectedRow.Cells["id"].Value;

                    string solution = selectedRow.Cells["solution"].Value.ToString();
                    textBox1.Text = solution;

                    



                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu_de_Gestion_des_chercheurs form = new Menu_de_Gestion_des_chercheurs();
            form.Show();
            this.Hide();
        }
    }
}
