using CrystalDecisions.Shared;
using PerfilEfectividad.DataSets;
using PerfilEfectividad.Reportes;
using PerfilEfectividad.WebServices;
using System;
using System.Data;

namespace PerfilEfectividad.WebForms_Reportes
{
    public partial class WfrmRep_PerfilPuesto : System.Web.UI.Page
    {
        private string DirApp = System.Configuration.ConfigurationManager.AppSettings["DirApp"];
        private string DirRep = System.Configuration.ConfigurationManager.AppSettings["DirRep"];
        private string DirRepLong = System.Configuration.ConfigurationManager.AppSettings["DirRepLong"];
        Ws_ConfReportes wsConfReportes;
        Ws_Puestos wsPuestos;
        Ws_CrudPerfil wsCrudPerfil;
        Rpt_Perfil Reporte = new Rpt_Perfil();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            int PuestoId = Convert.ToInt32(Request.QueryString["PuestoId"]);
            string Puesto = Request.QueryString["Puesto"];
            string Titulo = Request.QueryString["Titulo"];
            wsConfReportes = new Ws_ConfReportes();
            wsPuestos = new Ws_Puestos();
            wsCrudPerfil = new Ws_CrudPerfil();

            Ds_PerfilEfectividad dsPerfil = new Ds_PerfilEfectividad();
            dsPerfil.Tables["DtDatosPuesto"].Clear();

            var Logo = wsConfReportes.GetLogoaByte();
            var ResInfoPuesto = wsPuestos.GetDataPuestoPerfil(PuestoId);
            for (int i = 0; i < ResInfoPuesto.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtDatosPuesto"].NewRow();
                row["NombrePuesto"] = ResInfoPuesto[i].Puesto;
                row["Logo"] = Logo;
                row["Area"] = ResInfoPuesto[i].Area;
                row["SubArea"] = ResInfoPuesto[i].SubArea;
                row["PuestoJefeInmediato"] = ResInfoPuesto[i].PuestoSuperior;
                row["CodigoPuesto"] = ResInfoPuesto[i].CodigoPuesto;
                row["FuncionPrincipal"] = ResInfoPuesto[i].FuncionPrincipal;
                row["PrincipalesFunciones"] = ResInfoPuesto[i].Principales;
                row["FuncionesDiarias"] = ResInfoPuesto[i].FuncionDiaria;
                row["FuncionesSemanales"] = ResInfoPuesto[i].FuncionSemanalQuincenal;
                row["FuncionesMensuales"] = ResInfoPuesto[i].FuncionMensual;
                row["FuncionesTrimestrales"] = ResInfoPuesto[i].FuncionTrimestralSemestral;
                row["FuncionesAnuales"] = ResInfoPuesto[i].FuncionAnual;
                row["FuncionesEventuales"] = ResInfoPuesto[i].FuncionEventual;
                row["FactorTomaDescion"] = ResInfoPuesto[i].TomaDescion;
                row["FactorEsfuerzoMental"] = ResInfoPuesto[i].EsfuerzoMetal;
                row["FactorManejoBienes"] = ResInfoPuesto[i].ManejoBien;
                row["FactorSupervisiones"] = ResInfoPuesto[i].Supervisiones;
                row["FactorRelacionInterna"] = ResInfoPuesto[i].RelacionInterna;
                row["FactorRelacionExterna"] = ResInfoPuesto[i].RelacionExterna;
                row["FactorManejoInfo"] = ResInfoPuesto[i].ManejoInfo;
                row["RiesgoOcupacional"] = ResInfoPuesto[i].RiesgoOcupacional;
                row["FactorRiesgoOcupacional"] = ResInfoPuesto[i].Riesgo;
                row["EsfuerzoFisico"] = ResInfoPuesto[i].EsfuerzoFisico;
                row["FactorEsfuerzoFisico"] = ResInfoPuesto[i].Esfuerzo;
                row["AmbienteTrabajo"] = ResInfoPuesto[i].AmbienteTrabajo;
                row["FactorAmbienteTrabajo"] = ResInfoPuesto[i].Ambiente;
                row["FactorEducacionFormal"] = ResInfoPuesto[i].EducacionFormal;
                row["NivelEducacional"] = ResInfoPuesto[i].NivEduc;
                row["Carreras"] = ResInfoPuesto[i].Carreras;
                row["FactorImpactoError"] = ResInfoPuesto[i].ImpactoError;
                row["OtrosEstudios"] = ResInfoPuesto[i].OtrosEstudios;
                row["FactorExperiencia"] = ResInfoPuesto[i].Experiencia;
                row["CntSupervisiones"] = ResInfoPuesto[i].CntSupervisiones;
                row["CntRelacionesA"] = ResInfoPuesto[i].CntRelaciones;
                row["CntManejoInfoA"] = ResInfoPuesto[i].CntManejoInfo;
                row["NivEducId"] = ResInfoPuesto[i].NivEducId;
                row["Cntcursos"] = ResInfoPuesto[i].Cntcursos;
                row["CntIdiomas"] = ResInfoPuesto[i].CntIdiomas;
                row["CntExperiencia"] = ResInfoPuesto[i].CntExperiencia;
                dsPerfil.Tables["DtDatosPuesto"].Rows.Add(row);
            }

