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
        DirMngr dir;
        List<string> file = new List<string>();
        List<DataTable> tables = new List<DataTable>();
        
        #region "Construtores da classe"
        public ConfigMngr()
        {
            dir = new DirMngr(DirMngr.Dir + @"\Config.ini");
            LoadConfig();
        }
        public ConfigMngr(string file)
        {
            dir = new DirMngr(DirMngr.Dir + @"\" + file + ".ini");
            LoadConfig();
        }
        public ConfigMngr(string file, string extension)
        {
            dir = new DirMngr(DirMngr.Dir + @"\" + file + "." + extension);
            LoadConfig();
        }
        public ConfigMngr(string file, string extension, List<DataTable> tables)
        {
            this.tables = tables;
            dir = new DirMngr(DirMngr.Dir + file + "." + extension);
            LoadConfig();
        }
        #endregion

        #region "LoadFacilities"
        public void LoadConfig()
        {
            List<string> Encrypted = new List<string>(), file = new List<string>();
            Encrypted.AddRange(dir.ReadAll());

            foreach (string str in Encrypted)
            {
                file.Add(CryptMngr.Decrypt(str));
            }
            this.file.AddRange(file);

            loadTables(ref tables);
        }
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
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public string valueofTable(string paramName)
        {
            int index = -1;
            foreach (var table in tables)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i][0].ToString() == paramName)
                    {
                        index = i;
                        return table.Rows[index][1].ToString();
                    }
                }
            }

            return null;
        }
        #endregion

        #region "WriteFacilities"
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
        /// <summary>
        /// escreve todos os valores das tabelas no arquivo
        /// </summary>
        public void writeOnFile()
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
        #endregion

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
            get { return tables; }
            set { tables = value; }
        }

        #region "Old"
        /*

        DirMngr dirmngr;
        List<string> Param = new List<string>();
        int ln;
        DataTable configs = new DataTable();

        /// <summary>
        /// Checa se a linha é comentada ou não, se define comentada por se iniciar por "#"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool isComment(string line)
        {
            if (line == "")
            {
                return true;
            }
            for (int i = 0; i < line.Length; i++)
            {
                if (line.Substring(i, 1) == "#")
                {
                    return true;
                }
                else if (line.Substring(i, 1) != " ")
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Acha a linha da primeira ocorrencia da string de procura no arquivo
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private string FindinFile(string Search)
        {
            List<string> Lines = dirmngr.ReadAll();

            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Split('=')[0] == Search)
                {
                    ln = i;
                    return Lines[i].Split('=')[1];
                }
            }
            return null;
        }

        /// <summary>
        /// Faz a mesma função do "indexOf", fiz pq não sabia que existia... MAS também retorna o valor do parametro
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private string Find(string Search)
        {
            for (int i = 0; i < Param.Count; i++)
            {
                if (Param[i].Split('=')[0] == Search)
                {
                    ln = i;
                    return Param[i].Split('=')[1];
                }
            }
            return null;
        }

        /// <summary>
        /// Loada o arquivo e carrega os parametros do arquivo nos parametros da classe
        /// </summary>
        public void LoadConfig()
        {
            Param = dirmngr.ReadAll();

            for (int i = 0; i < Param.Count; i++)
            {
                if (isComment(Param[i]))
                {
                    Param.RemoveAt(i);
                    i--;
                }
            }

            //FnUVariable("nickname", ref nickname);
        }
        #region "FnUVariables"
        /// <summary>
        /// Acha e atualiza a variavel do parametro
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnUVariable(string str, ref string param)
        {
            if (Find(str) != null)
            {
                param = Find(str);
            }
        }
        /// <summary>
        /// Acha e atualiza a variavel do parametro
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnUVariable(string str, ref char param)
        {
            if (Find(str) != null)
            {
                param = char.Parse(Find(str));
            }
        }
        /// <summary>
        /// Acha e atualiza a variavel do parametro
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnUVariable(string str, ref bool param)
        {
            if (Find(str) != null)
            {
                param = bool.Parse(Find(str));
            }
        } 
        #endregion

        /// <summary>
        /// Dá um update no arquivo inteiro, muda o arquivo pelos parametros da classe
        /// </summary>
        public void UpdateFile()
        {
            dirmngr.CreateFile();

            //FnRParam("nickname", nickname);
        }
        #region "FnRParam"
        /// <summary>
        /// Acha o parametro se existir atualiza ele, se não existir cria
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnRParam(string str, string param)
        {
            if (Find(str) != null)
            {
                FindinFile(str);
                dirmngr.Rewrite(ln, str + "=" + param);
            }
            else
            {
                dirmngr.AppendText(str + "=" + param);
            }
        }
        /// <summary>
        /// Acha o parametro se existir atualiza ele, se não existir cria
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnRParam(string str, bool param)
        {
            if (Find(str) != null)
            {
                FindinFile(str);
                dirmngr.Rewrite(ln, str + "=" + param);
            }
            else
            {
                dirmngr.AppendText(str + "=" + param);
            }
        }
        /// <summary>
        /// Acha o parametro se existir atualiza ele, se não existir cria
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnRParam(string str, char param)
        {
            if (Find(str) != null)
            {
                FindinFile(str);
                dirmngr.Rewrite(ln, str + "=" + param);
            }
            else
            {
                dirmngr.AppendText(str + "=" + param);
            }
        }
        #endregion

        /// <summary>
        /// dá um update no arquivo de config no parametros desejado
        /// </summary>
        /// <param name="config"></param>
        public void UpdateParam(string config)
        {
            string param = config.Split('=')[0];

            dirmngr.CreateFile();
            if (Find(param) != null)
            {
                FindinFile(param);
                dirmngr.Rewrite(ln, config);
            }
        }
        */
        #endregion
    }
}
