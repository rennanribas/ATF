using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormBuscarFichaCliente : Form
    {
        DataTable listaFicha = new DataTable();
        String id_treino = string.Empty;

        public FormBuscarFichaCliente()
        {
            InitializeComponent();
        }

        private void FormBuscarFichaCliente_Load(object sender, EventArgs e)
        {
            //preenche o comboBox do cliente com todos os alunos
            AcessoCliente acessoCli = new AcessoCliente();
            cbAluno.DataSource = acessoCli.selecionarTodos();
            cbAluno.DisplayMember = "nome_cli";
            cbAluno.ValueMember = "id_cli";

            try
            {
                //limpa os items do listBox, atualiza o id_cliente, e busca utilizando o id, pelo cliente
                listBox1.Items.Clear();
                string id_cliente = (cbAluno.SelectedValue).ToString();
                acessoCli.bucarPorID(id_cliente);
                try
                {
                    lblNome.Text = acessoCli.Nome_cli;
                    lblDataCadastro.Text = "Cliente desde " + acessoCli.Data_cadastro.ToLongDateString();
                    AcessoControleFrequencia acessoContFreq = new AcessoControleFrequencia();
                    AcessoTreino acessoTreino = new AcessoTreino();

                    //Mostra o ultimo treino, caso haja, caso não, mostra que hoje será o primeiro treino.
                    if (acessoContFreq.ultimoTreino(id_cliente))
                    {
                        acessoTreino.buscarporID(acessoContFreq.ID_treino.ToString());
                        lblUltimoTreino.Text = "Ultimo treino foi no dia " + acessoContFreq.Data_frequencia.ToShortDateString() +
                            ", às " + acessoContFreq.Data_frequencia.Hour.ToString() + " hora(s) e " +
                            acessoContFreq.Data_frequencia.Minute.ToString() + " minuto(s), esse foi o treino " +
                            acessoTreino.Nome_treino + ".";
                    }
                    else
                    {       
                        lblUltimoTreino.Text = "Hoje será o primeiro treino.";
                    }

                    listaFicha = acessoTreino.selecionarDoCliente(id_cliente);
                    DataTable listaLoop = listaFicha;

                    //percorre a lista de treinos do cliente, e coloca desabilitado ou habilitado conforme estiver no banco
                    for (int i = 0; i < listaLoop.Rows.Count; i++)
                    {
                        if (listaLoop.Rows[i]["visivel_treino"].ToString() == "1")
                        {
                            String linhaTreino = listaLoop.Rows[i]["nome_treino"].ToString();
                            listBox1.Items.Add(linhaTreino + " - habilitado");
                        }
                        else
                        {
                            String linhaTreino = listaLoop.Rows[i]["nome_treino"].ToString();
                            listBox1.Items.Add(linhaTreino + " - desabilitado");
                        }
                    }
                }
                catch
                {
                    //caso dê erro, exibe a mensagem de não possuir treinos cadastrados
                    lblUltimoTreino.Text = "Não possui treinos cadastrados.";
                    btnImprimir.Visible = false;
                    btnTreinar.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //verifica se algum treino foi selecionado, caso sim, pesquisa a ficha deste treino, e exibe no datagrid
                AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                if (listBox1.SelectedItem != null)
                {
                    int linha = listBox1.SelectedIndex;
                    String idTreino = listaFicha.Rows[linha]["id_treino"].ToString();
                    dataGridView1.DataSource = acessoTreinoEx.selecionarPorTreino(idTreino);
                    arrumarDataGrid();
                    lblTreino.Text = listBox1.SelectedItem.ToString();
                    id_treino = idTreino;
                }
            }
            catch { }
        }

        private void btnTreinar_Click(object sender, EventArgs e)
        {
            //caso haja um treino selecionado, e o mesmo esteja habilitado insere na tabela controle frequencia um novo treino
            if (id_treino != string.Empty)
            {
                if (listaFicha.Rows[listBox1.SelectedIndex]["visivel_treino"].ToString() == "1")
                {
                    AcessoControleFrequencia acessoFrequencia = new AcessoControleFrequencia();
                    acessoFrequencia.inserir(id_treino, DateTime.Now.ToString());
                    MessageBox.Show("Treino registrado !", "Treino registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClasseGlobal.Id_treino = Convert.ToInt32(id_treino);
                    this.Close();
                }
                else
                    MessageBox.Show("Este treino está desabilitado, não há como treinar, habilite-o e" +
                        " após tente denovo.", "Treino não habilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Por favor, selecione um treino para registrar.",
                    "Sem campo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (id_treino != string.Empty)
            {
                if (listaFicha.Rows[listBox1.SelectedIndex]["visivel_treino"].ToString() == "1")
                {
                    //caso haja um treino selecionado e o treino esteja habilitado, preenche a classe estática
                    //com o id do treino, e chama o Form do relatorio
                    ClasseGlobal.Id_treino = Convert.ToInt32(id_treino);
                    this.Close();
                    FormRelatorioTreinoExercicio frmRelatorio = new FormRelatorioTreinoExercicio();
                    frmRelatorio.MdiParent = this.MdiParent;
                    frmRelatorio.Show();
                }
                else
                    MessageBox.Show("Este treino está desabilitado, não há como exibir um relatorio para imprimir, habilite-o na tela \"Alterar Treino\" e" +
                        " após tente denovo.", "Treino não habilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Por favor, selecione um treino para imprimir.",
                    "Sem campo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //zera os componentes do form, e busca o cliente por id
                dataGridView1.DataSource = new DataTable();
                lblTreino.Text = string.Empty;
                listBox1.Items.Clear();
                AcessoCliente acessoCli = new AcessoCliente();
                string id_cliente = (cbAluno.SelectedValue).ToString();
                acessoCli.bucarPorID(id_cliente);
                try
                {
                    //preenche os componentes com os novos dados do novo cliente selecionado
                    lblNome.Text = acessoCli.Nome_cli;
                    lblDataCadastro.Text = "Cliente desde " + acessoCli.Data_cadastro.ToLongDateString();
                    AcessoControleFrequencia acessoContFreq = new AcessoControleFrequencia();
                    AcessoTreino acessoTreino = new AcessoTreino();

                    //caso o cliente tenha um ultimo treino, exibe qual o mesmo, caso não, exibe que é o primeiro treino
                    if (acessoContFreq.ultimoTreino(id_cliente))
                    {
                        acessoTreino.buscarporID(acessoContFreq.ID_treino.ToString());
                        lblUltimoTreino.Text = "Ultimo treino foi no dia " + acessoContFreq.Data_frequencia.ToShortDateString() +
                            ", às " + acessoContFreq.Data_frequencia.Hour.ToString() + " hora(s) e " +
                            acessoContFreq.Data_frequencia.Minute.ToString() + " minuto(s), esse foi o treino " +
                            acessoTreino.Nome_treino + ".";
                    }
                    else
                    {
                        lblUltimoTreino.Text = "Hoje será o primeiro treino.";
                    }

                    listaFicha = acessoTreino.selecionarDoCliente(id_cliente);
                    DataTable listaLoop = listaFicha;

                    //preenche o list box e faz o loop para verificar se é habilitado ou desabilitado o treino
                    for (int i = 0; i < listaLoop.Rows.Count; i++)
                    {
                        if (listaLoop.Rows[i]["visivel_treino"].ToString() == "1")
                        {
                            String linhaTreino = listaLoop.Rows[i]["nome_treino"].ToString();
                            listBox1.Items.Add(linhaTreino + " - habilitado");
                        }
                        else
                        {
                            String linhaTreino = listaLoop.Rows[i]["nome_treino"].ToString();
                            listBox1.Items.Add(linhaTreino + " - desabilitado");
                        }
                    }
                }
                catch
                {
                    //caso dê erro, mostra que não possui treinos cadastrados
                    lblUltimoTreino.Text = "Não possui treinos cadastrados.";
                    btnImprimir.Visible = false;
                    btnTreinar.Visible = false;
                }
            }
            catch
            {
            }
        }
        private void arrumarDataGrid()
        {
            //arruma o nome das colunas do datagridView para ser exibido
            dataGridView1.Columns["nome_ex"].HeaderText = "Exercício";
            dataGridView1.Columns["num_repeticoes"].HeaderText = "Repetições";
            dataGridView1.Columns["num_series"].HeaderText = "Séries";
            dataGridView1.Columns["nome_gmusculares"].HeaderText = "Grupo Muscular";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTreino_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
