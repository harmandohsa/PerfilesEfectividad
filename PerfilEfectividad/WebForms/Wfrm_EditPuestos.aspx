<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_EditPuestos.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_EditPuestos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="kt-subheader   kt-grid__item" id="kt_subheader">
	<div class="kt-container  kt-container--fluid ">
		<div class="kt-subheader__main">
			<h3 class="kt-subheader__title">
				Catálogos </h3>
			<span class="kt-subheader__separator kt-hidden"></span>
			<div class="kt-subheader__breadcrumbs">
				<a href="WebForms/Wfrm_Inicio.aspx" class="kt-subheader__breadcrumbs-home"><i class="flaticon-home-2"></i></a>
				<span class="kt-subheader__breadcrumbs-separator"></span>
				<a class="kt-subheader__breadcrumbs-link">
					Editar Puestoo </a>
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
				<label id="lblPuesto"></label>
			</h3>
		</div>
		<div class="kt-portlet__head-toolbar">
			<div class="kt-portlet__head-wrapper">
				<div class="kt-portlet__head-actions">
					<%--<button type="button" id="BtnNuevo" onclick="NuevoDepartamento()" data-toggle="modal" data-target="#modalNuevoDepartamento" class="btn btn-primary"><i class="fa fa-plus-circle"></i>Nuevo Departamento</button>--%>
                        
                       
				</div>
			</div>
		</div>
	</div>
	<div class="kt-portlet__body">
        <div class="col-lg-12">
            <!--begin::Accordion-->
					<div class="accordion  accordion-toggle-arrow" id="accordionExample4">
						<div class="card">
							<div class="card-header" id="headingOne4">
								<div class="card-title" data-toggle="collapse" data-target="#collapseOne4" aria-expanded="true" aria-controls="collapseOne4">
									<i class="flaticon2-layers-1"></i> Información General
								</div>
							</div>
							<div id="collapseOne4" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample4">
								<div class="card-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="cboArea">Área</label>
                                                <select id="cboArea" class="full-width" data-init-plugin="select2"></select>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="txtpuestojefe">Puesto del jefe inmediato superior</label>
                                                <input id="txtpuestojefe" type="text" class="form-control" required>
                                            </div>
                                        </div>
                                    </div>
								</div>
							</div>
						</div>
						<div class="card">
							<div class="card-header" id="headingTwo4">
								<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseTwo4" aria-expanded="false" aria-controls="collapseTwo4">
									<i class="flaticon2-copy"></i> Tareas que realiza el puesto
								</div>
							</div>
							<div id="collapseTwo4" class="collapse" aria-labelledby="headingTwo1" data-parent="#accordionExample4">
								<div class="card-body">
									<div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfuncprincipal">Función Principal</label>
                                                <textarea id="txtfuncprincipal" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfuncprincipales">Principales funciones</label>
                                                <textarea id="txtfuncprincipales" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfuncdiarias">Funciones Diarias</label>
                                                <textarea id="txtfuncdiarias" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfuncsemquin">Funciones Semanales o Quincenales</label>
                                                <textarea id="txtfuncsemquin" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfuncmensual">Funciones Mensuales</label>
                                                <textarea id="txtfuncmensual" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfunctrimsem">Funciones Trimestrales o Semestrales</label>
                                                <textarea id="txtfunctrimsem" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfuncanual">Funciones Anuales</label>
                                                <textarea id="txtfuncanual" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtfunceventual">Funciones Eventuales</label>
                                                <textarea id="txtfunceventual" rows="5"  class="form-control" required></textarea>
                                                
                                            </div>
                                        </div>
                                    </div>
								</div>
							</div>
						</div>
						<div class="card">
							<div class="card-header" id="headingThree4">
								<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseThree4" aria-expanded="false" aria-controls="collapseThree4">
									<i class="flaticon2-bell-alarm-symbol"></i> Toma de Desiciones
								</div>
							</div>
							<div id="collapseThree4" class="collapse" aria-labelledby="headingThree1" data-parent="#accordionExample4">
								<div class="card-body">
									<div class="row">
                                        <div class="col-md-9">
                                            <div class="form-group">
                                                <label for="cboTomaDesicion">Factor Toma de Desiciones</label>
                                                <select id="cboTomaDesicion" class="full-width" data-init-plugin="select2"></select>
                                            </div>
                                        </div>
                                    </div>
								</div>
							</div>
						</div>
                        <div class="card">
							<div class="card-header" id="headingFour4">
								<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseFour4" aria-expanded="false" aria-controls="collapseFour4">
									<i class="flaticon2-user-1"></i> Esfuerzo Mental
								</div>
							</div>
							<div id="collapseFour4" class="collapse" aria-labelledby="headingThree1" data-parent="#accordionExample4">
								<div class="card-body">
									<div class="row">
                                        <div class="col-md-9">
                                            <div class="form-group">
                                                <label for="cboEsfuerzoMental">Factor Esfuerzo Mental</label>
                                                <select id="cboEsfuerzoMental" class="full-width" data-init-plugin="select2"></select>
                                            </div>
                                        </div>
                                    </div>
								</div>
							</div>
						</div>
					</div>

					<!--end::Accordion-->
			
			
		</div>
		
	</div>
</div>
<div class="modal fade slide-up" id="modalNuevoDepartamento" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Nuevo Departamento</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="col-md-6">
                        <div class="form-group required" >
                            <label for="txtDepartamento">Nombre Departamento</label>
                            <input id="txtDepartamento" type="text" class="form-control" required>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarDepartamento()" id="BtnGrabarDepartamento" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<input id="txtPuestoId" type="text" class="form-control" Style="display:none" >
<input id="txtAreaId" type="text" class="form-control" Style="display:none" >
<input id="txtTomaDecisionId" type="text" class="form-control" Style="display:none" >
<input id="txtEsfuerzoMentalId" type="text" class="form-control" Style="display:none" >
<input id="txtllamada" type="text" class="form-control" Style="display:none" >
<script src="../WebScripts/SrcEditPuesto.js" type="text/javascript"></script>
<script src="../WebScripts/SrcCombos.js" type="text/javascript"></script>
</asp:Content>
