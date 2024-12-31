using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TCC
{
    class AcessoCliente
    {
        int ID_cli, num_cli;
       // double renda_cli;
        String codigo_cli,nome_cli, end_cli, bairro_cli, cidade_cli,
            UF_cli, cep_cli, pais_cli, sx_cli, estcivil_cli, email_cli, RG_cli, CPF_cli, fone_cli, senha_cli;
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
            //looping para desencriptar a tabela memoria
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    if(tabela_memoria.Columns[coluna].ColumnName != "codseg_cli")
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }

            try
            {
                DataView dv = tabela_memoria.DefaultView;
                dv.Sort = "nome_cli";
                tabela_memoria = dv.ToTable();
            }
            catch { }
        }

        //metodo para inserir cliente
        public void inserir(String codigo, String nome, String endereco, String numero, String bairro, String cidade, String estado, String cep
            , String pais, String sexo, String estadoCivil, String dataNasc, String fone, String email
            , String RG, String CPF, String senha)
        {
            DateTime dataNow = DateTime.Now;
            String dataCadastro = dataNow.ToString("yyyy-MM-dd");
            carregar_tabela("Insert into cliente values(0,'" + Cripto.cripto(codigo) + "','" + Cripto.cripto(nome) +
                "','" + Cripto.cripto(endereco) + "','" + Cripto.cripto(numero) + "','" + Cripto.cripto(bairro)
                + "','" + Cripto.cripto(cidade) + "','" + Cripto.cripto(estado) + "','" + Cripto.cripto(cep) + "','" 
                + Cripto.cripto(pais) + "','" + Cripto.cripto(sexo) + "','" + Cripto.cripto(estadoCivil) + "','"
                + Cripto.cripto(dataNasc) + "','" + Cripto.cripto(fone) + "','" + Cripto.cripto(email) + "','" 
                + Cripto.cripto(RG) + "','" + Cripto.cripto(CPF) + "','" +
                Cripto.cripto(dataCadastro) + "','" + Cripto.cripto(senha) + "','')");
        }

        //método para selecionar todos os dados da tabela cliente
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from cliente");
            return tabela_memoria;
        }

        //método para selecionar todos os dados de certo cliente por id e salvar nas variáveis encapsuladas
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

        //método para selecionar todos os dados de certo cliente por código de barras e salvar nas variáveis encapsuladas
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

        //método para alterar o cliente completamente
        public void alterarCliente(Int32 ID, String codigo, String nome, String endereco, String numero, String bairro, String cidade, String estado, String cep
            , String pais, String sexo, String estadoCivil, DateTime dataNasc, String fone, String email
            , String RG, String CPF, String senha)
        {
            String dataCertaNasc = dataNasc.ToString("yyyy-MM-dd");

            string query1 = "update cliente set codigo_cli ='" + Cripto.cripto(codigo) +  "',nome_cli='" + Cripto.cripto(nome) +
                "', end_cli ='" + Cripto.cripto(endereco)
                + "', num_cli = '" + Cripto.cripto(numero) + "', bairro_cli= '" + Cripto.cripto(bairro) + 
                "', cidade_cli ='" + Cripto.cripto(cidade) + "', UF_cli ='" + Cripto.cripto(estado) + "', cep_cli='" 
                + Cripto.cripto(cep) + "', pais_cli='" + Cripto.cripto(pais) + "', sx_cli='" + Cripto.cripto(sexo)
                + "', estcivil_cli='" + Cripto.cripto(estadoCivil) + "', dtnasc_cli='" + Cripto.cripto(dataCertaNasc)
                + "', fone_cli='" + Cripto.cripto(fone) + "', email_cli='" + Cripto.cripto(email) + 
                "', RG_cli='" + Cripto.cripto(RG) + "', CPF_cli= '" + Cripto.cripto(CPF)
                + "',senha_cli = '" + Cripto.cripto(senha) + 
                "' where ID_cli = " + ID ;
            carregar_tabela(query1);
        }

        //método para alterar cliente sem a senha
        public void alterarClienteSemSenha(Int32 ID, String codigo, String nome, String endereco, String numero, String bairro, String cidade, String estado, String cep
            , String pais, String sexo, String estadoCivil, DateTime dataNasc, String fone, String email
            , String RG, String CPF)
        {
            String dataCertaNasc = dataNasc.ToString("yyyy-MM-dd");

            string query1 = "update cliente set codigo_cli ='" + Cripto.cripto(codigo) + "',nome_cli='" + Cripto.cripto(nome) +
                "', end_cli ='" + Cripto.cripto(endereco)
                + "', num_cli = '" + Cripto.cripto(numero) + "', bairro_cli= '" + Cripto.cripto(bairro) +
                "', cidade_cli ='" + Cripto.cripto(cidade) + "', UF_cli ='" + Cripto.cripto(estado) + "', cep_cli='"
                + Cripto.cripto(cep) + "', pais_cli='" + Cripto.cripto(pais) + "', sx_cli='" + Cripto.cripto(sexo)
                + "', estcivil_cli='" + Cripto.cripto(estadoCivil) + "', dtnasc_cli='" + Cripto.cripto(dataCertaNasc)
                + "', fone_cli='" + Cripto.cripto(fone) + "', email_cli='" + Cripto.cripto(email) +
                "', RG_cli='" + Cripto.cripto(RG) + "', CPF_cli= '" + Cripto.cripto(CPF) + "' where ID_cli = " + ID;
            carregar_tabela(query1);
        }

        //método para selecionar todos os nomes de clientes.
        public DataTable selecionarTodosNomes()
        {
            carregar_tabela("Select * from cliente");
            return tabela_memoria;
        }

      
        internal void alterarCliente1(int id_cli, string p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7, string p_8, string sexo, string estcivil_cli, DateTime dataCerta, string p_9, string p_10, string p_11, string p_12, string p_13, string p_14)
        {
            throw new NotImplementedException();
        }
    }
}
