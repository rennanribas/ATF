using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoTreino
    {
        int id_treino, id_func, id_cliente;
        string nome_treino;

        #region Variaveis Encapsuladas

        public int ID_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        public int ID_func
        {
            get { return id_func; }
            set { id_func = value; }
        }

        public int ID_treino
        {
            get { return id_treino; }
            set { id_treino = value; }
        }
        public string Nome_treino
        {
            get { return nome_treino; }
            set { nome_treino = value; }
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
                    if (tabela_memoria.Columns[coluna].ColumnName == "nome_treino" ||
                        tabela_memoria.Columns[coluna].ColumnName == "visivel_treino")
                        tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //metodo para inserir dados na tabela treino
        public void inserir(String IDfunc,String IDcliente, String nome_treino)
        {
            carregar_tabela("insert into treino values(0," + IDfunc + "," + IDcliente + ",'" + Cripto.cripto(nome_treino) + "','1');");
        }

        //metodo para atualizar dados na tabela treino
        public void atualizar(String idTreino, String idFunc, String idCliente, String nomeTreino, String visivel)
        {
            carregar_tabela("update treino set id_func = " + idFunc + ", id_cli = " + idCliente + ", nome_treino = '" + Cripto.cripto(nomeTreino)
                + "', visivel_treino = '" + Cripto.cripto(visivel) + "' where id_treino = " + idTreino);
        }

        //metodo para verificar se o treino esta habilitado
        public void visibilidadeTreino(String idTreino, String visivel)
        {
            carregar_tabela("update treino set visivel_treino = '" + Cripto.cripto(visivel) + "' where id_treino = " + idTreino);
        }

        //metodo para selecionar todos dados na tabela treino e retornar para o datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from treino order by id_treino");
            return tabela_memoria;
        }

        //metodo para selecionar os dados do cliente na tabela treino e retornar para o datatable
        public DataTable selecionarDoCliente(String idCli)
        {
            carregar_tabela("Select * from treino where id_cli = " + idCli + " order by id_treino");
            return tabela_memoria;
        }
        
        //metodo para buscar por ID e preencher as variaveis encapsuladas
        public void buscarporID(String ID)
        {
            carregar_tabela("select * from treino where ID_treino =" + ID);
            ID_func = Convert.ToInt32(tabela_memoria.Rows[0]["ID_func"].ToString());
            ID_cliente = Convert.ToInt32(tabela_memoria.Rows[0]["ID_cli"].ToString());
            Nome_treino = tabela_memoria.Rows[0]["nome_treino"].ToString();
        }

        //metodo para atualizar nome
        public void atualizarNome(String id, String nome)
        {
            carregar_tabela("update treino set nome_treino ='" + Cripto.cripto(nome) + "' where id_treino =" + id);
        }
    }

}
