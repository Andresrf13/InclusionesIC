using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class DatosReporteAYR
    {
        /*
         * Atributos
         */
        public string Sede;
        public string Curso;
        public string CodigoCurso;
        public string Periodo;
        public string Estudiante;
        public string Carne;
        public string LR;
        public string RN;
        public string Choque;


        private int _IdGroup;
        private List<int> ListID = new List<int>();
        SqlConnection conexion;

        /*
         * Metodo para realizar la conexion a la base de datos 
         */
        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }

        public List<int> SeleccionarIDGrupo()
        {
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand newCmd = new SqlCommand("SP_IdGroup", conexion);
                newCmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = newCmd.ExecuteReader();
                while (reader.Read())
                {
                    var myId = (int)reader["idGrupo"];
                    ListID.Add(myId);

                }
                return ListID;
            }
            catch (Exception e)
            {
                return null;
            }
            finally { conexion.Close(); }
        }
        public DataTable SeleccionarPorGrupo(int _newIdGroup)
        {
            DataTable dtestudiantes = null;
            try
            {
                _IdGroup = _newIdGroup;
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_EstudiantesXGrupo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idGrupo", this._IdGroup);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Estudiantes");
                dtestudiantes = _datos.Tables["Estudiantes"];

            }
            catch (Exception e) { ;}
            finally { conexion.Close(); }
            return dtestudiantes;
        }

    }
}