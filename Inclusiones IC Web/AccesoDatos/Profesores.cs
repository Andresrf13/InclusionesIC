using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class Profesores
    {
        SqlConnection conexion;
        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }

        public DataTable SeleccionarTodos()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                string queryString = "select * from Profesor";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, conexion);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Profesores");
                dtprofesores = _datos.Tables["Profesores"];
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
            return dtprofesores;
        }
    }
}