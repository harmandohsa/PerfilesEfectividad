using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_DominioIdioma
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_DominioIdioma : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaDominioIdomas
        {
            public int DominioIdiomaId { get; set; }
            public string DominioIdioma { get; set; }
        }

        [WebMethod]
        public List<ListaDominioIdomas> GetListaDominioIdioma()
        {
            ds.Tables.Clear();
            Cl_DominioIdioma clDominioIdioma = new Cl_DominioIdioma();
            ds = clDominioIdioma.GetListaDominioIdiomas();
            List<ListaDominioIdomas> Datos = new List<ListaDominioIdomas>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaDominioIdomas Registro = new ListaDominioIdomas();
                Registro.DominioIdiomaId = Convert.ToInt32(dr["DominioIdiomaId"]);
                Registro.DominioIdioma = dr["DominioIdioma"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
