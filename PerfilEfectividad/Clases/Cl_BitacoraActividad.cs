using System;
using System.Data;
using System.Data.SqlClient;


namespace PerfilEfectividad.Clases
{
    public class Cl_BitacoraActividad
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public DataSet GetBitacoraActividades(string FecIni, string FecFin, string Usuarios, string Actividades, string Puestos)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_GetDataActividades", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@FecIni", SqlDbType.VarChar, 8000).Value = FecIni;
                Comando.Parameters.Add("@FecFin", SqlDbType.VarChar, 8000).Value = FecFin;
                Comando.Parameters.Add("@Usuarios", SqlDbType.VarChar, 8000).Value = Usuarios;
                Comando.Parameters.Add("@Actividades", SqlDbType.VarChar, 8000).Value = Actividades;
                Comando.Parameters.Add("@Puestos", SqlDbType.VarChar, 8000).Value = Puestos;
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