using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarTreino : Form
    {
        DataTable listaFicha;
        string id_treino;

        public FormAlterarTreino()
        {
            InitializeComponent();
        }

        private void FormAlterarTreino_Load(object sender, EventArgs e)
        {
            //completa os componentes do form conforme o primeiro treino da lista.
            AcessoCliente acessoCli = new AcessoCliente();
            cBCliente.DataSource = acessoCli.selecionarTodos();
            cBCliente.ValueMember = "id_cli";
            cBCliente.DisplayMember = "nome_cli";

            listBox1.Items.Clear();
            listaFicha = new DataTable();
            dataGridView1.DataSource = new DataTable();
            id_treino = string.Empty;

            AcessoGruposMusculares acessoGrupo = new AcessoGruposMusculares();
            cbGrupoMusc.DataSource = acessoGrupo.selecionarTodos();
            cbGrupoMusc.DisplayMember = "nome_gmusculares";
            cbGrupoMusc.ValueMember = "id_gmusculares";


            AcessoExercicio acessoEx = new AcessoExercicio();
            cBExercicio.DataSource = acessoEx.selecionarPorGrupo(cbGrupoMusc.SelectedValue.ToString());
            cBExercicio.ValueMember = "id_ex";
            cBExercicio.DisplayMember = "nome_ex";

            //chama método para completar o listBox
            completarListBox();

            //seleciona o primeiro item da lista
            listBox1.SetSelected(0, true);
        }

        private void btnInvisivel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //caso haja um item selecionado, altera no banco a visibilidade
                AcessoTreino acessoTreino = new AcessoTreino();
                int linha = listBox1.SelectedIndex;
                String idTreino = listaFicha.Rows[linha]["id_treino"].ToString();
                id_treino = idTreino;
                acessoTreino.visibilidadeTreino(id_treino, "0");
                completarListBox();
            }
        }

        private void btnVisivel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                //caso tenha um item selecionado no listBox, altera no banco de dados
                AcessoTreino acessoTreino = new AcessoTreino();
                int linha = listBox1.SelectedIndex;
                String idTreino = listaFicha.Rows[linha]["id_treino"].ToString();
                id_treino = idTreino;
                acessoTreino.visibilidadeTreino(id_treino, "1");
                completarListBox();
            }
        }

        public void completarListBox()
        {
            //método para completar list Box
            listBox1.Items.Clear();
            AcessoTreino acessoTreino = new AcessoTreino();
            listaFicha = acessoTreino.selecionarDoCliente(cBCliente.SelectedValue.ToString());

            //verifica a visibilidade, caso esteja visivel, adiciona "habilitado" ao item, caso não, "desabilitado"
            for (int i = 0; i < listaFicha.Rows.Count; i++)
            {
                if (listaFicha.Rows[i]["visivel_treino"].ToString() == "1")
                {
                    String linhaTreino = listaFicha.Rows[i]["nome_treino"].ToString();
                    listBox1.Items.Add(linhaTreino + " - habilitado");
                }
                else
                {
                    String linhaTreino = listaFicha.Rows[i]["nome_treino"].ToString();
                    listBox1.Items.Add(linhaTreino + " - desabilitado");
                }
            }
        }

        private void btnCadastrarTreinoEx_Click(object sender, EventArgs e)
        {
            if (txtBoxRepeticoes.Text != string.Empty && txtBoxSeries.Text != string.Empty && id_treino != string.Empty &&
    cBExercicio.SelectedValue != null)
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este treino?", "Confirmação cadastro",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //caso o usuario confirme a alteração e os campos obrigatorios estejam preenchidos, cadastra no banco
                    //de dados os novos dados
                    AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                    acessoTreinoEx.inserir(id_treino.ToString(), cBExercicio.SelectedValue.ToString(), txtBoxRepeticoes.Text,
                        txtBoxSeries.Text);
                    dataGridView1.DataSource = acessoTreinoEx.selecionarPorTreino(id_treino.ToString());
                    arrumarDataGrid();
                    MessageBox.Show("Exercicio adicionado ao treino ",
                        "Adicionado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //após cadastrar, preenche os componentes com os novos dados do banco
                    txtBoxSeries.Text = string.Empty;
                    txtBoxRepeticoes.Text = string.Empty;
                    AcessoGruposMusculares acessoG = new AcessoGruposMusculares();
                    cbGrupoMusc.DataSource = acessoG.selecionarTodos();
                    cbGrupoMusc.DisplayMember = "nome_gmusculares";
                    cbGrupoMusc.ValueMember = "id_gmusculares";
                }
                else
                    MessageBox.Show("Cadastro não confirmado.", "Confirmação negada", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Verifique todos os campos, e selecione um treino para cadastrar um exercicio dentro da ficha.",
                    "Erro ao adicionar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cBCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //limpa o items do listBox, chama o metodo completarListBox e completa denovo, com os dados do novo cliente
                //selecionado
                listBox1.Items.Clear();
                listaFicha = new DataTable();
                dataGridView1.DataSource = new DataTable();
                id_treino = string.Empty;
                txtBoxNomeTreino.Text = string.Empty;

                cBCliente.BackColor = Color.Empty;

                completarListBox();
                listBox1.SetSelected(0, true);
            }
            catch { }
        }

        private void cBExercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //volta a cor do componente ao normal
            cBExercicio.BackColor = Color.Empty;
        }

        private void txtBoxSeries_TextChanged(object sender, EventArgs e)
        {
            //volta a cor do componente ao normal
            txtBoxSeries.BackColor = Color.Empty; ;
        }

        private void txtBoxRepeticoes_TextChanged(object sender, EventArgs e)
        {
            //volta a cor do componente ao normal
            txtBoxRepeticoes.BackColor = Color.Empty;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //limpa os componentes
            cBCliente.Text = string.Empty;
            cBExercicio.Text = string.Empty;
            txtBoxSeries.Text = string.Empty;
            txtBoxRepeticoes.Text = string.Empty;
        }

        private void arrumarDataGrid()
        {
            //método para arrumar os nomes das columas no datagridView
            dataGridView1.Columns["nome_ex"].HeaderText = "Exercício";
            dataGridView1.Columns["num_repeticoes"].HeaderText = "Repetições";
            dataGridView1.Columns["num_series"].HeaderText = "Séries";
            dataGridView1.Columns["nome_gmusculares"].HeaderText = "Grupo Muscular";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //completa a ficha de treino, comforme o treino selecionado no listBox
                AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                if (listBox1.SelectedItem != null)
                {
                    int linha = listBox1.SelectedIndex;
                    String idTreino = listaFicha.Rows[linha]["id_treino"].ToString();
                    dataGridView1.DataSource = acessoTreinoEx.selecionarPorTreino(idTreino);
                    arrumarDataGrid();
                    id_treino = idTreino;
                    AcessoTreino acessoTreino = new AcessoTreino();
                    acessoTreino.buscarporID(id_treino);
                    txtBoxNomeTreino.Text = acessoTreino.Nome_treino;
                }
            }
            catch { }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_treino != string.Empty)
                {
                    if (txtBoxNomeTreino.Text != string.Empty)
                    {
                        //caso os campos obrigatorios não estejam nulos, cadastra no banco, e atualiza o listBox
                        AcessoTreino acessoTreino = new AcessoTreino();
                        acessoTreino.atualizarNome(id_treino, txtBoxNomeTreino.Text);
                        MessageBox.Show("Alterado com sucesso!", "Alteração Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        completarListBox();
                        listBox1.SetSelected(0, true);
                    }
                    else
                        MessageBox.Show("Digite o nome do treino para alterar.", "Campo necessario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Selecione um treino para alterar.", "Treino não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch { }
        }

        private void cbGrupoMusc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //atualiza o comboBox exercicio com aqueles exercicios que só pertencem ao grupo muscular
                cBExercicio.Text = string.Empty;
                AcessoExercicio acessoEx = new AcessoExercicio();
                cBExercicio.DataSource = acessoEx.selecionarPorGrupo(cbGrupoMusc.SelectedValue.ToString());
                cBExercicio.ValueMember = "id_ex";
                cBExercicio.DisplayMember = "nome_ex";
            }
            catch
            {
            }
        }
    }
}
