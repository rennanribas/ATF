using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Drawing2D;

namespace TCC
{
    public partial class FormGerarCodigoDeBarras : Form
    {
        Font fonte;
        StringReader leitor;

        public FormGerarCodigoDeBarras()
        {
            InitializeComponent();
        }

        private void FormGerarCodigoDeBarras_Load(object sender, EventArgs e)
        {
            AcessoCliente acessoCli = new AcessoCliente();
            cbAluno.DataSource = acessoCli.selecionarTodos();
            cbAluno.DisplayMember = "nome_cli";
            cbAluno.ValueMember = "codigo_cli";
            if (ClasseGlobal.Id_cliente != null)
            {
                gerarCB();
            }
        }
        private void carregaFonte()
        {
            string caminhoStart = Application.StartupPath.ToString();
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(caminhoStart + @"\FREE3OF9.TTF");

            FontFamily fontFamily = pfc.Families[0];
            fonte = new Font(fontFamily,50);
        }

        private string formataCodigoBarras(string codigo)
        {
            string codigoBarras = string.Empty;
            codigoBarras = string.Format("*{0}*", codigo);
            return codigoBarras;
        }

        private void gerarCB()
        {
            if (((DataTable)cbAluno.DataSource).Rows.Count > 0)
            {
                carregaFonte();
                lblCodigoDeBarras.Font = fonte;
                lblNumeroCodigo.Text = formataCodigoBarras(cbAluno.SelectedValue.ToString());
                lblCodigoDeBarras.Text = formataCodigoBarras(cbAluno.SelectedValue.ToString());
            }
        }

        private void cbAluno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                gerarCB();
            }
            catch
            {
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAluno.SelectedIndex != -1)
                {
                    printDialog1.Document = printDocument1;
                    string texto = lblCodigoDeBarras.Text + Environment.NewLine + lblNumeroCodigo.Text;
                    leitor = new StringReader(texto);

                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.printDocument1.Print();
                    }
                }
                else
                    MessageBox.Show("Selecione um aluno para imprimir.", "Aluno não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void btnVisualizarImpressao_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAluno.SelectedIndex != -1)
                {
                    string texto = lblCodigoDeBarras.Text + Environment.NewLine + lblNumeroCodigo.Text;
                    leitor = new StringReader(texto);
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.Document = this.printDocument1;
                    printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                    printPreviewDialog1.ShowDialog();
                }
                else
                    MessageBox.Show("Selecione um aluno para vizualizar a impressão.", "Aluno Não Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exp)
            {
                MessageBox.Show(" Erro : " + exp.Message.ToString());
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //variaveis usadas para definir as configurações da impressão
            float linhasPorPagina = 0;
            float yPosicao = 0;
            float margemEsquerda = e.MarginBounds.Left;
            float margemSuperior = e.MarginBounds.Top;
            Font fonteImpressao = new Font("Verdana", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            SolidBrush mCaneta = new SolidBrush(Color.Black);

            // Define o numero de linhas por pagina, usando MarginBounds.
            linhasPorPagina = e.MarginBounds.Height / fonteImpressao.GetHeight(e.Graphics);

            // na altura da fonte de acordo com o dispositivo de impressão
            yPosicao = margemSuperior + (1 * fonteImpressao.GetHeight(e.Graphics));
            // desenha a marcação
            e.Graphics.DrawString("-------------------------------------------", 
                fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            // desenha a primeira linha
            yPosicao = margemSuperior + (2 * fonteImpressao.GetHeight(e.Graphics));
            e.Graphics.DrawString("Academia TOP FITNESS", fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            // Linha2(Nome do aluno)
            if (cbAluno.Text.Length <= 33)
            {
                yPosicao = margemSuperior + (3 * fonteImpressao.GetHeight(e.Graphics));
                e.Graphics.DrawString(cbAluno.Text, fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            }
            else
            {
                string[] nomeQuebrado = cbAluno.Text.Split(' ');
                string linha1 = string.Empty;
                string linha2 = string.Empty;

                for (int palavra = 0; nomeQuebrado.Length > palavra; palavra++)
                {
                    if ((linha1 + " " + nomeQuebrado[palavra]).Length < 33)
                        linha1 = linha1 + nomeQuebrado[palavra] + " ";
                    else
                        linha2 = linha2 + nomeQuebrado[palavra] + " ";
                }
                yPosicao = margemSuperior + (3 * fonteImpressao.GetHeight(e.Graphics));
                e.Graphics.DrawString(linha1, fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
                yPosicao = margemSuperior + (4 * fonteImpressao.GetHeight(e.Graphics));
                e.Graphics.DrawString(linha2, fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            }
            //Linha3(Codigo de barras)
            carregaFonte();
            yPosicao = margemSuperior + (6 * fonteImpressao.GetHeight(e.Graphics));
            // e.Graphics.DrawString(formataCodigoBarras(cbAluno.SelectedValue.ToString()), fonte, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            e.Graphics.DrawImage(createBitmapImage(lblCodigoDeBarras.Text), margemEsquerda, yPosicao);
            //Linha 4(Numero)
            yPosicao = margemSuperior + (10 * fonteImpressao.GetHeight(e.Graphics));
            e.Graphics.DrawString(lblNumeroCodigo.Text, fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            // desenha a marcação
            yPosicao = margemSuperior + (13 * fonteImpressao.GetHeight(e.Graphics));
            e.Graphics.DrawString("-------------------------------------------",
                fonteImpressao, mCaneta, margemEsquerda, yPosicao, new StringFormat());
            //Imagem Frente Cartão
            yPosicao = margemSuperior + (15 * fonteImpressao.GetHeight(e.Graphics));
            string caminhoStart = Application.StartupPath.ToString();
            string caminhoImagem = Path.Combine(caminhoStart, "FrenteCartao.png");
            Image logo = Image.FromFile(caminhoImagem);
            e.Graphics.DrawImage(logo, margemEsquerda, yPosicao);

            //libera recursos		
            mCaneta.Dispose();

        }

        private Bitmap createBitmapImage(string sImageText)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing. 
            Font objFont = fonte;

            // Create a graphics object to measure the text's width and height. 
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined. 
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font. 
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            // Add the colors to the new bitmap. 
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color 
            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = SmoothingMode.HighQuality;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.Black),0,0);
            objGraphics.Flush();

            return (objBmpImage);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigoDeBarras_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
