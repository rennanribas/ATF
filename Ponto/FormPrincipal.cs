using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ponto
{
    public partial class FormPrincipal : Form
    {
        //variáveis para serem usadas por métodos e eventos do form
        bool cb;
        int tempo = 0;
        bool fichaAberta = false;
        String id_cli;
        int alturaEspaco, alturaTexto;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //classe para mudar o estado visual do form
            EstadoForm form = new EstadoForm();
            //chama o método para maximizar o form em full screen
            form.Maximize(this);
        }

        private void FormPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se  o cliente digitar esc, zera os componentes do form, como se acabasse de abrir o mesmo.
            if (e.KeyChar == 27)
                zerar();
            //veririfca se a tecla pressionada é numero e se o timer está desativado
            if (char.IsNumber(e.KeyChar) && !timer.Enabled)
            {
                //caso seja, abre o textBox, e zera todos os componentes,para o caso de estar digitando com a ficha aberta.
                cb = true;
                lblCartaoNome.Text = "Código de barras:";

                groupBox1.Visible = false;
                lblFicha.Visible = false;
                lblFicha.Text = string.Empty;
                lblNome.Text = string.Empty;
                lblTempoDeCasa.Text = string.Empty;
                lblTreino.Text = string.Empty;
                lblCartaoNome.Visible = true;
                txtBoxConteudo.Enabled = true;
                txtBoxConteudo.Visible = true;
                txtBoxConteudo.Focus();
                txtBoxConteudo.Text = e.KeyChar.ToString();
                SendKeys.Send("{RIGHT}");
                tempo = 0;
                timer.Start();
                arrumarBusca();
                fichaAberta = false;
                //loop para apagar todos os pictureBox do form
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls.RemoveByKey("pictureBox" + i.ToString());
                }

            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //se já tiverem passados 3 segundos sem fazer nada, ele zera os componente, e fecha tudo
            if (tempo == 3)
            {
                zerar();
            }
            else
                //caso não, adiciona mais um na variavel tempo, adicionando mais um "segundo"
                tempo++;
        }

        private void txtBoxConteudo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verifica se já foram 6 digitos precionados, e se o ultimo é numero, caso sim, busca no banco a ficha do cliente
                if (cb && (txtBoxConteudo.TextLength + 1) == 6 && char.IsNumber(e.KeyChar))
                {
                    //código de barras
                    try
                    {
                        AcessoCliente acessoCli = new AcessoCliente();
                        acessoCli.bucarPorCB(txtBoxConteudo.Text + e.KeyChar.ToString());
                        //chama o método para completar a ficha do cliente
                        ficha(acessoCli.ID_cli1.ToString());                        
                    }
                    catch
                    {
                        //caso não encontre o aluno ou dê algum erro, exibe a mensagem de aluno não encontrado.
                        txtBoxConteudo.Text += e.KeyChar;
                        MessageBox.Show("Aluno não encontrado, por favor revise o código de barras.", 
                            "Erro na busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //método que zera os componentes, caso não encontre o aluno
                        zerar();
                    }

                }
            else
            {
                //caso não dê certo, verifica se é numero ou diferente de backspace caso seja, bloqueia a tecla.
                if(!char.IsNumber(e.KeyChar)  && e.KeyChar != '\b')
                e.Handled = true;
            }
            tempo = 0;
        }

        //Método para completar a ficha usando o id do cliente
        private void ficha(String idCli)
        {
            AcessoCliente acessoCli = new AcessoCliente();
            acessoCli.bucarPorID(idCli);
            AcessoControleFrequencia acessoFreq = new AcessoControleFrequencia();

            //verifica se o cliente já tem algum treino cadastrado na tabela frequencia
            if (acessoFreq.ultimoTreino(acessoCli.ID_cli1.ToString()))
            {
                id_cli = idCli;
                String idTreino = acessoFreq.ID_treino.ToString();
                AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                DataTable fichaTreino = acessoTreinoEx.selecionarPorTreino(idTreino);
                //percorre a tabela fichaTreino, onde tem todos os exercicios do treino
                //vai preenchendo o label desta forma, pulando linha para cada item da tabela, e para uma nova linha da tabela
                //pula duas linhas, também aproveita para pegar a informação de alturas para serem usados na hora de preencher
                //os pictureBox que mais tarde Serão criados
                for (int i = 0; fichaTreino.Rows.Count > i; i++)
                {
                    lblFicha.Text += (i + 1).ToString() + "º Exercicio" + Environment.NewLine
                        + "Nome do exercicio: " + fichaTreino.Rows[i][0].ToString() + Environment.NewLine
                        + "Número de Séries: " + fichaTreino.Rows[i][2].ToString() + Environment.NewLine
                        + "Número de Repetições: " + fichaTreino.Rows[i][1].ToString() + Environment.NewLine
                        + "Grupo Muscular: " + fichaTreino.Rows[i][3].ToString();
                    if (i == 0)
                        alturaTexto = lblFicha.Height;
                    lblFicha.Text += Environment.NewLine + Environment.NewLine;
                    if (i == 0)
                        alturaEspaco = lblFicha.Height - alturaTexto;
                }
                //Preenche os labels com os dados do cliente, usando o buscarPorID
                lblNome.Text = acessoCli.Nome_cli;
                lblTempoDeCasa.Text = "Cliente desde " + acessoCli.Data_cadastro.ToLongDateString();
                lblTreino.Text = "Treino de hoje: " + acessoTreinoEx.buscarNomeTreino(idTreino);
                Focus();
                //para o timer
                timer.Stop();
                fichaAberta = true;
                arrumarResposta();
                animacao();
            }
            else
            {
                //mostra mensagem caso não haja treinos realizados
                MessageBox.Show("Não possui treinos e/ou não realizou nenhum treino.", "Sem dados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                zerar();
            }
        }

        //método para preencher as animações, é chaamado pelo método "ficha"
        private void animacao()
        {
            AcessoCliente acessoCli = new AcessoCliente();
            //busca cliente por id, preenchendo as variaveis do objeto instanciado
            acessoCli.bucarPorID(id_cli);
            AcessoControleFrequencia acessoFreq = new AcessoControleFrequencia();
            //busca o ultimo treino do cliente para pegar o id
            acessoFreq.ultimoTreino(acessoCli.ID_cli1.ToString());
            String idTreino = acessoFreq.ID_treino.ToString();
            AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
            DataTable fichaTreino = acessoTreinoEx.selecionarPorTreino(idTreino);
            //cria uma lista de pictureBox, que logo serão usados como componentes do form
            PictureBox[] pt = new PictureBox[fichaTreino.Rows.Count];
            //percorre todos os itens da tabela fichaTreino, onde tem os exercicios, assim, vai completando a 
            //lista de pictureBox, cada um com sua imagem, e vai adicionando no form
            for (int i = 0; fichaTreino.Rows.Count > i; i++)
            {
                try
                {
                    Controls.RemoveByKey("pictureBox" + i.ToString());
                }
                catch { }
                pt[i] = new PictureBox();
                pt[i].Name = "pictureBox" + i.ToString();
                this.Controls.Add(pt[i]);
                Point local = new Point(lblFicha.Location.X + lblFicha.Width, 
                    lblFicha.Location.Y + (i*(alturaEspaco + alturaTexto)));
                pt[i].Location = local;
                pt[i].Image = Image.FromFile(fichaTreino.Rows[i]["caminho_gif"].ToString());
                pt[i].Width = 160;
                pt[i].Height = 120;
                pt[i].Visible = true;  
            }

            Focus();
        }

        //método para arrumar  layout ao usuario buscar pelo seu codigo de barras
        public void arrumarBusca()
        {
            int larguraForm = Width;
            int alturaForm = Height;
            Point pt = new Point();
            pt.X = (larguraForm / 2) - (lblCartaoNome.Size.Width / 2);
            pt.Y = Convert.ToInt32(alturaForm * 0.05);
            lblCartaoNome.Location = pt;
            txtBoxConteudo.Width = Convert.ToInt32(larguraForm - (larguraForm * 0.4));
            pt.X = (larguraForm / 2) - (txtBoxConteudo.Size.Width / 2);
            pt.Y = pt.Y + 10 + txtBoxConteudo.Height;
            txtBoxConteudo.Location = pt;
        }

        //método para arrumar a resposta na forma de ficha
        public void arrumarResposta()
        {
            txtBoxConteudo.Enabled = false;
            groupBox1.Visible = true;
            txtBoxConteudo.Visible = false;
            lblCartaoNome.Visible = false;
            lblFicha.Visible = true;
            timer.Stop();
            int larguraForm = Width;
            int alturForm = Height;
            Point p1 = groupBox1.Location;
            groupBox1.Width = Convert.ToInt32(larguraForm - (larguraForm * 0.05));
            p1.X = Convert.ToInt32(larguraForm - (larguraForm * 0.975));
            p1.Y = Convert.ToInt32(alturForm - (alturForm * 0.98));
            groupBox1.Location = p1;

            p1.X = Convert.ToInt32(larguraForm - (larguraForm * 0.975));
            p1.Y += (groupBox1.Height / 2) + Convert.ToInt32(alturForm*0.1);
            lblFicha.Location = p1;
        }

        //método para zerar tanto o layout quanto as variáveis
        public void zerar()
        {
            groupBox1.Visible = false;
            lblFicha.Visible = false;
            txtBoxConteudo.Visible = false;
            lblCartaoNome.Visible = false;
            timer.Stop();
            this.Focus();
            tempo = 3;
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls.RemoveByKey("pictureBox" + i.ToString());
            }
        }

        //evento detectado ao precionar as teclas UP ou DOWN do teclado
        private void FormPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            //baixo 40
            if (e.KeyValue == 40 && fichaAberta)
            {
                //move os labels, group box e picutreBox para baixo, as animações são refeitas
                Point pt = groupBox1.Location;
                pt.Y -= 10;
                groupBox1.Location = pt;

                pt = lblFicha.Location;
                pt.Y -= 10;
                lblFicha.Location = pt;

                animacao();
            }
            //cima 38
            if (e.KeyValue == 38 && fichaAberta)
            {
                //move os labels, group box e picutreBox para cima, as animações são refeitas
                Point pt = groupBox1.Location;
                pt.Y += 10;
                groupBox1.Location = pt;

                pt = lblFicha.Location;
                pt.Y += 10;
                lblFicha.Location = pt;
                animacao();
            }

        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //caso o form seja encerrado, fecha o processo
            Application.Exit();
        }
    }
}
