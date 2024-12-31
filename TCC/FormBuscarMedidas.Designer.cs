namespace TCC
{
    partial class FormBuscarMedidas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscarMedidas));
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbBraco = new System.Windows.Forms.RadioButton();
            this.rbAntebraco = new System.Windows.Forms.RadioButton();
            this.rbPeito = new System.Windows.Forms.RadioButton();
            this.rbOmbro = new System.Windows.Forms.RadioButton();
            this.rbCostas = new System.Windows.Forms.RadioButton();
            this.rbCoxas = new System.Windows.Forms.RadioButton();
            this.rbPanturrilha = new System.Windows.Forms.RadioButton();
            this.rbCintura = new System.Windows.Forms.RadioButton();
            this.rbAbdomen = new System.Windows.Forms.RadioButton();
            this.rbQuadril = new System.Windows.Forms.RadioButton();
            this.rbAltura = new System.Windows.Forms.RadioButton();
            this.rbPeso = new System.Windows.Forms.RadioButton();
            this.rbPercentual = new System.Windows.Forms.RadioButton();
            this.comboBoxNomeAluno = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3D = new System.Windows.Forms.CheckBox();
            this.rbIMC = new System.Windows.Forms.RadioButton();
            this.comboBoxExibir = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfo3D1 = new System.Windows.Forms.Label();
            this.lblInfo3D2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grafico
            // 
            this.grafico.BackColor = System.Drawing.Color.Transparent;
            this.grafico.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisX.Title = "Data Medida";
            chartArea1.AxisY.Title = "cm";
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.grafico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grafico.Legends.Add(legend1);
            this.grafico.Location = new System.Drawing.Point(280, 81);
            this.grafico.Margin = new System.Windows.Forms.Padding(4);
            this.grafico.Name = "grafico";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafico.Series.Add(series1);
            this.grafico.Size = new System.Drawing.Size(929, 518);
            this.grafico.TabIndex = 1;
            this.grafico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grafico_MouseClick);
            this.grafico.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grafico_MouseDoubleClick);
            this.grafico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grafico_MouseMove);
            // 
            // rbBraco
            // 
            this.rbBraco.AutoSize = true;
            this.rbBraco.Location = new System.Drawing.Point(27, 23);
            this.rbBraco.Margin = new System.Windows.Forms.Padding(4);
            this.rbBraco.Name = "rbBraco";
            this.rbBraco.Size = new System.Drawing.Size(69, 20);
            this.rbBraco.TabIndex = 3;
            this.rbBraco.TabStop = true;
            this.rbBraco.Text = "Braços";
            this.rbBraco.UseVisualStyleBackColor = true;
            this.rbBraco.CheckedChanged += new System.EventHandler(this.rbBraco_CheckedChanged);
            // 
            // rbAntebraco
            // 
            this.rbAntebraco.AutoSize = true;
            this.rbAntebraco.Location = new System.Drawing.Point(27, 52);
            this.rbAntebraco.Margin = new System.Windows.Forms.Padding(4);
            this.rbAntebraco.Name = "rbAntebraco";
            this.rbAntebraco.Size = new System.Drawing.Size(95, 20);
            this.rbAntebraco.TabIndex = 4;
            this.rbAntebraco.TabStop = true;
            this.rbAntebraco.Text = "Antebraços";
            this.rbAntebraco.UseVisualStyleBackColor = true;
            this.rbAntebraco.CheckedChanged += new System.EventHandler(this.rbAntebraco_CheckedChanged);
            // 
            // rbPeito
            // 
            this.rbPeito.AutoSize = true;
            this.rbPeito.Location = new System.Drawing.Point(27, 80);
            this.rbPeito.Margin = new System.Windows.Forms.Padding(4);
            this.rbPeito.Name = "rbPeito";
            this.rbPeito.Size = new System.Drawing.Size(57, 20);
            this.rbPeito.TabIndex = 5;
            this.rbPeito.TabStop = true;
            this.rbPeito.Text = "Peito";
            this.rbPeito.UseVisualStyleBackColor = true;
            this.rbPeito.CheckedChanged += new System.EventHandler(this.rbPeito_CheckedChanged);
            // 
            // rbOmbro
            // 
            this.rbOmbro.AutoSize = true;
            this.rbOmbro.Location = new System.Drawing.Point(27, 108);
            this.rbOmbro.Margin = new System.Windows.Forms.Padding(4);
            this.rbOmbro.Name = "rbOmbro";
            this.rbOmbro.Size = new System.Drawing.Size(67, 20);
            this.rbOmbro.TabIndex = 6;
            this.rbOmbro.TabStop = true;
            this.rbOmbro.Text = "Ombro";
            this.rbOmbro.UseVisualStyleBackColor = true;
            this.rbOmbro.CheckedChanged += new System.EventHandler(this.rbOmbro_CheckedChanged);
            // 
            // rbCostas
            // 
            this.rbCostas.AutoSize = true;
            this.rbCostas.Location = new System.Drawing.Point(27, 137);
            this.rbCostas.Margin = new System.Windows.Forms.Padding(4);
            this.rbCostas.Name = "rbCostas";
            this.rbCostas.Size = new System.Drawing.Size(68, 20);
            this.rbCostas.TabIndex = 7;
            this.rbCostas.TabStop = true;
            this.rbCostas.Text = "Costas";
            this.rbCostas.UseVisualStyleBackColor = true;
            this.rbCostas.CheckedChanged += new System.EventHandler(this.rbCostas_CheckedChanged);
            // 
            // rbCoxas
            // 
            this.rbCoxas.AutoSize = true;
            this.rbCoxas.Location = new System.Drawing.Point(27, 165);
            this.rbCoxas.Margin = new System.Windows.Forms.Padding(4);
            this.rbCoxas.Name = "rbCoxas";
            this.rbCoxas.Size = new System.Drawing.Size(64, 20);
            this.rbCoxas.TabIndex = 8;
            this.rbCoxas.TabStop = true;
            this.rbCoxas.Text = "Coxas";
            this.rbCoxas.UseVisualStyleBackColor = true;
            this.rbCoxas.CheckedChanged += new System.EventHandler(this.rbCoxas_CheckedChanged);
            // 
            // rbPanturrilha
            // 
            this.rbPanturrilha.AutoSize = true;
            this.rbPanturrilha.Location = new System.Drawing.Point(27, 193);
            this.rbPanturrilha.Margin = new System.Windows.Forms.Padding(4);
            this.rbPanturrilha.Name = "rbPanturrilha";
            this.rbPanturrilha.Size = new System.Drawing.Size(96, 20);
            this.rbPanturrilha.TabIndex = 9;
            this.rbPanturrilha.TabStop = true;
            this.rbPanturrilha.Text = "Panturrilhas";
            this.rbPanturrilha.UseVisualStyleBackColor = true;
            this.rbPanturrilha.CheckedChanged += new System.EventHandler(this.rbPanturrilha_CheckedChanged);
            // 
            // rbCintura
            // 
            this.rbCintura.AutoSize = true;
            this.rbCintura.Location = new System.Drawing.Point(27, 222);
            this.rbCintura.Margin = new System.Windows.Forms.Padding(4);
            this.rbCintura.Name = "rbCintura";
            this.rbCintura.Size = new System.Drawing.Size(67, 20);
            this.rbCintura.TabIndex = 10;
            this.rbCintura.TabStop = true;
            this.rbCintura.Text = "Cintura";
            this.rbCintura.UseVisualStyleBackColor = true;
            this.rbCintura.CheckedChanged += new System.EventHandler(this.rbCintura_CheckedChanged);
            // 
            // rbAbdomen
            // 
            this.rbAbdomen.AutoSize = true;
            this.rbAbdomen.Location = new System.Drawing.Point(27, 250);
            this.rbAbdomen.Margin = new System.Windows.Forms.Padding(4);
            this.rbAbdomen.Name = "rbAbdomen";
            this.rbAbdomen.Size = new System.Drawing.Size(85, 20);
            this.rbAbdomen.TabIndex = 11;
            this.rbAbdomen.TabStop = true;
            this.rbAbdomen.Text = "Abdomen";
            this.rbAbdomen.UseVisualStyleBackColor = true;
            this.rbAbdomen.CheckedChanged += new System.EventHandler(this.rbAbdomen_CheckedChanged);
            // 
            // rbQuadril
            // 
            this.rbQuadril.AutoSize = true;
            this.rbQuadril.Location = new System.Drawing.Point(27, 278);
            this.rbQuadril.Margin = new System.Windows.Forms.Padding(4);
            this.rbQuadril.Name = "rbQuadril";
            this.rbQuadril.Size = new System.Drawing.Size(69, 20);
            this.rbQuadril.TabIndex = 12;
            this.rbQuadril.TabStop = true;
            this.rbQuadril.Text = "Quadril";
            this.rbQuadril.UseVisualStyleBackColor = true;
            this.rbQuadril.CheckedChanged += new System.EventHandler(this.rbQuadril_CheckedChanged);
            // 
            // rbAltura
            // 
            this.rbAltura.AutoSize = true;
            this.rbAltura.Location = new System.Drawing.Point(27, 306);
            this.rbAltura.Margin = new System.Windows.Forms.Padding(4);
            this.rbAltura.Name = "rbAltura";
            this.rbAltura.Size = new System.Drawing.Size(60, 20);
            this.rbAltura.TabIndex = 13;
            this.rbAltura.TabStop = true;
            this.rbAltura.Text = "Altura";
            this.rbAltura.UseVisualStyleBackColor = true;
            this.rbAltura.CheckedChanged += new System.EventHandler(this.rbAltura_CheckedChanged);
            // 
            // rbPeso
            // 
            this.rbPeso.AutoSize = true;
            this.rbPeso.Location = new System.Drawing.Point(27, 335);
            this.rbPeso.Margin = new System.Windows.Forms.Padding(4);
            this.rbPeso.Name = "rbPeso";
            this.rbPeso.Size = new System.Drawing.Size(58, 20);
            this.rbPeso.TabIndex = 14;
            this.rbPeso.TabStop = true;
            this.rbPeso.Text = "Peso";
            this.rbPeso.UseVisualStyleBackColor = true;
            this.rbPeso.CheckedChanged += new System.EventHandler(this.rbPeso_CheckedChanged);
            // 
            // rbPercentual
            // 
            this.rbPercentual.AutoSize = true;
            this.rbPercentual.Location = new System.Drawing.Point(27, 391);
            this.rbPercentual.Margin = new System.Windows.Forms.Padding(4);
            this.rbPercentual.Name = "rbPercentual";
            this.rbPercentual.Size = new System.Drawing.Size(161, 20);
            this.rbPercentual.TabIndex = 15;
            this.rbPercentual.TabStop = true;
            this.rbPercentual.Text = "Percentual de Gordura";
            this.rbPercentual.UseVisualStyleBackColor = true;
            this.rbPercentual.CheckedChanged += new System.EventHandler(this.rbPercentual_CheckedChanged);
            // 
            // comboBoxNomeAluno
            // 
            this.comboBoxNomeAluno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxNomeAluno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxNomeAluno.FormattingEnabled = true;
            this.comboBoxNomeAluno.Location = new System.Drawing.Point(74, 14);
            this.comboBoxNomeAluno.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNomeAluno.Name = "comboBoxNomeAluno";
            this.comboBoxNomeAluno.Size = new System.Drawing.Size(383, 24);
            this.comboBoxNomeAluno.TabIndex = 16;
            this.comboBoxNomeAluno.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3D);
            this.groupBox1.Controls.Add(this.rbIMC);
            this.groupBox1.Controls.Add(this.comboBoxExibir);
            this.groupBox1.Controls.Add(this.rbCostas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbBraco);
            this.groupBox1.Controls.Add(this.rbQuadril);
            this.groupBox1.Controls.Add(this.rbPercentual);
            this.groupBox1.Controls.Add(this.rbAbdomen);
            this.groupBox1.Controls.Add(this.rbOmbro);
            this.groupBox1.Controls.Add(this.rbAntebraco);
            this.groupBox1.Controls.Add(this.rbCoxas);
            this.groupBox1.Controls.Add(this.rbAltura);
            this.groupBox1.Controls.Add(this.rbPeso);
            this.groupBox1.Controls.Add(this.rbCintura);
            this.groupBox1.Controls.Add(this.rbPanturrilha);
            this.groupBox1.Controls.Add(this.rbPeito);
            this.groupBox1.Location = new System.Drawing.Point(16, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(256, 571);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vizualizar";
            // 
            // checkBox3D
            // 
            this.checkBox3D.AutoSize = true;
            this.checkBox3D.Location = new System.Drawing.Point(27, 521);
            this.checkBox3D.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3D.Name = "checkBox3D";
            this.checkBox3D.Size = new System.Drawing.Size(119, 20);
            this.checkBox3D.TabIndex = 21;
            this.checkBox3D.Text = "Gráficos em 3D";
            this.checkBox3D.UseVisualStyleBackColor = true;
            this.checkBox3D.CheckedChanged += new System.EventHandler(this.checkBox3D_CheckedChanged);
            // 
            // rbIMC
            // 
            this.rbIMC.AutoSize = true;
            this.rbIMC.Location = new System.Drawing.Point(27, 363);
            this.rbIMC.Margin = new System.Windows.Forms.Padding(4);
            this.rbIMC.Name = "rbIMC";
            this.rbIMC.Size = new System.Drawing.Size(49, 20);
            this.rbIMC.TabIndex = 20;
            this.rbIMC.TabStop = true;
            this.rbIMC.Text = "IMC";
            this.rbIMC.UseVisualStyleBackColor = true;
            this.rbIMC.CheckedChanged += new System.EventHandler(this.rbIMC_CheckedChanged);
            // 
            // comboBoxExibir
            // 
            this.comboBoxExibir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExibir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxExibir.FormattingEnabled = true;
            this.comboBoxExibir.Items.AddRange(new object[] {
            "Coluna",
            "Linha Reta"});
            this.comboBoxExibir.Location = new System.Drawing.Point(12, 481);
            this.comboBoxExibir.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxExibir.Name = "comboBoxExibir";
            this.comboBoxExibir.Size = new System.Drawing.Size(224, 24);
            this.comboBoxExibir.TabIndex = 19;
            this.comboBoxExibir.SelectedIndexChanged += new System.EventHandler(this.comboBoxExibir_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 462);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Exibir:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Aluno:";
            // 
            // lblInfo3D1
            // 
            this.lblInfo3D1.AutoSize = true;
            this.lblInfo3D1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo3D1.Location = new System.Drawing.Point(405, 617);
            this.lblInfo3D1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo3D1.Name = "lblInfo3D1";
            this.lblInfo3D1.Size = new System.Drawing.Size(515, 16);
            this.lblInfo3D1.TabIndex = 19;
            this.lblInfo3D1.Text = "Clique no gráfico e mexa o mouse para girar, se deseja parar de girar, clique den" +
    "ovo.";
            this.lblInfo3D1.Visible = false;
            // 
            // lblInfo3D2
            // 
            this.lblInfo3D2.AutoSize = true;
            this.lblInfo3D2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo3D2.Location = new System.Drawing.Point(504, 645);
            this.lblInfo3D2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo3D2.Name = "lblInfo3D2";
            this.lblInfo3D2.Size = new System.Drawing.Size(314, 16);
            this.lblInfo3D2.TabIndex = 20;
            this.lblInfo3D2.Text = "Caso deseje voltar ao começo, dê um clique duplo.";
            this.lblInfo3D2.Visible = false;
            // 
            // FormBuscarMedidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 705);
            this.Controls.Add(this.lblInfo3D2);
            this.Controls.Add(this.lblInfo3D1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxNomeAluno);
            this.Controls.Add(this.grafico);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuscarMedidas";
            this.Text = "Buscar Medidas";
            this.Load += new System.EventHandler(this.FormBuscarMedidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.Windows.Forms.RadioButton rbBraco;
        private System.Windows.Forms.RadioButton rbAntebraco;
        private System.Windows.Forms.RadioButton rbPeito;
        private System.Windows.Forms.RadioButton rbOmbro;
        private System.Windows.Forms.RadioButton rbCostas;
        private System.Windows.Forms.RadioButton rbCoxas;
        private System.Windows.Forms.RadioButton rbPanturrilha;
        private System.Windows.Forms.RadioButton rbCintura;
        private System.Windows.Forms.RadioButton rbAbdomen;
        private System.Windows.Forms.RadioButton rbQuadril;
        private System.Windows.Forms.RadioButton rbAltura;
        private System.Windows.Forms.RadioButton rbPeso;
        private System.Windows.Forms.RadioButton rbPercentual;
        private System.Windows.Forms.ComboBox comboBoxNomeAluno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxExibir;
        private System.Windows.Forms.RadioButton rbIMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox3D;
        private System.Windows.Forms.Label lblInfo3D1;
        private System.Windows.Forms.Label lblInfo3D2;

    }
}