using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ProyectoBD2Grupo5.ReportsData
{

    public partial class Reporte_Total_Finca : Form
    {
        SqlConnection cnx;
        SqlDataAdapter adpReporte;
        DataTable dtReporte;
        DateTime Fecha;
        public Reporte_Total_Finca()
        {
            InitializeComponent();

        }
        public Reporte_Total_Finca(DateTime valor, SqlConnection conexion)
        {
            InitializeComponent();
            Fecha = valor;
            cnx = conexion;
            adpReporte = new SqlDataAdapter("spReporte1", cnx);
            adpReporte.SelectCommand.CommandType = CommandType.StoredProcedure;
            adpReporte.SelectCommand.Parameters.AddWithValue("@Fecha", Fecha);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Reporte_Total_Finca_Load(object sender, EventArgs e)
        {
            dtReporte = new DataTable();
            adpReporte.Fill(dtReporte);
            dataGridView1.DataSource = dtReporte;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
           // dataGridView1.Rows[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Alterna entre rojo y verde para el color de fondo de las filas
            if (e.RowIndex % 2 == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }

        }
    }
}
