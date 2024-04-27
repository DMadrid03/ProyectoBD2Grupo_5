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
    public partial class FrmAgregarProductorFinca : Form
    {
        SqlConnection conexion;
        SqlDataAdapter adpProductorFinca;
        DataTable dtProductorFinca;
        int indiceProductor;
        public FrmAgregarProductorFinca()
        {
            InitializeComponent();
        }

        public FrmAgregarProductorFinca(SqlConnection cnx)
        {
            InitializeComponent();
            conexion = cnx;
        }
        public FrmAgregarProductorFinca(SqlConnection cnx, SqlDataAdapter adpProductor, int indice)
        {
            InitializeComponent();
            conexion = cnx;
            adpProductorFinca = adpProductor;
            indiceProductor = indice;
            adpProductor.SelectCommand.Parameters[0].Value = indice;

            adpProductor.UpdateCommand.Parameters[0].Value = indice;

        }
        private void FrmAgregarProductorFinca_Load(object sender, EventArgs e)
        {
            try
            {
                dtProductorFinca = new DataTable();
                adpProductorFinca.Fill(dtProductorFinca);

                if (dtProductorFinca.Rows.Count == 0)
                {
                    dtProductorFinca.Rows.Add();
                }
                else
                {
                    textProductorNombre.Text = dtProductorFinca.Rows[0]["Agricultor"].ToString();
                    textFincaNombre.Text = dtProductorFinca.Rows[0]["NombreFinca"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                dtProductorFinca.Rows[0]["Agricultor"] = textProductorNombre.Text;
                dtProductorFinca.Rows[0]["NombreFinca"] = textFincaNombre.Text;
                adpProductorFinca.Update(dtProductorFinca);
                adpProductorFinca.SelectCommand.Parameters[0].Value = 0;
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
