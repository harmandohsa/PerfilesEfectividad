using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_PermisosUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_PermisosUsuario : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class PermisosUsuario
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
        public List<PermisosUsuario> kt_table_permisosUsuarios(int UsuarioId)
        {
            ds.Tables.Clear();
            Cl_PermisosUsuario clpermisosUsuario = new Cl_PermisosUsuario();
            ds = clpermisosUsuario.GetPermisosUsuario(UsuarioId);
            List<PermisosUsuario> Datos = new List<PermisosUsuario>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                PermisosUsuario Registro = new PermisosUsuario();
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
        public string Update_PermisoPaginaUsuario(int PaginaId, int UsuarioId, int Opcion, int Permiso)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Update_PermisoPaginaUsuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PaginaId", SqlDbType.Int).Value = PaginaId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
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
