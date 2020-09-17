using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_CargaPerfil
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_CargaPerfil : System.Web.Services.WebService
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);

        [WebMethod]
        public string CaptureFile(string Archivo)
        {
            string Error = "";
            bool HayError = false;
            string NombreColaborador = "";
            string NombrePuesto = "";

            try
            {
                byte[] imageBytes = Convert.FromBase64String(Archivo);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                using (ExcelPackage excelPackage = new ExcelPackage(ms))
                {
                    int a = excelPackage.Workbook.Worksheets.Count;
                    for (int i = 1; i <= a; i+=2)
                    {
                        string HojaA = excelPackage.Workbook.Worksheets[i].Name;
                        string HojaB = excelPackage.Workbook.Worksheets[i+1].Name;
                        if ((i % 2) != 0)
                        {
                            NombreColaborador = excelPackage.Workbook.Worksheets[i].Cells[10, 5].Text;
                            if (NombreColaborador == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Nombre esta vacio</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Nombre esta vacio</li>";
                            }
                            NombrePuesto = excelPackage.Workbook.Worksheets[i].Cells[11, 5].Text;
                            if (NombrePuesto == "")
                            {
                                HayError = true;
                                if (Error == "")
                                    Error = "<ul><li>El Puesto esta vacio</li>";
                                else
                                    Error = Error + Environment.NewLine + "<li>El Puesto esta vacio</li>";
                            }
                            else
                            {
                                int EsPuesto = ExistePuesto(NombrePuesto);
                                if (EsPuesto > 0)
                                {
                                    HayError = true;
                                    if (Error == "")
                                        Error = "<ul><li>El Puesto ya existe</li>";
                                    else
                                        Error = Error + Environment.NewLine + "<li>El Puesto ya existe</li>";
                                }
                            }
                            

                        }
                        else
                        {

                        }
                        if (Error != "")
                            Error = Error + "</ul>";
                        else{

                        }
                     
                    }
                }
                return Error;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public int ExistePuesto(string Puesto)
        {
            int Resul = 0;
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();
                Resul = Convert.ToInt32(Comando.Parameters["@Resul"].Value);
                cn.Close();

            }
            catch (Exception ex)
            {
                return 0;
            }
            return Resul;
        }
    }
}
