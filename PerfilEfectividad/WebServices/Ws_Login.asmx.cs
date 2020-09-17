using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Login
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Login : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);

        [WebMethod]
        public int ExisteUsuarioClave(string Usuario, string Clave)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExisteUsuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
                Comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();
                int Respuesta = Convert.ToInt32(Comando.Parameters["@Resul"].Value);
                cn.Close();
                return Respuesta;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
