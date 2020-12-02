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
					Editar Puesto </a>
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
                                        <label for="cboSubArea">Sub área</label>
                                        <select id="cboSubArea" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="txtpuestojefe">Puesto del jefe inmediato superior</label>
                                        <input id="txtpuestojefe" type="text" class="form-control" required>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="txtcodigopuesto">Código Puesto</label>
                                        <input id="txtcodigopuesto" type="text" class="form-control" required>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="GrabarInfoGenral()" id="BtnActualizaInfoGeneral" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="GrabarFunciones()" id="BtnActualizaFunciones" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>
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
                                        <select id="cboTomaDesicion" onchange="GrabarFactores(1)" class="full-width" data-init-plugin="select2"></select>
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
                                        <select id="cboEsfuerzoMental" onchange="GrabarFactores(2)" class="full-width" data-init-plugin="select2"></select>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="GrabarManejoBienes()" id="BtnActualizaBienes" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboManejoBienes">Factor Manejo de Bienes </label>
                                        <select id="cboManejoBienes" class="full-width" onchange="GrabarFactores(3)" data-init-plugin="select2"></select>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" data-toggle="modal" data-target="#modalSupervisiones" onclick="NuevaSupervision()" id="BtnNuevaSupervision" class="btn btn-primary"><i class="fa fa-plus"></i>Nueva Supervisión</button>                            
                                    </div>
                                    
                                </div>
                            </div>
                            
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
                                        <select id="cboSupervion" onchange="GrabarFactores(4)" class="full-width" data-init-plugin="select2"></select>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" data-toggle="modal" data-target="#modalRelacionesIntExt" onclick="NuevaRelacion()" id="BtnNuevaRelacion" class="btn btn-primary"><i class="fa fa-plus"></i>Nueva Relación de Trabajo</button>                            
                                    </div>
                                    
                                </div>
                            </div>
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
                                        <select id="cboRelacionInterna" onchange="GrabarFactores(5)" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboRelacionExterna">Factor Relacion Externas</label>
                                        <select id="cboRelacionExterna" onchange="GrabarFactores(6)" class="full-width" data-init-plugin="select2"></select>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" data-toggle="modal" data-target="#modalManejoInformacion" onclick="NuevaManejoInfo()" id="BtnNuevaManejoInfo" class="btn btn-primary"><i class="fa fa-plus"></i>Nuevo Manejo de Información y Documentos</button>                            
                                    </div>
                                    
                                </div>
                            </div>
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
                                        <select id="cboManejoInformacion" onchange="GrabarFactores(7)" class="full-width" data-init-plugin="select2"></select>
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="ActualizaAmiente()" id="BtnUpdateAmbiente" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>                            
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboAmbienteTrabajo">Factor Ambiente Trabajo</label>
                                        <select id="cboAmbienteTrabajo" onchange="GrabarFactores(8)" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingTen4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseTen4" aria-expanded="false" aria-controls="collapseTen4">
							<i class="flaticon-security"></i> Riesgo Ocupacional
						</div>
					</div>
					<div id="collapseTen4" class="collapse" aria-labelledby="headingTen1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="cboTipoRiesgoOcupacional">Seleccione, una o varias opciones, que describan los riesgos a los que puede estar expuesta la ejecución de sus tareas.</label>
                                        <select id="cboTipoRiesgoOcupacional" class="full-width" data-init-plugin="select2" multiple></select>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="ActualizaRiesgo()" id="BtnUpdateRiesgo" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>                            
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboRiesgoOcupacional">Factor Riesgo Ocupacional</label>
                                        <select id="cboRiesgoOcupacional" onchange="GrabarFactores(9)" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingEleven4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseEleven4" aria-expanded="false" aria-controls="collapseEleven4">
							<i class="flaticon2-heart-rate-monitor"></i> Esfuerzo Físico
						</div>
					</div>
					<div id="collapseEleven4" class="collapse" aria-labelledby="headingEleven1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="cboTipoEsfuerzoFisico">Seleccione, una o varias opciones, que describan los esfuerzos físicos que requiere la ejecución de las tareas del puesto.</label>
                                        <select id="cboTipoEsfuerzoFisico" class="full-width" data-init-plugin="select2" multiple></select>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="ActualizaEsfuerzoFisico()" id="BtnUpdateEsfuerzo" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>                            
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboEsfuerzoFisico">Factor Esfuerzo Fisico</label>
                                        <select id="cboEsfuerzoFisico" onchange="GrabarFactores(10)" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>

                <div class="card">
					<div class="card-header" id="headingTwelve4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseTwelve4" aria-expanded="false" aria-controls="collapseTwelve4">
							<i class="flaticon2-laptop"></i> Educación Formal
						</div>
					</div>
					<div id="collapseTwelve4" class="collapse" aria-labelledby="headingTwelve1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label for="cboNivelEducacional">Nivel Educacional</label>
                                        <select id="cboNivelEducacional" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                                <div class="col-md-4" id="DivCarrera">
                                    <div class="form-group">
                                        <label for="cboCarrera">Carrera específica</label>
                                        <select id="cboCarrera" class="full-width" data-init-plugin="select2" multiple></select>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="cboEducacionFormal">Factor Eduación Formal</label>
                                        <select id="cboEducacionFormal" disabled class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="ActualizaNivelEducacional()" id="BtnUpdateNivelEducacional" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>                            
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingTrece4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseTrece4" aria-expanded="false" aria-controls="collapseTrece4">
							<i class="flaticon2-cross"></i> Impacto del Error
						</div>
					</div>
					<div id="collapseTrece4" class="collapse" aria-labelledby="headingThree1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="CboImopactoError">Impacto del Error</label>
                                        <select id="CboImopactoError" onchange="GrabarFactores(12)" class="full-width" data-init-plugin="select2"></select>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingCatorce4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseCatorce4" aria-expanded="false" aria-controls="collapseCatorce4">
							<i class="flaticon2-ui"></i> Cursos Técnicos
						</div>
					</div>
					<div id="collapseCatorce4" class="collapse" aria-labelledby="headingCatorce1" data-parent="#accordionExample4">
						<div class="card-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" data-toggle="modal" data-target="#modalCursosTecnicos" onclick="NuevaCursoTecnico()" id="BtnNuevaCursoTecnico" class="btn btn-primary"><i class="fa fa-plus"></i>Nuevo Curso Técnico</button>                            
                                    </div>
                                    
                                </div>
                            </div>
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_CursosTecnicos">
                                        <thead>
				                            <tr>
                                                <th>Código</th>
					                            <th>Departamentos</th>
				                            </tr>
			                            </thead>
		                            </table>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingQuince4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseQuince4" aria-expanded="false" aria-controls="collapseQuince4">
							<i class="flaticon2-copy"></i> Otros Estudios Requeridos
						</div>
					</div>
					<div id="collapseQuince4" class="collapse" aria-labelledby="headingQuince1" data-parent="#accordionExample4">
						<div class="card-body">
							<div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtOtrosEstudios">Estudios</label>
                                        <textarea id="txtOtrosEstudios" rows="5"  class="form-control" required></textarea>
                                                
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" onclick="GrabarOtrosEstudios()" id="BtnActualizaEstudios" class="btn btn-primary"><i class="fa fa-save"></i>Actualizar</button>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingDiecisies4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseDiecisies4" aria-expanded="false" aria-controls="collapseDiecisies4">
							<i class=" flaticon2-chat-1"></i> Idiomas
						</div>
					</div>
					<div id="collapseDiecisies4" class="collapse" aria-labelledby="headingDiecisies1" data-parent="#accordionExample4">
						<div class="card-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" data-toggle="modal" data-target="#modalIdiomas" onclick="NuevoIdioma()" id="BtnNuevoIdioma" class="btn btn-primary"><i class="fa fa-plus"></i>Nuevo Idioma</button>                            
                                    </div>
                                    
                                </div>
                            </div>
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_Idiomas">
                                        <thead>
				                            <tr>
                                                <th>Código</th>
					                            <th>Departamentos</th>
				                            </tr>
			                            </thead>
		                            </table>
                                </div>
                            </div>
						</div>
					</div>
				</div>
                <div class="card">
					<div class="card-header" id="headingDiecisiete4">
						<div class="card-title collapsed" data-toggle="collapse" data-target="#collapseDiecisiete4" aria-expanded="false" aria-controls="collapseDiecisiete4">
							<i class="flaticon-presentation"></i> Experiencia
						</div>
					</div>
					<div id="collapseDiecisiete4" class="collapse" aria-labelledby="headingDiecisiete1" data-parent="#accordionExample4">
						<div class="card-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <button type="button" data-toggle="modal" data-target="#modalExperiencia" onclick="NuevaExperiencia()" id="BtnNuevaExperiencia" class="btn btn-primary"><i class="fa fa-plus"></i>Nueva Experiencia</button>                            
                                    </div>
                                    
                                </div>
                            </div>
							<div class="row">
                                <div class="col-md-12">
                                    <table class="table table-striped- table-bordered table-hover table-checkable order-column" id="kt_table_Experiencia">
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
                                        <label for="CboExperiencia">Factor Experiencia</label>
                                        <select id="CboExperiencia" onchange="GrabarFactores(13)" class="full-width" data-init-plugin="select2"></select>
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
<div class="modal fade slide-up" id="modalSupervisiones" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Crear / Editar Supervisiones</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtPuestoSupervision">Puesto (s)</label>
                                <input id="txtPuestoSupervision" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group required" >
                                <label for="txtCantidadSupervision">Cantidad</label>
                                <input id="txtCantidadSupervision" type="number" class="form-control" required>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarSupervision()" id="BtnGrabarSupervision" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class="modal fade slide-up" id="modalRelacionesIntExt" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Crear / Editar Relaciones de Trabajo Internas y Externas</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtPuestoRelacionTrabajo">Puesto o Departamento</label>
                                <input id="txtPuestoRelacionTrabajo" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtProposito">Proposito</label>
                                <input id="txtProposito" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="cboFrecuencia">Frecuencia</label>
                                <select id="cboFrecuencia" class="full-width" data-init-plugin="select2"></select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="cboTipoRelacion">Tipo Relación</label>
                                <select id="cboTipoRelacion" class="full-width" data-init-plugin="select2"></select>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarRelacion()" id="BtnGrabarRelacion" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class="modal fade slide-up" id="modalManejoInformacion" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Crear / Editar Manejo de Información y Documentos</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtDocuemento">Documento</label>
                                <input id="txtDocuemento" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtAccionDoc">Acción Documento</label>
                                <input id="txtAccionDoc" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtTipoInfo">Tipo Información</label>
                                <input id="txtTipoInfo" type="text" class="form-control" required>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group required" >
                                <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
									<input id="ChkJefe"  type="checkbox"> Jefe
									<span></span>
								</label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group required" >
                                <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
									<input id="ChkAuditInterna"  type="checkbox"> Auditoria Interna
									<span></span>
								</label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group required" >
                                <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
									<input id="ChkAuditExterna"  type="checkbox"> Auditoria Externa
									<span></span>
								</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarmanejoInfo()" id="BtnGrabarManejoInfo" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class="modal fade slide-up" id="modalCursosTecnicos" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Crear / Editar Cursos Técnicos</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtCurso">Curso</label>
                                <input id="txtCurso" type="text" class="form-control">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtDuracion">Duración</label>
                                <input id="txtDuracion" type="text" class="form-control">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarCursoTecnico()" id="BtnGrabarCursoTecnico" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class="modal fade slide-up" id="modalIdiomas" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Crear / Editar Idiomas</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                           <label for="cboIdioma">Idioma</label>
                            <select id="cboIdioma" class="full-width" data-init-plugin="select2"></select>
                        </div>
                        <div class="col-md-6">
                           <label for="cboDominioIdioma">Dominio Idioma</label>
                            <select id="cboDominioIdioma" class="full-width" data-init-plugin="select2"></select>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarIdioma()" id="BtnGrabarIdioma" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
                </div>
            </div>
        </div>
        </div>
        <!-- /.modal-content -->
    </div>
