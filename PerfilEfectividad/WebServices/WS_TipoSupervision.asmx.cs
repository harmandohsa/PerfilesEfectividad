using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_TipoSupervision
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_TipoSupervision : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaTiposSupervision
        {
            public int TipoSupervisionId { get; set; }
            public string TipoSupervision { get; set; }
        }

        [WebMethod]
        public List<ListaTiposSupervision> GetListaTipoSupervision()
        {
            ds.Tables.Clear();
            Cl_TipoSupervision clTipoSupervision = new Cl_TipoSupervision();
            ds = clTipoSupervision.GetListaTipoSupervision();
            List<ListaTiposSupervision> Datos = new List<ListaTiposSupervision>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaTiposSupervision Registro = new ListaTiposSupervision();
                Registro.TipoSupervisionId = Convert.ToInt32(dr["TipoSupervisionId"]);
                Registro.TipoSupervision = dr["TipoSupervision"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
