using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inclusiones_IC_Web.AccesoDatos;

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
            LoginDatos _aux = new LoginDatos();
            _aux.nonnbre = _username;
            _aux.contrasena = _password;
            if (_aux.login())
            {
                Session["Usuario"] = true;
                Response.Redirect("~/ModuloComite/menuComite.aspx");
            }
            else
            {
                txtTitulo.Text = "Error";
                txtCuerpo.Text = "Datos incorrectos, no aparece registrado";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            
        }
    }
}