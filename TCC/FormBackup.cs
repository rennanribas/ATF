using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace TCC
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 100;

            //quando executar fara o codigo seguinte
            string caminhoStart = Application.StartupPath.ToString();

            if (ClasseGlobal.Backup)
            {
                Text = "Backup";
                lblStatus.Text = "Status do backup:";
                MysqlBackup_Restore(caminhoStart, "backup");
            }
            else
            {
                Text = "Restauração";
                lblStatus.Text = "Status da restauração:";
                MysqlBackup_Restore(caminhoStart, "restore");
            }
            //corre uma thread com o processo que faz o backup ou restore
            Thread t = new Thread(delegate() { MySqlProcess(caminhoStart); });
            t.Start();

            if (ClasseGlobal.Backup)
                MessageBox.Show("Backup concluído!", "Backup concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Restauração concluída!", "Restauração concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnFechar.Visible = true;
        }

        private static void MysqlBackup_Restore(string path, string type)
        {
            //Caminho onde o mysql esta instalado
            string cmd = "\"C:/Arquivos de programas/MySQL/MySQL Server 5.5/bin/";

            //create a bath file to run the script database.
            StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
            //sw.WriteLine("c:");
            sw.WriteLine("c:");
            sw.WriteLine("cd\\");
            sw.WriteLine("cd " + cmd);

            string senha = "ALUNOS";

            if (type == "backup")
            {
                //se for backup
                sw.WriteLine("mysqldump.exe -uroot -p" + senha + " --databases atf_bd > " + path + "\\MySqlbackup.sql\"");
            }
            else
            {
                //se for restore
                sw.WriteLine("mysql.exe -uroot -p" + senha + " < \"" + path + "\\MySqlbackup.sql\"");
            }

            sw.Close();
        }

        private static void MySqlProcess(string Path)
        {
            //cria o processo a correr o MySqlbackup.cmd
            Process.Start(Path + "\\MySqlbackup.cmd");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
