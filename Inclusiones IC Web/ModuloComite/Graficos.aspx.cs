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

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class Graficos : System.Web.UI.Page
    {
        SqlConnection conexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = obtenerdatos();

            Chart1.Series.Add("Test");            
            Chart1.Series["Test"].XValueMember = "idGrupo";
            Chart1.Series["Test"].YValueMembers = "idProfesor";
            //Chart1.Series["Test"].ChartType = SeriesChartType.Bar;
            Chart1.DataSource = table;
            Chart1.DataBind();
        }


        private void Conectar()
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["dbInclusionesIC"].ConnectionString;
            conexion = new SqlConnection();
            conexion.ConnectionString = strCon;
        }
        public DataTable obtenerdatos()
        {
            DataTable dtprofesores = null;
            try
            {
                Conectar();
                conexion.Open();
                string queryString = "select * from [InclusionesIC].[dbo].[Grupo] ";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, conexion);
                DataSet _datos = new DataSet();
                adapter.Fill(_datos, "Cursos");
                dtprofesores = _datos.Tables["Cursos"];
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                conexion.Close();
            }
            return dtprofesores;
        }
    }
}