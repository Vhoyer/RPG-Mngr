using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace RpgMngr.Mngrs
{
    class DirMngr
    {
        static string dir = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        string User = Environment.UserName;
        private string path, dirpath;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public enum Dirt
        {
            file, folder
        }

        /// <summary>
        /// Caminho absoluto para a pasta onde esta o executavel do projeto (formato: "C:\Path\to\Folder\")
        /// </summary>
        public static string Dir
        {
            get { return dir; }
        }

        #region "Construtor da classe"
        public DirMngr(string path, Dirt dt)
        {
            if (dt == Dirt.file)
            {
                this.path = path;
                this.dirpath = dpgen(path);
                CreateDir();
                CreateFile(); 
            }
            else if (dt == Dirt.folder)
            {
                this.dirpath = path;
                CreateDir();
            }
        }

        public DirMngr(string path)
        {
            this.path = path;
            this.dirpath = dpgen(path);
            CreateDir();
            CreateFile();
        }

        public DirMngr()
        {

        }
        #endregion

        /// <summary>
        /// gera o caminho do arquivo sem o arquivo
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string dpgen(string path)
        {
            string retorno = "";
            string[] sptpath = path.Split(char.Parse(@"\"));

            for (int i = 0; i < sptpath.Length - 1; i++)
            {
                retorno += sptpath[i] + @"\";
            }

            return retorno;
        }

        #region "CreateDir"
        /// <summary>
        /// cria um diretorio
        /// </summary>
        /// <returns></returns>
        public bool CreateDir()
        {
            try
            {
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// cria um diretorio
        /// </summary>
        /// <returns></returns>
        public bool CreateDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region "CreateFile"
        /// <summary>
        /// Cria um arquivo
        /// </summary>
        /// <returns></returns>
        public bool CreateFile()
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Close();
                }
                else
                {
                    CreateDir();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Cria um arquivo
        /// </summary>
        /// <param name="firstLine">escreve na primeira linha do arquivo</param>
        /// <returns></returns>
        public bool CreateFile(string firstLine)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Close();
                    AppendText(firstLine);
                }
                else
                {
                    List<string> lines = new List<string>();
                    lines.Add(firstLine);
                    lines.AddRange(ReadAll());
                    System.IO.File.WriteAllLines(path, lines);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region "AppendText"
        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(string str)
        {
            string[] stra = new string[] { str };
            CreateDir();
            System.IO.File.AppendAllLines(path, stra);
        }

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(string[] str)
        {
            CreateDir();
            System.IO.File.AppendAllLines(path, str);
        }

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(List<string> str)
        {
            CreateDir();
            System.IO.File.AppendAllLines(path, str);
        }
        //
        //--<Com "file">---------------------------------------------------------
        //

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(string str, string file)
        {
            string[] stra = new string[] { str };
            CreateDir();
            System.IO.File.AppendAllLines(dirpath + @"\" + file, stra);
        }

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(string[] str, string file)
        {
            CreateDir();
            System.IO.File.AppendAllLines(dirpath + @"\" + file, str);
        }

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(List<string> str, string file)
        {
            CreateDir();
            System.IO.File.AppendAllLines(dirpath + @"\" + file, str);
        }
        #endregion

        #region "overwrite"
        /// <summary>
        /// Reescreve todo o documento
        /// </summary>
        /// <param name="lines"></param>
        public void overwrite(IEnumerable<string> lines)
        {
            System.IO.File.WriteAllLines(path, lines);
        }
        /// <summary>
        /// Reescreve todo o documento
        /// </summary>
        /// <param name="lines"></param>
        public void overwrite(string line)
        {
            string[] strs = new string[] { line };
            System.IO.File.WriteAllLines(path, strs);
        }
        #endregion

        #region "ReadAll"
        /// <summary>
        /// lê todo um documento em um List<string>
        /// </summary>
        /// <returns></returns>
        public List<string> ReadAll()
        {
            List<string> retorno = new List<string>();
            if (!System.IO.File.Exists(this.path))
            {
                System.IO.File.Create(this.path).Close();
                return null;
            }
            retorno.AddRange(System.IO.File.ReadLines(this.path));

            return retorno;
        }

        /// <summary>
        /// lê todo um documento em um List<string>
        /// </summary>
        /// <returns></returns>
        public List<string> ReadAll(string file)
        {
            List<string> retorno = new List<string>();
            if (!System.IO.File.Exists(this.dirpath + @"\" + file))
            {
                System.IO.File.Create(this.dirpath + @"\" + file).Close();
                return null;
            }
            retorno.AddRange(System.IO.File.ReadLines(this.dirpath + @"\" + file));

            return retorno;
        } 
        #endregion

        /// <summary>
        /// reescreve uma linha especifica de um arquivo
        /// </summary>
        /// <param name="line">linha para ser editada</param>
        /// <param name="New">novo valor da linha</param>
        public void Rewrite(int line, string New)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            List<string> lines = new List<string>();

            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }

            reader.Close();
            lines[line] = New;
            System.IO.File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Roda um comando no cmd
        /// </summary>
        /// <param name="cmds"></param>
        public void runCmd(List<string> cmds)
        {
            StringBuilder command = new StringBuilder();
            foreach (string str in cmds)
            {
                command.Append(str + Environment.NewLine);
            }

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = false,
                //CreateNoWindow = true,
                RedirectStandardInput = true,
            };
            Process proc = new Process() { StartInfo = psi };

            proc.Start();

            proc.StandardInput.Write(command.ToString());

            proc.WaitForExit();
            proc.Close();
        }
    }
}
