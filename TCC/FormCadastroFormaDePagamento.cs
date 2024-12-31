using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroFormaDePagamento : Form
    {
        public FormCadastroFormaDePagamento()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtforma.Text != string.Empty)
                {
                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar esta forma de pagamento?",
                        "Confirmação cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        AcessoFormaPagamento acesso = new AcessoFormaPagamento();
                        acesso.inserir(txtforma.Text);
                        MessageBox.Show("Forma de Pagamento Cadastrada Com Sucesso!", "Cadastrado Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtforma.Text = string.Empty;
                        txtforma.Focus();
                    }
                    else
                        MessageBox.Show("Cadastro não confirmado.", "Confirmação negada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Digite todos os campos primeiro.", "Campos não preenchidos"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtforma.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Houve algum erro, tente novamente.", "Erro ao cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtforma_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtforma.Text = string.Empty;
            txtforma.Focus();
        }
    }
}
