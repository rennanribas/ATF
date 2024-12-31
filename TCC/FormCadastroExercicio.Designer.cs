namespace TCC
{
    partial class FormCadastroExercicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroExercicio));
            this.label1 = new System.Windows.Forms.Label();
            this.cbGrupoMuscular = new System.Windows.Forms.ComboBox();
            this.lblNomeExercicio = new System.Windows.Forms.Label();
            this.txtExercicio = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLogar = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnProcurarImg = new System.Windows.Forms.Button();
            this.txtCaminhoImg = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo Muscular:";
            // 
            // cbGrupoMuscular
            // 
            this.cbGrupoMuscular.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupoMuscular.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupoMuscular.FormattingEnabled = true;
            this.cbGrupoMuscular.Location = new System.Drawing.Point(99, 16);
            this.cbGrupoMuscular.Name = "cbGrupoMuscular";
            this.cbGrupoMuscular.Size = new System.Drawing.Size(136, 21);
            this.cbGrupoMuscular.TabIndex = 1;
            this.cbGrupoMuscular.SelectedIndexChanged += new System.EventHandler(this.cbGrupoMuscular_SelectedIndexChanged);
            // 
            // lblNomeExercicio
            // 
            this.lblNomeExercicio.AutoSize = true;
            this.lblNomeExercicio.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeExercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeExercicio.ForeColor = System.Drawing.Color.Black;
            this.lblNomeExercicio.Location = new System.Drawing.Point(9, 18);
            this.lblNomeExercicio.Name = "lblNomeExercicio";
            this.lblNomeExercicio.Size = new System.Drawing.Size(86, 13);
            this.lblNomeExercicio.TabIndex = 2;
            this.lblNomeExercicio.Text = "Nome Exercício:";
            // 
            // txtExercicio
            // 
            this.txtExercicio.Location = new System.Drawing.Point(99, 15);
            this.txtExercicio.Name = "txtExercicio";
            this.txtExercicio.Size = new System.Drawing.Size(128, 20);
            this.txtExercicio.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGrupoMuscular);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(64, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtExercicio);
            this.groupBox2.Controls.Add(this.lblNomeExercicio);
            this.groupBox2.Location = new System.Drawing.Point(64, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 51);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lblLogar
            // 
            this.lblLogar.AutoSize = true;
            this.lblLogar.BackColor = System.Drawing.Color.Transparent;
            this.lblLogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogar.ForeColor = System.Drawing.Color.Black;
            this.lblLogar.Location = new System.Drawing.Point(193, 288);
            this.lblLogar.Name = "lblLogar";
            this.lblLogar.Size = new System.Drawing.Size(37, 13);
            this.lblLogar.TabIndex = 269;
            this.lblLogar.Text = "Salvar";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.BackgroundImage = global::TCC.Properties.Resources.Salvar1;
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.Location = new System.Drawing.Point(178, 221);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(67, 66);
            this.btnCadastrar.TabIndex = 303;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnProcurarImg
            // 
            this.btnProcurarImg.Location = new System.Drawing.Point(255, 19);
            this.btnProcurarImg.Name = "btnProcurarImg";
            this.btnProcurarImg.Size = new System.Drawing.Size(75, 23);
            this.btnProcurarImg.TabIndex = 304;
            this.btnProcurarImg.Text = "Procurar";
            this.btnProcurarImg.UseVisualStyleBackColor = true;
            this.btnProcurarImg.Click += new System.EventHandler(this.btnProcurarImg_Click);
            // 
            // txtCaminhoImg
            // 
            this.txtCaminhoImg.Enabled = false;
            this.txtCaminhoImg.Location = new System.Drawing.Point(75, 22);
            this.txtCaminhoImg.Name = "txtCaminhoImg";
            this.txtCaminhoImg.Size = new System.Drawing.Size(165, 20);
            this.txtCaminhoImg.TabIndex = 305;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Animação (*.gif)|*.gif";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Procurar Animação";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 306;
            this.label2.Text = "Caminho da";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 307;
            this.label3.Text = "animação :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnProcurarImg);
            this.groupBox3.Controls.Add(this.txtCaminhoImg);
            this.groupBox3.Location = new System.Drawing.Point(35, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 60);
            this.groupBox3.TabIndex = 308;
            this.groupBox3.TabStop = false;
            // 
            // FormCadastroExercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 321);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblLogar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroExercicio";
            this.Text = "Cadastro Exercicio";
            this.Load += new System.EventHandler(this.FormCadastroExercicio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbGrupoMuscular;
        private System.Windows.Forms.Label lblNomeExercicio;
        private System.Windows.Forms.TextBox txtExercicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLogar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnProcurarImg;
        private System.Windows.Forms.TextBox txtCaminhoImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}