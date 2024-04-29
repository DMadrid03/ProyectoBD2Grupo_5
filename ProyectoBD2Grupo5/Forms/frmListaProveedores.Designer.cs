namespace ProyectoBD2Grupo5.Forms
{
    partial class frmListaProveedores
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
            btnSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 9;
            label1.Text = "Buscar proveedores:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(131, 17);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(178, 23);
            txtBusqueda.TabIndex = 8;
            txtBusqueda.KeyUp += txtBusqueda_KeyUp;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(595, 241);
            dataGridView1.TabIndex = 7;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(532, 16);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // frmListaProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 310);
            Controls.Add(label1);
            Controls.Add(txtBusqueda);
            Controls.Add(dataGridView1);
            Controls.Add(btnSalvar);
            Name = "frmListaProveedores";
            Text = "Proveedores";
            Load += frmListaProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBusqueda;
        private DataGridView dataGridView1;
        private Button btnSalvar;
    }
}