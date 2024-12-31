using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarFuncionario : Form
    {
        public FormAlterarFuncionario()
        {
            InitializeComponent();
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //chama método para verificar todos os campos
            if (verificarCampos())
            {
                if (txtBoxNovaSenha.BackColor == Color.Yellow || txtBoxNovaSenha.BackColor == Color.Green
                    || txtBoxNovaSenha.Text == string.Empty)
                {
                    AcessoFuncionario acessoFunc = new AcessoFuncionario();
                    acessoFunc.buscarporID(comboBoxPesquisarFunc.SelectedValue.ToString());
                    if (txtBoxSenhaAntiga.Text == acessoFunc.Senha_func)
                    {
                        if (Valida(txtCPF.Text))
                        {
                            string sexo, adm;

                            if (rbFeminino.Checked)
                                sexo = "F";
                            else
                                sexo = "M";
                            if (checkBox1.Checked)
                                adm = "1";
                            else
                                adm = "0";

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

                            try
                            {
                                //caso tudo esteja válido, verifica por ultimo o email, e se tudo estiver certo, cadastra
                                if (acessoFunc.verificarEmail(txtemail.Text) || txtemail.Text == acessoFunc.Email_func)
                                {
                                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar?", "Confirmação alteração",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dr == DialogResult.Yes)
                                    {
                                        string id_func;
                                        if (ClasseGlobal.Adm)
                                            id_func = comboBoxPesquisarFunc.SelectedValue.ToString();
                                        else
                                            id_func = ClasseGlobal.Id_funcionario.ToString();
                                        if (txtBoxNovaSenha.Text == txtBoxConfirmacaoNovaSenha.Text && txtBoxNovaSenha.Text == string.Empty)
                                        {
                                            acessoFunc.alterarFuncionario(txtnome.Text, txtendereco.Text, txtnumero.Text, cbBairro.Text,
                                                txtcidade.Text, txtestado.Text, txtCEP.Text, txtpais.Text, sexo, estcivil_func, txtNascimento.Text,
                                                txtTelefone.Text, txtemail.Text, txtRG.Text, txtCPF.Text, txtTurno.Text, txtBoxSenhaAntiga.Text, adm,
                                                id_func);
                                            MessageBox.Show("Alterado Com Sucesso", "Alteração com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            load();
                                        }
                                        if (txtBoxNovaSenha.Text == txtBoxConfirmacaoNovaSenha.Text && txtBoxNovaSenha.Text != string.Empty)
                                        {
                                            acessoFunc.alterarFuncionario(txtnome.Text, txtendereco.Text, txtnumero.Text, cbBairro.Text,
                                                txtcidade.Text, txtestado.Text, txtCEP.Text, txtpais.Text, sexo, estcivil_func, txtNascimento.Text,
                                                txtTelefone.Text, txtemail.Text, txtRG.Text, txtCPF.Text, txtTurno.Text, txtBoxNovaSenha.Text, adm,
                                                id_func);
                                            MessageBox.Show("Alterado Com Sucesso", "Alteração com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            load();
                                            txtBoxNovaSenha.Text = string.Empty;
                                            txtBoxConfirmacaoNovaSenha.Text = string.Empty;
                                        }
                                        if (txtBoxNovaSenha.Text != txtBoxConfirmacaoNovaSenha.Text)
                                        {
                                            MessageBox.Show("Confirmação de senha inválida.", "Senha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            txtBoxConfirmacaoNovaSenha.BackColor = Color.Red;
                                            txtBoxConfirmacaoNovaSenha.Focus();
                                        }
                                    }
                                    else
                                        MessageBox.Show("Alteração não confirmada.", "Confirmação negada",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Este email já está cadastrado no sistema, por favor, digite outro.", "Email já cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtemail.BackColor = Color.Red;
                                    txtemail.Focus();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Erro Ao Alterar", "Erro Na Alteração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else
                        {
                            MessageBox.Show("CPF inválido, digite um válido.", "CPF inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCPF.Focus();
                            txtCPF.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Senha antiga inválida.", "Senha inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBoxSenhaAntiga.BackColor = Color.Red;
                        txtBoxSenhaAntiga.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Senha muito fraca, para cadastrar digite uma senha forte.", "Senha fraca",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                       txtBoxNovaSenha.Focus();
                }
            }
            else
                MessageBox.Show("Preencha os campos em vermelho, são obrigatórios.",
                "Campos não preenchidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private bool verificarCampos()
        {
            //verifica se algum campo obrigatorio não está preenchido, caso todos estejão preenchidos, retorna true
            if (txtnome.Text != string.Empty && txtendereco.Text != string.Empty && txtnumero.Text != string.Empty
                && txtCEP.Text != string.Empty && cbBairro.Text != string.Empty && txtcidade.Text != string.Empty &&
                txtestado.Text != string.Empty && txtpais.Text != string.Empty && txtemail.Text != string.Empty &&
                txtTurno.Text != string.Empty && txtNascimento.MaskFull && (rbFeminino.Checked || rbMasculino.Checked) &&
                cbEstadoCivil.Text != string.Empty)
                return true;
            else
                //caso não estejam, verifica qual está, e pinta de vermelho o fundo do mesmo
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
                if (!(txtCPF.Text != string.Empty))
                    txtCPF.BackColor = Color.Red;
                if (!ClasseGlobal.Adm)
                {
                    AcessoFuncionario acessoFunc = new AcessoFuncionario();
                    acessoFunc.buscarporID(ClasseGlobal.Id_funcionario.ToString());
                    if (acessoFunc.Senha_func != txtBoxSenhaAntiga.Text)
                        txtBoxSenhaAntiga.BackColor = Color.Red;
                }
                else
                {
                    AcessoFuncionario acessoFunc = new AcessoFuncionario();
                    acessoFunc.buscarporID(comboBoxPesquisarFunc.SelectedValue.ToString());
                    if (acessoFunc.Senha_func != txtBoxSenhaAntiga.Text)
                        txtBoxSenhaAntiga.BackColor = Color.Red;
                }
                return false;
            }
        }

        private void load()
        {
            //método chamado ao form inicializar, ou qunado é preciso ser "zerado"
            AcessoFuncionario acesso = new AcessoFuncionario();

            if (!ClasseGlobal.Adm)
            {
                checkBox1.Enabled = false;
                checkBox1.Visible = false;
                groupBox1.Visible = false;
                AcessoFuncionario acessoFunc = new AcessoFuncionario();
                acessoFunc.buscarporID(ClasseGlobal.Id_funcionario.ToString());

                acesso.buscarporID(ClasseGlobal.Id_funcionario.ToString());
                txtnome.Text = acesso.Nome_func;
                cbBairro.Text = acesso.Bairro_func;
                txtBoxSenhaAntiga.Text = acesso.Senha_func;
                txtCEP.Text = acesso.Cep_func;
                txtcidade.Text = acesso.Cidade_func;
                txtCPF.Text = acesso.CPF_func1;
                txtemail.Text = acesso.Email_func;
                txtendereco.Text = acesso.End_func;
                txtestado.Text = acesso.UF_func1;
                txtNascimento.Text = acesso.Dtnasc_func;
                txtnome.Text = acesso.Nome_func;
                txtnumero.Text = acesso.Numero.ToString();
                txtpais.Text = acesso.Pais_func;
                txtRG.Text = acesso.RG_func1;
                txtTelefone.Text = acesso.Fone_func;
                txtTurno.Text = acesso.Turno_func;
                if (acesso.Adm_func == "1")
                    checkBox1.Checked = true;

                if (acesso.Sx_func == "F")
                {
                    rbFeminino.Checked = true;
                }
                else
                    rbMasculino.Checked = true;
                string estcivil_func;
                estcivil_func = string.Empty;
                switch (acesso.Estcivil_func)
                {
                    case "S": estcivil_func = "Solteiro(a)"; break;
                    case "C": estcivil_func = "Casado(a)"; break;
                    case "D": estcivil_func = "Divorciado(a)"; break;
                    case "V": estcivil_func = "Viúvo(a)"; break;
                }
                cbEstadoCivil.Text = estcivil_func;
                txtBoxSenhaAntiga.Text = string.Empty;
                txtnome.Focus();
            }
            else
            {
                comboBoxPesquisarFunc.DataSource = acesso.selecionarTodos();
                comboBoxPesquisarFunc.ValueMember = "ID_func";
                comboBoxPesquisarFunc.DisplayMember = "nome_func";
                comboBoxPesquisarFunc.Focus();
            }
        }

        private void FormAlterarFuncionario_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //retira o traço do cep, pesquisa no banco, e caso dê certo, preenche os componentes, caso não, mostra mensagem de
            //CEP inválido
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //pesquisa o funcionario no banco pelo seu id, e preenche os componentes do form com o resultado
                comboBoxPesquisarFunc.BackColor = Color.Empty;

                AcessoFuncionario acesso = new AcessoFuncionario();
                acesso.buscarporID(comboBoxPesquisarFunc.SelectedValue.ToString());
                txtnome.Text = acesso.Nome_func;
                cbBairro.Text = acesso.Bairro_func;
                txtBoxSenhaAntiga.Text = acesso.Senha_func;
                txtCEP.Text = acesso.Cep_func;
                txtcidade.Text = acesso.Cidade_func;
                txtCPF.Text = acesso.CPF_func1;
                txtemail.Text = acesso.Email_func;
                txtendereco.Text = acesso.End_func;
                txtestado.Text = acesso.UF_func1;
                txtNascimento.Text = acesso.Dtnasc_func;
                txtnome.Text = acesso.Nome_func;
                txtnumero.Text = acesso.Numero.ToString();
                txtpais.Text = acesso.Pais_func;
                txtRG.Text = acesso.RG_func1;
                txtTelefone.Text = acesso.Fone_func;
                txtTurno.Text = acesso.Turno_func;
                if (acesso.Adm_func == "1")
                    checkBox1.Checked = true;

                if (acesso.Sx_func == "F")
                {
                    rbFeminino.Checked = true;
                }
                else
                    rbMasculino.Checked = true;

                string estcivil_func;
                estcivil_func = string.Empty;
                switch (acesso.Estcivil_func)
                {
                    case "S": estcivil_func = "Solteiro(a)"; break;
                    case "C": estcivil_func = "Casado(a)"; break;
                    case "D": estcivil_func = "Divorciado(a)"; break;
                    case "V": estcivil_func = "Viúvo(a)"; break;
                }
                cbEstadoCivil.Text = estcivil_func;
            }
            catch
            {
            }
        }

        #region volta campos a cor original
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

        private void txtbairro_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEstadoCivil.BackColor = Color.Empty;
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
            txtemail.BackColor = Color.White;
        }

        private void txtRG_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtRG.BackColor = Color.Empty;
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtCPF.BackColor = Color.Empty;
        }

        private void txtTurno_TextChanged(object sender, EventArgs e)
        {
            txtTurno.BackColor = Color.Empty;
        }

        private void txtBoxSenhaAntiga_TextChanged(object sender, EventArgs e)
        {
            txtBoxSenhaAntiga.BackColor = Color.Empty;
        }

        private void txtBoxConfirmacaoNovaSenha_TextChanged(object sender, EventArgs e)
        {
            txtBoxConfirmacaoNovaSenha.BackColor = Color.Empty;
        }
        #endregion

        private void txtBoxNovaSenha_TextChanged(object sender, EventArgs e)
        {
            //método para verificar força da senha
            string senha = txtBoxNovaSenha.Text;
            if (senha != string.Empty)
            {
                lblForcaSenha.Visible = true;
                int temLetra = 0, temNumero = 0, temCaractereEsp = 0;
                //looping para verificar se tem letra, numero ou caractere especial na string da senha
                for (int i = 0; i < txtBoxNovaSenha.Text.Length; i++)
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
                //soma as variaveis
                int somaTotal = temLetra + temNumero + temCaractereEsp;
                //verifica numero da senha, conforme numero mostra a força, 1 fraca, 2 médio, 3 forte
                if (somaTotal < 2)
                {
                    lblForcaSenha.Text = "Senha Fraca";
                    txtBoxNovaSenha.BackColor = Color.Red;
                }
                else
                {
                    if (somaTotal == 2)
                    {
                        lblForcaSenha.Text = "Senha Média";
                        txtBoxNovaSenha.BackColor = Color.Yellow;
                    }
                    else
                    {
                        lblForcaSenha.Text = "Senha Forte";
                        txtBoxNovaSenha.BackColor = Color.Green;
                    }
                }
            }
            else
            {
                //caso não haja caractere no textBox, zera o mesmo, e some com o label
                lblForcaSenha.Visible = false;
                txtBoxNovaSenha.BackColor = Color.White;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //limpa todos os campos
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
            checkBox1.Checked = false;
            txtNascimento.Text = string.Empty;
            rbMasculino.Checked = true;
            txtestado.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtBoxSenhaAntiga.Text = string.Empty;
            txtBoxNovaSenha.Text = string.Empty;
            txtBoxConfirmacaoNovaSenha.Text = string.Empty;
            if (ClasseGlobal.Adm)
                comboBoxPesquisarFunc.Focus();
            else
                txtnome.Focus();
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //veririca se é número, se tem 11 caracteres ou se a tecla precionada é backspace
            txtCPF.BackColor = Color.White;
            if ((!char.IsNumber(e.KeyChar) && e.KeyChar != '\b') || (txtCPF.Text.Length == 11 && e.KeyChar != '\b'))
                e.Handled = true;
        }

        //método para validar CPF
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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }
}
