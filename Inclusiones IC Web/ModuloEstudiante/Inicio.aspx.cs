using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InclusionesIC_Proyecto.ModuloEstudiante
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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