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

        public class RiesgoOcupacional
        {
            public int RiesgoOcupacionalId { get; set; }
        }

        public class EsfuerzoFisico
        {
            public int EsfuerzoFisicoId { get; set; }
        }

        public class CursosTecnicos
        {
            public string Curso { get; set; }
            public string Duracion { get; set; }
        }

        public class Idiomas
        {
            public string Idioma { get; set; }
            public int DominioId { get; set; }
        }

        public class Experiencia
        {
            public string TipoTrabajo { get; set; }
            public string Tiempo { get; set; }
        }

        [WebMethod]
        public string CaptureFile(string Archivo, bool Opcion)
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
            string DineroEfectivo = "";
            string ResponDineroEfectivo = "";
            string Instrumentos = "";
            string ResponInstrumentos = "";
            string VehiculoLiviano = "";
            string ResponVehiculoLiviano = "";
            string VehiculoPesado = "";
            string ResponVehiculoPesado = "";
            int RelacionInterna = 0;
            int RelacionExterna = 0;
            int ManejoInf = 0;
            int EducacionFormalId = 0;
            string Carrera = "";
            int ImpactoErrorId = 0;
            string OtrosEstudios = "";
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Archivo);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                using (ExcelPackage excelPackage = new ExcelPackage(ms))
                {
                    int a = excelPackage.Workbook.Worksheets.Count;
                    if (Opcion)
                    {
                        for (int i = 1; i <= a; i++)
                        {
                            string HojaA = excelPackage.Workbook.Worksheets[i].Name;

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
                                if (Information.IsNumeric(excelPackage.Workbook.Worksheets[i].Cells[7, 7].Text))
                                    Mes = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[7, 7].Text);
                            else
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Mes debe ser un dato númerico Celda G7 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Mes debe ser un dato númerico Celda G7 Hoja " + HojaA + "</li>";
                            }

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

                            //Funciones
                            if (excelPackage.Workbook.Worksheets[i].Cells[17, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>La función principal no puede estar vacía Celdas A17 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>La función principal no puede estar vacía Celdas A17 Hoja " + HojaA + "</li>";
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

                            if (excelPackage.Workbook.Worksheets[i].Cells[24, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes diarias no pueden estar vacías Celda A24 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes diarias no pueden estar vacías Celda A24 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesDiareas = excelPackage.Workbook.Worksheets[i].Cells[24, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesQuinSem = excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[30, 1].Text == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>Las funciónes Mensuales no pueden estar vacías Celda A30 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>Las funciónes Mensuales no pueden estar vacías Celda A30 Hoja " + HojaA + "</li>";
                            }
                            else
                                FuncionesMen = excelPackage.Workbook.Worksheets[i].Cells[30, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[33, 1].Text == "")
                            {
                                FuncionesTri = "";
                            }
                            else
                                FuncionesTri = excelPackage.Workbook.Worksheets[i].Cells[33, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[36, 1].Text == "")
                            {
                                FuncionesAnual = "";
                            }
                            else
                                FuncionesAnual = excelPackage.Workbook.Worksheets[i].Cells[36, 1].Text;

                            if (excelPackage.Workbook.Worksheets[i].Cells[39, 1].Text == "")
                            {
                                FuncionEventual = "";
                            }
                            else
                                FuncionEventual = excelPackage.Workbook.Worksheets[i].Cells[39, 1].Text;

                            //Toma de Desiciones
                            if ((excelPackage.Workbook.Worksheets[i].Cells[43, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Toma de Decisiones Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Toma de Decisiones Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text != "")
                                    TomaDecisiones = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text != "")
                                    TomaDecisiones = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text != "")
                                    TomaDecisiones = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text != "")
                                    TomaDecisiones = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[43, 10].Text != "")
                                    TomaDecisiones = 1;

                            }

                            //Esfuerzo Mental
                            if ((excelPackage.Workbook.Worksheets[i].Cells[50, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[51, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[52, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[53, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[54, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Esfuerzo Mental Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Esfuerzo Mental Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[54, 10].Text != "")
                                    EsfuerzoMental = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[53, 10].Text != "")
                                    EsfuerzoMental = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[52, 10].Text != "")
                                    EsfuerzoMental = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[51, 10].Text != "")
                                    EsfuerzoMental = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[50, 10].Text != "")
                                    EsfuerzoMental = 1;

                            }

                            //Manejo de Dinero
                            if (excelPackage.Workbook.Worksheets[i].Cells[58, 5].Text != "")
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[58, 5].Text != "")
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[58, 8].Text == "" && excelPackage.Workbook.Worksheets[i].Cells[58, 9].Text == "" && excelPackage.Workbook.Worksheets[i].Cells[58, 10].Text == "")
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Manejo de dinero en efectivo Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Manejo de dinero en efectivo Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        DineroEfectivo = excelPackage.Workbook.Worksheets[i].Cells[58, 5].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[58, 8].Text != "")
                                            ResponDineroEfectivo = "1";
                                        else
                                            ResponDineroEfectivo = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[58, 9].Text != "")
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",1";
                                        else
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[58, 10].Text != "")
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",1";
                                        else
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",0";
                                    }
                                }
                                
                            }

                            if (excelPackage.Workbook.Worksheets[i].Cells[59, 5].Text != "")
                            {
                                if ((excelPackage.Workbook.Worksheets[i].Cells[59, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[59, 8].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[59, 9].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[59, 10].Text == "")))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Instrumentos, equipo o herramientas especializadas Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Instrumentos, equipo o herramientas especializadas Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    Instrumentos = excelPackage.Workbook.Worksheets[i].Cells[59, 5].Text;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[59, 8].Text != "")
                                        ResponInstrumentos = "1";
                                    else
                                        ResponInstrumentos = "0";
                                    if (excelPackage.Workbook.Worksheets[i].Cells[59, 9].Text != "")
                                        ResponInstrumentos = ResponInstrumentos + ",1";
                                    else
                                        ResponInstrumentos = ResponInstrumentos + ",0";
                                    if (excelPackage.Workbook.Worksheets[i].Cells[59, 10].Text != "")
                                        ResponInstrumentos = ResponInstrumentos + ",1";
                                    else
                                        ResponInstrumentos = ResponInstrumentos + ",0";
                                }
                            }

                            if (excelPackage.Workbook.Worksheets[i].Cells[60, 5].Text != "")
                            {
                                if ((excelPackage.Workbook.Worksheets[i].Cells[60, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[60, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[60, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[60, 10].Text == "")))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Vehículos livianos Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Vehículos livianos Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    VehiculoLiviano = excelPackage.Workbook.Worksheets[i].Cells[60, 5].Text;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[60, 8].Text != "")
                                        ResponVehiculoLiviano = "1";
                                    else
                                        ResponVehiculoLiviano = "0";
                                    if (excelPackage.Workbook.Worksheets[i].Cells[60, 9].Text != "")
                                        ResponVehiculoLiviano = ResponVehiculoLiviano + ",1";
                                    else
                                        ResponVehiculoLiviano = ResponVehiculoLiviano + ",0";
                                    if (excelPackage.Workbook.Worksheets[i].Cells[60, 10].Text != "")
                                        ResponVehiculoLiviano = ResponVehiculoLiviano + ",1";
                                    else
                                        ResponVehiculoLiviano = ResponVehiculoLiviano + ",0";
                                }
                            }

                            if (excelPackage.Workbook.Worksheets[i].Cells[61, 5].Text != "")
                            {
                                if ((excelPackage.Workbook.Worksheets[i].Cells[61, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[61, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[61, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[61, 10].Text == "")))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Vehículos pesados Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Vehículos pesados Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    VehiculoPesado = excelPackage.Workbook.Worksheets[i].Cells[61, 5].Text;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[61, 8].Text != "")
                                        ResponVehiculoPesado = "1";
                                    else
                                        ResponVehiculoPesado = "0";
                                    if (excelPackage.Workbook.Worksheets[i].Cells[61, 9].Text != "")
                                        ResponVehiculoPesado = ResponVehiculoPesado + ",1";
                                    else
                                        ResponVehiculoPesado = ResponVehiculoPesado + ",0";
                                    if (excelPackage.Workbook.Worksheets[i].Cells[61, 10].Text != "")
                                        ResponVehiculoPesado = ResponVehiculoPesado + ",1";
                                    else
                                        ResponVehiculoPesado = ResponVehiculoPesado + ",0";
                                }
                            }

                            //Supervisiones Internas y Externas
                            List<Supervisiones> Datos = new List<Supervisiones>();
                            for (int j = 67; j < 70; j++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[j, 1].Text != "")
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

                                

                            }

                            for (int k = 72; k < 75; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
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

                                

                            }

                            List<Relaciones> DatosRel = new List<Relaciones>();
                            //Relacioes Internas
                            for (int k = 78; k < 81; k++)
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
                            for (int k = 83; k < 86; k++)
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
                            if ((excelPackage.Workbook.Worksheets[i].Cells[87, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[88, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[89, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text != "")
                                    RelacionInterna = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text != "")
                                    RelacionInterna = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[89, 10].Text != "")
                                    RelacionInterna = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[88, 10].Text != "")
                                    RelacionInterna = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[87, 10].Text != "")
                                    RelacionInterna = 1;

                            }

                            //Valor Relacion Externa
                            if ((excelPackage.Workbook.Worksheets[i].Cells[93, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[94, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[95, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[96, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[97, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[97, 10].Text != "")
                                    RelacionExterna = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[96, 10].Text != "")
                                    RelacionExterna = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[95, 10].Text != "")
                                    RelacionExterna = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[94, 10].Text != "")
                                    RelacionExterna = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[93, 10].Text != "")
                                    RelacionExterna = 1;

                            }

                            //Manejo Documentos
                            List<ManejoInf> DatosManejoDatos = new List<ManejoInf>();
                            for (int k = 102; k < 105; k++)
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
                            if ((excelPackage.Workbook.Worksheets[i].Cells[106, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[107, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[108, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[109, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[110, 10].Text == ""))
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                            }
                            else
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[110, 10].Text != "")
                                    ManejoInf = 5;
                                if (excelPackage.Workbook.Worksheets[i].Cells[111, 10].Text != "")
                                    ManejoInf = 4;
                                if (excelPackage.Workbook.Worksheets[i].Cells[112, 10].Text != "")
                                    ManejoInf = 3;
                                if (excelPackage.Workbook.Worksheets[i].Cells[113, 10].Text != "")
                                    ManejoInf = 2;
                                if (excelPackage.Workbook.Worksheets[i].Cells[114, 10].Text != "")
                                    ManejoInf = 1;

                            }

                            //Ambiente de Trabajo
                            List<AmbienteTrabajo> AmbienteDatos = new List<AmbienteTrabajo>();
                            int TipoAmbienteId = 1;
                            for (int k = 113; k < 123; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    AmbienteTrabajo Registro = new AmbienteTrabajo();
                                    Registro.TipoAmbienteId = TipoAmbienteId;
                                    AmbienteDatos.Add(Registro);
                                }
                                TipoAmbienteId = TipoAmbienteId + 1;
                            }

                            for (int k = 113; k < 122; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                {
                                    AmbienteTrabajo Registro = new AmbienteTrabajo();
                                    Registro.TipoAmbienteId = TipoAmbienteId;
                                    AmbienteDatos.Add(Registro);
                                }
                                TipoAmbienteId = TipoAmbienteId + 1;
                            }

                            //RiesgoOcupacional
                            List<RiesgoOcupacional> RiesgoDatos = new List<RiesgoOcupacional>();
                            int TipoRiesgoId = 1;
                            for (int k = 125; k < 134; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    RiesgoOcupacional Registro = new RiesgoOcupacional();
                                    Registro.RiesgoOcupacionalId = TipoRiesgoId;
                                    RiesgoDatos.Add(Registro);
                                }
                                TipoRiesgoId = TipoRiesgoId + 1;
                            }

                            for (int k = 125; k < 134; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                {
                                    RiesgoOcupacional Registro = new RiesgoOcupacional();
                                    Registro.RiesgoOcupacionalId = TipoRiesgoId;
                                    RiesgoDatos.Add(Registro);
                                }
                                TipoRiesgoId = TipoRiesgoId + 1;
                            }

                            //EsfuerzoFisico
                            List<EsfuerzoFisico> EsfuerzoFisicoDatos = new List<EsfuerzoFisico>();
                            int TipoEsfuerzoId = 1;
                            for (int k = 136; k < 143; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                {
                                    EsfuerzoFisico Registro = new EsfuerzoFisico();
                                    Registro.EsfuerzoFisicoId = TipoEsfuerzoId;
                                    EsfuerzoFisicoDatos.Add(Registro);
                                }
                                TipoEsfuerzoId = TipoEsfuerzoId + 1;
                            }

                            for (int k = 136; k < 144; k++)
                            {
                                if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                {
                                    EsfuerzoFisico Registro = new EsfuerzoFisico();
                                    Registro.EsfuerzoFisicoId = TipoEsfuerzoId;
                                    EsfuerzoFisicoDatos.Add(Registro);
                                }
                                TipoEsfuerzoId = TipoRiesgoId + 1;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= a; i += 2)
                        {
                            string HojaA = excelPackage.Workbook.Worksheets[i].Name;
                            string HojaB = excelPackage.Workbook.Worksheets[i + 1].Name;
                            if ((i % 2) != 0) //Seccion A
                            {
                                //Seccion Principal
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

                                //Funciones
                                if (excelPackage.Workbook.Worksheets[i].Cells[17, 1].Text == "")
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>La función principal no puede estar vacía Celdas A17 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>La función principal no puede estar vacía Celdas A17 Hoja " + HojaA + "</li>";
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

                                if (excelPackage.Workbook.Worksheets[i].Cells[24, 1].Text == "")
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>Las funciónes diarias no pueden estar vacías Celda A24 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>Las funciónes diarias no pueden estar vacías Celda A24 Hoja " + HojaA + "</li>";
                                }
                                else
                                    FuncionesDiareas = excelPackage.Workbook.Worksheets[i].Cells[24, 1].Text;

                                if (excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text == "")
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                                }
                                else
                                    FuncionesQuinSem = excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text;

                                if (excelPackage.Workbook.Worksheets[i].Cells[30, 1].Text == "")
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>Las funciónes Mensuales no pueden estar vacías Celda A30 Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>Las funciónes Mensuales no pueden estar vacías Celda A30 Hoja " + HojaA + "</li>";
                                }
                                else
                                    FuncionesMen = excelPackage.Workbook.Worksheets[i].Cells[30, 1].Text;

                                if (excelPackage.Workbook.Worksheets[i].Cells[33, 1].Text == "")
                                {
                                    FuncionesTri = "";
                                }
                                else
                                    FuncionesTri = excelPackage.Workbook.Worksheets[i].Cells[33, 1].Text;

                                if (excelPackage.Workbook.Worksheets[i].Cells[36, 1].Text == "")
                                {
                                    FuncionesAnual = "";
                                }
                                else
                                    FuncionesAnual = excelPackage.Workbook.Worksheets[i].Cells[36, 1].Text;

                                if (excelPackage.Workbook.Worksheets[i].Cells[39, 1].Text == "")
                                {
                                    FuncionEventual = "";
                                }
                                else
                                    FuncionEventual = excelPackage.Workbook.Worksheets[i].Cells[39, 1].Text;

                                //Toma de Desiciones
                                if ((excelPackage.Workbook.Worksheets[i].Cells[43, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Toma de Decisiones Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Toma de Decisiones Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[47, 10].Text != "")
                                        TomaDecisiones = 5;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[46, 10].Text != "")
                                        TomaDecisiones = 4;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[45, 10].Text != "")
                                        TomaDecisiones = 3;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[44, 10].Text != "")
                                        TomaDecisiones = 2;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[43, 10].Text != "")
                                        TomaDecisiones = 1;

                                }

                                //Esfuerzo Mental
                                if ((excelPackage.Workbook.Worksheets[i].Cells[50, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[51, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[52, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[53, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[54, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Esfuerzo Mental Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Esfuerzo Mental Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[54, 10].Text != "")
                                        EsfuerzoMental = 5;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[53, 10].Text != "")
                                        EsfuerzoMental = 4;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[52, 10].Text != "")
                                        EsfuerzoMental = 3;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[51, 10].Text != "")
                                        EsfuerzoMental = 2;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[50, 10].Text != "")
                                        EsfuerzoMental = 1;

                                }

                                //Manejo de Dinero
                                if (excelPackage.Workbook.Worksheets[i].Cells[58, 5].Text != "")
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[58, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[58, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[58, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[58, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Manejo de dinero en efectivo Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Manejo de dinero en efectivo Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        DineroEfectivo = excelPackage.Workbook.Worksheets[i].Cells[58, 5].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[58, 8].Text != "")
                                            ResponDineroEfectivo = "1";
                                        else
                                            ResponDineroEfectivo = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[58, 9].Text != "")
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",1";
                                        else
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[58, 10].Text != "")
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",1";
                                        else
                                            ResponDineroEfectivo = ResponDineroEfectivo + ",0";
                                    }
                                }

                                if (excelPackage.Workbook.Worksheets[i].Cells[59, 5].Text != "")
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[59, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[59, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[59, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[59, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Instrumentos, equipo o herramientas especializadas Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Instrumentos, equipo o herramientas especializadas Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        Instrumentos = excelPackage.Workbook.Worksheets[i].Cells[59, 5].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[59, 8].Text != "")
                                            ResponInstrumentos = "1";
                                        else
                                            ResponInstrumentos = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[59, 9].Text != "")
                                            ResponInstrumentos = ResponInstrumentos + ",1";
                                        else
                                            ResponInstrumentos = ResponInstrumentos + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[59, 10].Text != "")
                                            ResponInstrumentos = ResponInstrumentos + ",1";
                                        else
                                            ResponInstrumentos = ResponInstrumentos + ",0";
                                    }
                                }

                                if (excelPackage.Workbook.Worksheets[i].Cells[60, 5].Text != "")
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[60, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[60, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[60, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[60, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Vehículos livianos Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Vehículos livianos Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        VehiculoLiviano = excelPackage.Workbook.Worksheets[i].Cells[60, 5].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[60, 8].Text != "")
                                            ResponVehiculoLiviano = "1";
                                        else
                                            ResponVehiculoLiviano = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[60, 9].Text != "")
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",1";
                                        else
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[60, 10].Text != "")
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",1";
                                        else
                                            ResponVehiculoLiviano = ResponVehiculoLiviano + ",0";
                                    }
                                }

                                if (excelPackage.Workbook.Worksheets[i].Cells[61, 5].Text != "")
                                {
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[61, 5].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[61, 8].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[61, 9].Text == "") || (excelPackage.Workbook.Worksheets[i].Cells[61, 10].Text == "")))
                                    {
                                        HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>Debe seleccionar el nivel de responsabilidad en Vehículos pesados Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Debe seleccionar el nivel de responsabilidad en Vehículos pesados Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        VehiculoPesado = excelPackage.Workbook.Worksheets[i].Cells[61, 5].Text;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[61, 8].Text != "")
                                            ResponVehiculoPesado = "1";
                                        else
                                            ResponVehiculoPesado = "0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[61, 9].Text != "")
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",1";
                                        else
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",0";
                                        if (excelPackage.Workbook.Worksheets[i].Cells[61, 10].Text != "")
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",1";
                                        else
                                            ResponVehiculoPesado = ResponVehiculoPesado + ",0";
                                    }
                                }

                                //Supervisiones Internas y Externas
                                List<Supervisiones> Datos = new List<Supervisiones>();
                                for (int j = 67; j < 70; j++)
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

                                for (int k = 72; k < 75; k++)
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
                                for (int k = 78; k < 81; k++)
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
                                for (int k = 83; k < 86; k++)
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
                                if ((excelPackage.Workbook.Worksheets[i].Cells[87, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[88, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[89, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text != "")
                                        RelacionInterna = 5;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text != "")
                                        RelacionInterna = 4;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[89, 10].Text != "")
                                        RelacionInterna = 3;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[88, 10].Text != "")
                                        RelacionInterna = 2;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[87, 10].Text != "")
                                        RelacionInterna = 1;

                                }

                                //Valor Relacion Externa
                                if ((excelPackage.Workbook.Worksheets[i].Cells[93, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[94, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[95, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[96, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[97, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[97, 10].Text != "")
                                        RelacionExterna = 5;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[96, 10].Text != "")
                                        RelacionExterna = 4;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[95, 10].Text != "")
                                        RelacionExterna = 3;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[94, 10].Text != "")
                                        RelacionExterna = 2;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[93, 10].Text != "")
                                        RelacionExterna = 1;

                                }

                                //Manejo Documentos
                                List<ManejoInf> DatosManejoDatos = new List<ManejoInf>();
                                for (int k = 102; k < 105; k++)
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
                                if ((excelPackage.Workbook.Worksheets[i].Cells[106, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[107, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[108, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[109, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[110, 10].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[110, 10].Text != "")
                                        ManejoInf = 5;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[111, 10].Text != "")
                                        ManejoInf = 4;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[112, 10].Text != "")
                                        ManejoInf = 3;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[113, 10].Text != "")
                                        ManejoInf = 2;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[114, 10].Text != "")
                                        ManejoInf = 1;

                                }

                                //Ambiente de Trabajo
                                List<AmbienteTrabajo> AmbienteDatos = new List<AmbienteTrabajo>();
                                int TipoAmbienteId = 1;
                                for (int k = 113; k < 123; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                    {
                                        AmbienteTrabajo Registro = new AmbienteTrabajo();
                                        Registro.TipoAmbienteId = TipoAmbienteId;
                                        AmbienteDatos.Add(Registro);
                                    }
                                    TipoAmbienteId = TipoAmbienteId + 1;
                                }

                                for (int k = 113; k < 122; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                    {
                                        AmbienteTrabajo Registro = new AmbienteTrabajo();
                                        Registro.TipoAmbienteId = TipoAmbienteId;
                                        AmbienteDatos.Add(Registro);
                                    }
                                    TipoAmbienteId = TipoAmbienteId + 1;
                                }

                                //RiesgoOcupacional
                                List<RiesgoOcupacional> RiesgoDatos = new List<RiesgoOcupacional>();
                                int TipoRiesgoId = 1;
                                for (int k = 125; k < 134; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                    {
                                        RiesgoOcupacional Registro = new RiesgoOcupacional();
                                        Registro.RiesgoOcupacionalId = TipoRiesgoId;
                                        RiesgoDatos.Add(Registro);
                                    }
                                    TipoRiesgoId = TipoRiesgoId + 1;
                                }

                                for (int k = 125; k < 134; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                    {
                                        RiesgoOcupacional Registro = new RiesgoOcupacional();
                                        Registro.RiesgoOcupacionalId = TipoRiesgoId;
                                        RiesgoDatos.Add(Registro);
                                    }
                                    TipoRiesgoId = TipoRiesgoId + 1;
                                }

                                //EsfuerzoFisico
                                List<EsfuerzoFisico> EsfuerzoFisicoDatos = new List<EsfuerzoFisico>();
                                int TipoEsfuerzoId = 1;
                                for (int k = 136; k < 143; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                    {
                                        EsfuerzoFisico Registro = new EsfuerzoFisico();
                                        Registro.EsfuerzoFisicoId = TipoEsfuerzoId;
                                        EsfuerzoFisicoDatos.Add(Registro);
                                    }
                                    TipoEsfuerzoId = TipoEsfuerzoId + 1;
                                }

                                for (int k = 136; k < 144; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                    {
                                        EsfuerzoFisico Registro = new EsfuerzoFisico();
                                        Registro.EsfuerzoFisicoId = TipoEsfuerzoId;
                                        EsfuerzoFisicoDatos.Add(Registro);
                                    }
                                    TipoEsfuerzoId = TipoRiesgoId + 1;
                                }

                                //Seccion B
                                //Educacion Formal
                                if ((excelPackage.Workbook.Worksheets[i + 1].Cells[30, 4].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[31, 4].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[32, 4].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[33, 4].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[35, 4].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[36, 4].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Educación Formal Hoja " + HojaB + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Educación Formal Hoja " + HojaB + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[30, 4].Text != "")
                                    {
                                        EducacionFormalId = 1;
                                        Carrera = "";
                                    }
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[31, 4].Text != "")
                                    {
                                        EducacionFormalId = 2;
                                        Carrera = "";
                                    }
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[32, 4].Text != "")
                                    {
                                        EducacionFormalId = 3;
                                        Carrera = excelPackage.Workbook.Worksheets[i + 1].Cells[32, 5].Text;
                                    }
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[33, 4].Text != "")
                                    {
                                        EducacionFormalId = 4;
                                        Carrera = excelPackage.Workbook.Worksheets[i + 1].Cells[33, 5].Text;
                                    }
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[34, 4].Text != "")
                                    {
                                        EducacionFormalId = 5;
                                        Carrera = excelPackage.Workbook.Worksheets[i + 1].Cells[34, 5].Text;
                                    }
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[35, 4].Text != "")
                                    {
                                        EducacionFormalId = 6;
                                        Carrera = excelPackage.Workbook.Worksheets[i + 1].Cells[35, 5].Text;
                                    }
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[36, 4].Text != "")
                                    {
                                        EducacionFormalId = 6;
                                        Carrera = excelPackage.Workbook.Worksheets[i + 1].Cells[36, 5].Text;
                                    }
                                }

                                //Impacto del Error
                                if ((excelPackage.Workbook.Worksheets[i + 1].Cells[40, 1].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[41, 1].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[42, 1].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[43, 1].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[44, 1].Text == ""))
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>No selecciono ninguna opción en la sección de Impacto de Error Hoja " + HojaB + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Impacto de Error Hoja " + HojaB + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[44, 1].Text != "")
                                        ImpactoErrorId = 5;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[43, 1].Text != "")
                                        ImpactoErrorId = 4;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[42, 1].Text != "")
                                        ImpactoErrorId = 3;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[41, 1].Text != "")
                                        ImpactoErrorId = 2;
                                    if (excelPackage.Workbook.Worksheets[i].Cells[40, 1].Text != "")
                                        ImpactoErrorId = 1;

                                }

                                //Cursos Técnicos
                                List<CursosTecnicos> DatosCursosTecnicos = new List<CursosTecnicos>();
                                for (int k = 49; k < 54; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text != "")
                                    {
                                        CursosTecnicos Registro = new CursosTecnicos();
                                        Registro.Curso = excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text;
                                        Registro.Duracion = excelPackage.Workbook.Worksheets[i + 1].Cells[k, 6].Text;
                                        DatosCursosTecnicos.Add(Registro);
                                    }
                                }

                                OtrosEstudios = excelPackage.Workbook.Worksheets[i + 1].Cells[55, 1].Text;

                                //Otros Idiomas
                                List<Idiomas> DatosIdiomas = new List<Idiomas>();
                                for (int k = 64; k < 67; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text != "")
                                    {

                                        if ((excelPackage.Workbook.Worksheets[i + 1].Cells[k, 5].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 6].Text == "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 7].Text == ""))
                                        {
                                            HayError = true;
                                            if (Error == "")
                                                Error = "<ul><li>No selecciono el dominío del idioma: " + excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text + " Hoja " + HojaB + "</li>";
                                            else
                                                Error = Error + Environment.NewLine + "<li>No selecciono el dominío del idioma: " + excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text + " Hoja " + HojaB + "</li>";
                                        }
                                        else
                                        {
                                            Idiomas Registro = new Idiomas();
                                            Registro.Idioma = excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text;
                                            if (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 5].Text != "")
                                                Registro.DominioId = 1;
                                            else if (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 6].Text != "")
                                                Registro.DominioId = 2;
                                            else if (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 7].Text != "")
                                                Registro.DominioId = 3;
                                            DatosIdiomas.Add(Registro);
                                        }

                                    }
                                }

                                //Experiencia
                                List<Experiencia> DatosExperiencia = new List<Experiencia>();
                                for (int k = 72; k < 77; k++)
                                {
                                    if (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text != "")
                                    {

                                        if ((excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text != "") && (excelPackage.Workbook.Worksheets[i + 1].Cells[k, 6].Text == ""))
                                        {
                                            HayError = true;
                                            if (Error == "")
                                                Error = "<ul><li>No ingreso el el tiempo de experiencia: " + excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text + " Hoja " + HojaB + "</li>";
                                            else
                                                Error = Error + Environment.NewLine + "<li>No ingreso el el tiempo de experiencia: " + excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text + " Hoja " + HojaB + "</li>";
                                        }
                                        else
                                        {
                                            Experiencia Registro = new Experiencia();
                                            Registro.TipoTrabajo = excelPackage.Workbook.Worksheets[i + 1].Cells[k, 1].Text;
                                            Registro.Tiempo = excelPackage.Workbook.Worksheets[i + 1].Cells[k, 6].Text;
                                            DatosExperiencia.Add(Registro);
                                        }

                                    }
                                }

                            }
                            else
                            {


                            }
                            if (Error != "")
                                Error = Error + "</ul>";
                            else
                            {

                            }

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
