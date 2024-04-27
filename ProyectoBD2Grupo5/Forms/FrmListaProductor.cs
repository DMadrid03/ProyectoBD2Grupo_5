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
    public partial class FrmListaProductor : Form
    {
        //definicion de componentes para conexion a base de datos
        private SqlConnection conexion;
        private SqlDataAdapter adpProductor;
        private SqlDataAdapter adpBusqueda;
        private DataTable tabProductor;

        public FrmListaProductor()
        {
            InitializeComponent();
        }
        public FrmListaProductor(SqlConnection cnx)
        {
            InitializeComponent();
            conexion = cnx;

            adpProductor = new SqlDataAdapter("spSelectProductor", conexion);
            adpProductor.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpProductor.SelectCommand.Parameters.AddWithValue("@id", 0);

            //cuadro de busqueda
            adpBusqueda = new SqlDataAdapter("spBusquedaProductor", conexion);
            adpBusqueda.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpBusqueda.SelectCommand.Parameters.Add("@texto", SqlDbType.VarChar, 50);

            //cuando toque actualizar un productor
            adpProductor.UpdateCommand = new SqlCommand("spUpdateProductorFinca", conexion);
            adpProductor.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpProductor.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "ID");
            adpProductor.UpdateCommand.Parameters.Add("@NombreProductor", SqlDbType.VarChar, 50, "Agricultor");
            adpProductor.UpdateCommand.Parameters.Add("@NombreFinca", SqlDbType.VarChar, 50, "NombreFinca");

           
            adpProductor.InsertCommand = new SqlCommand("spProductorFincaInsert", conexion);
            adpProductor.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpProductor.InsertCommand.Parameters.Add("@nombre", SqlDbType.Char, 50, "Agricultor");
            adpProductor.InsertCommand.Parameters.Add("@finca", SqlDbType.Char, 50, "NombreFinca");
        }
        private void FrmListaProductor_Load(object sender, EventArgs e)
        {
           
            try
            {
                tabProductor = new DataTable();
                adpProductor.Fill(tabProductor);
                dataGridView1.DataSource = tabProductor;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                tabProductor.Clear();
                if (txtBusqueda.Text.Length == 0)
                {
                    adpProductor.Fill(tabProductor);
                }
                else
                {
                    adpBusqueda.SelectCommand.Parameters[0].Value = txtBusqueda.Text;
                    adpBusqueda.Fill(tabProductor);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {

                int indice = dataGridView1.SelectedRows[0].Index;
                int productorID = (int)tabProductor.Rows[indice]["ID"];
                //MessageBox.Show("valor" + productorID);
                txtBusqueda.Clear();

                FrmAgregarProductorFinca frm = new FrmAgregarProductorFinca(this.conexion, this.adpProductor, productorID);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                tabProductor.Clear();
                adpProductor.Fill(tabProductor);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            FrmAgregarProductorFinca frm = new FrmAgregarProductorFinca(this.conexion, adpProductor, -1);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            tabProductor.Clear();
            adpProductor.Fill(tabProductor);

            if (txtBusqueda.Text.Length > 0)
            {
                txtBusqueda.Clear();
                
            }
               
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
