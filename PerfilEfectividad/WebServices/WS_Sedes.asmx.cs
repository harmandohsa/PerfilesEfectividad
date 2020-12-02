using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Sedes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Sedes : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaSedes
        {
            public int PaisId { get; set; }
            public string Pais { get; set; }
            public int SedeId { get; set; }
            public string Sede { get; set; }
        }

        [WebMethod]
        public List<ListaSedes> GetListaSedes()
        {
            ds.Tables.Clear();
            CL_Sede clSede = new CL_Sede();
            ds = clSede.GetListaSedes();
            List<ListaSedes> Datos = new List<ListaSedes>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaSedes Registro = new ListaSedes();
                Registro.PaisId = Convert.ToInt32(dr["PaisId"]);
                Registro.Pais = dr["Pais"].ToString();
                Registro.SedeId = Convert.ToInt32(dr["SedeId"]);
                Registro.Sede = dr["Sede"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class ListaSedePais
        {
            public int SedeId { get; set; }
            public string Sede { get; set; }
        }

        [WebMethod]
        public List<ListaSedePais> GetListaSedePais(int PaisId)
        {
            ds.Tables.Clear();
            CL_Sede clSede = new CL_Sede();
            ds = clSede.GetListaSedePais(PaisId);
            List<ListaSedePais> Datos = new List<ListaSedePais>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaSedePais Registro = new ListaSedePais();
                Registro.SedeId = Convert.ToInt32(dr["SedeId"]);
                Registro.Sede = dr["Sede"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditSede(int PaisId, int SedeId, string Sede)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditSede", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaisId", SqlDbType.Int).Value = PaisId;
                Comando.Parameters.Add("@SedeId", SqlDbType.Int).Value = SedeId;
                Comando.Parameters.Add("@Sede", SqlDbType.VarChar, 500).Value = Sede;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_Sede(string Sede, int PaisId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Sede", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaisId", SqlDbType.Int).Value = PaisId;
                Comando.Parameters.Add("@Sede", SqlDbType.VarChar, 500).Value = Sede;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeleteSede(int SedeId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_Sede", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@SedeId", SqlDbType.Int).Value = SedeId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
