using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroTreino : Form
    {
        DataTable listaFicha = new DataTable();
        String id_treino = string.Empty;

        public FormCadastroTreino()
        {
            InitializeComponent();
        }

        private void FormCadastroTreino_Load(object sender, EventArgs e)
        {
            AcessoCliente acessoCli = new AcessoCliente();
            cBCliente.DataSource = acessoCli.selecionarTodos();
            cBCliente.ValueMember = "id_cli";
            cBCliente.DisplayMember = "nome_cli";

            AcessoGruposMusculares acessoGrupo = new AcessoGruposMusculares();
            cbGrupoMusc.DataSource = acessoGrupo.selecionarTodos();
            cbGrupoMusc.DisplayMember = "nome_gmusculares";
            cbGrupoMusc.ValueMember = "id_gmusculares";

            AcessoExercicio acessoEx = new AcessoExercicio();
            cBExercicio.DataSource = acessoEx.selecionarPorGrupo(cbGrupoMusc.SelectedValue.ToString());
            cBExercicio.ValueMember = "id_ex";
            cBExercicio.DisplayMember = "nome_ex";
        }

        private void btnAddTreino_Click(object sender, EventArgs e)
        {
            if (cBCliente.SelectedValue != null)
            {
                if (txtBoxTreino.Text != string.Empty)
                {
                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este treino?",
                        "Confirmação cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        AcessoTreino acessoTreino = new AcessoTreino();
                        acessoTreino.inserir(ClasseGlobal.Id_funcionario.ToString(),
                            cBCliente.SelectedValue.ToString(), txtBoxTreino.Text);

                        listaFicha = acessoTreino.selecionarDoCliente(cBCliente.SelectedValue.ToString());

                        listBox1.Items.Clear();
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
                        MessageBox.Show("Treino adicionado!", "Cadastro concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBoxTreino.Text = string.Empty;
                        txtBoxTreino.Focus();
                    }
                    else
                        MessageBox.Show("Cadastro não confirmado.", "Confirmação negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Digite um nome de um treino para cadastrar.", "Campo nulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBoxTreino.Focus();
                }
            }
            else
            {
                MessageBox.Show("Primeiro selecione um cliente.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cBCliente.Focus();
            }
        } 

        private void btnCadastrarTreinoEx_Click(object sender, EventArgs e)
        {
            if (txtBoxRepeticoes.Text != string.Empty && txtBoxSeries.Text != string.Empty && id_treino != string.Empty &&
                cBExercicio.SelectedValue != null)
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este exercício?", "Confirmação cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                    acessoTreinoEx.inserir(id_treino.ToString(), cBExercicio.SelectedValue.ToString(), txtBoxRepeticoes.Text,
                        txtBoxSeries.Text);
                    dataGridView1.DataSource = acessoTreinoEx.selecionarPorTreino(id_treino.ToString());
                    arrumarDataGrid();
                    MessageBox.Show("Exercicio adicionado ao treino " + lblTituloTreino.Text,
                        "Adicionado com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBoxRepeticoes.Text = string.Empty;
                    txtBoxSeries.Text = string.Empty;
                    cbGrupoMusc.Focus();
                }
                else
                    MessageBox.Show("Cadastro não confirmado.", "Confirmação negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Verifique todos os campos, e selecione um treino para cadastrar um exercicio dentro da ficha.",
                    "Erro ao adicionar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtBoxSeries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtBoxRepeticoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();

            if (listBox1.SelectedItem != null)
            {
                int linha = listBox1.SelectedIndex;
                String idTreino = listaFicha.Rows[linha]["id_treino"].ToString();
                dataGridView1.DataSource = acessoTreinoEx.selecionarPorTreino(idTreino);
                arrumarDataGrid();
                lblTituloTreino.Text = listBox1.SelectedItem.ToString();
                id_treino = idTreino;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        
        private void txtBoxTreino_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
        }

        private void cBCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listaFicha = new DataTable();
                dataGridView1.DataSource = new DataTable();
                lblTituloTreino.Text = string.Empty;
                id_treino = string.Empty;

                AcessoTreino acessoTreino = new AcessoTreino();
                listaFicha = acessoTreino.selecionarDoCliente(cBCliente.SelectedValue.ToString());

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
            catch
            {
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBoxTreino.Text = string.Empty;
            txtBoxSeries.Text = string.Empty;
            txtBoxRepeticoes.Text = string.Empty;
            cBCliente.Focus();
        }

        private void cbGrupoMusc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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

        private void arrumarDataGrid()
        {
            dataGridView1.Columns["nome_ex"].HeaderText = "Exercício";
            dataGridView1.Columns["num_repeticoes"].HeaderText = "Repetições";
            dataGridView1.Columns["num_series"].HeaderText = "Séries";
            dataGridView1.Columns["nome_gmusculares"].HeaderText = "Grupo Muscular";
        }
    }
}
