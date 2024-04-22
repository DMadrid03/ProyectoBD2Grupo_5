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
    public partial class frmProveedorDialogo : Form
    {
        private SqlConnection conexion;
        private SqlDataAdapter adpProveedor;
        private DataTable tabProveedor;


        public frmProveedorDialogo()
        {
            InitializeComponent();
        }
        public frmProveedorDialogo(SqlConnection cnx, SqlDataAdapter adpProveedor, int proveedorid)
        {
            InitializeComponent();
            this.conexion = cnx;
            this.adpProveedor = adpProveedor;

            adpProveedor.SelectCommand.Parameters[0].Value = proveedorid;

            adpProveedor.UpdateCommand.Parameters[0].Value = proveedorid;
        }

        private bool validarBlancos()
        {
            errorProvider1.Clear();
            bool hayError = false;

            if (txtNombre.Text.Length == 0)
            {
                hayError = true;
                errorProvider1.SetError(txtNombre, "No deben haber casillas en blanco");
            }
            if (txtDireccion.Text.Length == 0)
            {
                hayError = true;
                errorProvider1.SetError(txtDireccion, "No deben haber casillas en blanco");
            }

            return hayError;
        }

        private void frmProveedorDialogo_Load(object sender, EventArgs e)
        {
            try
            {
                tabProveedor = new DataTable();
                adpProveedor.Fill(tabProveedor);

                if (tabProveedor.Rows.Count == 0)
                {
                    tabProveedor.Rows.Add();
                }
                else
                {
                    txtNombre.Text = tabProveedor.Rows[0]["Nombre"].ToString();
                    txtDireccion.Text = tabProveedor.Rows[0]["Direccion"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            adpProveedor.SelectCommand.Parameters[0].Value = 0;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarBlancos())
                {
                    return;
                }

                tabProveedor.Rows[0]["Nombre"] = txtNombre.Text;
                tabProveedor.Rows[0]["Direccion"] = txtDireccion.Text;

                adpProveedor.Update(tabProveedor);

                adpProveedor.SelectCommand.Parameters[0].Value = 0;
                this.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }
    }
}
