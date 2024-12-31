namespace Ponto
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtBoxConteudo = new System.Windows.Forms.TextBox();
            this.lblCartaoNome = new System.Windows.Forms.Label();
            this.lblFicha = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTreino = new System.Windows.Forms.Label();
            this.lblTempoDeCasa = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // txtBoxConteudo
            // 
            this.txtBoxConteudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxConteudo.Location = new System.Drawing.Point(137, 72);
            this.txtBoxConteudo.Name = "txtBoxConteudo";
            this.txtBoxConteudo.Size = new System.Drawing.Size(347, 29);
            this.txtBoxConteudo.TabIndex = 0;
            this.txtBoxConteudo.Visible = false;
            this.txtBoxConteudo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxConteudo_KeyPress);
            // 
            // lblCartaoNome
            // 
            this.lblCartaoNome.AutoSize = true;
            this.lblCartaoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaoNome.Location = new System.Drawing.Point(134, 46);
            this.lblCartaoNome.Name = "lblCartaoNome";
            this.lblCartaoNome.Size = new System.Drawing.Size(0, 24);
            this.lblCartaoNome.TabIndex = 1;
            this.lblCartaoNome.Visible = false;
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.BackColor = System.Drawing.Color.Transparent;
            this.lblFicha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFicha.ForeColor = System.Drawing.Color.Blue;
            this.lblFicha.Location = new System.Drawing.Point(36, 140);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(0, 25);
            this.lblFicha.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblTreino);
            this.groupBox1.Controls.Add(this.lblTempoDeCasa);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 153);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações";
            this.groupBox1.Visible = false;
            // 
            // lblTreino
            // 
            this.lblTreino.AutoSize = true;
            this.lblTreino.ForeColor = System.Drawing.Color.Blue;
            this.lblTreino.Location = new System.Drawing.Point(7, 101);
            this.lblTreino.Name = "lblTreino";
            this.lblTreino.Size = new System.Drawing.Size(0, 24);
            this.lblTreino.TabIndex = 2;
            // 
            // lblTempoDeCasa
            // 
            this.lblTempoDeCasa.AutoSize = true;
            this.lblTempoDeCasa.ForeColor = System.Drawing.Color.Blue;
            this.lblTempoDeCasa.Location = new System.Drawing.Point(7, 66);
            this.lblTempoDeCasa.Name = "lblTempoDeCasa";
            this.lblTempoDeCasa.Size = new System.Drawing.Size(0, 24);
            this.lblTempoDeCasa.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.ForeColor = System.Drawing.Color.Blue;
            this.lblNome.Location = new System.Drawing.Point(7, 31);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(0, 24);
            this.lblNome.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(781, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFicha);
            this.Controls.Add(this.lblCartaoNome);
            this.Controls.Add(this.txtBoxConteudo);
            this.DoubleBuffered = true;
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPrincipal_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPrincipal_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox txtBoxConteudo;
        private System.Windows.Forms.Label lblCartaoNome;
        private System.Windows.Forms.Label lblFicha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTreino;
        private System.Windows.Forms.Label lblTempoDeCasa;
        private System.Windows.Forms.Label lblNome;
    }
}

