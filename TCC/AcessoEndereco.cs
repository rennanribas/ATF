using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoEndereco
    {
        private string end_cli, bairro_cli, cidade_cli, UF_cli, pais_cli, cep_cli, id_cidade;
        private int num_cli;

        #region Variaveis Encapsuladas
        public string Id_cidade
        {
            get { return id_cidade; }
            set { id_cidade = value; }
        }
        public string End_cli
        {
            get { return end_cli; }
            set { end_cli = value; }
        }


        public int Num_cli
        {
            get { return num_cli; }
            set { num_cli = value; }
        }

        public string Bairro_cli
        {
            get { return bairro_cli; }
            set { bairro_cli = value; }
        }


        public string Cidade_cli
        {
            get { return cidade_cli; }
            set { cidade_cli = value; }
        }


        public string UF_cli1
        {
            get { return UF_cli; }
            set { UF_cli = value; }
        }


        public string Cep_cli
        {
            get { return cep_cli; }
            set { cep_cli = value; }
        }


        public string Pais_cli
        {
            get { return pais_cli; }
            set { pais_cli = value; }
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
            comando_sql = new MySqlDataAdapter(comando, ConexaoEndereco.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }

        //método para buscar cep e preencher variáveis encapsuladas
        public void bucarPorCEP(String CEP)
        {

            carregar_tabela("select log_logradouro.log_nome, log_logradouro.cep, log_logradouro.ufe_sg, log_localidade.loc_nosub, log_logradouro.loc_nu_sequencial from log_logradouro inner join log_localidade on log_logradouro.loc_nu_sequencial = log_localidade.loc_nu_sequencial where log_logradouro.cep = " + CEP + ";");
            End_cli = tabela_memoria.Rows[0]["log_nome"].ToString();
            Cidade_cli = tabela_memoria.Rows[0]["loc_nosub"].ToString();
            UF_cli1 = tabela_memoria.Rows[0]["ufe_sg"].ToString();
            Cep_cli = tabela_memoria.Rows[0]["cep"].ToString();
            Id_cidade = tabela_memoria.Rows[0]["loc_nu_sequencial"].ToString();
            Pais_cli = "Brasil";

        }

        //método para selecionar bairro por id
        public DataTable selecionarBairro(String ID)
        {
            carregar_tabela("select * from log_bairro where loc_nu_sequencial =" + ID + ";");

            return tabela_memoria;
        }
    }
}

       

