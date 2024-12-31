using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoGruposMusculares
    {
        int ID_gmusculares;
        string nome_gmusculares;

        #region Variaveis Encapsuladas
        public int ID_gmusculares1
        {
            get { return ID_gmusculares; }
            set { ID_gmusculares = value; }
        }


        public string Nome_gmusculares
        {
            get { return nome_gmusculares; }
            set { nome_gmusculares = value; }
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

            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //metodo para inserir na tabela grupos_musculares
        public void inserir(String nome_gmusculares)
        {
            carregar_tabela("insert into grupos_musculares values(0,'" + Cripto.cripto(nome_gmusculares) + "')");
        }

        //metodo para selecionar os dados da tabela grupos_musculares e retornar no datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from grupos_musculares");
            return tabela_memoria;
        }

        //metodo para alterar nome dos grupos musculares
        public void alterarGrupoMuscular(String nome_gmusculares, String ID)
        {
            string query = "update grupos_musculares set nome_gmusculares = '" + Cripto.cripto(nome_gmusculares) + "' where ID_gmusculares=" + ID;
            carregar_tabela(query);
        }

        //metodo para buscar por ID e preenche as variaveis encapsuladas
        public void buscarporID(String ID)
        {
            carregar_tabela("select * from grupos_musculares where ID_gmusculares = " + ID);
            Nome_gmusculares = tabela_memoria.Rows[0]["nome_gmusculares"].ToString();
        }
    }
}
