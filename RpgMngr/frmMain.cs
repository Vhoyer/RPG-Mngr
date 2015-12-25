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
        interfaceMngr face = new interfaceMngr();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DirMngr dir = new DirMngr(TableMngr.TablesPath, DirMngr.Dirt.folder);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (!face.isFieldsEmpty(new object[] { txtNomeMesa, cbSistema }))
            {
                DirMngr dir = new DirMngr(TableMngr.TablesPath + txtNomeMesa.Text, DirMngr.Dirt.folder);
                TableMngr mesa = new TableMngr()
                {
                    TableName = txtNomeMesa.Text,
                    Rpgsystem = cbSistema.Text,
                    Lastplayed = DateTime.Now.Date.ToShortDateString()
                };

                MessageBox.Show("Mesa Criada com sucesso.", "Mesa");
                Dnd_35.frmDnd frm = new Dnd_35.frmDnd();
                frm.Show();
                this.Hide();
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
    }
}