</div>
<div class="modal fade slide-up" id="modalExperiencia" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
    <div class="modal-dialog modal-lg">
        <div class="modal-content-wrapper">
        <div class="modal-content ">
            <div class="modal-header clearfix text-left">
                <h5>Crear / Editar Experiencias</h5>
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    <i class="ik ik-arrow-down bg-blue"></i>
                </button>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtTipoTrabajo">Tipo de Trabajo</label>
                                <input id="txtTipoTrabajo" type="text" class="form-control">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtTiempoExperiencia">Tiempo (en meses o años)</label>
                                <input id="txtTiempoExperiencia" type="text" class="form-control">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                   <button type="button" onclick="GrabarExperiencia()" id="BtnGrabarExperiencia" class="btn btn-primary"><i class="fa fa-save"></i>Grabar</button>
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
<input id="txtTipoRiesgoOcupacionalId" type="text" class="form-control" Style="display:none">
<input id="txtRiesgoOcupacionalId" type="text" class="form-control" Style="display:none">
<input id="txtTipoEsfueroFisicolId" type="text" class="form-control" Style="display:none">
<input id="txtEsfuerzoFisicolId" type="text" class="form-control" Style="display:none">
<input id="txtllamadaSupervision" type="text" class="form-control" Style="display:none" >
<input id="txtTipoSupervisionId" value="1" type="text" class="form-control" Style="display:none" >
<input id="txtIdSupervision" type="text" class="form-control" Style="display:none" >
<input id="txtFrecuenciaId" value="1" type="text" class="form-control" Style="display:none" >
<input id="txtTipoRelacionId" value="1" type="text" class="form-control" Style="display:none" >
<input id="txtRelacionId" type="text" class="form-control" Style="display:none" >
<input id="txtllamadaRelacion" type="text" class="form-control" Style="display:none" >
<input id="txtManejoInfoId" type="text" class="form-control" Style="display:none" >
<input id="txtllamadaManejoInfo" type="text" class="form-control" Style="display:none" >
<input id="txtGradoId" type="text" class="form-control" Style="display:none" >
<input id="txtCarreraId" type="text" class="form-control" Style="display:none" >
<input id="txtEducacionFormalId" type="text" class="form-control" Style="display:none" >
<input id="txtImpactoErrorId" type="text" class="form-control" Style="display:none" >
<input id="txtCursoId" type="text" class="form-control" Style="display:none" >
<input id="txtllamadaCurso" type="text" class="form-control" Style="display:none" >
<input id="txtIdiomaId" type="text" class="form-control" Style="display:none" >
<input id="txtIdomaId" type="text" class="form-control" Style="display:none" >
<input id="txtDominioIdiomaId" type="text" class="form-control" Style="display:none" >
<input id="txtllamadaIdioma" type="text" class="form-control" Style="display:none" >
<input id="txtExperienciaId" type="text" class="form-control" Style="display:none" >
<input id="txtllamadaExperiencia" type="text" class="form-control" Style="display:none" >
<input id="txtExperienciaFactorId" type="text" class="form-control" Style="display:none" >
<input id="txtSubAreaId" type="text" class="form-control" Style="display:none" >
<script src="../WebScripts/SrcEditPuesto.js" type="text/javascript"></script>
<script src="../WebScripts/SrcCombos.js" type="text/javascript"></script>
 <script src="../WebScripts/SrcGenerales.js" type="text/javascript"></script>
</asp:Content>
