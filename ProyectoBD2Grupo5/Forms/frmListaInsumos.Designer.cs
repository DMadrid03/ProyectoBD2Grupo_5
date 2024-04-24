namespace ProyectoBD2Grupo5.Forms
{
    partial class frmListaInsumos
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 14;
            label1.Text = "Buscar insumos:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(120, 17);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(178, 23);
            txtBusqueda.TabIndex = 13;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(595, 241);
            dataGridView1.TabIndex = 12;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(532, 16);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(440, 16);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // frmListaInsumos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 310);
            Controls.Add(label1);
            Controls.Add(txtBusqueda);
            Controls.Add(dataGridView1);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Name = "frmListaInsumos";
            Text = "Insumos";
            Load += frmListaInsumos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBusqueda;
        private DataGridView dataGridView1;
        private Button btnModificar;
        private Button btnAgregar;
    }
}