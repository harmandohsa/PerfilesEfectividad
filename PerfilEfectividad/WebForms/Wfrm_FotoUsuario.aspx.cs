using System;
using System.Data;
using System.Web;
using PerfilEfectividad.Clases;
using PerfilEfectividad.WebServices;

namespace PerfilEfectividad.WebForms
{
    public partial class Wfrm_FotoUsuario : System.Web.UI.Page
    {
        CL_PerfilUsuario ClPerfilUsuario;
        Ws_Generales WsGenerales;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClPerfilUsuario = new CL_PerfilUsuario();
            WsGenerales = new Ws_Generales();
            DataSet DsArchivo = new DataSet();
            HttpCookie aCookie = Request.Cookies["UsuarioId"];
            if (aCookie == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                DsArchivo = ClPerfilUsuario.GetDatosUsuario(Convert.ToInt32(WsGenerales.Decrypt(aCookie.Value)));
                if (DsArchivo.Tables["DATOS"].Rows[0]["Foto"].ToString() != "")
                {
                    Response.ContentType = DsArchivo.Tables["DATOS"].Rows[0]["ContentType"].ToString();
                    if (DsArchivo.Tables["DATOS"].Rows[0]["Foto"].ToString() != "")
                        Response.BinaryWrite((byte[])DsArchivo.Tables["DATOS"].Rows[0]["Foto"]);
                }
            }
        }
    }
}