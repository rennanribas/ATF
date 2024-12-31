using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroFuncao : Form
    {
        public FormCadastroFuncao()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtBoxDesc.Text != string.Empty)
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar esta função?", "Confirmação cadastro",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    AcessoFuncao acessoFuncao = new AcessoFuncao();
                    string permissao;
                    if (cBPermissao.Checked)
                        permissao = "1";
                    else
                        permissao = "0";
                    acessoFuncao.inserir(txtBoxDesc.Text, permissao);
                    MessageBox.Show("Cadastrado com sucesso!", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cBPermissao.Checked = false;
                    txtBoxDesc.Text = string.Empty;
                    txtBoxDesc.Focus();
                }
                else
                    MessageBox.Show("Confirmação não confirmada", "Confirmação negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Digite todos os campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxDesc.Text = string.Empty;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBoxDesc.Text = string.Empty;
            cBPermissao.Checked = false;
            txtBoxDesc.Focus();
        }
    }
}
