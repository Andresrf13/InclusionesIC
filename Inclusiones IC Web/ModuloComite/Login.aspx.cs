﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            string _username = username.Value;
            string _password = password.Value;

            Response.Redirect("~/ModuloComite/menuComite.aspx");
        }
    }
}