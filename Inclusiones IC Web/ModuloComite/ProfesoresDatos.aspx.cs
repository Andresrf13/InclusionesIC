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
    public partial class ProfesoresDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProfesores();
            }
        }


        //  Ingresar un nuevo profesor
        protected void btn_NuevoProfeClick(object sender, EventArgs e)
        {
            if (btnNuevoProfe.Text == "Nuevo")
            {

                divAgregarProfe.Visible = true;
                btnNuevoProfe.Text = "Cerrar";
            }
            else
            {
                divAgregarProfe.Visible = false;
                btnNuevoProfe.Text = "Nuevo";
                //btnAgregar.Text = "Guardar";
            }

        }
        protected void btnAgregarProfe_Click(object sender, EventArgs e)
        {
            if (btnAgregarProfe.Text == "Guardar")
            {
                insertarProfe();
                CargarProfesores();
            }
            else
            {
                actualizarProfes();
                CargarProfesores();
            }
        }
        private Boolean actualizarProfes()
        {
            bool validar = false;
            try
            {
                Profesores _nuevo = new Profesores();
                _nuevo.nombre = txtProfe.Value.Trim();
                _nuevo.correo = txtCorreo.Value.Trim();
                _nuevo.telefono = int.Parse(txtTelefono.Value.Trim().ToString());
                _nuevo.id = (int)Session["idEditar"];
                bool result = _nuevo.Actualizar();
                validar = true;
                if (result)
                {
                    btnNuevoProfe.Text = "Nuevo";
                    divAgregarProfe.Visible = false;
                    Limpiar();
                    btnAgregarProfe.Text = "Guardar";

                }
            }
            catch (Exception e)
            {
                validar = false;
            }
            return validar;
        }
        private Boolean insertarProfe()
        {
            bool validar = true;
            try
            {
                AgregarProfesor _nuevo = new AgregarProfesor();
                _nuevo.nombre = txtProfe.Value;
                _nuevo.correo = txtCorreo.Value;
                _nuevo.telefono = int.Parse(txtTelefono.Value);

                bool result = _nuevo.InsertarProfe();
                validar = true;
                if (result)
                {
                    btnNuevoProfe.Text = "Nuevo";
                    divAgregarProfe.Visible = false;
                    Limpiar();
                }
            }
            catch (Exception e)
            {
                validar = false;
            }
            return validar;
        }

        private void Limpiar()
        {
            txtCorreo.Value = " ";
            txtProfe.Value = " ";
            txtTelefono.Value = " ";
        }


        private void CargarProfesores()
        {
            Profesores _aux = new Profesores();
            DataTable _dtProfesores = _aux.SeleccionarTodos();
            gridviewProfesores.DataSource = _dtProfesores;
            gridviewProfesores.DataBind();
        }
        private void llenarCampos(int id)
        {
            Session["idEditar"] = id;
            Profesores _aux = new Profesores();
            _aux.id = id;
            _aux.SeleccionarUno();
            txtProfe.Value = _aux.nombre.ToString();
            txtCorreo.Value = _aux.correo.ToString();
            txtTelefono.Value = _aux.telefono.ToString();
            divAgregarProfe.Visible = true;
            btnNuevoProfe.Text = "Cerrar";
            btnAgregarProfe.Text = "Actualizar";
        }

        protected void gridviewProfesores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridviewProfesores.Rows[index];
                int id = int.Parse(row.Cells[0].Text);
                llenarCampos(id);
            }
            else if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridviewProfesores.Rows[index];
                int id = int.Parse(row.Cells[0].Text);

                Profesores _elim = new Profesores();
                _elim.id = id;
                if (_elim.Eliminar())
                {
                    CargarProfesores();
                    divAgregarProfe.Visible = false;
                }

            }

        }



    }


}