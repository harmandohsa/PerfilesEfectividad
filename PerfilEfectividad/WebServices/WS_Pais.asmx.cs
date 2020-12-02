using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Pais
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Pais : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaPais
        {
            public int PaisId { get; set; }
            public string Pais { get; set; }
        }

        [WebMethod]
        public List<ListaPais> GetListaPais()
        {
            ds.Tables.Clear();
            Cl_Pais clPais = new Cl_Pais();
            ds = clPais.GetListaPaises();
            List<ListaPais> Datos = new List<ListaPais>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaPais Registro = new ListaPais();
                Registro.PaisId = Convert.ToInt32(dr["PaisId"]);
                Registro.Pais = dr["Pais"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditPais(int PaisId, string Pais)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Edit_Pais", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaisId", SqlDbType.Int).Value = PaisId;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar, 500).Value = Pais;
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
        public int Insert_Pais(string Pais)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Pais", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar, 500).Value = Pais;
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
        public int DeletePais(int PaisId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_Pais", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaisId", SqlDbType.Int).Value = PaisId;
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
