using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarFormaPagamento : Form
    {
        public FormAlterarFormaPagamento()
        {
            InitializeComponent();
        }

        private void FormAlterarFormaPagamento_Load(object sender, EventArgs e)
        {
            //preenche o comboBox ao iniciar o form
            AcessoFormaPagamento acesso = new AcessoFormaPagamento();
            cbEscolhaFormaPagamento.DataSource = acesso.selecionarTodos();
            cbEscolhaFormaPagamento.ValueMember = "ID_fpgto";
            cbEscolhaFormaPagamento.DisplayMember = "tipo_pgto";
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se o campo obrigatorio está preenchido
                if (cbEscolhaFormaPagamento.SelectedValue != null)
                {
                    //verifica se o outro campo obrigatorio está preenchido
                    if (txtforma.Text != string.Empty)
                    {
                        DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar esta forma de pagamento?",
                            "Confirmação forma de pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //Verifica se o cliente confirmou a alteração
                        if (dr == DialogResult.Yes)
                        {
                            AcessoFormaPagamento acesso = new AcessoFormaPagamento();
                            acesso.alterarFormaPagamento(txtforma.Text, cbEscolhaFormaPagamento.SelectedValue.ToString());
                            MessageBox.Show("Forma de Pagamento Alterada Com Sucesso!", "Alterado Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbEscolhaFormaPagamento.DataSource = acesso.selecionarTodos();
                            cbEscolhaFormaPagamento.ValueMember = "ID_fpgto";
                            cbEscolhaFormaPagamento.DisplayMember = "tipo_pgto";
                        }
                        else
                            MessageBox.Show("Alteração não confirmada.", "Confirmação negada.", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Digite uma descrição para a forma de pagamento.",
                            "Campo nulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtforma.Focus();
                    }
                }
                else
                    MessageBox.Show("Primeiro escolha uma forma de pagamento para alterar.", "Sem forma de pagamento selecionada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Houve algum erro, tente novamente.", "Erro ao Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCadastro_Click_1(object sender, EventArgs e)
        {

        }

        private void cbEscolhaFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //preenche o txt com a forma de pagamento
            try
            {
                cbEscolhaFormaPagamento.BackColor = Color.Empty;
                txtforma.Text = ((DataTable)cbEscolhaFormaPagamento.DataSource).
                    Rows[cbEscolhaFormaPagamento.SelectedIndex]["tipo_pgto"].ToString();
            }
            catch { }
        }

        private void txtforma_TextChanged(object sender, EventArgs e)
        {
            txtforma.BackColor = Color.Empty;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
