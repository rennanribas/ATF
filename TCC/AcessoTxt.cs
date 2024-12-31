using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TCC
{
    class AcessoTxt
    {
        public static string caminhoStart = Application.StartupPath.ToString();
        public static string caminhoDoArquivo = Path.Combine(caminhoStart, "IPMAQB.txt");

        //metodo para buscar IP a partir do bloco de notas
        public String ip()
        {
            using (Stream stream = new FileStream(caminhoDoArquivo, FileMode.OpenOrCreate))
            {
                using (StreamReader leitor = new StreamReader(stream))
                {
                    string desc = "";
                    int i = 0;
                    while(!leitor.EndOfStream)
                    {
                        if (i == 1)
                        {
                            string encriptado = leitor.ReadLine().ToString();
                            desc = Cripto.descripto(encriptado);
                        }
                        else
                            i++;
                    }

                    return desc;
                }
            }
        }

        //metodo para gravar no bloco de notas o IP
        public void registrarIP(String ip)
        {
            using (Stream stream = new FileStream(caminhoDoArquivo, FileMode.Truncate))
            {
                using (StreamWriter escritor = new StreamWriter(stream))
                {

                    escritor.Write(Cripto.cripto(ip));
                    escritor.Close();
                }
            }
        }
    }
}
