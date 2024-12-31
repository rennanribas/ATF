using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TCC
{
    public partial class FormBuscarMedidas : Form
    {
        public FormBuscarMedidas()
        {
            InitializeComponent();
        }

        private void FormBuscarMedidas_Load(object sender, EventArgs e)
        {
            //carrega comboBox com os nomes de todos os alunos
            comboBoxExibir.Text = "Coluna";
            AcessoCliente acessoCli = new AcessoCliente();
            comboBoxNomeAluno.DataSource = acessoCli.selecionarTodos();
            comboBoxNomeAluno.DisplayMember = "nome_cli";
            comboBoxNomeAluno.ValueMember = "id_cli";

            rbBraco.Checked = true;
            //chama o método para criar o gráfico utilizando do primeiro usuario do comboBox(selecionado)
            criarGrafico2Coluna(3, 4, "Braço Direito", "Braço Esquerdo");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //se houver medidas cadastradas no banco, cria o gráfico, usando o braço
                AcessoMedidas acessoMedidas = new AcessoMedidas();
                if (acessoMedidas.selecionarDataTablePorIDCli(comboBoxNomeAluno.SelectedValue.ToString()).Rows.Count > 0)
                {
                    criarGrafico2Coluna(3, 4, "Braço Direito", "Braço Esquerdo");
                    rbBraco.Checked = true;
                }
                else
                {
                    MessageBox.Show("Aluno não possui medidas, cadastre primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grafico.Series.Clear();
                }
            }
            catch
            {
            }
        }

        //método para preencher e completar o gráfico, usando uma medida só
        private void criarGrafico1Coluna(int coluna, String nomeColuna)
        {
            //cria o datatable dt e preenche com todas as medidas do cliente selecionado
            AcessoMedidas acessoMedidas = new AcessoMedidas();
            DataTable dt = acessoMedidas.selecionarDataTablePorIDCli(comboBoxNomeAluno.SelectedValue.ToString());
            DataTable tabVirtual = new DataTable();

            //cria uma tabela virtual, com novas colunas
            tabVirtual.Columns.Add("Data", Type.GetType("System.DateTime"));
            tabVirtual.Columns.Add("Membro", Type.GetType("System.String"));
            tabVirtual.Columns.Add("Medida", Type.GetType("System.String"));

            //preenche a tabela virtural, a partir do datatable com os dados do cliente, mudando as colunas para linhas
            for (int linha = 0; linha < dt.Rows.Count; linha++)
            {
                    DataRow dr = tabVirtual.NewRow();
                    string[] dataQuebrada = dt.Rows[linha]["data_med"].ToString().Split('|');
                    string[] horaQuebrada = dataQuebrada[1].Split(':');
                    dr["Data"] = Convert.ToDateTime(dataQuebrada[0]);
                    dr["Membro"] = nomeColuna;
                    dr["Medida"] = dt.Rows[linha][coluna].ToString().Replace(',','.');
                    tabVirtual.Rows.Add(dr);
            }
            //limpa o grafico, e a partir da tabela virtual, preenche o mesmo, da um "bind" no gráfico
            grafico.Series.Clear();
            grafico.DataBindCrossTable(tabVirtual.Rows, "Membro", "Data", "Medida",string.Empty);
            
            //arruma o gráfico, em todos os tipos de colunas, as "series"
           for (int i = 0; i < grafico.Series.Count; i++)
           {
               grafico.Series[i].BorderWidth = 5;
               grafico.Series[i].IsValueShownAsLabel = true;
               grafico.Series[i].BackGradientStyle = GradientStyle.DiagonalLeft;
               grafico.Series[i].LabelBackColor = Color.White;
            }

            //chama método para organizar o grafico a partir de coluna ou linha reta
           exibir();

            //altera a unidade de medida conforme o dado selecionado
           if (nomeColuna == "Altura")
               grafico.ChartAreas[0].AxisY.Title = "m";
           if (nomeColuna == "IMC")
               grafico.ChartAreas[0].AxisY.Title = "imc";
           if (nomeColuna == "Peso")
               grafico.ChartAreas[0].AxisY.Title = "kg";
           if (nomeColuna == "Percentual")
               grafico.ChartAreas[0].AxisY.Title = "%";
           if (nomeColuna != "Altura" && nomeColuna != "IMC" && nomeColuna != "Peso" && nomeColuna != "Percentual")
               grafico.ChartAreas[0].AxisY.Title = "cm";
        }

        //método para preencher e completar o gráfico, usando duas medidas, dois membros
        private void criarGrafico2Coluna(int col1, int col2, String nomeCol1, String nomeCol2)
        {
            //puxa do banco de dados as medidas por aluno
            AcessoMedidas acessoMedidas = new AcessoMedidas();
            DataTable dt = acessoMedidas.selecionarDataTablePorIDCli(comboBoxNomeAluno.SelectedValue.ToString());
            DataTable tabVirtual = new DataTable();

            //cria uma tabela virtual, e cria novas colunas
            tabVirtual.Columns.Add("Data", Type.GetType("System.DateTime"));
            tabVirtual.Columns.Add("Membro", Type.GetType("System.String"));
            tabVirtual.Columns.Add("Medida", Type.GetType("System.String"));

            //preenche a tabela virtual com dados das medidas da tabela que foi puxada do banco, ocm as medidas do cliente
            for (int linha = 0; linha < dt.Rows.Count; linha++)
            {
                for (int coluna = 3; coluna < dt.Columns.Count; coluna++)
                {
                    if (coluna == col1 || coluna == col2)
                    {
                        DataRow dr = tabVirtual.NewRow();
                        string[] dataQuebrada = dt.Rows[linha]["data_med"].ToString().Split('|');
                        string[] horaQuebrada = dataQuebrada[1].Split(':');
                        dr["Data"] = Convert.ToDateTime(dataQuebrada[0]);
                        if (coluna == col1)
                            dr["Membro"] = nomeCol1;
                        else
                            dr["Membro"] = nomeCol2;
                        dr["Medida"] = dt.Rows[linha][coluna].ToString().Replace(',', '.');

                        tabVirtual.Rows.Add(dr);
                    }
                }
            }
            //limpa o gráfico, e "binda" um novo a partir da tabela virtual
            grafico.Series.Clear();
            grafico.DataBindCrossTable(tabVirtual.Rows, "Membro", "Data", "Medida", string.Empty);

            //organiza as colunas do grafico, configura as mesmas.
            for (int i = 0; i < grafico.Series.Count; i++)
            {
                grafico.Series[i].BorderWidth = 5;
                grafico.Series[i].IsValueShownAsLabel = true;
                grafico.Series[i].BackGradientStyle = GradientStyle.DiagonalLeft;
                grafico.Series[i].LabelBackColor = Color.White;
            }
            //verifica se usuario está selecionando coluna ou linha reta, e altera o tipo da coluna, e coloca a unidade de cm
            //já que sempre que houver duas medidas juntas, sempre serão em cm
            exibir();
            grafico.ChartAreas[0].AxisY.Title = "cm";
        }

        //chama os métodos a partir de radio button selecionado
        #region Radio Buttons
        private void rbBraco_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico2Coluna(3, 4, "Braço Direito", "Braço Esquerdo");
        }

        private void rbAntebraco_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico2Coluna(5, 6, "Antebraço Direito", "Antebraço Esquerdo");
        }

        private void rbPeito_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(7, "Peito");
        }

        private void rbOmbro_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(8, "Ombro");
        }

        private void rbCostas_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(9, "Costas");
        }

        private void rbCoxas_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico2Coluna(10, 11, "Coxa Esquerda", "Coxa Direita");
        }

        private void rbPanturrilha_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico2Coluna(12, 13, "Panturrilha Esquerda", "Panturrilha Direita");
        }

        private void rbCintura_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(14, "Cintura");
        }

        private void rbAbdomen_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(15, "Abdomen");
        }

        private void rbQuadril_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(16, "Quadril");
        }

        private void rbAltura_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(17, "Altura");
        }

        private void rbPeso_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(18, "Peso");
        }

        private void rbIMC_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(19, "IMC");
        }

        private void rbPercentual_CheckedChanged(object sender, EventArgs e)
        {
            criarGrafico1Coluna(20, "Percentual");
        }
        #endregion

        private void comboBoxExibir_SelectedIndexChanged(object sender, EventArgs e)
        {
            //chama o método e exibe se usuario escolheu coluna ou linha reta
            exibir();
        }

        private void exibir()
        {
            //verifica o texto selecionado no comboBox, e altera para linha ou coluna
            SeriesChartType tipo = SeriesChartType.Column;
            switch (comboBoxExibir.Text)
            {
                case "Linha Reta": tipo = SeriesChartType.Line; break;
                case "Coluna": tipo = SeriesChartType.Column; break;
            }

            //muda todas as colunas, todos os tipos
            for (int i = 0; i < grafico.Series.Count; i++)
            {
                grafico.Series[i].ChartType = tipo;
            }
        }

        //caso esta variavel esteja ativada, move o gráfico
        bool clique = false;
        //ultimo ponto em que o mouse estava
        Point ultimo = new Point();
        private void grafico_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique && checkBox3D.Checked)
            {
                if (ultimo != null)
                {
                    //caso esteja 3D e o ultimo ponto não seja nulo, verifica para qual lado o mouse foi, e roda o grafico
                    if (ultimo.X < e.X)
                    {
                        if ((grafico.ChartAreas[0].Area3DStyle.Rotation-4) > -180)
                            grafico.ChartAreas[0].Area3DStyle.Rotation = grafico.ChartAreas[0].Area3DStyle.Rotation - 4;
                        else
                            grafico.ChartAreas[0].Area3DStyle.Rotation = 0;
                    }
                    else
                    {
                        if ((grafico.ChartAreas[0].Area3DStyle.Rotation + 4) < 180)
                            grafico.ChartAreas[0].Area3DStyle.Rotation = grafico.ChartAreas[0].Area3DStyle.Rotation +4;
                        else
                            grafico.ChartAreas[0].Area3DStyle.Rotation = 0;
                    }
                }
                ultimo = e.Location;
            }
        }

        private void grafico_MouseClick(object sender, MouseEventArgs e)
        {
            //controla se o mouse foi clicado ou não.
            if (clique)
                clique = false;
            else
                clique = true;
        }

        private void grafico_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //caso dê um clique duplo, redireciona o grafico para posição original, e altera a varivel clique para false
            //para o grafico não girar mais
            grafico.ChartAreas[0].Area3DStyle.Rotation = 30;
            grafico.ChartAreas[0].Area3DStyle.Inclination = 30;
            clique = false;
        }

        private void checkBox3D_CheckedChanged(object sender, EventArgs e)
        {
            //muda as propriedades para 3D e altera os labels de informação sobre o grafico em 3D
            if (checkBox3D.Checked)
            {
                grafico.ChartAreas[0].Area3DStyle.Enable3D = true;
                lblInfo3D1.Visible = true;
                lblInfo3D2.Visible = true;
            }
            else
            {
                grafico.ChartAreas[0].Area3DStyle.Enable3D = false;
                lblInfo3D1.Visible = false;
                lblInfo3D2.Visible = false;
            }
        }
    }
}
