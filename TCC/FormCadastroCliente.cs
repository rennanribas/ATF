using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroCliente : Form
    {
        public FormCadastroCliente()
        {
            InitializeComponent();
        }

        private void FormCadastroCliente_Load(object sender, EventArgs e)
        {
            AcessoCliente acessoCli = new AcessoCliente();
            DataTable dt = acessoCli.selecionarTodos();
            int ultimoCodigo;
            try
            {
                ultimoCodigo = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["codigo_cli"]);
            }
            catch
            {
                ultimoCodigo = 0;
            }
            ultimoCodigo++;
            string codigoDeBarras = ultimoCodigo.ToString();
            for (int i = 0; codigoDeBarras.Length < 6; i++)
            {
                codigoDeBarras = "0" + codigoDeBarras;
            }
            txtBoxCB.Text = codigoDeBarras;
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (txtnome.Text != string.Empty && txtendereco.Text != string.Empty && cbBairro.Text != string.Empty
    && txtcidade.Text != string.Empty && txtestado.Text != string.Empty && txtCEP.Text != string.Empty
    && txtpais.Text != string.Empty && txtNascimento.MaskFull && txtTelefone.Text != string.Empty
    && txtRG.Text != string.Empty && Valida(txtCPF.Text) && txtemail.Text != string.Empty)
            {
                    AcessoCliente cli = new AcessoCliente();

                    String num_cli;

                    String nome_cli, end_cli, bairro_cli, cidade_cli, UF_cli, cep_cli,
                        pais_cli, sx_cli, estcivil_cli, email_cli, RG_cli, CPF_cli, fone_cli, dataCadastro, senha;
                    String dtnasc_cli;

                    num_cli = txtnumero.Text;

                    nome_cli = txtnome.Text;
                    end_cli = txtendereco.Text;
                    bairro_cli = cbBairro.Text;
                    cidade_cli = txtcidade.Text;
                    UF_cli = txtestado.Text;
                    cep_cli = txtCEP.Text;
                    pais_cli = txtpais.Text;
                    if (rbFeminino.Checked == true)
                    {
                        sx_cli = "F";
                    }
                    else
                    {
                        sx_cli = "M";
                    }
                    estcivil_cli = string.Empty;
                    switch (cbestado.Text)
                    {
                        case "Solteiro(a)": estcivil_cli = "S"; break;
                        case "Casado(a)": estcivil_cli = "C"; break;
                        case "Divorciado(a)": estcivil_cli = "D"; break;
                        case "Viúvo(a)": estcivil_cli = "V"; break;
                    }
                    if (estcivil_cli == string.Empty)
                        estcivil_cli = "S";
                    email_cli = txtemail.Text;
                    RG_cli = txtRG.Text;
                    CPF_cli = txtCPF.Text;
                    fone_cli = txtTelefone.Text;
                    dtnasc_cli = txtNascimento.Text;
                    dataCadastro = DateTime.Now.ToString("yyyy-MM-dd");
                    senha = txtCPF.Text;
                    try
                    {
                        cli.inserir(txtBoxCB.Text, nome_cli, end_cli, num_cli, bairro_cli, cidade_cli,
                            UF_cli, cep_cli, pais_cli, sx_cli, estcivil_cli, dtnasc_cli, fone_cli, email_cli,
                            RG_cli, CPF_cli, senha);

                        MessageBox.Show("Cliente Cadastrado Com Sucesso!", "Cadastrado Com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        AcessoCliente acessoCli = new AcessoCliente();
                        DataTable dt = acessoCli.selecionarTodos();
                        int ultimoCodigo = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["codigo_cli"]);
                        ultimoCodigo++;
                        string codigoDeBarras = ultimoCodigo.ToString();
                        for (int i = 0; codigoDeBarras.Length < 6; i++)
                        {
                            codigoDeBarras = "0" + codigoDeBarras;
                        }
                        txtBoxCB.Text = codigoDeBarras;
                        txtnome.Text = string.Empty;
                        txtendereco.Text = string.Empty;
                        txtnumero.Text = string.Empty;
                        txtCEP.Text = string.Empty;
                        cbBairro.Text = string.Empty;
                        txtcidade.Text = string.Empty;
                        txtestado.Text = string.Empty;
                        txtpais.Text = string.Empty;
                        txtTelefone.Text = string.Empty;
                        txtemail.Text = string.Empty;
                        txtNascimento.Text = string.Empty;
                        rbMasculino.Checked = false;
                        rbFeminino.Checked = false;
                        cbestado.Text = string.Empty;
                        txtRG.Text = string.Empty;
                        txtCPF.Text = string.Empty;

                        txtnome.Focus();
                    }
                    catch
                    {
                        MessageBox.Show("Houve algum erro, tente novamente.", "Erro ao cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else
            {
                if (!(txtnome.Text != string.Empty))
                    txtnome.BackColor = Color.Red;
                if (!(txtendereco.Text != string.Empty))
                    txtendereco.BackColor = Color.Red;
                if (!(cbBairro.Text != string.Empty))
                    cbBairro.BackColor = Color.Red;
                if (!(txtcidade.Text != string.Empty))
                    txtcidade.BackColor = Color.Red;
                if (!(txtestado.Text != string.Empty))
                    txtestado.BackColor = Color.Red;
                if (!(txtCEP.Text != string.Empty))
                    txtCEP.BackColor = Color.Red;
                if (!(txtpais.Text != string.Empty))
                    txtpais.BackColor = Color.Red;
                if (!(txtNascimento.MaskFull))
                    txtNascimento.BackColor = Color.Red;
                if (!(txtTelefone.Text != string.Empty))
                    txtTelefone.BackColor = Color.Red;
                if (!(txtRG.Text != string.Empty))
                    txtRG.BackColor = Color.Red;
                if (!Valida(txtCPF.Text))
                    txtCPF.BackColor = Color.Red;
                if (!(txtemail.Text != string.Empty))
                    txtemail.BackColor = Color.Red;
                MessageBox.Show("Por Favor, Preencha todos os Campos em vermelho!", "Falta de Informações para Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtestado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar) || txtestado.TextLength >= 2) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Substring(0,5) + txtCEP.Text.Substring(6,3);
            try
            {
                ConexaoEndereco.criar_Conexao();
                AcessoEndereco acesso = new AcessoEndereco();
                acesso.bucarPorCEP(cep);
                txtcidade.Text = acesso.Cidade_cli;
                txtendereco.Text = acesso.End_cli;
                txtestado.Text = acesso.UF_cli1;
                txtpais.Text = acesso.Pais_cli;
                string id_cidade = acesso.Id_cidade;
                cbBairro.DataSource = acesso.selecionarBairro(id_cidade);
                cbBairro.DisplayMember = "bai_no";
                cbBairro.ValueMember = "bai_no";
                cbBairro.Focus();
            }
            catch
            {
                MessageBox.Show("Erro, CEP Inválido", "Erro no CEP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void textvenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == ',')
                e.KeyChar = '.';
        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            txtnome.BackColor = Color.Empty;
        }

        private void txtCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtCEP.BackColor = Color.Empty;
        }

        private void txtendereco_TextChanged(object sender, EventArgs e)
        {
            txtendereco.BackColor = Color.Empty;
        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {
            txtnumero.BackColor = Color.Empty;
        }

        private void cbBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBairro.BackColor = Color.Empty;
        }

        private void txtcidade_TextChanged(object sender, EventArgs e)
        {
            txtcidade.BackColor = Color.Empty;
        }

        private void txtestado_TextChanged(object sender, EventArgs e)
        {
            txtestado.BackColor = Color.Empty;
        }

        private void txtpais_TextChanged(object sender, EventArgs e)
        {
            txtpais.BackColor = Color.Empty;
        }

        private void cbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbestado.BackColor = Color.Empty;
        }

        private void txtNascimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtNascimento.BackColor = Color.Empty;
        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtTelefone.BackColor = Color.Empty;
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            txtemail.BackColor = Color.Empty;
        }

        private void txtRG_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtRG.BackColor = Color.Empty;
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtCPF.BackColor = Color.Empty;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtnome.Text = string.Empty;
            txtendereco.Text = string.Empty;
            txtnumero.Text = string.Empty;
            txtCEP.Text = string.Empty;
            cbBairro.Text = string.Empty;
            txtcidade.Text = string.Empty;
            txtestado.Text = string.Empty;
            txtpais.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtNascimento.Text = string.Empty;
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
            cbestado.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtnome.Focus();
        }

        private void cbBairro_TextChanged(object sender, EventArgs e)
        {
            cbBairro.BackColor = Color.White;
        }

        private void txtNascimento_TextChanged(object sender, EventArgs e)
        {
            txtNascimento.BackColor = Color.White;
        }

        public bool Valida(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCPF.BackColor = Color.White;
            if ((!char.IsNumber(e.KeyChar) && e.KeyChar != '\b') || (txtCPF.Text.Length == 11 && e.KeyChar != '\b'))
                e.Handled = true;
        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
