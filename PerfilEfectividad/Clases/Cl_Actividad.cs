using System;
using System.Data;
using System.Data.SqlClient;

namespace PerfilEfectividad.Clases
{
    public class Cl_Actividad
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public DataSet GetListaActividades()
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetActividades", cn);
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