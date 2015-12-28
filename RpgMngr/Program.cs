using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgMngr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            //configuração normal de aplicativos
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //variaveis
            bool tf = false, tryOpen = false;
            int Args_Length = 0;
            string filePath = "";
            //checa se existem argumentos
            try
            {
                if (Args.Length - 1 >= 0)
                {
                    Args_Length = Args.Length - 1;
                    tryOpen = true;
                }
            }
            catch (Exception) { }
            //se existirem argumentos faz isso se não...
            if (tryOpen)
            {
                try //checa se a extenção do arquivo é a correta
                {
                    if (Args[Args_Length].Split('.')[Args[Args_Length].Split('.').Length - 1].ToLower() == "rmgd")
                        tf = true;
                }
                catch (Exception) { }

                if (tf) //se for a estenção certa
                {
                    filePath = Args[Args_Length];

                    Mngrs.DirMngr dir = new Mngrs.DirMngr(filePath);

                    List<string> file = new List<string>();
                    file.AddRange(dir.ReadAll());

                    try
                    {
                        if (Mngrs.CryptMngr.Decrypt(file[0]) != Properties.Resources.file_version)
                        {
                            MessageBox.Show("Versão do arquivo não compatível", "Erro 002");
                            Application.Run(new frmMain());
                        }
                        else
                        {
                            string oi = "";
                            foreach (var item in file)
                            {
                                oi += Mngrs.CryptMngr.Decrypt(item) + Environment.NewLine;
                            }
                            MessageBox.Show(oi);
                            //Mngrs.OpenRmgd openFile = new Mngrs.OpenRmgd(filePath);
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("Documento em Branco", "ERRO 003");
                        Application.Run(new frmMain());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + "\n\n\n" + e);
                    }
                }
                else //se não roda a padrão
                {
                    MessageBox.Show("Estenção de arquivo incorreta", "ERRO 001");
                    Application.Run(new Dnd_35.frmMain());
                }
            }
            else //se não roda o começo do programa
            {
                Application.Run(new frmMain());
            }
        }
    }
}
