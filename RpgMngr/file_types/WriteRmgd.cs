using System;
using System.Data;
using System.Collections.Generic;
using Mngrs;

namespace RpgMngr.file_types
{
    /// <summary>
    /// Abre ou cria uma mesa e seus arquivos
    /// </summary>
    class WriteRmgd
    {
        static string defaultCampaignsPath = DirMngr.Dir + @"Campanhas\";
        DirMngr dir;
        List<string> file = new List<string>();
        DataTable paramCampaign;
        List<DataTable> tables = new List<DataTable>();
        //
        string campaignName = "",
            campaignPath = "",
            document;
        /// <summary>
        /// cria a pasta e o arquivo .rmgd e monta as tabelas
        /// </summary>
        /// <param name="campaignName"></param>
        public WriteRmgd(string campaignName)
        {
            List<DataTable> tables = new List<DataTable>()
            {
                ConfigMngr.DatatableModel("Load/Save")
            };
            ConfigMngr config = new ConfigMngr(tables);
            if (config.valueofTable("CampaignDefaultPath") != null)
            {
                defaultCampaignsPath = config.valueofTable("CampaignDefaultPath");
            }

            this.campaignName = campaignName;
            campaignPath = defaultCampaignsPath + campaignName + @"\";
            document = campaignName + ".rmgd";
            dir = new DirMngr(campaignPath + campaignName + ".rmgd");
            MontTables();
        }

        /// <summary>
        /// monta as tabelasbaseadas nas mesmas do openRmgd
        /// </summary>
        private void MontTables()
        {
            OpenRmgd rmgd = new OpenRmgd(campaignPath + campaignName + ".rmgd");
            CampaignTable = rmgd.CampaignTable;
            tables.Add(CampaignTable);
        }

        /// <summary>
        /// converte os valores de tabelas com duas colunas para uma lista. No formato: 'coluna1=coluna2'
        /// </summary>
        /// <param name="dt">tablea</param>
        /// <param name="lst">lista de retorno</param>
        private void TableToList(DataTable dt, out List<string> lst)
        {
            lst = new List<string>();
            lst.Add("[" + dt.TableName.ToUpper() + "]");

            foreach (DataRow row in dt.Rows)
            {
                lst.Add(row[0] + "=" + row[1]);
            }
        }

        /// <summary>
        /// escreve todos os valores das tabelas no arquivo
        /// </summary>
        public void writeEverthig()
        {
            file = new List<string>();
            file.Add(RpgMngr.Properties.Resources.file_version);
            List<string> temp;

            foreach (DataTable item in tables)
            {
                TableToList(item, out temp);
                file.AddRange(temp);
            }
            ////table: Campaign
            //TableToList(Campaign, out temp);
            //file.AddRange(temp);

            List<string> Encrypted = new List<string>();
            foreach (string str in file)
            {
                Encrypted.Add(CryptMngr.Encrypt(str));
            }

            dir.Overwrite(Encrypted);
        }

        /// <summary>
        /// Edita um valor de uma tabela específica
        /// </summary>
        /// <param name="tableName">tabela específica</param>
        /// <param name="paramName">nome do valor pelo procurar</param>
        /// <param name="newValue">novo valor a ser a tribuído a determinado campo</param>
        /// <returns>true se achar false se não achar</returns>
        public bool editTable(string tableName, string paramName, object newValue)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tableName == tables[i].TableName)
                {
                    for (int o = 0; o < tables[i].Rows.Count; o++)
                    {
                        if (tables[i].Rows[o][0].ToString() == paramName)
                        {
                            tables[i].Rows[o][1] = newValue;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Edita um específico de uma das tabelas da classe tabela
        /// </summary>
        /// <param name="paramName">nome do valor pelo procurar</param>
        /// <param name="newValue">novo valor a ser a tribuído a determinado campo</param>
        /// <returns>true se achar false se não achar</returns>
        public bool editTable(string paramName, object newValue)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                for (int o = 0; o < tables[i].Rows.Count; o++)
                {
                    if (tables[i].Rows[o][0].ToString() == paramName)
                    {
                        tables[i].Rows[o][1] = newValue;
                        return true;
                    }
                }
            }
            return false;
        }

        //
        // Propriedades
        //
        public DataTable CampaignTable
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
        public static string DefaultCampaignsPath
        {
            get { return defaultCampaignsPath; }
        }
        public string CampaignRmgd
        {
            get { return campaignPath + document; }
        }
    }
}
