using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Perfil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Perfil : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        [WebMethod]
        public string InsertPerfil(string Perfil)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Perfil", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Perfil", SqlDbType.VarChar, 200).Value = Perfil;
                Comando.ExecuteNonQuery();
                cn.Close();
                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string EditPerfil(int PerfilId, string Perfil)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Edit_Perfil", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PerfilId", SqlDbType.Int).Value = PerfilId;
                Comando.Parameters.Add("@Perfil", SqlDbType.VarChar, 200).Value = Perfil;
                Comando.ExecuteNonQuery();
                cn.Close();
                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public class ListaPerfiles
        {
            public int PerfilId { get; set; }
            public string Perfil { get; set; }
            public int CntUsuarios { get; set; }
        }

        [WebMethod]
        public List<ListaPerfiles> GetListaPerfiles()
        {
            ds.Tables.Clear();
            CL_Perfil clPerfil = new CL_Perfil();
            ds = clPerfil.GetListaPerfiles();
            List<ListaPerfiles> Datos = new List<ListaPerfiles>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaPerfiles Registro = new ListaPerfiles();
                Registro.PerfilId = Convert.ToInt32(dr["PerfilId"]);
                Registro.Perfil = dr["Perfil"].ToString();
                Registro.CntUsuarios = Convert.ToInt32(dr["CntUsuarios"]);
                Datos.Add(Registro);
            }
            return Datos;
        }

    }
}
