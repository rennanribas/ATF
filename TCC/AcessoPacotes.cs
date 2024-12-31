using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TCC
{
    class AcessoPacotes
    {
        int ID_pacote, dias_Pacote;
        String desc_pacote;
        double valor_pacote;

        #region Variaveis Encapsuladas
        public int DiasPacote
        {
            get { return dias_Pacote; }
            set { dias_Pacote = value; }
        }

        public int ID_pacote1
        {
            get { return ID_pacote; }
            set { ID_pacote = value; }
        }

        public String Desc_pacote
        {
            get { return desc_pacote; }
            set { desc_pacote = value; }
        }

        public double Valor_pacote
        {
            get { return valor_pacote; }
            set { valor_pacote = value; }
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

        //metodo para inserir dados na tabela pacotes
        public void inserir(String descPacote, String valorPacote, String diasPacote)
        {
            carregar_tabela("insert into pacotes values(0,'" + Cripto.cripto(descPacote) + "','" 
                + Cripto.cripto(valorPacote) + "','" + Cripto.cripto(diasPacote) + "')");
        }

        //metodo para selecionar os dados na tabela pacotes e retornar para o datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from pacotes");
            return tabela_memoria;
        }

        //metodo para buscar valor pacote por Id e retornar para tabela memoria
        public String buscarValorPacote(String id)
        {
            carregar_tabela("Select * from pacotes where id_pacote = " + id);
            return tabela_memoria.Rows[0]["valor_pacote"].ToString();
        }

        //metodo para buscar dias 
        public int buscarDiasPacote(String id)
        {
            carregar_tabela("Select * from pacotes where id_pacote = " + id);
            int dias = Convert.ToInt32(tabela_memoria.Rows[0]["dias_pacote"].ToString());
            return dias;
        }

        //metodo para alterar pacote 
        public void alterarPacote(String desc_pacote, String valor_pacote, String dias_pacotes, String ID)
        {
            string query = "update pacotes set desc_pacote= '" + Cripto.cripto(desc_pacote) +
                "', valor_pacote= '" + Cripto.cripto(valor_pacote) + "', dias_pacote= '" + 
                Cripto.cripto(dias_pacotes) + "' where ID_pacote =" + ID;
            carregar_tabela(query);

        }

        //metodo para buscar por ID e preencher as variaveis encapsuladas
        public void buscarporID(String ID)
        {
            carregar_tabela("select * from pacotes where ID_pacote = " + ID);
            Desc_pacote = tabela_memoria.Rows[0]["desc_pacote"].ToString();
            Valor_pacote = Convert.ToDouble(tabela_memoria.Rows[0]["valor_pacote"].ToString());
            DiasPacote = Convert.ToInt32(tabela_memoria.Rows[0]["dias_pacote"].ToString());
        }
    }
}
