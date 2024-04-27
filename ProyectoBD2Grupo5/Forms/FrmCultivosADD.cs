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
    public partial class FrmCultivosADD : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adpLote;
        SqlDataAdapter adpCultivo;
        DataTable dtCultivos;
        DataTable dtLote;
        int loteID;
        int CultivoID;
        SqlParameter prmID;
        bool sel;
        bool selCultivo;
        public FrmCultivosADD()
        {
            InitializeComponent();
        }

        public FrmCultivosADD(SqlConnection con)
        {

            InitializeComponent();
            prmID = new SqlParameter();
            prmID.ParameterName = "@idLote";
            prmID.Value = 0;

            conexion = con;
            adpLote = new SqlDataAdapter("spSelectLoteCultivo", conexion);
            adpLote.SelectCommand.CommandType = CommandType.StoredProcedure;
            // adpLote.SelectCommand.Parameters.Add()
            //adpLote.SelectCommand.Parameters.AddWithValue("id", IdFinca);

            adpCultivo = new SqlDataAdapter("spSelectCultivo", conexion);
            adpCultivo.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpCultivo.SelectCommand.Parameters.Add(prmID);


            //adpCultivo = new SqlDataAdapter("spInsertarCultivo", conexion);
            adpCultivo.InsertCommand = new SqlCommand("spInsertarCultivo", conexion);
            adpCultivo.InsertCommand.CommandType = CommandType.StoredProcedure;

            adpCultivo.InsertCommand.Parameters.Add("@loteID", SqlDbType.Int, 4, "LoteID");
            adpCultivo.InsertCommand.Parameters.Add("@fecha", SqlDbType.Date, 3, "FechaSiembra");
            adpCultivo.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 4, "Precio");





        }

        private void validarDataGr()
        {


            dataGridViewLote.AllowUserToAddRows = false;
            dataGridViewLote.AllowUserToOrderColumns = false;
            dataGridViewLote.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.ReadOnly = true;

            dataGridViewLote.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // dataGridViewLote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void FrmCultivosADD_Load(object sender, EventArgs e)
        {
            dtLote = new DataTable();
            dtCultivos = new DataTable();
            adpCultivo.Fill(dtCultivos);
            adpLote.Fill(dtLote);
            this.Size = new Size(1040, 550);

            dataGridViewLote.DataSource = dtLote;
            dataGridView1.DataSource = dtCultivos;
            validarDataGr();
            sel = false;
            selCultivo = false;


        }

        private void dataGridViewLote_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dtCultivos.Clear();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {


                // Obtener el valor del ID de la fila seleccionada
                loteID = Convert.ToInt32(dataGridViewLote.Rows[e.RowIndex].Cells["LoteID"].Value);
                //para llenar el data hijo
                prmID.Value = loteID;

                adpCultivo.Fill(dtCultivos);
                sel = true;
                // Hacer algo con el valor del ID


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewLote.SelectedRows.Count > 0 && sel)
            {
                FrmAddCultivo frm = new FrmAddCultivo(conexion, adpCultivo, loteID);
                frm.ShowDialog(this);
                dtCultivos.Clear();
                adpCultivo.Fill(dtCultivos);
            }
            else
            {
                MessageBox.Show("Debes selecionar un Lote", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validar que se selecione un cultivo
            if (dataGridView1.SelectedRows.Count > 0 && selCultivo)
            {
                MessageBox.Show("se pas el valor " + CultivoID);
            }
            else
            {
                MessageBox.Show("Debes selecionar un cultivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //selecionamos el valor del cultivo ocupando el valor del cultivo ID
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {


                // Obtener el valor del ID de la fila seleccionada
                CultivoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CultivoID"].Value);
                selCultivo = true;
                //
                //
                //
                //MessageBox.Show("El id del cultivo que le paso a daniel es el " + CultivoID);

                // Hacer algo con el valor del ID


            }

        }
    }
}
