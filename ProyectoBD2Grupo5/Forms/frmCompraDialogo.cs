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
    public partial class frmCompraDialogo : Form
    {
        SqlConnection cnx;
        SqlDataAdapter adpTablas;
        SqlDataAdapter adpCompra;
        SqlDataAdapter adpCompraDetalle;
        DataSet dsTablas;
        DataTable tabCompra;
        DataTable tabCompraDetalle;
        private int tipo;

        public frmCompraDialogo()
        {
            InitializeComponent();
        }
        public frmCompraDialogo(SqlConnection cnx, int compraid, int cultivoid, int tipo)
        {
            this.tipo = tipo;
            string sentencia = "select dbo.CalcularPkCompra(); " +
                               "select * from Proveedor; " +
                               "select * from Productor; " +
                               "select * from dbo.TipoCompra(); " +
                               "exec spObtenerProductorDeCultivo " + cultivoid;
            InitializeComponent();
            this.cnx = cnx;

            adpTablas = new SqlDataAdapter(sentencia, cnx);

            adpCompra = new SqlDataAdapter("spCompraSelect", cnx);
            adpCompra.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpCompra.SelectCommand.Parameters.AddWithValue("@compraid", compraid);

            adpCompra.InsertCommand = new SqlCommand("spCompraInsert", cnx);
            adpCompra.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpCompra.InsertCommand.Parameters.Add("@compraid", SqlDbType.Int, 4, "CompraID");
            adpCompra.InsertCommand.Parameters.AddWithValue("@tipocompraid", tipo);
            adpCompra.InsertCommand.Parameters.Add("@proveedorid", SqlDbType.Int, 4, "ProveedorID");
            adpCompra.InsertCommand.Parameters.Add("@productorid", SqlDbType.Int, 4, "ProductorID");
            adpCompra.InsertCommand.Parameters.Add("@fecha", SqlDbType.Date, 8, "Fecha");
            adpCompra.InsertCommand.Parameters.Add("@fechavencimiento", SqlDbType.Date, 8, "FechaVencimiento");
            adpCompra.InsertCommand.Parameters.AddWithValue("@cultivo", cultivoid);

            adpCompra.UpdateCommand = new SqlCommand("spCompraUpdate", cnx);
            adpCompra.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpCompra.UpdateCommand.Parameters.Add("@compraid", SqlDbType.Int, 4, "CompraID");
            adpCompra.UpdateCommand.Parameters.AddWithValue("@tipocompraid", tipo);
            adpCompra.UpdateCommand.Parameters.Add("@proveedorid", SqlDbType.Int, 4, "ProveedorID");
            adpCompra.UpdateCommand.Parameters.Add("@productorid", SqlDbType.Int, 4, "ProductorID");
            adpCompra.UpdateCommand.Parameters.Add("@fecha", SqlDbType.Date, 8, "Fecha");
            adpCompra.UpdateCommand.Parameters.Add("@fechavencimiento", SqlDbType.Date, 8, "FechaVencimiento");

            adpCompraDetalle = new SqlDataAdapter("spCompraDetalleSelect", cnx);
            adpCompraDetalle.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.SelectCommand.Parameters.AddWithValue("@compraid", compraid);
            adpCompraDetalle.SelectCommand.Parameters.AddWithValue("@tipo", tipo);

            adpCompraDetalle.InsertCommand = new SqlCommand("spCompraDetalleInsert", cnx);
            adpCompraDetalle.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.InsertCommand.Parameters.Add("@compraid", SqlDbType.Int, 4, "CompraID");
            adpCompraDetalle.InsertCommand.Parameters.Add("@insumoid", SqlDbType.Int, 4, "InsumoID");
            adpCompraDetalle.InsertCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpCompraDetalle.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");

            adpCompraDetalle.UpdateCommand = new SqlCommand("spCompraDetalleUpdate", cnx);
            adpCompraDetalle.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpCompraDetalle.UpdateCommand.Parameters.Add("@compraid", SqlDbType.Int, 4, "CompraID");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@insumoid", SqlDbType.Int, 4, "InsumoID");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.Int, 4, "Cantidad");
            adpCompraDetalle.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");



        }

        private void frmCompraDialogo_Load(object sender, EventArgs e)
        {
            try
            {
                dsTablas = new DataSet();
                adpTablas.Fill(dsTablas);

                tabCompra = new DataTable();
                adpCompra.Fill(tabCompra);

                tabCompraDetalle = new DataTable();
                adpCompraDetalle.Fill(tabCompraDetalle);

                cmbTipo.DataSource = dsTablas.Tables[3];
                cmbTipo.DisplayMember = "Nombre";
                cmbTipo.ValueMember = "TipoCompraID";
                cmbTipo.SelectedValue = this.tipo;

                if (this.tipo == 1)
                {
                    txtCultivo.Enabled = false;

                    cmbProveedor.DataSource = dsTablas.Tables[1];
                    cmbProveedor.DisplayMember = "Nombre";
                    cmbProveedor.ValueMember = "ProveedorID";
                }
                else
                {
                    cmbProveedor.Enabled = false;
                    dpFechaVencimiento.Enabled = false;
                }

                dataGridView1.DataSource = tabCompraDetalle;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.Columns["CompraDetalleID"].ReadOnly = true;
                dataGridView1.Columns["CompraID"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                if (this.tipo == 2)
                {
                    dataGridView1.Columns["Cobro Productor"].ReadOnly = true;
                }

                if (tabCompra.Rows.Count == 0)
                {
                    tabCompra.Rows.Add();
                    txtID.Text = dsTablas.Tables[0].Rows[0][0].ToString();
                    dataGridView1.Columns["InsumoID"].ReadOnly = false;
                }
                else
                {
                    txtID.Text = tabCompra.Rows[0]["CompraID"].ToString();

                    if (this.tipo == 1)
                    {
                        cmbProveedor.SelectedValue = tabCompra.Rows[0]["ProveedorID"];
                        dpFecha.Value = Convert.ToDateTime(tabCompra.Rows[0]["Fecha"]);
                        dpFechaVencimiento.Value = Convert.ToDateTime(tabCompra.Rows[0]["FechaVencimiento"]);
                    }
                    else
                    {
                        txtProductor.Text = dsTablas.Tables[4].Rows[0]["Nombre"].ToString();
                        dpFecha.Value = Convert.ToDateTime(tabCompra.Rows[0]["Fecha"]);
                        txtCultivo.Text = tabCompra.Rows[0]["CultivoID"].ToString();
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string col = dataGridView1.Columns[e.ColumnIndex].Name.ToLower();

            if (col == "insumoid" && e.FormattedValue.ToString().Length > 0)
            {
                String sql = "select * from Insumo where InsumoID = " + e.FormattedValue;
                SqlDataAdapter adp = new SqlDataAdapter(sql, cnx);
                DataTable tabInsumo = new DataTable();
                adp.Fill(tabInsumo);

                if (tabInsumo.Rows.Count == 0)
                {
                    MessageBox.Show("El insumo no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                {
                    tabCompraDetalle.DefaultView[e.RowIndex]["nombre"] = tabInsumo.Rows[0]["nombre"].ToString();
                }
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["CompraID"].Value = txtID.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                tabCompra.Rows[0]["TipoCompraID"] = cmbTipo.SelectedValue;  
                tabCompra.Rows[0]["Fecha"] = dpFecha.Value;
                
                if(this.tipo == 1)
                {
                    tabCompra.Rows[0]["FechaVencimiento"] = dpFechaVencimiento.Value;
                    tabCompra.Rows[0]["ProveedorID"] = cmbProveedor.SelectedValue;
                }

                if(this.tipo == 2)
                {
                    tabCompra.Rows[0]["CultivoID"] = txtCultivo.Text;
                    tabCompra.Rows[0]["ProductorID"] = dsTablas.Tables[4].Rows[0]["ProductorID"].ToString();
                }

                adpCompra.Update(tabCompra);
                adpCompraDetalle.Update(tabCompraDetalle);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView1.Rows[e.RowIndex].Cells["InsumoID"].ReadOnly = false;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells["InsumoID"].ReadOnly = true;
            }
        }
    }
}
