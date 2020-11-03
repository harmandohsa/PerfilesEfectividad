using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Idioma
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Idioma : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaIdomas
        {
            public int IdiomaId { get; set; }
            public string Idioma { get; set; }
        }

        [WebMethod]
        public List<ListaIdomas> GetListaIdioma()
        {
            ds.Tables.Clear();
            Cl_Idiomas clIdioma = new Cl_Idiomas();
            ds = clIdioma.GetListaIdiomas();
            List<ListaIdomas> Datos = new List<ListaIdomas>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaIdomas Registro = new ListaIdomas();
                Registro.IdiomaId = Convert.ToInt32(dr["IdomaId"]);
                Registro.Idioma = dr["Idioma"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
