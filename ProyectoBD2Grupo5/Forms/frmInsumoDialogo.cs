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
    public partial class frmInsumoDialogo : Form
    {
        private SqlConnection conexion;
        private SqlDataAdapter adpTablas;
        private SqlDataAdapter adpInsumos;
        private DataSet dsTablas;
        private DataTable tabInsumo;

        public frmInsumoDialogo()
        {
            InitializeComponent();
        }
        public frmInsumoDialogo(SqlConnection cnx, int insumoid)
        {
            string sql = "select dbo.CalcularPkInsumo(); select * from dbo.TipoInsumo()";
            InitializeComponent();
            this.conexion = cnx;

            adpTablas = new SqlDataAdapter(sql, cnx);

            adpInsumos = new SqlDataAdapter("spInsumoSelect", cnx);
            adpInsumos.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.SelectCommand.Parameters.AddWithValue("@insumoid", insumoid);

            adpInsumos.InsertCommand = new SqlCommand("spInsumoInsert", cnx);
            adpInsumos.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.InsertCommand.Parameters.Add("@insumoid", SqlDbType.Int, 4, "InsumoID");
            adpInsumos.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100, "Nombre");
            adpInsumos.InsertCommand.Parameters.Add("@tipo", SqlDbType.Int, 4, "TipoInsumoID");
            adpInsumos.InsertCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 200, "Observacion");
            adpInsumos.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;


            adpInsumos.UpdateCommand = new SqlCommand("spInsumoUpdate", cnx);
            adpInsumos.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.UpdateCommand.Parameters.AddWithValue("@insumoid", insumoid);
            adpInsumos.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100, "Nombre");
            adpInsumos.UpdateCommand.Parameters.Add("@tipo", SqlDbType.Int, 4, "TipoInsumoID");
            adpInsumos.UpdateCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 200, "Observacion");

        }

        private bool validarBlancos()
        {
            bool hayError = false;

            if (txtNombre.Text.Length == 0)
            {
                hayError = true;
                errorProvider1.SetError(txtNombre, "No debe dejar la casilla en blanco");
            }

            return hayError;
        }

        private void frmInsumoDialogo_Load(object sender, EventArgs e)
        {
            try
            {
                dsTablas = new DataSet();
                tabInsumo = new DataTable();
                adpTablas.Fill(dsTablas);
                adpInsumos.Fill(tabInsumo);

                cmbTipo.DataSource = dsTablas.Tables[1];
                cmbTipo.DisplayMember = "Nombre";
                cmbTipo.ValueMember = "TipoInsumoID";

                if (tabInsumo.Rows.Count == 0)
                {
                    tabInsumo.Rows.Add();
                    txtCodigo.Text = dsTablas.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    txtCodigo.Text = tabInsumo.Rows[0]["InsumoID"].ToString();
                    cmbTipo.SelectedValue = tabInsumo.Rows[0]["TipoInsumoID"];
                    txtNombre.Text = tabInsumo.Rows[0]["Nombre"].ToString();
                    txtExistencia.Text = tabInsumo.Rows[0]["Existencia"].ToString();
                    txtObservacion.Text = tabInsumo.Rows[0]["Observacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarBlancos())
                {
                    return;
                }

                tabInsumo.Rows[0]["InsumoID"] = (txtCodigo.Text);
                tabInsumo.Rows[0]["Nombre"] = txtNombre.Text;
                tabInsumo.Rows[0]["Existencia"] = txtExistencia.Text;
                tabInsumo.Rows[0]["TipoInsumoID"] = cmbTipo.SelectedValue;
                tabInsumo.Rows[0]["Observacion"] = txtObservacion.Text;

                adpInsumos.Update(tabInsumo);

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
