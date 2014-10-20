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
                //Celda(11) finalizado
                DataRowView _datos = (DataRowView)e.Row.DataItem;
                bool finalizado = bool.Parse(_datos["Finalizado"].ToString());              
                
                if ( finalizado)
                {
                    _drp.Enabled = false;
                    _drpEstado.Enabled = false;
                }
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
                DropDownList _drpCursoBoleta = (DropDownList)gvInclusiones.Rows[index].FindControl("drpCursoBoleta");
                int grupo = int.Parse(_drpCursoBoleta.SelectedValue);
                CargarDatosVisualizar(idBoleta, grupo);

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "verComentario", "openModal();", true);
            }
        }

        private void CargarDatosVisualizar(int idBoleta, int grupo)
        {
            //aqui falta cargar las varas, ahora hay que setear
            InclusionDatos _aux = new InclusionDatos();
            _aux.idBoleta = idBoleta;
            _aux.grupo = grupo;
            DataTable _dtBoleta = _aux.getBoleta();

            lblNombre.Text = "Nombre: " + _dtBoleta.Rows[0]["Nombre"].ToString();
            lblCarnet.Text = "Carné: " + _dtBoleta.Rows[0]["Carnet"].ToString();
            lblCorreo.Text = "Correo: " + _dtBoleta.Rows[0]["Correo"].ToString();
            lbltelefono.Text = "Telefono: " + _dtBoleta.Rows[0]["Telefono"].ToString();
            lblCelular.Text = "Celular: " + _dtBoleta.Rows[0]["Celular"].ToString();
            lbldia.Text = "Día: " + _dtBoleta.Rows[0]["Dia"].ToString();
            lblhora.Text = "Hora: " + _dtBoleta.Rows[0]["Hora"].ToString()+":"+ _dtBoleta.Rows[0]["Minuto"].ToString();
            lblcarrera.Text = "Carrera: " + _dtBoleta.Rows[0]["Carrera"].ToString();
            lblplan.Text = "Sede: " + _dtBoleta.Rows[0]["Sede"].ToString();
            lblrn.Text = "RN: " + _dtBoleta.Rows[0]["RN"].ToString();
            string result = ((bool)_dtBoleta.Rows[0]["LR"]) ? "Sí" : "No";
            lbllr.Text = "LR: " +result;
            lblcomentario.Text = "Comentario: " + _dtBoleta.Rows[0]["Comentario"].ToString();

             EstadoInclusionesDatos _auxGrupo = new EstadoInclusionesDatos();
             _auxGrupo.idBoleta = idBoleta;
                DataTable _dtGrupos = _auxGrupo.getGrupos();
            lblGrupos.Text = "";
            lblGrupos.Text = "Grupos Solicitados: ";
            for(int x = 0; x < _dtGrupos.Rows.Count; x++)
            {
                lblGrupos.Text += _dtGrupos.Rows[x]["Numero"].ToString() + "  ";
            }

            

        }

        #endregion

        protected void btnCerrarPeriodo_OnClick(object sender, EventArgs e)
        {
            EstadoInclusionesDatos aux = new EstadoInclusionesDatos();            
            if (aux.FinalizarPeriodo())
            {
                txtTitulo1.Text = "Exito";
                txtcuerpo1.Text = "Periodo cerrado con exito";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "exito", "open();", true);
            }
            else
            {
                txtTitulo1.Text = "Error";
                txtcuerpo1.Text = " Fallo al intentar cerrar periodo";
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "exito", "open();", true);
            }
        }
    }
}