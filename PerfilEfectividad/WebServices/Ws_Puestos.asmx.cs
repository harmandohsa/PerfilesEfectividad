using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Puestos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Puestos : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaPuesots
        {
            public int PuestoId { get; set; }
            public string Puesto { get; set; }
        }

        [WebMethod]
        public List<ListaPuesots> GetListaPuestos()
        {
            ds.Tables.Clear();
            Cl_Puestos clPuestos = new Cl_Puestos();
            ds = clPuestos.GetListaPuestos();
            List<ListaPuesots> Datos = new List<ListaPuesots>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaPuesots Registro = new ListaPuesots();
                Registro.PuestoId = Convert.ToInt32(dr["PuestoId"]);
                Registro.Puesto = dr["NombrePuesto"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public List<ListaPuesots> GetListaPuestosInactivos()
        {
            ds.Tables.Clear();
            Cl_Puestos clPuestos = new Cl_Puestos();
            ds = clPuestos.GetListaPuestosInactivos();
            List<ListaPuesots> Datos = new List<ListaPuesots>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaPuesots Registro = new ListaPuesots();
                Registro.PuestoId = Convert.ToInt32(dr["PuestoId"]);
                Registro.Puesto = dr["NombrePuesto"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditPuesto(int PuestoId, string NombrePuesto)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditaNombrePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
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
        public int ExistePuestoNoActual(int PuestoId, string Puesto)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuestoActual", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Existe", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Existe"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditNomprePuesto(int PuestoId, string Puesto, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditNombrePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 500).Value = Puesto;
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
        public int DeletePuesto(int PuestoId, int Estatus, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeletePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@Estatus", SqlDbType.Int).Value = Estatus;
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
        public int Insert_Puesto(string Puesto, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Puesto_New", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int ExistePuesto(string Puesto)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Resul", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public class PerfilPuesto
        {
            public string Puesto { get; set; }
            public string Area { get; set; }
            public string SubArea { get; set; }
            public string PuestoSuperior { get; set; }
            public string CodigoPuesto { get; set; }
            public string FuncionPrincipal { get; set; }
            public string Principales { get; set; }
            public string FuncionDiaria { get; set; }
            public string FuncionSemanalQuincenal { get; set; }
            public string FuncionMensual { get; set; }
            public string FuncionTrimestralSemestral { get; set; }
            public string FuncionAnual { get; set; }
            public string FuncionEventual { get; set; }
            public string TomaDescion { get; set; }
            public string EsfuerzoMetal { get; set; }
            public string ManejoBien { get; set; }
            public string Supervisiones { get; set; }
            public string RelacionInterna { get; set; }
            public string RelacionExterna { get; set; }
            public string ManejoInfo { get; set; }
            public string RiesgoOcupacional { get; set; }
            public string Riesgo { get; set; }
            public string EsfuerzoFisico { get; set; }
            public string Esfuerzo { get; set; }
            public string AmbienteTrabajo { get; set; }
            public string Ambiente { get; set; }
            public string EducacionFormal { get; set; }
            public string NivEduc { get; set; }
            public string Carreras { get; set; }
            public string ImpactoError { get; set; }
            public string OtrosEstudios { get; set; }
            public string Experiencia { get; set; }
            public int CntSupervisiones { get; set; }
            public int CntRelaciones { get; set; }
            public int CntManejoInfo { get; set; }
            public int NivEducId { get; set; }
            public int Cntcursos { get; set; }
            public int CntIdiomas { get; set; }
            public int CntExperiencia { get; set; }
        }

        [WebMethod]
        public List<PerfilPuesto> GetDataPuestoPerfil(int PuestoId, int UsuarioId)
        {
            ds.Tables.Clear();
            Cl_Puestos clPuestos = new Cl_Puestos();
            ds = clPuestos.GetDataPuestoPerfil(PuestoId, UsuarioId);
            List<PerfilPuesto> Datos = new List<PerfilPuesto>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                PerfilPuesto Registro = new PerfilPuesto();
                if (dr["NombrePuesto"].ToString() == "")
                    Registro.Puesto = "";
                else
                    Registro.Puesto = dr["NombrePuesto"].ToString();

                if (dr["Area"].ToString() == "")
                    Registro.Area = "";
                else
                    Registro.Area = dr["Area"].ToString();

                if (dr["SubArea"].ToString() == "")
                    Registro.SubArea = "";
                else
                    Registro.SubArea = dr["SubArea"].ToString();

                if (dr["PuestoSuperior"].ToString() == "")
                    Registro.PuestoSuperior = "";
                else
                    Registro.PuestoSuperior = dr["PuestoSuperior"].ToString();

                if (dr["CodigoPuesto"].ToString() == "")
                    Registro.CodigoPuesto = "";
                else
                    Registro.CodigoPuesto = dr["CodigoPuesto"].ToString();

                if (dr["FuncionPrincipal"].ToString() == "")
                    Registro.FuncionPrincipal = "";
                else
                    Registro.FuncionPrincipal = dr["FuncionPrincipal"].ToString();

                if (dr["Principales"].ToString() == "")
                    Registro.Principales = "";
                else
                    Registro.Principales = dr["Principales"].ToString();

                if (dr["FuncionDiaria"].ToString() == "")
                    Registro.FuncionDiaria = "";
                else
                    Registro.FuncionDiaria = dr["FuncionDiaria"].ToString();

                if (dr["FuncionSemanalQuincenal"].ToString() == "")
                    Registro.FuncionSemanalQuincenal = "";
                else
                    Registro.FuncionSemanalQuincenal = dr["FuncionSemanalQuincenal"].ToString();

                if (dr["FuncionMensual"].ToString() == "")
                    Registro.FuncionMensual = "";
                else
                    Registro.FuncionMensual = dr["FuncionMensual"].ToString();

                if (dr["FuncionTrimestralSemestral"].ToString() == "")
                    Registro.FuncionTrimestralSemestral = "";
                else
                    Registro.FuncionTrimestralSemestral = dr["FuncionTrimestralSemestral"].ToString();

                if (dr["FuncionAnual"].ToString() == "")
                    Registro.FuncionAnual = "";
                else
                    Registro.FuncionAnual = dr["FuncionAnual"].ToString();

                if (dr["FuncionEventual"].ToString() == "")
                    Registro.FuncionEventual = "";
                else
                    Registro.FuncionEventual = dr["FuncionEventual"].ToString();

                if (dr["FuncionEventual"].ToString() == "")
                    Registro.FuncionEventual = "";
                else
                    Registro.FuncionEventual = dr["FuncionEventual"].ToString();

                if (dr["TomaDescion"].ToString() == "")
                    Registro.TomaDescion = "";
                else
                    Registro.TomaDescion = dr["TomaDescion"].ToString();

                if (dr["EsfuerzoMental"].ToString() == "")
                    Registro.EsfuerzoMetal = "";
                else
                    Registro.EsfuerzoMetal = dr["EsfuerzoMental"].ToString();

                if (dr["ManejoBien"].ToString() == "")
                    Registro.ManejoBien = "";
                else
                    Registro.ManejoBien = dr["ManejoBien"].ToString();

                if (dr["Supervisiones"].ToString() == "")
                    Registro.Supervisiones = "";
                else
                    Registro.Supervisiones = dr["Supervisiones"].ToString();

                if (dr["RelacionInterna"].ToString() == "")
                    Registro.RelacionInterna = "";
                else
                    Registro.RelacionInterna = dr["RelacionInterna"].ToString();

                if (dr["RelacionExterna"].ToString() == "")
                    Registro.RelacionExterna = "";
                else
                    Registro.RelacionExterna = dr["RelacionExterna"].ToString();

                if (dr["ManejoInfo"].ToString() == "")
                    Registro.ManejoInfo = "";
                else
                    Registro.ManejoInfo = dr["ManejoInfo"].ToString();

                if (dr["RiesgoOcupacional"].ToString() == "")
                    Registro.RiesgoOcupacional = "";
                else
                    Registro.RiesgoOcupacional = dr["RiesgoOcupacional"].ToString();

                if (dr["Riesgo"].ToString() == "")
                    Registro.Riesgo = "";
                else
                    Registro.Riesgo = dr["Riesgo"].ToString();

                if (dr["EsfuerzoFisico"].ToString() == "")
                    Registro.EsfuerzoFisico = "";
                else
                    Registro.EsfuerzoFisico = dr["EsfuerzoFisico"].ToString();

                if (dr["Esfuerzo"].ToString() == "")
                    Registro.Esfuerzo = "";
                else
                    Registro.Esfuerzo = dr["Esfuerzo"].ToString();

                if (dr["AmbienteTrabajo"].ToString() == "")
                    Registro.AmbienteTrabajo = "";
                else
                    Registro.AmbienteTrabajo = dr["AmbienteTrabajo"].ToString();

                if (dr["Ambiente"].ToString() == "")
                    Registro.Ambiente = "";
                else
                    Registro.Ambiente = dr["Ambiente"].ToString();

                if (dr["EducacionFormal"].ToString() == "")
                    Registro.EducacionFormal = "";
                else
                    Registro.EducacionFormal = dr["EducacionFormal"].ToString();

                if (dr["NivEduc"].ToString() == "")
                    Registro.NivEduc = "";
                else
                    Registro.NivEduc = dr["NivEduc"].ToString();

                if (dr["Carreras"].ToString() == "")
                    Registro.Carreras = "";
                else
                    Registro.Carreras = dr["Carreras"].ToString();

                if (dr["ImpactoError"].ToString() == "")
                    Registro.ImpactoError = "";
                else
                    Registro.ImpactoError = dr["ImpactoError"].ToString();

                if (dr["OtrosEstudios"].ToString() == "")
                    Registro.OtrosEstudios = "";
                else
                    Registro.OtrosEstudios = dr["OtrosEstudios"].ToString();

                if (dr["Experiencia"].ToString() == "")
                    Registro.Experiencia = "";
                else
                    Registro.Experiencia = dr["Experiencia"].ToString();
                Registro.CntSupervisiones = Convert.ToInt32(dr["CntSupervision"].ToString());
                Registro.CntRelaciones = Convert.ToInt32(dr["CntRelaciones"].ToString());
                Registro.CntManejoInfo = Convert.ToInt32(dr["CntManejoInfo"].ToString());
                if (dr["NivEducId"].ToString() == "")
                    Registro.NivEducId = 0;
                else
                    Registro.NivEducId = Convert.ToInt32(dr["NivEducId"].ToString());
                Registro.Cntcursos = Convert.ToInt32(dr["Cntcursos"].ToString());
                Registro.CntIdiomas = Convert.ToInt32(dr["CntIdiomas"].ToString());
                Registro.CntExperiencia = Convert.ToInt32(dr["CntExperiencia"].ToString());

                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public string GetCategoriaPuesto(int PuestoId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetCategoriaPuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@Categoria", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                string Resultado = Comando.Parameters["@Categoria"].Value.ToString();
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return "Sin Categoría";
            }

        }

    }
}
