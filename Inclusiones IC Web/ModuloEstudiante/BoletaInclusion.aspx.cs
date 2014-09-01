using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Inclusiones_IC_Web.ModuloEstudiante
{
    public partial class BoletaInclusion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnAddGrupo_Click(object sender, EventArgs e)
        {

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
            LabelVisualizarHora.Text = DropDownRegistrationTimeHour.SelectedValue;
            LabelVisualizarMinutos.Text = DropDownRegistrationTimeMinute.SelectedValue;

            if (rbsiRN.Checked)
            {
                LabelVisualizarRN.Text = "Si";
                LabelVisualizarNumeroRN.Text = drpNoRN.SelectedValue;
            }

            LabelVisualizarPlan.Text = drpPlan.SelectedValue;
            LabelVisualizarSede.Text = DropDownSede.SelectedValue;
            LabelVisualizarCarrera.Text = drpCarrera.SelectedValue;
            LabelVisualizarComentario.Text = TxtComentario.Text;
            if (rbSiLR.Checked)
            {
                LabelVisualizarRequisitos.Text = "Si";
                if(rbSiLRProceso.Checked)
                {
                    LabelVisualizarCumpleRequisitos.Text = "Si, realizó el proceso de levantamiento de requisitos";
                }
                if(rbSiLRCursos.Checked)
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
                var titleFont = FontFactory.GetFont("Aial", 18, Font.BOLD);

                var titulo = new Paragraph("Escuela de Ingeniería en Computación", titleFont);
                var subtitulo = new Paragraph("Boleta de Inclusión \r\n \r\n --------------------------------------------------------- \r\nDatos Personales \r\n\r\n", titleFont);
                var parrafo = new Paragraph("- Nombre: " + LabelVisualizadorNombre.Text + "\r\n" +
                                            "- Carné: " + LabelVisualizadorCarne.Text + "\r\n" +
                                            "- E-mail: " + LabelVisualizarEmail.Text + "\r\n" +
                                            "- Celular: " + LabelVisualizarCelular.Text + "\r\n" +
                                            "- Teléfono: " + LabelVisualizarTelefono.Text + "\r\n"
                                          + "- Sede: " + LabelVisualizarSede.Text + "\r\n"
                                          + "- Día de matrícula: " + LabelVisualizarDiaMatricula.Text + "\r\n"
                                          + "- Hora de matrícula: " + LabelVisualizarHora.Text + ":" + LabelVisualizarMinutos.Text + "\r\n");
                var subtituloCurso = new Paragraph("--------------------------------------------------------- \r\nDatos del Curso \r\n\r\n", titleFont);
                var parrafoCurso = new Paragraph("- Sede: " + LabelVisualizarSede.Text + "\r\n"
                                               + "- Carrera: " + LabelVisualizarCarrera.Text + "\r\n"
                                               + "- Plan de estudios: " + LabelVisualizarPlan.Text + "\r\n"
                                               + "- Curso: " + LabelVisualizarCurso.Text + "\r\n"
                                               + "- Grupos: " + LabelVisualizarGrupo.Text + "\r\n"
                                               + "- RN: " + LabelVisualizarRN.Text + "\r\n"
                                               + "- Cumple con requisitos: " + LabelVisualizarCumpleRequisitos.Text + "\r\n"
                                               + "- Comentario: " + LabelVisualizarComentario.Text);

                newPDF.Add(titulo);
                newPDF.Add(subtitulo);
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

    }
}