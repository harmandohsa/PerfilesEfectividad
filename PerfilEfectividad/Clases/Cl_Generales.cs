using System;
using System.Data;
using System.Data.SqlClient;


namespace PerfilEfectividad.Clases
{
    public class Cl_Generales
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public DataSet PermisosUsuarioPagina(int UsuarioId, int PaginaId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Get_PermisosUsuarioPagina", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@PaginaId", SqlDbType.Int).Value = PaginaId;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                cn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }

        }

        public DataSet PermisosUsuario(int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Get_PermisosUsuario", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("UsuarioId", SqlDbType.Int).Value = UsuarioId;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                cn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }

        }
    }
}