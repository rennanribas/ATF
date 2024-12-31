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
    public partial class FormAlterarExercicio : Form
    {
        bool naoAlterada = true;
        public FormAlterarExercicio()
        {
            InitializeComponent();
        }

        private void FormAlterarExercicio_Load(object sender, EventArgs e)
        {
            //preenche os comboBox, usando o primeiro cliente selecionado do comboBoxExercicio
            //preenche também o pictureBox
            AcessoExercicio acessoExercicio = new AcessoExercicio();
            comboBoxExercicio.DataSource = acessoExercicio.selecionarTodos();
            comboBoxExercicio.DisplayMember = "nome_ex";
            comboBoxExercicio.ValueMember = "id_ex";

            AcessoGruposMusculares acessoGrupos = new AcessoGruposMusculares();
            comboBoxGrupoMuscular.DataSource = acessoGrupos.selecionarTodos();
            comboBoxGrupoMuscular.DisplayMember = "nome_gmusculares";
            comboBoxGrupoMuscular.ValueMember = "id_gmusculares";

            acessoExercicio.busrcarporID(comboBoxExercicio.SelectedValue.ToString());
            comboBoxGrupoMuscular.SelectedValue = acessoExercicio.ID_gmusculares1.ToString();
            txtBoxNomeExercicio.Text = acessoExercicio.Nome_ex;
            pictureBox1.Image = Image.FromFile(acessoExercicio.Caminho_gif);
            naoAlterada = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica se os campos obrigatorios estão preenchidos
                if (comboBoxExercicio.SelectedValue != null && comboBoxGrupoMuscular.SelectedValue != null)
                {
                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar este exercício?", "Confirmação alteração"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //caso o usuario confirme a alteração, altera conforme a imagem estiver modificada ou não
                        AcessoExercicio acessoExercicio = new AcessoExercicio();
                        acessoExercicio.busrcarporID(comboBoxExercicio.SelectedValue.ToString());
                        string caminhoStart = Application.StartupPath.ToString();
                        string[] nomeImagem = acessoExercicio.Caminho_gif.Split('\\');
                        if (txtCaminhoImg.Text == string.Empty &&
                            nomeImagem[nomeImagem.Length - 1].ToString() != "0.gif" &&
                            !naoAlterada)
                        {
                            pictureBox1.Image.Dispose();
                            File.Delete(acessoExercicio.Caminho_gif);
                            acessoExercicio.alterarExercicio(comboBoxGrupoMuscular.SelectedValue.ToString(),
                                txtBoxNomeExercicio.Text, comboBoxExercicio.SelectedValue.ToString(),
                                caminhoStart + "\\gifs\\0.gif");
                        }
                        if(txtCaminhoImg.Text == string.Empty &&
                            nomeImagem[nomeImagem.Length - 1].ToString() == "0.gif" &&
                            !naoAlterada)
                            acessoExercicio.alterarExercicio(comboBoxGrupoMuscular.SelectedValue.ToString(),
                                txtBoxNomeExercicio.Text, comboBoxExercicio.SelectedValue.ToString(),
                                caminhoStart + "\\gifs\\0.gif");
                        if(naoAlterada)
                            acessoExercicio.alterarExercicio(comboBoxGrupoMuscular.SelectedValue.ToString(),
                                txtBoxNomeExercicio.Text, comboBoxExercicio.SelectedValue.ToString(),
                                acessoExercicio.Caminho_gif);

                        if(txtCaminhoImg.Text != string.Empty)
                        {
                            acessoExercicio.alterarExercicio(comboBoxGrupoMuscular.SelectedValue.ToString(),
                                txtBoxNomeExercicio.Text, comboBoxExercicio.SelectedValue.ToString(),
                                caminhoStart + "\\gifs\\" + comboBoxExercicio.SelectedValue.ToString() + ".gif");
                            pictureBox1.Image.Save(caminhoStart + "\\temp.gif");
                            if (nomeImagem[nomeImagem.Length - 1].ToString() != "0.gif")
                            {
                                pictureBox1.Image.Dispose();
                                File.Delete(acessoExercicio.Caminho_gif);
                            }
                            Image gif = Image.FromFile(caminhoStart + "\\temp.gif");
                            gif.Save(caminhoStart + "\\gifs\\" + comboBoxExercicio.SelectedValue.ToString() + ".gif");
                            gif.Dispose();
                            File.Delete(caminhoStart + "\\temp.gif");
                        }
                        comboBoxExercicio.DataSource = acessoExercicio.selecionarTodos();
                        comboBoxExercicio.DisplayMember = "nome_ex";
                        comboBoxExercicio.ValueMember = "id_ex";
                        acessoExercicio.busrcarporID(comboBoxExercicio.SelectedValue.ToString());
                        comboBoxGrupoMuscular.SelectedValue = acessoExercicio.ID_gmusculares1.ToString();
                        txtBoxNomeExercicio.Text = acessoExercicio.Nome_ex;
                        pictureBox1.Image = Image.FromFile(acessoExercicio.Caminho_gif);
                        MessageBox.Show("Alterado com sucesso.", "Alteração Concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxExercicio.Focus();
                    }
                    else
                        MessageBox.Show("Alteração não confirmada.", "Confirmação negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Preencha os dois valores para cadastrar.", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxExercicio.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao alterar.", "Erro na alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxExercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //completa os campos por exercicio, pegando o id do exercicio do comboBoxExercicio
                AcessoExercicio acessoExercicio = new AcessoExercicio();
                AcessoGruposMusculares acessoGrupos = new AcessoGruposMusculares();
                comboBoxGrupoMuscular.DataSource = acessoGrupos.selecionarTodos();
                comboBoxGrupoMuscular.DisplayMember = "nome_gmusculares";
                comboBoxGrupoMuscular.ValueMember = "id_gmusculares";

                acessoExercicio.busrcarporID(comboBoxExercicio.SelectedValue.ToString());
                comboBoxGrupoMuscular.SelectedValue = acessoExercicio.ID_gmusculares1.ToString();
                txtBoxNomeExercicio.Text = acessoExercicio.Nome_ex;
                pictureBox1.Image = Image.FromFile(acessoExercicio.Caminho_gif);
                naoAlterada = true;
            }
            catch { }
        }

        private void comboBoxGrupoMuscular_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ao ser precionado, muda a cor para empty, assim, caso esteja vermelha, volta ao normal
            comboBoxGrupoMuscular.BackColor = Color.Empty;
        }

        private void btnProcurarImg_Click(object sender, EventArgs e)
        {
            //chama o método "ShowDialog" da classe OpenDialog para buscar uma imagem
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //ao a imagem ser selecionada, o caminho fica no textBoxCaminhoImg
            //e já preenche o pictureBox
            txtCaminhoImg.Text = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            //Remove a imagem do pictureBox, apaga o txtCaminho, e coloca a viravel naoAlterada para true
            string caminhoStart = Application.StartupPath.ToString();
            pictureBox1.Image = Image.FromFile(caminhoStart + "\\gifs\\0.gif");
            txtCaminhoImg.Text = string.Empty;
            naoAlterada = false;
        }
    }
}
