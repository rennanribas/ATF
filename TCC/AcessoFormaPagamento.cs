 using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoFormaPagamento
    {
        int ID_fpgto;
        string tipo_pgto;

        #region Variaveis Encapsuladas
        public string Tipo_pgto
        {
            get { return tipo_pgto; }
            set { tipo_pgto = value; }
        }

        public int ID_fpgto1
        {
            get { return ID_fpgto; }
            set { ID_fpgto = value; }
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
                    if (tabela_memoria.Columns[coluna].ColumnName == "tipo_pgto")
                        tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //método para inserir forma de pagamento
        public void inserir(String tipo_pgto)
        {
            carregar_tabela("Insert into forma_pagamento values(0,'" + Cripto.cripto(tipo_pgto) + "');");
        }

        //método para selecionar todos os dados da tabela forma_pagamento e retornar como um DataTable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from forma_pagamento");
            return tabela_memoria;
        }

        //método para alterar a forma de pagamento, utilizando o id
        public void alterarFormaPagamento(String tipo_pgto, String ID_fpagamento)
        {
            string query = "update forma_pagamento set tipo_pgto ='" + Cripto.cripto(tipo_pgto) + "' where ID_fpgto = " + ID_fpagamento;
            carregar_tabela(query);

        }

        //método para buscar por id e preencher as variaveis encapsuladas com o valor
        public void buscarporID(String ID)
        {
            carregar_tabela("select * from forma_pagamento where ID_fpgto = " + ID);
            Tipo_pgto = tabela_memoria.Rows[0]["tipo_pgto"].ToString();
        }
    }
}
