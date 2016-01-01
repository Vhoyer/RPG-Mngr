using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mngrs
{
    public class ConfigMngr
    {
        string Path = DirMngr.Dir;
        int start, end;
        DirMngr dir;
        List<string> file = new List<string>();
        List<DataTable> configs = new List<DataTable>();
        
        #region "Construtores da classe"
        public ConfigMngr()
        {
            dir = new DirMngr(DirMngr.Dir + @"\Config(" + DirMngr.User + ").ini");
            LoadConfig();
        }
        public ConfigMngr(string file)
        {
            dir = new DirMngr(DirMngr.Dir + @"\" + file + ".ini");
            LoadConfig();
        }
        public ConfigMngr(List<DataTable> tables)
        {
            this.configs = tables;
            dir = new DirMngr(DirMngr.Dir + @"\Config(" + DirMngr.User + ").ini");
            LoadConfig();
        }
        public ConfigMngr(string file, string extension)
        {
            dir = new DirMngr(DirMngr.Dir + @"\" + file + "." + extension);
            LoadConfig();
        }
        public ConfigMngr(string file, string extension, List<DataTable> tables)
        {
            this.configs = tables;
            dir = new DirMngr(DirMngr.Dir + file + "." + extension);
            LoadConfig();
        }
        #endregion

        #region "LoadFacilities"
        /// <summary>
        /// Retorna uma tabela com os valores de um campo do arquivo
        /// </summary>
        /// <param name="dt"></param>
        private void loadTables(ref List<DataTable> dts)
        {
            foreach (var dt in dts)
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
        }
        /// <summary>
        /// retorna uma lista com as linhas de só um campo
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private List<string> breakFile(string breakInField)
        {
            List<string> retorno = new List<string>();
            start = 0;
            end = file.Count;
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
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public string valueofTable(string paramName)
        {
            foreach (var table in configs)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i][0].ToString() == paramName)
                    {
                        return table.Rows[i][1].ToString();
                    }
                }
            }

            return null;
        }
        #endregion

        #region "WriteFacilities"
        public bool EditOrAddToTable(string tableName, string paramName, object paramValue)
        {
            if (!editTable(paramName, paramValue))
            {
                for (int i = 0; i < configs.Count; i++)
                {
                    if (configs[i].TableName == tableName)
                    {
                        configs[i].Rows.Add(paramName, paramValue);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Edita um específico de uma das tabelas da classe tabela
        /// </summary>
        /// <param name="paramName">nome do valor pelo procurar</param>
        /// <param name="newValue">novo valor a ser a tribuído a determinado campo</param>
        /// <returns>true se achar false se não achar</returns>
        public bool editTable(string paramName, object newValue)
        {
            for (int i = 0; i < configs.Count; i++)
            {
                for (int o = 0; o < configs[i].Rows.Count; o++)
                {
                    if (configs[i].Rows[o][0].ToString() == paramName)
                    {
                        configs[i].Rows[o][1] = newValue;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// converte os valores de tabelas com duas colunas para uma lista. No formato: 'coluna1=coluna2'
        /// </summary>
        /// <param name="dt">tablea</param>
        /// <param name="lst">lista de retorno</param>
        public void TableToList(DataTable dt, out List<string> lst)
        {
            lst = new List<string>();
            lst.Add("[" + dt.TableName.ToUpper() + "]");

            foreach (DataRow row in dt.Rows)
            {
                lst.Add(row[0] + "=" + row[1]);
            }
        }
        /// <summary>
        /// converte os valores de tabelas com duas colunas para uma lista. No formato: 'coluna1=coluna2'
        /// </summary>
        /// <param name="dt">tablea</param>
        /// <param name="lst">lista de retorno</param>
        public List<string> TableToList(DataTable dt)
        {
            List<string> lst = new List<string>();
            lst.Add("[" + dt.TableName.ToUpper() + "]");

            foreach (DataRow row in dt.Rows)
            {
                lst.Add(row[0] + "=" + row[1]);
            }

            return lst;
        }
        #endregion

        public void LoadConfig()
        {
            List<string> Encrypted = new List<string>(), file = new List<string>();
            Encrypted.AddRange(dir.ReadAll());

            foreach (string str in Encrypted)
            {
                file.Add(CryptMngr.Decrypt(str));
            }
            this.file.AddRange(file);

            loadTables(ref configs);
        }
        /// <summary>
        /// escreve todos os valores das tabelas no arquivo
        /// </summary>
        public void writeOnFile()
        {
            List<string> temp;

            foreach (DataTable item in configs)
            {
                TableToList(item, out temp);

                if (file.Count > 0)
                {
                    if (file[start] == "[" + item.TableName.ToUpper() + "]")
                    {
                        int index = 0;
                        int i;
                        for (i = start; i < end; i++)
                        {
                            file[i] = temp[index];
                            index++;
                        }
                        if (i - start - 1 < index)
                        {
                            for (int o = 0; o < index; o++)
                            {
                                temp.RemoveAt(0);
                            }
                            file.InsertRange(i, temp);
                        }
                    }
                    else
                    {
                        file.AddRange(temp);
                    }
                }
                else
                {
                    file.Add(RpgMngr.Properties.Resources.file_version);
                    file.AddRange(temp);
                }
            }

            List<string> Encrypted = new List<string>();
            foreach (string str in file)
            {
                Encrypted.Add(CryptMngr.Encrypt(str));
            }

            dir.Overwrite(Encrypted);
        }

        public static DataTable DatatableModel(string tableName)
        {
            DataTable dt = new DataTable(tableName);
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Param_Name", typeof(string)),
                new DataColumn("Param_Value", typeof(object))
            });
            return dt;
        }

        //
        // Propriedades
        //
        public List<DataTable> Configs
        {
            get { return configs; }
            set { configs = value; }
        }
    }
}
