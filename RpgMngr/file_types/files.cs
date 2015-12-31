using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mngrs;

namespace RpgMngr.file_types
{
    public class files
    {
        public files()
        {

        }

        public static string[] GetRecentRmgdFiles()
        {
            string[] retorno = new string[8]
            {
                "","","","","","","",""
            };
            List<DataTable> tables = new List<DataTable>()
            {
                ConfigMngr.DatatableModel("RecentRmgdFiles")
            };
            ConfigMngr config = new ConfigMngr("Data", "dat", tables);
            List<string> lst = new List<string>();
            config.TableToList(config.Configs[0], out lst);

            lst.RemoveAt(0);
            lst.Reverse();
            for (int i = 0; i < retorno.Length && i < lst.Count; i++)
            {
                retorno[i] = lst[i];
            }
            return retorno;
        }

        public static void AddRecentRmgdFile(string fileName, string filePath)
        {
            List<DataTable> tables = new List<DataTable>()
            {
                ConfigMngr.DatatableModel("RecentRmgdFiles")
            };
            ConfigMngr config = new ConfigMngr("Data", "dat", tables);

            for (int i = 0; i < config.Configs[0].Rows.Count; i++)
            {
                if (config.Configs[0].Rows[i][0].ToString() == fileName)
                {
                    config.Configs[0].Rows.RemoveAt(i);
                    break;
                }
            }
            config.Configs[0].Rows.Add(fileName, filePath);

            if (config.Configs[0].Rows.Count > 8)
                config.Configs[0].Rows.RemoveAt(0);

            config.writeOnFile();
        }
    }
}