            dsPerfil.Tables["DtConfig"].Clear();
            var Config = wsConfReportes.GetConfReportes();
            for (int i = 0; i < Config.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtConfig"].NewRow();
                row["InfoGeneral"] = Config[i].InfoGeneral;
                row["Tareas"] = Config[i].Tareas;
                row["TomaDesiciones"] = Config[i].TomaDesiciones;
                row["EsfuerzoMental"] = Config[i].EsfuerzoMental;
                row["ManejoBienes"] = Config[i].ManejoBienes;
                row["Supervision"] = Config[i].Supervision;
                row["RelacionesTrabajo"] = Config[i].RelacionesTrabajo;
                row["ManejoInfo"] = Config[i].ManejoInfo;
                row["AmbienteTrabajo"] = Config[i].AmbienteTrabajo;
                row["RiesgoOcupacional"] = Config[i].RiesgoOcupacional;
                row["EsfuerzoFisico"] = Config[i].EsfuerzoFisico;
                row["EducacionFormal"] = Config[i].EducacionFormal;
                row["ImpactoError"] = Config[i].ImpactoError;
                row["CursosTecnicos"] = Config[i].CursosTecnicos;
                row["OtrasEstudios"] = Config[i].OtrasEstudios;
                row["Idiomas"] = Config[i].Idiomas;
                row["Experiencia"] = Config[i].Experiencia;
                dsPerfil.Tables["DtConfig"].Rows.Add(row);
            }


            dsPerfil.Tables["DtManejoInfo"].Clear();
            var ManejoBienes = wsCrudPerfil.GetDataManejoBienes(PuestoId);

            for (int i = 0; i < ManejoBienes.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtManejoInfo"].NewRow();
                row["Concepto"] = ManejoBienes[i].Concepto;
                row["Monto"] = ManejoBienes[i].Monto;
                row["Indirecta"] = ManejoBienes[i].Indirecta;
                row["Directa"] = ManejoBienes[i].Directa;
                row["Compartida"] = ManejoBienes[i].Compartida;
                dsPerfil.Tables["DtManejoInfo"].Rows.Add(row);
            }

            dsPerfil.Tables["DtSupervisiones"].Clear();
            var Supervisiones = wsCrudPerfil.GetDataSupervisiones(PuestoId);

            for (int i = 0; i < Supervisiones.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtSupervisiones"].NewRow();
                row["Puesto"] = Supervisiones[i].NombrePuesto;
                row["Cantidad"] = Supervisiones[i].Cantidad;
                dsPerfil.Tables["DtSupervisiones"].Rows.Add(row);
            }

