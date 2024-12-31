using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TCC
{
    public partial class FormCadastroExercicio : Form
    {
        public FormCadastroExercicio()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (cbGrupoMuscular.SelectedValue != null && txtExercicio.Text != string.Empty)
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este exercício?",
                    "Confirmação Exercício", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    AcessoExercicio acesso = new AcessoExercicio();
                    DataTable dt = acesso.selecionarTodos();
                    int proximoId;
                    try
                    {
                        proximoId = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["ID_ex"]) + 1;
                    }
                    catch
                    {
                        proximoId = 1;
                    }
                    string caminhoStart = Application.StartupPath.ToString();
                    string caminhoPastaGifs = caminhoStart + "\\gifs\\" + proximoId.ToString() + ".gif";
                    if (txtCaminhoImg.Text != string.Empty)
                    {
                        File.Copy(txtCaminhoImg.Text, caminhoPastaGifs);
                        acesso.inserir(cbGrupoMuscular.SelectedValue.ToString(), txtExercicio.Text,
                            caminhoPastaGifs);
                    }
                    else
                    {
                        caminhoPastaGifs = caminhoStart + "\\gifs\\0.gif";
                        acesso.inserir(cbGrupoMuscular.SelectedValue.ToString(), txtExercicio.Text,
                            caminhoPastaGifs);
                    }
                    MessageBox.Show("Exercício Cadastrado Com Sucesso!", "Exerício cadastrado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCaminhoImg.Text = string.Empty;
                    txtExercicio.Text = string.Empty;
                    CompletarComboBox();
                    cbGrupoMuscular.Focus();
                }
                else
                    MessageBox.Show("Cadastro não confirmado.", "Confirmação negada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Digite todos os dados primeiro.", "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGrupoMuscular.Focus();
            }
        }

        public void CompletarComboBox()
        {
            AcessoGruposMusculares acessoMuscular = new AcessoGruposMusculares();
            cbGrupoMuscular.DataSource = acessoMuscular.selecionarTodos();
            cbGrupoMuscular.DisplayMember = "nome_gmusculares";
            cbGrupoMuscular.ValueMember = "ID_gmusculares";
        }

        private void FormCadastroExercicio_Load(object sender, EventArgs e)
        {
            CompletarComboBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtExercicio.Text = string.Empty;
            cbGrupoMuscular.Focus();
        }

        private void btnProcurarImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtCaminhoImg.Text = openFileDialog1.FileName;
        }

        private void cbGrupoMuscular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
