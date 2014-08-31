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
    public partial class PeriodoyFechas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           

            cargarPeriodos();
        }

        private void cargarPeriodos()
        {
            drpPeriodo.Enabled = true;
            chkActivo.Enabled = true;
            drpPeriodo.Items.Clear();
            PeriodoDatos _aux = new PeriodoDatos();
            DataTable _dtPeriodos = _aux.SeleccionarTodos();
            drpPeriodo.DataSource = _dtPeriodos;
            drpPeriodo.DataValueField = "idSemestre";
            drpPeriodo.DataTextField = "Periodo";
            drpPeriodo.DataBind();
        }

        /// <summary>
        /// Carga la información cuando se selecciona un periodo en los calendar y el chechkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            if(BtnNew.Text == "Crear nuevo período")
            {
                divcrearNuevo.Visible = true;
                txtnuevoPeriodo.Value = "";
                BtnNew.Text = "Cerrar";
                drpPeriodo.Enabled = false;
                chkActivo.Enabled = false;
                calConsultaDesde.SelectedDate = DateTime.Now;
                calConsultaHasta.SelectedDate = DateTime.Now;
                calRecepcionDesde.SelectedDate = DateTime.Now;
                calRecepcionHasta.SelectedDate = DateTime.Now;
            }
            else
            {
                divcrearNuevo.Visible = false;
                txtnuevoPeriodo.Value = "";
                BtnNew.Text = "Crear nuevo período";
                drpPeriodo.Enabled = true;
                chkActivo.Enabled = true;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if(BtnNew.Text =="Cerrar" )
            {
                PeriodoDatos _nuevo = new PeriodoDatos();
                _nuevo.periodo = txtnuevoPeriodo.Value.Trim();
                _nuevo.fechaIniInclusion = calRecepcionDesde.SelectedDate;
                _nuevo.fechaFinInclusion = calRecepcionHasta.SelectedDate;
                _nuevo.FechaIniConsulta = calConsultaDesde.SelectedDate;
                _nuevo.FechaFinConsulta = calConsultaDesde.SelectedDate;

                if (_nuevo.Insertar())
                {
                    drpPeriodo.SelectedIndex = -1;
                    divcrearNuevo.Visible = false;
                    cargarPeriodos();
                    calConsultaDesde.SelectedDate = DateTime.Now;
                    calConsultaHasta.SelectedDate = DateTime.Now;
                    calRecepcionDesde.SelectedDate = DateTime.Now;
                    calRecepcionHasta.SelectedDate = DateTime.Now;
                    
                }
            }
        }
    }
}