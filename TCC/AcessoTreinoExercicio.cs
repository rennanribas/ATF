using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
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

        //metodo para inserir dados na tabea treino_exercicio
        public void inserir(String ID_treino, String ID_ex, String num_rep, String num_series)
        {
            carregar_tabela("insert into treino_exercicio values(" + ID_treino + "," + ID_ex + ",'" + Cripto.cripto(num_rep) + "','" + Cripto.cripto(num_series) + "');");
        }

        //metodo para selecionar todos os dados do treino_exercicio e retornar para datatable 
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from treino_exericio");
            return tabela_memoria;
        }

        //metodo para selecionar por treino e retornar para datatable
        public DataTable selecionarPorTreino(String idTreino)
        {
            String innerJoin = "select e.nome_ex, te.num_repeticoes, " +
            "te.num_series, g.nome_gmusculares " +
            "From treino_exercicio te " +
            "inner join exercicio e " +
            "on " +
            "te.id_ex = e.id_ex " +
            "inner join grupos_musculares g " +
            "on " +
            "e.id_gmusculares = g.id_gmusculares " +
            "where te.id_treino =" + idTreino;

            carregar_tabela(innerJoin);

            for (int coluna = 0; tabela_memoria.Columns.Count > coluna; coluna++)
            {
                for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
            }
            return tabela_memoria;
        }

        //metodo para selecionar o relatorio
        public DataTable relatorio()
        {
            DataTable nv = new DataTable();

            nv.Columns.Add("nome_ex", typeof(string));
            nv.Columns.Add("num_repeticoes", typeof(int));
            nv.Columns.Add("num_series", typeof(int));
            nv.Columns.Add("nome_gmusculares", typeof(string));
            nv.Columns.Add("id_treino_ex", typeof(int));

            String innerJoin = "select e.nome_ex, te.num_repeticoes, " +
            "te.num_series, g.nome_gmusculares " +
            "From treino_exercicio te " +
            "inner join exercicio e " +
            "on " +
            "te.id_ex = e.id_ex " +
            "inner join grupos_musculares g " +
            "on " +
            "e.id_gmusculares = g.id_gmusculares " +
            "inner join treino t " +
            "on " +
            "t.id_treino = te.id_treino " +
            "where te.id_treino =" + ClasseGlobal.Id_treino.ToString() +
            " and t.visivel_treino = '1'";

            carregar_tabela(innerJoin);

            for (int linha = 0; linha < tabela_memoria.Rows.Count; linha++)
            {
                for (int coluna = 0; coluna < tabela_memoria.Columns.Count; coluna++)
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString()); 
            }

            for (int i = 0; i < tabela_memoria.Rows.Count; i++)
            {
                DataRow linha = nv.NewRow();

                linha["nome_ex"] = tabela_memoria.Rows[i]["nome_ex"].ToString();
                linha["num_repeticoes"] = tabela_memoria.Rows[i]["num_repeticoes"].ToString();
                linha["num_series"] = tabela_memoria.Rows[i]["num_series"].ToString();
                linha["nome_gmusculares"] = tabela_memoria.Rows[i]["nome_gmusculares"].ToString();
                linha["id_treino_ex"] = i.ToString();

                nv.Rows.Add(linha);
            }

            return nv;
        }

        //metodo para alterar treino exercicio
        public void alterarTreinoExercicio(String ID_treino, String ID_ex, String num_rep, String num_series, String ID)
        {
            string query = "update treino set ID_ex = " + ID_ex + ", num_repeticoes ='" + Cripto.cripto(num_rep) + "', num_series =' " + Cripto.cripto(num_series) + "', where ID_treino =" + ID;
            carregar_tabela(query);
        }
    }
}