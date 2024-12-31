using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoFuncao
    {
        int ID_funcao;
        string nome_funcao, permissao_funcao;

        #region Variaveis Encapsuladas

        public string Permissao_funcao
        {
            get { return permissao_funcao; }
            set { permissao_funcao = value; }
        }

        public string Nome_funcao
        {
            get { return nome_funcao; }
            set { nome_funcao = value; }
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
           
            //looping para desencriptar tabela função
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    if (tabela_memoria.Columns[coluna].ColumnName == "nome_funcao" 
                        || tabela_memoria.Columns[coluna].ColumnName == "permissao_funcao")
                        tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //método para inserir dados na tabela função
        public void inserir(String nome, String permissao)
        {

            carregar_tabela("Insert into funcao values(0,'" + Cripto.cripto(nome) + "','" + Cripto.cripto(permissao) + "');");
        }

        //método para selecionar todos os dados da tabela funcao e retornar no datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from funcao");
            return tabela_memoria;
        }

        //metodo para verificar se o funcionario tem permissão para cadastrar treinos
        public bool verificarPermissaoPorFunc(String id_func)
        {
            carregar_tabela("select fcao.permissao_funcao From funcao fcao inner join funcao_funcionario ff on fcao.id_funcao =" +
                " ff.id_funcao where ff.id_func = " + id_func + " and fcao.permissao_funcao ='"+ Cripto.cripto("1") +"'");
            if (tabela_memoria.Rows.Count >= 1)
                return true;
            else
                return false;
        }

        //metodo para alterar funcao
        public void alterarFuncao(String nome, String permissao, String ID)
        {
            string query = "update funcao set nome ='" + Cripto.cripto(nome) + "', permissao= '" + Cripto.cripto(permissao) + "', ID_funcao = " + ID;
            carregar_tabela(query);
        }
    }
}
