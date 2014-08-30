using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;           

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class OfertaAcademica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
            cargarSedes();
        }

        private void cargarSedes()
        {
            drpSede.Items.Clear();
            Sede _sedes = new Sede();
            DataTable _dt_Sedes = _sedes.SeleccionarTodos();
            drpSede.DataSource = _dt_Sedes;
            drpSede.DataValueField = "idSede";
            drpSede.DataTextField = "Nombre";
            drpSede.DataBind();
        }
    }
}