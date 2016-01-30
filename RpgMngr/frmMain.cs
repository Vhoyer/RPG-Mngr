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
        OpenFileDialog ofd = new OpenFileDialog()
        {
            Filter = "RpgMngr! file| *.rmgd"
        };

        public frmMain()
        {
            InitializeComponent();
        }

        public void load_Recent()
        {
            string[] recents = files.GetRecentRmgdFiles();
            //ToolStripItem[] itens = new ToolStripItem[recents.Length];
            List<ToolStripItem> itens = new List<ToolStripItem>();
            //itens[0] = new ToolStripMenuItem("Nenhum arquivo recente...");
            for (int i = 0; i < recents.Length ; i++)
            {
                try
                {
                    itens.Add(new ToolStripMenuItem(recents[i].Split('=')[0], null, tsmiRecentC_Click, recents[i].Split('=')[1]));
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
            tsmiRecentC.DropDownItems.Clear();
            if (itens.Count > 0)
            {
                ToolStripItem[] itensMenu = new ToolStripItem[itens.Count];
                for (int i = 0; i < itensMenu.Length; i++)
                {
                    itensMenu[i] = itens[i];
                }
                tsmiRecentC.DropDownItems.AddRange(itensMenu);
            }
            else
            {
                tsmiRecentC.DropDownItems.Add(new ToolStripMenuItem("Nenhum arquivo recente..."));
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OpenRmgd table = new OpenRmgd();
            cbSistema.DataSource = table.SystemsSupported;
            cbSistema.DisplayMember = "System_Name";
            cbSistema.ValueMember = "System_Id";
            //
            load_Recent();
        }

        private void tsmiRecentC_Click(object sender, EventArgs e)
        {
            OpenRmgd open = new OpenRmgd((sender as ToolStripMenuItem).Name, this);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (!utilitiesMngr.isFieldsEmpty(new object[] { txtNomeMesa, cbSistema }))
            {
                WriteRmgd write = new WriteRmgd(txtNomeMesa.Text);
                write.editTable(write.CampaignTable.TableName, "campaignName", txtNomeMesa.Text);
                write.editTable(write.CampaignTable.TableName, "rpgSystem", cbSistema.SelectedValue);

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

        private void tsmiRecentC_DropDownOpening(object sender, EventArgs e)
        {
            load_Recent();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
        }
    }
}
