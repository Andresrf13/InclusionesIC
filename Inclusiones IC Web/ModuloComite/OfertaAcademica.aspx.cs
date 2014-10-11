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
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/ModuloComite/Login.aspx");
            }
            if(!IsPostBack)
            {
                cargarSedes();
                cargarProfesores();
                cargarCursos();
                cargarOfertaAcademica();
            }            
        }

        private void cargarOfertaAcademica()
        {
            OfertaAcademicaDatos _aux = new OfertaAcademicaDatos();
            DataTable _dtOfertaAc = _aux.SeleccionarTodos();
            gvOfertaAcademica.DataSource = _dtOfertaAc;
            gvOfertaAcademica.DataBind();
        }

        private void cargarCursos()
        {
            drpCursos.Items.Clear();
            Cursos _cursos = new Cursos();
            DataTable _dtCursos = _cursos.SeleccionarTodos();
            drpCursos.DataSource = _dtCursos;
            drpCursos.DataValueField = "idCurso";
            drpCursos.DataTextField = "Codigo";
            drpCursos.DataBind();
            cargarnombre();
        }

        private void cargarProfesores()
        {
            drpProfesores.Items.Clear();
            Profesores _prof = new Profesores();
            DataTable _dtProfesor = _prof.SeleccionarTodos();
            drpProfesores.DataSource = _dtProfesor;
            drpProfesores.DataValueField = "idProfesor";
            drpProfesores.DataTextField = "Nombre";
            drpProfesores.DataBind();
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if(btnNuevo.Text == "Nuevo")
            {
                limpiarCampos();
                divAgregar.Visible = true;
                btnNuevo.Text = "Cerrar";
            }
            else
            {
                divAgregar.Visible = false;
                btnNuevo.Text = "Nuevo";
                btnAgregar.Text = "Guardar";
            }
            
        }

        private void limpiarCampos()
        {
            txtGrupo.Value = "";
            txtCapMax.Value = "";
            txtCapDis.Value = "";
            txthoraaula.Text = "";
            drpCursos.SelectedIndex = -1;
            drpProfesores.SelectedIndex = -1;
            drpSede.SelectedIndex = -1;
            btnNuevo.Text = "Nuevo";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(btnAgregar.Text == "Guardar")
            {                
                    insertarregistro();
                    cargarOfertaAcademica();
            }
            else
            {
                actualizarRegistro();
                cargarOfertaAcademica();
            }
        }

        private Boolean actualizarRegistro()
        {
            bool validar = false;
            try
            {
                OfertaAcademicaDatos _nuevo = new OfertaAcademicaDatos();
                _nuevo.numgrupo = int.Parse(txtGrupo.Value.ToString());
                _nuevo.idCurso = int.Parse(drpCursos.SelectedValue.ToString());
                _nuevo.idProfesor = int.Parse(drpProfesores.SelectedValue.ToString());
                _nuevo.horario = txthoraaula.Text.Trim();
                _nuevo.Capacidad = int.Parse(txtCapMax.Value.Trim().ToString());
                _nuevo.disponible = int.Parse(txtCapDis.Value.Trim().ToString());
                _nuevo.sede = int.Parse(drpSede.SelectedValue);
                _nuevo.id = (int) Session["idEditar"];
                bool result = _nuevo.Actualizar();
                validar = true;
                if (result)
                {
                    btnNuevo.Text = "Nuevo";
                    divAgregar.Visible = false;
                    limpiarCampos();
                    btnAgregar.Text = "Guardar";

                }
            }
            catch (Exception e)
            {
                validar = false;
            }
            return validar;
        }
       
        private bool insertarregistro()
        {
            bool validar = false;
            try
            {
                OfertaAcademicaDatos _nuevo = new OfertaAcademicaDatos();
                _nuevo.numgrupo = int.Parse(txtGrupo.Value.ToString());
                _nuevo.idCurso = int.Parse(drpCursos.SelectedValue.ToString());
                _nuevo.idProfesor = int.Parse(drpProfesores.SelectedValue.ToString());
                _nuevo.horario = txthoraaula.Text.Trim();
                _nuevo.Capacidad = int.Parse(txtCapMax.Value.Trim().ToString());
                _nuevo.disponible = int.Parse(txtCapDis.Value.Trim().ToString());
                _nuevo.sede =  int.Parse(drpSede.SelectedValue);                

                bool result = _nuevo.Insertar();
                validar = true;
                if (result)
                {
                    btnNuevo.Text = "Nuevo";
                    divAgregar.Visible = false;
                    limpiarCampos();
                    
                }
            }
            catch (Exception e)
            {
                validar = false;
            }
            return validar;
        }

        protected void gvOfertaAcademica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOfertaAcademica.Rows[index];
                int id = int.Parse(row.Cells[0].Text);

                OfertaAcademicaDatos _elim = new OfertaAcademicaDatos();
                _elim.id = id;
                if (_elim.Eliminar())
                {
                    cargarOfertaAcademica();
                    divAgregar.Visible = false;
                }
            }
            else if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOfertaAcademica.Rows[index];
                int id = int.Parse(row.Cells[0].Text);
                llenarCannpos(id);                                
            }
        }

        private void llenarCannpos(int id)
        {
            Session["idEditar"] = id;
            OfertaAcademicaDatos _aux = new OfertaAcademicaDatos();
            _aux.id = id;
            _aux.SeleccionarUno();
            drpSede.SelectedValue = _aux.sede.ToString();
            drpProfesores.SelectedValue = _aux.idProfesor.ToString();
            drpCursos.SelectedValue = _aux.idCurso.ToString();
            txtGrupo.Value = _aux.numgrupo.ToString();
            txtCapDis.Value = _aux.Capacidad.ToString();
            txtCapMax.Value =  _aux.disponible.ToString();
            txthoraaula.Text = _aux.horario;

            cargarnombre();
            divAgregar.Visible = true;
            btnNuevo.Text = "Cerrar";
            btnAgregar.Text = "Actualizar";
        }

        protected void drpCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarnombre();
            
        }

        private void cargarnombre()
        {
            Cursos _aux = new Cursos();
            _aux.id = int.Parse(drpCursos.SelectedValue);
            _aux.getNombre();
            txtNombreCurso.Text = _aux.nombre;
        }

    }
}