﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class AsignarGrupoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCursos();
                CargarGrid();

            }
        }

        private void CargarGrid()
        {
            GrupoNuevoDatos gNuevo = new GrupoNuevoDatos();
            gNuevo.id = int.Parse(drpCursos.SelectedValue);
            DataTable dtGNuevo = gNuevo.SeleccionarTodos();
            gvGruposNuevos.DataSource = dtGNuevo;
            gvGruposNuevos.DataBind();
        }

        #region DropdownList
        private void CargarGrupos()
        {
            if (drpCursos.Items.Count > 0)
            {
                GruposDatos grupos = new GruposDatos();
                grupos.id = int.Parse(drpCursos.SelectedValue);
                DataTable dtgrupos = grupos.SeleccionarTodos();
                drpGrupos.DataSource = dtgrupos;
                drpGrupos.DataValueField = "idGrupo";
                drpGrupos.DataTextField = "Numero";
                drpGrupos.DataBind();                
            }            
        }

        private void CargarCursos()
        {
            Cursos cursos = new Cursos();
            DataTable dtCursos = cursos.SeleccionarTodos();
            drpCursos.DataSource = dtCursos;
            drpCursos.DataValueField = "idCurso";
            drpCursos.DataTextField = "Nombre";
            drpCursos.DataBind();
            CargarGrupos();
        }

        protected void drpCursos_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrupos();
            CargarGrid();
        }

        #endregion

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            GrupoNuevoDatos aux = new GrupoNuevoDatos();
            aux.idGrupo = int.Parse(drpGrupos.SelectedItem.Text);
            aux.idCurso = int.Parse(drpCursos.SelectedValue);
            if (aux.ActualizarGrupo())
            {
                txtTitulo.Text = "Finalizado";
                txtCuerpo.Text = "Inclusiones reasignadas al grupo " + drpGrupos.SelectedItem.Text;
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "Finalizado", "openModal();", true);
                CargarGrid();
            }
            else
            {
                txtTitulo.Text = "Error";
                txtCuerpo.Text = "Error al intentar reasignar inclusiones  al grupo " + drpGrupos.SelectedItem.Text;
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "Finalizado", "openModal();", true);
            }
            
        }


    }
}