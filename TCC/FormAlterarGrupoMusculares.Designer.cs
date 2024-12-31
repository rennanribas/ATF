namespace TCC
{
    partial class FormAlterarGrupoMusculares
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlterarGrupoMusculares));
            this.cbEscolherGrupoMusuclar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrupoMuscular = new System.Windows.Forms.TextBox();
            this.lblGrupoMuscular = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLogar = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEscolherGrupoMusuclar
            // 
            this.cbEscolherGrupoMusuclar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEscolherGrupoMusuclar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEscolherGrupoMusuclar.FormattingEnabled = true;
            this.cbEscolherGrupoMusuclar.Location = new System.Drawing.Point(152, 16);
            this.cbEscolherGrupoMusuclar.Name = "cbEscolherGrupoMusuclar";
            this.cbEscolherGrupoMusuclar.Size = new System.Drawing.Size(171, 21);
            this.cbEscolherGrupoMusuclar.TabIndex = 17;
            this.cbEscolherGrupoMusuclar.SelectedIndexChanged += new System.EventHandler(this.cbEscolherGrupoMusuclar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Selecione o Grupo Muscular:";
            // 
            // txtGrupoMuscular
            // 
            this.txtGrupoMuscular.Location = new System.Drawing.Point(95, 16);
            this.txtGrupoMuscular.Name = "txtGrupoMuscular";
            this.txtGrupoMuscular.Size = new System.Drawing.Size(156, 20);
            this.txtGrupoMuscular.TabIndex = 15;
            this.txtGrupoMuscular.TextChanged += new System.EventHandler(this.txtGrupoMuscular_TextChanged);
            // 
            // lblGrupoMuscular
            // 
            this.lblGrupoMuscular.AutoSize = true;
            this.lblGrupoMuscular.BackColor = System.Drawing.Color.Transparent;
            this.lblGrupoMuscular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupoMuscular.ForeColor = System.Drawing.Color.Black;
            this.lblGrupoMuscular.Location = new System.Drawing.Point(4, 19);
            this.lblGrupoMuscular.Name = "lblGrupoMuscular";
            this.lblGrupoMuscular.Size = new System.Drawing.Size(85, 13);
            this.lblGrupoMuscular.TabIndex = 14;
            this.lblGrupoMuscular.Text = "Grupo Muscular:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEscolherGrupoMusuclar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 56);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGrupoMuscular);
            this.groupBox2.Controls.Add(this.lblGrupoMuscular);
            this.groupBox2.Location = new System.Drawing.Point(29, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 53);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // lblLogar
            // 
            this.lblLogar.AutoSize = true;
            this.lblLogar.BackColor = System.Drawing.Color.Transparent;
            this.lblLogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogar.ForeColor = System.Drawing.Color.Black;
            this.lblLogar.Location = new System.Drawing.Point(196, 294);
            this.lblLogar.Name = "lblLogar";
            this.lblLogar.Size = new System.Drawing.Size(37, 13);
            this.lblLogar.TabIndex = 265;
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
            this.btnCadastrar.Location = new System.Drawing.Point(179, 227);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(67, 66);
            this.btnCadastrar.TabIndex = 309;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_1);
            // 
            // FormAlterarGrupoMusculares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 321);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblLogar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlterarGrupoMusculares";
            this.Text = "Alterar Grupos Musculares";
            this.Load += new System.EventHandler(this.FormAlterarGrupoMusculares_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEscolherGrupoMusuclar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGrupoMuscular;
        private System.Windows.Forms.Label lblGrupoMuscular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLogar;
        private System.Windows.Forms.Button btnCadastrar;
    }
}