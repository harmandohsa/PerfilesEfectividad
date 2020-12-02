<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_CambioClave.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_CambioClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
	    <div class="kt-container  kt-container--fluid ">
		    <div class="kt-subheader__main">
			    <h3 class="kt-subheader__title">
				    Administración </h3>
			    <span class="kt-subheader__separator kt-hidden"></span>
			    <div class="kt-subheader__breadcrumbs">
				    <a href="WebForms/Wfrm_Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i class="flaticon-home-2"></i></a>
				    <span class="kt-subheader__breadcrumbs-separator"></span>
				    <a class="kt-subheader__breadcrumbs-link">
					    Cambio de Clave </a>
			    </div>
		    </div>
	    </div>
    </div>
    <div class="kt-portlet kt-portlet--mobile">
	    <div class="kt-portlet__head kt-portlet__head--lg">
		    <div class="kt-portlet__head-label">
			    <span class="kt-portlet__head-icon">
				    <i class="kt-font-brand flaticon2-line-chart"></i>
			    </span>
			    <h3 class="kt-portlet__head-title">
				    Administración
			    </h3>
		    </div>
	    </div>
	    <div class="kt-portlet__body">
		    <div class="container-fluid">
                <div class="col-md-6">
                    <div class="form-group required" >
                        <label for="txtClave">Clave Actual</label>
                        <input id="txtClave" type="password" class="form-control" required>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group required" >
                        <label for="txtNuevaClave">Nueva Clave</label>
                        <input id="txtNuevaClave" type="password" class="form-control" required>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group required" >
                        <label for="txtConfirmarClave">Confirmar Clave</label>
                        <input id="txtConfirmarClave" type="password" class="form-control" required>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group required" >
                        <button type="button" onclick="CambiaClave()" id="BtnCambiar" class="btn btn-primary"><i class="fa fa-exchange-alt"></i>Cambiar Clave</button>
                    </div>
                </div>
            </div>
	    </div>
    </div>
    <script src="../WebScripts/Src_CambioClave.js" type="text/javascript"></script>
</asp:Content>
