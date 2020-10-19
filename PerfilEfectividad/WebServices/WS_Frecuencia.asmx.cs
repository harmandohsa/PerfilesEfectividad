using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Frecuencia
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Frecuencia : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaFrecuencia
        {
            public int FrecuenciaId { get; set; }
            public string Frecuencia { get; set; }
        }

        [WebMethod]
        public List<ListaFrecuencia> GetListaFrecuencia()
        {
            ds.Tables.Clear();
            Cl_Frecuencia clFrecuencia = new Cl_Frecuencia();
            ds = clFrecuencia.GetListaFrecuencias();
            List<ListaFrecuencia> Datos = new List<ListaFrecuencia>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaFrecuencia Registro = new ListaFrecuencia();
                Registro.FrecuenciaId = Convert.ToInt32(dr["FrecuenciaId"]);
                Registro.Frecuencia = dr["Frecuencia"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
