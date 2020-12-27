using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Actividad
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Actividad : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaActividades
        {
            public int ActividadId { get; set; }
            public string Actividad { get; set; }
        }

        [WebMethod]
        public List<ListaActividades> GetListaActividades()
        {
            ds.Tables.Clear();
            Cl_Actividad clActividad = new Cl_Actividad();
            ds = clActividad.GetListaActividades();
            List<ListaActividades> Datos = new List<ListaActividades>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaActividades Registro = new ListaActividades();
                Registro.ActividadId = Convert.ToInt32(dr["ActividadId"]);
                Registro.Actividad = dr["Actividad"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
