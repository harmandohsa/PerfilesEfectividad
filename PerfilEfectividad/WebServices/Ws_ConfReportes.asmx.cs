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
    /// Summary description for Ws_ConfReportes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_ConfReportes : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ConfiguracionReporte
        {
            public int InfoGeneral { get; set; }
            public int Tareas { get; set; }
            public int TomaDesiciones { get; set; }
            public int EsfuerzoMental { get; set; }
            public int ManejoBienes { get; set; }
            public int Supervision { get; set; }
            public int RelacionesTrabajo { get; set; }
            public int ManejoInfo { get; set; }
            public int AmbienteTrabajo { get; set; }
            public int RiesgoOcupacional { get; set; }
            public int EsfuerzoFisico { get; set; }
            public int EducacionFormal { get; set; }
            public int ImpactoError { get; set; }
            public int CursosTecnicos { get; set; }
            public int OtrasEstudios { get; set; }
            public int Idiomas { get; set; }
            public int Experiencia { get; set; }
        }

        [WebMethod]
        public List<ConfiguracionReporte> GetConfReportes()
        {
            ds.Tables.Clear();
            Cl_ConfReportes clConfReporetes = new Cl_ConfReportes();
            ds = clConfReporetes.GetConfiguracionReporte();
            List<ConfiguracionReporte> Datos = new List<ConfiguracionReporte>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ConfiguracionReporte Registro = new ConfiguracionReporte();
                Registro.InfoGeneral = Convert.ToInt32(dr["InfoGeneral"]);
                Registro.Tareas = Convert.ToInt32(dr["Tareas"]);
                Registro.TomaDesiciones = Convert.ToInt32(dr["TomaDesiciones"]);
                Registro.EsfuerzoMental = Convert.ToInt32(dr["EsfuerzoMental"]);
                Registro.ManejoBienes = Convert.ToInt32(dr["ManejoBienes"]);
                Registro.Supervision = Convert.ToInt32(dr["Supervision"]);
                Registro.RelacionesTrabajo = Convert.ToInt32(dr["RelacionesTrabajo"]);
                Registro.ManejoInfo = Convert.ToInt32(dr["ManejoInfo"]);
                Registro.AmbienteTrabajo = Convert.ToInt32(dr["AmbienteTrabajo"]);
                Registro.RiesgoOcupacional = Convert.ToInt32(dr["RiesgoOcupacional"]);
                Registro.EsfuerzoFisico = Convert.ToInt32(dr["EsfuerzoFisico"]);
                Registro.EducacionFormal = Convert.ToInt32(dr["EducacionFormal"]);
                Registro.ImpactoError = Convert.ToInt32(dr["ImpactoError"]);
                Registro.CursosTecnicos = Convert.ToInt32(dr["CursosTecnicos"]);
                Registro.OtrasEstudios = Convert.ToInt32(dr["OtrasEstudios"]);
                Registro.Idiomas = Convert.ToInt32(dr["Idiomas"]);
                Registro.Experiencia = Convert.ToInt32(dr["Experiencia"]);
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditConfReportes(int InfoGeneral, int Tareas, int TomaDesiciones, int EsfuerzoMental, int ManejoBienes, int Supervision, int RelacionesTrabajo, int ManejoInfo, int AmbienteTrabajo, 
            int RiesgoOcupacional, int EsfuerzoFisico, int EducacionFormal, int ImpactoError, int CursosTecnicos, int OtrasEstudios, int Idiomas, int Experiencia)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_UPdateConfReporte", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@InfoGeneral", SqlDbType.Int).Value = InfoGeneral;
                Comando.Parameters.Add("@Tareas", SqlDbType.Int).Value = Tareas;
                Comando.Parameters.Add("@TomaDesiciones", SqlDbType.Int).Value = TomaDesiciones;
                Comando.Parameters.Add("@EsfuerzoMental", SqlDbType.Int).Value = EsfuerzoMental;
                Comando.Parameters.Add("@ManejoBienes", SqlDbType.Int).Value = ManejoBienes;
                Comando.Parameters.Add("@Supervision", SqlDbType.Int).Value = Supervision;
                Comando.Parameters.Add("@RelacionesTrabajo", SqlDbType.Int).Value = RelacionesTrabajo;
                Comando.Parameters.Add("@ManejoInfo", SqlDbType.Int).Value = ManejoInfo;
                Comando.Parameters.Add("@AmbienteTrabajo", SqlDbType.Int).Value = AmbienteTrabajo;
                Comando.Parameters.Add("@RiesgoOcupacional", SqlDbType.Int).Value = RiesgoOcupacional;
                Comando.Parameters.Add("@EsfuerzoFisico", SqlDbType.Int).Value = EsfuerzoFisico;
                Comando.Parameters.Add("@EducacionFormal", SqlDbType.Int).Value = EducacionFormal;
                Comando.Parameters.Add("@ImpactoError", SqlDbType.Int).Value = ImpactoError;
                Comando.Parameters.Add("@CursosTecnicos", SqlDbType.Int).Value = CursosTecnicos;
                Comando.Parameters.Add("@OtrasEstudios", SqlDbType.Int).Value = OtrasEstudios;
                Comando.Parameters.Add("@Idiomas", SqlDbType.Int).Value = Idiomas;
                Comando.Parameters.Add("@Experiencia", SqlDbType.Int).Value = Experiencia;
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
        public string GetLogo()
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetLogo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Res", SqlDbType.VarBinary, 5000000).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();

                string Respuesta = Convert.ToBase64String((byte[])Comando.Parameters["@Res"].Value);
                cn.Close();

                return Respuesta;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        [WebMethod]
        public byte[] GetLogoaByte()
        {
            byte[] Respuesta;
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetLogo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Res", SqlDbType.VarBinary, 5000000).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();

                Respuesta = (byte[])Comando.Parameters["@Res"].Value;
                cn.Close();

                return Respuesta;
            }
            catch (Exception ex)
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetLogo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Res", SqlDbType.VarBinary, 5000000).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();

                Respuesta = (byte[])Comando.Parameters["@Res"].Value;
                cn.Close();
                return Respuesta;
            }

        }

        [WebMethod]
        public string UpdateLogo(string Foto, string fileName, string ContentType)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Foto);
                System.IO.MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);


                cn.Open();
                SqlCommand Comando = new SqlCommand("UpdateLogo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = imageBytes;
                Comando.Parameters.Add("@ContentType", SqlDbType.VarChar, 200).Value = ContentType;
                Comando.Parameters.Add("@NombreFoto", SqlDbType.VarChar, 200).Value = fileName;
                Comando.ExecuteNonQuery();
                cn.Close();
                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
