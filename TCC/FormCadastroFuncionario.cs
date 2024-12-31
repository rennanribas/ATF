using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroFuncionario : Form
    {
        public FormCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (verificarCampos())
            {
                if (txtBoxSenha.BackColor == Color.Green || txtBoxSenha.BackColor == Color.Yellow)
                {
                    AcessoFuncionario acessoFunc = new AcessoFuncionario();
                    if (acessoFunc.verificarEmail(txtemail.Text))
                    {
                        if (txtBoxConfirmacao.Text == txtBoxSenha.Text)
                        {
                            AcessoFuncionario acesso = new AcessoFuncionario();

                            string sexo;
                            if (rbMasculino.Checked == true || rbFeminino.Checked == false)
                            {
                                sexo = "M";
                            }
                            else
                            {
                                sexo = "F";
                            }
                            String adm = "0";

                            if (checkBox1.Checked)
                                adm = "1";

                            string estcivil_func;
                            estcivil_func = string.Empty;
                            switch (cbEstadoCivil.SelectedItem.ToString())
                            {
                                case "Solteiro(a)": estcivil_func = "S"; break;
                                case "Casado(a)": estcivil_func = "C"; break;
                                case "Divorciado(a)": estcivil_func = "D"; break;
                                case "Viúvo(a)": estcivil_func = "V"; break;
                            }
                            if (estcivil_func == string.Empty)
                                estcivil_func = "Solteiro(a)";

                            DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar este funcionario?", "Confirmação cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                acesso.inserir(txtnome.Text, txtendereco.Text, txtnumero.Text,
                                    cbBairro.Text.ToString(), txtcidade.Text, txtestado.Text, txtCEP.Text, txtpais.Text, sexo,
                                    estcivil_func, txtNascimento.Text,
                                    txtTelefone.Text, txtemail.Text, txtRG.Text, txtCPF.Text,
                                    txtTurno.Text, txtBoxSenha.Text, adm);
                                MessageBox.Show("Funcionário Cadastrado Com Sucesso!");
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
                                txtTurno.Text = string.Empty;
                                checkBox1.Checked = false;
                                txtNascimento.Text = string.Empty;
                                txtestado.Text = string.Empty;
                                txtRG.Text = string.Empty;
                                txtCPF.Text = string.Empty;
                                txtBoxSenha.Text = string.Empty;
                                txtBoxConfirmacao.Text = string.Empty;
                                txtnome.Focus();
                                if (ClasseGlobal.PrimeiroLogin)
                                {
                                    ClasseGlobal.PrimeiroLogin = false;
                                    FormLogin frmLogin = new FormLogin();
                                    frmLogin.Show();
                                    Close();
                                }
                            }
                            else
                                MessageBox.Show("Cadastro não confirmado", "Confirmação Negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Confirmação de senha inválida.", "Senha Inválida",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtBoxConfirmacao.BackColor = Color.Red;
                            txtBoxConfirmacao.Focus();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Este e-mail já está cadastrado no sistema, por favor, digite outro.", "E-mail já cadastrado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtemail.BackColor = Color.Red;
                        txtemail.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Senha muito fraca, para cadastrar digite uma senha forte.", "Senha fraca",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBoxSenha.Focus();
                }
            }
            else
                MessageBox.Show("Preencha os campos em vermelho, são obrigatórios.",
                    "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool verificarCampos()
        {
            if (txtnome.Text != string.Empty && txtendereco.Text != string.Empty && txtnumero.Text != string.Empty
                && txtCEP.Text != string.Empty && cbBairro.Text != string.Empty && txtcidade.Text != string.Empty &&
                txtestado.Text != string.Empty && txtpais.Text != string.Empty && txtemail.Text != string.Empty &&
                txtTurno.Text != string.Empty && txtNascimento.MaskFull && (rbFeminino.Checked || rbMasculino.Checked) &&
                cbEstadoCivil.Text != string.Empty && txtBoxSenha.Text != string.Empty &&
                txtBoxConfirmacao.Text != string.Empty && Valida(txtCPF.Text))
                return true;
            else
            {
                if (!(txtnome.Text != string.Empty))
                    txtnome.BackColor = Color.Red;
                if (!(txtendereco.Text != string.Empty))
                    txtendereco.BackColor = Color.Red;
                if (!(txtnumero.Text != string.Empty))
                    txtnumero.BackColor = Color.Red;
                if (!(txtCEP.Text != string.Empty))
                    txtCEP.BackColor = Color.Red;
                if (!(cbBairro.Text != string.Empty))
                    cbBairro.BackColor = Color.Red;
                if (!(txtcidade.Text != string.Empty))
                    txtcidade.BackColor = Color.Red;
                if (!(txtestado.Text != string.Empty))
                    txtestado.BackColor = Color.Red;
                if (!(txtpais.Text != string.Empty))
                    txtpais.BackColor = Color.Red;
                if (!(txtemail.Text != string.Empty))
                    txtemail.BackColor = Color.Red;
                if (!(txtTurno.Text != string.Empty))
                    txtTurno.BackColor = Color.Red;
                if (!(txtNascimento.MaskFull))
                    txtNascimento.BackColor = Color.Red;
                if (!(cbEstadoCivil.Text != string.Empty))
                    cbEstadoCivil.BackColor = Color.Red;
                if (!(txtBoxSenha.Text != string.Empty))
                    txtBoxSenha.BackColor = Color.Red;
                if (!(txtBoxConfirmacao.Text != string.Empty))
                    txtBoxConfirmacao.BackColor = Color.Red;
                if (!Valida(txtCPF.Text))
                    txtCPF.BackColor = Color.Red;
                return false;
            }
        }

        private void FormCadastroFuncionario_Load(object sender, EventArgs e)
        {
            if (ClasseGlobal.PrimeiroLogin)
            {
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
            }
        }

        private void FormCadastroFuncionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ClasseGlobal.PrimeiroLogin)
            {
                Application.Exit();
            }
        }

        private void txtestado_KeyPress(object sender, KeyPressEventArgs e)
        {
             
            if ((!char.IsLetter(e.KeyChar) || txtestado.TextLength >= 2) && e.KeyChar != '\b')
                e.Handled = true;
        
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Text.Substring(0, 5) + txtCEP.Text.Substring(6, 3);
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

        private void txtTurno_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
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
            txtTurno.Text = string.Empty;
            checkBox1.Checked = false;
            txtNascimento.Text = string.Empty;
            txtestado.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtBoxSenha.Text = string.Empty;
            txtBoxConfirmacao.Text = string.Empty;
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCPF.BackColor = Color.White;
            if ((!char.IsNumber(e.KeyChar) && e.KeyChar != '\b') || (txtCPF.Text.Length == 11 && e.KeyChar != '\b'))
                e.Handled = true;
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

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            txtemail.BackColor = Color.White;
        }

        private void txtBoxSenha_TextChanged(object sender, EventArgs e)
        {
            string senha = txtBoxSenha.Text;
            if (senha != string.Empty)
            {
                int temLetra = 0, temNumero = 0, temCaractereEsp = 0;
                for (int i = 0; i < txtBoxSenha.Text.Length; i++)
                {
                    char letra = char.Parse(senha.Substring(i, 1));
                    if (char.IsLetter(letra))
                        temLetra = 1;
                    else
                    {
                        if (char.IsNumber(letra))
                            temNumero = 1;
                        else
                            temCaractereEsp = 1;
                    }
                }
                int somaTotal = temLetra + temNumero + temCaractereEsp;
                if (somaTotal < 2)
                {
                    lblForcaSenha.Text = "Senha Fraca";
                    txtBoxSenha.BackColor = Color.Red;
                }
                else
                {
                    if (somaTotal == 2)
                    {
                        lblForcaSenha.Text = "Senha Média";
                        txtBoxSenha.BackColor = Color.Yellow;
                    }
                    else
                    {
                        lblForcaSenha.Text = "Senha Forte";
                        txtBoxSenha.BackColor = Color.Green;
                    }
                }
            }
            else
                txtBoxSenha.BackColor = Color.White;
        }

        private void txtBoxConfirmacao_TextChanged(object sender, EventArgs e)
        {
            txtBoxConfirmacao.BackColor = Color.White;
        }
    }
}
