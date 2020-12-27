<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_BitacoraActividad.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_BitacoraActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kt-subheader   kt-grid__item" id="kt_subheader">
	    <div class="kt-container  kt-container--fluid ">
		    <div class="kt-subheader__main">
			    <h3 class="kt-subheader__title">
				    Reportes </h3>
			    <span class="kt-subheader__separator kt-hidden"></span>
			    <div class="kt-subheader__breadcrumbs">
				    <a href="WebForms/Wfrm_Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i class="flaticon-home-2"></i></a>
				    <span class="kt-subheader__breadcrumbs-separator"></span>
				    <a class="kt-subheader__breadcrumbs-link">
					    Bitacoras </a>
			    </div>
		    </div>
	    </div>
    </div>
    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
        <div class="row">
		    <div class="col-lg-12">
                <div class="kt-portlet">
                    <div class="kt-portlet__head kt-portlet__head--lg">
		                <div class="kt-portlet__head-label">
			                <span class="kt-portlet__head-icon">
				                <i class="kt-font-brand flaticon2-line-chart"></i>
			                </span>
			                <h3 class="kt-portlet__head-title">
				                Filtros
			                </h3>
		                </div>
		                <div class="kt-portlet__head-toolbar">
			                <div class="kt-portlet__head-wrapper">
				                <div class="kt-portlet__head-actions">
                                
				                </div>
			                </div>
		                </div>
	                </div>
	                <div class="kt-portlet__body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group" >
                                    <label for="txtFechaDesde">Fecha Inicio</label>
                                    <input class="form-control" type="date"  id="txtFechaDesde">
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group" >
                                    <label for="txtFechaHasta">Fecha Fin</label>
                                    <input class="form-control" type="date"  id="txtFechaHasta">
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group required" >
                                    <label for="cboUsuario">Usuarios</label>
                                    <select id="cboUsuario" class="full-width" data-init-plugin="select2" multiple></select>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group required" >
                                    <label for="cboActividad">Actividades</label>
                                    <select id="cboActividad" class="full-width" data-init-plugin="select2" multiple></select>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group required" >
                                    <label for="cboPuesto">Puestos</label>
                                    <select id="cboPuesto" class="full-width" data-init-plugin="select2" multiple></select>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                           <button type="button" onclick="GenerarData()" id="BtnGenerar" class="btn btn-primary"><i class="fa fa-save"></i>Generar</button>
                            <%--<button type="button" onclick="GenerarDataPDF(1)" id="BtnGenerarpDF" class="btn btn-primary"><i class="fa fa-save"></i>Generar PDF</button>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="kt-portlet__body">
		                        <!--begin: Datatable -->
		                            <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_Data">
                                        <thead>
				                            <tr>
                                                <th>Actividades</th>
				                            </tr>
			                            </thead>
		                            </table>
		                            <!--end: Datatable -->
	                            </div>
                            </div>
                            
                        </div>
	                </div>
                </div>
            </div>
        </div>
    </div>
    <input id="txtUsuarios"  type="text" class="form-control"  Style="display:none">
    <input id="txtActividades"  type="text" class="form-control"  Style="display:none">
    <input id="txtPuestos"  type="text" class="form-control"  Style="display:none">
    <script src="../WebScripts/SrcCombos.js" type="text/javascript"></script>
    <script src="../WebScripts/SrcRepBitacora.js" type="text/javascript"></script>
</asp:Content>
