namespace ProyectoBD2Grupo5.Forms
{
    partial class MaestroDetalle_ProductorFinca
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
            txtBuscarProductor = new TextBox();
            label1 = new Label();
            dataGridViewProductor = new DataGridView();
            dataGridViewFinca = new DataGridView();
            cmdSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFinca).BeginInit();
            SuspendLayout();
            // 
            // txtBuscarProductor
            // 
            txtBuscarProductor.Location = new Point(136, 36);
            txtBuscarProductor.Name = "txtBuscarProductor";
            txtBuscarProductor.Size = new Size(100, 23);
            txtBuscarProductor.TabIndex = 1;
            txtBuscarProductor.KeyPress += txtBuscarProductor_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 44);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 2;
            label1.Text = "Buscar Productor";
            // 
            // dataGridViewProductor
            // 
            dataGridViewProductor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductor.Location = new Point(22, 90);
            dataGridViewProductor.Name = "dataGridViewProductor";
            dataGridViewProductor.RowTemplate.Height = 25;
            dataGridViewProductor.Size = new Size(454, 139);
            dataGridViewProductor.TabIndex = 3;
            dataGridViewProductor.CellClick += dataGridViewProductor_CellClick;
            // 
            // dataGridViewFinca
            // 
            dataGridViewFinca.AllowUserToDeleteRows = false;
            dataGridViewFinca.AllowUserToResizeColumns = false;
            dataGridViewFinca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFinca.Location = new Point(22, 256);
            dataGridViewFinca.Name = "dataGridViewFinca";
            dataGridViewFinca.RowTemplate.Height = 25;
            dataGridViewFinca.Size = new Size(454, 182);
            dataGridViewFinca.TabIndex = 4;
            dataGridViewFinca.CellContentClick += dataGridView2_CellContentClick;
            dataGridViewFinca.CellFormatting += dataGridViewFinca_CellFormatting;
            // 
            // cmdSalvar
            // 
            cmdSalvar.Location = new Point(286, 36);
            cmdSalvar.Name = "cmdSalvar";
            cmdSalvar.Size = new Size(100, 23);
            cmdSalvar.TabIndex = 5;
            cmdSalvar.Text = "Salvar";
            cmdSalvar.UseVisualStyleBackColor = true;
            cmdSalvar.Click += button1_Click;
            // 
            // MaestroDetalle_ProductorFinca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 450);
            Controls.Add(cmdSalvar);
            Controls.Add(dataGridViewFinca);
            Controls.Add(dataGridViewProductor);
            Controls.Add(label1);
            Controls.Add(txtBuscarProductor);
            Name = "MaestroDetalle_ProductorFinca";
            Text = "MaestroDetalle_ProductorFinca";
            Load += MaestroDetalle_ProductorFinca_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFinca).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscarProductor;
        private Label label1;
        private DataGridView dataGridViewProductor;
        private DataGridView dataGridViewFinca;
        private Button cmdSalvar;
    }
}