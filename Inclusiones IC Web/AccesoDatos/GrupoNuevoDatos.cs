using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class GrupoNuevoDatos
    {
        SqlConnection conexion;
        public int id;
        public string nombre;
        public int idGrupo;
        public int idCurso;
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
                SqlCommand cmd = new SqlCommand("SP_GrupoCero", conexion);
                cmd.Parameters.AddWithValue("@curso", this.id);
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

        public bool ActualizarGrupo()
        {
            bool valor = false;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_AsignarGrupo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@grupo", this.idGrupo);
                cmd.Parameters.AddWithValue("@curso", this.idCurso);
                
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