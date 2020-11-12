using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_Carreras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_Carreras : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaCarreras
        {
            public int CarreraId { get; set; }
            public string Carrera { get; set; }
        }

        [WebMethod]
        public List<ListaCarreras> GetListaCarreras(int GradoId)
        {
            ds.Tables.Clear();
            Cl_Carreras clCarreras = new Cl_Carreras();
            ds = clCarreras.GetListaCarreras(GradoId);
            List<ListaCarreras> Datos = new List<ListaCarreras>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaCarreras Registro = new ListaCarreras();
                Registro.CarreraId = Convert.ToInt32(dr["CarreraId"]);
                Registro.Carrera = dr["Carrera"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class ListaCarrerasAll
        {
            public int CarreraId { get; set; }
            public string Carrera { get; set; }
            public int GradoId { get; set; }
            public string NivelEducativo { get; set; }
        }

        [WebMethod]
        public List<ListaCarrerasAll> GetListaCarrerasCat()
        {
            ds.Tables.Clear();
            Cl_Carreras clCarreras = new Cl_Carreras();
            ds = clCarreras.GetListaCarrerasTodas();
            List<ListaCarrerasAll> Datos = new List<ListaCarrerasAll>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaCarrerasAll Registro = new ListaCarrerasAll();
                Registro.CarreraId = Convert.ToInt32(dr["CarreraId"]);
                Registro.Carrera = dr["Carrera"].ToString();
                Registro.GradoId = Convert.ToInt32(dr["GradoId"]);
                Registro.NivelEducativo = dr["Grado"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditCarrera(int CarreraId, int GradoId, string Carrera)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditCarrera", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@CarreraId", SqlDbType.Int).Value = CarreraId;
                Comando.Parameters.Add("@GradoId", SqlDbType.Int).Value = GradoId;
                Comando.Parameters.Add("@Carrera", SqlDbType.VarChar, 500).Value = Carrera;
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
        public int Insert_Carrera(string Carrera, int GradoId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Carrera", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@GradoId", SqlDbType.Int).Value = GradoId;
                Comando.Parameters.Add("@Carrera", SqlDbType.VarChar, 500).Value = Carrera;
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
        public int DeleteCarrera(int CarreraId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_Carrera", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@CarreraId", SqlDbType.Int).Value = CarreraId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}
