using System;
using System.Data;
using System.Data.SqlClient;

namespace PerfilEfectividad.Clases
{
    public class Cl_Puestos
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public DataSet GetListaPuestos()
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_CatalogoPuestos", cn);
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

        public DataSet GetListaPuestosInactivos()
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_CatalogoPuestosInactivos", cn);
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

        public DataSet GetDataPuestoPerfil(int PuestoId, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetDataPuestoReporte", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
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