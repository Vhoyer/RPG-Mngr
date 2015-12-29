using System;
using Mngrs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpgMngr.file_types;

namespace RpgMngr
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OpenRmgd table = new OpenRmgd();
            cbSistema.DataSource = table.SystemsSupported;
            cbSistema.DisplayMember = "System_Name";
            cbSistema.ValueMember = "System_Id";
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (!interfaceMngr.isFieldsEmpty(new object[] { txtNomeMesa, cbSistema }))
            {
                WriteRmgd write = new WriteRmgd(txtNomeMesa.Text);
                write.editTable(write.CampaignTable.TableName, "campaingName", txtNomeMesa.Text);
                write.editTable(write.CampaignTable.TableName, "rpgSystem", cbSistema.SelectedValue);
                write.editTable(write.CampaignTable.TableName, "lastPlayed", DateTime.Now.ToUniversalTime());

                write.writeEverthig();
                OpenRmgd open = new OpenRmgd(write.CampaignRmgd, this);
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
                OpenRmgd rmgd = new OpenRmgd(ofd.FileName, this);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
