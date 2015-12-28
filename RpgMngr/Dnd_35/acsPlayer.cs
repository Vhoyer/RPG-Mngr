using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMngr.Dnd_35
{
    public class acsPlayer
    {
        DataTable table;
        //System.IO.StreamReader reader;

        public acsPlayer()
        {

        }

        private void loadTable()
        {

        }

        //
        // Proprieties
        //
        public DataTable Table
        {
            get
            {
                return table;
            }

            set
            {
                table = value;
            }
        }
    }
}
