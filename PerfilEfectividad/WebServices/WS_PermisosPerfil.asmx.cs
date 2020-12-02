using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_PermisosPerfil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_PermisosPerfil : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class PermisosPerfil
        {
            public int PaginaId { get; set; }
            public string Pagina { get; set; }
            public int ModuloId { get; set; }
            public string Modulo { get; set; }
            public int Consultar { get; set; }
            public int Insertar { get; set; }
            public int Editar { get; set; }
            public int Eliminar { get; set; }
            public int Imprimir { get; set; }
        }

        [WebMethod]
        public List<PermisosPerfil> GetPermisosPerfil(int PerfilId)
        {
            ds.Tables.Clear();
            CL_PermisosPerfil clPermisosPerfil = new CL_PermisosPerfil();
            ds = clPermisosPerfil.GetPermisosPerfil(PerfilId);
            List<PermisosPerfil> Datos = new List<PermisosPerfil>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                PermisosPerfil Registro = new PermisosPerfil();
                Registro.PaginaId = Convert.ToInt32(dr["PaginaId"]);
                Registro.Pagina = dr["Pagina"].ToString();
                Registro.ModuloId = Convert.ToInt32(dr["ModuloId"]);
                Registro.Modulo = dr["Modulo"].ToString();
                Registro.Consultar = Convert.ToInt32(dr["Consultar"]);
                Registro.Insertar = Convert.ToInt32(dr["Insertar"]);
                Registro.Editar = Convert.ToInt32(dr["Editar"]);
                Registro.Eliminar = Convert.ToInt32(dr["Eliminar"]);
                Registro.Imprimir = Convert.ToInt32(dr["Imprimir"]);
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public string Update_PermisoPaginaPerfil(int PaginaId, int PerfilId, int Opcion, int Permiso)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Update_PermisoPaginaPerfil", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaginaId", SqlDbType.Int).Value = PaginaId;
                Comando.Parameters.Add("@PerfilId", SqlDbType.Int).Value = PerfilId;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
                Comando.Parameters.Add("@Permiso", SqlDbType.Int).Value = Permiso;
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
        public string HeredaPermiso(int PaginaId, int PerfilId, int Opcion, int Permiso)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_HeredaPermiso", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaginaId", SqlDbType.Int).Value = PaginaId;
                Comando.Parameters.Add("@PerfilId", SqlDbType.Int).Value = PerfilId;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = Opcion;
                Comando.Parameters.Add("@Permiso", SqlDbType.Int).Value = Permiso;
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
