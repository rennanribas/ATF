using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarMedidas : Form
    {
        public FormAlterarMedidas()
        {
            InitializeComponent();
        }

        private void FormAlterarMedidas_Load(object sender, EventArgs e)
        {
            //preenche comboBox com todos clientes do banco
            AcessoCliente acessoCli = new AcessoCliente();
            comboBoxAluno.DataSource = acessoCli.selecionarTodos();
            comboBoxAluno.DisplayMember = "nome_cli";
            comboBoxAluno.ValueMember = "id_cli";
            comboBoxData.DataSource = new DataTable();
            AcessoMedidas acessoMedidas = new AcessoMedidas();
            DataTable dt = new DataTable();
            //verifica se algum cliente foi selecionado, caso sim, busca no banco por o id do cliente, e preenche 
            // com as medidas do mesmo
            if(comboBoxAluno.SelectedIndex != -1)
              dt  = acessoMedidas.selecionarDataTablePorIDCli(comboBoxAluno.SelectedValue.ToString());
            if (dt.Rows.Count != 0)
            {
                //looping para alterar o modo de exibir a data
                for (int linha = 0; linha < dt.Rows.Count; linha++)
                {
                    string[] quebrada = dt.Rows[linha]["data_med"].ToString().Split('|');
                    dt.Rows[linha]["data_med"] = "Dia " + quebrada[0] + ",às " + quebrada[1];
                }
                //preenche os dados nos componentes do form
                comboBoxData.DataSource = dt;
                comboBoxData.DisplayMember = "data_med";
                comboBoxData.ValueMember = "id_med";
                acessoMedidas.selecionarPorID(comboBoxData.SelectedValue.ToString());
                dPDia.Text = acessoMedidas.Data_med.ToLongDateString();
                dPHorario.Text = acessoMedidas.Data_med.ToShortTimeString();
                numBraDir.Value = Convert.ToDecimal(acessoMedidas.Bracodir_med);
                numBraEsq.Value = Convert.ToDecimal(acessoMedidas.Bracoesq_med);
                numAnteDir.Value = Convert.ToDecimal(acessoMedidas.Antebracodir_med);
                numAnteEsq.Value = Convert.ToDecimal(acessoMedidas.Antebracoesq_med);
                numPeito.Value = Convert.ToDecimal(acessoMedidas.Peito_med);
                numOmbro.Value = Convert.ToDecimal(acessoMedidas.Ombro_med);
                numCostas.Value = Convert.ToDecimal(acessoMedidas.Costas_med);
                numCoxaDir.Value = Convert.ToDecimal(acessoMedidas.Coxadir_med);
                numCoxaEsq.Value = Convert.ToDecimal(acessoMedidas.Coxaesq_med);
                numPantDir.Value = Convert.ToDecimal(acessoMedidas.Pantdir_med);
                numPantEsq.Value = Convert.ToDecimal(acessoMedidas.Pantesq_med);
                numCintura.Value = Convert.ToDecimal(acessoMedidas.Cintura_med);
                numAbd.Value = Convert.ToDecimal(acessoMedidas.Abdomen_med);
                numQuadril.Value = Convert.ToDecimal(acessoMedidas.Quadril_med);
                numAltura.Value = Convert.ToDecimal(acessoMedidas.Altura_med);
                numPeso.Value = Convert.ToDecimal(acessoMedidas.Peso_med);
                txtIMC.Text = acessoMedidas.IMC_med1;
                numPercent.Value = Convert.ToDecimal(acessoMedidas.Percent_med);
            }
        }

        private void comboBoxAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //zera todos os campos, caso alguma variavel na hora de preencher, seja nula.
            dPDia.Text = string.Empty;
            dPHorario.Text = string.Empty;
            numBraDir.Value = Convert.ToDecimal(0);
            numBraEsq.Value = Convert.ToDecimal(0);
            numAnteDir.Value = Convert.ToDecimal(0);
            numAnteEsq.Value = Convert.ToDecimal(0);
            numPeito.Value = Convert.ToDecimal(0);
            numOmbro.Value = Convert.ToDecimal(0);
            numCostas.Value = Convert.ToDecimal(0);
            numCoxaDir.Value = Convert.ToDecimal(0);
            numCoxaEsq.Value = Convert.ToDecimal(0);
            numPantDir.Value = Convert.ToDecimal(0);
            numPantEsq.Value = Convert.ToDecimal(0);
            numCintura.Value = Convert.ToDecimal(0);
            numAbd.Value = Convert.ToDecimal(0);
            numQuadril.Value = Convert.ToDecimal(0);
            numAltura.Value = Convert.ToDecimal(0);
            numPeso.Value = Convert.ToDecimal(0);
            txtIMC.Text = string.Empty;
            numPercent.Value = Convert.ToDecimal(0);

            try
            {
                //completa por aluno todos os componentes do form, buscando no banco por ID
                comboBoxData.DataSource = new DataTable();
                AcessoMedidas acessoMedidas = new AcessoMedidas();
                DataTable dt = new DataTable();
                if (comboBoxAluno.SelectedIndex != -1)
                    dt = acessoMedidas.selecionarDataTablePorIDCli(comboBoxAluno.SelectedValue.ToString());
                if (dt.Rows.Count != 0)
                {
                    for (int linha = 0; linha < dt.Rows.Count; linha++)
                    {
                        string[] quebrada = dt.Rows[linha]["data_med"].ToString().Split('|');
                        dt.Rows[linha]["data_med"] = "Dia " + quebrada[0] + ",às " + quebrada[1];
                    }
                    comboBoxData.DataSource = dt;
                    comboBoxData.DisplayMember = "data_med";
                    comboBoxData.ValueMember = "id_med";
                    acessoMedidas.selecionarPorID(comboBoxData.SelectedValue.ToString());
                    dPDia.Text = acessoMedidas.Data_med.ToLongDateString();
                    dPHorario.Text = acessoMedidas.Data_med.ToShortTimeString();
                    numBraDir.Value = Convert.ToDecimal(acessoMedidas.Bracodir_med);
                    numBraEsq.Value = Convert.ToDecimal(acessoMedidas.Bracoesq_med);
                    numAnteDir.Value = Convert.ToDecimal(acessoMedidas.Antebracodir_med);
                    numAnteEsq.Value = Convert.ToDecimal(acessoMedidas.Antebracoesq_med);
                    numPeito.Value = Convert.ToDecimal(acessoMedidas.Peito_med);
                    numOmbro.Value = Convert.ToDecimal(acessoMedidas.Ombro_med);
                    numCostas.Value = Convert.ToDecimal(acessoMedidas.Costas_med);
                    numCoxaDir.Value = Convert.ToDecimal(acessoMedidas.Coxadir_med);
                    numCoxaEsq.Value = Convert.ToDecimal(acessoMedidas.Coxaesq_med);
                    numPantDir.Value = Convert.ToDecimal(acessoMedidas.Pantdir_med);
                    numPantEsq.Value = Convert.ToDecimal(acessoMedidas.Pantesq_med);
                    numCintura.Value = Convert.ToDecimal(acessoMedidas.Cintura_med);
                    numAbd.Value = Convert.ToDecimal(acessoMedidas.Abdomen_med);
                    numQuadril.Value = Convert.ToDecimal(acessoMedidas.Quadril_med);
                    numAltura.Value = Convert.ToDecimal(acessoMedidas.Altura_med);
                    numPeso.Value = Convert.ToDecimal(acessoMedidas.Peso_med);
                    txtIMC.Text = acessoMedidas.IMC_med1;
                    numPercent.Value = Convert.ToDecimal(acessoMedidas.Percent_med);
                }
            }
            catch
            { }
        }

        private void comboBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {
            //zera todos os campos
            dPDia.Text = string.Empty;
            dPHorario.Text = string.Empty;
            numBraDir.Value = Convert.ToDecimal(0);
            numBraEsq.Value = Convert.ToDecimal(0);
            numAnteDir.Value = Convert.ToDecimal(0);
            numAnteEsq.Value = Convert.ToDecimal(0);
            numPeito.Value = Convert.ToDecimal(0);
            numOmbro.Value = Convert.ToDecimal(0);
            numCostas.Value = Convert.ToDecimal(0);
            numCoxaDir.Value = Convert.ToDecimal(0);
            numCoxaEsq.Value = Convert.ToDecimal(0);
            numPantDir.Value = Convert.ToDecimal(0);
            numPantEsq.Value = Convert.ToDecimal(0);
            numCintura.Value = Convert.ToDecimal(0);
            numAbd.Value = Convert.ToDecimal(0);
            numQuadril.Value = Convert.ToDecimal(0);
            numAltura.Value = Convert.ToDecimal(0);
            numPeso.Value = Convert.ToDecimal(0);
            txtIMC.Text = string.Empty;
            numPercent.Value = Convert.ToDecimal(0);

            try
            {
                //preenche os componentes pelo id da data selecionada
                AcessoMedidas acessoMedidas = new AcessoMedidas();
                acessoMedidas.selecionarPorID(comboBoxData.SelectedValue.ToString());
                dPDia.Text = acessoMedidas.Data_med.ToLongDateString();
                dPHorario.Text = acessoMedidas.Data_med.ToShortTimeString();
                numBraDir.Value = Convert.ToDecimal(acessoMedidas.Bracodir_med);
                numBraEsq.Value = Convert.ToDecimal(acessoMedidas.Bracoesq_med);
                numAnteDir.Value = Convert.ToDecimal(acessoMedidas.Antebracodir_med);
                numAnteEsq.Value = Convert.ToDecimal(acessoMedidas.Antebracoesq_med);
                numPeito.Value = Convert.ToDecimal(acessoMedidas.Peito_med);
                numOmbro.Value = Convert.ToDecimal(acessoMedidas.Ombro_med);
                numCostas.Value = Convert.ToDecimal(acessoMedidas.Costas_med);
                numCoxaDir.Value = Convert.ToDecimal(acessoMedidas.Coxadir_med);
                numCoxaEsq.Value = Convert.ToDecimal(acessoMedidas.Coxaesq_med);
                numPantDir.Value = Convert.ToDecimal(acessoMedidas.Pantdir_med);
                numPantEsq.Value = Convert.ToDecimal(acessoMedidas.Pantesq_med);
                numCintura.Value = Convert.ToDecimal(acessoMedidas.Cintura_med);
                numAbd.Value = Convert.ToDecimal(acessoMedidas.Abdomen_med);
                numQuadril.Value = Convert.ToDecimal(acessoMedidas.Quadril_med);
                numAltura.Value = Convert.ToDecimal(acessoMedidas.Altura_med);
                numPeso.Value = Convert.ToDecimal(acessoMedidas.Peso_med);
                txtIMC.Text = acessoMedidas.IMC_med1;
                numPercent.Value = Convert.ToDecimal(acessoMedidas.Percent_med);
            }
            catch
            {

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //caso o usuario confirme, altera no banco de dados, e exibe mensagem
                    AcessoMedidas acessoMedidas = new AcessoMedidas();
                    acessoMedidas.selecionarTodos();
                    String dataMedida = dPDia.Value.ToShortDateString() + "|" + dPHorario.Value.ToShortTimeString();
                    acessoMedidas.alterar(comboBoxAluno.SelectedValue.ToString(), dataMedida, numBraDir.Value.ToString(), numBraEsq.Value.ToString()
                        , numAnteDir.Value.ToString(), numAnteEsq.Value.ToString(), numPeito.Value.ToString(), numOmbro.Value.ToString()
                        , numCostas.Value.ToString(), numCoxaDir.Value.ToString(), numCoxaEsq.Value.ToString(), numPantDir.Value.ToString()
                        , numPantEsq.Value.ToString(), numCintura.Value.ToString(), numAbd.Value.ToString(), numQuadril.Value.ToString()
                        , numAltura.Value.ToString(), numPeso.Value.ToString(), txtIMC.Text, numPercent.Value.ToString(), comboBoxData.SelectedValue.ToString());
                    MessageBox.Show("Alterado com sucesso!", "Alteração Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxData.DataSource = new DataTable();
                    DataTable dt = acessoMedidas.selecionarDataTablePorIDCli(comboBoxAluno.SelectedValue.ToString());
                    if (dt.Rows.Count != 0)
                    {
                        for (int linha = 0; linha < dt.Rows.Count; linha++)
                        {
                            string[] quebrada = dt.Rows[linha]["data_med"].ToString().Split('|');
                            dt.Rows[linha]["data_med"] = "Dia " + quebrada[0] + ",às " + quebrada[1];
                        }
                        comboBoxData.DataSource = dt;
                        comboBoxData.DisplayMember = "data_med";
                        comboBoxData.ValueMember = "id_med";
                    }
                }
                else
                    MessageBox.Show("Cadastro não alterado", "Confirmação Negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Houve algum erro ao alterar, tente outra vez.", "Erro ao alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numPeso_ValueChanged(object sender, EventArgs e)
        {
            //caso altere o peso, tenta calcular o IMC
            calcularIMC();
        }

        private void calcularIMC()
        {
            try
            {
                //verifica se os campos estão preenchidos, caso sim, calcula o imc, caso não, não calcula
                if (Convert.ToDouble(numAltura.Value) != 0 && Convert.ToDouble(numPeso.Value) != 0)
                {
                    double imc = Convert.ToDouble(numPeso.Value) /
                        (Convert.ToDouble(numAltura.Value) * Convert.ToDouble(numAltura.Value));
                    string[] imcQuebrado = imc.ToString().Replace('.', ',').Split(',');
                    txtIMC.Text = imcQuebrado[0] + "," + imcQuebrado[1].Substring(0, 2);
                }
            }
            catch
            {
            }
        }

        private void numAltura_ValueChanged(object sender, EventArgs e)
        {
            //caso altera a altura, calcula o imc
            calcularIMC();
        }
    }
}
