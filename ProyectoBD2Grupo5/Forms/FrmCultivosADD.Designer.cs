namespace ProyectoBD2Grupo5.Forms
{
    partial class FrmCultivosADD
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
            dataGridView1 = new DataGridView();
            dataGridViewLote = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLote).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(398, 426);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridViewLote
            // 
            dataGridViewLote.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLote.Location = new Point(6, 25);
            dataGridViewLote.Name = "dataGridViewLote";
            dataGridViewLote.RowTemplate.Height = 25;
            dataGridViewLote.Size = new Size(398, 426);
            dataGridViewLote.TabIndex = 1;
            dataGridViewLote.CellClick += dataGridViewLote_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewLote);
            groupBox1.Location = new Point(12, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 451);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lotes";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(461, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(410, 451);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cultivos";
            // 
            // button1
            // 
            button1.Location = new Point(891, 122);
            button1.Name = "button1";
            button1.Size = new Size(119, 48);
            button1.TabIndex = 4;
            button1.Text = "Agregar Datos del cultivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmCultivosADD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 509);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmCultivosADD";
            Text = "FrmCultivosADD";
            Load += FrmCultivosADD_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLote).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridViewLote;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
    }
}