using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using Inclusiones_IC_Web.AccesoDatos;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class Graficos : System.Web.UI.Page
    {
        SqlConnection conexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable table = obtenerdatos();
            //Chart1.Series.Add("Test");            
            //Chart1.Series["Test"].XValueMember = "idGrupo";
            //Chart1.Series["Test"].YValueMembers = "idProfesor";
            ////Chart1.Series["Test"].ChartType = SeriesChartType.Bar;
            //Chart1.DataSource = table;
            //Chart1.DataBind();
            
        }


        #region NNenu 
        protected void btnGrafico1_OnClick(object sender, EventArgs e)
        {
            Seleccionado(1);
            MultiView1.ActiveViewIndex = 0;
            cargarConnboxPeriodo();
        }        

        protected void btnGrafico2_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            Seleccionado(2);
            cargarConnboxPeriodo2();
            cargarConnboxCursos2();

        }               

        protected void btnGrafico3_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            Seleccionado(3);           
        }        

        protected void btnGrafico4_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            Seleccionado(4);
            cargarConnboxPeriodo4();
        }

        private void Seleccionado(int x)
        {
            btnGrafico1.CssClass = "list-group-item ";
            btnGrafico2.CssClass = "list-group-item ";
            btnGrafico3.CssClass = "list-group-item ";
            btnGrafico4.CssClass = "list-group-item ";
            switch (x)
            {
                case 1:
                    btnGrafico1.CssClass = "list-group-item active";
                    break;
                case 2:
                    btnGrafico2.CssClass = "list-group-item active";
                    break;
                case 3:
                    btnGrafico3.CssClass = "list-group-item active";
                    break;
                case 4:
                    btnGrafico4.CssClass = "list-group-item active";
                    break;
            }
        }

        #endregion

        #region Cargar Connbox y datos
        private void cargarConnboxPeriodo()
        {
            drpPeriodoGrafico1.Items.Clear();
            PeriodoDatos _aux = new PeriodoDatos();
            DataTable _dtPeriodos = _aux.SeleccionarTodos();
            drpPeriodoGrafico1.DataSource = _dtPeriodos;
            drpPeriodoGrafico1.DataValueField = "idSemestre";
            drpPeriodoGrafico1.DataTextField = "Periodo";
            drpPeriodoGrafico1.DataBind();
        }

        private void cargarConnboxPeriodo2()
        {
            drpPeriodoGrafico2.Items.Clear();
            PeriodoDatos _aux = new PeriodoDatos();
            DataTable _dtPeriodos = _aux.SeleccionarTodos();
            drpPeriodoGrafico2.DataSource = _dtPeriodos;
            drpPeriodoGrafico2.DataValueField = "idSemestre";
            drpPeriodoGrafico2.DataTextField = "Periodo";
            drpPeriodoGrafico2.DataBind();
        }

        private void cargarConnboxPeriodo4()
        {
            drpPeriodoGrafico4.Items.Clear();
            PeriodoDatos _aux = new PeriodoDatos();
            DataTable _dtPeriodos = _aux.SeleccionarTodos();
            drpPeriodoGrafico4.DataSource = _dtPeriodos;
            drpPeriodoGrafico4.DataValueField = "idSemestre";
            drpPeriodoGrafico4.DataTextField = "Periodo";
            drpPeriodoGrafico4.DataBind();
        }

        private void cargarConnboxCursos2()
        {
            Cursos _nuevos = new Cursos();
            DataTable dtCursos = _nuevos.SeleccionarTodos();
            drpCursoGrafico2.DataSource = dtCursos;
            drpCursoGrafico2.DataValueField = "idCurso";
            drpCursoGrafico2.DataTextField = "Nombre";
            drpCursoGrafico2.DataBind();
        } 

        #endregion
    }
}