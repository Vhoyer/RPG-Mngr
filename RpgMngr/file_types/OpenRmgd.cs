using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Mngrs;

namespace RpgMngr.file_types
{
    public class OpenRmgd
    {
        DirMngr dir;
        List<string> file = new List<string>();
        DataTable paramCampaign, systemsSupported;
        List<DataTable> tables = new List<DataTable>();

        public OpenRmgd(string path)
        {
            MountTables();
            dir = new DirMngr(path);
            LoadConfig();
        }

        public OpenRmgd(string path, bool runApp)
        {
            MountTables();
            dir = new DirMngr(path);
            LoadConfig();

            if (runApp)
            {
                Form frm = returnForm();
                Application.Run(frm);
            }
        }

        public OpenRmgd(string path, Form originFrm)
        {
            MountTables();
            dir = new DirMngr(path);
            LoadConfig();

            Form frm = returnForm();
            originFrm.Hide();
            frm.Show(originFrm);
        }

        public OpenRmgd() { MountTables(); }

        #region "TablesSpawn"
        private void updateTableList()
        {
            tables.Add(paramCampaign);
            
            files.AddRecentRmgdFile(valueofTable(tables[0], "campaignName"), dir.Path);
        }
        private void MountTables()
        {
            MountCampaign();
        }
        public void MountCampaign()
        {
            paramCampaign = new DataTable("Campaign");
            paramCampaign.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ParamName", typeof(string)),
                new DataColumn("ParamValue", typeof(object))
            });

            paramCampaign.Rows.Add("rpgSystem", null);
            paramCampaign.Rows.Add("campaignName", null);
        }
        public void MountSystemsSupported()
        {
            systemsSupported = new DataTable("SystemsSupported");
            systemsSupported.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("System_Id", typeof(int)),
                new DataColumn("System_Name", typeof(string))
            });

            systemsSupported.Rows.Add(0, "D&D 3.5");
        }
        #endregion

        private Form returnForm()
        {
            Form form = new frmMain();
            if (valueofTable(paramCampaign, "rpgSystem") == 0.ToString()) //0 == D&D 3.5 see: MountSystemsSupported Method
            {
                form = new Dnd_35.frmMain(valueofTable(paramCampaign, "campaignName"));
            }

            return form;
        }
        #region "private methods"
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
                if (file[i].Split('=')[0].StartsWith("[") && canStop)
                {
                    end = i;
                    break;
                }
                if (file[i].Split('=')[0] == "[" + breakInField.ToUpper() + "]" && !found)
                {
                    start = i;
                    canStop = true;
                    found = true;
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

            return new List<string>();
        }
        /// <summary>
        /// Retorna uma tabela com os valores de um campo do arquivo
        /// </summary>
        /// <param name="dt"></param>
        private void loadTable(ref DataTable dt)
        {
            List<string> lst = new List<string>();
            lst.AddRange(breakFile(dt.TableName));
            lst.Remove("[" + dt.TableName.ToUpper() + "]");

            foreach (string item in lst)
            {
                bool found = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (item.Split('=')[0] == dt.Rows[i][0].ToString())
                    {
                        found = true;
                        dt.Rows[i][1] = item.Split('=')[1];
                    }
                }
                if (!found)
                {
                    dt.Rows.Add(item.Split('=')[0], item.Split('=')[1]);
                }
            }
        }
        #endregion

        #region "public methods"
        /// <summary>
        /// Loada o arquivo e carrega os parametros do arquivo nos parametros da classe
        /// </summary>
        public void LoadConfig()
        {
            List<string> Encrypted = new List<string>(), file = new List<string>();
            Encrypted.AddRange(dir.ReadAll());

            foreach (string str in Encrypted)
            {
                file.Add(CryptMngr.Decrypt(str));
            }
            this.file.AddRange(file);

            loadTable(ref paramCampaign);

            updateTableList();
        }

        public string valueofTable(DataTable table, string paramName)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][0].ToString() == paramName)
                {
                    return table.Rows[i][1].ToString();
                }
            }

            return null;
        }
        #endregion

        //
        // Propriedades
        //
        public DataTable CampaignTable
        {
            get { return paramCampaign; }
        }
        public DataTable SystemsSupported
        {
            get {
                MountSystemsSupported();
                return systemsSupported;
            }
        }
        public List<string> File
        {
            get { return file; }
        }
    }
}
