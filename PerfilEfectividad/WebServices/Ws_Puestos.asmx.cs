using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Puestos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Puestos : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaPuesots
        {
            public int PuestoId { get; set; }
            public string Puesto { get; set; }
        }

        [WebMethod]
        public List<ListaPuesots> GetListaPuestos()
        {
            ds.Tables.Clear();
            Cl_Puestos clPuestos = new Cl_Puestos();
            ds = clPuestos.GetListaPuestos();
            List<ListaPuesots> Datos = new List<ListaPuesots>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaPuesots Registro = new ListaPuesots();
                Registro.PuestoId = Convert.ToInt32(dr["PuestoId"]);
                Registro.Puesto = dr["NombrePuesto"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public List<ListaPuesots> GetListaPuestosInactivos()
        {
            ds.Tables.Clear();
            Cl_Puestos clPuestos = new Cl_Puestos();
            ds = clPuestos.GetListaPuestosInactivos();
            List<ListaPuesots> Datos = new List<ListaPuesots>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaPuesots Registro = new ListaPuesots();
                Registro.PuestoId = Convert.ToInt32(dr["PuestoId"]);
                Registro.Puesto = dr["NombrePuesto"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditPuesto(int PuestoId, string NombrePuesto)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditaNombrePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int ExistePuestoNoActual(int PuestoId, string Puesto)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuestoActual", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Existe", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Existe"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int EditNomprePuesto(int PuestoId, string Puesto, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditNombrePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int DeletePuesto(int PuestoId, int Estatus, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_DeletePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@Estatus", SqlDbType.Int).Value = Estatus;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int Insert_Puesto(string Puesto, int UsuarioId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Puesto_New", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        [WebMethod]
        public int ExistePuesto(string Puesto)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Resul", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
