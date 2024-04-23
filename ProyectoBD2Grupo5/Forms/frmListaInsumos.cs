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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoBD2Grupo5.Forms
{
    public partial class frmListaInsumos : Form
    {
        private SqlConnection conexion;
        private SqlDataAdapter adpInsumos;
        private SqlDataAdapter adpBusqueda;
        private DataTable tabInsumos;
        public frmListaInsumos()
        {
            InitializeComponent();
        }
        public frmListaInsumos(SqlConnection cnx)
        {
            InitializeComponent();
            this.conexion = cnx;

            adpInsumos = new SqlDataAdapter("spInsumoSelect", cnx);
            adpInsumos.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.SelectCommand.Parameters.AddWithValue("@insumoid", 0);

            adpBusqueda = new SqlDataAdapter();
            adpBusqueda.SelectCommand = new SqlCommand("spBusquedaInsumo", cnx);
            adpBusqueda.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpBusqueda.SelectCommand.Parameters.Add("@texto", SqlDbType.VarChar, 50);

            adpInsumos.InsertCommand = new SqlCommand("spInsumoInsert", cnx);
            adpInsumos.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.InsertCommand.Parameters.Add("@insumoid", SqlDbType.Int, 4, "InsumoID");
            adpInsumos.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100, "Nombre");
            adpInsumos.InsertCommand.Parameters.Add("@tipo", SqlDbType.Int, 4, "TipoInsumoID");
            adpInsumos.InsertCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 200, "Observacion");
            adpInsumos.InsertCommand.Parameters[0].Direction = ParameterDirection.InputOutput;


            adpInsumos.UpdateCommand = new SqlCommand("spInsumoUpdate", cnx);
            adpInsumos.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.UpdateCommand.Parameters.Add("@insumoid", SqlDbType.Int, 4, "InsumoID");
            adpInsumos.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100, "Nombre");
            adpInsumos.UpdateCommand.Parameters.Add("@tipo", SqlDbType.Int, 4, "TipoInsumoID");
            adpInsumos.UpdateCommand.Parameters.Add("@observacion", SqlDbType.VarChar, 200, "Observacion");


            adpInsumos.DeleteCommand = new SqlCommand("spInsumoDelete", cnx);
            adpInsumos.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.DeleteCommand.Parameters.Add("@insumoid", SqlDbType.Int, 4, "InsumoID");

        }

        private void frmListaInsumos_Load(object sender, EventArgs e)
        {
            try
            {
                tabInsumos = new DataTable();
                adpInsumos.Fill(tabInsumos);

                dataGridView1.DataSource = tabInsumos;
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
                tabInsumos.Clear();
                if (txtBusqueda.Text.Length == 0)
                {
                    adpInsumos.Fill(tabInsumos);
                }
                else
                {
                    adpBusqueda.SelectCommand.Parameters[0].Value = txtBusqueda.Text;
                    adpBusqueda.Fill(tabInsumos);
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

            frmInsumoDialogo frm = new frmInsumoDialogo(this.conexion, this.adpInsumos, -1);
            frm.ShowDialog();

            tabInsumos.Clear();
            adpInsumos.Fill(tabInsumos);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                int insumoid = (int)tabInsumos.Rows[indice]["InsumoID"];
                txtBusqueda.Text = "";

                frmInsumoDialogo frm = new frmInsumoDialogo(this.conexion, this.adpInsumos, insumoid);
                frm.ShowDialog();

                tabInsumos.Clear();
                adpInsumos.Fill(tabInsumos);
            }
        }
    }
}
