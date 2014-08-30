using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class Sede
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
            DataTable dtsedes = null;
            try
            {
                Conectar();
                conexion.Open();
                string queryString = "select * from Sede";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, conexion);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Inclusiones");
                dtsedes = _datos.Tables["Inclusiones"];
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
            return dtsedes;
        }
    }
}