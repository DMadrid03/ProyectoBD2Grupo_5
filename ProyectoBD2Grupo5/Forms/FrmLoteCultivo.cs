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
    public partial class FrmLoteCultivo : Form
    {
        SqlDataAdapter adpTipoRiego;
        SqlDataAdapter adpTipoSuelo;
        DataTable dtRiego;
        DataTable dtSuelo;
        SqlDataAdapter adplote;
        DataTable dtLote;
        SqlConnection conexion;
        bool status;
        int fincaID;
        int loteID;
        int indexrows;
        string sql = "select * from dbo.TipoSuelo()";
        string sql2 = "select * from dbo.TipoRiego()";
        public FrmLoteCultivo()
        {
            InitializeComponent();
        }

        public FrmLoteCultivo(SqlConnection cnx, SqlDataAdapter adplote, int IdFinca, bool estado)
        {
            InitializeComponent();
            conexion = cnx;
            this.adplote = adplote;
            fincaID = IdFinca;

            //adapter combobox
            adpTipoSuelo = new SqlDataAdapter(sql, conexion);
            //adpTipoSuelo.SelectCommand.CommandType = CommandType.Text;
            adpTipoRiego = new SqlDataAdapter(sql2, conexion);
            status = estado;
        }

        private void validarDataGr(bool estado)
        {
            
            if (estado == true)
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToOrderColumns = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            }
            else
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToOrderColumns = false;
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns["TipoSuelo"].ReadOnly = true;
                dataGridView1.Columns["FincaID"].ReadOnly = true;
                dataGridView1.Columns["Codigo"].ReadOnly = true;
                dataGridView1.Columns["TipoRiego"].ReadOnly = true;

                dataGridView1.Columns["TipoSuelo"].DefaultCellStyle.BackColor = Color.LightGray; // CellStyle.BackColor = Color.LightGray;

                dataGridView1.Columns["FincaID"].DefaultCellStyle.BackColor = Color.LightGray; // CellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns["Codigo"].DefaultCellStyle.BackColor = Color.LightGray; // CellStyle.BackColor = Color.LightGray;
                dataGridView1.Columns["TipoRiego"].DefaultCellStyle.BackColor = Color.LightGray; // CellStyle.BackColor = Color.LightGray;

                //dataGridView1.columns["TipoSuelo"];
                cmbTsuelo.Enabled = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            


        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void cmdAgregarLote_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cmdAgregarLote_Click_1(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLoteCultivo_Load(object sender, EventArgs e)
        {
            dtLote = new DataTable();
            adplote.Fill(dtLote);

            dataGridView1.DataSource = dtLote;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["LoteID"].Visible = false;
            dataGridView1.Columns["TipoSueloID"].Visible = false;
            dataGridView1.Columns["TipoRiegoID"].Visible = false;
            validarDataGr(status);
            dtSuelo = new DataTable();
            adpTipoSuelo.Fill(dtSuelo);
            cmbTsuelo.DataSource = dtSuelo;
            cmbTsuelo.DisplayMember = "Nombre";
            cmbTsuelo.ValueMember = "TipoSueloID";
            cmbTsuelo.SelectedIndex = -1;

            dtRiego = new DataTable();
            adpTipoRiego.Fill(dtRiego);
            cmbTriego.DataSource = dtRiego;
            cmbTriego.DisplayMember = "Nombre";
            cmbTriego.ValueMember = "TipoRiegoID";
            cmbTriego.SelectedIndex = -1;
            textCodigo.Enabled = false;
        }

        private bool CamposNoVacios(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show($"{textBox.Name} no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        private void LimpiarCampos(params Control[] controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = ""; // Limpiar el texto del TextBox
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1; // Establecer el índice seleccionado en -1 para el ComboBox
                }
            }
        }


        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //dtLote = new DataTable();
                //adplote.Fill(dtLote);
                if (status == true) //modo agregar
                {

                    if (CamposNoVacios( textExtension, textCantidadSembrada))
                    {
                        //dtLote = new DataTable();
                        //adplote.Fill(dtLote);
                        DataRow dr = dtLote.NewRow();
                        dr["FincaID"] = fincaID;
                        //dr["Codigo"] = textCodigo.Text;
                        dr["Extension"] = textExtension.Text;
                        dr["TipoSueloID"] = cmbTsuelo.SelectedValue;
                        dr["TipoRiegoID"] = cmbTriego.SelectedValue;
                        dr["CantidadCosechas"] = textCantidadSembrada.Text;
                        //dtMiDataTable.Rows.Add(newRow);
                        dtLote.Rows.Add(dr);

                        MessageBox.Show("La tarea fue realizada  exitosamente", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarCampos(cmbTriego, cmbTsuelo, textExtension, textCantidadSembrada);
                        adplote.Update(dtLote);

                        dtLote.Clear();
                        adplote.Fill(dtLote);
                    }

                }
                else
                {

                    cmbTsuelo.Enabled = false;
                    // Obtener la fila seleccionada en el DataGridView
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    // Obtener el objeto de datos subyacente (DataRowView) de la fila seleccionada
                    DataRowView filaDatos = filaSeleccionada.DataBoundItem as DataRowView;

                    // Obtener el índice de la fila en el DataTable
                    int indiceFila = dtLote.Rows.IndexOf(filaDatos.Row);

                    // Modificar los datos de la fila en el DataTable
                    //dtLote.Rows[indiceFila]["Codigo"] = textCodigo.Text;
                    dtLote.Rows[indiceFila]["Extension"] = textExtension.Text;
                    dtLote.Rows[indiceFila]["CantidadCosechas"] = textCantidadSembrada.Text;
                    dtLote.Rows[indiceFila]["TipoRiegoID"] = cmbTriego.SelectedValue;

                    //   dtLote.Rows[indiceFila]["NombreColumna2"] = nuevoValor2;
                    // Modificar las columnas necesarias con sus nuevos valores

                    // Luego de modificar los datos, puedes reflejar los cambios en el DataGridView si es necesario
                    dataGridView1.DataSource = dtLote;
                    MessageBox.Show("La tarea fue realizada  exitosamente", "Datos Guardados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message, "ERROR", MessageBoxButtons.OK);
            }

            adplote.Update(dtLote);
            dtLote.Clear();
             adplote.Fill(dtLote);
            dataGridView1.DataSource = dtLote;
        }

        private void textExtension_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cmbTriego_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (status != true)
            {
                if (e.RowIndex >= 0)
                {
                    indexrows = e.RowIndex;
                    //  MessageBox.Show("" + indexrows);
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    // Obtener los valores de las celdas y asignarlos a los controles
                    textCodigo.Text = row.Cells["Codigo"].Value.ToString();
                    textExtension.Text = row.Cells["Extension"].Value.ToString();
                    textCantidadSembrada.Text = row.Cells["CantidadCosechas"].Value.ToString();

                    cmbTriego.SelectedIndex = (int)row.Cells["TipoRiegoID"].Value - 1;

                    cmbTsuelo.SelectedIndex = (int)row.Cells["TipoSueloID"].Value - 1;
                    loteID = (int)row.Cells["LoteID"].Value;

                }

            }
            
            //
        }
    }
}
