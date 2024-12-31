using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ponto
{
    class AcessoFuncionario
    {
        int ID_func, numero;
        string nome_func, end_func, bairro_func, cidade_func,
            UF_func, cep_func, pais_func, sx_func, estcivil_func, dtnasc_func, fone_func,
            email_func, RG_func, CPF_func, turno_func, senha_func, adm_func;

        #region Variaveis Encapsuladas

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Adm_func
        {
            get { return adm_func; }
            set { adm_func = value; }
        }

        public string Senha_func
        {
            get { return senha_func; }
            set { senha_func = value; }
        }

        public string Turno_func
        {
            get { return turno_func; }
            set { turno_func = value; }
        }

        public string CPF_func1
        {
            get { return CPF_func; }
            set { CPF_func = value; }
        }

        public string RG_func1
        {
            get { return RG_func; }
            set { RG_func = value; }
        }

        public string Email_func
        {
            get { return email_func; }
            set { email_func = value; }
        }

        public string Fone_func
        {
            get { return fone_func; }
            set { fone_func = value; }
        }

        public string Dtnasc_func
        {
            get { return dtnasc_func; }
            set { dtnasc_func = value; }
        }

        public string Estcivil_func
        {
            get { return estcivil_func; }
            set { estcivil_func = value; }
        }

        public string Sx_func
        {
            get { return sx_func; }
            set { sx_func = value; }
        }

        public string Pais_func
        {
            get { return pais_func; }
            set { pais_func = value; }
        }

        public string Cep_func
        {
            get { return cep_func; }
            set { cep_func = value; }
        }

        public string UF_func1
        {
            get { return UF_func; }
            set { UF_func = value; }
        }

        public string Cidade_func
        {
            get { return cidade_func; }
            set { cidade_func = value; }
        }

        public string Bairro_func
        {
            get { return bairro_func; }
            set { bairro_func = value; }
        }

        public string End_func
        {
            get { return end_func; }
            set { end_func = value; }
        }

        /*public double Salario_func
        {
            get { return salario_func; }
            set { salario_func = value; }
        }*/

        public string Nome_func
        {
            get { return nome_func; }
            set { nome_func = value; }
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

            //looping para desencriptar a tabela funcionario
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //método para selecionar todos os dados da tabela funcionario
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from funcionario");
            return tabela_memoria;
        }

        //método que verifica se já tem um admin cadastrado no banco de dados, caso sim, retorna true
        public bool verificarSeTemADM()
        {
            carregar_tabela("Select * from funcionario where ADM_func = '1'");
            if (tabela_memoria.Rows.Count == 0)
                return false;
            else
                return true;
        }

        //método para logar funcionario no sistema, ou seja, testa usuario e senha, caso sejam válidos,
        //retorna o valor "Administrador Logado.", caso o funcionario não seja administrador, retorna
        //"Autorizado apenas para administrador.", e caso o usuario e senha sejam inválidos, retorna
        //"Usuario e/ou senha incorretos."
        public string logarFuncionario(String email, String senha)
        {
            carregar_tabela("Select * from funcionario where email_func = '" + Cripto.cripto(email) + "' and senha_func = '" + Cripto.cripto(senha) + "'");
            if (tabela_memoria.Rows.Count == 1)
            {
                if (tabela_memoria.Rows[0]["ADM_func"].ToString() == "1")
                {
                    return "Administrador Logado.";
                }
                else
                    return "Autorizado apenas para administrador.";

            }
            else
                return "Usuario e/ou senha incorretos.";
        }

        //método para retornar o nome do funcionario, buscando pelo seu ID
        public string nomeFunc(String idFunc)
        {
            carregar_tabela("select nome_func from funcionario where id_func = " + idFunc);
            return tabela_memoria.Rows[0]["nome_func"].ToString();
        }

        //método onde busca os dados do funcionario pelo ID, e retorna preenchendo as variáveis encapsuladas
        public void buscarporID(String ID)
        {
            carregar_tabela("select * from funcionario where ID_func = " + ID);
            Nome_func = tabela_memoria.Rows[0]["nome_func"].ToString();
            Numero = Convert.ToInt32(tabela_memoria.Rows[0]["num_func"].ToString());
            Bairro_func = tabela_memoria.Rows[0]["bairro_func"].ToString();
            Cidade_func = tabela_memoria.Rows[0]["cidade_func"].ToString();
            UF_func1 = tabela_memoria.Rows[0]["UF_func"].ToString();
            Cep_func = tabela_memoria.Rows[0]["cep_func"].ToString();
            Pais_func = tabela_memoria.Rows[0]["pais_func"].ToString();
            Sx_func = tabela_memoria.Rows[0]["sx_func"].ToString();
            Estcivil_func = tabela_memoria.Rows[0]["estcivil_func"].ToString();
            Dtnasc_func = tabela_memoria.Rows[0]["dtnasc_func"].ToString();
            Fone_func = tabela_memoria.Rows[0]["fone_func"].ToString();
            Email_func = tabela_memoria.Rows[0]["email_func"].ToString();
            RG_func1 = tabela_memoria.Rows[0]["RG_func"].ToString();
            CPF_func1 = tabela_memoria.Rows[0]["CPF_func"].ToString();
            Turno_func = tabela_memoria.Rows[0]["turno_func"].ToString();
            Senha_func = tabela_memoria.Rows[0]["senha_func"].ToString();
            Adm_func = tabela_memoria.Rows[0]["ADM_func"].ToString();
        }
    }
}
