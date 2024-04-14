using ControleCodeFirst.Modele;
using ControleCodeFirst.Repository.LieuR;
using ControleCodeFirst.Repository.PollutionDataR;
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
    public partial class PollutionDataF : Form
    {
        PollutionData pollutionData = new PollutionData();
        DatabaseContext db = new DatabaseContext();
        private IPollutionDataRepository DataRep;
        public static int id = -1;


        public PollutionDataF()
        {
            InitializeComponent();
            DataRep = new PollutionDataRepository(db);
        }



        private void PollutionData_Load(object sender, EventArgs e)
        {
            loadDataEvent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PollutionData p = new PollutionData();
            p.Date = tdate.Value;
            p.NivPollution = textBox1.Text;

            DataRep.Add(p);
            loadDataEvent();
            MessageBox.Show("Les information  a ete ajouter avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void loadDataEvent()
        {
            var pollutionDatas = DataRep.GetAll();
            dataGridView1.DataSource = pollutionDatas;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                PollutionData p = db.PollutionDatas.Where(m => m.Id == id).SingleOrDefault();

                p.Date = tdate.Value;
                p.NivPollution = textBox1.Text;
                DataRep.Update(p);
                loadDataEvent();
                MessageBox.Show("Les information de pollution ont ete modifie avec succes !!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                    string date = selectedRow.Cells["date"].Value.ToString();
                    string NivPollution = selectedRow.Cells["NivPollution"].Value.ToString();
                    textBox1.Text = NivPollution;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DialogResult res = MessageBox.Show("Vous etes sure", "MessageConfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        PollutionData p = db.PollutionDatas.Find(id);

                        DataRep.Remove(p);
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

        private void button4_Click(object sender, EventArgs e)
        {
            MenuGestion form = new MenuGestion();
            form.Show();
            this.Hide();
        }
    }
}

