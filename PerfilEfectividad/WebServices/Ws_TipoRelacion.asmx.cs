using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_TipoRelacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_TipoRelacion : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaTipoRelacion
        {
            public int TipoRelacionId { get; set; }
            public string TipoRelacion { get; set; }
        }

        [WebMethod]
        public List<ListaTipoRelacion> GetListaFrecuencia()
        {
            ds.Tables.Clear();
            Cl_TipoRelacion clTipoRelacion = new Cl_TipoRelacion();
            ds = clTipoRelacion.GetListaTipoRelacion();
            List<ListaTipoRelacion> Datos = new List<ListaTipoRelacion>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaTipoRelacion Registro = new ListaTipoRelacion();
                Registro.TipoRelacionId = Convert.ToInt32(dr["TipoRelacionId"]);
                Registro.TipoRelacion = dr["TipoRelacion"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
