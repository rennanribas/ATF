namespace TCC
{
    partial class FormAlterarTreino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlterarTreino));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBCliente = new System.Windows.Forms.ComboBox();
            this.btnVisivel = new System.Windows.Forms.Button();
            this.btnInvisivel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSeries = new System.Windows.Forms.TextBox();
            this.txtBoxRepeticoes = new System.Windows.Forms.TextBox();
            this.btnCadastrarTreinoEx = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtBoxNomeTreino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGrupoMusc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBExercicio = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(449, 166);
            this.dataGridView1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ficha:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(239, 186);
            this.listBox1.TabIndex = 21;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Aluno:";
            // 
            // cBCliente
            // 
            this.cBCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBCliente.FormattingEnabled = true;
            this.cBCliente.Location = new System.Drawing.Point(51, 13);
            this.cBCliente.Name = "cBCliente";
            this.cBCliente.Size = new System.Drawing.Size(247, 21);
            this.cBCliente.TabIndex = 16;
            this.cBCliente.SelectedIndexChanged += new System.EventHandler(this.cBCliente_SelectedIndexChanged);
            // 
            // btnVisivel
            // 
            this.btnVisivel.ForeColor = System.Drawing.Color.Black;
            this.btnVisivel.Location = new System.Drawing.Point(19, 244);
            this.btnVisivel.Name = "btnVisivel";
            this.btnVisivel.Size = new System.Drawing.Size(88, 37);
            this.btnVisivel.TabIndex = 32;
            this.btnVisivel.Text = "Habilitar Treino";
            this.btnVisivel.UseVisualStyleBackColor = true;
            this.btnVisivel.Click += new System.EventHandler(this.btnVisivel_Click);
            // 
            // btnInvisivel
            // 
            this.btnInvisivel.ForeColor = System.Drawing.Color.Black;
            this.btnInvisivel.Location = new System.Drawing.Point(170, 244);
            this.btnInvisivel.Name = "btnInvisivel";
            this.btnInvisivel.Size = new System.Drawing.Size(88, 37);
            this.btnInvisivel.TabIndex = 33;
            this.btnInvisivel.Text = "Desabilitar Treino";
            this.btnInvisivel.UseVisualStyleBackColor = true;
            this.btnInvisivel.Click += new System.EventHandler(this.btnInvisivel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Nº de séries:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Nº de repetições:";
            // 
            // txtBoxSeries
            // 
            this.txtBoxSeries.Location = new System.Drawing.Point(82, 90);
            this.txtBoxSeries.Name = "txtBoxSeries";
            this.txtBoxSeries.Size = new System.Drawing.Size(54, 20);
            this.txtBoxSeries.TabIndex = 29;
            this.txtBoxSeries.TextChanged += new System.EventHandler(this.txtBoxSeries_TextChanged);
            // 
            // txtBoxRepeticoes
            // 
            this.txtBoxRepeticoes.Location = new System.Drawing.Point(104, 125);
            this.txtBoxRepeticoes.Name = "txtBoxRepeticoes";
            this.txtBoxRepeticoes.Size = new System.Drawing.Size(46, 20);
            this.txtBoxRepeticoes.TabIndex = 30;
            this.txtBoxRepeticoes.TextChanged += new System.EventHandler(this.txtBoxRepeticoes_TextChanged);
            // 
            // btnCadastrarTreinoEx
            // 
            this.btnCadastrarTreinoEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarTreinoEx.ForeColor = System.Drawing.Color.Black;
            this.btnCadastrarTreinoEx.Location = new System.Drawing.Point(251, 106);
            this.btnCadastrarTreinoEx.Name = "btnCadastrarTreinoEx";
            this.btnCadastrarTreinoEx.Size = new System.Drawing.Size(97, 57);
            this.btnCadastrarTreinoEx.TabIndex = 31;
            this.btnCadastrarTreinoEx.Text = "Adicionar exercício ao treino";
            this.btnCadastrarTreinoEx.UseVisualStyleBackColor = true;
            this.btnCadastrarTreinoEx.Click += new System.EventHandler(this.btnCadastrarTreinoEx_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 47);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAlterar);
            this.groupBox2.Controls.Add(this.txtBoxNomeTreino);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnInvisivel);
            this.groupBox2.Controls.Add(this.btnVisivel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(5, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 413);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(58, 364);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(135, 32);
            this.btnAlterar.TabIndex = 36;
            this.btnAlterar.Text = "Alterar nome do Treino";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtBoxNomeTreino
            // 
            this.txtBoxNomeTreino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNomeTreino.Location = new System.Drawing.Point(19, 332);
            this.txtBoxNomeTreino.Name = "txtBoxNomeTreino";
            this.txtBoxNomeTreino.Size = new System.Drawing.Size(239, 22);
            this.txtBoxNomeTreino.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Nome do Treino:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(336, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(486, 222);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Exercícios do Treino";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCadastrarTreinoEx);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtBoxRepeticoes);
            this.groupBox3.Controls.Add(this.cbGrupoMusc);
            this.groupBox3.Controls.Add(this.txtBoxSeries);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cBExercicio);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(393, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 182);
            this.groupBox3.TabIndex = 308;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Adicionar Exercício";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Grupo Muscular:";
            // 
            // cbGrupoMusc
            // 
            this.cbGrupoMusc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupoMusc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupoMusc.FormattingEnabled = true;
            this.cbGrupoMusc.Location = new System.Drawing.Point(100, 16);
            this.cbGrupoMusc.Name = "cbGrupoMusc";
            this.cbGrupoMusc.Size = new System.Drawing.Size(144, 21);
            this.cbGrupoMusc.TabIndex = 11;
            this.cbGrupoMusc.SelectedIndexChanged += new System.EventHandler(this.cbGrupoMusc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Exercício:";
            // 
            // cBExercicio
            // 
            this.cBExercicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBExercicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBExercicio.FormattingEnabled = true;
            this.cBExercicio.Location = new System.Drawing.Point(70, 50);
            this.cBExercicio.Name = "cBExercicio";
            this.cBExercicio.Size = new System.Drawing.Size(174, 21);
            this.cBExercicio.TabIndex = 9;
            // 
            // FormAlterarTreino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlterarTreino";
            this.Text = "Alterar Treino";
            this.Load += new System.EventHandler(this.FormAlterarTreino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBCliente;
        private System.Windows.Forms.Button btnVisivel;
        private System.Windows.Forms.Button btnInvisivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxSeries;
        private System.Windows.Forms.TextBox txtBoxRepeticoes;
        private System.Windows.Forms.Button btnCadastrarTreinoEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGrupoMusc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBExercicio;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtBoxNomeTreino;
        private System.Windows.Forms.Label label2;
    }
}