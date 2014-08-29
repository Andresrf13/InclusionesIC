using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class menuComite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// boton ajustes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAjustes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloComite/PeriodoyFechas.aspx");
        }

        protected void lbtnadminProfes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloComite/OfertaAcademica.aspx");
        }
    }
}