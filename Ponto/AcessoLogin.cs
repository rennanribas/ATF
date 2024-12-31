using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Ponto
{
    class AcessoLogin
    {
        int id_login, id_func;
        string nome_login, senha_login, resposta;

        #region Variaveis Encapsuladas

        public string Resposta
        {
            get { return resposta; }
            set { resposta = value; }
        }
        public int Id_func
        {
            get { return id_func; }
            set { id_func = value; }
        }

        public int Id_login
        {
            get { return id_login; }
            set { id_login = value; }
        }

        public string Senha_login
        {
            get { return senha_login; }
            set { senha_login = value; }
        }

        public string Nome_login
        {
            get { return nome_login; }
            set { nome_login = value; }
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

        //Fazer Login
        public Boolean VerificarLogin(String usuario, String senha)
        {
            AcessoFuncionario acessoFunc = new AcessoFuncionario();
            DataTable dt = acessoFunc.selecionarTodos();
            String resposta = acessoFunc.logarFuncionario(usuario, senha);
            Resposta = resposta;
            if (resposta == "Administrador Logado.")
                return true;
            else
                return false;

        }

        public Boolean verificarSeHaCadastro()
        {
            AcessoFuncionario acessoFunc = new AcessoFuncionario();
            if (acessoFunc.selecionarTodos().Rows.Count == 0)
                return false;
            else
                return true;
        }
    }

}
