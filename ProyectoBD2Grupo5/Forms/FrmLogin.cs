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
    public partial class FrmLogin : Form
    {
        private SqlConnection conexion;
        private bool conectado;

        public SqlConnection getConexion
        {
            get { return this.conexion; }
        }

        public bool getConectado
        {
            get { return this.conectado; }
        }

        public FrmLogin()
        {
            InitializeComponent();
            conexion = new SqlConnection();
            
        }

        private bool validarBlancos()
        {
            errorProvider1.Clear();
            bool hayError = false;

            if(txtUsuario.Text.Length == 0 )
            {
                hayError = true;
                errorProvider1.SetError(txtUsuario, "No pueden haber valores en blanco");
                return hayError;
            }
            if (txtContrasenia.Text.Length == 0)
            {
                hayError = true;
                errorProvider1.SetError(txtContrasenia, "No pueden haber valores en blanco");
                return hayError;
            }
            if (txtBaseDeDatos.Text.Length == 0)
            {
                hayError = true;
                errorProvider1.SetError(txtBaseDeDatos, "No pueden haber valores en blanco");
                return hayError;
            }
            if (txtServidor.Text.Length == 0)
            {
                hayError = true;
                errorProvider1.SetError(txtServidor, "No pueden haber valores en blanco");
                return hayError;
            }


            return hayError;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarBlancos())
                {
                    return;
                }

                String url = "Server=" + txtServidor.Text + "; Database=" + txtBaseDeDatos.Text
                             + "; UID=" + txtUsuario.Text + "; PWD=" + txtContrasenia.Text + ";";

                conexion.ConnectionString = url;
                conexion.Open();
                conectado = true;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
    }
}
