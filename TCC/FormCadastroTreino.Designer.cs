namespace TCC
{
    partial class FormCadastroTreino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroTreino));
            this.cBCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxTreino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTreino = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTituloTreino = new System.Windows.Forms.Label();
            this.cBExercicio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSeries = new System.Windows.Forms.TextBox();
            this.txtBoxRepeticoes = new System.Windows.Forms.TextBox();
            this.btnCadastrarTreinoEx = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGrupoMusc = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBCliente
            // 
            this.cBCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBCliente.FormattingEnabled = true;
            this.cBCliente.Location = new System.Drawing.Point(50, 21);
            this.cBCliente.Name = "cBCliente";
            this.cBCliente.Size = new System.Drawing.Size(285, 21);
            this.cBCliente.TabIndex = 0;
            this.cBCliente.SelectedIndexChanged += new System.EventHandler(this.cBCliente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aluno:";
            // 
            // txtBoxTreino
            // 
            this.txtBoxTreino.Location = new System.Drawing.Point(60, 19);
            this.txtBoxTreino.MaxLength = 16;
            this.txtBoxTreino.Name = "txtBoxTreino";
            this.txtBoxTreino.Size = new System.Drawing.Size(152, 20);
            this.txtBoxTreino.TabIndex = 2;
            this.txtBoxTreino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxTreino_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Treino:";
            // 
            // btnAddTreino
            // 
            this.btnAddTreino.Location = new System.Drawing.Point(170, 88);
            this.btnAddTreino.Name = "btnAddTreino";
            this.btnAddTreino.Size = new System.Drawing.Size(106, 37);
            this.btnAddTreino.TabIndex = 4;
            this.btnAddTreino.Text = "Adicionar treino à ficha";
            this.btnAddTreino.UseVisualStyleBackColor = true;
            this.btnAddTreino.Click += new System.EventHandler(this.btnAddTreino_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(17, 159);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(259, 186);
            this.listBox1.TabIndex = 5;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ficha:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(454, 166);
            this.dataGridView1.TabIndex = 7;
            // 
            // lblTituloTreino
            // 
            this.lblTituloTreino.AutoSize = true;
            this.lblTituloTreino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTreino.Location = new System.Drawing.Point(168, 20);
            this.lblTituloTreino.Name = "lblTituloTreino";
            this.lblTituloTreino.Size = new System.Drawing.Size(0, 16);
            this.lblTituloTreino.TabIndex = 8;
            // 
            // cBExercicio
            // 
            this.cBExercicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBExercicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBExercicio.FormattingEnabled = true;
            this.cBExercicio.Location = new System.Drawing.Point(70, 50);
            this.cBExercicio.Name = "cBExercicio";
            this.cBExercicio.Size = new System.Drawing.Size(159, 21);
            this.cBExercicio.TabIndex = 9;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nº de séries:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nº de repetições:";
            // 
            // txtBoxSeries
            // 
            this.txtBoxSeries.Location = new System.Drawing.Point(81, 77);
            this.txtBoxSeries.Name = "txtBoxSeries";
            this.txtBoxSeries.Size = new System.Drawing.Size(33, 20);
            this.txtBoxSeries.TabIndex = 13;
            this.txtBoxSeries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSeries_KeyPress);
            // 
            // txtBoxRepeticoes
            // 
            this.txtBoxRepeticoes.Location = new System.Drawing.Point(103, 112);
            this.txtBoxRepeticoes.Name = "txtBoxRepeticoes";
            this.txtBoxRepeticoes.Size = new System.Drawing.Size(33, 20);
            this.txtBoxRepeticoes.TabIndex = 14;
            this.txtBoxRepeticoes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxRepeticoes_KeyPress);
            // 
            // btnCadastrarTreinoEx
            // 
            this.btnCadastrarTreinoEx.Location = new System.Drawing.Point(248, 79);
            this.btnCadastrarTreinoEx.Name = "btnCadastrarTreinoEx";
            this.btnCadastrarTreinoEx.Size = new System.Drawing.Size(97, 57);
            this.btnCadastrarTreinoEx.TabIndex = 15;
            this.btnCadastrarTreinoEx.Text = "Adicionar exercício ao treino";
            this.btnCadastrarTreinoEx.UseVisualStyleBackColor = true;
            this.btnCadastrarTreinoEx.Click += new System.EventHandler(this.btnCadastrarTreinoEx_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBCliente);
            this.groupBox1.Location = new System.Drawing.Point(7, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 60);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.btnAddTreino);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtBoxTreino);
            this.groupBox2.Location = new System.Drawing.Point(7, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 366);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Não utilize acentos, ou caracteres especiais.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCadastrarTreinoEx);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbGrupoMusc);
            this.groupBox3.Controls.Add(this.txtBoxRepeticoes);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cBExercicio);
            this.groupBox3.Controls.Add(this.txtBoxSeries);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(339, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 145);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
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
            this.cbGrupoMusc.Location = new System.Drawing.Point(100, 18);
            this.cbGrupoMusc.Name = "cbGrupoMusc";
            this.cbGrupoMusc.Size = new System.Drawing.Size(175, 21);
            this.cbGrupoMusc.TabIndex = 11;
            this.cbGrupoMusc.SelectedIndexChanged += new System.EventHandler(this.cbGrupoMusc_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTituloTreino);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(339, 260);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(475, 215);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // FormCadastroTreino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 487);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroTreino";
            this.Text = "Cadastro Treino";
            this.Load += new System.EventHandler(this.FormCadastroTreino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxTreino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTreino;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTituloTreino;
        private System.Windows.Forms.ComboBox cBExercicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxSeries;
        private System.Windows.Forms.TextBox txtBoxRepeticoes;
        private System.Windows.Forms.Button btnCadastrarTreinoEx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGrupoMusc;
    }
}