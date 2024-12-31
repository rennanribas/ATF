using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace TCC
{
    class AcessoMedidas
    {
        string bracodir_med, bracoesq_med, antebracodir_med, antebracoesq_med, peito_med, ombro_med,
        costas_med,coxadir_med,coxaesq_med,pantdir_med,pantesq_med,cintura_med,abdomen_med,
        quadril_med, altura_med, peso_med, IMC_med, percent_med;
        int id_med, id_cli;
        DateTime data_med;

        #region Variaveis Encapsuladas
        public DateTime Data_med
        {
            get { return data_med; }
            set { data_med = value; }
        }

        public string IMC_med1
        {
            get { return IMC_med; }
            set { IMC_med = value; }
        }

        public string Peso_med
        {
            get { return peso_med; }
            set { peso_med = value; }
        }

        public string Altura_med
        {
            get { return altura_med; }
            set { altura_med = value; }
        }

        public string Quadril_med
        {
            get { return quadril_med; }
            set { quadril_med = value; }
        }

        public string Abdomen_med
        {
            get { return abdomen_med; }
            set { abdomen_med = value; }
        }

        public string Cintura_med
        {
            get { return cintura_med; }
            set { cintura_med = value; }
        }

        public string Pantesq_med
        {
            get { return pantesq_med; }
            set { pantesq_med = value; }
        }

        public string Pantdir_med
        {
            get { return pantdir_med; }
            set { pantdir_med = value; }
        }

        public string Coxaesq_med
        {
            get { return coxaesq_med; }
            set { coxaesq_med = value; }
        }

        public string Coxadir_med
        {
            get { return coxadir_med; }
            set { coxadir_med = value; }
        }

        public string Costas_med
        {
            get { return costas_med; }
            set { costas_med = value; }
        }

        public string Ombro_med
        {
            get { return ombro_med; }
            set { ombro_med = value; }
        }

        public string Peito_med
        {
            get { return peito_med; }
            set { peito_med = value; }
        }

        public string Antebracoesq_med
        {
            get { return antebracoesq_med; }
            set { antebracoesq_med = value; }
        }

        public string Antebracodir_med
        {
            get { return antebracodir_med; }
            set { antebracodir_med = value; }
        }

        public string Bracoesq_med
        {
            get { return bracoesq_med; }
            set { bracoesq_med = value; }
        }

        public string Percent_med
        {
            get { return percent_med; }
            set { percent_med = value; }
        }

        public string Bracodir_med
        {
            get { return bracodir_med; }
            set { bracodir_med = value; }
        }
        public int Id_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }

        public int Id_med
        {
            get { return id_med; }
            set { id_med = value; }
        }
        #endregion

        //Variaveis para acesso ao MYSQL
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;

        //metodo para de acesso ao BD
        private void carregar_tabela(String comando)
        {
            tabela_memoria = new DataTable();

            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);

            for (int linha = 0; linha < tabela_memoria.Rows.Count; linha++)
            {
                for (int coluna = 0; coluna < tabela_memoria.Columns.Count; coluna++)
                {
                    if(tabela_memoria.Columns[coluna].ColumnName != "id_med" 
                        && tabela_memoria.Columns[coluna].ColumnName != "id_cli")
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }
        }

        //metodo para selecionar os dados da tabela medidas e retornar o datatable
        public DataTable selecionarTodos()
        {
            carregar_tabela("Select * from medidas");
            return tabela_memoria;
        }

        //metodo para inserir dados na tabela medidas
        public void inserir(String idCli, String data_med, String bracodir_med, String bracoesq_med,
            String antebracodir_med, String antebracoesq_med, String peito_med, String ombro_med, String costas_med,
            String coxadir_med, String coxaesq_med, String pantdir_med, String pantesq_med, String cintura_med,
            String abdomen_med, String quadril_med, String altura_med, String peso_med, String IMC_med,
            String percent_med)
        {
            carregar_tabela("Insert into medidas values(0," + idCli + ",'" + Cripto.cripto(data_med) + "','" +
                Cripto.cripto(bracodir_med) + "','" + Cripto.cripto(bracoesq_med) + "','" + Cripto.cripto(antebracodir_med)
                + "','" + Cripto.cripto(antebracoesq_med) + "','" + Cripto.cripto(peito_med) + "','" + Cripto.cripto(ombro_med)
                + "','" + Cripto.cripto(costas_med) + "','" + Cripto.cripto(coxadir_med) + "','" + Cripto.cripto(coxaesq_med)
                + "','" + Cripto.cripto(pantdir_med) + "','" + Cripto.cripto(pantesq_med) + "','" + Cripto.cripto(cintura_med)
                + "','" + Cripto.cripto(abdomen_med) + "','" + Cripto.cripto(quadril_med) + "','" + Cripto.cripto(altura_med)
                + "','" + Cripto.cripto(peso_med) + "','" + Cripto.cripto(IMC_med) + "','" + Cripto.cripto(percent_med) + "')");
        }

        //metodo para alterar dados na tabela medida
        public void alterar(String idCli, String data_med, String bracodir_med, String bracoesq_med,
            String antebracodir_med, String antebracoesq_med, String peito_med, String ombro_med, String costas_med,
            String coxadir_med, String coxaesq_med, String pantdir_med, String pantesq_med, String cintura_med,
            String abdomen_med, String quadril_med, String altura_med, String peso_med, String IMC_med,
            String percent_med, String id_med)
        {
            carregar_tabela("Update medidas set id_cli = " + idCli + ",data_med = '" + Cripto.cripto(data_med) + "',bracodir_med ='" +
    Cripto.cripto(bracodir_med) + "',bracoesq_med = '" + Cripto.cripto(bracoesq_med) + "',antebracodir_med = '" + Cripto.cripto(antebracodir_med)
    + "',antebracoesq_med = '" + Cripto.cripto(antebracoesq_med) + "',peito_med = '" + Cripto.cripto(peito_med) + "',ombro_med = '" + Cripto.cripto(ombro_med)
    + "',costas_med = '" + Cripto.cripto(costas_med) + "',coxadir_med = '" + Cripto.cripto(coxadir_med) + "',coxaesq_med = '" + Cripto.cripto(coxaesq_med)
    + "',pantdir_med = '" + Cripto.cripto(pantdir_med) + "',pantesq_med = '" + Cripto.cripto(pantesq_med) + "',cintura_med = '" + Cripto.cripto(cintura_med)
    + "',abdomen_med = '" + Cripto.cripto(abdomen_med) + "',quadril_med = '" + Cripto.cripto(quadril_med) + "',altura_med = '" + Cripto.cripto(altura_med)
    + "',peso_med = '" + Cripto.cripto(peso_med) + "',imc_med = '" + Cripto.cripto(IMC_med) + "',percent_med = '" + Cripto.cripto(percent_med) 
    + "' where id_med = " + id_med);
        }

        //metodo para selecionar os dados na tabela medidas e retornar para o datatable
        public DataTable selecionarDataTablePorIDCli(String id_cli)
        {
            carregar_tabela("Select * from medidas where id_cli = " + id_cli);
            return tabela_memoria;
        }

        //metodo para selecionar por ID e preencher as variaveis encapsuladas
        public void selecionarPorID(String idMed)
        {
            carregar_tabela("Select * from medidas where id_med = " + idMed);
            Id_med = Convert.ToInt32(Cripto.descripto(tabela_memoria.Rows[0]["id_med"].ToString()));
            Id_cli = Convert.ToInt32(Cripto.descripto(tabela_memoria.Rows[0]["id_cli"].ToString()));
            string[] dataQuebrada = Cripto.descripto(tabela_memoria.Rows[0]["data_med"].ToString()).Split('|');
            string[] horaQubrada = dataQuebrada[1].Split(':');
            Data_med = Convert.ToDateTime(dataQuebrada[0]).AddHours(Convert.ToDouble(horaQubrada[0])).
                AddMinutes(Convert.ToDouble(horaQubrada[1]));
            Bracodir_med = Cripto.descripto(tabela_memoria.Rows[0]["bracodir_med"].ToString());
            bracoesq_med = Cripto.descripto(tabela_memoria.Rows[0]["bracoesq_med"].ToString());
            Antebracodir_med = Cripto.descripto(tabela_memoria.Rows[0]["Antebracodir_med"].ToString());
            Antebracoesq_med = Cripto.descripto(tabela_memoria.Rows[0]["Antebracoesq_med"].ToString());
            Peito_med = Cripto.descripto(tabela_memoria.Rows[0]["Peito_med"].ToString());
            Ombro_med = Cripto.descripto(tabela_memoria.Rows[0]["Ombro_med"].ToString());
            Costas_med = Cripto.descripto(tabela_memoria.Rows[0]["Costas_med"].ToString());
            Coxadir_med = Cripto.descripto(tabela_memoria.Rows[0]["Coxadir_med"].ToString());
            Coxaesq_med = Cripto.descripto(tabela_memoria.Rows[0]["Coxaesq_med"].ToString());
            Pantdir_med = Cripto.descripto(tabela_memoria.Rows[0]["Pantdir_med"].ToString());
            Pantesq_med = Cripto.descripto(tabela_memoria.Rows[0]["Pantesq_med"].ToString());
            Cintura_med = Cripto.descripto(tabela_memoria.Rows[0]["Cintura_med"].ToString());
            Abdomen_med = Cripto.descripto(tabela_memoria.Rows[0]["Abdomen_med"].ToString());
            Quadril_med = Cripto.descripto(tabela_memoria.Rows[0]["Quadril_med"].ToString());
            Altura_med = Cripto.descripto(tabela_memoria.Rows[0]["Altura_med"].ToString());
            Peso_med = Cripto.descripto(tabela_memoria.Rows[0]["Peso_med"].ToString());
            IMC_med1 = Cripto.descripto(tabela_memoria.Rows[0]["IMC_med"].ToString());
            Percent_med = Cripto.descripto(tabela_memoria.Rows[0]["Percent_med"].ToString());
        }
    }
}
