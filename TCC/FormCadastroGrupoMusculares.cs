using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroGrupoMusculares : Form
    {
        public FormCadastroGrupoMusculares()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtGrupoMuscular.Text != string.Empty)
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este grupo muscular ?"
                    , "Confirmação cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    AcessoGruposMusculares acesso = new AcessoGruposMusculares();
                    acesso.inserir(txtGrupoMuscular.Text);
                    MessageBox.Show("Grupo Muscular Cadastrado Com Sucesso!", "Cadastrado Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGrupoMuscular.Text = string.Empty;
                    txtGrupoMuscular.Focus();
                }
                else
                    MessageBox.Show("Cadastro não confirmado.", "Confirmação negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Preencha todos os campos para cadastrar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormCadastroGrupoMusculares_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtGrupoMuscular.Text = string.Empty;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtGrupoMuscular.Text = string.Empty;
        }
    }
}
