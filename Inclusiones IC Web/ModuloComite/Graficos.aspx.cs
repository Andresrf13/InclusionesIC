using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using Inclusiones_IC_Web.AccesoDatos;
using ListItem = iTextSharp.text.ListItem;

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
            cargarConnboxPeriodo3();
        }        

        protected void btnGrafico4_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            Seleccionado(4);
            //cargarConnboxPeriodo4();
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
            System.Web.UI.WebControls.ListItem seleccione = new System.Web.UI.WebControls.ListItem("--Seleccione--", "-1");
            drpPeriodoGrafico1.Items.Insert(0, seleccione);
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
            System.Web.UI.WebControls.ListItem seleccione = new System.Web.UI.WebControls.ListItem("--Seleccione--", "-1");
            drpPeriodoGrafico2.Items.Insert(0, seleccione);
        }

        private void cargarConnboxPeriodo3()
        {
            drpPeriodoGrafico3.Items.Clear();
            PeriodoDatos _aux = new PeriodoDatos();
            DataTable _dtPeriodos = _aux.SeleccionarTodos();
            drpPeriodoGrafico3.DataSource = _dtPeriodos;
            drpPeriodoGrafico3.DataValueField = "idSemestre";
            drpPeriodoGrafico3.DataTextField = "Periodo";
            drpPeriodoGrafico3.DataBind();
            System.Web.UI.WebControls.ListItem seleccione = new System.Web.UI.WebControls.ListItem("--Seleccione--", "-1");
            drpPeriodoGrafico3.Items.Insert(0, seleccione);
        }
       

        //private void cargarConnboxPeriodo4()
        //{
        //    drpPeriodoGrafico4.Items.Clear();
        //    PeriodoDatos _aux = new PeriodoDatos();
        //    DataTable _dtPeriodos = _aux.SeleccionarTodos();
        //    drpPeriodoGrafico4.DataSource = _dtPeriodos;
        //    drpPeriodoGrafico4.DataValueField = "idSemestre";
        //    drpPeriodoGrafico4.DataTextField = "Periodo";
        //    drpPeriodoGrafico4.DataBind();
        //    System.Web.UI.WebControls.ListItem seleccione = new System.Web.UI.WebControls.ListItem("--Seleccione--", "-1");
        //    drpPeriodoGrafico4.Items.Insert(0, seleccione);
        //}

        private void cargarConnboxCursos2()
        {
            Cursos _nuevos = new Cursos();
            DataTable dtCursos = _nuevos.SeleccionarTodos();
            drpCursoGrafico2.DataSource = dtCursos;
            drpCursoGrafico2.DataValueField = "idCurso";
            drpCursoGrafico2.DataTextField = "Nombre";
            drpCursoGrafico2.DataBind();
            System.Web.UI.WebControls.ListItem seleccione = new System.Web.UI.WebControls.ListItem("--Seleccione--", "-1");
            drpCursoGrafico2.Items.Insert(0, seleccione);
        } 

        #endregion

        protected void drpPeriodoGrafico1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           GraficosDatos _datos = new GraficosDatos();
            _datos.periodo = drpPeriodoGrafico1.SelectedValue;
            DataTable _dtDatos = _datos.GetGrafico1();           
            //Grafico1.Palette = ChartColorPalette.Bright;            
            //Grafico1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //Grafico1.ChartAreas[0].Area3DStyle.Inclination = 1;
            //Grafico1.ChartAreas[0].Area3DStyle.Rotation = 3;
            Grafico1.Series.RemoveAt(0);
            Grafico1.BackColor = Color.GhostWhite;
            Grafico1.ChartAreas[0].BackColor = Color.GhostWhite;

            Grafico1.Series.Add("Total");                      
            Grafico1.Series["Total"].XValueMember = "COD_CURSO";
            Grafico1.Series["Total"].YValueMembers = "TOTAL_INCLUSIONES";
            Grafico1.Series["Total"].ChartType = SeriesChartType.Column;
            Grafico1.Series["Total"].IsValueShownAsLabel = true;
            Grafico1.Series["Total"]["PixelPointWidth"] = "100";
            Grafico1.Series["Total"]["DrawingStyle"] = "Emboss";
            Grafico1.Series["Total"].Font = new Font("Verdana", 12, FontStyle.Bold);
            Grafico1.Series["Total"].LabelForeColor = Color.Blue;
            Grafico1.Series["Total"].Color = Color.Blue;

            Grafico1.Series.Add("Cursado");
            Grafico1.Series["Cursado"].XValueMember = "COD_CURSO";
            Grafico1.Series["Cursado"].YValueMembers = "CUR";
            Grafico1.Series["Cursado"].ChartType = SeriesChartType.Column;
            Grafico1.Series["Cursado"].IsValueShownAsLabel = true;
            Grafico1.Series["Cursado"]["PixelPointWidth"] = "100";
            Grafico1.Series["Cursado"]["DrawingStyle"] = "Emboss";
            Grafico1.Series["Cursado"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico1.Series["Cursado"].LabelForeColor = Color.OrangeRed;
            Grafico1.Series["Cursado"].Color = Color.OrangeRed;

            Grafico1.Series.Add("Abandono de curso");
            Grafico1.Series["Abandono de curso"].XValueMember = "COD_CURSO";
            Grafico1.Series["Abandono de curso"].YValueMembers = "AC";
            Grafico1.Series["Abandono de curso"].ChartType = SeriesChartType.Column;
            Grafico1.Series["Abandono de curso"].IsValueShownAsLabel = true;
            Grafico1.Series["Abandono de curso"]["PixelPointWidth"] = "100";
            Grafico1.Series["Abandono de curso"]["DrawingStyle"] = "Emboss";
            Grafico1.Series["Abandono de curso"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico1.Series["Abandono de curso"].LabelForeColor = Color.ForestGreen;
            Grafico1.Series["Abandono de curso"].Color = Color.ForestGreen;

            Grafico1.Series.Add("Reprobado");
            Grafico1.Series["Reprobado"].XValueMember = "COD_CURSO";
            Grafico1.Series["Reprobado"].YValueMembers = "REP";
            Grafico1.Series["Reprobado"].ChartType = SeriesChartType.Column;
            Grafico1.Series["Reprobado"].IsValueShownAsLabel = true;
            Grafico1.Series["Reprobado"]["PixelPointWidth"] = "100";
            Grafico1.Series["Reprobado"]["DrawingStyle"] = "Emboss";
            Grafico1.Series["Reprobado"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico1.Series["Reprobado"].LabelForeColor = Color.DeepPink;
            Grafico1.Series["Reprobado"].Color = Color.DeepPink;

            Grafico1.Series.Add("Retiro justificado");
            Grafico1.Series["Retiro justificado"].XValueMember = "COD_CURSO";
            Grafico1.Series["Retiro justificado"].YValueMembers = "RTJ";            
            Grafico1.Series["Retiro justificado"].ChartType = SeriesChartType.Column;
            Grafico1.Series["Retiro justificado"].IsValueShownAsLabel = true;
            Grafico1.Series["Retiro justificado"]["PixelPointWidth"] = "100";
            Grafico1.Series["Retiro justificado"]["DrawingStyle"] = "Emboss";
            Grafico1.Series["Retiro justificado"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico1.Series["Retiro justificado"].LabelForeColor = Color.Black;
            Grafico1.Series["Retiro justificado"].Color = Color.Black;

            Grafico1.Legends.Add(new Legend("Legenda1"));
            Grafico1.Series["Total"].Legend = "Legenda1";
            Grafico1.Series["Total"].IsVisibleInLegend = true;    

            Grafico1.DataSource = _dtDatos;
            Grafico1.DataBind();            
        }

        protected void drpPeriodoGrafico2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpPeriodoGrafico2.Items.Count > 0 && drpCursoGrafico2.Items.Count > 0)
            {
                GraficosDatos _datos = new GraficosDatos();
                _datos.iperiodo =  int.Parse(drpPeriodoGrafico2.SelectedValue);
                _datos.curso = int.Parse(drpCursoGrafico2.SelectedValue);
                DataTable _dtDatos = _datos.GetGrafico2();
                //Grafico2.Palette = ChartColorPalette.Bright;            
                //Grafico2.ChartAreas[0].Area3DStyle.Enable3D = true;
                //Grafico2.ChartAreas[0].Area3DStyle.Inclination = 1;
                //Grafico2.ChartAreas[0].Area3DStyle.Rotation = 3;
                Grafico2.Series.RemoveAt(0);
                Grafico2.BackColor = Color.GhostWhite;
                Grafico2.ChartAreas[0].BackColor = Color.GhostWhite;

                Grafico2.Series.Add("Total");
                Grafico2.Series["Total"].XValueMember = "COD_CURSO";
                Grafico2.Series["Total"].YValueMembers = "TOTAL_INCLUSIONES";
                Grafico2.Series["Total"].ChartType = SeriesChartType.Column;
                Grafico2.Series["Total"].IsValueShownAsLabel = true;
                Grafico2.Series["Total"]["PixelPointWidth"] = "100";
                Grafico2.Series["Total"]["DrawingStyle"] = "Emboss";
                Grafico2.Series["Total"].Font = new Font("Verdana", 12, FontStyle.Bold);
                Grafico2.Series["Total"].LabelForeColor = Color.Blue;
                Grafico2.Series["Total"].Color = Color.Blue;

                Grafico2.Series.Add("Cursado");
                Grafico2.Series["Cursado"].XValueMember = "COD_CURSO";
                Grafico2.Series["Cursado"].YValueMembers = "CUR";
                Grafico2.Series["Cursado"].ChartType = SeriesChartType.Column;
                Grafico2.Series["Cursado"].IsValueShownAsLabel = true;
                Grafico2.Series["Cursado"]["PixelPointWidth"] = "100";
                Grafico2.Series["Cursado"]["DrawingStyle"] = "Emboss";
                Grafico2.Series["Cursado"].Font = new Font("Verdana", 10, FontStyle.Regular);
                Grafico2.Series["Cursado"].LabelForeColor = Color.OrangeRed;
                Grafico2.Series["Cursado"].Color = Color.OrangeRed;

                Grafico2.Series.Add("Abandono de curso");
                Grafico2.Series["Abandono de curso"].XValueMember = "COD_CURSO";
                Grafico2.Series["Abandono de curso"].YValueMembers = "AC";
                Grafico2.Series["Abandono de curso"].ChartType = SeriesChartType.Column;
                Grafico2.Series["Abandono de curso"].IsValueShownAsLabel = true;
                Grafico2.Series["Abandono de curso"]["PixelPointWidth"] = "100";
                Grafico2.Series["Abandono de curso"]["DrawingStyle"] = "Emboss";
                Grafico2.Series["Abandono de curso"].Font = new Font("Verdana", 10, FontStyle.Regular);
                Grafico2.Series["Abandono de curso"].LabelForeColor = Color.ForestGreen;
                Grafico2.Series["Abandono de curso"].Color = Color.ForestGreen;

                Grafico2.Series.Add("Reprobado");
                Grafico2.Series["Reprobado"].XValueMember = "COD_CURSO";
                Grafico2.Series["Reprobado"].YValueMembers = "REP";
                Grafico2.Series["Reprobado"].ChartType = SeriesChartType.Column;
                Grafico2.Series["Reprobado"].IsValueShownAsLabel = true;
                Grafico2.Series["Reprobado"]["PixelPointWidth"] = "100";
                Grafico2.Series["Reprobado"]["DrawingStyle"] = "Emboss";
                Grafico2.Series["Reprobado"].Font = new Font("Verdana", 10, FontStyle.Regular);
                Grafico2.Series["Reprobado"].LabelForeColor = Color.DeepPink;
                Grafico2.Series["Reprobado"].Color = Color.DeepPink;

                Grafico2.Series.Add("Retiro justificado");
                Grafico2.Series["Retiro justificado"].XValueMember = "COD_CURSO";
                Grafico2.Series["Retiro justificado"].YValueMembers = "RTJ";
                Grafico2.Series["Retiro justificado"].ChartType = SeriesChartType.Column;
                Grafico2.Series["Retiro justificado"].IsValueShownAsLabel = true;
                Grafico2.Series["Retiro justificado"]["PixelPointWidth"] = "100";
                Grafico2.Series["Retiro justificado"]["DrawingStyle"] = "Emboss";
                Grafico2.Series["Retiro justificado"].Font = new Font("Verdana", 10, FontStyle.Regular);
                Grafico2.Series["Retiro justificado"].LabelForeColor = Color.Black;
                Grafico2.Series["Retiro justificado"].Color = Color.Black;

                Grafico2.Legends.Add(new Legend("Legenda1"));
                Grafico2.Series["Total"].Legend = "Legenda1";
                Grafico2.Series["Total"].IsVisibleInLegend = true;

                Grafico2.DataSource = _dtDatos;
                Grafico2.DataBind();       
            }
        }

        protected void txtCarnetGrafico3_OnTextChanged(object sender, EventArgs e)
        {
            GraficosDatos _datos = new GraficosDatos();
            _datos.iperiodo = int.Parse(drpPeriodoGrafico3.SelectedValue);
            _datos.carnet = txtCarnetGrafico3.Text.Trim();
            DataTable _dtDatos = _datos.GetGrafico3();
            Grid3.DataSource = _dtDatos;
            Grid3.DataBind();
        }

        protected void drpPeriodoGrafico3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GraficosDatos _datos = new GraficosDatos();
            _datos.iperiodo = int.Parse(drpPeriodoGrafico3.SelectedValue);
            _datos.carnet = txtCarnetGrafico3.Text.Trim();
            DataTable _dtDatos = _datos.GetGrafico3();
            Grid3.DataSource = _dtDatos;
            Grid3.DataBind();
        }

        protected void txtcarnetGrafico4_OnTextChanged(object sender, EventArgs e)
        {
            GraficosDatos _datos = new GraficosDatos();
            _datos.carnet = txtcarnetGrafico4.Text.Trim();
            DataTable _dtDatos = _datos.GetGrafico4();
            //Grafico4.Palette = ChartColorPalette.Bright;            
            //Grafico4.ChartAreas[0].Area3DStyle.Enable3D = true;
            //Grafico4.ChartAreas[0].Area3DStyle.Inclination = 1;
            //Grafico4.ChartAreas[0].Area3DStyle.Rotation = 3;
            Grafico4.Series.RemoveAt(0);
            Grafico4.BackColor = Color.GhostWhite;
            Grafico4.ChartAreas[0].BackColor = Color.GhostWhite;
            

            Grafico4.Series.Add("Cursado");
            Grafico4.Series["Cursado"].XValueMember = "Periodo";
            Grafico4.Series["Cursado"].YValueMembers = "CUR";
            Grafico4.Series["Cursado"].ChartType = SeriesChartType.Column;
            Grafico4.Series["Cursado"].IsValueShownAsLabel = true;
            Grafico4.Series["Cursado"]["PixelPointWidth"] = "100";
            Grafico4.Series["Cursado"]["DrawingStyle"] = "Emboss";
            Grafico4.Series["Cursado"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico4.Series["Cursado"].LabelForeColor = Color.OrangeRed;
            Grafico4.Series["Cursado"].Color = Color.OrangeRed;

            Grafico4.Series.Add("Abandono de curso");
            Grafico4.Series["Abandono de curso"].XValueMember = "Periodo";
            Grafico4.Series["Abandono de curso"].YValueMembers = "AC";
            Grafico4.Series["Abandono de curso"].ChartType = SeriesChartType.Column;
            Grafico4.Series["Abandono de curso"].IsValueShownAsLabel = true;
            Grafico4.Series["Abandono de curso"]["PixelPointWidth"] = "100";
            Grafico4.Series["Abandono de curso"]["DrawingStyle"] = "Emboss";
            Grafico4.Series["Abandono de curso"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico4.Series["Abandono de curso"].LabelForeColor = Color.ForestGreen;
            Grafico4.Series["Abandono de curso"].Color = Color.ForestGreen;

            Grafico4.Series.Add("Reprobado");
            Grafico4.Series["Reprobado"].XValueMember = "Periodo";
            Grafico4.Series["Reprobado"].YValueMembers = "REP";
            Grafico4.Series["Reprobado"].ChartType = SeriesChartType.Column;
            Grafico4.Series["Reprobado"].IsValueShownAsLabel = true;
            Grafico4.Series["Reprobado"]["PixelPointWidth"] = "100";
            Grafico4.Series["Reprobado"]["DrawingStyle"] = "Emboss";
            Grafico4.Series["Reprobado"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico4.Series["Reprobado"].LabelForeColor = Color.DeepPink;
            Grafico4.Series["Reprobado"].Color = Color.DeepPink;

            Grafico4.Series.Add("Retiro justificado");
            Grafico4.Series["Retiro justificado"].XValueMember = "Periodo";
            Grafico4.Series["Retiro justificado"].YValueMembers = "RTJ";
            Grafico4.Series["Retiro justificado"].ChartType = SeriesChartType.Column;
            Grafico4.Series["Retiro justificado"].IsValueShownAsLabel = true;
            Grafico4.Series["Retiro justificado"]["PixelPointWidth"] = "100";
            Grafico4.Series["Retiro justificado"]["DrawingStyle"] = "Emboss";
            Grafico4.Series["Retiro justificado"].Font = new Font("Verdana", 10, FontStyle.Regular);
            Grafico4.Series["Retiro justificado"].LabelForeColor = Color.Black;
            Grafico4.Series["Retiro justificado"].Color = Color.Black;

            Grafico4.Legends.Add(new Legend("Legenda1"));
            Grafico4.Series["Cursado"].Legend = "Legenda1";
            Grafico4.Series["Cursado"].IsVisibleInLegend = true;

            Grafico4.DataSource = _dtDatos;
            Grafico4.DataBind();         
        }
    }
}