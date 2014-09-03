using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;

namespace Inclusiones_IC_Web.ModuloEstudiante
{
    public partial class BoletaInclusion : System.Web.UI.Page
    {
        List<ItemGrupo> _listagrupos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarSedes();
                cargarCarrera();
                _listagrupos = new List<ItemGrupo>();
                Session["listagrupo"] = _listagrupos;

            }
            else
            {
                _listagrupos = (List<ItemGrupo>)Session["listagrupo"];
            }
        }

        private void cargarCarrera()
        {
            drpCarrera.Items.Clear();
            CarreraDatos _aux = new CarreraDatos();
            DataTable _dtcarrera = _aux.SeleccionarTodos();
            drpCarrera.DataSource = _dtcarrera;
            drpCarrera.DataValueField = "idCarrera";
            drpCarrera.DataTextField = "Nombre";
            drpCarrera.DataBind();
            cargarPlan();
        }

        private void cargarPlan()
        {
            drpPlan.Items.Clear();
            Plan _aux = new Plan();
            _aux.id = int.Parse(drpCarrera.SelectedValue.ToString());
            DataTable _dtplan = _aux.SeleccionarPlanxCarrera();
            drpPlan.DataSource = _dtplan;
            drpPlan.DataValueField = "idPlan";
            drpPlan.DataTextField = "Nombre";
            drpPlan.DataBind();
            cargarCursos();
        }

        private void cargarCursos()
        {
            drpCursos.Items.Clear();
            Cursos _aux = new Cursos();            
            DataTable _dtCursos = _aux.SeleccionarCursoxPlan(int.Parse(drpCarrera.SelectedValue.ToString()), int.Parse(drpPlan.SelectedValue.ToString()));
            drpCursos.DataSource = _dtCursos;
            drpCursos.DataValueField = "idCurso";
            drpCursos.DataTextField = "Nombre";
            drpCursos.DataBind();
        }


        private void cargarSedes()
        {
            drpSedes.Items.Clear();
            Sede _aux = new Sede();
            DataTable _dtSedes = _aux.SeleccionarTodos();
            drpSedes.DataSource = _dtSedes;
            drpSedes.DataValueField = "idSede";
            drpSedes.DataTextField = "Nombre";
            drpSedes.DataBind();
        }

        /// <summary>
        /// radiobutton de RN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rbnoRN_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnoRN.Checked)
            {
                divRN.Visible = false;
            }
            else if (rbsiRN.Checked)
            {
                divRN.Visible = true;
            }
        }

        //AGREGA UN GRUPO A LA LISTA
        protected void btnAddGrupo_Click(object sender, EventArgs e)
        {
            _listagrupos = (List<ItemGrupo>)Session["listagrupo"];
            int numgrupo = int.Parse(drpGrupo.SelectedValue.ToString());

            bool result = _listagrupos.Exists(x => x.numgrupo == numgrupo);
            if (!result)
            {
                ItemGrupo nuevo = new ItemGrupo(numgrupo, false);
                _listagrupos.Add(nuevo);
                Session["listagrupo"] = _listagrupos;
                gvGrupos.DataSource = _listagrupos;
                gvGrupos.DataBind();
            }            

        }

        protected void rbSiLR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoLR.Checked)
            {
                divLRPeriodo.Visible = false;
            }
            else if (rbSiLR.Checked)
            {
                divLRPeriodo.Visible = true;
            }
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            divBoleta.Visible = false;
            divVisualizador.Visible = true;

            LabelVisualizadorNombre.Text = TxtName.Text;
            LabelVisualizadorCarne.Text = TxtCarne.Text;
            LabelVisualizarEmail.Text = TxtEmail.Text;
            LabelVisualizarTelefono.Text = TxtPhone.Text;
            LabelVisualizarCelular.Text = TxtCellphone.Text;
            LabelVisualizarDiaMatricula.Text = DropDownRegistrationDay.SelectedValue;
            LabelVisualizarHora.Text = DropDownRegistrationTimeHour.SelectedValue +":"+DropDownRegistrationTimeMinute.SelectedValue;

            LabelVisualizarRN.Text = (rbsiRN.Checked) ? "Sí" : "No";
            LabelVisualizarNumeroRN.Text = (rbsiRN.Checked)? drpNoRN.SelectedValue : "0";         
            LabelVisualizarPlan.Text = drpPlan.SelectedItem.Text;
            LabelVisualizarSede.Text = drpSedes.SelectedItem.Text;
            LabelVisualizarCarrera.Text = drpCarrera.SelectedItem.Text;
            LabelVisualizarComentario.Text = TxtComentario.Text;
            LabelVisualizarCurso.Text = drpCursos.SelectedItem.Text;
            
            for (int x = 0; x < _listagrupos.Count; x++)
            {
                string choca = ((bool)_listagrupos[x].choque)? "Choca" : "No choca";
                if (x == 0)
                {
                    LabelVisualizarGrupo.Text += " #Grupo: " + _listagrupos[x].numgrupo.ToString() + " " + choca;
                }
                else
                {
                    LabelVisualizarGrupo.Text += ", #Grupo: " + _listagrupos[x].numgrupo.ToString() + " " + choca;
                }
                
            }
            

            LabelVisualizarRequisitos.Text = (rbSiLR.Checked) ? "Sí" : "No";
            if (rbSiLR.Checked)
            {
                
                if (rbSiLRProceso.Checked)
                {
                    LabelVisualizarCumpleRequisitos.Text = "Si, realizó el proceso de levantamiento de requisitos";
                }
                if (rbSiLRCursos.Checked)
                {
                    LabelVisualizarCumpleRequisitos.Text = "Si, ha ganado todos los cursos";
                }
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            divBoleta.Visible = true;
            divVisualizador.Visible = false;
        }

        protected void BtnImprimirPDF_Click(object sender, EventArgs e)
        {
            try
            {
                var newPDF = new Document(PageSize.A4, 50, 50, 25, 25);
                var output = new FileStream(Server.MapPath("Boleta.pdf"), FileMode.OpenOrCreate);
                var writer = PdfWriter.GetInstance(newPDF, output);

                newPDF.Open();
                var titleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.BOLD, CMYKColor.DARK_GRAY);
                var subTitleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, Font.BOLD, CMYKColor.GRAY);
                var paraFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.NORMAL);

                var imagenTEC = iTextSharp.text.Image.GetInstance(Server.MapPath("/Imagenes/tec.jpg"));
                imagenTEC.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                var titulo = new Paragraph("                                 Escuela de Ingeniería en Computación", titleFont);
                var subtitulo = new Paragraph("                                                          Boleta de Inclusión \r\n \r\n", subTitleFont);
                var subtituloDatos = new Paragraph("--------------------------------------------------------- \r\nDatos Personales \r\n\r\n", titleFont);
                var parrafo = new Paragraph("- Nombre: " + LabelVisualizadorNombre.Text + "\r\n" +
                                            "- Carné: " + LabelVisualizadorCarne.Text + "\r\n" +
                                            "- E-mail: " + LabelVisualizarEmail.Text + "\r\n" +
                                            "- Celular: " + LabelVisualizarCelular.Text + "\r\n" +
                                            "- Teléfono: " + LabelVisualizarTelefono.Text + "\r\n"
                                          + "- Sede: " + LabelVisualizarSede.Text + "\r\n"
                                          + "- Día de matrícula: " + LabelVisualizarDiaMatricula.Text + "\r\n"
                                          + "- Hora de matrícula: " + LabelVisualizarHora.Text + "\r\n", paraFont);
                var subtituloCurso = new Paragraph("--------------------------------------------------------- \r\nDatos del Curso \r\n\r\n", titleFont);
                var parrafoCurso = new Paragraph("- Sede: " + LabelVisualizarSede.Text + "\r\n"
                                               + "- Carrera: " + LabelVisualizarCarrera.Text + "\r\n"
                                               + "- Plan de estudios: " + LabelVisualizarPlan.Text + "\r\n"
                                               + "- Curso: " + LabelVisualizarCurso.Text + "\r\n"
                                               + "- Grupos: " + LabelVisualizarGrupo.Text + "\r\n"
                                               + "- RN: " + LabelVisualizarRN.Text + "\r\n"
                                               + "- Cumple con requisitos: " + LabelVisualizarCumpleRequisitos.Text + "\r\n"
                                               + "- Comentario: " + LabelVisualizarComentario.Text, paraFont);
                newPDF.Add(imagenTEC);
                newPDF.Add(titulo);
                newPDF.Add(subtitulo);
                newPDF.Add(subtituloDatos);
                newPDF.Add(parrafo);
                newPDF.Add(subtituloCurso);
                newPDF.Add(parrafoCurso);
                newPDF.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void drpCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPlan();
        }

        protected void drpPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCursos();
        }

        protected void gvGrupos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Eliminar")
            {
                _listagrupos = (List<ItemGrupo>)Session["listagrupo"];
                int index = Convert.ToInt32(e.CommandArgument);
                _listagrupos.RemoveAt(index);
                Session["listagrupo"] = _listagrupos;
                gvGrupos.DataSource = _listagrupos;
                gvGrupos.DataBind();
            }
        }

        //clase para la lista de grupos
        class ItemGrupo
        {            
            private bool _choque;
            private int _numgrupo;            

            public ItemGrupo(int numgrupo, bool p)
            {
                // TODO: Complete member initialization
                this.numgrupo = numgrupo;
                this.choque = p;
            }

            public int numgrupo
            {
                get { return _numgrupo; }
                set { _numgrupo = value; }
            }
            public bool choque
            {
                get { return _choque; }
                set { _choque = value; }
            }
        }

        protected void chkChoque_CheckedChanged(object sender, EventArgs e)
        {
            int indice = 0;
            _listagrupos = (List<ItemGrupo>)Session["listagrupo"];
            foreach (GridViewRow row in gvGrupos.Rows)
            {
                //CheckBox chk = row.Cells[1].Controls[0] as CheckBox;
                CheckBox chk = (CheckBox)row.Cells[0].FindControl("chkChoque");
                if (chk != null && chk.Checked)
                {
                    _listagrupos[indice].choque = true;
                }
                else if (chk != null && !chk.Checked)
                {
                    _listagrupos[indice].choque = false;
                }
                indice+= 1;
            }

            Session["listagrupo"] = _listagrupos;
            gvGrupos.DataSource = _listagrupos;
            gvGrupos.DataBind();
        }
     

        protected void btnGrupoNuevo_Click(object sender, EventArgs e)
        {
            _listagrupos = (List<ItemGrupo>)Session["listagrupo"];
            ItemGrupo _aux = new ItemGrupo(0, false);
            bool result = _listagrupos.Exists(x => x.numgrupo == 0);

            if (!result)
            {
                _listagrupos.Add(_aux);
            }

            Session["listagrupo"] = _listagrupos;
            gvGrupos.DataSource = _listagrupos;
            gvGrupos.DataBind();
        }


        #region InsertarRegistro


        protected void BtnSuccess_Click(object sender, EventArgs e)
        {
            InclusionDatos _nuevo = new InclusionDatos();
            _nuevo.nombre = TxtName.Text.Trim();
            _nuevo.celular = TxtCellphone.Text.Trim();
            _nuevo.carnet = TxtCarne.Text.Trim();
            _nuevo.telefono = int.Parse(TxtCellphone.Text.Trim());
            _nuevo.correo = TxtEmail.Text.Trim();
            _nuevo.hora = DropDownRegistrationTimeHour.SelectedValue;
            _nuevo.minuto = DropDownRegistrationTimeMinute.SelectedValue;
            _nuevo.dia =  int.Parse(DropDownRegistrationDay.SelectedValue);
            int rnnunn = int.Parse(drpNoRN.SelectedValue);
            _nuevo.rn = (rbsiRN.Checked) ? rnnunn : 0;
            _nuevo.lr = (rbSiLR.Checked) ? true : false;

            int idInsertado = _nuevo.Insertar();
            
            int activo = 1;
            for(int x = 0; x < _listagrupos.Count; x++){
                _nuevo.InsertarGrupo(idInsertado, _listagrupos[x].numgrupo, x, _listagrupos[x].choque, activo);
                activo = 0;                
            }

            Response.Redirect("../ModuloEstudiante/Inicio.aspx");

        }

        #endregion

    }

}