using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarCliente : Form
    {
        AcessoCliente acesso = new AcessoCliente();
        int id_cli;

        public FormAlterarCliente()
        {
            InitializeComponent();
        }

        private void FormAlterarCliente_Load(object sender, EventArgs e)
        {
            //carrega o comboBox com nomes de todos os clientes
            comboBoxNomeCli.DataSource = acesso.selecionarTodos();
            comboBoxNomeCli.ValueMember = "ID_cli";
            comboBoxNomeCli.DisplayMember = "nome_cli";
        }

        //método para buscar dados de cliente por id, e preencher os campos com estes dados
        public void buscarEPreencher(String idCli)
        {
            acesso.bucarPorID(idCli);
            txtnome.Text = acesso.Nome_cli;
            txtendereco.Text = acesso.End_cli;
            txtnumero.Text = acesso.Num_cli.ToString();
            cbBairro.Text = acesso.Bairro_cli;
            txtestado.Text = acesso.UF_cli1;
            txtCEP.Text = acesso.Cep_cli;
            txtpais.Text = acesso.Pais_cli;
            if (acesso.Sx_cli == "M")
            {
                rbMasculino.Checked = true;
            }
            if (acesso.Sx_cli == "F")
            {
                rbFeminino.Checked = true;
            }
            cbestado.SelectedValue = acesso.Estcivil_cli;
            txtNascimento.Text = acesso.Dtnasc_cli.ToString("dd-MM-yyyy");
            txtTelefone.Text = acesso.Fone_cli;
            txtemail.Text = acesso.Email_cli;
            txtRG.Text = acesso.RG_cli1;
            txtCPF.Text = acesso.CPF_cli1;
            id_cli = acesso.ID_cli1;
            //faz um switch para cadastrar o estado civil do cliente por letra
            switch (acesso.Estcivil_cli)
            {
                case "S": cbestado.Text = "Solteiro(a)"; break;
                case "C": cbestado.Text = "Casado(a)"; break;
                case "D": cbestado.Text = "Divorciado(a)"; break;
                case "V": cbestado.Text = "Viúvo(a)"; break;
            }
            txtcidade.Text = acesso.Cidade_cli;
            txtBoxCB.Text = acesso.Codigo_cli;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idCli = id_cli;
            if (idCli != new int())
            {
                //verifica se todos os campos estão validos
                if (txtnome.Text != string.Empty && txtendereco.Text != string.Empty && cbBairro.Text != string.Empty
                    && txtcidade.Text != string.Empty && txtestado.Text != string.Empty && txtCEP.Text != string.Empty
                    && txtpais.Text != string.Empty && txtNascimento.MaskFull && txtTelefone.Text != string.Empty
                    && txtRG.Text != string.Empty && Valida(txtCPF.Text) && txtemail.Text != string.Empty)
                {
                    //verifica se existe um cliente selecionado
                        if (id_cli >= 0)
                        {
                            DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar este cliente?",
                                "Confirmação alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                string sexo;
                                if (rbFeminino.Checked == true && rbMasculino.Checked == false)
                                {
                                    sexo = "F";
                                }
                                else
                                {
                                    sexo = "M";
                                }
                                string estcivil_cli = string.Empty;
                                switch (cbestado.Text)
                                {
                                    case "Solteiro(a)": estcivil_cli = "S"; break;
                                    case "Casado(a)": estcivil_cli = "C"; break;
                                    case "Divorciado(a)": estcivil_cli = "D"; break;
                                    case "Viúvo(a)": estcivil_cli = "V"; break;
                                }
                                if (estcivil_cli == string.Empty)
                                    estcivil_cli = "S";
                                try
                                {
                                    DateTime dataCerta = Convert.ToDateTime(txtNascimento.Text);
                                    //caso tudo ocorra perfeitamente, altera os dados
                                    acesso.alterarClienteSemSenha(id_cli, txtBoxCB.Text, txtnome.Text, txtendereco.Text,
                                     txtnumero.Text, cbBairro.Text, txtcidade.Text, txtestado.Text, txtCEP.Text,
                                    txtpais.Text, sexo, estcivil_cli, dataCerta, txtTelefone.Text, txtemail.Text, txtRG.Text,
                                       txtCPF.Text);
                                    comboBoxNomeCli.ValueMember = "ID_cli";
                                    comboBoxNomeCli.DisplayMember = "nome_cli";
                                    MessageBox.Show("Alterardo.", "Alteração concluida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch
                                {
                                    MessageBox.Show("Data incorreta.", "Data invalida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                                MessageBox.Show("Alteração não confirmada.", "Confirmação negada",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
                else
                {
                    //se algum campo obrigatório não estiver preenchido, "cai" neste else, e verifica
                    //todos os campos, aqueles que não estiverem corretos, pinta de vermelho.
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
                    if(!Valida(txtCPF.Text))
                        txtCPF.BackColor = Color.Red;
                    if (!(txtemail.Text != string.Empty))
                        txtemail.BackColor = Color.Red;
                    MessageBox.Show("Por Favor, Preencha todos os Campos em vermelho!", "Falta de Informações para Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Selecione um cliente", "Cliente não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //edita o CEP para buscar no banco, tirando a máscara, para ficar somente números
            string cep = txtCEP.Text.Substring(0, 5) + txtCEP.Text.Substring(6, 3);
            try
            {
                //busca no banco e preenche nos componentes do form
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

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtnome.BackColor = Color.Empty;
        }

        private void txtNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica e a tecla que foi precionada é número ou o backspace, caso não seja nenhum dos dois,
            //a tecla não será "contada"
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica e a tecla que foi precionada é número ou o backspace, caso não seja nenhum dos dois,
            //a tecla não será "contada"
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica e a tecla que foi precionada é número ou o backspace, caso não seja nenhum dos dois,
            //a tecla não será "contada"
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;

        }

        private void txtnome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica e a tecla que foi precionada é número ou o backspace, caso não seja nenhum dos dois,
            //a tecla não será "contada"
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void txtendereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica e a tecla que foi precionada é número ou o backspace, caso não seja nenhum dos dois,
            //a tecla não será "contada"
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void comboBoxNomeCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void txtbairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void txtcidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void txtestado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void txtpais_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void cbestado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //não deixa digitar número neste campo
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;

        }

        private void txtCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtCEP.BackColor = Color.Empty;
        }

        private void txtendereco_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtendereco.BackColor = Color.Empty;
        }

        private void txtnumero_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtnumero.BackColor = Color.Empty;
        }

        private void txtcidade_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtcidade.BackColor = Color.Empty;
        }

        private void txtestado_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtestado.BackColor = Color.Empty;
        }

        private void txtpais_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtpais.BackColor = Color.Empty;
        }

        private void txtNascimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtNascimento.BackColor = Color.Empty;
        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtTelefone.BackColor = Color.Empty;
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtemail.BackColor = Color.Empty;
        }

        private void txtRG_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtRG.BackColor = Color.Empty;
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtCPF.BackColor = Color.Empty;
        }

        private void comboBoxNomeCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxNomeCli.BackColor = Color.Empty;

                //verifica se foi selecionado um cliente
                if (comboBoxNomeCli.SelectedValue != null)
                {
                    //utiliza o método para buscar no banco de dados, e preencher os componentes do form
                    //conforme o id selecionado
                    string id = comboBoxNomeCli.SelectedValue.ToString();
                    buscarEPreencher(id);
                }
                else
                    //caso não haja um cliente selecionado, aparecerá a mensagem de erro
                    MessageBox.Show("Primeiro selecione ou cadastre um cliente", "Cliente inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
            }
        }

        private void txtbairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            cbBairro.BackColor = Color.Empty;
        }

        private void cbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            cbestado.BackColor = Color.Empty;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //limpa todos os campos, e retorna para solteiro o comboBox estado civil
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
            rbMasculino.Checked = true;
            cbestado.Text = "Solteiro(a)";
            txtRG.Text = string.Empty;
            txtCPF.Text = string.Empty;
            txtnome.Focus();
        }

        private void cbBairro_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            cbBairro.BackColor = Color.White;
        }

        private void txtNascimento_TextChanged(object sender, EventArgs e)
        {
            //ao ser precionado, o componente volta a cor original (branco)
            txtNascimento.BackColor = Color.White;
        }

        //método para validar o cpf
        public bool Valida(string cpf)
        {
            //cria os arrays multiplicadores
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            //remove os espaços tanto do meio, quanto do fim da variavel cpf
            cpf = cpf.Trim();
            //retira tanto os pontos quanto os traços da variavel cpf
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            //verifica se o cpf tem os 11 caracteres, caso não, retorna falso
            if (cpf.Length != 11)
                return false;

            //atribui os 9 primeiros números do cpf a variável tempCpf
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            //percorre o tempCpf, e vai multiplicando os números do mesmo, pelos do array multiplicador
            //e soma este valor
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            //pega o resto da divisão da variavel soma por 11
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

        private void txtCPF_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //volta textBox para a cor branca ao ser precionado
            txtCPF.BackColor = Color.White;
            //verifica se o caractere digitado é número ou backspace, e verifica quantas letras já tem.
            //se alguma dessas for errada, "bloqueia" o caractere digitado
            if ((!char.IsNumber(e.KeyChar) && e.KeyChar != '\b') || (txtCPF.Text.Length == 11 && e.KeyChar != '\b'))
                e.Handled = true;
        }

        private void txtBoxCB_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
