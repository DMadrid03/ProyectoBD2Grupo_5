namespace ProyectoBD2Grupo5.Forms
{
    partial class frmListaCompras
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
            txtBusqueda = new TextBox();
            dataGridView1 = new DataGridView();
            btnModificar = new Button();
            btnAgregar = new Button();
            btnMostrarDetalle = new Button();
            radCompras = new RadioButton();
            radSolicitudes = new RadioButton();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 29);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 19;
            label1.Text = "Buscar insumos:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(131, 26);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(178, 23);
            txtBusqueda.TabIndex = 18;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(883, 346);
            dataGridView1.TabIndex = 17;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(708, 25);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(606, 25);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 15;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnMostrarDetalle
            // 
            btnMostrarDetalle.Location = new Point(799, 25);
            btnMostrarDetalle.Name = "btnMostrarDetalle";
            btnMostrarDetalle.Size = new Size(107, 23);
            btnMostrarDetalle.TabIndex = 20;
            btnMostrarDetalle.Text = "Mostrar Detalle";
            btnMostrarDetalle.UseVisualStyleBackColor = true;
            // 
            // radCompras
            // 
            radCompras.AutoSize = true;
            radCompras.Location = new Point(23, 9);
            radCompras.Name = "radCompras";
            radCompras.Size = new Size(73, 19);
            radCompras.TabIndex = 21;
            radCompras.TabStop = true;
            radCompras.Text = "Compras";
            radCompras.UseVisualStyleBackColor = true;
            radCompras.CheckedChanged += radCompras_CheckedChanged;
            // 
            // radSolicitudes
            // 
            radSolicitudes.AutoSize = true;
            radSolicitudes.Location = new Point(139, 9);
            radSolicitudes.Name = "radSolicitudes";
            radSolicitudes.Size = new Size(82, 19);
            radSolicitudes.TabIndex = 22;
            radSolicitudes.TabStop = true;
            radSolicitudes.Text = "Solicitudes";
            radSolicitudes.UseVisualStyleBackColor = true;
            radSolicitudes.CheckedChanged += radSolicitudes_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radSolicitudes);
            groupBox1.Controls.Add(radCompras);
            groupBox1.Location = new Point(335, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 37);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // frmListaCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 423);
            Controls.Add(groupBox1);
            Controls.Add(btnMostrarDetalle);
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(txtBusqueda);
            Controls.Add(dataGridView1);
            Controls.Add(btnModificar);
            Name = "frmListaCompras";
            Text = "frmListaCompras";
            Load += frmListaCompras_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBusqueda;
        private DataGridView dataGridView1;
        private Button btnModificar;
        private Button btnAgregar;
        private Button btnMostrarDetalle;
        private RadioButton radCompras;
        private RadioButton radSolicitudes;
        private GroupBox groupBox1;
    }
}