using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpgMngr.Mngrs;

namespace RpgMngr
{
    public partial class frmMain : Form
    {
        enum systems
        {
            Dnd3dot5 = 0 
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (!interfaceMngr.isFieldsEmpty(new object[] { txtNomeMesa, cbSistema }))
            {
                WriteRmgd rmgd = new WriteRmgd(txtNomeMesa.Text);
                rmgd.Campaign.LoadDataRow(new object[] { "campaingName", txtNomeMesa.Text }, LoadOption.PreserveChanges);
                rmgd.writeEverthig();
            }
            else
            {
                MessageBox.Show("Favor preencha todos os campos", "Campos vazios");
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void abrirMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenRmgd rmgd = new OpenRmgd(ofd.FileName);
                dataGridView1.DataSource = rmgd.Campaign;
            }
        }
    }
}
