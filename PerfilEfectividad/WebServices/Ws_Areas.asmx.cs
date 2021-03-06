﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Areas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Areas : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public class ListaAreas
        {
            public int AreaId { get; set; }
            public string Area { get; set; }
        }

        [WebMethod]
        public List<ListaAreas> GetListaAreas()
        {
            ds.Tables.Clear();
            Cl_Areas clAreas = new Cl_Areas();
            ds = clAreas.GetListaAreas();
            List<ListaAreas> Datos = new List<ListaAreas>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                ListaAreas Registro = new ListaAreas();
                Registro.AreaId = Convert.ToInt32(dr["AreaId"]);
                Registro.Area = dr["Area"].ToString();
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public int EditArea(int AreaId, string Area)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_EditArea", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@AreaId", SqlDbType.Int).Value = AreaId;
                Comando.Parameters.Add("@Area", SqlDbType.VarChar, 500).Value = Area;
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
        public int Insert_Area(string Area)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Area", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Area", SqlDbType.VarChar, 500).Value = Area;
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
        public int DeleteArea(int AreaId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Delete_Area", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@AreaId", SqlDbType.Int).Value = AreaId;
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
