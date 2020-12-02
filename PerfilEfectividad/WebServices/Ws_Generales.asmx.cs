using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Services;
using PerfilEfectividad.Clases;

namespace PerfilEfectividad.WebServices
{
    /// <summary>
    /// Summary description for Ws_Generales
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Ws_Generales : System.Web.Services.WebService
    {
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);

        [WebMethod]
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "QueryClinica";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        [WebMethod]
        public string Decrypt(string cipherText)
        {

            string EncryptionKey = "QueryClinica";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        //cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public class PermisosUsuarioPagina
        {
            public int Insertar { get; set; }
            public int Editar { get; set; }
            public int Eliminar { get; set; }
            public int Imprimir { get; set; }
            public int Consultar { get; set; }

        }

        [WebMethod]
        public List<PermisosUsuarioPagina> GetPermisosUsuarioPagina(int UsuarioId, int PaginaId)
        {
            ds.Tables.Clear();
            Cl_Generales clGenerales = new Cl_Generales();
            ds = clGenerales.PermisosUsuarioPagina(UsuarioId, PaginaId);
            List<PermisosUsuarioPagina> Datos = new List<PermisosUsuarioPagina>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                PermisosUsuarioPagina Registro = new PermisosUsuarioPagina();
                Registro.Insertar = Convert.ToInt32(dr["Insertar"]);
                Registro.Editar = Convert.ToInt32(dr["Editar"]);
                Registro.Eliminar = Convert.ToInt32(dr["Eliminar"]);
                Registro.Imprimir = Convert.ToInt32(dr["Imprimir"]);
                Registro.Consultar = Convert.ToInt32(dr["Consultar"]);
                Datos.Add(Registro);
            }
            return Datos;
        }

        public class PermisosUsuario
        {
            public int PaginaId { get; set; }
        }

        [WebMethod]
        public List<PermisosUsuario> GetPermisosUsuario(int UsuarioId)
        {
            ds.Tables.Clear();
            Cl_Generales clGenerales = new Cl_Generales();
            ds = clGenerales.PermisosUsuario(UsuarioId);
            List<PermisosUsuario> Datos = new List<PermisosUsuario>();


            foreach (DataRow dr in ds.Tables["DATOS"].Rows)
            {
                PermisosUsuario Registro = new PermisosUsuario();
                Registro.PaginaId = Convert.ToInt32(dr["PaginaId"]);
                Datos.Add(Registro);
            }
            return Datos;
        }

        [WebMethod]
        public void EnvioCorreo(string Mail, string Nombre, string Asunto, string Mensaje, int ConAdjunto, string RutaAdjunto, string NombreArchivo)
        {
            try
            {
                string Sitio = System.Configuration.ConfigurationManager.AppSettings["Sitio"].ToString();
                System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
                Correo.From = new System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings["Cuenta"], "Sistema de Perfiles de Efectividad");
                Correo.To.Add(Mail);
                Correo.Subject = Asunto;
                string Saludo = "<table><tr><td>Estimado(a): " + Nombre + "</td></tr></table>";
                string Notificacion = "<table><tr><td><b>NOTIFICACIÓ ELECTRÓNICA, DEL ADMINISTRADOR DEL SISTEMA</b></td></tr></table>";
                Mensaje = Notificacion + Saludo + Mensaje + "<table><tr><td>Ingrese al sistema por medio del siguiente enlace: " + Sitio + " para revisar la información</td></tr><tr><td></td></tr><tr><td><b>Vistera</b></td><tr><td></td></tr><tr><td> <font color=#FF0000>Por favor no responda este correo.</font></td></tr></table>";
                AlternateView HTMLConImagenes = default(AlternateView);
                HTMLConImagenes = AlternateView.CreateAlternateViewFromString(Mensaje, null, "text/html");

                Correo.IsBodyHtml = true;
                if (ConAdjunto == 1)
                {
                    Attachment File = new Attachment(RutaAdjunto);
                    File.Name = NombreArchivo;
                    Correo.Attachments.Add(File);
                }
                Correo.AlternateViews.Add(HTMLConImagenes);
                Correo.Priority = System.Net.Mail.MailPriority.High;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["Host"].ToString(), Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Puerto"]));
                //smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Cuenta"], System.Configuration.ConfigurationManager.AppSettings["Clave"]);

                smtp.Send(Correo);
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
            }
        }

        [WebMethod]
        public int InsertBitacoraActividad(int ActividadId, int PuestoId, int UsuarioId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_BitacoraActividad", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@ActividadId", SqlDbType.Int).Value = ActividadId;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
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
    }
}
