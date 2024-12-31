using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TCC
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

        public int ID_func1
        {
            get { return ID_func; }
            set { ID_func = value; }
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

            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //metodo para inserir dados
        public void inserir(String nome, String endereco, String numero, String bairro, String cidade, String estado, String cep
           , String pais, String sexo, String estadoCivil, String dataNasc, String fone, String email
           , String RG, String CPF, String turno, String senha, String adm)
        {
           

            carregar_tabela("Insert into funcionario values(0,'" + Cripto.cripto(nome) + "','" + Cripto.cripto(endereco) + "','" + Cripto.cripto(numero) + "','" + Cripto.cripto(bairro)
                + "','" + Cripto.cripto(cidade) + "','" + Cripto.cripto(estado) + "','" + Cripto.cripto(cep) + "','" + Cripto.cripto(pais) + "','" + Cripto.cripto(sexo) + "','" + Cripto.cripto(estadoCivil) + "','" + Cripto.cripto(dataNasc) + "','"
                 + Cripto.cripto(fone) + "','" + Cripto.cripto(email) + "','" + Cripto.cripto(RG) + "','" + Cripto.cripto(CPF) + "','" + Cripto.cripto(turno)+ "','" + Cripto.cripto(senha) +
                 "','" + Cripto.cripto(adm) +"')");
        }

        //metodo para selecionar os dados da tabela funcionario e retornar para o datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from funcionario");
            return tabela_memoria;
        }

        //verificar se possui administrador
        public bool verificarSeTemADM()
        {
            carregar_tabela("Select * from funcionario where ADM_func = '1'");
            if (tabela_memoria.Rows.Count == 0)
                return false;
            else
                return true;
        }

        //metodo para logar funcionario
        public string logarFuncionario(String email, String senha)
        {
            carregar_tabela("Select * from funcionario where email_func = '" + Cripto.cripto(email) 
                + "' and senha_func = '" + Cripto.cripto(senha) + "'");
            if (tabela_memoria.Rows.Count == 1)
            {
                ClasseGlobal.Logado = true;
                ClasseGlobal.Id_funcionario = Convert.ToInt32(tabela_memoria.Rows[0]["id_func"].ToString());
                if (tabela_memoria.Rows[0]["ADM_func"].ToString() == "1")
                {
                    ClasseGlobal.Adm = true;
                    return "Administrador Logado.";
                }
                else
                {
                    ClasseGlobal.Adm = false;
                    return "Logado.";
                }

            }
            else
                return "Usuario e/ou senha incorretos.";
        }

        //metodo para retornar o nome do funcionario
        public string nomeFunc(String idFunc)
        {
            carregar_tabela("select nome_func from funcionario where id_func = " + idFunc);
            return tabela_memoria.Rows[0]["nome_func"].ToString();
        }

        //metodo para alterar funcionario
        public void alterarFuncionario(String nome, String endereco, String numero, String bairro, String cidade, String estado, String cep
            , String pais, String sexo, String estadoCivil, String dataNasc, String fone, String email
            , String RG, String CPF, String turno, String senha, String adm, String ID_func)
        {
            
            string query = "update funcionario set nome_func = '" + Cripto.cripto(nome) + "',end_func='" + Cripto.cripto(endereco)
                + "', num_func =' " + Cripto.cripto(numero) + "', bairro_func = '" + Cripto.cripto(bairro) + "', cidade_func='" 
                + Cripto.cripto(cidade) + "', UF_func ='" + Cripto.cripto(estado) + "', cep_func ='" + Cripto.cripto(cep) + "', pais_func='" + Cripto.cripto(pais) +
                "',  sx_func='" + Cripto.cripto(sexo) + "', estcivil_func='" + Cripto.cripto(estadoCivil) + "', dtnasc_func='" + Cripto.cripto(dataNasc) + 
                "', fone_func='" + Cripto.cripto(fone) + "', email_func= '" + Cripto.cripto(email) + "', RG_func ='" + Cripto.cripto(RG) + "', CPF_func ='"
                + Cripto.cripto(CPF) + "', turno_func ='" + Cripto.cripto(turno) + "', Senha_func= '" 
                + Cripto.cripto(senha) + "', ADM_func = '" + Cripto.cripto(adm) + "' where ID_func = " + ID_func;
            carregar_tabela(query);
        }

        //metodo para buscar por ID e preencher as variaveis encapsuladas
        public void buscarporID(String ID)
        {
            carregar_tabela("select * from funcionario where ID_func = " + ID);
            ID_func1 = Convert.ToInt32(tabela_memoria.Rows[0]["ID_func"].ToString());
            Nome_func = tabela_memoria.Rows[0]["nome_func"].ToString();
            Numero = Convert.ToInt32(tabela_memoria.Rows[0]["num_func"].ToString());
            End_func = tabela_memoria.Rows[0]["end_func"].ToString();
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

        public bool verificarEmail(String email)
        {
            carregar_tabela("Select * from funcionario where email_func ='" + Cripto.cripto(email) + "'");
            if (tabela_memoria.Rows.Count > 0)
                return false;
            else
                return true;
        }
    }
}
