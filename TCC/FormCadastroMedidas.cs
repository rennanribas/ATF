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
    public partial class FormCadastroMedidas : Form
    {
        public FormCadastroMedidas()
        {
            InitializeComponent();
        }

        private void FormCadastroMedidas_Load(object sender, EventArgs e)
        {
            AcessoCliente acessoCli = new AcessoCliente();
            cbAluno.DataSource = acessoCli.selecionarTodos();
            cbAluno.ValueMember = "id_cli";
            cbAluno.DisplayMember = "nome_cli";
        }

        private void numPeso_ValueChanged(object sender, EventArgs e)
        {
            calcularIMC();
        }

        private void numAltura_ValueChanged(object sender, EventArgs e)
        {
            calcularIMC();
        }

        private void calcularIMC()
        {
            try
            {
                if (Convert.ToDouble(numAltura.Value) != 0)
                {
                    double imc = Convert.ToDouble(numPeso.Value) /
                        (Convert.ToDouble(numAltura.Value) * Convert.ToDouble(numAltura.Value));
                    string[] imcQuebrado = imc.ToString().Replace('.',',').Split(',');
                    txtIMC.Text = imcQuebrado[0] + "," + imcQuebrado[1].Substring(0, 2);
                }
            }
            catch
            {
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Tem certeza de que deseja cadastrar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    AcessoMedidas acessoMedidas = new AcessoMedidas();
                    acessoMedidas.selecionarTodos();
                    String dataMedida = dPDia.Value.ToShortDateString() + "|" + dPHorario.Value.ToShortTimeString();
                    acessoMedidas.inserir(cbAluno.SelectedValue.ToString(), dataMedida, numBraDir.Value.ToString(), numBraEsq.Value.ToString()
                        , numAnteDir.Value.ToString(), numAnteEsq.Value.ToString(), numPeito.Value.ToString(), numOmbro.Value.ToString()
                        , numCostas.Value.ToString(), numCoxaDir.Value.ToString(), numCoxaEsq.Value.ToString(), numPantDir.Value.ToString()
                        , numPantEsq.Value.ToString(), numCintura.Value.ToString(), numAbd.Value.ToString(), numQuadril.Value.ToString()
                        , numAltura.Value.ToString(), numPeso.Value.ToString(), txtIMC.Text, numPercent.Value.ToString());
                    MessageBox.Show("Cadastrado com sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Cadastro não confirmado.", "Confirmação Negada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Houve algum erro ao cadastrar, tente outra vez.", "Erro ao cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
