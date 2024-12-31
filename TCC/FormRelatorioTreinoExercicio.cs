using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class FormRelatorioTreinoExercicio : Form
    {
        AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();

        public FormRelatorioTreinoExercicio()
        {
            InitializeComponent();
        }

        private void FormRelatorioTreinoExercicio_Load(object sender, EventArgs e)
        {
            RelatorioTreinoExercicio relatorio = new RelatorioTreinoExercicio();
            DataTable dt = acessoTreinoEx.relatorio(); 
            relatorio.SetDataSource(dt);
            crystalReportViewer1.ReportSource = relatorio;
        }
    }
}
