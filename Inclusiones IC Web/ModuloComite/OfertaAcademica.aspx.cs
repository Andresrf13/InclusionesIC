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
            drpCursos.DataTextField = "Nombre";
            drpCursos.DataBind();
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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(btnAgregar.Text == "Guardar")
            {                
                    insertarregistro();
                    cargarOfertaAcademica();
            }
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
    }
}