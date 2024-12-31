using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ponto
{
    class AcessoCliente
    {
        int ID_cli, num_cli;
       // double renda_cli;
        String codigo_cli,nome_cli, end_cli, bairro_cli, cidade_cli,
            UF_cli, cep_cli, pais_cli, sx_cli, estcivil_cli, email_cli, RG_cli, CPF_cli, fone_cli, login_cli,
            senha_cli;
        DateTime dtnasc_cli, data_cadastro;

        #region Variaveis Encapsuladas

        public String Codigo_cli
        {
            get { return codigo_cli; }
            set { codigo_cli = value; }
        }

        public String Fone_cli
        {
            get { return fone_cli; }
            set { fone_cli = value; }
        }

        public int Num_cli
        {
            get { return num_cli; }
            set { num_cli = value; }
        }

        public int ID_cli1
        {
            get { return ID_cli; }
            set { ID_cli = value; }
        }

        public String CPF_cli1
        {
            get { return CPF_cli; }
            set { CPF_cli = value; }
        }

        public String RG_cli1
        {
            get { return RG_cli; }
            set { RG_cli = value; }
        }

        public String Email_cli
        {
            get { return email_cli; }
            set { email_cli = value; }
        }

        public String Estcivil_cli
        {
            get { return estcivil_cli; }
            set { estcivil_cli = value; }
        }

        public String Sx_cli
        {
            get { return sx_cli; }
            set { sx_cli = value; }
        }

        public String Pais_cli
        {
            get { return pais_cli; }
            set { pais_cli = value; }
        }

        public String Cep_cli
        {
            get { return cep_cli; }
            set { cep_cli = value; }
        }

        public String UF_cli1
        {
            get { return UF_cli; }
            set { UF_cli = value; }
        }

        public String Cidade_cli
        {
            get { return cidade_cli; }
            set { cidade_cli = value; }
        }

        public String Bairro_cli
        {
            get { return bairro_cli; }
            set { bairro_cli = value; }
        }

        public String End_cli
        {
            get { return end_cli; }
            set { end_cli = value; }
        }

        public String Nome_cli
        {
            get { return nome_cli; }
            set { nome_cli = value; }
        }

        public DateTime Dtnasc_cli
        {
            get { return dtnasc_cli; }
            set { dtnasc_cli = value; }
        }

        public String Senha_cli
        {
            get { return senha_cli; }
            set { senha_cli = value; }
        }

        public String Login_cli
        {
            get { return login_cli; }
            set { login_cli = value; }
        }

        public DateTime Data_cadastro
        {
            get { return data_cadastro; }
            set { data_cadastro = value; }
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
            // looping para desencriptar a tabela cliente
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    if(tabela_memoria.Columns[coluna].ColumnName != "codseg_cli")
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }

            //organiza a tabela por ordem alfabetica usando o nome
            try
            {
                DataView dv = tabela_memoria.DefaultView;
                dv.Sort = "nome_cli";
                tabela_memoria = dv.ToTable();
            }
            catch { }
        }
        
        //método para selecionar todos clientes
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from cliente");
            return tabela_memoria;
        }

        //método que busca cliente por id, e atribui valores a variaveis encapsuladas
        public void bucarPorID(String id)
        {
            carregar_tabela("select * from cliente where id_cli=" + id );
            ID_cli1 = Convert.ToInt32(tabela_memoria.Rows[0]["ID_cli"]);
            Codigo_cli = tabela_memoria.Rows[0]["codigo_cli"].ToString();
            Nome_cli = tabela_memoria.Rows[0]["nome_cli"].ToString();
            End_cli = tabela_memoria.Rows[0]["end_cli"].ToString();
            Num_cli = Convert.ToInt32(tabela_memoria.Rows[0]["num_cli"]);
            Bairro_cli = tabela_memoria.Rows[0]["bairro_cli"].ToString();
            Cidade_cli = tabela_memoria.Rows[0]["cidade_cli"].ToString();
            UF_cli = tabela_memoria.Rows[0]["uf_cli"].ToString();
            Cep_cli = tabela_memoria.Rows[0]["cep_cli"].ToString();
            Pais_cli = tabela_memoria.Rows[0]["pais_cli"].ToString();
            Sx_cli = tabela_memoria.Rows[0]["sx_cli"].ToString();
            Estcivil_cli = tabela_memoria.Rows[0]["estcivil_cli"].ToString();
            dtnasc_cli = Convert.ToDateTime(tabela_memoria.Rows[0]["dtnasc_cli"]);
            Fone_cli = tabela_memoria.Rows[0]["fone_cli"].ToString();
            Email_cli = tabela_memoria.Rows[0]["email_cli"].ToString();
            RG_cli = tabela_memoria.Rows[0]["rg_cli"].ToString();
            CPF_cli = tabela_memoria.Rows[0]["cpf_cli"].ToString();
            Data_cadastro = Convert.ToDateTime(tabela_memoria.Rows[0]["data_cadastro"]);
            Senha_cli = tabela_memoria.Rows[0]["senha_cli"].ToString();
        }

        //método que busca cliente por codigo de barras, e atribui valores a variaveis encapsuladas
        public void bucarPorCB(String codigo)
        {
            carregar_tabela("select * from cliente where codigo_cli='" + Cripto.cripto(codigo) + "'");
            ID_cli1 = Convert.ToInt32(tabela_memoria.Rows[0]["ID_cli"]);
            Codigo_cli = tabela_memoria.Rows[0]["codigo_cli"].ToString();
            Nome_cli = tabela_memoria.Rows[0]["nome_cli"].ToString();
            End_cli = tabela_memoria.Rows[0]["end_cli"].ToString();
            Num_cli = Convert.ToInt32(tabela_memoria.Rows[0]["num_cli"]);
            Bairro_cli = tabela_memoria.Rows[0]["bairro_cli"].ToString();
            Cidade_cli = tabela_memoria.Rows[0]["cidade_cli"].ToString();
            UF_cli = tabela_memoria.Rows[0]["uf_cli"].ToString();
            Cep_cli = tabela_memoria.Rows[0]["cep_cli"].ToString();
            Pais_cli = tabela_memoria.Rows[0]["pais_cli"].ToString();
            Sx_cli = tabela_memoria.Rows[0]["sx_cli"].ToString();
            Estcivil_cli = tabela_memoria.Rows[0]["estcivil_cli"].ToString();
            dtnasc_cli = Convert.ToDateTime(tabela_memoria.Rows[0]["dtnasc_cli"]);
            Fone_cli = tabela_memoria.Rows[0]["fone_cli"].ToString();
            Email_cli = tabela_memoria.Rows[0]["email_cli"].ToString();
            RG_cli = tabela_memoria.Rows[0]["rg_cli"].ToString();
            CPF_cli = tabela_memoria.Rows[0]["cpf_cli"].ToString();
            Data_cadastro = Convert.ToDateTime(tabela_memoria.Rows[0]["data_cadastro"]);
            Senha_cli = tabela_memoria.Rows[0]["senha_cli"].ToString();
        }

        //método que busca cliente por nome, e atribui valores a variaveis encapsuladas
        public void bucarPorNome(String nome)
        {
            carregar_tabela("select * from cliente where nome_cli='" + Cripto.cripto(nome) + "'");
            ID_cli1 = Convert.ToInt32(tabela_memoria.Rows[0]["ID_cli"]);
            Codigo_cli = tabela_memoria.Rows[0]["codigo_cli"].ToString();
            Nome_cli = tabela_memoria.Rows[0]["nome_cli"].ToString();
            End_cli = tabela_memoria.Rows[0]["end_cli"].ToString();
            Num_cli = Convert.ToInt32(tabela_memoria.Rows[0]["num_cli"]);
            Bairro_cli = tabela_memoria.Rows[0]["bairro_cli"].ToString();
            Cidade_cli = tabela_memoria.Rows[0]["cidade_cli"].ToString();
            UF_cli = tabela_memoria.Rows[0]["uf_cli"].ToString();
            Cep_cli = tabela_memoria.Rows[0]["cep_cli"].ToString();
            Pais_cli = tabela_memoria.Rows[0]["pais_cli"].ToString();
            Sx_cli = tabela_memoria.Rows[0]["sx_cli"].ToString();
            Estcivil_cli = tabela_memoria.Rows[0]["estcivil_cli"].ToString();
            dtnasc_cli = Convert.ToDateTime(tabela_memoria.Rows[0]["dtnasc_cli"]);
            Fone_cli = tabela_memoria.Rows[0]["fone_cli"].ToString();
            Email_cli = tabela_memoria.Rows[0]["email_cli"].ToString();
            RG_cli = tabela_memoria.Rows[0]["rg_cli"].ToString();
            CPF_cli = tabela_memoria.Rows[0]["cpf_cli"].ToString();
            Data_cadastro = Convert.ToDateTime(tabela_memoria.Rows[0]["data_cadastro"]);
            Senha_cli = tabela_memoria.Rows[0]["senha_cli"].ToString();
        }

        //método para selecionar todos os clientes
        public DataTable selecionarTodosNomes()
        {
            carregar_tabela("Select * from cliente");
            return tabela_memoria;
        }
    }
}
