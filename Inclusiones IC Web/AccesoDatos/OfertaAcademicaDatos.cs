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
                SqlCommand cmd = new SqlCommand("InsertarOferta(@numGrupo, @curso, @profe, @horario, @capacidad, @disponible )", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numGrupo", this.numgrupo);
                cmd.Parameters.AddWithValue("@curso", this.idCurso);
                cmd.Parameters.AddWithValue("@profe", this.idProfesor);
                cmd.Parameters.AddWithValue("@horario", this.horario);
                cmd.Parameters.AddWithValue("@capacidad", this.Capacidad);
                cmd.Parameters.AddWithValue("@disponible", this.disponible);
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