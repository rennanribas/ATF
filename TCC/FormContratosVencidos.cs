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
    public partial class FormContratosVencidos : Form
    {
        public FormContratosVencidos()
        {
            InitializeComponent();
        }

        private void FormContratosVencidos_Load(object sender, EventArgs e)
        {
            AcessoContrato acessoCont = new AcessoContrato();
            dataGridView1.DataSource = acessoCont.devedores();
            dataGridView1.Columns["id_cli"].Visible = false;
            dataGridView1.Columns["nome_cli"].HeaderText = "Cliente";
            dataGridView1.Columns["data_contrato"].HeaderText = "Data de Vencimento";
            dataGridView1.Columns["valor_total"].HeaderText = "Valor Pago";
            dataGridView1.Columns["dias_pacote"].HeaderText = "Dias do pacote";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ClasseGlobal.Contrato = true;
                ClasseGlobal.Id_cliente = Convert.ToInt32(dataGridView1["id_cli", dataGridView1.CurrentRow.Index].Value.ToString());
                FormAlterarContrato frmContrato = new FormAlterarContrato();
                frmContrato.MdiParent = this.MdiParent;
                frmContrato.Show();
            }
            catch
            {
                MessageBox.Show("Selecione uma linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnContrato_Click(object sender, EventArgs e)
        {
            try
            {
                ClasseGlobal.Contrato = true;
                ClasseGlobal.Id_cliente = Convert.ToInt32(dataGridView1["id_cli", dataGridView1.CurrentRow.Index].Value.ToString());
                FormAlterarContrato frmContrato = new FormAlterarContrato();
                frmContrato.MdiParent = this.MdiParent;
                frmContrato.Show();
            }
            catch
            {
                MessageBox.Show("Selecione uma linha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
