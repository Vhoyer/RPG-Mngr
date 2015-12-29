using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mngrs
{
    class ConfigMngr
    {
        DirMngr dirmngr;
        List<string> Param = new List<string>();
        int ln;
        DataTable configs = new DataTable();

        public DataTable Configs
        {
            get { return configs; }
            set { configs = value; }
        }

        public ConfigMngr()
        {
            dirmngr = new DirMngr(DirMngr.Dir + @"\Config.ini");
            LoadConfig();
        }

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
    }
}
