using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;
using System.Net.Mail;


namespace Inclusiones_IC_Web.ModuloEstudiante
{
    public partial class BoletaInclusion : System.Web.UI.Page
    {
        List<ItemGrupo> _listagrupos;
        int idgruponuevo = 0; //esto esta ligado en la base de datos -.-
        protected void Page_Load(object sender, EventArgs e)
        {
            PeriodoDatos _aux = new PeriodoDatos();
            string _peri = _aux.PeriodoActual();
            if (_peri.Equals("NO hay período Actual"))
            {
                string script = "<script type = 'text/javascript'>alert('Error, periodo actual no definido') ;window.location.href ='../ModuloEstudiante/Inicio.aspx';</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", script.ToString());
                //Response.Redirect("~/ModuloEstudiante/Inicio.aspx");
            }
            else
            {
                lblPeriodoshow.Text = _peri;
            }

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
            if (drpCarrera.Items.Count > 0)
            {
                drpCursos.Items.Clear();
                Cursos _aux = new Cursos();
                DataTable _dtCursos = _aux.SeleccionarCursoxPlan(int.Parse(drpCarrera.SelectedValue.ToString()), int.Parse(drpPlan.SelectedValue.ToString()));
                drpCursos.DataSource = _dtCursos;
                drpCursos.DataValueField = "idCurso";
                drpCursos.DataTextField = "Nombre";
                drpCursos.DataBind();
                cargarGrupos();
            }            
        }

        private void cargarGrupos()
        {
            if (drpCursos.Items.Count > 0)
            {
                drpGrupo.Items.Clear();
                GruposDatos _aux = new GruposDatos();
                _aux.id = Convert.ToInt32(drpCursos.SelectedValue);
                DataTable _dtGrupos = _aux.SeleccionarTodos();
                drpGrupo.DataSource = _dtGrupos;
                drpGrupo.DataValueField = "idGrupo";
                drpGrupo.DataTextField = "Numero";
                drpGrupo.DataBind();
            }
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
            if(drpGrupo.Items.Count > 0)
            {
                _listagrupos = (List<ItemGrupo>)Session["listagrupo"];
                int numgrupo = int.Parse(drpGrupo.SelectedValue.ToString());
                int show = int.Parse(drpGrupo.SelectedItem.Text);
                bool result = _listagrupos.Exists(x => x.numgrupo == numgrupo);
                if (!result)
                {
                    ItemGrupo nuevo = new ItemGrupo(numgrupo, show, false);
                    _listagrupos.Add(nuevo);
                    Session["listagrupo"] = _listagrupos;
                    gvGrupos.DataSource = _listagrupos;
                    gvGrupos.DataBind();
                }            
            }           
        }

