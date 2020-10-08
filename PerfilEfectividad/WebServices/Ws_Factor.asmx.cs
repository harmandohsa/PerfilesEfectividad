using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Factor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Factor : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaFactor
        {
            public int Id { get; set; }
            public string Texto { get; set; }
        }

        [WebMethod]
        public List<ListaFactor> GetListaFactor(int FactorId)
        {
            ds.Tables.Clear();
            Cl_Factor clFactor = new Cl_Factor();
            ds = clFactor.GetListaFactor(FactorId);
            List<ListaFactor> Datos = new List<ListaFactor>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaFactor Registro = new ListaFactor();
                Registro.Id = Convert.ToInt32(dr["Id"]);
                Registro.Texto = dr["Texto"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }
    }
}
