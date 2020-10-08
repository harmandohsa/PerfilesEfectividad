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

    }
}
