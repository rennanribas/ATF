using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormVerificarCodigo : Form
    {
        public FormVerificarCodigo()
        {
            InitializeComponent();
        }

        private void FormVerificarCodigo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "12345")
            {
                Hide();
                FormCadastroFuncionario frmCadastroFunc = new FormCadastroFuncionario();
                frmCadastroFunc.Show();
            }
            else
            {
                MessageBox.Show("Código inválido", "Código Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = string.Empty;
                txtCodigo.Focus();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (txtCodigo.Text == "12345")
                {
                    Hide();
                    FormCadastroFuncionario frmCadastroFunc = new FormCadastroFuncionario();
                    frmCadastroFunc.Show();
                }
                else
                {
                    MessageBox.Show("Código inválido", "Código Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
            }
        }
    }
}
