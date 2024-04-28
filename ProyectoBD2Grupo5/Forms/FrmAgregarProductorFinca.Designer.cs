namespace ProyectoBD2Grupo5.Forms
{
    partial class FrmAgregarProductorFinca
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
            textProductorNombre = new TextBox();
            label1 = new Label();
            cmdSalvar = new Button();
            label2 = new Label();
            textFincaNombre = new TextBox();
            SuspendLayout();
            // 
            // textProductorNombre
            // 
            textProductorNombre.Location = new Point(185, 54);
            textProductorNombre.Name = "textProductorNombre";
            textProductorNombre.Size = new Size(100, 23);
            textProductorNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 57);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre del productor";
            // 
            // cmdSalvar
            // 
            cmdSalvar.Location = new Point(141, 192);
            cmdSalvar.Name = "cmdSalvar";
            cmdSalvar.Size = new Size(88, 80);
            cmdSalvar.TabIndex = 2;
            cmdSalvar.Text = "Salvar";
            cmdSalvar.UseVisualStyleBackColor = true;
            cmdSalvar.Click += cmdSalvar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 118);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre de la Finca";
            // 
            // textFincaNombre
            // 
            textFincaNombre.Location = new Point(185, 110);
            textFincaNombre.Name = "textFincaNombre";
            textFincaNombre.Size = new Size(100, 23);
            textFincaNombre.TabIndex = 3;
            // 
            // FrmAgregarProductorFinca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 379);
            Controls.Add(label2);
            Controls.Add(textFincaNombre);
            Controls.Add(cmdSalvar);
            Controls.Add(label1);
            Controls.Add(textProductorNombre);
            Name = "FrmAgregarProductorFinca";
            Text = "FrmAgregarProductorFinca";
            Load += FrmAgregarProductorFinca_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textProductorNombre;
        private Label label1;
        private Button cmdSalvar;
        private Label label2;
        private TextBox textFincaNombre;
    }
}