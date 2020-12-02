using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using PerfilEfectividad.Clases;

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
        DataSet ds = new DataSet();

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

        public class DatosUsuario
        {
            public int UsuarioId { get; set; }
            public string Nombre { get; set; }
            public int PerfilId { get; set; }
            public string Correo { get; set; }
            public string Usuario { get; set; }
            public string Clave { get; set; }
            public int CambiaClave { get; set; }
            public int EstatusUsuario { get; set; }
        }

        [WebMethod]
        public List<DatosUsuario> GetDatosUsuario(string Usuario)
        {
            ds.Tables.Clear();
            
            Cl_Login cllogin = new Cl_Login();
            Ws_Generales wsGenerales = new Ws_Generales();
            ds = cllogin.GetDatosUsuario(Usuario);
            List<DatosUsuario> Datos = new List<DatosUsuario>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DatosUsuario Registro = new DatosUsuario();
                Registro.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                Registro.Nombre = dr["Nombre"].ToString();
                Registro.PerfilId = Convert.ToInt32(dr["PerfilId"]);
                Registro.CambiaClave = Convert.ToInt32(dr["CambiaClave"]);
                Registro.Correo = dr["Correo"].ToString();
                Registro.Clave = wsGenerales.Decrypt(dr["Clave"].ToString());
                Registro.EstatusUsuario = Convert.ToInt32(dr["EstatusUsuarioId"]);
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public List<DatosUsuario> GetDatosUsuarioById(int UsuarioId)
        {
            ds.Tables.Clear();

            Cl_Login cllogin = new Cl_Login();
            ds = cllogin.GetDatosUsuariById(UsuarioId);
            List<DatosUsuario> Datos = new List<DatosUsuario>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                DatosUsuario Registro = new DatosUsuario();
                Registro.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                Registro.Nombre = dr["Nombres"].ToString();
                Registro.Correo = dr["Correo"].ToString();
                Registro.Usuario = dr["Usuario"].ToString();
                Registro.Clave = dr["Clave"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int GrabaBitacoraIngreso(string Usuario)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_InsertBitacoraIngreso", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 200).Value = Usuario;
                Comando.Parameters.Add("@IngresoId", SqlDbType.Int).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();
                int Respuesta = Convert.ToInt32(Comando.Parameters["@IngresoId"].Value);
                cn.Close();

                return Respuesta;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        [WebMethod]
        public int GrabaBitacoraSalida(int UsuarioId, int IngresoId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_InsertBitacoraSalida", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@IngresoId", SqlDbType.Int).Value = IngresoId;
                Comando.ExecuteNonQuery();
                cn.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }

        }

    }
}
