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
                //cargargvInclusiones();
            }
            
        }

        #region FILTROS ----------------------------------------------------------------------------------------
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
            ListItem _nuevo = new ListItem("-- seleccione un item--", "0");
            drpCursos.Items.Insert(0, _nuevo);
            drpCursos.SelectedIndex = 0;
            cargarGrupos();
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
                //ListItem _grupo = new ListItem("Grupo Nuevo", "28");
                //drpGrupo.Items.Insert(0, _grupo);
            }
            cargargvInclusiones();
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
            cargarCursos();
        }

        protected void drpCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrupos();           
        }
        
        protected void drpSedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCursos();            
        }

        protected void drpGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargargvInclusiones();
        }

        #endregion ----------------------------------------------------------------------------------------

        #region EVENTOS GRIDVIEW -----------------------------------------------------------------------
        //fila por fila del gridview
        protected void gvInclusiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                EstadoInclusionesDatos _aux = new EstadoInclusionesDatos();
                _aux.idBoleta = int.Parse(e.Row.Cells[0].Text);
                DataTable _dtGrupos = _aux.getGrupos();
                DropDownList _drp = (DropDownList)e.Row.FindControl("drpCursoBoleta");
                _drp.DataSource = _dtGrupos;
                _drp.DataValueField = "idGrupo";
                _drp.DataTextField = "Numero";
                _drp.DataBind();
                for (int x = 0; x < _dtGrupos.Rows.Count; x++)
                {
                    if ((bool)_dtGrupos.Rows[x]["Activo"])
                    {
                        _drp.SelectedIndex = x;
                        break;
                    }
                }
                DropDownList _drpEstado = (DropDownList)e.Row.FindControl("drpEstado");
                _drpEstado.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();

            }
        }

        protected void drpCursoBoleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            GridViewRow gv = (GridViewRow)drp.NamingContainer;
            int index = gv.RowIndex;
            DropDownList _drpCursoBoleta = (DropDownList)gvInclusiones.Rows[index].FindControl("drpCursoBoleta");
            int idboleta = int.Parse(gvInclusiones.Rows[index].Cells[0].Text);

            EstadoInclusionesDatos _aux = new EstadoInclusionesDatos();
            _aux.idBoleta = idboleta;
            _aux.grupo = int.Parse(_drpCursoBoleta.SelectedValue);

            _aux.ActualizarActivo();
        }        

        protected void drpEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            GridViewRow gv = (GridViewRow)drp.NamingContainer;
            int index = gv.RowIndex;
            DropDownList _drpEstado = (DropDownList)gvInclusiones.Rows[index].FindControl("drpEstado");
            int idboleta = int.Parse(gvInclusiones.Rows[index].Cells[0].Text);

            EstadoInclusionesDatos _aux = new EstadoInclusionesDatos();
            _aux.idBoleta = idboleta;
            _aux.estado = int.Parse(_drpEstado.SelectedValue);

            _aux.ActualizarEstado();
        }

        protected void gvInclusiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvInclusiones.Rows[index];
                int idBoleta = int.Parse(row.Cells[0].Text);
                CargarDatosVisualizar(idBoleta);

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "verComentario", "openModal();", true);
            }
        }

        private void CargarDatosVisualizar(int idBoleta)
        {
            //aqui falta cargar las varas, ahora hay que setear

            lblNombre.Text = "Nombre: ";
            lblCarnet.Text = "Carné: ";
            lblCorreo.Text = "Correo: ";
            lbltelefono.Text = "Telefono: ";
            lblCelular.Text = "Celular: ";
            lbldia.Text = "Día: ";
            lblhora.Text = "Hora: ";
            lblcarrera.Text = "Carrera: ";
            lblplan.Text = "Plan: ";
            lblrn.Text = "RN: ";
            lbllr.Text = "LR: ";
            lblcomentario.Text = "Comentario: ";

        }

        #endregion

        

        


    }
}