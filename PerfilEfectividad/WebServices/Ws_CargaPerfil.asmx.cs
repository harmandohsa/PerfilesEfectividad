using Microsoft.VisualBasic;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using PerfilEfectividad.Clases;

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
        ClPerfilPuesto clPerfil = new ClPerfilPuesto();

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
        public string CaptureFile(string Archivo, bool Opcion, int UsuarioId)
        {
            string Error = "";
            bool HayError = false;
            bool HayErrorPuesto = false;
            int Dia = 0, Mes = 0, Anis = 0;
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
                            NombrePuesto = excelPackage.Workbook.Worksheets[i].Cells[11, 5].Text;
                            if (NombrePuesto == "")
                            {
                                HayErrorPuesto = true;
                                if (Error == "")
                                    Error = "<ul><li>El Puesto está vacío Celda E11 Hoja " + HojaA + "</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Puesto está vacío Celda E11 Hoja " + HojaA + "</li>";
                            }
                            if (NombrePuesto != "")
                            {
                                int ExistePuesto = clPerfil.ExistePuesto(NombrePuesto);
                                if (ExistePuesto >= 1)
                                {
                                    //HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Puesto " + NombrePuesto + " ya existe Hoja, se omite " + HojaA + "</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Puesto " + NombrePuesto + " ya existe Hoja, se omite " + HojaA + "</li>";
                                }
                                else
                                {
                                    if (excelPackage.Workbook.Worksheets[i].Cells[7, 5].Text == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Día está vacío Celda E7 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Día está vacío Celda E7 Hoja " + HojaA + "</li>";
                                    }
                                    else
                                        Dia = Convert.ToInt32(excelPackage.Workbook.Worksheets[i].Cells[7, 5].Text);

                                    if (excelPackage.Workbook.Worksheets[i].Cells[7, 7].Text == "")
                                    {
                                        HayErrorPuesto = true;
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
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Mes debe ser un dato númerico Celda G7 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Mes debe ser un dato númerico Celda G7 Hoja " + HojaA + "</li>";
                                    }

                                    if (excelPackage.Workbook.Worksheets[i].Cells[7, 9].Text == "")
                                    {
                                        HayErrorPuesto = true;
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
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Nombre está vacío Celda E10 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Nombre está vacío Celda E10 Hoja " + HojaA + "</li>";
                                    }

                                    Area = excelPackage.Workbook.Worksheets[i].Cells[12, 5].Text;
                                    if (Area == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Área está vacía Celda E12 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El El Área está vacía Celda E12 Hoja " + HojaA + "</li>";
                                    }

                                    PuestoSuperior = excelPackage.Workbook.Worksheets[i].Cells[13, 5].Text;
                                    if (Area == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Puesto superior está vacío Celda E13 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Area está vacío Celda E13 Hoja " + HojaA + "</li>";
                                    }

                                    Jefe = excelPackage.Workbook.Worksheets[i].Cells[14, 5].Text;
                                    if (Area == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Nombre del Jefe está vacío Celda E14 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Nombre del Jefe está vacío Celda E13 Hoja " + HojaA + "</li>";
                                    }

                                    //Funciones
                                    if (excelPackage.Workbook.Worksheets[i].Cells[17, 1].Text == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>La función principal no puede estar vacía Celdas A17 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>La función principal no puede estar vacía Celdas A17 Hoja " + HojaA + "</li>";
                                    }
                                    else
                                        FuncionPrincipal = excelPackage.Workbook.Worksheets[i].Cells[17, 1].Text + ' ' + excelPackage.Workbook.Worksheets[i].Cells[18, 1].Text;

                                    if (excelPackage.Workbook.Worksheets[i].Cells[21, 1].Text == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>Las funciónes principales no pueden estar vacías Celda A21 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Las funciónes principales no pueden estar vacías Celda A21 Hoja " + HojaA + "</li>";
                                    }
                                    else
                                        FuncionesPrincipales = excelPackage.Workbook.Worksheets[i].Cells[21, 1].Text;

                                    if (excelPackage.Workbook.Worksheets[i].Cells[24, 1].Text == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>Las funciónes diarias no pueden estar vacías Celda A24 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Las funciónes diarias no pueden estar vacías Celda A24 Hoja " + HojaA + "</li>";
                                    }
                                    else
                                        FuncionesDiareas = excelPackage.Workbook.Worksheets[i].Cells[24, 1].Text;

                                    if (excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text == "")
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>Las funciónes Semanales o Quincenales no pueden estar vacías Celda A27 Hoja " + HojaA + "</li>";
                                    }
                                    else
                                        FuncionesQuinSem = excelPackage.Workbook.Worksheets[i].Cells[27, 1].Text;

                                    if (excelPackage.Workbook.Worksheets[i].Cells[30, 1].Text == "")
                                    {
                                        HayErrorPuesto = true;
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
                                        HayErrorPuesto = true;
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
                                        HayErrorPuesto = true;
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
                                                HayErrorPuesto = true;
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
                                            HayErrorPuesto = true;
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
                                            HayErrorPuesto = true;
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
                                            HayErrorPuesto = true;
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
                                                HayErrorPuesto = true;
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
                                                    HayErrorPuesto = true;
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
                                                HayErrorPuesto = true;
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
                                                    HayErrorPuesto = true;
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
                                    for (int k = 78; k < 84; k++)
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                        {
                                            if ((excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[k, 7].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text == "")))
                                            {
                                                HayErrorPuesto = true;
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
                                    for (int k = 86; k < 89; k++)
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                        {
                                            if ((excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "") && ((excelPackage.Workbook.Worksheets[i].Cells[k, 7].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 8].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 9].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[k, 10].Text == "")))
                                            {
                                                HayErrorPuesto = true;
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
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[92, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[93, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[94, 10].Text == ""))
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones internas Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[94, 10].Text != "")
                                            RelacionInterna = 5;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[93, 10].Text != "")
                                            RelacionInterna = 4;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[92, 10].Text != "")
                                            RelacionInterna = 3;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[91, 10].Text != "")
                                            RelacionInterna = 2;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[90, 10].Text != "")
                                            RelacionInterna = 1;

                                    }

                                    //Valor Relacion Externa
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[96, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[97, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[98, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[99, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[100, 10].Text == ""))
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Relaciones Externas Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[100, 10].Text != "")
                                            RelacionExterna = 5;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[99, 10].Text != "")
                                            RelacionExterna = 4;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[98, 10].Text != "")
                                            RelacionExterna = 3;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[97, 10].Text != "")
                                            RelacionExterna = 2;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[96, 10].Text != "")
                                            RelacionExterna = 1;

                                    }

                                    //Manejo Documentos
                                    List<ManejoInf> DatosManejoDatos = new List<ManejoInf>();
                                    for (int k = 105; k < 108; k++)
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
                                    if ((excelPackage.Workbook.Worksheets[i].Cells[109, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[110, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[111, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[112, 10].Text == "") && (excelPackage.Workbook.Worksheets[i].Cells[113, 10].Text == ""))
                                    {
                                        HayErrorPuesto = true;
                                        if (Error == "")
                                            Error = "<ul><li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>No selecciono ninguna opción en la sección de Manejo de Información y Documentos Hoja " + HojaA + "</li>";
                                    }
                                    else
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[113, 10].Text != "")
                                            ManejoInf = 5;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[112, 10].Text != "")
                                            ManejoInf = 4;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[111, 10].Text != "")
                                            ManejoInf = 3;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[110, 10].Text != "")
                                            ManejoInf = 2;
                                        if (excelPackage.Workbook.Worksheets[i].Cells[109, 10].Text != "")
                                            ManejoInf = 1;

                                    }

                                    //Ambiente de Trabajo
                                    List<AmbienteTrabajo> AmbienteDatos = new List<AmbienteTrabajo>();
                                    int TipoAmbienteId = 1;
                                    for (int k = 116; k < 126; k++)
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                        {
                                            AmbienteTrabajo Registro = new AmbienteTrabajo();
                                            Registro.TipoAmbienteId = TipoAmbienteId;
                                            AmbienteDatos.Add(Registro);
                                        }
                                        TipoAmbienteId = TipoAmbienteId + 1;
                                    }

                                    for (int k = 116; k < 125; k++)
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
                                    for (int k = 128; k < 137; k++)
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                        {
                                            RiesgoOcupacional Registro = new RiesgoOcupacional();
                                            Registro.RiesgoOcupacionalId = TipoRiesgoId;
                                            RiesgoDatos.Add(Registro);
                                        }
                                        TipoRiesgoId = TipoRiesgoId + 1;
                                    }

                                    for (int k = 128; k < 137; k++)
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
                                    for (int k = 139; k < 146; k++)
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 1].Text != "")
                                        {
                                            EsfuerzoFisico Registro = new EsfuerzoFisico();
                                            Registro.EsfuerzoFisicoId = TipoEsfuerzoId;
                                            EsfuerzoFisicoDatos.Add(Registro);
                                        }
                                        TipoEsfuerzoId = TipoEsfuerzoId + 1;
                                    }

                                    for (int k = 139; k < 147; k++)
                                    {
                                        if (excelPackage.Workbook.Worksheets[i].Cells[k, 6].Text != "")
                                        {
                                            EsfuerzoFisico Registro = new EsfuerzoFisico();
                                            Registro.EsfuerzoFisicoId = TipoEsfuerzoId;
                                            EsfuerzoFisicoDatos.Add(Registro);
                                        }
                                        TipoEsfuerzoId = TipoRiesgoId + 1;
                                    }

                                    //Insertar Puesto
                                    if (HayErrorPuesto == false)
                                    {
                                        
                                        int AreaId = clPerfil.ExisteArea(Area);
                                        int PuestoId = clPerfil.Insert_Puesto(NombrePuesto);
                                        string Fecha = Mes.ToString() + "/" + Dia.ToString() + "/" + Anis.ToString();
                                        int PuestoVer = clPerfil.Insert_Perfil(PuestoId, Fecha, AreaId, FuncionPrincipal, FuncionesPrincipales, FuncionesQuinSem, FuncionesMen, FuncionesTri, FuncionesAnual,
                                            FuncionEventual, TomaDecisiones, EsfuerzoMental, RelacionInterna, RelacionExterna, ManejoInf, UsuarioId, PuestoSuperior, NombreColaborador, Jefe, FuncionesDiareas);
                                        if (DineroEfectivo != "")
                                        {
                                            string[] words = ResponDineroEfectivo.Split(',');
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 1, DineroEfectivo, Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
                                        }
                                        else
                                        {
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 1, "", 0, 0, 0);
                                        }
                                        if (Instrumentos != "")
                                        {
                                            string[] words = ResponInstrumentos.Split(',');
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 2, Instrumentos, Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
                                        }
                                        else
                                        {
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 2, "", 0, 0, 0);
                                        }
                                        if (VehiculoLiviano != "")
                                        {
                                            string[] words = ResponVehiculoLiviano.Split(',');
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 3, VehiculoLiviano, Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
                                        }
                                        else
                                        {
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 3, "", 0, 0, 0);
                                        }
                                        if (VehiculoPesado != "")
                                        {
                                            string[] words = ResponVehiculoPesado.Split(',');
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 4, VehiculoPesado, Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
                                        }
                                        else
                                        {
                                            clPerfil.Insert_DetalleManejoBien(PuestoId, PuestoVer, 4, "", 0, 0, 0);
                                        }
                                        for (int j = 0; j < Datos.Count; j++)
                                        {
                                            clPerfil.Insert_DetalleSupervisiones(PuestoId, PuestoVer, Datos[j].TipoSupervision, Datos[j].Puesto, Datos[j].Cantidad);
                                        }
                                        for (int j = 0; j < DatosRel.Count; j++)
                                        {
                                            clPerfil.Insert_DetalleRelaciones(PuestoId, PuestoVer, DatosRel[j].Puesto, DatosRel[j].Proposito, DatosRel[j].FrecuenciaId, DatosRel[j].TipoRelacion);
                                        }
                                        for (int j = 0; j < DatosManejoDatos.Count; j++)
                                        {
                                            clPerfil.Insert_DetalleManejoInfo(PuestoId, PuestoVer, DatosManejoDatos[j].Documento, DatosManejoDatos[j].Accion, DatosManejoDatos[j].TipoInformacion, DatosManejoDatos[j].Jefe, DatosManejoDatos[j].AuditoriaInt, DatosManejoDatos[j].AuditoriaExt);
                                        }
                                        for (int j = 0; j < AmbienteDatos.Count; j++)
                                        {
                                            clPerfil.Insert_DetalleAmbienteTrabajo(PuestoId, PuestoVer, AmbienteDatos[j].TipoAmbienteId);
                                        }
                                        for (int j = 0; j < RiesgoDatos.Count; j++)
                                        {
                                            clPerfil.Insert_DetalleRiesgo(PuestoId, PuestoVer, RiesgoDatos[j].RiesgoOcupacionalId);
                                        }
                                        for (int j = 0; j < EsfuerzoFisicoDatos.Count; j++)
                                        {
                                            clPerfil.Insert_DetalleEsfuerzoFisico(PuestoId, PuestoVer, EsfuerzoFisicoDatos[j].EsfuerzoFisicoId);
                                        }

                                        //HayError = true;
                                        if (Error == "")
                                            Error = "<ul><li>El Puesto: " + NombrePuesto + " fue agregado " + HojaA + "</li>";
                                        else
                                            Error = Error + Environment.NewLine + "<li>El Puesto: " + NombrePuesto + " fue agregado " + HojaA + "</li>";
                                    }
                                    HayErrorPuesto = false;

                                }
                            }
                            
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= a; i += 2)
                        {
                            

                        }
                    }
                    if (Error != "")
                        Error = Error + "</ul>";
                   


                }
                return Error;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
