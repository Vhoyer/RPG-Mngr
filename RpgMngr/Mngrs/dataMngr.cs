using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mngrs
{
    public class dataMngr
    {
        List<DataTable> db;
        string fileName = "database.db", filePath = DirMngr.Dir;

        public dataMngr() { }
        public dataMngr(List<DataTable> dts) { db = dts; }

        #region "static methods"
        /// <summary>
        /// Cria ou reescreve um arquivo contendo: nome da tabela; nome das colunas; valores das celulas, presentes em um array de tabelas(datatables).
        /// </summary>
        /// <param name="db">List<DataTables> As tabelas que serão salvas no arquivo</param>
        /// <param name="fileName">Nome do arquivo que será salvo. formato: "nomeDoArquivo.extenção"</param>
        /// <param name="filePath">Caminho até a pasta que será salvo o arquivo. formato: "Caminho\para\o\arquivo\"</param>
        public static void TablesToFile(List<DataTable> db, string fileName, string filePath)
        {
            List<string> file = new List<string>();
            foreach (DataTable table in db)
            {
                file.Add("[" + table.TableName.ToUpper() + "]");
                string columns = "|";
                foreach (DataColumn column in table.Columns)
                {
                    columns += column.ColumnName + '|';
                }
                foreach (DataRow row in table.Rows)
                {
                    string items = "|";
                    foreach (var item in row.ItemArray)
                    {
                        items += item.ToString() + '|';
                    }
                    file.Add(items);
                }
            }
            DirMngr dir = new DirMngr(filePath + fileName);
            List<string> Encrypted = new List<string>();
            foreach (var item in file)
            {
                Encrypted.Add(CryptMngr.Encrypt(item));
            }
            dir.Overwrite(file/*Encrypted*/);
        }
        public static void fileToTables()
        {

        }
        #endregion

        public bool command(string cmd, out object saida)
        {
            saida = "";
            string[] cmdSplit = cmd.Split(' ');
            try
            {
                #region "CREATE"
                if (cmdSplit[0].ToUpper() == "CREATE")
                {
                    if (cmdSplit[1].ToUpper() == "TABLE")
                    {
                        bool isNew = true;
                        foreach (var item in db)
                        {
                            if (cmdSplit[2] == item.TableName)
                            {
                                isNew = false;
                                break;
                            }
                        }
                        if (isNew)
                        {
                            db.Add(new DataTable(cmdSplit[2]));
                        }
                        return true;
                    }
                }
                #endregion
                #region "INSERT"
                int index = 0;
                if (cmdSplit[index++].ToUpper() == "INSERT")
                {
                    if (cmdSplit[index++].ToUpper() == "INTO")
                    {
                        bool firstParentesis = false;
                        string tableName = cmdSplit[index++];
                        if (tableName.Contains("("))
                        {
                            tableName = tableName.Split('(')[0];
                            index--;
                            firstParentesis = true;
                        }
                        for (int i = 0; i < db.Count; i++)
                        {
                            if (tableName == db[i].TableName)
                            {
                                List<string> whatColumns;
                                #region "if (firstParentesis)"
                                if (firstParentesis)
                                {
                                    char[] chars = cmd.ToCharArray();
                                    bool stopFirstSearch = false;
                                    int start = 0, stop = chars.Length;
                                    for (int c = 0; c < chars.Length; c++)
                                    {
                                        if (chars[c] == ')' && stopFirstSearch)
                                        {
                                            stop = c - start - 1;
                                            break;
                                        }
                                        if (chars[c] == '(' && !stopFirstSearch)
                                        {
                                            start = c;
                                            stopFirstSearch = true;
                                        }
                                    }
                                    string columns = cmd.Substring(start, stop);
                                    columns.Replace(" ", "");
                                    whatColumns = columns.Split(',');
                                }
                                else
                                {
                                    whatColumns = new string[db[i].Columns.Count];
                                    for (int c = 0; c < db[i].Columns.Count; c++)
                                    {
                                        whatColumns[c] = db[i].Columns[c].ColumnName;
                                    }
                                }
                                #endregion
                                List<string> values = ;

                                break;
                            }
                        }
                    }
                }
                #endregion
                #region "DROP"
                if (cmdSplit[0].ToUpper() == "DROP")
                {
                    if (cmdSplit[1].ToUpper() == "TABLE")
                    {
                        for (int i = 0; i > db.Count; i++)
                        {
                            if (cmdSplit[2] == db[i].TableName)
                            {
                                db.RemoveAt(i);
                                return true;
                            }
                        }
                    }
                } 
                #endregion
            }
            catch (Exception) { throw; }

            return false;
        }

        //
        // proprieties
        //
        public List<DataTable> Database
        {
            get { return db; }
            set { db = value; }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
            }
        }
    }
}
