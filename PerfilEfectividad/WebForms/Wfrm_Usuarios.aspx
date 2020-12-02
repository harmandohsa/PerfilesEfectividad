<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Usuarios.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
	<div class="kt-container  kt-container--fluid ">
		<div class="kt-subheader__main">
			<h3 class="kt-subheader__title">
				Usuarios </h3>
			<span class="kt-subheader__separator kt-hidden"></span>
			<div class="kt-subheader__breadcrumbs">
				<a href="WebForms/Wfrm_Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i class="flaticon-home-2"></i></a>
				<span class="kt-subheader__breadcrumbs-separator"></span>
				<a class="kt-subheader__breadcrumbs-link">
					Usuarios </a>
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
				Catálogo de Usuarios
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

		<!--begin: Datatable -->
		<table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_Usuarios">
            <thead>
				<tr>
                    <th>AB</th>
                    <th>Nombres</th>
					<th>Empresa</th>
                    <th>Pais</th>
                    <th>Sede</th>
                    <th>Telefono</th>
                    <th>Correo</th>
                    <th>Proceso</th>
                    <th>Usuario</th>
                    <th>Perfil</th>
				</tr>
			</thead>
		</table>
		<!--end: Datatable -->
	</div>
</div>

<div class="modal fade slide-up" id="modalNuevaUsuario" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Nuevo Usuario</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtNombre">Nombres</label>
                                <input id="txtNombre" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtApellido">Apellidos</label>
                                <input id="txtApellido" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtCorreo">Correo</label>
                                <input id="txtCorreo" type="email" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtTelefono">Teléfono</label>
                                <input id="txtTelefono" type="email" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtUsuario">Usuario</label>
                                <input id="txtUsuario" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="cboPais">País</label>
                                <select id="cboPais" class="full-width" data-init-plugin="select2"></select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="cboSede">Sede</label>
                                <select id="cboSede" class="full-width" data-init-plugin="select2"></select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="cboPerfil">Perfil</label>
                                <select id="cboPerfil" class="full-width" data-init-plugin="select2"></select>
                            </div>
                        </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarUsuario()" id="BtnGrabarUsuario" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
</div>
<div class="modal fade slide-up" id="modalPermisosUsuario" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5><label id="lblTituloPermisos"></label></h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                     <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_permisosUsuarios">
                        <thead>
					        <tr>
                                <th></th>
						        <th></th>
                                <th></th>
					        </tr>
				        </thead>
			        </table>
                </div>
                
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<input id="txtPerfilId" type="text" class="form-control" Style="display:none" >
<input id="txtPaisId" type="text" class="form-control" Style="display:none" >
<input id="txtSedeId" type="text" class="form-control" Style="display:none" >
<input id="txtllamada" type="text" class="form-control" Style="display:none" >
<script src="../WebScripts/SrcUsuarios.js" type="text/javascript"></script>
<script src="../WebScripts/SrcCombos.js" type="text/javascript"></script>	
<input id="txtPerfilIdOriginal" type="text" class="form-control" Style="display:none" >
<input id="txtCorreoOriginal" type="text" class="form-control" Style="display:none" >
<input id="txtUsuarioOriginal" type="text" class="form-control" Style="display:none" >
<input id="txtTelefonoOriginal" type="text" class="form-control" Style="display:none" >
<input id="txtUsuarioId" type="text" class="form-control" Style="display:none" >
</asp:Content>
