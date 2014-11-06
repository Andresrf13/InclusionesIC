using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;


namespace InclusionesIC_Proyecto.ModuloEstudiante
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PeriodoDatos _activar = new PeriodoDatos();
            DataTable _dtfechas = _activar.PeriodoActualFechaInclusion();
            if (_dtfechas.Rows.Count > 0)
            {
                DateTime inicio = DateTime.Parse(_dtfechas.Rows[0][1].ToString());
                DateTime final = DateTime.Parse(_dtfechas.Rows[0][2].ToString());

                if (inicio <= DateTime.Now.Date && DateTime.Now.Date <= final)
                {
                    TiempoPeriodo.Visible = false;   
                    ibtnSolicitar.Enabled = true;                                 
                }
                else
                {
                    TiempoPeriodo.Visible = true;
                    ibtnSolicitar.Enabled = false;
                }

                 inicio = DateTime.Parse(_dtfechas.Rows[0][4].ToString());
                 final = DateTime.Parse(_dtfechas.Rows[0][5].ToString());
                if (inicio <= DateTime.Now.Date && DateTime.Now.Date <= final)
                {
                    
                    
                    TiempoBusqueda.Visible = false;
                    ibtnBuscar.Enabled = true;
                }
                else
                {
                    TiempoBusqueda.Visible = true;                   
                    ibtnBuscar.Enabled = false;

                }
                
            }

        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ModuloEstudiante/BoletaInclusion.aspx");
        }

        protected void ibtnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ModuloEstudiante/VisualizarBoleta.aspx");
        }
    }
}