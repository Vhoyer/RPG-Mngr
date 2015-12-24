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
        public static string Mesas;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Mesas = DirMngr.Dir + @"Mesas\";
            DirMngr dir = new DirMngr(Mesas, DirMngr.Dirt.folder);
        }
    }
}
