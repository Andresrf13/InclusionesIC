using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using Inclusiones_IC_Web.AccesoDatos;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class generarreportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerarReporteAdmin_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel2, GetType(), "MostrarFinalizar", "openModal();", true);
            DataTable dtestudiantes;// = new DataTable();
            DatosReporteAYR newData = new DatosReporteAYR();
            List<int> GroupList = newData.SeleccionarIDGrupo();


            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            var SheetCollection = new Microsoft.Office.Interop.Excel.Worksheet[GroupList.Count()];

            //Excel.Worksheet xlWorkSheet;

            object value = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(value);
            // xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (int group = 1; group < GroupList.Count(); group++)
            {
                SheetCollection[group] = xlWorkBook.Worksheets.Add();

                #region Plantilla
                chartRange = SheetCollection[group].get_Range("b4", "j9");
                SheetCollection[group].Cells[2, 2] = "Ingenieria en Computación";
                SheetCollection[group].Cells[2, 7] = "Resultado de Inclusiones";
                SheetCollection[group].Cells[4, 2] = "Sede";
                SheetCollection[group].Cells[4, 9] = "Año";
                SheetCollection[group].Cells[4, 10] = DateTime.Now.Year.ToString();
                SheetCollection[group].Cells[5, 2] = "Código";
                SheetCollection[group].Cells[5, 3] = "Descripción";
                SheetCollection[group].Cells[5, 6] = "Periodo";
                SheetCollection[group].Cells[5, 9] = "Modalidad";
                SheetCollection[group].Cells[6, 9] = "Semestre";
                SheetCollection[group].Cells[5, 2] = "Grupo";
                SheetCollection[group].Cells[7, 7] = "Se autoriza la inclusión con";
                SheetCollection[group].Cells[8, 2] = "Carné";
                SheetCollection[group].Cells[8, 3] = "Nombre del Estudiante";
                SheetCollection[group].Cells[8, 7] = "RN";
                SheetCollection[group].Cells[8, 8] = "LR";
                SheetCollection[group].Cells[8, 9] = "LC";
                SheetCollection[group].Cells[8, 10] = "CH";
                #endregion

                dtestudiantes = newData.SeleccionarPorGrupo(GroupList[group]);

                #region Llenado desde la base de datos
                int counterRow = 9;
                int counterRowForStyle = dtestudiantes.Rows.Count;
                foreach (DataRow row in dtestudiantes.Rows)
                {

                    string Sede = row["Sede"].ToString();
                    SheetCollection[group].Cells[4, 2] = Sede;
                    string Descrip = row["Curso"].ToString();
                    SheetCollection[group].Cells[6, 3] = Descrip;
                    string Codigo = row["Codigo"].ToString();
                    SheetCollection[group].Cells[6, 2] = Codigo;
                    SheetCollection[group].Name = Codigo;
                    string Periodo = row["Periodo"].ToString();
                    SheetCollection[group].Cells[6, 6] = Periodo;


                    string Nombre = row["Estudiante"].ToString();
                    SheetCollection[group].Cells[counterRow, 3] = Nombre;
                    string Carne = row["Carnet"].ToString();
                    SheetCollection[group].Cells[counterRow, 2] = Carne;


                    string RN = row["RN"].ToString();
                    if (!RN.Equals("0"))
                    {
                        SheetCollection[group].Cells[counterRow, 7] = RN;
                    }

                    string LR = row["LR"].ToString();
                    if (!LR.Equals("False"))
                    {
                        SheetCollection[group].Cells[counterRow, 8] = "X";
                    }

                    string CH = row["CH"].ToString();
                    if (!CH.Equals("False"))
                    {
                        SheetCollection[group].Cells[counterRow, 10] = "X";
                    }

                    counterRow++;
                    //}
                }
                #endregion

                #region estilos

                chartRange = SheetCollection[group].get_Range("b2", "z2");
                chartRange.Font.Bold = true;
                chartRange.Font.Name = "Agency FB";
                chartRange.Font.Size = 18;

                chartRange = SheetCollection[group].get_Range("b4", "j4");
                chartRange.Font.Bold = true;
                chartRange.Cells.Interior.Color = 1;
                chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                chartRange = SheetCollection[group].get_Range("b7", "j7");
                chartRange.Font.Bold = true;
                chartRange.Cells.Interior.Color = 1;
                chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                chartRange = SheetCollection[group].get_Range("b4", "j" + Convert.ToString(counterRowForStyle + 8));
                chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                chartRange.Font.Name = "Agency FB";
                chartRange.Font.Size = 14;
                chartRange.Rows.AutoFit();
                //chartRange.Rows.AutoFit();
                chartRange = SheetCollection[group].get_Range("g8", "g11");
                chartRange.Rows.AutoFit();
                chartRange = SheetCollection[group].get_Range("i8", "i11");
                chartRange.Rows.AutoFit();

                #endregion


            }
            #region guardado y cerrado
            xlWorkBook.SaveAs(Server.MapPath("Resultado Inclusiones IC.xls"), Excel.XlFileFormat.xlWorkbookNormal, value, value, value, value, Excel.XlSaveAsAccessMode.xlExclusive, value, value, value, value, value);
            xlWorkBook.Close(true, value, value);
            xlApp.Quit();
            #endregion

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            for (int group2 = 1; group2 < GroupList.Count(); group2++)
            {
                releaseObject(SheetCollection[group2]);
            }

        }


        protected void BtnDescargarExcel_Click(object sender, EventArgs e)
        {

            string filename = Server.MapPath("Resultado Inclusiones IC.xls");
            FileInfo fileInfo = new FileInfo(filename);


            if (fileInfo.Exists)
            {                
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/vnd.ms-excel";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                ScriptManager.RegisterStartupScript(this.UpdatePanel2, GetType(), "MostrarFinalizar", "closeModal();", true);
                Response.End();
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;

            }
            finally
            {
                GC.Collect();
            }
        }
    }
}