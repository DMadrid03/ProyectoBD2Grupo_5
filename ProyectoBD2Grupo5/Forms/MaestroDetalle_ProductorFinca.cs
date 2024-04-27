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
    public partial class MaestroDetalle_ProductorFinca : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adpProductorSearch;
        SqlDataAdapter adpProductor;
        SqlDataAdapter adpFinca;
        DataTable dtProductor;
        DataTable dtFinca;
        int id = 0;
        public MaestroDetalle_ProductorFinca()
        {
            InitializeComponent();
        }
        public MaestroDetalle_ProductorFinca(SqlConnection cnx)
        {
            InitializeComponent();
            conexion = cnx;
            //para la busqueda
            adpProductorSearch = new SqlDataAdapter("spProductorSearch", conexion);
            adpProductorSearch.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpProductorSearch.SelectCommand.Parameters.Add("@texto", SqlDbType.VarChar, 50);


            //para el datagried productor
            adpProductor = new SqlDataAdapter("spSelectProductorSimple", conexion);
            adpProductor.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpProductor.SelectCommand.Parameters.AddWithValue("id", 0);

            //para llenar datagried de la fincas
            adpFinca = new SqlDataAdapter("spSelectFinca", conexion);
            adpFinca.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpFinca.SelectCommand.Parameters.Add("@id", SqlDbType.Int, 4);

            //INSERT falta validar eso del idfinca que no see pueda editat
            adpFinca.InsertCommand = new SqlCommand("spInsertFinca", conexion);
            adpFinca.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpFinca.InsertCommand.Parameters.Add("@idprod", SqlDbType.Int, 4);

            adpFinca.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "Nombre");

            //update 
            adpFinca.UpdateCommand = new SqlCommand("spUpdateFinca", conexion);
            adpFinca.UpdateCommand.CommandType = CommandType.StoredProcedure;
            adpFinca.UpdateCommand.Parameters.Add("@idPro", SqlDbType.Int, 4);
            adpFinca.UpdateCommand.Parameters.Add("@fincaID", SqlDbType.Int, 4, "FincaID");
            adpFinca.UpdateCommand.Parameters.Add("@NombreFinca", SqlDbType.Char, 50, "Nombre");
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void AjustarData(DataGridView dtg)
        {
            // dtg.Dock = DockStyle.Fill;

            // Configura las columnas para que ocupen todo el ancho disponible en el DataGridView
            //
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            ///
        }
        private void MaestroDetalle_ProductorFinca_Load(object sender, EventArgs e)
        {

            try
            {
                dtProductor = new DataTable();
                adpProductor.Fill(dtProductor);
                dataGridViewProductor.DataSource = dtProductor;
                AjustarData(dataGridViewFinca);
                AjustarData(dataGridViewProductor);
                dataGridViewProductor.ReadOnly = true;
                dataGridViewProductor.AllowUserToAddRows = false;
                dataGridViewProductor.AllowUserToDeleteRows = false;
               // dataGridViewProductor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dtFinca = new DataTable();
                adpFinca.SelectCommand.Parameters[0].Value = id;
                adpFinca.Fill(dtFinca);
                dataGridViewFinca.DataSource = dtFinca;
                dataGridViewFinca.Columns["ProductorID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarProductor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                dtProductor.Clear();
                if (txtBuscarProductor.Text.Length == 0)
                {
                    adpProductor.Fill(dtProductor);
                }
                else
                {
                    adpProductorSearch.SelectCommand.Parameters[0].Value = txtBuscarProductor.Text;
                    adpProductorSearch.Fill(dtProductor);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewProductor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtFinca.Clear();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el valor del ID de la fila seleccionada
                id = Convert.ToInt32(dataGridViewProductor.Rows[e.RowIndex].Cells["ID"].Value);
                //para llenar el data hijo
                adpFinca.SelectCommand.Parameters[0].Value = id;
                adpFinca.Fill(dtFinca);

                // Hacer algo con el valor del ID


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            adpFinca.InsertCommand.Parameters[0].Value = id;
            adpFinca.UpdateCommand.Parameters[0].Value = id;
            adpFinca.Update(dtFinca);
            MessageBox.Show("La Tarea se realizó con éxito", "éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtFinca.Clear();
            dtProductor.Clear();
            adpProductor.Fill(dtProductor);
            adpFinca.Fill(dtFinca);
        }

        private void dataGridViewFinca_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //
            //  / Especifica el índice de la columna que deseas bloquear
            int columnIndex = 0; // Por ejemplo, la primera columna

            // Verifica si la celda actual es la que deseas bloquear
            if (e.ColumnIndex == columnIndex && e.RowIndex >= 0)
            {
                // Establece la propiedad ReadOnly de la celda en true
                e.CellStyle.BackColor = Color.LightGray; // Opcional: cambia el color de fondo para indicar que la celda está bloqueada
                e.CellStyle.ForeColor = Color.Black; // Opcional: cambia el color del texto para que sea legible
                e.CellStyle.SelectionBackColor = Color.LightGray; // Opcional: cambia el color de fondo cuando la celda está seleccionada
                e.CellStyle.SelectionForeColor = Color.Black; // Opcional: cambia el color del texto cuando la celda está seleccionada
                e.CellStyle.Font = new Font(dataGridViewFinca.Font, FontStyle.Bold); // Opcional: cambia el estilo de fuente para resaltar la celda bloqueada

                dataGridViewFinca.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true; // Establece la celda como solo lectura
            }
            //
        }
    }
}
