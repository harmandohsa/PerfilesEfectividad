<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_PerfilUsuario.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
	<div class="kt-container  kt-container--fluid ">
		<div class="kt-subheader__main">
			<h3 class="kt-subheader__title">
				Mis Datos </h3>
			<span class="kt-subheader__separator kt-hidden"></span>
			<div class="kt-subheader__breadcrumbs">
				<a href="WebForms/Wfrm_Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i class="flaticon-home-2"></i></a>
				<span class="kt-subheader__breadcrumbs-separator"></span>
				<a class="kt-subheader__breadcrumbs-link">
					Perfil de Usuario </a>
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
				Perfil
			</h3>
		</div>
		<div class="kt-portlet__head-toolbar">
			<div class="kt-portlet__head-wrapper">
				<div class="kt-portlet__head-actions">
					<button type="button" id="BtnNuevo" onclick="NuevoUsuario()" data-toggle="modal" data-target="#modalNuevaUsuario" class="btn btn-primary"><i class="fa fa-plus-circle"></i>Nuevo Usuario</button>
                    
                       
				</div>
			</div>
		</div>
	</div>
	<div class="kt-portlet__body">
        <div class="container-fluid">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="txtNombre">Nombres</label>
                            <input id="txtNombre" disabled type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="txtApellido">Apellidos</label>
                            <input id="txtApellido" disabled type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group required" >
                            <label for="txtPais">País</label>
                            <input id="txtPais" disabled type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group required" >
                            <label for="txtSede">Sede</label>
                            <input id="txtSede" disabled type="text" class="form-control" required>
                        </div>
                    </div>
                    
                    <div class="col-md-3">
                        <div class="form-group required" >
                            <label for="txtTelefono">Teléfono</label>
                            <input id="txtTelefono" type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group required" >
                            <label for="txtCorreo">Correo</label>
                            <input id="txtCorreo" type="email" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group required" >
                            <label for="txtUsuario">Usuario</label>
                            <input id="txtUsuario" disabled type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group required" >
                            <label for="txtPerfil">Perfil</label>
                            <input id="txtPerfil" disabled type="text" class="form-control" required>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Seleccionar Foto</label>
                            <input type="file" class="form-control" name="file" id="profile-img" >
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Foto</label>
                            <img src="" id="profile-img-tag"  width="100px" height="100px" />
                        </div>
                    </div>
            </div>
            <div class="modal-footer">
                <button type="button" onclick="GrabarUsuario()" id="BtnGrabar" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
            </div>
        </div>
	</div>
</div>
<input id="txtUsuarioId" type="text" class="form-control" Style="display:none" >
<input id="txtCorreoOriginal" type="text" class="form-control" Style="display:none" >
 <input id="txtTelefonoOriginal" type="text" class="form-control" Style="display:none" >
<script src="../WebScripts/SrcPerfilUsuario.js" type="text/javascript"></script>
<script src="../WebScripts/SrcCombos.js" type="text/javascript"></script>
</asp:Content>
