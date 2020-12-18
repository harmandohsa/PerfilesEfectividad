<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_Puestos.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_Puestos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="kt-subheader   kt-grid__item" id="kt_subheader">
	<div class="kt-container  kt-container--fluid ">
		<div class="kt-subheader__main">
			<h3 class="kt-subheader__title">
				Perfiles </h3>
			<span class="kt-subheader__separator kt-hidden"></span>
			<div class="kt-subheader__breadcrumbs">
				<a href="WebForms/Wfrm_Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i class="flaticon-home-2"></i></a>
				<span class="kt-subheader__breadcrumbs-separator"></span>
				<a class="kt-subheader__breadcrumbs-link">
					Puestos </a>
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
				Puestos
			</h3>
		</div>
		<div class="kt-portlet__head-toolbar">
			<div class="kt-portlet__head-wrapper">
				<div class="kt-portlet__head-actions">
					<button type="button" id="BtnNuevo" onclick="NuevoPuesto()" data-toggle="modal" data-target="#modalEditPuesto" class="btn btn-primary"><i class="fa fa-plus-circle"></i>Nuevo Puesto</button>
                       
				</div>
			</div>
		</div>
	</div>
	<div class="kt-portlet__body">

		<!--begin: Datatable -->
		<table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_Puestos">
            <thead>
				<tr>
                    <th>Código</th>
					<th>Departamentos</th>
				</tr>
			</thead>
		</table>
		<!--end: Datatable -->
	</div>
</div>
<div class="modal fade slide-up" id="modalEditPuesto" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Editar Puesto</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="col-md-6">
                        <div class="form-group required" >
                            <label for="txtNombrePuesto">Nombre Puesto</label>
                            <input id="txtNombrePuesto" type="text" class="form-control" required>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" onclick="GrabarPuesto()" id="BtnGrabarPuesto" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                    <button type="button" onclick="BorrarPuesto()" id="BtnBorrarPuesto" class="btn btn-danger"><i class="fa fa-trash"></i>Inactivar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class="modal fade slide-up"  id="modalPrintPerfil" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
            <div class="modal-content ">
                <div class="modal-header clearfix text-left">
                    <h5>Reporte</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        <i class="ik ik-arrow-down bg-blue"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <iframe id="frameRep" width="1000px" height="800px"></iframe>
                            <a id="Documento"></a>
                        </div>    
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    <!-- /.modal-content -->
    </div>
</div>
<input id="txtPuestoId" type="text" class="form-control" Style="display:none" >
<input id="txtllamada" type="text" class="form-control" Style="display:none" >
<script src="../WebScripts/SrcPuesto.js" type="text/javascript"></script>
</asp:Content>
