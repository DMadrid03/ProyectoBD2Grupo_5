namespace ProyectoBD2Grupo5.Forms
{
    partial class FrmLoteCultivo
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
            cmdSalvar = new Button();
            textExtension = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            textCodigo = new TextBox();
            label7 = new Label();
            label4 = new Label();
            cmbTriego = new ComboBox();
            label2 = new Label();
            cmbTsuelo = new ComboBox();
            textCantidadSembrada = new TextBox();
            label3 = new Label();
            cmdCancelar = new Button();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cmdSalvar
            // 
            cmdSalvar.Location = new Point(760, 14);
            cmdSalvar.Name = "cmdSalvar";
            cmdSalvar.Size = new Size(129, 73);
            cmdSalvar.TabIndex = 0;
            cmdSalvar.Text = "Salvar";
            cmdSalvar.UseVisualStyleBackColor = true;
            cmdSalvar.Click += cmdSalvar_Click;
            // 
            // textExtension
            // 
            textExtension.Location = new Point(361, 35);
            textExtension.Name = "textExtension";
            textExtension.Size = new Size(121, 23);
            textExtension.TabIndex = 1;
            textExtension.TextChanged += textExtension_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 43);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 3;
            label1.Text = "Extension";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textCodigo);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textExtension);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbTriego);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbTsuelo);
            groupBox1.Controls.Add(textCantidadSembrada);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(742, 188);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ficha del lote";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textCodigo
            // 
            textCodigo.Location = new Point(111, 35);
            textCodigo.Name = "textCodigo";
            textCodigo.Size = new Size(121, 23);
            textCodigo.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 43);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 10;
            label7.Text = "Codigo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(527, 43);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 8;
            label4.Text = "Cantidad sembrada";
            // 
            // cmbTriego
            // 
            cmbTriego.FormattingEnabled = true;
            cmbTriego.Location = new Point(361, 105);
            cmbTriego.Name = "cmbTriego";
            cmbTriego.Size = new Size(121, 23);
            cmbTriego.TabIndex = 7;
            cmbTriego.SelectedIndexChanged += cmbTriego_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 113);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Tipo de suelo";
            // 
            // cmbTsuelo
            // 
            cmbTsuelo.FormattingEnabled = true;
            cmbTsuelo.Location = new Point(111, 105);
            cmbTsuelo.Name = "cmbTsuelo";
            cmbTsuelo.Size = new Size(121, 23);
            cmbTsuelo.TabIndex = 6;
            // 
            // textCantidadSembrada
            // 
            textCantidadSembrada.Location = new Point(527, 70);
            textCantidadSembrada.Name = "textCantidadSembrada";
            textCantidadSembrada.Size = new Size(121, 23);
            textCantidadSembrada.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(274, 113);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Tipo de riego";
            label3.Click += label3_Click;
            // 
            // cmdCancelar
            // 
            cmdCancelar.Location = new Point(760, 105);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(129, 73);
            cmdCancelar.TabIndex = 5;
            cmdCancelar.Text = "Cancelar";
            cmdCancelar.UseVisualStyleBackColor = true;
            cmdCancelar.Click += cmdCancelar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 199);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(742, 212);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // FrmLoteCultivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 450);
            Controls.Add(dataGridView1);
            Controls.Add(cmdCancelar);
            Controls.Add(groupBox1);
            Controls.Add(cmdSalvar);
            Name = "FrmLoteCultivo";
            Text = "Cultivo de lote";
            Load += FrmLoteCultivo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button cmdSalvar;
        private TextBox textExtension;
        private Label label1;
        private GroupBox groupBox1;
        private Label label4;
        private ComboBox cmbTriego;
        private Label label2;
        private ComboBox cmbTsuelo;
        private TextBox textCantidadSembrada;
        private Label label3;
        private Button cmdCancelar;
        private DataGridView dataGridView1;
        private TextBox textCodigo;
        private Label label7;
    }
}