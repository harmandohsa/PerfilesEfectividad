using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Carreras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Carreras : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaCarreras
        {
            public int CarreraId { get; set; }
            public string Carrera { get; set; }
        }

        [WebMethod]
        public List<ListaCarreras> GetListaCarreras(int GradoId)
        {
            ds.Tables.Clear();
            Cl_Carreras clCarreras = new Cl_Carreras();
            ds = clCarreras.GetListaCarreras(GradoId);
            List<ListaCarreras> Datos = new List<ListaCarreras>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaCarreras Registro = new ListaCarreras();
                Registro.CarreraId = Convert.ToInt32(dr["CarreraId"]);
                Registro.Carrera = dr["Carrera"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
