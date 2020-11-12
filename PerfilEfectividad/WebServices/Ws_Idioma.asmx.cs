using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Idioma
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Idioma : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaIdomas
        {
            public int IdiomaId { get; set; }
            public string Idioma { get; set; }
        }

        [WebMethod]
        public List<ListaIdomas> GetListaIdioma()
        {
            ds.Tables.Clear();
            Cl_Idiomas clIdioma = new Cl_Idiomas();
            ds = clIdioma.GetListaIdiomas();
            List<ListaIdomas> Datos = new List<ListaIdomas>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaIdomas Registro = new ListaIdomas();
                Registro.IdiomaId = Convert.ToInt32(dr["IdomaId"]);
                Registro.Idioma = dr["Idioma"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditIdioma(int IdiomaId, string Idioma)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Edit_Idioma", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdiomaId", SqlDbType.Int).Value = IdiomaId;
                Comando.Parameters.Add("@Idioma", SqlDbType.VarChar, 500).Value = Idioma;
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
        public int Insert_Idioma(string Idioma)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Idioma", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Idioma", SqlDbType.VarChar, 500).Value = Idioma;
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
        public int DeleteIdioma(int IdiomaId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_Idioma", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@IdiomaId", SqlDbType.Int).Value = IdiomaId;
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
