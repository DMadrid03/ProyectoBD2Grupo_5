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

            adpInsumos = new SqlDataAdapter("spListaInsumosSelect", cnx);
            adpInsumos.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpInsumos.SelectCommand.Parameters.AddWithValue("@busqueda", "");
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



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            frmInsumoDialogo frm = new frmInsumoDialogo(this.conexion, -1);
            frm.ShowDialog();

            tabInsumos.Clear();
            adpInsumos.Fill(tabInsumos);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                int insumoid = (int)tabInsumos.Rows[indice]["InsumoID"];
                txtBusqueda.Text = "";

                frmInsumoDialogo frm = new frmInsumoDialogo(this.conexion, insumoid);
                frm.ShowDialog();

                tabInsumos.Clear();
                adpInsumos.Fill(tabInsumos);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tabInsumos.Clear();
                if (txtBusqueda.Text.Length == 0)
                {
                    adpInsumos.SelectCommand.Parameters[0].Value = "";
                    adpInsumos.Fill(tabInsumos);
                }
                else
                {
                    adpInsumos.SelectCommand.Parameters[0].Value = txtBusqueda.Text;
                    adpInsumos.Fill(tabInsumos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
