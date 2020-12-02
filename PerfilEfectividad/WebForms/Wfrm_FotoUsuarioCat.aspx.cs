using System;
using System.Data;
using PerfilEfectividad.Clases;
using PerfilEfectividad.WebServices;

namespace PerfilEfectividad.WebForms
{
    public partial class Wfrm_FotoUsuarioCat : System.Web.UI.Page
    {
        CL_PerfilUsuario ClPerfilUsuario;
        Ws_Generales WsGenerales;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPerfilUsuario = new CL_PerfilUsuario();
            WsGenerales = new Ws_Generales();
            DataSet DsArchivo = new DataSet();
            int UsuarioId = Convert.ToInt32(Request.QueryString["UsuarioId"]);
            DsArchivo = ClPerfilUsuario.GetDatosUsuario(UsuarioId);
            if (DsArchivo.Tables["DATOS"].Rows[0]["Foto"].ToString() != "")
            {
                Response.ContentType = DsArchivo.Tables["DATOS"].Rows[0]["ContentType"].ToString();
                if (DsArchivo.Tables["DATOS"].Rows[0]["Foto"].ToString() != "")
                    Response.BinaryWrite((byte[])DsArchivo.Tables["DATOS"].Rows[0]["Foto"]);
            }
        }
    }
}