using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class AcessoContrato
    {
        int id_cont, id_cli, id_func, id_fpgto, id_pacote, diasContrato;
        string nome_cli, nome_func, desc_formapag, nome_pacote;
        double valor_total;

        #region Variaveis Encapsuladas

        public string Nome_pacote
        {
            get { return nome_pacote; }
            set { nome_pacote = value; }
        }

        public string Desc_formapag
        {
            get { return desc_formapag; }
            set { desc_formapag = value; }
        }

        public string Nome_func
        {
            get { return nome_func; }
            set { nome_func = value; }
        }

        public string Nome_cli
        {
            get { return nome_cli; }
            set { nome_cli = value; }
        }

        public int DiasContrato
        {
            get { return diasContrato; }
            set { diasContrato = value; }
        }

        public int ID_pacote
        {
            get { return id_pacote; }
            set { id_pacote = value; }
        }

        public int ID_fpgto
        {
            get { return id_fpgto; }
            set { id_fpgto = value; }
        }

        public int ID_func
        {
            get { return id_func; }
            set { id_func = value; }
        }

        public int ID_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }

        public int ID_cont
        {
            get { return id_cont; }
            set { id_cont = value; }
        }

        public double Valor_total
        {
            get { return valor_total; }
            set { valor_total = value; }
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

            //looping para desencriptar a tabela memória
            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    if (tabela_memoria.Columns[coluna].ColumnName == "data_contrato" ||
                        tabela_memoria.Columns[coluna].ColumnName == "valor_total" ||
                        tabela_memoria.Columns[coluna].ColumnName == "dias_pacote" ||
                        tabela_memoria.Columns[coluna].ColumnName == "nome_cli" ||
                        tabela_memoria.Columns[coluna].ColumnName == "nome_func") 

                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //método para inserir na tabela contrato
        public void inserir(String ID_cli, String ID_func, String ID_fpgto, String ID_pacote, double valor_total)
        {
            DateTime dateNow = DateTime.Now;
            String dataCorreta = dateNow.ToString("yyyy-MM-dd");

            carregar_tabela("insert into contrato values(0," + ID_cli + "," + ID_func + "," + ID_fpgto + "," + 
                ID_pacote + ",'" +Cripto.cripto(dataCorreta) + "','" + Cripto.cripto(valor_total.ToString()) + "');");
        }

        //método para selecionar todos os dados da tabela
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from contrato");
            return tabela_memoria;
        }

        //método para selecionar dados de varias tabelas, usando o campo "id_cliente" da tabela contrato, para filtrar
        public void selecionarComInnerJoin(String id_cliente)
        {
            carregar_tabela("Select fp.id_fpgto, c.nome_cli, f.nome_func, fp.tipo_pgto, p.desc_pacote, co.data_contrato, co.valor_total, p.id_pacote"
                + " from contrato co inner join cliente c on co.id_cli = c.id_cli inner join funcionario f on co.id_func = f.id_func"
                + " inner join forma_pagamento fp on fp.id_fpgto = co.id_fpgto inner join pacotes p on p.id_pacote = co.id_pacote"
                + " where co.id_cli =" + id_cliente);
            if (tabela_memoria.Rows.Count == 1)
            {
                ID_fpgto = Convert.ToInt32(tabela_memoria.Rows[0]["id_fpgto"]);
                ID_pacote = Convert.ToInt32(tabela_memoria.Rows[0]["id_pacote"]);
                Nome_cli = tabela_memoria.Rows[0]["nome_cli"].ToString();
                Nome_func = tabela_memoria.Rows[0]["nome_func"].ToString();
                Desc_formapag = tabela_memoria.Rows[0]["tipo_pgto"].ToString();
                Nome_pacote = tabela_memoria.Rows[0]["desc_pacote"].ToString();
                Valor_total = Convert.ToDouble(tabela_memoria.Rows[0]["valor_total"]);
                DateTime dataContrato = Convert.ToDateTime(tabela_memoria.Rows[0]["data_contrato"].ToString());
                AcessoPacotes acessoPac = new AcessoPacotes();
                int diasPac = acessoPac.buscarDiasPacote(tabela_memoria.Rows[0]["id_pacote"].ToString());
                DateTime dataVencContrato = dataContrato.AddDays(diasPac);
                TimeSpan contaDiasFaltando = dataVencContrato - DateTime.Now;
                DiasContrato = contaDiasFaltando.Days;
            }
        }
        
        //método para atualizar dados da tabela cliente usando id_cliente
        public void atualizar(String idCli, String idFunc, String idFpgto, String idPac,
            DateTime dataContrato, String valor)
        {
            string dataCerta = dataContrato.ToString("yyyy-MM-dd");
            carregar_tabela("update contrato set id_func = " + idFunc + ", id_fpgto = " + idFpgto
                + ", id_pacote = " + idPac + ", data_contrato ='" + Cripto.cripto(dataCerta) + "', valor_total ='" 
                + Cripto.cripto(valor) + "' where id_cli = " + idCli);
        }

        //método para gerar uma tabela com todos os contratos vencidos
        public DataTable devedores()
        {
            carregar_tabela("Select c.id_cli, c.nome_cli, co.data_contrato, co.valor_total, p.dias_pacote"
            + " from contrato co inner join cliente c on co.id_cli = c.id_cli"
            + " inner join pacotes p on p.id_pacote = co.id_pacote");
                            
            AcessoPacotes acessoPac = new AcessoPacotes();
            DateTime dataContrato;
            int diasPac, diasVencimento;
            DateTime dataVencContrato;
            TimeSpan contaDiasFaltando;

            for(int i = 0; i< tabela_memoria.Rows.Count;i++)
            {
                dataContrato = Convert.ToDateTime(tabela_memoria.Rows[i]["data_contrato"]);
                diasPac = Convert.ToInt32(tabela_memoria.Rows[i]["dias_pacote"]);
                dataVencContrato = dataContrato.AddDays(diasPac);
                contaDiasFaltando = dataVencContrato - DateTime.Now;
                diasVencimento = contaDiasFaltando.Days;
                if (diasVencimento > 0)
                    tabela_memoria.Rows[i].Delete();
                else
                    tabela_memoria.Rows[i]["data_contrato"] = dataVencContrato.ToShortDateString();
            }
            return tabela_memoria;
        }

        //método para verificar se o contrato de certo cliente está ou não atrasado, caso não esteja, retorna false
        public bool verificarContratos(String idCliente)
        {
            carregar_tabela("Select c.id_cli, c.nome_cli, co.data_contrato, co.valor_total, p.dias_pacote"
            + " from contrato co inner join cliente c on co.id_cli = c.id_cli"
            + " inner join pacotes p on p.id_pacote = co.id_pacote where c.id_cli =" + idCliente);

            try
            {
                AcessoPacotes acessoPac = new AcessoPacotes();
                DateTime dataContrato;
                int diasPac, diasVencimento;
                DateTime dataVencContrato;
                TimeSpan contaDiasFaltando;
                dataContrato = Convert.ToDateTime(tabela_memoria.Rows[0]["data_contrato"]);
                diasPac = Convert.ToInt32(tabela_memoria.Rows[0]["dias_pacote"]);
                dataVencContrato = dataContrato.AddDays(diasPac);
                contaDiasFaltando = dataVencContrato - DateTime.Now;
                diasVencimento = contaDiasFaltando.Days;
                if (diasVencimento > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        //método para verificar se o cliente já tem contrato, usando o id do mesmo
        public bool temContrato(String idCliente)
        {
            carregar_tabela("Select * from contrato where id_cli=" + idCliente);
            if (tabela_memoria.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
