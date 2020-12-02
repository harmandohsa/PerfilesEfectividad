using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_PerfilUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_PerfilUsuario : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaDatosUsuarios
        {
            public int UsuarioId { get; set; }
            public string Nombres { get; set; }
            public string Pais { get; set; }
            public string Sede { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string Usuario { get; set; }
            public string Perfil { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

        [WebMethod]
        public List<ListaDatosUsuarios> GetDatosUsuario(int Usuarioid)
        {
            ds.Tables.Clear();
            CL_PerfilUsuario clPerfilUsuario = new CL_PerfilUsuario();
            ds = clPerfilUsuario.GetDatosUsuario(Usuarioid);
            List<ListaDatosUsuarios> Datos = new List<ListaDatosUsuarios>();

            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaDatosUsuarios Registro = new ListaDatosUsuarios();
                Registro.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                Registro.Nombres = dr["Nombres"].ToString();
                Registro.Pais = dr["Pais"].ToString();
                Registro.Sede = dr["Sede"].ToString();
                Registro.Telefono = dr["Telefono"].ToString();
                Registro.Correo = dr["Correo"].ToString();
                Registro.Usuario = dr["Usuario"].ToString();
                Registro.Perfil = dr["Perfil"].ToString();
                Registro.Nombre = dr["Nombre"].ToString();
                Registro.Apellido = dr["Apellidos"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public string UpdateFotoUsuario(int UsuarioId, string Foto, string fileName, string ContentType)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Foto);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);


                cn.Open();
                SqlCommand Comando = new SqlCommand("UpdateFotoUsuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Logo", SqlDbType.VarBinary).Value = imageBytes;
                Comando.Parameters.Add("@ContentType", SqlDbType.VarChar, 200).Value = ContentType;
                Comando.Parameters.Add("@NombreFoto", SqlDbType.VarChar, 200).Value = fileName;
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
        public string EditPerfilUsuario(int UsuarioId, string Telefono, string Correo)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Edit_PerfilUsuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 200).Value = Telefono;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar, 200).Value = Correo;

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
        public string GetFotoUsuario(int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetFotoUsuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.VarChar, 500).Value = UsuarioId;
                Comando.Parameters.Add("@Res", SqlDbType.VarBinary, 5000000).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();

                string Respuesta = Convert.ToBase64String((byte[])Comando.Parameters["@Res"].Value);
                cn.Close();

                return Respuesta;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

    }
}
