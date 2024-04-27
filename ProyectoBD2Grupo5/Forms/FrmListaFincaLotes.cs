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
    public partial class FrmListaFincaLotes : Form
    {
        SqlDataAdapter adpLote;
        SqlDataAdapter adpFinca;
        SqlDataAdapter adpCombobox;
        int IdFinca = 0;
        DataTable dtFinca;
        DataTable dtLote;

        SqlConnection conexion;

        public FrmListaFincaLotes()
        {
            InitializeComponent();
        }

        private void AjustarData(DataGridView dtg)
        {
            // dtg.Dock = DockStyle.Fill;

            // Configura las columnas para que ocupen todo el ancho disponible en el DataGridView
            //
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg.AllowUserToAddRows = false;
            dtg.AllowUserToDeleteRows = false;
            dtg.AllowUserToOrderColumns = false;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

               
            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ///
        }
        public FrmListaFincaLotes(SqlConnection cnx)
        {
            InitializeComponent();
            this.conexion = cnx;

            adpLote = new SqlDataAdapter("spSelectLote", conexion);
            adpLote.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpLote.SelectCommand.Parameters.AddWithValue("id", IdFinca);

            adpLote.InsertCommand = new SqlCommand("sPInserttLote", conexion);

            adpLote.InsertCommand.CommandType = CommandType.StoredProcedure;

           // adpLote.InsertCommand.Parameters.Add("@Codigo", SqlDbType.VarChar, 50, "Codigo");
            adpLote.InsertCommand.Parameters.Add("@iDFinca", SqlDbType.Int, 4, "FincaID");
            adpLote.InsertCommand.Parameters.Add("@extension", SqlDbType.Float, 4, "Extension");
            adpLote.InsertCommand.Parameters.Add("@idsuelo", SqlDbType.Int, 4, "TipoSueloID"); //sueloid
            adpLote.InsertCommand.Parameters.Add("@idriego", SqlDbType.Int, 4, "TipoRiegoID");//riegoID
            adpLote.InsertCommand.Parameters.Add("@cosechaCant", SqlDbType.Int, 4, "CantidadCosechas");



            //actualizar
            //update Lote set  Codigo=@Codigo, Extension=@extension, TipoSueloID=@idsuelo, TipoRiegoID=@idriego, CantidadCosechas=@cosechaCant where LoteID=@loteID;

            adpLote.UpdateCommand = new SqlCommand("sPUpdatetLote", conexion);

            adpLote.UpdateCommand.CommandType = CommandType.StoredProcedure;

            adpLote.UpdateCommand.Parameters.Add("@loteID", SqlDbType.Int, 4, "LoteID");
            //adpLote.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.VarChar, 50, "Codigo");
            adpLote.UpdateCommand.Parameters.Add("@extension", SqlDbType.Float, 4, "Extension");
            adpLote.UpdateCommand.Parameters.Add("@idsuelo", SqlDbType.Int, 4, "TipoSueloID"); //sueloid
            adpLote.UpdateCommand.Parameters.Add("@idriego", SqlDbType.Int, 4, "TipoRiegoID");//riegoID
            adpLote.UpdateCommand.Parameters.Add("@cosechaCant", SqlDbType.Int, 4, "CantidadCosechas");


            //fin actualizar

            /*
                 //cuando toque eliminar un registro
            adpProductor.InsertCommand = new SqlCommand("spProductorFincaInsert", conexion);
            adpProductor.InsertCommand.CommandType = CommandType.StoredProcedure;
            adpProductor.InsertCommand.Parameters.Add("@nombre", SqlDbType.Char, 50, "Agricultor");
            adpProductor.InsertCommand.Parameters.Add("@finca", SqlDbType.Char, 50, "NombreFinca");
             */
            /*
             * AQUI IRAN LOS PARAMETROS Y ESTE LLENARA LOS LOTES
             */
            //

            adpFinca = new SqlDataAdapter("spSelectFincalOTE", conexion);
            adpFinca.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpFinca.SelectCommand.Parameters.AddWithValue("@id", 0);



        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (IdFinca != 0)
            {
                FrmLoteCultivo frm = new FrmLoteCultivo(this.conexion, this.adpLote, this.IdFinca, false); //modificar
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No puede Actualizar lotes sin finca", "ERROR", MessageBoxButtons.OK);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (IdFinca != 0)
            {
                FrmLoteCultivo frm = new FrmLoteCultivo(this.conexion, this.adpLote, this.IdFinca, true);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No puede registrar lotes sin finca", "ERROR", MessageBoxButtons.OK);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmListaFincaLotes_Load(object sender, EventArgs e)
        {

            dtFinca = new DataTable();
            dtLote = new DataTable();

            adpLote.SelectCommand.Parameters[0].Value = IdFinca;

            adpLote.Fill(dtLote);
            adpFinca.Fill(dtFinca);
            dataGridView1.DataSource = dtFinca;
            dataGridView1.Columns["ProductorID"].Visible = false;
            AjustarData(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtLote.Clear();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el valor del ID de la fila seleccionada
                IdFinca = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["FincaID"].Value);
                //para llenar el data hijo
                adpLote.SelectCommand.Parameters[0].Value = IdFinca;
                adpLote.Fill(dtLote);
                txtBusqueda.Text = IdFinca.ToString();
                // Hacer algo con el valor del ID


            }
        }
    }
}
