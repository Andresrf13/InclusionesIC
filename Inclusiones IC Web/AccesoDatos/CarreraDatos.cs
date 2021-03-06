﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class CarreraDatos
    {
        SqlConnection conexion;
        public int id;
        public string nombre;
        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }

        public DataTable SeleccionarTodos()
        {
            DataTable dtcarrera = null;
            try
            {
                Conectar();
                conexion.Open();

                SqlCommand cmd = new SqlCommand("select * from carrera", conexion);
                cmd.CommandType = CommandType.Text;
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
    }
}