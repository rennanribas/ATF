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
    public partial class FormSelecionarTreino : Form
    {
        String id_treino = string.Empty;
        DataTable listaFicha = new DataTable();

        public FormSelecionarTreino()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                if (listBox1.SelectedItem != null)
                {
                    int linha = listBox1.SelectedIndex;
                    String idTreino = listaFicha.Rows[linha]["id_treino"].ToString();
                    dataGridView1.DataSource = acessoTreinoEx.selecionarPorTreino(idTreino);
                    id_treino = idTreino;
                }
                arrumarDataGrid();
            }
            catch { }
        }

        private void FormSelecionarTreino_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string id_cliente = ClasseGlobal.Id_cliente.ToString();
            AcessoCliente acessoCli = new AcessoCliente();
            acessoCli.bucarPorID(id_cliente);
            lblNomeAluno.Text = "Aluno: " + acessoCli.Nome_cli;
            AcessoControleFrequencia acessoContFreq = new AcessoControleFrequencia();
            AcessoTreino acessoTreino = new AcessoTreino();

            listaFicha = acessoTreino.selecionarDoCliente(id_cliente);
            DataTable listaLoop = listaFicha;
            AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();

            for (int i = 0; i < listaLoop.Rows.Count; i++)
            {
                if (listaLoop.Rows[i]["visivel_treino"].ToString() == "1" &&
                    acessoTreinoEx.selecionarPorTreino(listaLoop.Rows[i]["id_treino"].ToString()).Rows.Count >0)
                {
                    String linhaTreino = listaLoop.Rows[i]["nome_treino"].ToString();
                    listBox1.Items.Add(linhaTreino);
                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (id_treino != string.Empty)
            {
                if (listaFicha.Rows[listBox1.SelectedIndex]["visivel_treino"].ToString() == "1" && dataGridView1.Rows.Count > 0)
                {
                    AcessoControleFrequencia acessoFrequencia = new AcessoControleFrequencia();
                    acessoFrequencia.inserir(id_treino, DateTime.Now.ToString());
                    MessageBox.Show("Treino registrado !", "Treino registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClasseGlobal.Id_treino = Convert.ToInt32(id_treino);
                    this.Close();
                }
                else
                    MessageBox.Show("Este treino está desabilitado ou sem exercicios, não há como registrar, habilite-o, ou cadastre exercícios e" +
                        " após tente denovo.", "Treino não habilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Por favor, selecione um treino para registrar.",
                    "Sem campo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void arrumarDataGrid()
        {
            dataGridView1.Columns["nome_ex"].HeaderText = "Exercício";
            dataGridView1.Columns["num_repeticoes"].HeaderText = "Repetições";
            dataGridView1.Columns["num_series"].HeaderText = "Séries";
            dataGridView1.Columns["nome_gmusculares"].HeaderText = "Grupo Muscular";
        }

        private void lblNomeAluno_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
