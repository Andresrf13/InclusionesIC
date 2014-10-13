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
    public partial class EstadoInclusiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/ModuloComite/Login.aspx");
            }
            if (!IsPostBack)
            {
                cargarSedes();
                cargarCursos();
            }
            cargargvInclusiones();
        }

        private void cargargvInclusiones()
        {
            EstadoInclusionesDatos _aux = new EstadoInclusionesDatos();
            _aux.sede = int.Parse(drpSedes.SelectedValue);
            _aux.curso = int.Parse(drpCursos.SelectedValue);
            _aux.grupo = int.Parse(drpGrupo.SelectedValue);
            DataTable _dtInclusiones = _aux.SeleccionarTodos();
            gvInclusiones.DataSource = _dtInclusiones;
            gvInclusiones.DataBind();
        }

        private void cargarCursos()
        {
            drpCursos.Items.Clear();
            Cursos _aux = new Cursos();
            DataTable _dtCursos = _aux.SeleccionarTodos();            
            drpCursos.DataSource = _dtCursos;
            drpCursos.DataValueField = "idCurso";
            drpCursos.DataTextField = "Nombre";
            drpCursos.DataBind();
            cargarGrupos();
            ListItem _nuevo = new ListItem("-- seleccione un item--", "0");
            drpCursos.Items.Insert(0, _nuevo);
            drpCursos.SelectedIndex = 0;
        }

        private void cargarGrupos()
        {
            if (drpCursos.Items.Count > 0)
            {
                drpGrupo.Items.Clear();
                GruposDatos _aux = new GruposDatos();
                _aux.id = Convert.ToInt32(drpCursos.SelectedValue);
                DataTable _dtGrupos = _aux.SeleccionarTodos();
                drpGrupo.DataSource = _dtGrupos;
                drpGrupo.DataValueField = "idGrupo";
                drpGrupo.DataTextField = "Numero";
                drpGrupo.DataBind();
                ListItem _nuevo = new ListItem("-- seleccione un item--", "0");
                drpGrupo.Items.Insert(0, _nuevo);
            }
        }

        private void cargarSedes()
        {
            drpSedes.Items.Clear();
            Sede _aux = new Sede();
            DataTable _dtSedes = _aux.SeleccionarTodos();
            drpSedes.DataSource = _dtSedes;
            drpSedes.DataValueField = "idSede";
            drpSedes.DataTextField = "Nombre";
            drpSedes.DataBind();
            ListItem _nuevo = new ListItem("-- seleccione un item--", "0");
            drpSedes.Items.Insert(0, _nuevo);
        }

        protected void drpCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrupos();
        }

        //fila por fila del gridview
        protected void gvInclusiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                //GruposDatos _aux = new GruposDatos();
            }
        }


    }
}