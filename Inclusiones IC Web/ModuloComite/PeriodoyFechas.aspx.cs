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
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/ModuloComite/Login.aspx");
            }
            if (!IsPostBack)
            {
                cargarPeriodos();
                showPeriodoActual();
            }
        }

        private void showPeriodoActual()
        {
            PeriodoDatos _aux = new PeriodoDatos();
            lblPeridoActual.Text = _aux.PeriodoActual();
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
            cargarInfoControles();
        }

        /// <summary>
        /// Carga la información cuando se selecciona un periodo en los calendar y el chechkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarInfoControles();
            showPeriodoActual();
        }

        private void cargarInfoControles()
        {
            try
            {
                PeriodoDatos _selec = new PeriodoDatos();
                _selec.Id = int.Parse(drpPeriodo.SelectedValue);
                _selec.SeleccionarUno();

                chkActivo.Checked = _selec.activo;
                calConsultaDesde.SelectedDate = _selec.FechaIniConsulta;
                calConsultaHasta.SelectedDate = _selec.FechaFinConsulta;
                calRecepcionDesde.SelectedDate = _selec.fechaIniInclusion;
                calRecepcionHasta.SelectedDate = _selec.fechaFinInclusion;
            }
            catch (Exception e)
            {

            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            if (BtnNew.Text == "Crear nuevo período")
            {
                divcrearNuevo.Visible = true;
                //txtnuevoPeriodo.Value = "";
                drpSemestre.SelectedIndex = -1;
                drpTipo.SelectedIndex = -1;
                drpAno.SelectedIndex = -1;
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
                //txtnuevoPeriodo.Value = "";
                drpSemestre.SelectedIndex = -1;
                drpTipo.SelectedIndex = -1;
                drpAno.SelectedIndex = -1;

                BtnNew.Text = "Crear nuevo período";
                drpPeriodo.Enabled = true;
                chkActivo.Enabled = true;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            PeriodoDatos _nuevo = new PeriodoDatos();
            string periodo = default (string);
            periodo = drpSemestre.SelectedValue.ToString();
            periodo += drpTipo.SelectedValue.ToString();
            periodo += drpAno.SelectedValue.ToString();
            _nuevo.periodo = periodo;
            _nuevo.fechaIniInclusion = calRecepcionDesde.SelectedDate;
            _nuevo.fechaFinInclusion = calRecepcionHasta.SelectedDate;
            _nuevo.FechaIniConsulta = calConsultaDesde.SelectedDate;
            _nuevo.FechaFinConsulta = calConsultaHasta.SelectedDate;
            if (BtnNew.Text == "Cerrar")
            {               
                if (_nuevo.Insertar())
                {
                    drpPeriodo.SelectedIndex = -1;
                    divcrearNuevo.Visible = false;
                    cargarPeriodos();
                    calConsultaDesde.SelectedDate = DateTime.Now;
                    calConsultaHasta.SelectedDate = DateTime.Now;
                    calRecepcionDesde.SelectedDate = DateTime.Now;
                    calRecepcionHasta.SelectedDate = DateTime.Now;
                    divcrearNuevo.Visible = false;
                   // txtnuevoPeriodo.Value = "";
                    drpSemestre.SelectedIndex = -1;
                    drpTipo.SelectedIndex = -1;
                    drpAno.SelectedIndex = -1;
                    BtnNew.Text = "Crear nuevo período";
                    drpPeriodo.Enabled = true;
                    chkActivo.Enabled = true;

                }

            }
            else
            {
                _nuevo.Id = int.Parse(drpPeriodo.SelectedValue);
                if (_nuevo.Actualizar())
                {
                    drpPeriodo.SelectedIndex = -1;
                    divcrearNuevo.Visible = false;
                    cargarPeriodos();
                    calConsultaDesde.SelectedDate = DateTime.Now;
                    calConsultaHasta.SelectedDate = DateTime.Now;
                    calRecepcionDesde.SelectedDate = DateTime.Now;
                    calRecepcionHasta.SelectedDate = DateTime.Now;
                    divcrearNuevo.Visible = false;
                   // txtnuevoPeriodo.Value = "";
                    drpSemestre.SelectedIndex = -1;
                    drpTipo.SelectedIndex = -1;
                    drpAno.SelectedIndex = -1;
                    BtnNew.Text = "Crear nuevo período";
                    drpPeriodo.Enabled = true;
                    chkActivo.Enabled = true;
                }
            }
        }

        protected void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            PeriodoDatos _activo = new PeriodoDatos();
            _activo.Id = int.Parse(drpPeriodo.SelectedValue);
            _activo.activo = chkActivo.Checked;
            _activo.activarPeriodo();
            showPeriodoActual();
        }
    }
}