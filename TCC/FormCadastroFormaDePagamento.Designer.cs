namespace TCC
{
    partial class FormCadastroFormaDePagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroFormaDePagamento));
            this.lblFormaDePagamento = new System.Windows.Forms.Label();
            this.txtforma = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLogar = new System.Windows.Forms.Label();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormaDePagamento
            // 
            this.lblFormaDePagamento.AutoSize = true;
            this.lblFormaDePagamento.BackColor = System.Drawing.Color.Transparent;
            this.lblFormaDePagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaDePagamento.ForeColor = System.Drawing.Color.Black;
            this.lblFormaDePagamento.Location = new System.Drawing.Point(6, 23);
            this.lblFormaDePagamento.Name = "lblFormaDePagamento";
            this.lblFormaDePagamento.Size = new System.Drawing.Size(111, 13);
            this.lblFormaDePagamento.TabIndex = 0;
            this.lblFormaDePagamento.Text = "Forma de Pagamento:";
            // 
            // txtforma
            // 
            this.txtforma.Location = new System.Drawing.Point(123, 19);
            this.txtforma.Name = "txtforma";
            this.txtforma.Size = new System.Drawing.Size(144, 20);
            this.txtforma.TabIndex = 1;
            this.txtforma.TextChanged += new System.EventHandler(this.txtforma_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtforma);
            this.groupBox1.Controls.Add(this.lblFormaDePagamento);
            this.groupBox1.Location = new System.Drawing.Point(49, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 61);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblLogar
            // 
            this.lblLogar.AutoSize = true;
            this.lblLogar.BackColor = System.Drawing.Color.Transparent;
            this.lblLogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogar.ForeColor = System.Drawing.Color.Black;
            this.lblLogar.Location = new System.Drawing.Point(187, 286);
            this.lblLogar.Name = "lblLogar";
            this.lblLogar.Size = new System.Drawing.Size(37, 13);
            this.lblLogar.TabIndex = 277;
            this.lblLogar.Text = "Salvar";
            // 
            // btnCadastro
            // 
            this.btnCadastro.BackColor = System.Drawing.Color.Transparent;
            this.btnCadastro.BackgroundImage = global::TCC.Properties.Resources.Salvar1;
            this.btnCadastro.FlatAppearance.BorderSize = 0;
            this.btnCadastro.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCadastro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCadastro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Location = new System.Drawing.Point(167, 219);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(67, 66);
            this.btnCadastro.TabIndex = 301;
            this.btnCadastro.UseVisualStyleBackColor = false;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // FormCadastroFormaDePagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 321);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.lblLogar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroFormaDePagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Forma De Pagamento";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormaDePagamento;
        private System.Windows.Forms.TextBox txtforma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLogar;
        private System.Windows.Forms.Button btnCadastro;
    }
}