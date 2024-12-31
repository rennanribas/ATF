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
    public partial class FormAlterarPacote : Form
    {
        public FormAlterarPacote()
        {
            InitializeComponent();
        }

        private void FormAlterarPacote_Load(object sender, EventArgs e)
        {
            //completa o comboBox do pacote com todos os pacotes, e preenche os campos com o primeiro ID selecionado
            AcessoPacotes acessoPac = new AcessoPacotes();
            cbPesquisar.DataSource = acessoPac.selecionarTodos();
            cbPesquisar.DisplayMember = "desc_pacote";
            cbPesquisar.ValueMember = "id_pacote";

            acessoPac.buscarporID(cbPesquisar.SelectedValue.ToString());
            txtBoxDesc.Text = acessoPac.Desc_pacote;
            txtBoxValor.Text = acessoPac.Valor_pacote.ToString();
            nUpDownDias.Value = acessoPac.DiasPacote;
        }

        private void cbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //se houver ID selecionado, busca no banco e preenche os valores
                if (cbPesquisar.SelectedValue != null)
                {
                    AcessoPacotes acessoPac = new AcessoPacotes();
                    acessoPac.buscarporID(cbPesquisar.SelectedValue.ToString());
                    txtBoxDesc.Text = acessoPac.Desc_pacote;
                    txtBoxValor.Text = acessoPac.Valor_pacote.ToString();
                    nUpDownDias.Value = acessoPac.DiasPacote;
                }
            }
            catch
            { }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar este pacote?", "Confirmação de Alteração",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (txtBoxDesc.Text != string.Empty && cbPesquisar.SelectedValue != null && txtBoxValor.Text != string.Empty
                && nUpDownDias.Value > 0)
            {
                if (dr == DialogResult.Yes)
                {
                    //se os campos verificados não estiverem nulos, e o usuario confirmar a alteração, altera no banco de 
                    //dados
                    AcessoPacotes acessoPac = new AcessoPacotes();
                    if (txtBoxValor.Text == string.Empty)
                        txtBoxValor.Text = "0";
                    acessoPac.alterarPacote(txtBoxDesc.Text, txtBoxValor.Text, nUpDownDias.Value.ToString(), cbPesquisar.SelectedValue.ToString());
                    MessageBox.Show("Pacote alterado com sucesso!", "Alteração Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //após alterar, preenhe os dados do comboBox denovo, com os novos dados.
                    cbPesquisar.DataSource = acessoPac.selecionarTodos();
                    cbPesquisar.DisplayMember = "desc_pacote";
                    cbPesquisar.ValueMember = "id_pacote";
                }
                else
                    MessageBox.Show("Este pacote não foi alterado.", "Confirmação Negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Preencha corretamente para alterar.", "Campos Não Preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //caso não seja numero, a tecla backspace ou virgula, bloqueia, e caso seja ponto, troca por virgula
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '\b')
                e.Handled = true;
            else
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
            }
        }

        private void txtBoxDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxValor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
