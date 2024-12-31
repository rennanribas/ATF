using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormIP : Form
    {
        public FormIP()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                AcessoTxt acessoTxt = new AcessoTxt();
                acessoTxt.registrarIP(textBoxIP.Text);
                if (Conexao.criar_Conexao() != "Erro ao conectar")
                {
                    MessageBox.Show("Cadastrado com sucesso!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    AcessoLogin login = new AcessoLogin();
                    if (!login.verificarSeHaCadastro())
                    {
                        ClasseGlobal.PrimeiroLogin = true;
                        FormVerificarCodigo frmVerificar = new FormVerificarCodigo();
                        frmVerificar.Show();
                    }
                    else
                    {
                        FormLogin frmLogin = new FormLogin();
                        frmLogin.Show();
                    }
                }
                else
                    MessageBox.Show("IP inválido!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("IP inválido!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
