namespace TCC
{
    partial class FormCadastroGrupoMusculares
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroGrupoMusculares));
            this.lblGrupoMuscular = new System.Windows.Forms.Label();
            this.txtGrupoMuscular = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLogar = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGrupoMuscular
            // 
            this.lblGrupoMuscular.AutoSize = true;
            this.lblGrupoMuscular.BackColor = System.Drawing.Color.Transparent;
            this.lblGrupoMuscular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrupoMuscular.ForeColor = System.Drawing.Color.Black;
            this.lblGrupoMuscular.Location = new System.Drawing.Point(6, 22);
            this.lblGrupoMuscular.Name = "lblGrupoMuscular";
            this.lblGrupoMuscular.Size = new System.Drawing.Size(85, 13);
            this.lblGrupoMuscular.TabIndex = 1;
            this.lblGrupoMuscular.Text = "Grupo Muscular:";
            // 
            // txtGrupoMuscular
            // 
            this.txtGrupoMuscular.Location = new System.Drawing.Point(93, 19);
            this.txtGrupoMuscular.Name = "txtGrupoMuscular";
            this.txtGrupoMuscular.Size = new System.Drawing.Size(193, 20);
            this.txtGrupoMuscular.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGrupoMuscular);
            this.groupBox1.Controls.Add(this.lblGrupoMuscular);
            this.groupBox1.Location = new System.Drawing.Point(49, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblLogar
            // 
            this.lblLogar.AutoSize = true;
            this.lblLogar.BackColor = System.Drawing.Color.Transparent;
            this.lblLogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogar.ForeColor = System.Drawing.Color.Black;
            this.lblLogar.Location = new System.Drawing.Point(192, 280);
            this.lblLogar.Name = "lblLogar";
            this.lblLogar.Size = new System.Drawing.Size(52, 13);
            this.lblLogar.TabIndex = 261;
            this.lblLogar.Text = "Cadastrar";
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
            this.btnCadastrar.Location = new System.Drawing.Point(181, 212);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(67, 66);
            this.btnCadastrar.TabIndex = 295;
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // FormCadastroGrupoMusculares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 321);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.lblLogar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroGrupoMusculares";
            this.Text = "Cadastro Grupo Muscular";
            this.Load += new System.EventHandler(this.FormCadastroGrupoMusculares_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrupoMuscular;
        private System.Windows.Forms.TextBox txtGrupoMuscular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLogar;
        private System.Windows.Forms.Button btnCadastrar;
    }
}