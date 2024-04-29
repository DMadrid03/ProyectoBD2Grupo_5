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
        DataTable tabSolicitud;
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


        }

        private void frmListaCompras_Load(object sender, EventArgs e)
        {
            try
            {
                tabCompra = new DataTable();
                tabSolicitud = new DataTable();


                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                radCompras.Checked = true;
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
                btnAgregar.Enabled = true;
                tabCompra.Clear();
                adpCompra.SelectCommand.Parameters[0].Value = 1;
                adpCompra.Fill(tabCompra);
                dataGridView1.DataSource = tabCompra;
            }
        }

        private void radSolicitudes_CheckedChanged(object sender, EventArgs e)
        {
            if (radSolicitudes.Checked)
            {
                btnAgregar.Enabled = false;
                tabSolicitud.Clear();
                adpCompra.SelectCommand.Parameters[0].Value = 2;
                adpCompra.Fill(tabSolicitud);
                dataGridView1.DataSource = tabSolicitud;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            frmCompraDialogo frm = new frmCompraDialogo(conexion, -1, -1, 1);
            frm.ShowDialog();

            tabCompra.Clear();
            adpCompra.Fill(tabCompra);
            dataGridView1.DataSource = tabCompra;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.CurrentRow.Index;

                



                if (radSolicitudes.Checked)
                {
                    int compraid = (int)tabSolicitud.DefaultView[indice]["CompraID"];
                    int cultivoid = (int)tabSolicitud.DefaultView[indice]["CultivoID"];
                    frmCompraDialogo frm = new frmCompraDialogo(conexion, compraid, cultivoid, 2);
                    frm.ShowDialog();

                    tabSolicitud.Clear();
                    adpCompra.Fill(tabSolicitud);
                    dataGridView1.DataSource = tabSolicitud;
                }

                if (radCompras.Checked)
                {
                    int compraid = (int)tabCompra.DefaultView[indice]["CompraID"];
                    frmCompraDialogo frm = new frmCompraDialogo(conexion, compraid, -1, 1);
                    frm.ShowDialog();

                    tabCompra.Clear();
                    adpCompra.Fill(tabCompra);
                    dataGridView1.DataSource = tabCompra;
                }

                txtBusqueda.Text = "";
            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (radCompras.Checked)
            {
                if (txtBusqueda.Text.Length == 0)
                    tabCompra.DefaultView.RowFilter = "";
                else
                    tabCompra.DefaultView.RowFilter = "Nombre like '%" + txtBusqueda.Text + "%'";
            }

            if (radSolicitudes.Checked)
            {
                if (txtBusqueda.Text.Length == 0)
                    tabSolicitud.DefaultView.RowFilter = "";
                else
                    tabSolicitud.DefaultView.RowFilter = "Nombre like '%" + txtBusqueda.Text + "%'";
            }

        }
    }
}
