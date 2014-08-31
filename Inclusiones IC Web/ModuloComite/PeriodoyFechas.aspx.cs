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
            DateTime pinicio = DateTime.Now;
            string dtinicio = String.Format("{0:yyyy-MM-dd}", pinicio);

            cargarPeriodos();
        }

        private void cargarPeriodos()
        {
            drpPeriodo.Items.Clear();
            PeriodoDatos _aux = new PeriodoDatos();
            DataTable _dtPeriodos = _aux.SeleccionarTodos();
            drpPeriodo.DataSource = _dtPeriodos;
            drpPeriodo.DataValueField = "idSemestre";
            drpPeriodo.DataTextField = "Periodo";
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
                BtnNew.Text = "Cerrrar";
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
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if(BtnNew.Text =="Crear nuevo período" )
            {

            }
        }
    }
}