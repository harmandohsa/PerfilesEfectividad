using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for WS_SubAreas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS_SubAreas : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaSubAreas
        {
            public int AreaId { get; set; }
            public string Area { get; set; }
            public int SubareaId { get; set; }
            public string SubArea { get; set; }
        }

        [WebMethod]
        public List<ListaSubAreas> GetListaSubAreas()
        {
            ds.Tables.Clear();
            CL_SubAreas clSubAreas = new CL_SubAreas();
            ds = clSubAreas.GetListaSubAreas();
            List<ListaSubAreas> Datos = new List<ListaSubAreas>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaSubAreas Registro = new ListaSubAreas();
                Registro.AreaId = Convert.ToInt32(dr["AreaId"]);
                Registro.Area = dr["Area"].ToString();
                Registro.SubareaId = Convert.ToInt32(dr["SubareaId"]);
                Registro.SubArea = dr["SubArea"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class ListaSubAreasArea
        {
            public int SubareaId { get; set; }
            public string SubArea { get; set; }
        }

        [WebMethod]
        public List<ListaSubAreasArea> GetListaSubAreasArea(int AreaId)
        {
            ds.Tables.Clear();
            CL_SubAreas clSubAreas = new CL_SubAreas();
            ds = clSubAreas.GetListaSubAreasArea(AreaId);
            List<ListaSubAreasArea> Datos = new List<ListaSubAreasArea>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaSubAreasArea Registro = new ListaSubAreasArea();
                Registro.SubareaId = Convert.ToInt32(dr["SubareaId"]);
                Registro.SubArea = dr["SubArea"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditSubArea(int AreaId, int SubAreaId, string Subarea)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditSubArea", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@AreaId", SqlDbType.Int).Value = AreaId;
                Comando.Parameters.Add("@SubAreaId", SqlDbType.Int).Value = SubAreaId;
                Comando.Parameters.Add("@SubArea", SqlDbType.VarChar, 500).Value = Subarea;
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
        public int Insert_SubArea(string Subarea, int AreaId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_SubArea", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@AreaId", SqlDbType.Int).Value = AreaId;
                Comando.Parameters.Add("@Subarea", SqlDbType.VarChar, 500).Value = Subarea;
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
        public int DeleteSubArea(int SubAreaId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_SubArea", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@SubAreaId", SqlDbType.Int).Value = SubAreaId;
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
