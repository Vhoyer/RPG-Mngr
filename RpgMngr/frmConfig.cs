using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgMngr
{
    public partial class frmConfig : Form
    {
        Mngrs.ConfigMngr config;

        public frmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            List<DataTable> tables = new List<DataTable>()
            {
                Mngrs.ConfigMngr.DatatableModel("Load/Save")
            };
            config = new Mngrs.ConfigMngr(tables);
            //
            // load
            //
            checkNull(txtCdp, "CampaignDefaultPath", file_types.WriteRmgd.DefaultCampaignsPath);
        }

        private void checkNull(Control ct, string field, string defaultValue)
        {
            ct.Text = config.valueofTable(field);
            if (ct.Text == null)
            {
                ct.Text = defaultValue;
            }
        }

        private void trvCmenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeCollection nodes = trvMenu.Nodes;
            if (nodes[0].IsSelected)
            {

            }
            else if (nodes[1].IsSelected)
            {

            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            config.EditOrAddToTable("Load/Save", "CampaignDefaultPath", txtCdp.Text);

            config.writeOnFile();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            btnAplicar_Click(sender, e);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtCdp.Text = fbd.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
