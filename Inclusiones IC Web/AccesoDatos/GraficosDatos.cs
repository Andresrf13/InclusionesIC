using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class GraficosDatos
    {
        SqlConnection conexion;
        public string periodo;
        public int iperiodo;
        public string carnet;
        public int curso;

        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }


        public DataTable GetGrafico1()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GraficoEstadoNotas", conexion);
                cmd.Parameters.AddWithValue("@idPeriodo", this.periodo);                
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Grupos");
                dtprofesores = _datos.Tables["Grupos"];
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

        public DataTable GetGrafico2()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GraficoEstadoNotasXCurso", conexion);
                cmd.Parameters.AddWithValue("@idPeriodo", this.iperiodo);
                cmd.Parameters.AddWithValue("@idcurso", this.curso);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Grupos");
                dtprofesores = _datos.Tables["Grupos"];
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

        public DataTable GetGrafico3()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GraficoEstadoNotasXEstudiante", conexion);
                cmd.Parameters.AddWithValue("@idPeriodo", this.iperiodo);
                cmd.Parameters.AddWithValue("@carnet", this.carnet);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Grupos");
                dtprofesores = _datos.Tables["Grupos"];
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

        public DataTable GetGrafico4()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_GraficoEstadoPeriodo", conexion);                
                cmd.Parameters.AddWithValue("@carnet", this.carnet);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Grupos");
                dtprofesores = _datos.Tables["Grupos"];
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