namespace ProyectoBD2Grupo5.Forms
{
    partial class frmCompraDialogo
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
            label1 = new Label();
            txtID = new TextBox();
            label2 = new Label();
            cmbTipo = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dpFecha = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            dpFechaVencimiento = new DateTimePicker();
            label7 = new Label();
            txtCultivo = new TextBox();
            dataGridView1 = new DataGridView();
            btnAceptar = new Button();
            btnCancelar = new Button();
            cmbProveedor = new ComboBox();
            txtProductor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 36);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(169, 33);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(67, 23);
            txtID.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(431, 36);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de Transaccion";
            // 
            // cmbTipo
            // 
            cmbTipo.AutoCompleteMode = AutoCompleteMode.Append;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Enabled = false;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(561, 33);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(197, 23);
            cmbTipo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 94);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Productor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 94);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "Proveedor";
            // 
            // dpFecha
            // 
            dpFecha.Format = DateTimePickerFormat.Custom;
            dpFecha.Location = new Point(169, 151);
            dpFecha.Name = "dpFecha";
            dpFecha.Size = new Size(89, 23);
            dpFecha.TabIndex = 8;
            dpFecha.Value = new DateTime(2024, 4, 25, 0, 0, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 157);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 9;
            label5.Text = "Fecha";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(323, 157);
            label6.Name = "label6";
            label6.Size = new Size(123, 15);
            label6.TabIndex = 11;
            label6.Text = "Fecha de Vencimiento";
            // 
            // dpFechaVencimiento
            // 
            dpFechaVencimiento.Format = DateTimePickerFormat.Custom;
            dpFechaVencimiento.Location = new Point(461, 151);
            dpFechaVencimiento.Name = "dpFechaVencimiento";
            dpFechaVencimiento.Size = new Size(89, 23);
            dpFechaVencimiento.TabIndex = 10;
            dpFechaVencimiento.Value = new DateTime(2024, 4, 25, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(622, 157);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 12;
            label7.Text = "Cultivo";
            // 
            // txtCultivo
            // 
            txtCultivo.Location = new Point(699, 154);
            txtCultivo.Name = "txtCultivo";
            txtCultivo.Size = new Size(59, 23);
            txtCultivo.TabIndex = 13;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(31, 217);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(727, 209);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.DefaultValuesNeeded += dataGridView1_DefaultValuesNeeded;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(169, 463);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 15;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(546, 463);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbProveedor
            // 
            cmbProveedor.AutoCompleteMode = AutoCompleteMode.Append;
            cmbProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(169, 91);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(197, 23);
            cmbProveedor.TabIndex = 7;
            // 
            // txtProductor
            // 
            txtProductor.Location = new Point(561, 91);
            txtProductor.Name = "txtProductor";
            txtProductor.ReadOnly = true;
            txtProductor.Size = new Size(197, 23);
            txtProductor.TabIndex = 17;
            // 
            // frmCompraDialogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 508);
            ControlBox = false;
            Controls.Add(txtProductor);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(dataGridView1);
            Controls.Add(txtCultivo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dpFechaVencimiento);
            Controls.Add(label5);
            Controls.Add(dpFecha);
            Controls.Add(cmbProveedor);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbTipo);
            Controls.Add(label2);
            Controls.Add(txtID);
            Controls.Add(label1);
            Name = "frmCompraDialogo";
            Text = "frmCompraDialogo";
            Load += frmCompraDialogo_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtID;
        private Label label2;
        private ComboBox cmbTipo;
        private Label label3;
        private Label label4;
        private DateTimePicker dpFecha;
        private Label label5;
        private Label label6;
        private DateTimePicker dpFechaVencimiento;
        private Label label7;
        private TextBox txtCultivo;
        private DataGridView dataGridView1;
        private Button btnAceptar;
        private Button btnCancelar;
        private ComboBox cmbProveedor;
        private TextBox txtProductor;
    }
}