using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroContrato : Form
    {
        public FormCadastroContrato()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (cBCliente.SelectedValue != null &&
                cBFormaPag.SelectedValue != null && cBPacote.SelectedValue != null)
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este contrato?", "Confirmação Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    double valorTotal = Convert.ToDouble(txtBoxValor.Text);
                    AcessoContrato acessoContrato = new AcessoContrato();
                    acessoContrato.inserir(cBCliente.SelectedValue.ToString(), ClasseGlobal.Id_funcionario.ToString(),
                        cBFormaPag.SelectedValue.ToString(), cBPacote.SelectedValue.ToString(), valorTotal);
                    AcessoPacotes acessoPac = new AcessoPacotes();
                    DateTime diaExpirar = DateTime.Now;
                    int diasPacote = acessoPac.buscarDiasPacote(cBPacote.SelectedValue.ToString());
                    diaExpirar.AddDays(diasPacote);

                    MessageBox.Show("Contrato realizado com sucesso!" + Environment.NewLine +
                    "Irá expirar em " + diasPacote.ToString()
                        + " dias (será " + diaExpirar.ToLongDateString() + ")", "Contrato realizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    completar();
                }
                else
                    MessageBox.Show("Cadastro não confirmado", "Confirmação Negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Selecione todos os dados antes de cadastrar!", "Erro ao cadastrar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FormCadastroContrato_Load(object sender, EventArgs e)
        {
            completar();
        }

        private void completar()
        {
            AcessoCliente acessoCli = new AcessoCliente();
            DataTable todosCli = acessoCli.selecionarTodos();
            AcessoContrato acessoContrato = new AcessoContrato();
            for (int linha = 0; linha < todosCli.Rows.Count; linha++)
            {
                if (acessoContrato.temContrato(todosCli.Rows[linha]["ID_cli"].ToString()))
                {
                    todosCli.Rows[linha].Delete();
                    linha--;
                }
            }
            cBCliente.DataSource = todosCli;
            cBCliente.ValueMember = "id_cli";
            cBCliente.DisplayMember = "nome_cli";
            if (cBCliente.SelectedValue == null)
                cBCliente.Text = string.Empty;

            AcessoFormaPagamento acessoPag = new AcessoFormaPagamento();
            cBFormaPag.DataSource = acessoPag.selecionarTodos();
            cBFormaPag.ValueMember = "id_fpgto";
            cBFormaPag.DisplayMember = "tipo_pgto";

            AcessoPacotes acessoPacote = new AcessoPacotes();
            cBPacote.DataSource = acessoPacote.selecionarTodos();
            cBPacote.ValueMember = "id_pacote";
            cBPacote.DisplayMember = "desc_pacote";

            cBCliente.Focus();
        }

        private void cBPacote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AcessoPacotes acessoPacote = new AcessoPacotes();
                txtBoxValor.Text = acessoPacote.buscarValorPacote(cBPacote.SelectedValue.ToString());
            }
            catch { }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            cBCliente.Text = string.Empty;
            cBFormaPag.Text = string.Empty;
            cBPacote.Text = string.Empty;
            txtBoxValor.Text = string.Empty;
            cBCliente.Focus();
        }

        private void txtBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void cBFormaPag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
