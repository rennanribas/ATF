using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoExercicio
    {
        int ID_ex, ID_gmusculares;
        string nome_ex, caminho_gif;

        #region Variaveis Encapsuladas

        public string Caminho_gif
        {
            get { return caminho_gif; }
            set { caminho_gif = value; }
        }

        public int ID_gmusculares1
        {
            get { return ID_gmusculares; }
            set { ID_gmusculares = value; }
        }

        public int ID_ex1
        {
            get { return ID_ex; }
            set { ID_ex = value; }
        }


        public string Nome_ex
        {
            get { return nome_ex; }
            set { nome_ex = value; }
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

            //looping para desencriptar tabela
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    if (tabela_memoria.Columns[coluna].ColumnName == "nome_ex" ||
                        tabela_memoria.Columns[coluna].ColumnName == "caminho_gif")
                        tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //método para inserir dados na tabela exercicio
        public void inserir(String ID_gmusculares, String nome_ex, String imagem)
        {
            carregar_tabela("insert into exercicio values(0," + ID_gmusculares + ",'" + Cripto.cripto(nome_ex) + "','" +
                Cripto.cripto(imagem) + "')");
        }

        //método para selecionar todos dados da tabela exercicio
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from exercicio");
            return tabela_memoria;
        }

        //método para alterar exericio
        public void alterarExercicio(String ID_gmusculares, String nome_ex, String ID_exercicio, String imagem)
        {
            string query = "update exercicio set ID_gmusculares = " + ID_gmusculares + ", nome_ex = '"
                + Cripto.cripto(nome_ex) + "', caminho_gif ='" + Cripto.cripto(imagem) + "' where ID_ex = " + ID_exercicio;
            carregar_tabela(query);
        }

        //método para buscar por ID e completar as variáveis encapsuladas
        public void busrcarporID(String ID)
        {
            carregar_tabela("select * from exercicio where ID_ex = " + ID);
            ID_ex1 = Convert.ToInt32(tabela_memoria.Rows[0]["id_ex"].ToString());
            ID_gmusculares1 = Convert.ToInt32(tabela_memoria.Rows[0]["ID_gmusculares"].ToString());
            Nome_ex = tabela_memoria.Rows[0]["nome_ex"].ToString();
            Caminho_gif = tabela_memoria.Rows[0]["caminho_gif"].ToString();
        }

        //método para selecionar por grupo muscular
        public DataTable selecionarPorGrupo(String idGrupo)
        {
            carregar_tabela("Select * from exercicio where id_gmusculares =" + idGrupo);
            return tabela_memoria;
        }
    }
}
