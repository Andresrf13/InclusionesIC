using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inclusiones_IC_Web.ModuloEstudiante
{
    public partial class BoletaInclusion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbnoRN_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnoRN.Checked)
            {
                divRN.Visible = false;
            }
            else if (rbsiRN.Checked)
            {
                divRN.Visible = true;
            }
        }

    }
}