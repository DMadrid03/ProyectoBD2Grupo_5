namespace ProyectoBD2Grupo5.Forms
{
    partial class frmInsumoDialogo
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNombre = new TextBox();
            txtObservacion = new TextBox();
            txtExistencia = new TextBox();
            cmbTipo = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 70);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 132);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Existencia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(361, 129);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "Observacion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(361, 70);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 3;
            label4.Text = "Tipo";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(133, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(181, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(451, 129);
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(181, 65);
            txtObservacion.TabIndex = 5;
            // 
            // txtExistencia
            // 
            txtExistencia.Location = new Point(133, 129);
            txtExistencia.Name = "txtExistencia";
            txtExistencia.Size = new Size(181, 23);
            txtExistencia.TabIndex = 6;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(451, 67);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(181, 23);
            cmbTipo.TabIndex = 7;
            // 
            // frmInsumoDialogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 260);
            Controls.Add(cmbTipo);
            Controls.Add(txtExistencia);
            Controls.Add(txtObservacion);
            Controls.Add(txtNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmInsumoDialogo";
            Text = "Detalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNombre;
        private TextBox txtObservacion;
        private TextBox txtExistencia;
        private ComboBox cmbTipo;
    }
}