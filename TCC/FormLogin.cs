using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
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
                if (acesso.VerificarLogin(txtEmail.Text, txtSenha.Text) == true)
                {
                    MessageBox.Show(acesso.Resposta, "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    FormPrincipal form = new FormPrincipal();
                    form.Show();
                    ClasseGlobal.Logado = true;
                }
                else
                {
                    MessageBox.Show(acesso.Resposta, "Login inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao conectar com base de dados.", "Erro na conexão",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    AcessoLogin acesso = new AcessoLogin();
                    if (acesso.VerificarLogin(txtEmail.Text, txtSenha.Text) == true)
                    {
                        MessageBox.Show(acesso.Resposta, "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        FormPrincipal form = new FormPrincipal();
                        form.Show();
                        ClasseGlobal.Logado = true;
                    }
                    else
                    {
                        MessageBox.Show(acesso.Resposta, "Login inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    MessageBox.Show("Erro ao conectar com base de dados.", "Erro na conexão",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        


    }
}
