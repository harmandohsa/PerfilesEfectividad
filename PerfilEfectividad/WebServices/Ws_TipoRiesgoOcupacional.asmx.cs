using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_TipoRiesgoOcupacional
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_TipoRiesgoOcupacional : System.Web.Services.WebService
    {

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaTipoRiesgoOcupacional
        {
            public int TipoRiesgoOcupacionalId { get; set; }
            public string TipoRiesgoOcupacional { get; set; }
        }

        [WebMethod]
        public List<ListaTipoRiesgoOcupacional> GetTipoRiesgoOcupacional()
        {
            ds.Tables.Clear();
            CL_TipoRiesgoOcupacional clTipoRiesgoOcupacional = new CL_TipoRiesgoOcupacional();
            ds = clTipoRiesgoOcupacional.GetListaTipoRiesgoOcupacional();
            List<ListaTipoRiesgoOcupacional> Datos = new List<ListaTipoRiesgoOcupacional>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaTipoRiesgoOcupacional Registro = new ListaTipoRiesgoOcupacional();
                Registro.TipoRiesgoOcupacionalId = Convert.ToInt32(dr["TipoRiesgoOcupacionalId"]);
                Registro.TipoRiesgoOcupacional = dr["TipoRiesgoOcupacional"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }
    }
}