            dsPerfil.Tables["DtRelacionesInternas"].Clear();
            var Relaciones = wsCrudPerfil.GetDataRelaciones(PuestoId,"1,2");

            for (int i = 0; i < Relaciones.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtRelacionesInternas"].NewRow();
                row["TipoRelacion"] = Relaciones[i].TipoRelacion;
                row["Puesto"] = Relaciones[i].Puesto;
                row["Proposito"] = Relaciones[i].Proposito;
                row["Frecuencia"] = Relaciones[i].Puesto;
                dsPerfil.Tables["DtRelacionesInternas"].Rows.Add(row);
            }

            dsPerfil.Tables["DtManejoData"].Clear();
            var ManejoData = wsCrudPerfil.GetDataManejoInformacion(PuestoId);

            for (int i = 0; i < ManejoData.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtManejoData"].NewRow();
                row["Documento"] = ManejoData[i].Documento;
                row["AccionDocumento"] = ManejoData[i].AccionDocumento;
                row["TipoInformacion"] = ManejoData[i].TipoInformacion;
                row["Jefe"] = ManejoData[i].Jefe;
                row["AuditoriaInt"] = ManejoData[i].AuditoriaInt;
                row["AuditoriaExterna"] = ManejoData[i].AuditoriaExterna;
                dsPerfil.Tables["DtManejoData"].Rows.Add(row);
            }

            dsPerfil.Tables["DtCursosTecnicos"].Clear();
            var Cursos = wsCrudPerfil.GetDataCursosTecnicos(PuestoId);

            for (int i = 0; i < Cursos.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtCursosTecnicos"].NewRow();
                row["Curso"] = Cursos[i].Curso;
                row["Duracion"] = Cursos[i].Duracion;
                dsPerfil.Tables["DtCursosTecnicos"].Rows.Add(row);
            }

            dsPerfil.Tables["DtIdioma"].Clear();
            var Idiomas = wsCrudPerfil.GetDataIdiomas(PuestoId);

            for (int i = 0; i < Idiomas.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtIdioma"].NewRow();
                row["Idioma"] = Idiomas[i].Idioma;
                row["Dominio"] = Idiomas[i].DominioIdioma;
                dsPerfil.Tables["DtIdioma"].Rows.Add(row);
            }

            dsPerfil.Tables["DtExperiencia"].Clear();
            var Experiencia = wsCrudPerfil.GetDataExperiencia(PuestoId);

            for (int i = 0; i < Experiencia.Count; i++)
            {
                DataRow row = dsPerfil.Tables["DtExperiencia"].NewRow();
                row["TipoTrabajo"] = Experiencia[i].TipoTrabajo;
                row["Tiempo"] = Experiencia[i].Tiempo;
                dsPerfil.Tables["DtExperiencia"].Rows.Add(row);
            }


            Reporte.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            Reporte.SetDataSource(dsPerfil);
            Reporte.Subreports[0].SetDataSource(dsPerfil);
            Reporte.Subreports[1].SetDataSource(dsPerfil);
            Reporte.Subreports[2].SetDataSource(dsPerfil);
            Reporte.Subreports[3].SetDataSource(dsPerfil);
            Reporte.Subreports[4].SetDataSource(dsPerfil);
            Reporte.Subreports[5].SetDataSource(dsPerfil);
            Reporte.Subreports[6].SetDataSource(dsPerfil);

            Reporte.SetParameterValue("Titulo", Titulo);
            string NomReporte = NomReporte = Guid.NewGuid().ToString() + ".pdf";
            string url = Server.MapPath(".") + @"\" + DirRep + NomReporte;
            DiskFileDestinationOptions options2 = new DiskFileDestinationOptions
            {
                DiskFileName = url
            };
            ExportOptions exportOptions = Reporte.ExportOptions;
            exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOptions.ExportDestinationOptions = options2;
            Reporte.Export();
            url = DirApp + DirRepLong + NomReporte;
            base.Response.Redirect(url);


        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            Reporte.Close();
            Reporte.Dispose();
            GC.Collect();
        }
    }
}