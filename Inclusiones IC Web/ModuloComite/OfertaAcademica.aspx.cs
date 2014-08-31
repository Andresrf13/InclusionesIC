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

            }
            cargarSedes();
            cargarProfesores();
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
            }
        }

        private void insertarregistro()
        {
            OfertaAcademica _nuevo = new OfertaAcademica();
            _nuevo.numgrupo = int.Parse(txtGrupo.Value.ToString());
        }
    }
}