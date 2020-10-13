using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_TipoEsfuerzoFisico
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_TipoEsfuerzoFisico : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaTipoEsfuerzoFisico
        {
            public int TipoEsfuerzoFisicoId { get; set; }
            public string EsfuerzoFisico { get; set; }
        }

        [WebMethod]
        public List<ListaTipoEsfuerzoFisico> GetTipoEsfuerzoFisico()
        {
            ds.Tables.Clear();
            Cl_TipoEsfuerzoFisico clTipoEsfuerzoFisico = new Cl_TipoEsfuerzoFisico();
            ds = clTipoEsfuerzoFisico.GetListaTipoEsfuerzoFisico();
            List<ListaTipoEsfuerzoFisico> Datos = new List<ListaTipoEsfuerzoFisico>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaTipoEsfuerzoFisico Registro = new ListaTipoEsfuerzoFisico();
                Registro.TipoEsfuerzoFisicoId = Convert.ToInt32(dr["TipoEsfuerzoFisicoId"]);
                Registro.EsfuerzoFisico = dr["EsfuerzoFisico"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
