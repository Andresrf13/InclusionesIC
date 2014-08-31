using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class PeriodoDatos
    {
        SqlConnection conexion;
        public DateTime FechaIniConsulta;
        public DateTime FechaFinConsulta;
        public DateTime fechaIniInclusion;
        public DateTime fechaFinInclusion;
        public string periodo;

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
                string queryString = "select * from Semestre";
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

        public bool Insertar()
        {
            bool valor = false;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarSemestre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@fechaFinInclusion", String.Format("{0:yyyy-MM-dd}", this.fechaFinInclusion));
                cmd.Parameters.AddWithValue("@fechaIniInclusion", String.Format("{0:yyyy-MM-dd}", this.fechaIniInclusion));
                cmd.Parameters.AddWithValue("@FechaIniConsulta", String.Format("{0:yyyy-MM-dd}", this.FechaIniConsulta));
                cmd.Parameters.AddWithValue("@FechaFinConsulta", String.Format("{0:yyyy-MM-dd}", this.FechaFinConsulta));
                cmd.Parameters.AddWithValue("@periodo", String.Format("{0:yyyy-MM-dd}", this.periodo));                
                cmd.ExecuteNonQuery();
                valor = true;
            }
            catch (Exception e)
            {
                valor = false;
            }
            finally
            {
                conexion.Close();
            }
            return valor;
        }
    }
}