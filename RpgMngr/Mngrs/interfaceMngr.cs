using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mngrs
{
    public class interfaceMngr
    {
        public static bool isFieldsEmpty(object[] fields)
        {
            System.Windows.Forms.TextBox[] txts = new System.Windows.Forms.TextBox[fields.Length - 1];
            for (int i = 0; i < fields.Length - 1; i++)
            {
                txts[i] = (fields[i] as System.Windows.Forms.TextBox);
            }

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
