using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormAlterarGrupoMusculares : Form
    {
        public FormAlterarGrupoMusculares()
        {
            InitializeComponent();
        }

        private void FormAlterarGrupoMusculares_Load(object sender, EventArgs e)
        {
            //preenche comboBox do grupo muscular, com todos do banco
            AcessoGruposMusculares acesso = new AcessoGruposMusculares();
            cbEscolherGrupoMusuclar.DataSource = acesso.selecionarTodos();
            cbEscolherGrupoMusuclar.DisplayMember = "nome_gmusculares";
            cbEscolherGrupoMusuclar.ValueMember = "ID_gmusculares";
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //verifica de o campo obrigatorio está preenchido
                if (txtGrupoMuscular.Text != string.Empty)
                {
                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja alterar este grupo muscular?", "Confirmação alteração",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //caso o usuario confirme, altera no banco
                    if (dr == DialogResult.Yes)
                    {
                        AcessoGruposMusculares acesso = new AcessoGruposMusculares();
                        acesso.alterarGrupoMuscular(txtGrupoMuscular.Text, cbEscolherGrupoMusuclar.SelectedValue.ToString());
                        MessageBox.Show("Alterado com sucesso!", "Alteração Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbEscolherGrupoMusuclar.DataSource = acesso.selecionarTodos();
                        cbEscolherGrupoMusuclar.Focus();
                    }
                    else
                        MessageBox.Show("Alterção não confirmada.", "Confirmação negada", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Digite o novo nome do grupo muscular para alterar.", "Campo nulo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGrupoMuscular.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Houve algum erro ao alterar.", "Erro ao alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbEscolherGrupoMusuclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEscolherGrupoMusuclar.BackColor = Color.Empty;
            try
            {
                //pelo grupo muscular, preenche o textBox pelo ID selecionado no comboBox
                AcessoGruposMusculares acesso = new AcessoGruposMusculares();
                acesso.buscarporID(cbEscolherGrupoMusuclar.SelectedValue.ToString());
                txtGrupoMuscular.Text = acesso.Nome_gmusculares;
            }
            catch
            {
            }
        }

        private void txtGrupoMuscular_TextChanged(object sender, EventArgs e)
        {
            //caso precionado, volta para a cor original do textBox
            txtGrupoMuscular.BackColor = Color.Empty;
        }
    }
}