        protected void rbSiLR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoLR.Checked)
            {
                divLRPeriodo.Visible = false;
                btnVisualizar.Enabled = false;
            }
            else if (rbSiLR.Checked)
            {
                divLRPeriodo.Visible = true;
                btnVisualizar.Enabled = true;
            }
        }

        protected void btnVisualizar_Click(object sender, EventArgs e)
        {
            Page.Validate("validar");
            if (Page.IsValid)
            {
                if (gvGrupos.Rows.Count > 0) //debe de haber al nnenos un grupo donde hacer la inclusion
                {
                    divBoleta.Visible = false;
                    divVisualizador.Visible = true;

                    LabelVisualizadorNombre.Text = TxtName.Text;
                    LabelVisualizadorCarne.Text = TxtCarne.Text;
                    LabelVisualizarEmail.Text = TxtEmail.Text;
                    LabelVisualizarTelefono.Text = TxtPhone.Text;
                    LabelVisualizarCelular.Text = TxtCellphone.Text;
                    LabelVisualizarDiaMatricula.Text = DropDownRegistrationDay.SelectedValue;
                    LabelVisualizarHora.Text = DropDownRegistrationTimeHour.SelectedValue + ":" + DropDownRegistrationTimeMinute.SelectedValue;

                    LabelVisualizarRN.Text = (rbsiRN.Checked) ? "Sí" : "No";
                    LabelVisualizarNumeroRN.Text = (rbsiRN.Checked) ? drpNoRN.SelectedValue : "0";
                    LabelVisualizarPlan.Text = drpPlan.SelectedItem.Text;
                    LabelVisualizarSede.Text = drpSedes.SelectedItem.Text;
                    LabelVisualizarCarrera.Text = drpCarrera.SelectedItem.Text;
                    LabelVisualizarComentario.Text = TxtComentario.Text;
                    LabelVisualizarCurso.Text = drpCursos.SelectedItem.Text;
                    LabelVisualizarGrupo.Text = "";
                    for (int x = 0; x < _listagrupos.Count; x++)
                    {
                        string choca = ((bool)_listagrupos[x].choque) ? "Choca" : "No choca";
                        if (x == 0)
                        {
                            LabelVisualizarGrupo.Text += " #Grupo: " + _listagrupos[x].show.ToString() + " " + choca;
                        }
                        else
                        {
                            LabelVisualizarGrupo.Text += ", #Grupo: " + _listagrupos[x].show.ToString() + " " + choca;
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
                else
                {
                   string script = "<script type = 'text/javascript'>alert('Error, periodo actual no definido')</script>";
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "NO_Grupos", script.ToString());
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "alertMessage", script.ToString(), true);
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
            //IMGcargando.Visible = true;
            pdfenviar();
            
        }

        private void pdfenviar()
        {
            ImprimirPDF();
            sendEmail();
            Response.Redirect("../ModuloEstudiante/Inicio.aspx");
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
            private int _show;

            
            public ItemGrupo(int numgrupo, int show, bool p)
            {
                // TODO: Complete member initialization
                this.numgrupo = numgrupo;
                this.choque = p;
                this._show = show;
            }

            public int show
            {
                get { return _show; }
                set { _show = value; }
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
            ItemGrupo _aux = new ItemGrupo(idgruponuevo, 0, false);
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
            BtnSuccess.Enabled = false;
            BtnSuccess.Text = "Espere...";
            insertarBoleta();
            
           
        }

        private void insertarBoleta()
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "MostrarFinalizar", "openModal();", true);


                InclusionDatos _nuevo = new InclusionDatos();
                _nuevo.nombre = TxtName.Text.Trim();
                _nuevo.celular = TxtCellphone.Text.Trim();
                _nuevo.carnet = TxtCarne.Text.Trim();
                _nuevo.telefono = int.Parse(TxtCellphone.Text.Trim());
                _nuevo.correo = TxtEmail.Text.Trim();
                _nuevo.hora = DropDownRegistrationTimeHour.SelectedValue;
                _nuevo.minuto = DropDownRegistrationTimeMinute.SelectedValue;
                _nuevo.dia = int.Parse(DropDownRegistrationDay.SelectedValue);
                int rnnunn = (rbnoRN.Checked) ? 0 : int.Parse(drpNoRN.SelectedValue);
                _nuevo.rn = (rbsiRN.Checked) ? rnnunn : 0;
                _nuevo.lr = (rbSiLRProceso.Checked) ? true : false;
                _nuevo.connentario = TxtComentario.Text.Trim();
                _nuevo.sede = int.Parse(drpSedes.SelectedValue.ToString());

                int idEstudiante = default(int);
                int.TryParse(Session["idEstudiante"].ToString(), out idEstudiante);
                _nuevo.idEstudiante = idEstudiante;
                int idPersona = default(int);
                int.TryParse(Session["idEstudiante"].ToString(), out idPersona);
                _nuevo.idPersona = idPersona;
            
                int idInsertado = _nuevo.Insertar();

                if (idInsertado != -1)
                {
                    int activo = 1;
                    for (int x = 0; x < _listagrupos.Count; x++)
                    {
                        _nuevo.InsertarGrupo(idInsertado, _listagrupos[x].numgrupo, x + 1, _listagrupos[x].choque, activo);
                        activo = 0;
                    }

                    divpdf.Visible = true;
                    BtnRegresar.Visible = false;
                    BtnSuccess.Visible = false;

                }
            }
            catch (Exception)
            {
                BtnSuccess.Text = "Enviar";
                BtnSuccess.Enabled = true;
                string script = "<script type = 'text/javascript'>alert('Error al generar la solicitud, revise sus datos');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error_generar", script.ToString());
            }
        }

        #endregion

        protected void drpCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCursos.Items.Count > 0)
            {
                drpGrupo.Items.Clear();
                GruposDatos _aux = new GruposDatos();
                _aux.id = Convert.ToInt32(drpCursos.SelectedValue);
                DataTable _dtGrupos = _aux.SeleccionarTodos();
                drpGrupo.DataSource = _dtGrupos;
                drpGrupo.DataValueField = "idGrupo";
                drpGrupo.DataTextField = "Numero";
                drpGrupo.DataBind();
            }            
            _listagrupos.Clear();
            Session["listagrupo"] = _listagrupos;
            gvGrupos.DataSource = _listagrupos;
            gvGrupos.DataBind();
        }

        public void ImprimirPDF()
        {
            try
            {

                var newPDF = new Document(PageSize.A4, 50, 50, 25, 25);
                var output = new FileStream(Server.MapPath(LabelVisualizadorCarne.Text + ".pdf"), FileMode.CreateNew);
                var writer = PdfWriter.GetInstance(newPDF, output);

                newPDF.Open();
                var titleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 16, Font.BOLD, CMYKColor.DARK_GRAY);
                var subTitleFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, Font.BOLD, CMYKColor.GRAY);
                var paraFont = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12, Font.NORMAL);
                var titulo = new Paragraph("                                 Escuela de Ingeniería en Computación", titleFont);
                var subtitulo = new Paragraph("                             Boleta de Inclusión - " + DateTime.Now.ToLongDateString() + "\r\n \r\n", subTitleFont);
                var subtitulo2 = new Paragraph("                             Periodo: " + lblPeriodoshow.Text + "\r\n \r\n", subTitleFont);
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
                newPDF.Add(titulo);
                newPDF.Add(subtitulo);
                newPDF.Add(subtitulo2); 
                newPDF.Add(subtituloDatos);
                newPDF.Add(parrafo);
                newPDF.Add(subtituloCurso);
                newPDF.Add(parrafoCurso);
                newPDF.Close();
            }
            catch (Exception e)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + e.Message + "');", true);
            }
        }



        public void sendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("inclusiones.ic.teccr@gmail.com");
                mail.To.Add(LabelVisualizarEmail.Text);
                mail.Subject = "Boleta Inclusión - " + DateTime.Now.ToLongDateString();
                mail.Body = "Escuela de Ingeniería en Computación";

                System.Net.Mail.Attachment newAttachment;
                newAttachment = new System.Net.Mail.Attachment(Server.MapPath(LabelVisualizadorCarne.Text + ".pdf"));
                mail.Attachments.Add(newAttachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("inclusiones.ic.teccr@gmail.com", "inclusiones");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Se ha enviado un correo a tu cuenta');", true);
            }
            catch (Exception e)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + e.Message + "');", true);
            }
        }


        protected void TxtCarne_OnTextChanged(object sender, EventArgs e)
        {
            InclusionDatos _aux = new InclusionDatos();            
            _aux.carnet = TxtCarne.Text.Trim();
            _aux.getInfoEstudiante();

            TxtName.Text = _aux.nombre;
            TxtCellphone.Text = _aux.celular;
            TxtPhone.Text = _aux.telefono.ToString();
            TxtEmail.Text = _aux.correo;
            Session["idPersona"] = _aux.idPersona;
            Session["idEstudiante"] = _aux.idEstudiante;

        }
    }

}