using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace Inclusiones_IC_Web.ModuloComite
{
    public partial class generarreportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerarReporteAdmin_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            object value = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(value);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            #region Plantilla
            chartRange = xlWorkSheet.get_Range("b4", "j9");
            xlWorkSheet.Cells[2, 2] = "Ingenieria en Computación";
            xlWorkSheet.Cells[2, 8] = "Resultado de Inclusiones";
            xlWorkSheet.Cells[4, 2] = "Sede";
            xlWorkSheet.Cells[4, 9] = "Año";
            xlWorkSheet.Cells[4, 10] = DateTime.Now.Year.ToString();
            xlWorkSheet.Cells[5, 2] = "Código";
            xlWorkSheet.Cells[5, 4] = "Descripción";
            xlWorkSheet.Cells[5, 6] = "Periodo";
            xlWorkSheet.Cells[5, 9] = "Modalidad";
            xlWorkSheet.Cells[5, 2] = "Grupo";
            xlWorkSheet.Cells[6, 7] = "Se autoriza la inclusión con";
            xlWorkSheet.Cells[7, 2] = "Carné";
            xlWorkSheet.Cells[7, 3] = "Nombre del Estudiante";
            xlWorkSheet.Cells[7, 7] = "RN";
            xlWorkSheet.Cells[7, 8] = "LR";
            xlWorkSheet.Cells[7, 9] = "LC";
            xlWorkSheet.Cells[7, 10] = "CH";
            #endregion

            #region Llenado desde la base de datos

            #endregion

            #region estilos

            chartRange = xlWorkSheet.get_Range("b2", "z2");
            chartRange.Font.Bold = true;
            chartRange.Font.Name = "Agency FB";
            chartRange.Font.Size = 18;

            chartRange = xlWorkSheet.get_Range("b4", "j4");
            chartRange.Font.Bold = true;
            chartRange.Cells.Interior.Color = 1;
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            chartRange = xlWorkSheet.get_Range("b4", "j9");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            chartRange.Font.Name = "Agency FB";
            chartRange.Font.Size = 14;
            chartRange.Rows.AutoFit();
            //chartRange.Columns.AutoFit();
            #endregion

            #region guardado y cerrado
            xlWorkBook.SaveAs(Server.MapPath("Resultado Inclusiones IC.xls"), Excel.XlFileFormat.xlWorkbookNormal, value, value, value, value, Excel.XlSaveAsAccessMode.xlExclusive, value, value, value, value, value);
            xlWorkBook.Close(true, value, value);
            xlApp.Quit();
            #endregion

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);

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