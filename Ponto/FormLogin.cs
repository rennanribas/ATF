using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ponto
{
    public partial class FormLogin : Form
    {
        bool load = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                AcessoLogin acesso = new AcessoLogin();
                //verifica se o login é valido, utilizando do usuário e senha fornecidos
                if (acesso.VerificarLogin(txtLogin.Text, txtSenha.Text) == true)
                {
                    //caso retorne true, mostra a mensagem de cliente logado, esconde o form, e abre o form principal
                    MessageBox.Show(acesso.Resposta, "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FormPrincipal form = new FormPrincipal();
                    form.Show();
                }
                else
                {
                    //caso retorne false, não loga, e mostra a mensagem vinda do método
                    MessageBox.Show(acesso.Resposta, "Login inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                //método caso dê erro, dá erro ao conectar banco de dados
                MessageBox.Show("Erro ao conectar com base de dados.", "Erro na conexão",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //caso feche o form, fecha o processo.
            Application.Exit();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica se o usuario precionou enter no txt senha, faz a mesma coisa que o botão logar
            if (e.KeyChar == '\r')
            {
                try
                {
                    AcessoLogin acesso = new AcessoLogin();
                    //verifica se o login é valido, utilizando do usuário e senha fornecidos
                    if (acesso.VerificarLogin(txtLogin.Text, txtSenha.Text) == true)
                    {
                        //caso retorne true, mostra a mensagem de cliente logado, esconde o form, e abre o form principal
                        MessageBox.Show(acesso.Resposta, "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        FormPrincipal form = new FormPrincipal();
                        form.Show();
                    }
                    else
                    {
                        //caso retorne false, não loga, e mostra a mensagem vinda do método
                        MessageBox.Show(acesso.Resposta, "Login inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    //método caso dê erro, dá erro ao conectar banco de dados
                    MessageBox.Show("Erro ao conectar com base de dados.", "Erro na conexão",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        


    }
}
