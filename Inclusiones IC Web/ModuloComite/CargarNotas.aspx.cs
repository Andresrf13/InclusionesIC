using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  Inclusiones_IC_Web.AccesoDatos;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class CargarNotas : System.Web.UI.Page
    {

        private DataTable _dtNotas = new DataTable();
        private char separador = ';';
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("~/ModuloComite/Login.aspx");
            //}
        }

        //controla que tipo de archivos se pueden subir para parsear
        bool ChecarExtension(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".csv":
                    return true;
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }

        protected void btnSubirArchivo_OnClick(object sender, EventArgs e)
        {
            
            try
            {
                if (btnGetArchivo.HasFile)
                {
                    if (ChecarExtension(btnGetArchivo.FileName))
                    {
                        btnGetArchivo.SaveAs(MapPath("Archivos/" + btnGetArchivo.FileName));


                        //Label1.Text = btnGetArchivo.FileName + " cargado exitosamente";

                        lblOculto.Text = MapPath("Archivos/" + btnGetArchivo.FileName);
                    }
                }
                else
                {
                    //Label1.Text = "Error al subir el archivo o no es el tipo .CSV";
                }

                CargarDatos(lblOculto.Text);
            }
            catch
            {
                Response.Write("Ocurrió un error debe cargar antes el archivo");
            }

        }

        private void CargarDatos(string strm)
        {
            StreamReader lector = new StreamReader(strm);
            try
            {
                DataTable tabla = null;
                
                String fila = String.Empty;
                Int32 cantidad = 0;
                do
                {
                    fila = lector.ReadLine();
                    if (fila == null)
                    {
                        break;
                    }
                    if (0 == cantidad++)
                    {
                        this.CrearTabla(fila); //ESTA SE ENCARGA DE CREAR LOS ENCABEZADOS
                    }
                    else
                    {
                        if (!this.AgregarFila(fila)); //SE ENCARGA DE LEER LAS FILAS                         
                    }
                } while (true);

                lector.Close();
                gvNotas.DataSource = _dtNotas;
                gvNotas.DataBind();
            }
            catch (Exception e)
            {
                lector.Close();
                Response.Write("Ocurrió un error durante la lectura del archivo");
            }

        }

        private bool AgregarFila(string fila)
        {
            bool resul = false;
            try
            {
                CargarNotasDatos _nuevo = new CargarNotasDatos();
                string[] valores = fila.Split(separador);
                string periodo = valores[0].ToString();
                periodo += valores[1].ToString();
                periodo += valores[2].ToString();
                _nuevo.periodo = periodo;
                _nuevo.curso = valores[4];
                _nuevo.numgrupo = Convert.ToInt32(valores[5].ToString());
                _nuevo.carnet = valores[6];
                _nuevo.nota = float.Parse(valores[7].ToString());
                _nuevo.estado = valores[8];

                if (_nuevo.InsertarNota() == 1)
                {
                    DataRow row = _dtNotas.NewRow();
                    row["Periodo"] = periodo;
                    row["Sede"] = valores[3];
                    row["Codigo Curso"] = valores[4];
                    row["Grupo"] = valores[5];
                    row["Carné"] = valores[6];
                    row["Nota Obtenida"] = valores[7];
                    row["Estado"] = valores[8];
                    _dtNotas.Rows.Add(row);
                    resul = true;
                }               
            }
// ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                resul = false;
                Response.Write("Error en el formato de archivo");
            }
            return resul;

        }

        private void CrearTabla(string fila)
        {
            _dtNotas.Rows.Clear();
            _dtNotas.Columns.Add("Periodo");
            _dtNotas.Columns.Add("Sede");
            _dtNotas.Columns.Add("Codigo Curso");
            _dtNotas.Columns.Add("Grupo");
            _dtNotas.Columns.Add("Carné");
            _dtNotas.Columns.Add("Nota Obtenida");
            _dtNotas.Columns.Add("Estado");
        }
    }
}