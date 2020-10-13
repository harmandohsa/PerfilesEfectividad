using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_CrudPerfil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_CrudPerfil : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class DataGeneral
        {
            public int AreaId { get; set; }
            public string Area { get; set; }
            public string PuestoSuperior { get; set; }
        }

        [WebMethod]
        public List<DataGeneral> GetDataGeneral(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetDataGeneral(PuestoId);
            List<DataGeneral> Datos = new List<DataGeneral>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataGeneral Registro = new DataGeneral();
                Registro.AreaId = Convert.ToInt32(dr["AreaId"]);
                Registro.Area = dr["Area"].ToString();
                Registro.PuestoSuperior = dr["PuestoSuperior"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataFunciones
        {
            public string FuncionPrincipal { get; set; }
            public string Principales { get; set; }
            public string FuncionDiaria { get; set; }
            public string FuncionSemanalQuincenal { get; set; }
            public string FuncionMensual { get; set; }
            public string FuncionTrimestralSemestral { get; set; }
            public string FuncionAnual { get; set; }
            public string FuncionEventual { get; set; }
        }

        [WebMethod]
        public List<DataFunciones> GetDataFunciones(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetDataFunciones(PuestoId);
            List<DataFunciones> Datos = new List<DataFunciones>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataFunciones Registro = new DataFunciones();
                Registro.FuncionPrincipal = dr["FuncionPrincipal"].ToString();
                Registro.Principales = dr["Principales"].ToString();
                Registro.FuncionDiaria = dr["FuncionDiaria"].ToString();
                Registro.FuncionSemanalQuincenal = dr["FuncionSemanalQuincenal"].ToString();
                Registro.FuncionMensual = dr["FuncionMensual"].ToString();
                Registro.FuncionTrimestralSemestral = dr["FuncionTrimestralSemestral"].ToString();
                Registro.FuncionAnual = dr["FuncionAnual"].ToString();
                Registro.FuncionEventual = dr["FuncionEventual"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataFactores
        {
            public int TomaDesicionId { get; set; }
            public int EsfuerzoMentalId { get; set; }
            public int ManejoBienId { get; set; }
            public int SupervisionId { get; set; }
            public int RelacionInternaId { get; set; }
            public int RelacionExternaId { get; set; }
            public int ManejoInformacionId { get; set; }
            public int AmbienteTrabajoId { get; set; }
            public int RiesgoOcupacionalId { get; set; }
            public int EsfuerzoFisicoId { get; set; }
        }

        [WebMethod]
        public List<DataFactores> GetDataFactores(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetDataFactores(PuestoId);
            List<DataFactores> Datos = new List<DataFactores>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataFactores Registro = new DataFactores();
                Registro.TomaDesicionId = Convert.ToInt32(dr["TomaDesicionId"].ToString());
                Registro.EsfuerzoMentalId = Convert.ToInt32(dr["EsfuerzoMentalId"].ToString());
                if (dr["ManejoBienId"].ToString() == "")
                    Registro.ManejoBienId = 0;
                else
                    Registro.ManejoBienId = Convert.ToInt32(dr["ManejoBienId"].ToString());
                if (dr["SupervisionId"].ToString() == "")
                    Registro.SupervisionId = 0;
                else
                    Registro.SupervisionId = Convert.ToInt32(dr["SupervisionId"].ToString());
                Registro.RelacionInternaId = Convert.ToInt32(dr["RelacionInternaId"].ToString());
                Registro.RelacionExternaId = Convert.ToInt32(dr["RelacionExternaId"].ToString());
                Registro.ManejoInformacionId = Convert.ToInt32(dr["ManejoInformacionId"].ToString());
                if (dr["AmbienteTrabajoId"].ToString() == "")
                    Registro.AmbienteTrabajoId = 0;
                else
                    Registro.AmbienteTrabajoId = Convert.ToInt32(dr["AmbienteTrabajoId"].ToString());
                if (dr["RiesgoOcupacionalId"].ToString() == "")
                    Registro.RiesgoOcupacionalId = 0;
                else
                    Registro.RiesgoOcupacionalId = Convert.ToInt32(dr["RiesgoOcupacionalId"].ToString());
                if (dr["EsfuerzoFisicoId"].ToString() == "")
                    Registro.EsfuerzoFisicoId = 0;
                else
                    Registro.EsfuerzoFisicoId = Convert.ToInt32(dr["EsfuerzoFisicoId"].ToString());
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataManejoBienes
        {
            public int ConceptoId { get; set; }
            public string Concepto { get; set; }
            public string Monto { get; set; }
            public int Indirecta { get; set; }
            public int Directa { get; set; }
            public int Compartida { get; set; }
        }

        [WebMethod]
        public List<DataManejoBienes> GetDataManejoBienes(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetDataManejoBienes(PuestoId);
            List<DataManejoBienes> Datos = new List<DataManejoBienes>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataManejoBienes Registro = new DataManejoBienes();
                Registro.ConceptoId = Convert.ToInt32(dr["ConceptoId"].ToString());
                Registro.Concepto = dr["Concepto"].ToString();
                Registro.Monto = dr["MontoUS"].ToString();
                Registro.Indirecta = Convert.ToInt32(dr["Indirecta"].ToString());
                Registro.Directa = Convert.ToInt32(dr["Directa"].ToString());
                Registro.Compartida = Convert.ToInt32(dr["Compartida"].ToString());
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataSupervisiones
        {
            public int SupervisionId { get; set; }
            public int PuestoVer { get; set; }
            public string NombrePuesto { get; set; }
            public int Cantidad { get; set; }
            public string TipoSupervision { get; set; }
            public int TipoSupervisionId { get; set; }
        }

        [WebMethod]
        public List<DataSupervisiones> GetDataSupervisiones(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetDataSupervision(PuestoId);
            List<DataSupervisiones> Datos = new List<DataSupervisiones>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataSupervisiones Registro = new DataSupervisiones();
                Registro.SupervisionId = Convert.ToInt32(dr["SupervisionId"].ToString());
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.NombrePuesto = dr["NombrePuesto"].ToString();
                Registro.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString());
                Registro.TipoSupervision = dr["TipoSupervision"].ToString();
                Registro.TipoSupervisionId = Convert.ToInt32(dr["TipoSupervisionId"].ToString());
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataRelaciones
        {
            public int RelacionId { get; set; }
            public int PuestoVer { get; set; }
            public int TipoRelacionId { get; set; }
            public string TipoRelacion { get; set; }
            public string Puesto { get; set; }
            public string Proposito { get; set; }
            public int FrecuenciaId { get; set; }
            public string Frecuencia { get; set; }
        }

        [WebMethod]
        public List<DataRelaciones> GetDataRelaciones(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetRelacionesTrabajo(PuestoId);
            List<DataRelaciones> Datos = new List<DataRelaciones>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataRelaciones Registro = new DataRelaciones();
                Registro.RelacionId = Convert.ToInt32(dr["RelacionId"].ToString());
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.TipoRelacionId = Convert.ToInt32(dr["TipoRelacionId"].ToString());
                Registro.TipoRelacion = dr["TipoRelacion"].ToString();
                Registro.Puesto = dr["Puesto"].ToString();
                Registro.Proposito = dr["Proposito"].ToString();
                Registro.FrecuenciaId = Convert.ToInt32(dr["FrecuenciaId"].ToString());
                Registro.Frecuencia = dr["Frecuencia"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataManejoInformacion
        {
            public int ManejoInformacionId { get; set; }
            public int PuestoVer { get; set; }
            public string Documento { get; set; }
            public string AccionDocumento { get; set; }
            public string TipoInformacion { get; set; }
            public int Jefe { get; set; }
            public int AuditoriaInt { get; set; }
            public int AuditoriaExterna { get; set; }
        }

        [WebMethod]
        public List<DataManejoInformacion> GetDataManejoInformacion(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetManejoInformacion(PuestoId);
            List<DataManejoInformacion> Datos = new List<DataManejoInformacion>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataManejoInformacion Registro = new DataManejoInformacion();
                Registro.ManejoInformacionId = Convert.ToInt32(dr["ManejoInformacionId"].ToString());
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.Documento = dr["Documento"].ToString();
                Registro.AccionDocumento = dr["AccionDocumento"].ToString();
                Registro.TipoInformacion = dr["TipoInformacion"].ToString();
                Registro.Jefe = Convert.ToInt32(dr["Jefe"].ToString());
                Registro.AuditoriaInt = Convert.ToInt32(dr["AuditoriaInt"].ToString());
                Registro.AuditoriaExterna = Convert.ToInt32(dr["AuditoriaExterna"].ToString());
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataAmbienteTrabajo
        {
            public int PuestoVer { get; set; }
            public string Tipos { get; set; }
        }

        [WebMethod]
        public List<DataAmbienteTrabajo> GetDataAmbienteTrabajo(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetAmbienteTrabajo(PuestoId);
            List<DataAmbienteTrabajo> Datos = new List<DataAmbienteTrabajo>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataAmbienteTrabajo Registro = new DataAmbienteTrabajo();
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.Tipos = dr["Tipos"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataRiesgoOcupacional
        {
            public int PuestoVer { get; set; }
            public string Tipos { get; set; }
        }

        [WebMethod]
        public List<DataRiesgoOcupacional> GetDataRiesgoOcupacional(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetRiesgoOcupacional(PuestoId);
            List<DataRiesgoOcupacional> Datos = new List<DataRiesgoOcupacional>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataRiesgoOcupacional Registro = new DataRiesgoOcupacional();
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.Tipos = dr["Tipos"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataEsfuerzoFisico
        {
            public int PuestoVer { get; set; }
            public string Tipos { get; set; }
        }

        [WebMethod]
        public List<DataRiesgoOcupacional> GetDataEsfuerzoFisico(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetEsfuerzoFisico(PuestoId);
            List<DataRiesgoOcupacional> Datos = new List<DataRiesgoOcupacional>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataRiesgoOcupacional Registro = new DataRiesgoOcupacional();
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.Tipos = dr["Tipos"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }
    }
}
