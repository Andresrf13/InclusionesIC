using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class CargarNotasDatos
    {
        public string periodo;
        public int numgrupo;
        public string curso;
        public string carnet;
        public float nota;
        public string estado;

        SqlConnection conexion;
        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }


        public int InsertarNota()
        {
            int valor = 2;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_InsertarNotas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@periodo", this.periodo);
                cmd.Parameters.AddWithValue("@numgrupo", this.numgrupo);
                cmd.Parameters.AddWithValue("@curso", this.curso);
                cmd.Parameters.AddWithValue("@carnet", this.carnet);
                cmd.Parameters.AddWithValue("@nota", this.nota);
                cmd.Parameters.AddWithValue("@estado", this.estado);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    valor = int.Parse(reader[0].ToString());
                }
            }
            catch (Exception e)
            {
                valor = 2;
            }
            finally
            {
                conexion.Close();
            }
            return valor;
        }
    }
}