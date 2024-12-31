using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TCC
{
    class AcessoFuncaoFuncionario
    {
        int ID_funcao, ID_func;

        #region Variaveis Encapsuladas

        public int ID_func1
        {
            get { return ID_func; }
            set { ID_func = value; }
        }

        public int ID_funcao1
        {
            get { return ID_funcao; }
            set { ID_funcao = value; }
        }

        #endregion

        //Variaveis para acesso ao MYSQL
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        // método de acesso ao BD
        private void carregar_tabela(String comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);

        }

        //metodo para inserir funcao para funcionario
        public void inserir(int idFunc, int idFuncao)
        {

            carregar_tabela("Insert into funcao_funcionario values(" + idFunc.ToString() + "," + idFuncao.ToString() + ")");
        }

        //metodo para selecionar todos os dados da tabela funcao_funcionario e retornar para o datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from funcao_funcionario");
            return tabela_memoria;
        }

        //metodo  para selecionar com inner join
        public DataTable selecionarComInnerJoin()
        {
            carregar_tabela("Select f.nome_func, fcao.nome_funcao From funcionario f inner join " +
                " funcao_funcionario ff on f.id_func = ff.id_func inner join funcao fcao on ff.id_funcao = fcao.id_funcao");
            for (int linha = 0; linha < tabela_memoria.Rows.Count; linha++)
            {
                for (int coluna = 0; coluna < tabela_memoria.Columns.Count; coluna++)
                {
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
            return tabela_memoria;
        }

        //metodo para alterar a funcao do funcionario
        public void alterarFuncaoFuncionario(String idFunc, String idFuncao)
        {
            string query = "update funcao_funcionario set ID_func =" + idFunc + ", ID_funcao=" + idFuncao;
            carregar_tabela(query);
        }

        //metodo para verificar funcao
        public bool verificar(String idFunc, String idFuncao)
        {
            carregar_tabela("Select * from funcao_funcionario where id_func =" + idFunc + " and id_funcao =" + idFuncao);
            if (tabela_memoria.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //metodo para selecionar por funcionario
        public DataTable selecionarPorFunc(String idFunc)
        {
            carregar_tabela("Select fcao.nome_funcao from funcao_funcionario ff inner join funcao fcao on" + 
                " fcao.id_funcao = ff.id_funcao where ff.id_func =" + idFunc);
            for (int linha = 0; linha < tabela_memoria.Rows.Count; linha++)
                tabela_memoria.Rows[linha][0] = Cripto.descripto(tabela_memoria.Rows[linha][0].ToString());
            return tabela_memoria;
        }
    }
}
