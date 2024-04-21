namespace ProyectoBD2Grupo5.Forms
{
    partial class FrmProveedorFinca
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
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            textPrecioCultivo = new TextBox();
            label2 = new Label();
            textCantidadSembrada = new TextBox();
            label3 = new Label();
            cmbTsuelo = new ComboBox();
            cmbTriego = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cmdCancelar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmdSalvar
            // 
            cmdSalvar.Location = new Point(167, 318);
            cmdSalvar.Name = "cmdSalvar";
            cmdSalvar.Size = new Size(129, 73);
            cmdSalvar.TabIndex = 0;
            cmdSalvar.Text = "Salvar";
            cmdSalvar.UseVisualStyleBackColor = true;
            // 
            // textExtension
            // 
            textExtension.Location = new Point(155, 31);
            textExtension.Name = "textExtension";
            textExtension.Size = new Size(121, 23);
            textExtension.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(125, 37);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(100, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 39);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 3;
            label1.Text = "Extension";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbTriego);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbTsuelo);
            groupBox1.Controls.Add(textCantidadSembrada);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textExtension);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(742, 291);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ficha del lote";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textPrecioCultivo);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Location = new Point(328, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(408, 184);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de Cultivo";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // textPrecioCultivo
            // 
            textPrecioCultivo.Location = new Point(125, 104);
            textPrecioCultivo.Name = "textPrecioCultivo";
            textPrecioCultivo.Size = new Size(79, 23);
            textPrecioCultivo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 89);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Tipo de suelo";
            // 
            // textCantidadSembrada
            // 
            textCantidadSembrada.Location = new Point(155, 183);
            textCantidadSembrada.Name = "textCantidadSembrada";
            textCantidadSembrada.Size = new Size(121, 23);
            textCantidadSembrada.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 142);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 5;
            label3.Text = "Tipo de riego";
            label3.Click += label3_Click;
            // 
            // cmbTsuelo
            // 
            cmbTsuelo.FormattingEnabled = true;
            cmbTsuelo.Location = new Point(155, 81);
            cmbTsuelo.Name = "cmbTsuelo";
            cmbTsuelo.Size = new Size(121, 23);
            cmbTsuelo.TabIndex = 6;
            // 
            // cmbTriego
            // 
            cmbTriego.FormattingEnabled = true;
            cmbTriego.Location = new Point(155, 134);
            cmbTriego.Name = "cmbTriego";
            cmbTriego.Size = new Size(121, 23);
            cmbTriego.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 191);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 8;
            label4.Text = "Cantidad sembrada";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 45);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 9;
            label5.Text = "Fecha de siembro";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 112);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 10;
            label6.Text = "Precio cultivo";
            // 
            // cmdCancelar
            // 
            cmdCancelar.Location = new Point(465, 318);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(129, 73);
            cmdCancelar.TabIndex = 5;
            cmdCancelar.Text = "Cancelar";
            cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmProveedorFinca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmdCancelar);
            Controls.Add(groupBox1);
            Controls.Add(cmdSalvar);
            Name = "FrmProveedorFinca";
            Text = "Cultivo de lote";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button cmdSalvar;
        private TextBox textExtension;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label4;
        private ComboBox cmbTriego;
        private Label label2;
        private ComboBox cmbTsuelo;
        private TextBox textCantidadSembrada;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox textPrecioCultivo;
        private Label label6;
        private Label label5;
        private Button cmdCancelar;
    }
}