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

    }
}
