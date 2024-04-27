using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoBD2Grupo5.Forms
{
    public partial class frmListaCompras : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adpCompra;
        DataTable tabCompra;
        public frmListaCompras()
        {
            InitializeComponent();
        }
        public frmListaCompras(SqlConnection cnx)
        {
            InitializeComponent();
            this.conexion = cnx;

            adpCompra = new SqlDataAdapter("spListaCompraSelect", cnx);
            adpCompra.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpCompra.SelectCommand.Parameters.AddWithValue("@tipo", 1);

            tabCompra = new DataTable();
            radCompras.Checked = true;
        }

        private void frmListaCompras_Load(object sender, EventArgs e)
        {
            try
            {
                tabCompra.Clear();
                adpCompra.Fill(tabCompra);
                dataGridView1.DataSource = tabCompra;

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (radCompras.Checked)
            {
                adpCompra.SelectCommand.Parameters[0].Value = 1;
                tabCompra.Clear();
                adpCompra.Fill(tabCompra);
            }
        }

        private void radSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (radSolicitudes.Checked)
            {
                adpCompra.SelectCommand.Parameters[0].Value = 2;
                tabCompra.Clear();
                adpCompra.Fill(tabCompra);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
