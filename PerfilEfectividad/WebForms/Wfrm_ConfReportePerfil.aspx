<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_ConfReportePerfil.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_ConfReportePerfil" %>
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
					    Configuración Reporte </a>
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
				    Configuración Reporte
			    </h3>
		    </div>
		    <div class="kt-portlet__head-toolbar">
			    <div class="kt-portlet__head-wrapper">
				    <div class="kt-portlet__head-actions">
					    <%--<button type="button" id="BtnNuevo" onclick="Nuevo()" data-toggle="modal" data-target="#modalDatos" class="btn btn-primary"><i class="fa fa-plus-circle"></i>Nuevo País</button>--%>
                       
				    </div>
			    </div>
		    </div>
	    </div>
	    <div class="kt-portlet__body">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkInfoGeneral" type="checkbox"> Información General
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkTareas" type="checkbox"> Tareas
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkTomaDesciones" type="checkbox"> Toma de Desiciones
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkEsfuerzoMental" type="checkbox"> Esfuerzo Mental
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkManejoBienes" type="checkbox"> Manejo de Bienes y Valores Económicos
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkSupervision" type="checkbox"> Supervisión
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkRelaciones" type="checkbox"> Relaciones de Trabajo Internas y Externas
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkManejoInformacion" type="checkbox"> Manejo de Información y Documentos
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkAmbienteTrabajo" type="checkbox"> Ambiente de Trabajo
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkRiesgoOcupacional" type="checkbox"> Riesgo Ocupacional
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkEsfuerzoFisico" type="checkbox"> Esfuerzo Fisico
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkEducacionFormal" type="checkbox"> Educación Formal
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkImpactoError" type="checkbox"> Impacto del Error
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkCursosTecnicos" type="checkbox"> Cursos Técnicos
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkOtrosEstudios" type="checkbox"> Otros Estudios Requeridos
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkIdiomas" type="checkbox"> Idiomas
							<span></span>
						</label>
                    </div>
                    <div class="col-md-3">
                        <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
							<input id="ChkExperiencia" type="checkbox"> Experiencia
							<span></span>
						</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <button type="button" onclick="Grabar()" id="BtnGrabar" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Seleccionar Logo</label>
                            <input type="file" class="form-control" name="file" id="profile-img" >
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label>Logo Reporte</label>
                            <img src="" id="profile-img-tag"  width="100px" height="100px" />
                        </div>
                    </div>
                </div>
            </div>
	    </div>
    </div>
    <script src="../WebScripts/SrcConfReporte.js" type="text/javascript"></script>
</asp:Content>
