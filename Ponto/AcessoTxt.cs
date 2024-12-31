using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Ponto
{
    class AcessoTxt
    {
        //váriaveis estaticas para o caminho do arquivo txt com o IP
        public static string caminhoStart = Application.StartupPath.ToString();
        public static string caminhoDoArquivoBD = Path.Combine(caminhoStart, "IPMAQB.txt");

        //método para buscar o IP do banco de dados usando do arquivo txt
        public String ipBD()
        {
            using (Stream stream = new FileStream(caminhoDoArquivoBD, FileMode.OpenOrCreate))
            {
                using (StreamReader leitor = new StreamReader(stream))
                {
                    string desc = string.Empty;
                    int i = 0;
                    while(!leitor.EndOfStream)
                    {
                        if (i == 1)
                        {
                            //se for a linha 1 do txt, ele lê a mesma, e ocupa o valor da variavel desc, 
                            //com a linha desencriptada
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

        //método para registrar o IP do banco de dados no bloco de notas
        public void registrarIPBD(String ip)
        {
            using (Stream stream = new FileStream(caminhoDoArquivoBD, FileMode.Truncate))
            {
                using (StreamWriter escritor = new StreamWriter(stream))
                {
                    //escreve no bloco de notas o ip, encriptografando o mesmo
                    escritor.Write(Cripto.cripto(ip));
                    escritor.Close();
                }
            }
        }
    }
}
