using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_CargaPerfil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_CargaPerfil : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);

        [WebMethod]
        public string CaptureFile(string Archivo)
        {
            string Error = "";
            bool HayError = false;
            int Dia, Mes, Anis;
            string NombreColaborador = "";
            string NombrePuesto = "";
            string Area = "";
            string PuestoSuperior = "";
            string Jefe = "";
            string FuncionPrincipal = "";
            string FuncionesPrincipales = "";
            string FuncionesDiareas = "";
            string FuncionesQuinSem = "";
            string FuncionesMen = "";
            string FuncionesTri = "";
            string FuncionesAnual = "";
            string FuncionEventual = "";
            int TomaDecisiones = 0;
            int EsfuerzoMental = 0;
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Archivo);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                using (ExcelPackage excelPackage = new ExcelPackage(ms))
                {
                    int a = excelPackage.Workbook.Worksheets.Count;
                    for (int i = 1; i <= a; i+=2)
                    {
                        string HojaA = excelPackage.Workbook.Worksheets[i].Name;
                        string HojaB = excelPackage.Workbook.Worksheets[i+1].Name;
                        if ((i % 2) != 0)
                        {
                            if (excelPackage.Workbook.Worksheets[i].Cells[7, 5].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Día está vacío Celda E7 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Día está vacío Celda E7 Hoja " + HojaA + "</li>";
                            }
                            else
                                Dia = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[7, 5].Text);

                            if (excelPackage.Workbook.Worksheets[i].Cells[7, 7].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Mes está vacío Celda G7 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Mes está vacío Celda G7 Hoja " + HojaA + "</li>";
                            }
                            else
                                Mes = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[7, 7].Text);

                            if (excelPackage.Workbook.Worksheets[i].Cells[7, 9].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Año está vacío Celda I7 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Año está vacío Celda I7 Hoja " + HojaA + "</li>";
                            }
                            else
                                Anis = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[7, 9].Text);

                            NombreColaborador = excelPackage.Workbook.Worksheets[i].Cells[10, 5].Text;
                            if (NombreColaborador == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Nombre está vacío Celda E10 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Nombre está vacío Celda E10 Hoja " + HojaA + "</li>";
                            }
                            NombrePuesto = excelPackage.Workbook.Worksheets[i].Cells[11, 5].Text;
                            if (NombrePuesto == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Puesto está vacío Celda E11 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Puesto está vacío Celda E11 Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                int EsPuesto = ExistePuesto(NombrePuesto);
                                if (EsPuesto > 0)
                                {
                                    HayError = true; 
                                    if (Error == "")
                                        Error = "<ul><li>El Puesto ya existe Celda E11 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Puesto ya existe Celda E11 Hoja " + HojaA + "</li>";
                                }
                            }
                            Area = excelPackage.Workbook.Worksheets[i].Cells[12, 5].Text;
                            if (Area == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Área está vacía Celda E12 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El El Área está vacía Celda E12 Hoja " + HojaA + "</li>";
                            }
                            PuestoSuperior = excelPackage.Workbook.Worksheets[i].Cells[13, 5].Text;
                            if (Area == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Puesto superior está vacío Celda E13 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Area está vacío Celda E13 Hoja " + HojaA + "</li>";
                            }
                            Jefe = excelPackage.Workbook.Worksheets[i].Cells[14, 5].Text;
                            if (Area == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Nombre del Jefe está vacío Celda E14 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Nombre del Jefe está vacío Celda E13 Hoja " + HojaA + "</li>";
                            }
                            if ((excelPackage.Workbook.Worksheets[i].Cells[17, 1].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[18, 1].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>La función principal no puede estar vacía Celdas A17 o A18 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>La función principal no puede estar vacía Celdas A17 o A18 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionPrincipal = excelPackage.Workbook.Worksheets[i].Cells[17, 1].Text + ' ' + excelPackage.Workbook.Worksheets[i].Cells[18, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[21, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes principales no pueden estar vacías Celda A21 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes principales no pueden estar vacías Celda A21 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesPrincipales = excelPackage.Workbook.Worksheets[i].Cells[21, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[23, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes diarias no pueden estar vacías Celda A23 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes diarias no pueden estar vacías Celda A23 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesDiareas = excelPackage.Workbook.Worksheets[i].Cells[23, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[25, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A25 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A25 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesQuinSem = excelPackage.Workbook.Worksheets[i].Cells[25, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Mensuales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Mensuales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesMen = excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[29, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Trimestrales o Semestrales no pueden estar vacías Celda A29 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Trimestrales o Semestrales no pueden estar vacías Celda A29 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesTri = excelPackage.Workbook.Worksheets[i].Cells[29, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[31, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Anuales no pueden estar vacías Celda A31 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Anuales no pueden estar vacías Celda A31 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesAnual = excelPackage.Workbook.Worksheets[i].Cells[31, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[33, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Eventuales u Ocasionales no pueden estar vacías Celda A33 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Eventuales u Ocasionales no pueden estar vacías Celda A33 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionEventual = excelPackage.Workbook.Worksheets[i].Cells[33, 1].Text;

                            if ((excelPackage.Workbook.Worksheets[i].Cells[37, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[38, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[39, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[40, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[41, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Toma de Decisiones Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Toma de Decisiones Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[41, 10].Text != "")
                                    TomaDecisiones = 5;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[40, 10].Text != "")
                                    TomaDecisiones = 4;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[39, 10].Text != "")
                                    TomaDecisiones = 3;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[38, 10].Text != "")
                                    TomaDecisiones = 2;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[37, 10].Text != "")
                                    TomaDecisiones = 1;

                            }

                            if ((excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[48, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Esfuerzo Mental Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Esfuerzo Mental Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[48, 10].Text != "")
                                    EsfuerzoMental = 5;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text != "")
                                    EsfuerzoMental = 4;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text != "")
                                    EsfuerzoMental = 3;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text != "")
                                    EsfuerzoMental = 2;
                                else if (excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text != "")
                                    EsfuerzoMental = 1;

                            }
                        }
                        else
                        {

                        }
                        if (Error != "")
                            Error = Error + "</ul>";
                        else{

                        }
                     
                    }
                }
                return Error;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public int ExistePuesto(string Puesto)
        {
            int Resul = 0;
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();
                Resul = Convert.ToInt32(Comando.Parameters["@Resul"].Value);
                cn.Close();

            }
            catch (Exception ex)
            {
                return 0;
            }
            return Resul;
        }
    }
}
