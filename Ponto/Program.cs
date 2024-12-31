using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ponto
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
                Application.Run(new FormLogin());
            else
                Application.Run(new FormIP());
        }
    }
}
