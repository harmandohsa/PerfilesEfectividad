using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;
namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Bitacoras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Bitacoras : System.Web.Services.WebService
    {

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaBitacoraActidad
        {
            public string Fecha { get; set; }
            public string Actividad { get; set; }
            public string Nombre { get; set; }
            public string FechaLong { get; set; }
            public string Puesto { get; set; }
        }

        [WebMethod]
        public List<ListaBitacoraActidad> GetBitacorasActividades(string FecIni, string FecFin, string Usuarios, string Actividades, string Puestos)
        {
            ds.Tables.Clear();
            Cl_BitacoraActividad clBitacoras = new Cl_BitacoraActividad();
            ds = clBitacoras.GetBitacoraActividades(FecIni,FecFin,Usuarios,Actividades, Puestos);
            List<ListaBitacoraActidad> Datos = new List<ListaBitacoraActidad>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaBitacoraActidad Registro = new ListaBitacoraActidad();
                Registro.Fecha = dr["Fecha"].ToString();
                Registro.Actividad = dr["Actividad"].ToString();
                Registro.Nombre = dr["Nombre"].ToString();
                Registro.FechaLong = dr["FechaLong"].ToString();
                Registro.Puesto = dr["Puesto"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
