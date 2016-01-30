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
        static char separator = '§';

        public dataMngr() { }
        public dataMngr(List<DataTable> dts) { db = dts; }

        #region "static methods"
        /// <summary>
        /// Cria ou reescreve um arquivo contendo: nome da tabela; nome das colunas; valores das celulas, presentes em um array de tabelas(datatables).
        /// </summary>
        /// <param name="db">List<DataTables> As tabelas que serão salvas no arquivo</param>
        /// <param name="filePath">Caminho até a pasta que será salvo o arquivo. formato: "Caminho\para\o\arquivo\nomeDoArquivo.extenção"</param>
        public static void TablesToFile(List<DataTable> db, string filePath)
        {
            List<string> file = new List<string>();
            foreach (DataTable table in db)
            {
                file.Add("[" + table.TableName + "]");
                string columns = "";
                for (int i = 0; i < table.Columns.Count - 1; i++)
                {
                    columns += table.Columns[i].ToString() + separator;
                }
                columns += table.Columns[table.Columns.Count - 1].ToString();
                file.Add(columns);
                foreach (DataRow row in table.Rows)
                {
                    string items = "";
                    for (int i = 0; i < row.ItemArray.Length - 1; i++)
                    {
                        items += row.ItemArray[i].ToString() + separator;
                    }
                    items += row.ItemArray[row.ItemArray.Length - 1].ToString();
                    file.Add(items);
                }
            }
            DirMngr dir = new DirMngr(filePath);
            dir.Overwrite(CryptMngr.EncryptText(file));
        }
        /// <summary>
        /// Lê um arquivo contendo: nome da tabela; nome das colunas; valores das celulas, presentes em um arquivo.
        /// </summary>
        /// <param name="db">List<DataTables>A variavel na qual serão salvas as tabelas</param>
        /// <param name="filePath">Caminho até a pasta que será aberto o arquivo. formato: "Caminho\para\o\arquivo\nomeDoArquivo.extenção"</param>
        public static void fileToTables(out List<DataTable> db, string filePath)
        {
            DirMngr dir = new DirMngr(filePath);
            db = new List<DataTable>();
            List<string> file = CryptMngr.DecryptText(dir.ReadAll());
            try
            {
                //separar as tabelas do array de string e depois transforma-las em datatables e inseri-las na lista de datatables
                int startIn = 0;
                while (startIn < file.Count)
                {
                    db.Add(tableSeparator(ref file, ref startIn));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Possivelmente o arquivo está ilegivel, corrompido ou em branco. Mais Detalhes:\n\n" + e.Message + "\n\n" + e);
            }
        }
        private static DataTable tableSeparator(ref List<string> strLst, ref int whereToStart)
        {
            DataTable oneTable = new DataTable();
            int index;
            //separa o nome da tabela
            for (index = whereToStart; index < strLst.Count; index++)
            {
                if (strLst[index].StartsWith("[") && strLst[index].EndsWith("]"))
                {
                    oneTable.TableName = strLst[index].Substring(1, strLst[index].Length - 2);
                    index++;
                    break;
                }
            }
            //separa as colunas
            List<string> columnsNames = utilitiesMngr.convertToListString(strLst[index++].Split(separator));
            foreach (var item in columnsNames)
            {
                oneTable.Columns.Add(item);
            }
            int i;
            //separa as linhas
            for (i = index; i < strLst.Count; i++)
            {
                if (strLst[i].StartsWith("[") && strLst[i].EndsWith("]"))
                {
                    break;
                }
                DataRow newRow = oneTable.NewRow();
                object[] itens = strLst[i].Split(separator);
                newRow.ItemArray = itens;
                oneTable.Rows.Add(newRow);
            }
            whereToStart = i;
            //tudo junto, hora de desachar ;)
            return oneTable;
        }
        public static void fileToTables(ref List<DataTable> db, string filePath, out List<DataTable> backup)
        {
            backup = db;
            fileToTables(out db, filePath);
        }
        #endregion

        public bool command(string cmd, out object saida)
        {
            saida = "";
            string[] cmdSplit = cmd.Split(' ');
            try
            {
                int index = 0;
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
                else if (cmdSplit[index++].ToUpper() == "INSERT")
                {
                    if (cmdSplit[index++].ToUpper() == "INTO")
                    {
                        //formato esperado: INSERT INTO tablename(columns, separeted, by, comma) VALUES(values, separeted, by, comma)
                        bool firstParentesis = false;
                        string tableName = cmdSplit[index++]; //pega o nome da tabela
                        index++;
                        //se houver um parentesis no nome a gente tira
                        #region "if (tableName.Contains("(")) else if (cmdSplit[index].Contains("(") && !cmdSplit[index].ToUpper().Contains("VALUES"))"
                        if (tableName.Contains("("))
                        {
                            tableName = tableName.Split('(')[0];
                            firstParentesis = true;
                        }
                        else if (cmdSplit[index].Contains("(") && !cmdSplit[index].ToUpper().Contains("VALUES"))
                        {
                            firstParentesis = true;
                        } 
                        #endregion
                        //procura a tabela no "banco"
                        for (int i = 0; i < db.Count; i++)
                        {
                            #region "if (tableName == db[i].TableName)"
                            if (tableName == db[i].TableName)
                            {
                                List<string> whatColumns;
                                List<string> whatValues = new List<string>();

                                char[] chars = cmd.ToCharArray();
                                //procura e separa os valores das colunas a adicionar, mais o nome da coluna
                                #region "if (firstParentesis)"
                                bool stop2ndSearch = false;
                                int start2nd = 0, stop2nd = chars.Length;
                                bool stopFirstSearch = false;
                                int start = 0, stop = chars.Length;
                                if (firstParentesis)
                                {
                                    //analiza char por char pra ver qual é a dele ¬¬
                                    //confere se ele é um parenteses e marca o inicio e o fim de uma das listas. colunas ou valores
                                    for (int c = 0; c < chars.Length; c++)
                                    {
                                        if (chars[c] == ')')
                                        {
                                            if (stopFirstSearch)
                                            {
                                                stop = c - start - 1;
                                            }
                                            else if (stop2ndSearch)
                                            {
                                                stop2nd = c - start2nd - 1;
                                                break;
                                            }
                                        }
                                        if (chars[c] == '(')
                                        {
                                            if (!stopFirstSearch)
                                            {
                                                start = c;
                                                stopFirstSearch = true;
                                            }
                                            else if (!stop2ndSearch)
                                            {
                                                start2nd = c;
                                                stop2ndSearch = true;
                                            }
                                        }
                                    }
                                    //addicona os valores na lista
                                    //tirando os espasos e separando por virgula
                                    string columns = cmd.Substring(start, stop);
                                    columns.Replace(" ", "");
                                    whatColumns = utilitiesMngr.convertToListString(columns.Split(','));
                                }
                                else
                                {
                                    //não achou os nomes das colunas, então vai procurar só dos "valores"
                                    whatColumns = new List<string>();
                                    for (int c = 0; c < db[i].Columns.Count; c++)
                                    {
                                        whatColumns.Add(db[i].Columns[c].ColumnName);//improvisou os nomes das colunas aqui
                                    }

                                    for (int c = 0; c < chars.Length; c++)
                                    {
                                        if (chars[c] == ')')
                                        {
                                            if (stop2ndSearch)
                                            {
                                                stop2nd = c - start2nd - 1;
                                                break;
                                            }
                                        }
                                        if (chars[c] == '(')
                                        {
                                            if (!stop2ndSearch)
                                            {
                                                start2nd = c;
                                                stop2ndSearch = true;
                                            }
                                        }
                                    }
                                }
                                //analisa, conserta, separa e aplica. tipo dividir e conquistar, só que mais complicado
                                string values = cmd.Substring(start2nd, stop2nd);
                                values.Replace(" ", "");
                                List<string> validate = utilitiesMngr.convertToListString(values.Split(','));
                                bool temAspas = false;
                                for (int v = 0; v < validate.Count; v++)
                                {
                                    //testa pra ver se tem aspas("), porque se tiver fudeu, porque vai ter que consertar, ao invés de separa por virgula, 
                                    //vai ter que separar por aspas e tirar os itens a mais...

                                    if (validate[v].Contains('"'.ToString()))
                                    {
                                        temAspas = true;
                                        break;
                                    }
                                }
                                if (temAspas)
                                {
                                    List<string> jaSeparado = new List<string>();
                                    #region "Separar por aspas"
                                    object[] Comeco_Final = new object[2]; int currentChar = 0;
                                    values.Replace(",", "");
                                    foreach (char chr in values)
                                    {
                                        if (chr == '"')
                                        {
                                            if (Comeco_Final[0] != null)
                                            {
                                                Comeco_Final[0] = currentChar;
                                            }
                                            else if (Comeco_Final[1] != null)
                                            {
                                                Comeco_Final[1] = currentChar;
                                                jaSeparado.Add(
                                                    values.Substring(
                                                        Convert.ToInt32(Comeco_Final[0]), 
                                                        Convert.ToInt32(Comeco_Final[1])
                                                    )
                                                );
                                                Comeco_Final = new object[2];
                                            }
                                        }
                                        currentChar++;
                                    }
                                    #endregion
                                    whatValues = jaSeparado;
                                }
                                else
                                {
                                    whatValues = validate;
                                    validate = null;
                                }
                                #endregion
                                List<string> allColumns = new List<string>();
                                List<string> allValues = new List<string>();
                                foreach (DataColumn column in db[i].Columns)
                                {
                                    allColumns.Add(column.ColumnName);
                                    allValues.Add("");
                                }
                                //edita as listas "all" com os valores das "what"
                                foreach (string col in allColumns)
                                {
                                    for (int c = 0; c < whatColumns.Count; c++)
                                    {
                                        if (col == whatColumns[c])
                                        {
                                            allValues[c] = whatValues[c];
                                            break;
                                        } 
                                    }
                                }
                                //cria e coloca os valores na "row"
                                DataRow newRow = db[i].NewRow();
                                object[] itemArray = new object[allValues.Count];
                                for (int v = 0; v < itemArray.Length; v++)
                                {
                                    itemArray[v] = allValues[v];
                                }
                                newRow.ItemArray = itemArray;
                                //coloca a "row" na tabela
                                db[i].Rows.Add(newRow);
                                break;
                            }
                            #endregion
                        }
                    }
                }
                #endregion
                #region "DROP"
                else if (cmdSplit[0].ToUpper() == "DROP")
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

            saida = "erro não esperado";
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
