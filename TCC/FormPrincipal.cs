using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TCC
{
    public partial class FormPrincipal : Form
    {
        private bool deslogando;
        private String CB;
        private int linhaAtual;
        DataTable treinos;
        private bool escolhendoTreino;
        private int tempo;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Point p = new Point();
            p.X = (this.Width - textBox1.Size.Width);
            p.Y = (this.Height - 50 - textBox1.Size.Height);
            textBox1.Location = p;

            AcessoFuncionario acessoFunc = new AcessoFuncionario();
            acessoFunc.buscarporID(ClasseGlobal.Id_funcionario.ToString());
            if (!ClasseGlobal.Adm)
            {
                cadastrarToolStripMenuItem1.Visible = false;
                Ferramentas_toolStripDropDownButton.Visible = false;
                pacote_toolStripDropDownButton1.Visible  = false;
                toolStripSeparator9.Visible = false;
                FormaDePagamento_toolStripDropDownButton.Visible = false;
                toolStripSeparator8.Visible = false;
                toolStripSeparator11.Visible = false;
                backupToolStripDropDownButton1.Visible = false;
                toolStripSeparator5.Visible = false;

                AcessoFuncao acessoFuncao = new AcessoFuncao();
                if (!acessoFuncao.verificarPermissaoPorFunc(ClasseGlobal.Id_funcionario.ToString()))
                {
                    cadastrarToolStripMenuItem2.Visible = false;
                    alterarToolStripMenuItem2.Visible = false;
                    GrupoMuscular_toolStripDropDownButton.Visible = false;
                    Exercicio_toolStripDropDownButton.Visible = false;
                    toolStripSeparator7.Visible = false;
                    toolStripSeparator3.Visible = false;
                    cadastrarMedidasToolStripMenuItem.Visible = false;
                    alterarMedidasToolStripMenuItem.Visible = false;
                }
                lblNomeDoFuncionario.Text = acessoFunc.Nome_func;
            }
            else
            {
                lblNomeDoFuncionario.Text = acessoFunc.Nome_func + "(Administrador)";
            }
            FormContratosVencidos frmVenc = new FormContratosVencidos();
            frmVenc.MdiParent = this;
            frmVenc.Show();

            // display e etc
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                      //  serialPort1.PortName = "COM" + i.ToString();
                        //serialPort1.Open();
                        break;
                    }
                    catch
                    {
                    }
                }
                serialPort1.Write("|");
                backgroundWorker1.RunWorkerAsync();
                lblStatusPorta.Text = "         Status do display: Conectado";
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar o display e botões externos, para tentar conectar denovo, " +
    "clique no botão 'conectar'.", "Erro ao conectar display", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatusPorta.Text = "         Status do display: Desconectado";
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroCliente form = new FormCadastroCliente();
            form.MdiParent = this;
            form.Show();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroFuncionario form = new FormCadastroFuncionario();
            form.MdiParent = this;
            form.Show();
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroFormaDePagamento form = new FormCadastroFormaDePagamento();
            form.MdiParent = this;
            form.Show();
        }

        private void grupoMuscularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroGrupoMusculares form = new FormCadastroGrupoMusculares();
            form.MdiParent = this;
            form.Show();
        }

        private void exercícioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroExercicio form = new FormCadastroExercicio();
            form.MdiParent = this;
            form.Show();
        }

        private void treinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroTreino form = new FormCadastroTreino();
            form.MdiParent = this;
            form.Show();
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroContrato form = new FormCadastroContrato();
            form.MdiParent = this;
            form.Show();
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        bool encerrar = false;
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (deslogando)
            {
                FormLogin frmLogin = new FormLogin();
                frmLogin.Show();
                encerrar = true;
            }
            else
            {
                if (!encerrar)
                {
                    DialogResult dr = MessageBox.Show("Deseja realmente sair? \r (caso clique em não, será apenas deslogado)",
                        "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dr == DialogResult.No)
                    {
                        FormLogin frmLogin = new FormLogin();
                        frmLogin.Show();
                        encerrar = true;
                    }
                    if (dr == DialogResult.Yes)
                    {
                        encerrar = true;
                        Application.Exit();
                    }
                    if (dr == DialogResult.Cancel)
                        e.Cancel = true;
                }
            }
        }

        private void pacoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroPacote frmCadastroPac = new FormCadastroPacote();
            frmCadastroPac.MdiParent = this;
            frmCadastroPac.Show();
        }

        private void funçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroFuncao frmCadastroFuncao = new FormCadastroFuncao();
            frmCadastroFuncao.MdiParent = this;
            frmCadastroFuncao.Show();
        }

        private void funçãoDoFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroFuncaoFuncionario frmCadastroFF = new FormCadastroFuncaoFuncionario();
            frmCadastroFF.MdiParent = this;
            frmCadastroFF.Show();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAlterarCliente frmCli = new FormAlterarCliente();
            frmCli.MdiParent = this;
            frmCli.Show();
        }

        private void contratoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAlterarContrato frmContrato = new FormAlterarContrato();
            frmContrato.MdiParent = this;
            frmContrato.Show();
        }

        private void exercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarExercicio frmAlterar = new FormAlterarExercicio();
            frmAlterar.MdiParent = this;
            frmAlterar.Show();
        }

        private void formaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAlterarFormaPagamento frmAlterar = new FormAlterarFormaPagamento();
            frmAlterar.MdiParent = this;
            frmAlterar.Show();
        }

        private void funcionamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarFuncionario frmAlterar = new FormAlterarFuncionario();
            frmAlterar.MdiParent = this;
            frmAlterar.Show();
        }

        private void grupoMuscularToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAlterarGrupoMusculares frmAlterar = new FormAlterarGrupoMusculares();
            frmAlterar.MdiParent = this;
            frmAlterar.Show();
        }

        private void alterarTreinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarTreino frmAlterar = new FormAlterarTreino();
            frmAlterar.MdiParent = this;
            frmAlterar.Show();
        }

        private void contratosVencidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContratosVencidos frmContra = new FormContratosVencidos();
            frmContra.MdiParent = this;
            frmContra.Show();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroCliente form = new FormCadastroCliente();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarCliente form = new FormAlterarCliente();
            form.Show();
            form.MdiParent = this;
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCadastroFuncionario form = new FormCadastroFuncionario();
            form.Show();
            form.MdiParent = this;

        }

        private void alterarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAlterarFuncionario form = new FormAlterarFuncionario();
            form.Show();
            form.MdiParent = this;
        }

        private void cadastrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormCadastroTreino form = new FormCadastroTreino();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormAlterarTreino form = new FormAlterarTreino();
            form.Show();
            form.MdiParent = this;
        }

        private void cadastrarFunçãoDoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroFuncao form = new FormCadastroFuncao();
            form.Show();
            form.MdiParent = this;

        }

        private void atribuirFunçãoAoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroFuncaoFuncionario form = new FormCadastroFuncaoFuncionario();
            form.Show();
            form.MdiParent = this;

        }

        private void cadastrarExercícioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroExercicio form = new FormCadastroExercicio();
            form.Show();
            form.MdiParent = this;
        }

        private void Sair_toolStripDropDownButton_Click(object sender, EventArgs e)
        {
            deslogando = true;
            Close();
        }

        private void cadastrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormCadastroGrupoMusculares form = new FormCadastroGrupoMusculares();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormAlterarGrupoMusculares form = new FormAlterarGrupoMusculares();
            form.Show();
            form.MdiParent = this;
        }

        private void cadastrarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormCadastroFormaDePagamento form = new FormCadastroFormaDePagamento();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FormAlterarFormaPagamento form = new FormAlterarFormaPagamento();
            form.Show();
            form.MdiParent = this;
        }
        
        private void cadastrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormCadastroContrato form = new FormCadastroContrato();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormAlterarContrato form = new FormAlterarContrato();
            form.Show();
            form.MdiParent = this;
        }

        private void cadastrarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FormCadastroExercicio form = new FormCadastroExercicio();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FormAlterarExercicio form = new FormAlterarExercicio();
            form.Show();
            form.MdiParent = this;
        }

        private void fichaDoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarFichaCliente form = new FormBuscarFichaCliente();
            form.Show();
            form.MdiParent = this;
        }

        private void buscarFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarFichaCliente frmProcurar = new FormBuscarFichaCliente();
            frmProcurar.MdiParent = this;
            frmProcurar.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (serialPort1.IsOpen)
                {

                }
            }
            catch
            {
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatusPorta.Text = "         Status do display: Desconectado";
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        serialPort1.PortName = "COM" + i.ToString();
                        serialPort1.Open();
                        break;
                    }
                    catch
                    {
                    }
                }
                serialPort1.Write("|");
                backgroundWorker1.RunWorkerAsync();
                lblStatusPorta.Text = "         Status do display: Conectado";
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar o display e botões externos, para tentar conectar denovo, " +
    "clique no botão 'conectar'.", "Erro ao conectar display", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tempo > 10)
            {
                timer1.Stop();
                tempo = 0;
                escolhendoTreino = false;
                serialPort1.Write("/{Cancelado!#");
                Thread.Sleep(1000);
                serialPort1.Write("|$");
            }
            else
                tempo++;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                CB = textBox1.Text + e.KeyChar.ToString();
                if (CB.Length == 6)
                {
                    try
                    {
                        AcessoCliente acessoCli = new AcessoCliente();
                        acessoCli.bucarPorCB(CB);
                        AcessoContrato acessoContrato = new AcessoContrato();
                        if (acessoContrato.verificarContratos(acessoCli.ID_cli1.ToString()))
                        {
                            AcessoTreino acessoTreino = new AcessoTreino();
                            treinos = acessoTreino.selecionarDoCliente(acessoCli.ID_cli1.ToString());
                            linhaAtual = 0;
                            escolhendoTreino = true;
                            DataTable test = treinos.Clone();
                            AcessoTreinoExercicio acessoTreinoEx = new AcessoTreinoExercicio();
                            for (int linha = 0; linha < treinos.Rows.Count; linha++)
                            {
                                if (treinos.Rows[linha]["visivel_treino"].ToString() != "0" &&
                                    acessoTreinoEx.selecionarPorTreino(treinos.Rows[linha]["id_treino"].ToString()).Rows.Count > 0)
                                {
                                    DataRow dr = test.NewRow();
                                    for (int coluna = 0; coluna < test.Columns.Count; coluna++)
                                    {
                                        dr[coluna] = treinos.Rows[linha][coluna];
                                    }
                                    test.Rows.Add(dr);
                                }
                            }
                            if (test.Rows.Count > 0)
                            {
                                if (serialPort1.IsOpen)
                                {
                                    timer1.Start();
                                    treinos = test;
                                    serialPort1.Write("/{Escolha o treino%");
                                    serialPort1.Write("}" + treinos.Rows[linhaAtual]["nome_treino"].ToString());
                                }
                                else
                                {
                                    ClasseGlobal.Id_cliente = acessoCli.ID_cli1;
                                    FormSelecionarTreino frmSelecionar = new FormSelecionarTreino();
                                    frmSelecionar.MdiParent = this;
                                    frmSelecionar.Show();
                                }
                            }
                            else
                            {
                                if (serialPort1.IsOpen)
                                {
                                    serialPort1.Write("/{Sem Treinos}Cadastrados.#");
                                    Thread.Sleep(2500);
                                    serialPort1.Write("|$");
                                }
                                else
                                    MessageBox.Show("Aluno sem treinos cadastrados.", "Sem treinos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (serialPort1.IsOpen)
                            {
                                serialPort1.Write("/{Contrato}Vencido.#");
                                Thread.Sleep(2500);
                                serialPort1.Write("|$");
                            }
                            else
                            MessageBox.Show("Contrato vencido.", "Sem contratos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write("/{Codigo invalido#");
                            Thread.Sleep(2500);
                            serialPort1.Write("|$");
                        }
                        else
                            MessageBox.Show("Código de Barras Inválido.", "Código Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    CB = string.Empty;
                    textBox1.Text = string.Empty;
                    e.Handled = true;
                }
            }
        }

        private void toolStripProgressBar2_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (Convert.ToChar(serialPort1.ReadByte()).ToString() != null && escolhendoTreino)
            {
                String recebeu = Convert.ToChar(serialPort1.ReadByte()).ToString();
                switch (recebeu)
                {
                    //cancelar
                    case "0":
                        escolhendoTreino = false;
                        timer1.Stop();
                        serialPort1.Write("/{Cancelado!#");
                        Thread.Sleep(2500);
                        serialPort1.Write("|$");
                        break;

                    //selecionar
                    case "1":
                        //botão treino, treinar, etc
                        timer1.Stop();
                        tempo = 0;
                        serialPort1.Write("/{Treino Escolhido}" + treinos.Rows[linhaAtual]["nome_treino"].ToString());
                        Thread.Sleep(2500);
                        AcessoCliente acessoCli = new AcessoCliente();
                        acessoCli.bucarPorID(treinos.Rows[linhaAtual]["id_cli"].ToString());
                        string[] arrayNome = acessoCli.Nome_cli.Split(' ');
                        if(arrayNome[0].Length <= 12)
                            serialPort1.Write("/{BOM TREINO !}" + arrayNome[0] + "&");
                        else
                            serialPort1.Write("/{BOM TREINO !}" + arrayNome[0] + "&");
                        Thread.Sleep(2500);
                        serialPort1.Write("|$");
                        AcessoControleFrequencia acessoFrequencia = new AcessoControleFrequencia();
                        String idTreino = treinos.Rows[linhaAtual]["id_treino"].ToString();
                        acessoFrequencia.inserir(idTreino, DateTime.Now.ToString());
                        escolhendoTreino = false;
                        break;

                    //cima
                    case "2":
                        serialPort1.Write("/{Escolha o treino%");
                        linhaAtual--;
                        if (linhaAtual < 0)
                            linhaAtual = treinos.Rows.Count - 1;
                        serialPort1.Write("}" + treinos.Rows[linhaAtual]["nome_treino"].ToString());
                        tempo = 0;
                        break;

                    //baixo
                    case "3":
                        serialPort1.Write("/{Escolha o treino%");
                        linhaAtual++;
                        if (linhaAtual > (treinos.Rows.Count - 1))
                            linhaAtual = 0;
                        serialPort1.Write("}" + treinos.Rows[linhaAtual]["nome_treino"].ToString());
                        tempo = 0;
                        break;
                }
            }
        }

        private void cadastrarMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroMedidas frmMedidas = new FormCadastroMedidas();
            frmMedidas.MdiParent = this;
            frmMedidas.Show();
        }

        private void gráficoMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarMedidas frmBuscar = new FormBuscarMedidas();
            frmBuscar.MdiParent = this;
            frmBuscar.Show();
        }

        private void alterarMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarMedidas frmAlterar = new FormAlterarMedidas();
            frmAlterar.MdiParent = this;
            frmAlterar.Show();
        }

        private void gerarCódigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGerarCodigoDeBarras formCB = new FormGerarCodigoDeBarras();
            formCB.MdiParent = this;
            formCB.Show();
        }

        private void cadastrarPacoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadastroPacote form = new FormCadastroPacote();
            form.Show();
            form.MdiParent = this;
        }

        private void contratosVencidosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormContratosVencidos form = new FormContratosVencidos();
            form.Show();
            form.MdiParent = this;
        }

        private void alterarPacoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlterarPacote formAlterar = new FormAlterarPacote();
            formAlterar.MdiParent = this;
            formAlterar.Show();
        }

        private void pesquisarFunçõesDeFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarFuncaoFuncionario frmBuscarFuncaoFunc = new FormBuscarFuncaoFuncionario();
            frmBuscarFuncaoFunc.MdiParent = this;
            frmBuscarFuncaoFunc.Show();
        }

        private void fazerBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClasseGlobal.Backup = true;
            FormBackup frmBackup = new FormBackup();
            frmBackup.MdiParent = this;
            frmBackup.Show();
        }

        private void restaurarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClasseGlobal.Backup = false;
            FormBackup frmBackup = new FormBackup();
            frmBackup.MdiParent = this;
            frmBackup.Show();
        }

    }
}
