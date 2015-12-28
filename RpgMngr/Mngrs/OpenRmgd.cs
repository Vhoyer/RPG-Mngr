using System;
using System.Data;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RpgMngr.Mngrs
{
    public class OpenRmgd
    {
        string campaignsPath = DirMngr.Dir + @"Mesas\";
        int index;
        DirMngr dir;
        List<string> file = new List<string>();
        DataTable paramCampaign;


        public OpenRmgd(string path)
        {
            MontTables();
            dir = new DirMngr(path);
            List<string> Encrypted = new List<string>(), file = new List<string>();
            Encrypted.AddRange(dir.ReadAll());

            foreach (string str in Encrypted)
            {
                file.Add(CryptMngr.Decrypt(str));
            }
            this.file.AddRange(file);

            LoadConfig();
        }

        #region "TablesSpawn"
        private void MontTables()
        {
            MontCampaign();
        }
        public void MontCampaign()
        {
            paramCampaign = new DataTable("Campaign");
            paramCampaign.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ParamName", typeof(string)),
                new DataColumn("ParamValue", typeof(object))
            });

            paramCampaign.Rows.Add("rpgSystem", null);
            paramCampaign.Rows.Add("lastPlayed", null);
            paramCampaign.Rows.Add("campaingName", null);
        }
        #endregion

        #region "private methods"
        /// <summary>
        /// Faz a mesma função do "indexOf", fiz pq não sabia que existia... MAS também retorna o valor do parametro
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private string Find(string Search, string searchField)
        {
            int start = 0, end = file.Count;
            bool canStop = false;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Split('=')[0] == "[" + searchField.ToUpper() + "]")
                {
                    start = i;
                    canStop = true;
                }
                if (file[i].Split('=')[0].StartsWith("[") && canStop)
                {
                    end = i;
                    break;
                }
            }

            for (int i = start; i < end; i++)
            {
                if (file[i].Split('=')[0] == Search)
                {
                    index = i;
                    return file[i].Split('=')[1];
                }
            }
            return null;
        }
        /// <summary>
        /// retorna uma lista com as linhas de só um campo
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private List<string> breakFile(string breakInField)
        {
            List<string> retorno = new List<string>();
            int start = 0, end = file.Count;
            bool canStop = false, found = false;

            for (int i = 0; i < file.Count; i++)
            {
                if (file[i].Split('=')[0] == "[" + breakInField.ToUpper() + "]")
                {
                    start = i;
                    canStop = true;
                    found = true;
                }
                if (file[i].Split('=')[0].StartsWith("[") && canStop)
                {
                    end = i;
                    break;
                }
            }
            if (found)
            {
                for (int i = start; i < end; i++)
                {
                    retorno.Add(file[i]);
                }
                return retorno;
            }

            return null;
        }
        /// <summary>
        /// Retorna uma tabela com os valores de um campo do arquivo
        /// </summary>
        /// <param name="dt"></param>
        private void loadTable(ref DataTable dt)
        {
            List<string> lst = new List<string>();
            if (breakFile(dt.TableName) != null)
            {
                lst.AddRange(breakFile(dt.TableName));
            }
            foreach (string item in lst)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (item.Split('=')[0] == dt.Rows[i][0].ToString())
                    {
                        dt.Rows[i][1] = item.Split('=')[1];
                    }
                }
            }
        }
        #endregion

        #region "Configs"
        /// <summary>
        /// Loada o arquivo e carrega os parametros do arquivo nos parametros da classe
        /// </summary>
        public void LoadConfig()
        {
            loadTable(ref paramCampaign);
        }
        #endregion

        public DataTable Campaign
        {
            get { return paramCampaign; }
        }
        public List<string> File
        {
            get { return file; }
        }
    }
}
