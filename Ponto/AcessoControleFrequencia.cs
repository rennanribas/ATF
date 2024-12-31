using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ponto
{
    class AcessoControleFrequencia
    {
        int id_frequencia, id_treino;
        DateTime data_frequencia;

        #region Variaveis Encapsuladas
        public int ID_treino
        {
            get { return id_treino; }
            set { id_treino = value; }
        }

        public int ID_frequencia
        {
            get { return id_frequencia; }
            set { id_frequencia = value; }
        }

        public DateTime Data_frequencia
        {
            get { return data_frequencia; }
            set { data_frequencia = value; }
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

            //looping para desencriptar tabela memnoria
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 0; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    if (tabela_memoria.Columns[coluna].ColumnName == "data_frequencia")
                        tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }

        }

        //método para inserir dados na tabela controle_frequencia
        public void inserir(String IDtreino, String dataHoje)
        {
            carregar_tabela("insert into controle_frequencia values(0," +IDtreino + ",'" + Cripto.cripto(dataHoje) + "');");
        }

        //método para selecionar todos os dados da tabela controle_frequencia
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from controle_frequencia");
            return tabela_memoria;
        }

        //método que verifica se o cliente já tem algum treino registrado, se sim, retorna true

        public bool ultimoTreino(String idCliente)
        {
            carregar_tabela("select cf.data_frequencia, cf.id_treino From controle_frequencia cf inner join treino t on t.id_treino = " 
            + "cf.id_treino inner join cliente c on c.id_cli = t.id_cli where c.id_cli =" + idCliente);

            if (tabela_memoria.Rows.Count != 0)
            {
                DataView dv = tabela_memoria.DefaultView;
                dv.Sort = "data_frequencia";
                tabela_memoria = dv.ToTable();

                Data_frequencia = Convert.ToDateTime(tabela_memoria.Rows[tabela_memoria.Rows.Count -1][0].ToString());
                ID_treino = Convert.ToInt32(tabela_memoria.Rows[tabela_memoria.Rows.Count - 1][1].ToString());
                return true;
            }
            else
                return false;
        }
    }
}
