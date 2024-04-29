using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBD2Grupo5.Forms
{
    public partial class MDIMenu : Form
    {
        private int childFormNumber = 0;
        private SqlConnection conexion;


        public MDIMenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIMenu_Load(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();

            if (!frm.getConectado)
            {
                this.Close();
            }
            else
            {
                this.conexion = frm.getConexion;
            }
        }

        private void pagoCultivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProveedores frm = new frmListaProveedores(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void listaProductoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListaProductor frm = new FrmListaProductor(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaestroDetalle_ProductorFinca frm = new MaestroDetalle_ProductorFinca(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void fincasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListaFincaLotes frm = new FrmListaFincaLotes(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void cultivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCultivosADD frm = new FrmCultivosADD(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void comprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListaCompras frm = new frmListaCompras(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaInsumos frm = new frmListaInsumos(this.conexion);
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporteTotalxCultivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mostrar el cuadro de diálogo de entrada personalizado para fecha
            DateTime userInput = ShowDateInputDialog("Selecciona una fecha:");

            // Mostrar la fecha introducida por el usuario
            if (userInput != null)
            {
               //MessageBox.Show("Fecha seleccionada: " + userInput);

                ReportsData.Reporte_Total_Finca frm = new ReportsData.Reporte_Total_Finca(userInput,conexion);
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una Fecha para generar el reporte ","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        //
        // Función para mostrar el cuadro de diálogo de entrada personalizado para fecha
        private DateTime ShowDateInputDialog(string text)
        {
            Form prompt = new Form();
            prompt.Width = 300;
            prompt.Height = 150;
            prompt.Text = text;

            DateTimePicker dateTimePicker = new DateTimePicker() { Left = 50, Top = 20, Width = 200 };
            

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
            Button okButton = new Button() { Text = "OK", Left = 100, Width = 100, Top = 50 };
            okButton.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(dateTimePicker);
            prompt.Controls.Add(okButton);
            prompt.ShowDialog();

            return dateTimePicker.Value;
        }
        //


    }
}
