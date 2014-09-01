using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class OfertaAcademicaDatos
    {
        public int numgrupo;
        public int idCurso;
        public int idProfesor;
        public string horario;
        public int Capacidad;
        public int disponible;
        public int sede;


        SqlConnection conexion;
        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }

        public bool Insertar()
        {
            bool valor = false;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("InsertarOferta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numGrupo", this.numgrupo);
                cmd.Parameters.AddWithValue("@codigo", this.idCurso);
                cmd.Parameters.AddWithValue("@profe", this.idProfesor);
                cmd.Parameters.AddWithValue("@horario", this.horario);
                cmd.Parameters.AddWithValue("@capacidad", this.Capacidad);
                cmd.Parameters.AddWithValue("@disponible", this.disponible);
                cmd.Parameters.AddWithValue("@sede", this.sede);
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

        internal DataTable SeleccionarTodos()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                
                SqlCommand cmd = new SqlCommand("SP_listaGrupos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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