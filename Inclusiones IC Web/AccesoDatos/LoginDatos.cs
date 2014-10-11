using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class LoginDatos
    {
        SqlConnection conexion;
        public string nonnbre;
        public string contrasena;

        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }

        public bool login()
        {
            bool valor = false;
            DataTable dtcarrera = null;
            try
            {
                Conectar();
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_ComprobarUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", this.nonnbre);
                cmd.Parameters.AddWithValue("@Contrasena", this.contrasena);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Login");
                dtcarrera = _datos.Tables["Login"];
                if (dtcarrera.Rows.Count > 0)
                {
                    valor = true;
                }
                else
                {
                    valor = false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
            return valor;
        }
    }
}