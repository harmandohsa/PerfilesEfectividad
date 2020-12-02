using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Usuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Usuarios : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaUsuarios
        {
            public int UsuarioId { get; set; }
            public string Nombres { get; set; }
            public int PaisId { get; set; }
            public int SedeId { get; set; }
            public string Sede { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string Usuario { get; set; }
            public int PerfilId { get; set; }
            public string Perfil { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int CntIngresos { get; set; }
            public int EstatusUsuarioId { get; set; }
            public string EstatusUsuario { get; set; }
        }

        [WebMethod]
        public List<ListaUsuarios> GetListaUsuarios()
        {
            ds.Tables.Clear();
            Cl_Usuarios clUsuarios = new Cl_Usuarios();
            ds = clUsuarios.GetListaUsuarios();
            List<ListaUsuarios> Datos = new List<ListaUsuarios>();

            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaUsuarios Registro = new ListaUsuarios();
                Registro.UsuarioId = Convert.ToInt32(dr["UsuarioId"]);
                Registro.Nombres = dr["Nombres"].ToString();
                Registro.SedeId = Convert.ToInt32(dr["SedeId"]);
                Registro.Sede = dr["Sede"].ToString();
                Registro.Telefono = dr["Telefono"].ToString();
                Registro.Correo = dr["Correo"].ToString();
                Registro.Usuario = dr["Usuario"].ToString();
                Registro.PerfilId = Convert.ToInt32(dr["PerfilId"]);
                Registro.Perfil = dr["Perfil"].ToString();
                Registro.Nombre = dr["Nombre"].ToString();
                Registro.Apellido = dr["Apellidos"].ToString();
                Registro.CntIngresos = Convert.ToInt32(dr["CntIngresos"]);
                Registro.PaisId = Convert.ToInt32(dr["PaisId"]);
                Registro.EstatusUsuarioId = Convert.ToInt32(dr["EstatusUsuarioId"]);
                Registro.EstatusUsuario = dr["EstatusUsuario"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int ExisteCorreo(string Correo)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExisteCorreo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@correo", SqlDbType.VarChar, 200).Value = Correo;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();
                int Respuesta = Convert.ToInt32(Comando.Parameters["@Resul"].Value);
                cn.Close();

                return Respuesta;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        [WebMethod]
        public int ExisteTelefono(string Telefono)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExisteTelefono", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 200).Value = Telefono.Trim();
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();
                int Respuesta = Convert.ToInt32(Comando.Parameters["@Resul"].Value);
                cn.Close();

                return Respuesta;
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
                return -1;
            }

        }

        [WebMethod]
        public int ExisteUsuario(string Usuario)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExisteUsuarioNew", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 200).Value = Usuario.Trim();
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;

                Comando.ExecuteNonQuery();
                int Respuesta = Convert.ToInt32(Comando.Parameters["@Resul"].Value);
                cn.Close();

                return Respuesta;
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
                return -1;
            }

        }

        [WebMethod]
        public string InsertUsuario(string Nombres, string Apellidos, string Correo, string Usuario, int PerfilId, int SedeId, string Telefono, int UsuarioId)
        {
            try
            {
                Cl_Usuarios clUsuarios = new Cl_Usuarios();
                Ws_Generales wsGenerales = new Ws_Generales();
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Usuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 200).Value = Nombres;
                Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 200).Value = Apellidos;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar, 200).Value = Correo;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 200).Value = Usuario;
                Comando.Parameters.Add("@PerfilId", SqlDbType.Int).Value = PerfilId;
                Comando.Parameters.Add("@SedeId", SqlDbType.Int).Value = SedeId;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 200).Value = Telefono;
                Comando.Parameters.Add("@UsuarioIdCrea", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Clave", SqlDbType.VarChar, 500).Value = wsGenerales.Encrypt(clUsuarios.GeneraClave());

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
        public string EditUsuario(int UsuarioId, string Nombres, string Apellidos, string Correo, string Usuario, int PerfilId, int SedeId, string Telefono, int CambiaPermisos)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Edit_Usuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 200).Value = Nombres;
                Comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 200).Value = Apellidos;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar, 200).Value = Correo;
                Comando.Parameters.Add("@Usuario", SqlDbType.VarChar, 200).Value = Usuario;
                Comando.Parameters.Add("@PerfilId", SqlDbType.Int).Value = PerfilId;
                Comando.Parameters.Add("@SedeId", SqlDbType.Int).Value = SedeId;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 200).Value = Telefono;
                Comando.Parameters.Add("@CambiaPermisos", SqlDbType.Int).Value = CambiaPermisos;
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
        public string EditClave(int UsuarioId, string Clave, int CambiaClave)
        {
            try
            {
                Ws_Generales wsGenerales = new Ws_Generales();
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ChangeClave", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Clave", SqlDbType.VarChar, 200).Value = wsGenerales.Encrypt(Clave);
                Comando.Parameters.Add("@CambiaClave", SqlDbType.Int).Value = CambiaClave;
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
        public string EditEstatus(int UsuarioId, int Estatus)
        {
            try
            {
                Ws_Generales wsGenerales = new Ws_Generales();
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ChangeEstatus", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Estatus", SqlDbType.Int).Value = Estatus;
                Comando.ExecuteNonQuery();
                cn.Close();

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
