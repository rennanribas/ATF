using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace TCC
{
    abstract class ConexaoEndereco
    {
        static MySqlConnection conectar;

        public static MySqlConnection Conectar
        {
            get { return ConexaoEndereco.conectar; }
            set { ConexaoEndereco.conectar = value; }
        }

        public static String criar_Conexao()
        {
            // verificando se existe uma conexão, fecha esta conexão
            if (conectar != null)
            {
                conectar.Close();
            }

            AcessoTxt acessoTxt = new AcessoTxt();
            // serve para configurar os parametros do banco de dados
            if (acessoTxt.ip() == string.Empty)
                return ("Erro ao conectar");
            string configuracao = string.Format("server={0};user id={1}; password={2};database=mysql; pooling=false", acessoTxt.ip(), "root", "ALUNOS");
            
            // tenta estabelecer conectar
            try
            {
                conectar = new MySqlConnection(configuracao);
                conectar.Open();
            }// caso não consiga exibe erro de conexão
            catch (MySqlException erro)
            {
                return ("Erro ao conectar " + erro);
            }
            
            // criar um banco em branco na memória
            MySqlDataReader banco = null;
           
            // fazer uso do banco escolhido
            MySqlCommand usar = new MySqlCommand("use enderco", conectar);
            
            // tenta criar o banco
            try
            {
                banco = usar.ExecuteReader();
            }// caso ocorra erro
            catch (MySqlException erro)
            {
                return ("Failed to populate database list: " + erro);
            }// no fim fecha
            finally
            {
                if (banco != null)
                {
                    banco.Close();
                }
            }

            return ("Conexão OK!!!");
        }
    }
}
