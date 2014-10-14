using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class Cursos
    {
        SqlConnection conexion;
        public int id;
        public string nombre;
        public string Carnet;
        public string Estado;
        public string Grupo;
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
                string queryString = "select * from Curso";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, conexion);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Cursos");
                dtprofesores = _datos.Tables["Cursos"];
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

        public void getNombre()
        {
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_NombreCurso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@curso", this.id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                    
                    this.nombre = Convert.ToString(reader["Nombre"]);                                       
                }
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataTable SeleccionarCursoxPlan(int idCarrera, int idplan)
        {
            DataTable dtcarrera = null;
            try
            {
                Conectar();
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_CursoIDNombre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcarrera", idCarrera);
                cmd.Parameters.AddWithValue("@idPlan", idplan);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Profesores");
                dtcarrera = _datos.Tables["Profesores"];
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
            return dtcarrera;
        }

        public DataTable getCursoxCarnet()
        {
            DataTable dtcursos = null;
            try
            {
                Conectar();
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_BoletaCurso", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carnet", this.Carnet);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Cursos");
                dtcursos = _datos.Tables["Cursos"];
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
            return dtcursos;
        }

        public DataTable ResultadoVisualizar()
        {
            DataTable dtcursos = null;
            try
            {
                Conectar();
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_EstadoActivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBoleta", this.id);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.Estado = Convert.ToString(reader["Estado"]);
                    this.Grupo = Convert.ToString(reader["Numero"]); 
                }
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
            return dtcursos;
        }
    }
}