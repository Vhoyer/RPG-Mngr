using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgMngr.Dnd_35
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string campaignName)
        {
            InitializeComponent();
            this.Text = "RpgMngr!- D&D 3.5 - " + campaignName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBattle frm = new frmBattle();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmCreatePlayer();
            frm.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void voltarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Close();
            }
            else
            {
                RpgMngr.frmMain frm = new RpgMngr.frmMain();
                this.Hide();
                frm.Show();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }
    }
}
