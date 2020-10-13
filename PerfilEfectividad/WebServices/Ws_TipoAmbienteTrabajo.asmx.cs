using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_TipoAmbienteTrabajo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_TipoAmbienteTrabajo : System.Web.Services.WebService
    {

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaTipoAmbienteTrabajo
        {
            public int TipoAmbienteTrabajoId { get; set; }
            public string TipoAmbienteTrabajo { get; set; }
        }

        [WebMethod]
        public List<ListaTipoAmbienteTrabajo> GetTipoAmbienteTrabajo()
        {
            ds.Tables.Clear();
            Cl_TipoAmbienteTrabajo clTipoAmbiente = new Cl_TipoAmbienteTrabajo();
            ds = clTipoAmbiente.GetListaTipoAmbienteTrabajo();
            List<ListaTipoAmbienteTrabajo> Datos = new List<ListaTipoAmbienteTrabajo>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaTipoAmbienteTrabajo Registro = new ListaTipoAmbienteTrabajo();
                Registro.TipoAmbienteTrabajoId = Convert.ToInt32(dr["TipoAmbienteTrabajoId"]);
                Registro.TipoAmbienteTrabajo = dr["TipoAmbienteTrabajo"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }
    }
}
