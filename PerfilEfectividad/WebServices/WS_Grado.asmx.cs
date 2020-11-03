using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Grado
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Grado : System.Web.Services.WebService
    {

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaGrados
        {
            public int GradoId { get; set; }
            public string Grado { get; set; }
        }

        [WebMethod]
        public List<ListaGrados> GetListaGrados()
        {
            ds.Tables.Clear();
            Cl_Grado clGrado = new Cl_Grado();
            ds = clGrado.GetListaGrados();
            List<ListaGrados> Datos = new List<ListaGrados>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaGrados Registro = new ListaGrados();
                Registro.GradoId = Convert.ToInt32(dr["GradoId"]);
                Registro.Grado = dr["Grado"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
