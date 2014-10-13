﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class EstadoInclusionesDatos
    {
        SqlConnection conexion;
        public int sede = 0;
        public int curso = 0;
        public int grupo = 0;
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
                SqlCommand cmd = new SqlCommand("SP_inclusionSolicitadas", conexion);
                cmd.Parameters.AddWithValue("@sede", this.sede);
                cmd.Parameters.AddWithValue("@curso", this.curso);
                cmd.Parameters.AddWithValue("@grupo", this.grupo);
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