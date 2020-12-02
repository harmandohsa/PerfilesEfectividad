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
            public int SubAreaId { get; set; }
            public string CodigoPuesto { get; set; }
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
                if (dr["SubAreaId"].ToString() == "")
                    Registro.SubAreaId = 0;
                else
                    Registro.SubAreaId = Convert.ToInt32(dr["SubAreaId"]);
                if (dr["CodigoPuesto"].ToString() == "")
                    Registro.CodigoPuesto = "";
                else
                    Registro.CodigoPuesto = dr["CodigoPuesto"].ToString();
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
            public string OtrosEstudios { get; set; }
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
                Registro.OtrosEstudios = dr["OtrosEstudios"].ToString();
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
            public int EducacionFormalId { get; set; }
            public int ImpactoErrorId { get; set; }
            public int ExperienciaLaboralId { get; set; }
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
                if (dr["TomaDesicionId"].ToString() == "")
                    Registro.TomaDesicionId = 0;
                else
                    Registro.TomaDesicionId = Convert.ToInt32(dr["TomaDesicionId"].ToString());
                if (dr["EsfuerzoMentalId"].ToString() == "")
                    Registro.EsfuerzoMentalId = 0;
                else
                    Registro.EsfuerzoMentalId = Convert.ToInt32(dr["EsfuerzoMentalId"].ToString());
                if (dr["ManejoBienId"].ToString() == "")
                    Registro.ManejoBienId = 0;
                else
                    Registro.ManejoBienId = Convert.ToInt32(dr["ManejoBienId"].ToString());
                if (dr["SupervisionId"].ToString() == "")
                    Registro.SupervisionId = 0;
                else
                    Registro.SupervisionId = Convert.ToInt32(dr["SupervisionId"].ToString());
                if (dr["RelacionInternaId"].ToString() == "")
                    Registro.RelacionInternaId = 0;
                else
                    Registro.RelacionInternaId = Convert.ToInt32(dr["RelacionInternaId"].ToString());
                if (dr["RelacionExternaId"].ToString() == "")
                    Registro.RelacionExternaId = 0;
                else
                    Registro.RelacionExternaId = Convert.ToInt32(dr["RelacionExternaId"].ToString());
                if (dr["ManejoInformacionId"].ToString() == "")
                    Registro.ManejoInformacionId = 0;
                else
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
                if (dr["EducacionFormalId"].ToString() == "")
                    Registro.EducacionFormalId = 0;
                else
                    Registro.EducacionFormalId = Convert.ToInt32(dr["EducacionFormalId"].ToString());
                if (dr["ImpactoErrorId"].ToString() == "")
                    Registro.ImpactoErrorId = 0;
                else
                    Registro.ImpactoErrorId = Convert.ToInt32(dr["ImpactoErrorId"].ToString());
                if (dr["ExperienciaLaboralId"].ToString() == "")
                    Registro.ExperienciaLaboralId = 0;
                else
                    Registro.ExperienciaLaboralId = Convert.ToInt32(dr["ExperienciaLaboralId"].ToString());
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

        public class DataEstudioFormal
        {
            public int GradoId { get; set; }
        }

        [WebMethod]
        public List<DataEstudioFormal> GetDataEstudioFormal(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetEstudioFormal(PuestoId);
            List<DataEstudioFormal> Datos = new List<DataEstudioFormal>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataEstudioFormal Registro = new DataEstudioFormal();
                if (dr["GradoId"].ToString() == "")
                    Registro.GradoId = 0;
                else
                    Registro.GradoId = Convert.ToInt32(dr["GradoId"].ToString());
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataCursosTecnicos
        {
            public int CursoId { get; set; }
            public string Curso { get; set; }
            public string Duracion { get; set; }
        }

        [WebMethod]
        public List<DataCursosTecnicos> GetDataCursosTecnicos(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetCursosTecnicos(PuestoId);
            List<DataCursosTecnicos> Datos = new List<DataCursosTecnicos>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataCursosTecnicos Registro = new DataCursosTecnicos();
                Registro.CursoId = Convert.ToInt32(dr["CursoId"].ToString());
                Registro.Curso = dr["Curso"].ToString();
                Registro.Duracion = dr["Duracion"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }


        public class DataIdomas
        {
            public int IdiomaId { get; set; }
            public int IdomaId { get; set; }
            public string Idioma { get; set; }
            public int DominioIdiomaId { get; set; }
            public string DominioIdioma { get; set; }
        }

        [WebMethod]
        public List<DataIdomas> GetDataIdiomas(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetIdiomas(PuestoId);
            List<DataIdomas> Datos = new List<DataIdomas>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataIdomas Registro = new DataIdomas();
                Registro.IdiomaId = Convert.ToInt32(dr["IdiomaId"].ToString());
                Registro.IdomaId = Convert.ToInt32(dr["IdomaId"].ToString());
                Registro.Idioma = dr["Idioma"].ToString();
                Registro.DominioIdiomaId = Convert.ToInt32(dr["DominioIdiomaId"].ToString());
                Registro.DominioIdioma = dr["DominioIdioma"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class DataExperiencia
        {
            public int ExperienciaId { get; set; }
            public string TipoTrabajo { get; set; }
            public string Tiempo { get; set; }
        }

        [WebMethod]
        public List<DataExperiencia> GetDataExperiencia(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetExperiencia(PuestoId);
            List<DataExperiencia> Datos = new List<DataExperiencia>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataExperiencia Registro = new DataExperiencia();
                Registro.ExperienciaId = Convert.ToInt32(dr["ExperienciaId"].ToString());
                Registro.TipoTrabajo = dr["TipoTrabajo"].ToString();
                Registro.Tiempo = dr["Tiempo"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int UpdateInfoGeneral(int AreaId, string PuestoJefe, int PuestoId, string SubAreaId, string CodigoPuesto, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UpdateInfoGeneral", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@AreaId", SqlDbType.Int).Value = AreaId;
                Comando.Parameters.Add("@PuestoJefe", SqlDbType.VarChar, 900).Value = PuestoJefe;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                if (SubAreaId == "")
                    Comando.Parameters.Add("@SubAreaId", SqlDbType.Int).Value = DBNull.Value;
                else
                    Comando.Parameters.Add("@SubAreaId", SqlDbType.Int).Value = SubAreaId;
                Comando.Parameters.Add("@CodigoPuesto", SqlDbType.VarChar, 900).Value = CodigoPuesto;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int UpdateFunciones(int PuestoId, string FuncPrincipal, string FuncPrincipales, 
            string FuncDiarias, string FuncSemanalQuin, string FuncMensual, string FuncTrimSemestre, 
            string FuncAnual, string FuncEventual, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UpdateFunciones", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@FuncPrincipal", SqlDbType.Text).Value = FuncPrincipal;
                Comando.Parameters.Add("@FuncPrincipales", SqlDbType.Text).Value = FuncPrincipales;
                Comando.Parameters.Add("@FuncDiarias", SqlDbType.Text).Value = FuncDiarias;
                Comando.Parameters.Add("@FuncSemanalQuin", SqlDbType.Text).Value = FuncSemanalQuin;
                Comando.Parameters.Add("@FuncMensual", SqlDbType.Text).Value = FuncMensual;
                Comando.Parameters.Add("@FuncTrimSemestre", SqlDbType.Text).Value = FuncTrimSemestre;
                Comando.Parameters.Add("@FuncAnual", SqlDbType.Text).Value = FuncAnual;
                Comando.Parameters.Add("@FuncEventual", SqlDbType.Text).Value = FuncEventual;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int UpdateFactores(int PuestoId, int FactorId, string Id, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UpdateFactor", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@FactorId", SqlDbType.Int).Value = FactorId;
                if (Id != "")
                    Comando.Parameters.Add("@Id", SqlDbType.VarChar, 2).Value = Id;
                else
                    Comando.Parameters.Add("@Id", SqlDbType.VarChar, 2).Value = DBNull.Value;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int UpdateDetalleManejoBientes(int PuestoId, int ConceptoId, string Monto, int Indirecta, int Directa, int Compartida, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UpdateManejoBien", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@ConceptoId", SqlDbType.Int).Value = ConceptoId;
                Comando.Parameters.Add("@Monto", SqlDbType.VarChar, 500).Value = Monto;
                Comando.Parameters.Add("@Indirecta", SqlDbType.Int).Value = Indirecta;
                Comando.Parameters.Add("@Directa", SqlDbType.Int).Value = Directa;
                Comando.Parameters.Add("@Compartida", SqlDbType.Int).Value = Compartida;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteDetalleSupervision(int PuestoId, int SupervisionId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteSupervision", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@SupervisionId", SqlDbType.Int).Value = SupervisionId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditDetalleSupervision(int PuestoId, int SupervisionId, string Puesto, int Cantidad, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UpdateDetalleSupervision", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@SupervisionId", SqlDbType.Int).Value = SupervisionId;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_DetalleSupervisiones(int PuestoId, int PuestoVer, string NombrePuesto, int Cantidad, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleSupervisiones", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditDetalleRelaciones(int PuestoId, int RelacionId, string Puesto, 
            string Proposito, int FrecuenciaId, int TipoRelacionId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditDetalleRelacion", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@RelacionId", SqlDbType.Int).Value = RelacionId;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Proposito", SqlDbType.VarChar, 500).Value = Proposito;
                Comando.Parameters.Add("@FrecuenciaId", SqlDbType.Int).Value = FrecuenciaId;
                Comando.Parameters.Add("@TipoRelacionId", SqlDbType.Int).Value = TipoRelacionId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_DetalleRelaciones(int PuestoId, int PuestoVer, string NombrePuesto, 
            string Proposito, int FrecuenciaId, int TipoRelacionId, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleRelaciones", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
                Comando.Parameters.Add("@Proposito", SqlDbType.VarChar, 900).Value = Proposito;
                Comando.Parameters.Add("@FrecuenciaId", SqlDbType.Int).Value = FrecuenciaId;
                Comando.Parameters.Add("@TipoRelacionId", SqlDbType.Int).Value = TipoRelacionId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteDetalleRelacion(int PuestoId, int RelacionId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteRelacion", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@RelacionId", SqlDbType.Int).Value = RelacionId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditManjeoInfo(int PuestoId, int ManejoInformacionId, string Docuemento,
            string AccionDocumento, string TipoInformacion, int Jefe, int AuditoriaInt, int AuditoriaExt, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditManejoInfo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@ManejoInformacionId", SqlDbType.Int).Value = ManejoInformacionId;
                Comando.Parameters.Add("@Docuemento", SqlDbType.VarChar, 500).Value = Docuemento;
                Comando.Parameters.Add("@AccionDocumento", SqlDbType.VarChar, 500).Value = AccionDocumento;
                Comando.Parameters.Add("@TipoInformacion", SqlDbType.VarChar, 500).Value = TipoInformacion;
                Comando.Parameters.Add("@Jefe", SqlDbType.Int).Value = Jefe;
                Comando.Parameters.Add("@AuditoriaInt", SqlDbType.Int).Value = AuditoriaInt;
                Comando.Parameters.Add("@AuditoriaExt", SqlDbType.Int).Value = AuditoriaExt;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_DetalleManejoInfo(int PuestoId, int PuestoVer, string Documento, string Accion, string TipoInformacion, int Jefe, int AuditoriaInt, int AuditoriaExt, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleManejoInfo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar, 900).Value = Documento;
                Comando.Parameters.Add("@Accion", SqlDbType.VarChar, 900).Value = Accion;
                Comando.Parameters.Add("@TipoInformacion", SqlDbType.VarChar, 900).Value = TipoInformacion;
                Comando.Parameters.Add("@Jefe", SqlDbType.Int).Value = Jefe;
                Comando.Parameters.Add("@AuditoriaInt", SqlDbType.Int).Value = AuditoriaInt;
                Comando.Parameters.Add("@AuditoriaExt", SqlDbType.Int).Value = AuditoriaExt;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteDetalleManejoInfo(int PuestoId, int ManejoInformacionId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteManejoInfo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@ManejoInformacionId", SqlDbType.Int).Value = ManejoInformacionId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int AddAmbienteTrabajo(int PuestoId, string TipoAmbienteTrabajo, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_AddAmbienteTrabajo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@TipoAmbienteTrabajo", SqlDbType.VarChar, 1000).Value = TipoAmbienteTrabajo;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int AddRiesgoOcupacional(int PuestoId, string TipoRiesgoOcupacional, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_AddRiesgoOcupacional", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@TipoRiesgoOcupacional", SqlDbType.VarChar, 1000).Value = TipoRiesgoOcupacional;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int AddEsfuerzoFisico(int PuestoId, string TipoEsfuerzoFisico, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_AddEsfuerzoFisico", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@TipoEsfuerzoFisico", SqlDbType.VarChar, 1000).Value = TipoEsfuerzoFisico;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int UpdateEducacionActual(int PuestoId, int GradoId, int EducacionFormalId, string Carreras, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UpdateEducacionFormal", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@GradoId", SqlDbType.Int).Value = GradoId;
                Comando.Parameters.Add("@EducacionFormalId", SqlDbType.Int).Value = EducacionFormalId;
                if (Carreras == "")
                    Comando.Parameters.Add("@Carreras", SqlDbType.VarChar, 8000).Value = DBNull.Value;
                else
                    Comando.Parameters.Add("@Carreras", SqlDbType.VarChar, 8000).Value = Carreras;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditCursoTecnico(int PuestoId, int CursoId, string Curso, string Duracion, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditCursosTecnicos", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@CursoId", SqlDbType.Int).Value = CursoId;
                Comando.Parameters.Add("@Curso", SqlDbType.VarChar, 500).Value = Curso;
                Comando.Parameters.Add("@Duracion", SqlDbType.VarChar, 500).Value = Duracion;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_DetalleCursoTecnico(int PuestoId, int PuestoVer, string Curso, string Duracion, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleCursoTecnico", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@Curso", SqlDbType.VarChar, 900).Value = Curso;
                Comando.Parameters.Add("@Duracion", SqlDbType.VarChar, 900).Value = Duracion;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteDetalleCursoTecnico(int PuestoId, int CursoId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_DetalleCursoTecnico", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@CursoId", SqlDbType.Int).Value = CursoId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int UpdateOtrosEstudios(int PuestoId, string OtrosEstudios, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditOtrosEstudios", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@OtrosEstudios", SqlDbType.VarChar, 1000).Value = OtrosEstudios;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditIdioma(int PuestoId, int IdiomaId, int IdomaId, int DominioIdiomaId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditIdioma", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@IdiomaId", SqlDbType.Int).Value = IdiomaId;
                Comando.Parameters.Add("@IdomaId", SqlDbType.Int).Value = IdomaId;
                Comando.Parameters.Add("@DominioIdiomaId", SqlDbType.Int).Value = DominioIdiomaId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_Idioma(int PuestoId, int PuestoVer, int IdomaId, int DominioIdiomaId, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleIdioma", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@IdomaId", SqlDbType.Int).Value = IdomaId;
                Comando.Parameters.Add("@DominioIdiomaId", SqlDbType.Int).Value = DominioIdiomaId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteIdioma(int PuestoId, int IdiomaId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteIdioma", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@IdiomaId", SqlDbType.Int).Value = IdiomaId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }


        [WebMethod]
        public int EditExperiencia(int PuestoId, int ExperienciaId, string Trabajo, string Tiempo, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditExperiencia", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@ExperienciaId", SqlDbType.Int).Value = ExperienciaId;
                Comando.Parameters.Add("@TipoTrabajo", SqlDbType.VarChar, 900).Value = Trabajo;
                Comando.Parameters.Add("@Tiempo", SqlDbType.VarChar, 900).Value = Tiempo;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_Experiencia(int PuestoId, int PuestoVer, string Trabajo, string Tiempo, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleExperiencia", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@TipoTrabajo", SqlDbType.VarChar, 900).Value = Trabajo;
                Comando.Parameters.Add("@Tiempo", SqlDbType.VarChar, 900).Value = Tiempo;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteExperiencia(int PuestoId, int ExperienciaId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteExperiencia", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@ExperienciaId", SqlDbType.Int).Value = ExperienciaId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public class DataCarreras
        {
            public int PuestoVer { get; set; }
            public string Carreras { get; set; }
        }

        [WebMethod]
        public List<DataCarreras> GetDataCarreras(int PuestoId)
        {
            ds.Tables.Clear();
            Cl_CrudPerfil clCrudPerfil = new Cl_CrudPerfil();
            ds = clCrudPerfil.GetCarreras(PuestoId);
            List<DataCarreras> Datos = new List<DataCarreras>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DataCarreras Registro = new DataCarreras();
                Registro.PuestoVer = Convert.ToInt32(dr["PuestoVer"].ToString());
                Registro.Carreras = dr["Carreras"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        
    }
}
