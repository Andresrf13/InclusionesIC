﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inclusiones_IC_Web.AccesoDatos
{
    public class InclusionDatos
    {
        SqlConnection conexion;
        public int idBoleta;
        public int grupo;
        public int idPersona;
        public int idEstudiante;

        public string nombre;
        public string celular;
        public string carnet;
        public int telefono;
        public string correo;
        public string hora;
        public string minuto;
        public int dia;
        public int rn;
        public bool lr;
        public string connentario;
        public int sede;



        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }

        public int Insertar()
        {
            int valor = -1;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ActEstIngBoleta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", this.nombre);
                cmd.Parameters.AddWithValue("@Celular", this.celular);
                cmd.Parameters.AddWithValue("@Carnet", this.carnet);
                cmd.Parameters.AddWithValue("@Telefono", this.telefono);
                cmd.Parameters.AddWithValue("@Correo", this.correo);
                cmd.Parameters.AddWithValue("@Hora", this.hora);
                cmd.Parameters.AddWithValue("@Minuto", this.minuto);
                cmd.Parameters.AddWithValue("@Dia", this.dia);
                cmd.Parameters.AddWithValue("@idRN", this.rn);
                cmd.Parameters.AddWithValue("@LR", this.lr);
                cmd.Parameters.AddWithValue("@comentario", this.connentario);
                cmd.Parameters.AddWithValue("@Sede", this.sede);
                cmd.Parameters.AddWithValue("@idpersona", this.idPersona);
                cmd.Parameters.AddWithValue("@idEstudiante", this.idEstudiante);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    valor = (int)(reader["idBoleta"]);
                }                
            }
            catch (Exception e)
            {
                valor = -1;
            }
            finally
            {
                conexion.Close();
            }
            return valor;
        } 

        internal bool InsertarGrupo(int idInsertado, int p1, int x, bool p2, int activo)
        {
            bool valor = false;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_IngresarGrupoXBoleta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Boleta", idInsertado);
                cmd.Parameters.AddWithValue("@Grupo", p1);
                cmd.Parameters.AddWithValue("@Prioridad", x);
                cmd.Parameters.AddWithValue("@Choque", p2);
                cmd.Parameters.AddWithValue("@activo", activo);             
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

        internal DataTable getBoleta()
        {
            
            DataTable dtcarrera = null;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_BoletaCompleta", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@boleta", this.idBoleta);
                cmd.Parameters.AddWithValue("@grupo", this.grupo);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Boleta");
                dtcarrera = _datos.Tables["Boleta"];                                
            }
            catch (Exception e)
            {
                return dtcarrera;
            }
            finally
            {
                conexion.Close();
            }
            return dtcarrera;
        }

        internal void getInfoEstudiante()
        {

            DataTable dtcarrera = null;
            try
            {
                Conectar();
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ExisteEstudiante", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carnetEstudiante", this.carnet);                               

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.telefono = (int)(reader["Telefono"]);
                    this.correo = Convert.ToString(reader["Correo"]);
                    this.nombre = Convert.ToString(reader["Nombre"]);
                    this.celular = Convert.ToString(reader["Celular"]);
                    this.idPersona = (int)(reader["Persona"]);
                    this.idEstudiante = (int)(reader["Estudiante"]);
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
    }
}