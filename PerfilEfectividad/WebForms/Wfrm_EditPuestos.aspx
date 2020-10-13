﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_EditPuestos.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_EditPuestos" %>
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
					<div id="collapseFour4" class="collapse" aria-labelledby="headingFour1" data-parent="#accordionExample4">
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
                <div class="card">
					<div class="card-header" id="headingFive4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseFive4" aria-expanded="false" aria-controls="collapseFive4">
							<i class="flaticon-notepad"></i> Manejo de Bienes y Valores Económicos
						</div>
					</div>
					<div id="collapseFive4" class="collapse" aria-labelledby="headingFive1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_ManejoBienes">
                                        <thead>
				                            <tr>
                                                <th>Código</th>
					                            <th>Departamentos</th>
				                            </tr>
			                            </thead>
		                            </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboManejoBienes">Factor Manejo de Bienes </label>
                                        <select id="cboManejoBienes" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingSix4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseSix4" aria-expanded="false" aria-controls="collapseSix4">
							<i class="flaticon2-user-outline-symbol"></i> Supervisión
						</div>
					</div>
					<div id="collapseSix4" class="collapse" aria-labelledby="headingSix1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_Supervision">
                                        <thead>
				                            <tr>
                                                <th>Código</th>
					                            <th>Departamentos</th>
				                            </tr>
			                            </thead>
		                            </table>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboSupervion">Factor Supervisiones </label>
                                        <select id="cboSupervion" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingSeven4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseSeven4" aria-expanded="false" aria-controls="collapseSeven4">
							<i class="flaticon2-console"></i> Relaciones de Trabajo Internas y Externas
						</div>
					</div>
					<div id="collapseSeven4" class="collapse" aria-labelledby="headingSeven1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_RelacionesTrabajo">
                                        <thead>
				                            <tr>
                                                <th>Código</th>
					                            <th>Departamentos</th>
				                            </tr>
			                            </thead>
		                            </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboRelacionInterna">Factor Relacion Internas</label>
                                        <select id="cboRelacionInterna" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboRelacionExterna">Factor Relacion Externas</label>
                                        <select id="cboRelacionExterna" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingEigth4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseEigth4" aria-expanded="false" aria-controls="collapseEigth4">
							<i class="flaticon2-protected"></i> Manejo de Información y Documentos
						</div>
					</div>
					<div id="collapseEigth4" class="collapse" aria-labelledby="headingEigth1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_ManejoInformacion">
                                        <thead>
				                            <tr>
                                                <th>Código</th>
					                            <th>Departamentos</th>
				                            </tr>
			                            </thead>
		                            </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboManejoInformacion">Factor Manejo Información</label>
                                        <select id="cboManejoInformacion" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingNine4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseNine4" aria-expanded="false" aria-controls="collapseNine4">
							<i class="flaticon2-soft-icons-1"></i> Ambiente de Trabajo
						</div>
					</div>
					<div id="collapseNine4" class="collapse" aria-labelledby="headingNine1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="cboTipoAmbienteTrabajo">Seleccione una o varias opciones, que describan de la mejor forma el ambiente normal en el que se ejecuta su trabajo.</label>
                                        <select id="cboTipoAmbienteTrabajo" class="full-width" data-init-plugin="select2" multiple></select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboAmbienteTrabajo">Factor Ambiente Trabajo</label>
                                        <select id="cboAmbienteTrabajo" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<%--end accordion--%>
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
<input id="txtAreaId" type="text" class="form-control" Style="display:none">
<input id="txtTomaDecisionId" type="text" class="form-control"  Style="display:none">
<input id="txtEsfuerzoMentalId" type="text" class="form-control"  Style="display:none">
<input id="txtRelacionInternalId" type="text" class="form-control" Style="display:none">
<input id="txtRelacionExternalId" type="text" class="form-control" Style="display:none">
<input id="txtManejoBienesId" type="text" class="form-control" Style="display:none">
<input id="txtSupervisionId" type="text" class="form-control" Style="display:none">
<input id="txtManejoInformacionId" type="text" class="form-control" Style="display:none">
<input id="txtTipoAmbienteTrabajoId" type="text" class="form-control" Style="display:none">
<input id="txtAmbienteTrabajoId" type="text" class="form-control" Style="display:none">
<input id="txtllamada" type="text" class="form-control" Style="display:none" >
<script src="../WebScripts/SrcEditPuesto.js" type="text/javascript"></script>
<script src="../WebScripts/SrcCombos.js" type="text/javascript"></script>
</asp:Content>
