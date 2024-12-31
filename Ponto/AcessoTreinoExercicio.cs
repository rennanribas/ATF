using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Ponto
{
    class AcessoTreinoExercicio
    {
        int ID_treino, ID_ex, num_repeticoes, num_series;

        #region Variaveis Encapsuladas
        public int Num_series
        {
            get { return num_series; }
            set { num_series = value; }
        }

        public int Num_repeticoes
        {
            get { return num_repeticoes; }
            set { num_repeticoes = value; }
        }

        public int ID_ex1
        {
            get { return ID_ex; }
            set { ID_ex = value; }
        }

        public int ID_treino1
        {
            get { return ID_treino; }
            set { ID_treino = value; }
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

        //método para inserir um dado na tabela treino_exercicio
        public void inserir(String ID_treino, String ID_ex, String num_rep, String num_series)
        {
            carregar_tabela("insert into treino_exercicio values(" + ID_treino + "," + ID_ex + ",'" + Cripto.cripto(num_rep) + "','" + Cripto.cripto(num_series) + "');");
        }

        //método para selecionar todos os dados da tabela treino_exercicio
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from treino_exericio");
            return tabela_memoria;
        }

        //método para buscar nome de treino, usando o id como pesquisa
        public String buscarNomeTreino(String idTreino)
        {
            carregar_tabela("select nome_treino from treino where id_treino = " + idTreino);
            return Cripto.descripto(tabela_memoria.Rows[0][0].ToString());
        }

        //método para selecionar uma tabela fazendo inner join, utilizando o id do treino.
        public DataTable selecionarPorTreino(String idTreino)
        {
            String innerJoin = "select e.nome_ex, te.num_repeticoes, " +
            "te.num_series, g.nome_gmusculares, e.caminho_gif " +
            "From treino_exercicio te " +
            "inner join exercicio e " +
            "on " +
            "te.id_ex = e.id_ex " +
            "inner join grupos_musculares g " +
            "on " +
            "e.id_gmusculares = g.id_gmusculares " +
            "where te.id_treino =" + idTreino;
            //carrega a tabela_memória com os dados do inner join
            carregar_tabela(innerJoin);

            //desencripta a tabela memória antes de retornar
            for (int coluna = 0; tabela_memoria.Columns.Count > coluna; coluna++)
            {
                for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
            }
            return tabela_memoria;
        }
    }
}