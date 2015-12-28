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
    public partial class frmCreatePlayer : Form
    {
        public frmCreatePlayer()
        {
            InitializeComponent();
            dataGridView1.DataSource = playersDefaultTables.periaciaTable();
            dataGridView2.DataSource = playersDefaultTables.equipamentoTable();
        }
    }
}
