﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InclusionesIC_Proyecto
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciaSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloComite/Login.aspx");
        }
    }
}