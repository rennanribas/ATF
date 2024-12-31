using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarContrato : Form
    {
        bool buscar = false;
        public FormAlterarContrato()
        {
            InitializeComponent();
        }
        private void FormAlterarContrato_Load(object sender, EventArgs e)
        {
            //preenche o comboBox do cliente com todos os clientes
            AcessoCliente acessoCli = new AcessoCliente();
            DataTable dt = acessoCli.selecionarTodos();
            comboBoxCliente.DisplayMember = "nome_cli";
            comboBoxCliente.ValueMember = "id_cli";
            AcessoContrato acessoContrato = new AcessoContrato();

            //looping para verificar quais clientes já tem contrato, aqueles que já tiverem, são excluidos da tabela
            //e logo, não aparecem no comboBox
            for (int linha = 0; linha < dt.Rows.Count; linha++)
            {
                if (!acessoContrato.temContrato(dt.Rows[linha]["id_cli"].ToString()))
                {
                    dt.Rows[linha].Delete();
                    linha--;
                }
            }
            comboBoxCliente.DataSource = dt;

            //preenche o comboBox da forma de pagamento, com todas as formas.
            AcessoFormaPagamento acessoFormaPag = new AcessoFormaPagamento();
            comboBoxFormaPagamento.DataSource = acessoFormaPag.selecionarTodos();
            comboBoxFormaPagamento.DisplayMember = "tipo_pgto";
            comboBoxFormaPagamento.ValueMember = "id_fpgto";

            //Preenche o comboBox Pacote com todos os pacotes.
            AcessoPacotes acessoPac = new AcessoPacotes();
            comboBoxPacote.DataSource = acessoPac.selecionarTodos();
            comboBoxPacote.DisplayMember = "desc_pacote";
            comboBoxPacote.ValueMember = "id_pacote";

            //verifica se variavel contrato está como true, caso sim, quer dizer que veio de uma lista,
            //logo, ele completa o contrato com aquele certo cliente.
            if(ClasseGlobal.Contrato)
            {
                //completa os componentes do form com o ID do cliente.
                completarPorID(ClasseGlobal.Id_cliente.ToString());
                ClasseGlobal.Contrato = false;
            }
            else
                //caso não esteja true a variavel contrato, ele completa normalmente utilizando o primeiro cliente
                //do comboBox cliente.
            completarPorCliente();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //chama método para completar componentes do form utilizando o id selecionado no comboBoxCliente
                completarPorCliente();
                comboBoxCliente.BackColor = Color.Empty;
            }
                //caso não tenha cliente selecionado ou o id esteja inválido, cai no catch, e não faz nada.
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //verifica se todos os campos obrigatórios foram preenchidos
            if (comboBoxCliente.SelectedValue != null &&
                comboBoxFormaPagamento.SelectedValue != null &&
                comboBoxPacote.SelectedValue != null &&
                txtBoxDiasParaVencer.Text != string.Empty &&
                txtBoxFunc.Text != string.Empty && txtBoxValorTotal.Text != string.Empty)
            {
                try
                {
                    //cria um dialogResult onde a mensagem de confirmação para alterar é mostrada
                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar?", "Confirmação Alteração"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
                    if (dr == DialogResult.Yes)
                    {
                        //caso seja confirmada a alteração, cadastra no banco
                        AcessoContrato acessoContrato = new AcessoContrato();
                        //método para dar update no banco, no valor, troca as , por .
                        acessoContrato.atualizar(comboBoxCliente.SelectedValue.ToString(), ClasseGlobal.Id_funcionario.ToString(),
                            comboBoxFormaPagamento.SelectedValue.ToString(), comboBoxPacote.SelectedValue.ToString(),
                            DateTime.Now, txtBoxValorTotal.Text.Replace(',', '.'));
                        MessageBox.Show("Atualizado com sucesso", "Atualização concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //após alterar, atualiza o comboBox
                        completarPorCliente();
                        comboBoxCliente.Focus();
                    }
                    else
                        MessageBox.Show("Alteração não confirmada.", "Confirmação negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Alteração não confirmada.", "Confirmação Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Erro Ao Alterar", "Erro na Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
        }

        //método para completar os componentes do form por cliente selecionado no comboBoxCliente
        private void completarPorCliente()
        {
            //variavel para não mudar no comboBox enquanto estiver atualizando-o
            buscar = true;
            AcessoContrato acessoCont = new AcessoContrato();
            if (comboBoxCliente.SelectedValue != null)
            {
                //completa os componentes com os dados do select por cliente selecionado
                acessoCont.selecionarComInnerJoin(comboBoxCliente.SelectedValue.ToString());
                comboBoxFormaPagamento.SelectedValue = acessoCont.ID_fpgto;
                comboBoxPacote.SelectedValue = acessoCont.ID_pacote;
                txtBoxFunc.Text = acessoCont.Nome_func;
                txtBoxDiasParaVencer.Text = acessoCont.DiasContrato.ToString();
                txtBoxValorTotal.Text = acessoCont.Valor_total.ToString();
                lblPago.Text = "Pago";
            }
            buscar = false;
        }

        //método para completar os componentes do form a partir de um ID de cliente, fornecido ao método
        private void completarPorID(String id)
        {
            //variavel para "desativar" o comboBox enquanto é preenchido
            buscar = true;
            AcessoContrato acessoCont = new AcessoContrato();
            //completa os componentes do form utilizando o select por ID do cliente
            acessoCont.selecionarComInnerJoin(id);
            comboBoxFormaPagamento.SelectedValue = acessoCont.ID_fpgto;
            comboBoxPacote.SelectedValue = acessoCont.ID_pacote;
            txtBoxFunc.Text = acessoCont.Nome_func;
            txtBoxDiasParaVencer.Text = acessoCont.DiasContrato.ToString();
            txtBoxValorTotal.Text = acessoCont.Valor_total.ToString();
            lblPago.Text = "Pago";
            buscar = false;
        }

        private void txtBoxFunc_TextChanged(object sender, EventArgs e)
        {
            //zera a cor do componente ao ser modificado
            txtBoxFunc.BackColor = Color.Empty;
        }

        private void comboBoxFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //tenta completar o txtBoxFunc com o nome do funcionario, utilizando o id
                comboBoxFormaPagamento.BackColor = Color.Empty;
                AcessoFuncionario acessoFunc = new AcessoFuncionario();
                txtBoxFunc.Text = acessoFunc.nomeFunc(ClasseGlobal.Id_funcionario.ToString());
                if (!buscar)
                    lblPago.Text = "Não Pago";
            }
                //caso não dê certo, o catch não altera nada.
            catch { }
        }

        private void comboBoxPacote_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //completa os componentes do form que sobraram utilizando o id do pacote selecionado
                comboBoxPacote.BackColor = Color.Empty;
                AcessoPacotes acessoPac = new AcessoPacotes();
                txtBoxValorTotal.Text = acessoPac.buscarValorPacote(comboBoxPacote.SelectedValue.ToString());
                DateTime dataVenc = DateTime.Now.AddDays(acessoPac.buscarDiasPacote(comboBoxPacote.SelectedValue.ToString()));
                TimeSpan conta = dataVenc - DateTime.Now;
                txtBoxDiasParaVencer.Text = conta.Days.ToString();
                lblVencido.Visible = false;
                groupBox4.Width = 205;

                //verifica se modificou algo no contrato, caso sim, aparece que o contrato ainda não foi pago.
                if (!buscar)
                {
                    if (conta.Days < 0)
                    {
                        lblVencido.Visible = true;
                        groupBox4.Width = 275;
                    }
                    lblPago.Text = "Não Pago";
                }
            }
                //caso não dê certo, cai no catch, que não fará nada.
            catch
            { }
        }

        private void txtBoxDiasParaVencer_TextChanged(object sender, EventArgs e)
        {
            //zera a cor do componente ao ser modificado
            txtBoxDiasParaVencer.BackColor = Color.Empty;
        }

        private void txtBoxValorTotal_TextChanged(object sender, EventArgs e)
        {
            //zera a cor do componente ao ser modificado
            txtBoxValorTotal.BackColor = Color.Empty;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
