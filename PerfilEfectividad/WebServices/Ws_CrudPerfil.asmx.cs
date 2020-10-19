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

        [WebMethod]
        public int UpdateInfoGeneral(int AreaId, string PuestoJefe, int PuestoId)
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
            string FuncAnual, string FuncEventual)
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
        public int UpdateFactores(int PuestoId, int FactorId, string Id)
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
        public int UpdateDetalleManejoBientes(int PuestoId, int ConceptoId, string Monto, int Indirecta, int Directa, int Compartida)
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
        public int DeleteDetalleSupervision(int PuestoId, int SupervisionId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteSupervision", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@SupervisionId", SqlDbType.Int).Value = SupervisionId;
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
        public int EditDetalleSupervision(int PuestoId, int SupervisionId, string Puesto, int Cantidad, int TipoSupervision)
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
                Comando.Parameters.Add("@TipoSupervision", SqlDbType.Int).Value = TipoSupervision;
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
        public int Insert_DetalleSupervisiones(int PuestoId, int PuestoVer, int TipoSupervisionId, string NombrePuesto, int Cantidad)
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
                Comando.Parameters.Add("@TipoSupervisionId", SqlDbType.Int).Value = TipoSupervisionId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;

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
            string Proposito, int FrecuenciaId, int TipoRelacionId)
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
            string Proposito, int FrecuenciaId, int TipoRelacionId)
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
        public int DeleteDetalleRelacion(int PuestoId, int RelacionId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteRelacion", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@RelacionId", SqlDbType.Int).Value = RelacionId;
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
            string AccionDocumento, string TipoInformacion, int Jefe, int AuditoriaInt, int AuditoriaExt)
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
        public int Insert_DetalleManejoInfo(int PuestoId, int PuestoVer, string Documento, string Accion, string TipoInformacion, int Jefe, int AuditoriaInt, int AuditoriaExt)
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
        public int DeleteDetalleManejoInfo(int PuestoId, int ManejoInformacionId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeleteManejoInfo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@ManejoInformacionId", SqlDbType.Int).Value = ManejoInformacionId;
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
        public int AddAmbienteTrabajo(int PuestoId, string TipoAmbienteTrabajo)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_AddAmbienteTrabajo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@TipoAmbienteTrabajo", SqlDbType.VarChar, 1000).Value = TipoAmbienteTrabajo;
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
        public int AddRiesgoOcupacional(int PuestoId, string TipoRiesgoOcupacional)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_AddRiesgoOcupacional", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@TipoRiesgoOcupacional", SqlDbType.VarChar, 1000).Value = TipoRiesgoOcupacional;
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
        public int AddEsfuerzoFisico(int PuestoId, string TipoEsfuerzoFisico)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_AddEsfuerzoFisico", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@TipoEsfuerzoFisico", SqlDbType.VarChar, 1000).Value = TipoEsfuerzoFisico;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
