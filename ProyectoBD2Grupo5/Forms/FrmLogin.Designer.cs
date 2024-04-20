namespace ProyectoBD2Grupo5.Forms
{
    partial class FrmLogin
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtUsuario = new TextBox();
            txtServidor = new TextBox();
            label2 = new Label();
            txtBaseDeDatos = new TextBox();
            label3 = new Label();
            txtContrasenia = new TextBox();
            label4 = new Label();
            cmdIngresar = new Button();
            cmdCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 41);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(135, 38);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(121, 23);
            txtUsuario.TabIndex = 1;
            txtUsuario.Text = "jefferson.castro";
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(135, 174);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(121, 23);
            txtServidor.TabIndex = 3;
            txtServidor.Text = "3.128.144.165";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 177);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Servidor";
            // 
            // txtBaseDeDatos
            // 
            txtBaseDeDatos.Location = new Point(135, 127);
            txtBaseDeDatos.Name = "txtBaseDeDatos";
            txtBaseDeDatos.Size = new Size(121, 23);
            txtBaseDeDatos.TabIndex = 5;
            txtBaseDeDatos.Text = "DB20211900096";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 130);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 4;
            label3.Text = "Base de Datos";
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(135, 82);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PasswordChar = '*';
            txtContrasenia.Size = new Size(121, 23);
            txtContrasenia.TabIndex = 7;
            txtContrasenia.Text = "JC20211900096";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 85);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 6;
            label4.Text = "Contraseña";
            // 
            // cmdIngresar
            // 
            cmdIngresar.Location = new Point(25, 226);
            cmdIngresar.Name = "cmdIngresar";
            cmdIngresar.Size = new Size(75, 23);
            cmdIngresar.TabIndex = 8;
            cmdIngresar.Text = "Ingresar";
            cmdIngresar.UseVisualStyleBackColor = true;
            cmdIngresar.Click += cmdIngresar_Click;
            // 
            // cmdCancelar
            // 
            cmdCancelar.Location = new Point(181, 226);
            cmdCancelar.Name = "cmdCancelar";
            cmdCancelar.Size = new Size(75, 23);
            cmdCancelar.TabIndex = 9;
            cmdCancelar.Text = "Cancelar";
            cmdCancelar.UseVisualStyleBackColor = true;
            cmdCancelar.Click += cmdCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 261);
            Controls.Add(cmdCancelar);
            Controls.Add(cmdIngresar);
            Controls.Add(txtContrasenia);
            Controls.Add(label4);
            Controls.Add(txtBaseDeDatos);
            Controls.Add(label3);
            Controls.Add(txtServidor);
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtServidor;
        private Label label2;
        private TextBox txtBaseDeDatos;
        private Label label3;
        private TextBox txtContrasenia;
        private Label label4;
        private Button cmdIngresar;
        private Button cmdCancelar;
        private ErrorProvider errorProvider1;
    }
}