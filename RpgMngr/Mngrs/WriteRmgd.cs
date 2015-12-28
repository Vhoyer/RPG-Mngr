using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RpgMngr.Mngrs
{
    /// <summary>
    /// Abre ou cria uma mesa e seus arquivos
    /// </summary>
    class WriteRmgd
    {
        string campaignsPath = DirMngr.Dir + @"Mesas\";
        DirMngr dir;
        List<string> file = new List<string>();
        DataTable paramCampaign;
        //
        string campaignName = "",
            campaignPath = "";

        public WriteRmgd(string campaignName)
        {
            this.campaignName = campaignName;
            campaignPath = campaignsPath + campaignName + @"\";
            dir = new DirMngr(campaignPath + campaignName + ".rmgd");
            MontTables();
        }

        private void MontTables()
        {
            OpenRmgd rmgd = new OpenRmgd(campaignPath + campaignName + ".rmgd");
            Campaign = rmgd.Campaign;
        }

        private void TableToList(DataTable dt, out List<string> lst)
        {
            lst = new List<string>();
            lst.Add("[" + dt.TableName.ToUpper() + "]");

            foreach (DataRow row in dt.Rows)
            {
                lst.Add(row[0] + "=" + row[1]);
            }
        }

        public void writeEverthig()
        {
            file.Add(RpgMngr.Properties.Resources.file_version);
            List<string> temp;
            TableToList(Campaign, out temp);
            file.AddRange(temp);

            List<string> Encrypted = new List<string>();
            foreach (string str in file)
            {
                Encrypted.Add(CryptMngr.Encrypt(str));
            }

            dir.overwrite(Encrypted);
        }

        //
        // Propriedades
        //

        public DataTable Campaign
        {
            get
            {
                return paramCampaign;
            }

            set
            {
                paramCampaign = value;
            }
        }
    }
}
