using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ponto
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
                //tenta conectar com o banco de dados, usando o ip fornecido, caso consiga, cadastra no bloco de notas
                //e exibe mensagem de cadastrado com sucesso
                AcessoTxt acessoTxt = new AcessoTxt();
                acessoTxt.registrarIPBD(textBoxIP.Text);
                Conexao.criar_Conexao();
                MessageBox.Show("Cadastrado com sucesso!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //esconde o form, já que ele é o principal para o processo, e logo após, abre o form login
                Hide();
                FormLogin frmLogin = new FormLogin();
                frmLogin.Show();
            }
            catch
            {
                //caso não consiga conectar, exibe a mensagem de IP inválido
                MessageBox.Show("IP inválido!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxIP.Focus();
            }
        }

        private void textBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //caso o usuario aperte enter, faz o mesmo código que ao preciosar o botão cadastrar.
            if (e.KeyChar == '\r')
            {
                try
                {
                    //tenta conectar com o banco de dados, usando o ip fornecido, caso consiga, cadastra no bloco de notas
                    //e exibe mensagem de cadastrado com sucesso
                    AcessoTxt acessoTxt = new AcessoTxt();
                    acessoTxt.registrarIPBD(textBoxIP.Text);
                    Conexao.criar_Conexao();
                    MessageBox.Show("Cadastrado com sucesso!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //esconde o form, já que ele é o principal para o processo, e logo após, abre o form login
                    Hide();
                    FormLogin frmLogin = new FormLogin();
                    frmLogin.Show();
                }
                catch
                {
                    //caso não consiga conectar, exibe a mensagem de IP inválido
                    MessageBox.Show("IP inválido!", "Cadastro de IP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
