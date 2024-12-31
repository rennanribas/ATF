using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TCC
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Conexao.criar_Conexao() != "Erro ao conectar")
            {
                AcessoLogin login = new AcessoLogin();
                if (!login.verificarSeHaCadastro())
                {
                    ClasseGlobal.PrimeiroLogin = true;
                    Application.Run(new FormVerificarCodigo());
                }
                else
                    Application.Run(new FormLogin());
            }
            else
            {
                Application.Run(new FormIP());
            }
        }
    }
}
