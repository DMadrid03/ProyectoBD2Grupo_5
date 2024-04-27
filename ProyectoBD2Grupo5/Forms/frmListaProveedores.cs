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

    public partial class frmListaProveedores : Form
    {
        private SqlConnection conexion;
        private SqlDataAdapter adpProveedor;
        private SqlDataAdapter adpBusqueda;
        private DataTable tabProveedor;

        public frmListaProveedores()
        {
            InitializeComponent();
        }

        public frmListaProveedores(SqlConnection cnx)
        {
            InitializeComponent();
            this.conexion = cnx;
            adpProveedor = new SqlDataAdapter("spProveedorSelect", cnx);
            adpProveedor.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpProveedor.SelectCommand.Parameters.AddWithValue("@proveedorid", 0);


            adpBusqueda = new SqlDataAdapter();
            adpBusqueda.SelectCommand = new SqlCommand("spBusquedaProveedor", cnx);
            adpBusqueda.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpBusqueda.SelectCommand.Parameters.Add("@texto", SqlDbType.VarChar, 50);


            adpProveedor.InsertCommand = new SqlCommand("spProveedorInsert", cnx);
            adpProveedor.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpProveedor.InsertCommand.Parameters.Add("@proveedorid", SqlDbType.Int, 4, "ProveedoriD");
            adpProveedor.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            adpProveedor.InsertCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "Direccion");
            adpProveedor.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;

            adpProveedor.UpdateCommand = new SqlCommand("spProveedorUpdate", cnx);
            adpProveedor.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpProveedor.UpdateCommand.Parameters.Add("@proveedorid", SqlDbType.Int, 4, "ProveedoriD");
            adpProveedor.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");
            adpProveedor.UpdateCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "Direccion");

            adpProveedor.DeleteCommand = new SqlCommand("spProveedorDelete", cnx);
            adpProveedor.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adpProveedor.DeleteCommand.Parameters.Add("@proveedorid", SqlDbType.Int, 4, "ProveedoriD");

        }

        private void frmListaProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                tabProveedor = new DataTable();
                adpProveedor.Fill(tabProveedor);

                dataGridView1.DataSource = tabProveedor;
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

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                tabProveedor.Clear();
                if (txtBusqueda.Text.Length == 0)
                {
                    adpProveedor.Fill(tabProveedor);
                }
                else
                {
                    adpBusqueda.SelectCommand.Parameters[0].Value = txtBusqueda.Text;
                    adpBusqueda.Fill(tabProveedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            frmProveedorDialogo frm = new frmProveedorDialogo(this.conexion, this.adpProveedor, -1);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            tabProveedor.Clear();
            adpProveedor.Fill(tabProveedor);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                int proveedorid = (int)(tabProveedor.DefaultView[indice]["ProveedorID"]);

                txtBusqueda.Text = "";
                frmProveedorDialogo frm = new frmProveedorDialogo(this.conexion, this.adpProveedor, proveedorid);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                tabProveedor.Clear();
                adpProveedor.Fill(tabProveedor);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
