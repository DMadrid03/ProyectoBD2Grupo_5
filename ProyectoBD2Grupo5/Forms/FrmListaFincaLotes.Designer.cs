namespace ProyectoBD2Grupo5.Forms
{
    partial class FrmListaFincaLotes
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
            btnModificar = new Button();
            btnAgregar = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 35);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 13;
            label1.Text = "Identificador de la finca";
            label1.Click += label1_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Enabled = false;
            txtBusqueda.Location = new Point(161, 28);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(45, 23);
            txtBusqueda.TabIndex = 12;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(474, 27);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(168, 23);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar Lotes de la finca";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(317, 27);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(151, 23);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar Lote a la finca";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(618, 199);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // FrmListaFincaLotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 346);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(txtBusqueda);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Name = "FrmListaFincaLotes";
            Text = "FrmListaFincaLotes";
            Load += FrmListaFincaLotes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBusqueda;
        private Button btnModificar;
        private Button btnAgregar;
        private DataGridView dataGridView1;
    }
}