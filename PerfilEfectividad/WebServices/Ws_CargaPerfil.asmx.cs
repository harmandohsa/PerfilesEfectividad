using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Microsoft.VisualBasic;

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

        public class Supervisiones
        {
            public string Puesto { get; set; }
            public int Cantidad { get; set; }
            public int TipoSupervision { get; set; }
        }

        public class Relaciones
        {
            public string Puesto { get; set; }
            public string Proposito { get; set; }
            public int FrecuenciaId { get; set; }
            public int TipoRelacion { get; set; }
        }

        public class ManejoInf
        {
            public string Documento { get; set; }
            public string Accion { get; set; }
            public string TipoInformacion { get; set; }
            public int Jefe { get; set; }
            public int AuditoriaInt { get; set; }
            public int AuditoriaExt { get; set; }
        }

        public class AmbienteTrabajo
        {
            public int TipoAmbienteId { get; set; }
        }


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
            double DineroEfectivo = 0;
            string ResponDineroEfectivo = "";
            double Instrumentos = 0;
            string ResponInstrumentos = "";
            double VehiculoLiviano = 0;
            string ResponVehiculoLiviano = "";
            double VehiculoPesado = 0;
            string ResponVehiculoPesado = "";
            int RelacionInterna = 0;
            int RelacionExterna = 0;
            int ManejoInf = 0;

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
                        if ((i % 2) != 0) //Seccion A
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
                                if (excelPackage.Workbook.Worksheets[i].Cells[40, 10].Text != "")
                                    TomaDecisiones = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[39, 10].Text != "")
                                    TomaDecisiones = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[38, 10].Text != "")
                                    TomaDecisiones = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[37, 10].Text != "")
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
                                if (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text != "")
                                    EsfuerzoMental = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text != "")
                                    EsfuerzoMental = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text != "")
                                    EsfuerzoMental = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text != "")
                                    EsfuerzoMental = 1;

                            }


                            if (excelPackage.Workbook.Worksheets[i].Cells[52, 5].Text != "")
                            {
                                if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[52, 5].Text))
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[52, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[52, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[52, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[52, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Manejo de dinero en efectivo Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Manejo de dinero en efectivo Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        DineroEfectivo = Convert.ToDouble(excelPackage.Workbook.Worksheets[i].Cells[52, 5].Text);
                                        if (excelPackage.Workbook.Worksheets[i].Cells[52, 8].Text != "")
                                            ResponDineroEfectivo = "1";
                                        else
                                            ResponDineroEfectivo = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[52, 9].Text != "")
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",1";
                                        else
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[52, 10].Text != "")
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",1";
                                        else
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",0";
                                    }
                                }
                                else
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Valor de dinero en efectivo debe ser númerico celda E52 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Valor de dinero en efectivo debe ser númerico celda E52 Hoja " + HojaA + "</li>";
                                }
                            }

                            if (excelPackage.Workbook.Worksheets[i].Cells[53, 5].Text != "")
                            {
                                if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[53, 5].Text))
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[53, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[53, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[53, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[53, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Instrumentos, equipo o herramientas especializadas Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Instrumentos, equipo o herramientas especializadas Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        Instrumentos = Convert.ToDouble(excelPackage.Workbook.Worksheets[i].Cells[53, 5].Text);
                                        if (excelPackage.Workbook.Worksheets[i].Cells[53, 8].Text != "")
                                            ResponInstrumentos = "1";
                                        else
                                            ResponInstrumentos = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[53, 9].Text != "")
                                            ResponInstrumentos = ResponInstrumentos + ",1";
                                        else
                                            ResponInstrumentos = ResponInstrumentos + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[53, 10].Text != "")
                                            ResponInstrumentos = ResponInstrumentos + ",1";
                                        else
                                            ResponInstrumentos = ResponInstrumentos + ",0";
                                    }
                                }
                                else
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Valor de Instrumentos, equipo o herramientas especializadas debe ser númerico celda E53 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Valor de Instrumentos, equipo o herramientas especializadas debe ser númerico celda E53 Hoja " + HojaA + "</li>";
                                }
                            }

                            if (excelPackage.Workbook.Worksheets[i].Cells[54, 5].Text != "")
                            {
                                if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[54, 5].Text))
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[54, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[54, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[54, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[54, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Vehículos livianos Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Vehículos livianos Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        VehiculoLiviano = Convert.ToDouble(excelPackage.Workbook.Worksheets[i].Cells[54, 5].Text);
                                        if (excelPackage.Workbook.Worksheets[i].Cells[54, 8].Text != "")
                                            ResponVehiculoLiviano = "1";
                                        else
                                            ResponVehiculoLiviano = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[54, 9].Text != "")
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",1";
                                        else
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[54, 10].Text != "")
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",1";
                                        else
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",0";
                                    }
                                }
                                else
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Valor de Vehículos livianos debe ser númerico celda E54 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Valor de Vehículos livianos debe ser númerico celda E54 Hoja " + HojaA + "</li>";
                                }
                            }

                            if (excelPackage.Workbook.Worksheets[i].Cells[55, 5].Text != "")
                            {
                                if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[55, 5].Text))
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[55, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[55, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[55, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[55, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Vehículos pesados Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Vehículos pesados Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        VehiculoPesado = Convert.ToDouble(excelPackage.Workbook.Worksheets[i].Cells[55, 5].Text);
                                        if (excelPackage.Workbook.Worksheets[i].Cells[55, 8].Text != "")
                                            ResponVehiculoPesado = "1";
                                        else
                                            ResponVehiculoPesado = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[55, 9].Text != "")
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",1";
                                        else
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[55, 10].Text != "")
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",1";
                                        else
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",0";
                                    }
                                }
                                else
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Valor de Vehículos pesados debe ser númerico celda E55 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Valor de Vehículos pesados debe ser númerico celda E55 Hoja " + HojaA + "</li>";
                                }
                            }

                            List<Supervisiones> Datos = new List<Supervisiones>();
                            for (int j = 61; j < 64; j++)
                            {
                                if ((excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text != "") && (excelPackage.Workbook.Worksheets[i].Cells[j, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Puesto de Supervisión Directa: " + excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text + " no se puso la cantida de personas celda J" + j + " Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Puesto de Supervisión Directa: " + excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text + " no se puso la cantida de personas celda J" + j + " Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[j, 10].Text))
                                    {

                                        Supervisiones Registro = new Supervisiones();
                                        Registro.Puesto = excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text;
                                        Registro.Cantidad = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[j, 10].Text);
                                        Registro.TipoSupervision = 1;
                                        Datos.Add(Registro);
                                    }
                                    else
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Puesto de Supervisión Directa: " + excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text + " no tiene un valor númerico en la cantida de personas celda J" + j + " Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Puesto de Supervisión Directa: " + excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text + " no tiene un valor númerico en la cantida de personas celda J" + j + " Hoja " + HojaA + "</li>";
                                    }
                                }

                            }

                            for (int k = 66; k < 69; k++)
                            {
                                if ((excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Puesto de Supervisión Indirecta: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no se puso la cantida de personas celda J" + k + " Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Puesto de Supervisión Indirecta: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no se puso la cantida de personas celda J" + k + " Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text))
                                    {

                                        Supervisiones Registro = new Supervisiones();
                                        Registro.Puesto = excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text;
                                        Registro.Cantidad = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text);
                                        Registro.TipoSupervision = 2;
                                        Datos.Add(Registro);
                                    }
                                    else
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Puesto de Supervisión Indirecta: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no tiene un valor númerico en la cantida de personas celda J" + k + " Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Puesto de Supervisión Indirecta: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no tiene un valor númerico en la cantida de personas celda J" + k + " Hoja " + HojaA + "</li>";
                                    }
                                }

                            }

                            List<Relaciones> DatosRel = new List<Relaciones>();
                            //Relacioes Internas
                            for (int k = 72; k < 75; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[k, 7].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>La Relación de Trabajo Interna: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no se puso la frecuencia celda A" + k + " Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>La Relación de Trabajo Interna: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no se puso la frecuencia celda A" + k + " Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        Relaciones Registro = new Relaciones();
                                        Registro.Puesto = excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text;
                                        Registro.Proposito = excelPackage.Workbook.Worksheets[i].Cells[k, 4].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text != "")
                                            Registro.FrecuenciaId = 4;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text != "")
                                            Registro.FrecuenciaId = 3;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text != "")
                                            Registro.FrecuenciaId = 2;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 7].Text != "")
                                            Registro.FrecuenciaId = 1;
                                        Registro.TipoRelacion = 1;
                                        DatosRel.Add(Registro);
                                    }
                                }
                                

                            }
                            //Relacioes Externas
                            for (int k = 77; k < 80; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[k, 7].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>La Relación de Trabajo Externa: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no se puso la frecuencia celda A" + k + " Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>La Relación de Trabajo Externa: " + excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text + " no se puso la frecuencia celda A" + k + " Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        Relaciones Registro = new Relaciones();
                                        Registro.Puesto = excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text;
                                        Registro.Proposito = excelPackage.Workbook.Worksheets[i].Cells[k, 4].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text != "")
                                            Registro.FrecuenciaId = 4;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text != "")
                                            Registro.FrecuenciaId = 3;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text != "")
                                            Registro.FrecuenciaId = 2;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 7].Text != "")
                                            Registro.FrecuenciaId = 1;
                                        Registro.TipoRelacion = 2;
                                        DatosRel.Add(Registro);
                                    }
                                }
                            }

                            //Valor Relacion Interna
                            if ((excelPackage.Workbook.Worksheets[i].Cells[81, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[82, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[83, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[84, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[85, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[85, 10].Text != "")
                                    RelacionInterna = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[84, 10].Text != "")
                                    RelacionInterna = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[83, 10].Text != "")
                                    RelacionInterna = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[82, 10].Text != "")
                                    RelacionInterna = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[81, 10].Text != "")
                                    RelacionInterna = 1;

                            }

                            //Valor Relacion Externa
                            if ((excelPackage.Workbook.Worksheets[i].Cells[87, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[88, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[89, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text != "")
                                    RelacionExterna = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text != "")
                                    RelacionExterna = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[89, 10].Text != "")
                                    RelacionExterna = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[88, 10].Text != "")
                                    RelacionExterna = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[87, 10].Text != "")
                                    RelacionExterna = 1;

                            }

                            //Manejo Documentos
                            List<ManejoInf> DatosManejoDatos = new List<ManejoInf>();
                            for (int k = 96; k < 99; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    ManejoInf Registro = new ManejoInf();
                                    Registro.Documento = excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text;
                                    Registro.Accion = excelPackage.Workbook.Worksheets[i].Cells[k, 4].Text;
                                    Registro.TipoInformacion = excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text != "")
                                        Registro.Jefe = 1;
                                    else
                                        Registro.Jefe = 0;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text != "")
                                        Registro.AuditoriaInt = 1;
                                    else
                                        Registro.AuditoriaInt = 0;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text != "")
                                        Registro.AuditoriaExt = 1;
                                    else
                                        Registro.AuditoriaExt = 0;
                                    DatosManejoDatos.Add(Registro);
                                }
                            }

                            //Valor Manejo de Información
                            if ((excelPackage.Workbook.Worksheets[i].Cells[100, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[101, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[102, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[103, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[104, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[104, 10].Text != "")
                                    ManejoInf = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[103, 10].Text != "")
                                    ManejoInf = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[102, 10].Text != "")
                                    ManejoInf = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[101, 10].Text != "")
                                    ManejoInf = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[100, 10].Text != "")
                                    ManejoInf = 1;

                            }

                            //Ambiente de Trabajo
                            List<AmbienteTrabajo> AmbienteDatos = new List<AmbienteTrabajo>();
                            int TipoAmbienteId = 1;
                            for (int k = 107; k < 117; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    AmbienteTrabajo Registro = new AmbienteTrabajo();
                                    Registro.TipoAmbienteId = TipoAmbienteId;
                                    AmbienteDatos.Add(Registro);
                                }
                                TipoAmbienteId = TipoAmbienteId + 1;
                            }

                        }
                        else //Seccion B
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
