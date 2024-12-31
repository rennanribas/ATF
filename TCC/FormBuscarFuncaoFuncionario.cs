using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormBuscarFuncaoFuncionario : Form
    {
        public FormBuscarFuncaoFuncionario()
        {
            InitializeComponent();
        }

        private void FormBuscarFuncaoFuncionario_Load(object sender, EventArgs e)
        {
            //busca os dados e completa no comboBoxFuncionario com todos os funcionarios
            AcessoFuncionario acessoFunc = new AcessoFuncionario();
            cbFuncionario.DataSource = acessoFunc.selecionarTodos();
            cbFuncionario.DisplayMember = "nome_func";
            cbFuncionario.ValueMember = "id_func";

            //completa o datagridView conforme o primeiro dado selecionado no comboBox funcionario
            AcessoFuncaoFuncionario acessoFuncaoFunc = new AcessoFuncaoFuncionario();
            dataGridView1.DataSource = acessoFuncaoFunc.selecionarPorFunc(cbFuncionario.SelectedValue.ToString());
            dataGridView1.Columns["nome_funcao"].HeaderText = "Função";
        }

        private void cbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //completa o datagridView conforme o funcionario que foi selecionado, buscando pelo ID
                AcessoFuncaoFuncionario acessoFuncaoFunc = new AcessoFuncaoFuncionario();
                dataGridView1.DataSource = acessoFuncaoFunc.selecionarPorFunc(cbFuncionario.SelectedValue.ToString());
                dataGridView1.Columns["nome_funcao"].HeaderText = "Função";
            }
            catch { }
        }
    }
}
