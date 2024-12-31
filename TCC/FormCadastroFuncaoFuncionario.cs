using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormCadastroFuncaoFuncionario : Form
    {
        public FormCadastroFuncaoFuncionario()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxFuncao.SelectedValue != null && comboBoxFuncionario.SelectedValue != null)
                {
                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja atribuir esta função à este funcionário?", "Confirmação Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        AcessoFuncaoFuncionario acessoFuncaoFunc = new AcessoFuncaoFuncionario();
                        acessoFuncaoFunc.inserir(Convert.ToInt32(comboBoxFuncionario.SelectedValue)
                            , Convert.ToInt32(comboBoxFuncao.SelectedValue));
                        MessageBox.Show("Cadastrado com sucesso!", "Cadastro realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        completarCBFuncao();
                    }
                    else
                        MessageBox.Show("Confirmação negada.", "Cadastro não confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Selecione uma função e um funcionário para cadastrar." + Environment.NewLine +
                        "(só é possível cadastrar uma função para cada funcionario)", "Sem função selecionada.", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Houve algum erro ao cadastrar.", "Erro no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormCadastroFuncaoFuncionario_Load(object sender, EventArgs e)
        {
            AcessoFuncionario acessoFunc = new AcessoFuncionario();
            comboBoxFuncionario.DataSource = acessoFunc.selecionarTodos();
            comboBoxFuncionario.DisplayMember = "nome_func";
            comboBoxFuncionario.ValueMember = "id_func";
            completarCBFuncao();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            comboBoxFuncionario.Text = string.Empty;
            comboBoxFuncao.Text = string.Empty;
        }

        private void comboBoxFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                completarCBFuncao();
            }
            catch { }
        }

        private void completarCBFuncao()
        {
            AcessoFuncaoFuncionario acessoFuncaoFunc = new AcessoFuncaoFuncionario();
            AcessoFuncao acessoFuncao = new AcessoFuncao();
            DataTable dt = acessoFuncao.selecionarTodos();
            for (int linha = 0; linha < dt.Rows.Count; linha++)
            {
                if (acessoFuncaoFunc.verificar(comboBoxFuncionario.SelectedValue.ToString(), dt.Rows[linha]["id_funcao"].ToString()))
                {
                    dt.Rows[linha].Delete();
                }
            }
            comboBoxFuncao.DataSource = dt;
            comboBoxFuncao.DisplayMember = "nome_funcao";
            comboBoxFuncao.ValueMember = "id_funcao";
            if (comboBoxFuncao.SelectedValue == null)
                comboBoxFuncao.Text = string.Empty;
        }

        private void comboBoxFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
