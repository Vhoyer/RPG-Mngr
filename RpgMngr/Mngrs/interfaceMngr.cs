using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMngr.Mngrs
{
    class interfaceMngr
    {
        public bool isFieldsEmpty(object[] fields)
        {
            System.Windows.Forms.TextBox[] txts = (fields as System.Windows.Forms.TextBox[]);

            foreach (System.Windows.Forms.TextBox txt in txts)
            {
                if (txt.Text == "")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
