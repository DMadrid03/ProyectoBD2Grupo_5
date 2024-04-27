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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoBD2Grupo5.Forms
{
    public partial class FrmAddCultivo : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adpCultivo;
        DataTable dtCultivo;
        int loteID;
        public FrmAddCultivo()
        {
            InitializeComponent();
        }

        public FrmAddCultivo(SqlConnection cnx, SqlDataAdapter adpCultivo, int loteId)
        {

            InitializeComponent();
            this.conexion = cnx;
            this.adpCultivo = adpCultivo;
            loteID = loteId;
        }

        private void FrmAddCultivo_Load(object sender, EventArgs e)
        {
            dtCultivo = new DataTable();

            adpCultivo.Fill(dtCultivo);
        }

        public bool EsNumero(System.Windows.Forms.TextBox textBox)
        {
            return int.TryParse(textBox.Text, out _);
        }
        public bool TodosNumeros(List<System.Windows.Forms.TextBox> textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (!EsNumero(textBox))
                {
                    return false;
                }
            }
            return true;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                DataRow dr = dtCultivo.NewRow();
                //DateTime dt = (DateTime)dateTimePicker1.Value.;
                // adpCultivo.InsertCommand.Parameters.Add("@fecha", SqlDbType.Date, 3, dt);
                // adpCultivo.InsertCommand.Parameters.AddWithValue("@fecha", dt);
                //  adpCultivo.InsertCommand.Parameters.Add("@fecha", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                
                
                if (EsNumero(textBox1))
                {
                    dr["Precio"] = textBox1.Text;
                    dr["LoteID"] = loteID;
                    dr["FechaSiembra"] = dateTimePicker1.Value.Date;
                    dtCultivo.Rows.Add(dr);
                    adpCultivo.Update(dtCultivo);
                    MessageBox.Show("La tarea fue realizada  exitosamente", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



                    dtCultivo.Clear();
                    adpCultivo.Fill(dtCultivo);

                }
                else
                {
                    MessageBox.Show("La entrada debe ser numerica");
                }
                
                this.Close();
                //   string d = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                // MessageBox.Show("" + dt);


            }
            catch (Exception ex)
            {

                MessageBox.Show("La tarea fallo" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
