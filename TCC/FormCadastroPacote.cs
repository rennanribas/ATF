using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroPacote : Form
    {
        public FormCadastroPacote()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este pacote?", "Confirmação de Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (txtBoxDesc.Text != string.Empty)
            {
                if (dr == DialogResult.Yes)
                {
                    AcessoPacotes acessoPac = new AcessoPacotes();
                    if (txtBoxValor.Text == string.Empty)
                        txtBoxValor.Text = "0";
                    acessoPac.inserir(txtBoxDesc.Text, txtBoxValor.Text.ToString(), nUpDownDias.Value.ToString());
                    MessageBox.Show("Cadastrado com sucesso", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Cadastro não confirmado.", "Confirmação Negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para cadastrar.", "Campos Não Preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBoxDesc.Text = string.Empty;
            txtBoxValor.Text = string.Empty;
            nUpDownDias.Value = 0;
        }

        private void txtBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.' || e.KeyChar == '\b')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void FormCadastroPacote_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxValor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtBoxDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
