using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;

namespace Inclusiones_IC_Web.ModuloEstudiante
{
    public partial class VisualizarBoleta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ModuloEstudiante/Inicio.aspx");
        }

        protected void txtCarnet_TextChanged(object sender, EventArgs e)
        {
            Cursos _aux = new Cursos();
            _aux.Carnet = txtCarnet.Text.Trim();
            DataTable _dtCursos = _aux.getCursoxCarnet();
            drpCursos.DataSource = _dtCursos;
            drpCursos.DataValueField = "idBoleta";
            drpCursos.DataTextField = "Curso";
            drpCursos.DataBind();

            for (int y = 0; y < _dtCursos.Rows.Count; y++ )
            {
                string curso = _dtCursos.Rows[y]["Curso"].ToString();
                if (curso.Equals("Grupo Nuevo"))
                {
                    ListItem _borrar = new ListItem("Grupo Nuevo", _dtCursos.Rows[y]["idBoleta"].ToString());
                    drpCursos.Items.Remove(_borrar);
                }
                
            }
                
            cargarResultados();
        }

        protected void drpCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarResultados();
        }

        private void cargarResultados()
        {
            Cursos _aux = new Cursos();
            _aux.id = int.Parse(drpCursos.SelectedValue);
            _aux.ResultadoVisualizar();

            if (_aux.Estado == "0")
            {
                txtEstado.Text = "Pendiente";
            }
            else if (_aux.Estado == "1")
            {
                txtEstado.Text = "Aprobado";
            }
            else if (_aux.Estado == "2")
            {
                txtEstado.Text = "Rechazado";
            }

            txtgrupo.Text = _aux.Grupo;

            if (_aux.Estado == "2")
            {
                txtgrupo.Text = "N/A";
            }
        }

        

    }
}