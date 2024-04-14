using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleCodeFirst.View
{
    public partial class Menu_de_Gestion_des_chercheurs : Form
    {
        public Menu_de_Gestion_des_chercheurs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChercheurFor form = new ChercheurFor();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChercheurPollEventF form = new ChercheurPollEventF();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuGestion form = new MenuGestion();
            form.Show();
            this.Hide();
        }
    }
}
