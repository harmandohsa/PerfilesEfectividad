<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="Wfrm_CargaPerfil.aspx.cs" Inherits="PerfilEfectividad.WebForms.Wfrm_CargaPerfil" %>
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
					    Carga de Perfiles </a>
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
				                Carga de Archivos
			                </h3>
		                </div>
		                <div class="kt-portlet__head-toolbar">
			                <div class="kt-portlet__head-wrapper">
				                <div class="kt-portlet__head-actions">
                                
				                </div>
			                </div>
		                </div>
	                </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-3">
                                    <input type="file" name="file" class="btn btn-label-brand btn-bold btn-sm" id="FileUpload" >
                                </div>
                                <div class="col-md-3">
                                   <label class="kt-checkbox kt-checkbox--bold kt-checkbox--brand">
									    <input id="ChkSeccionA"  type="checkbox"> Solo Sección A
									    <span></span>
								    </label>
                                </div>
                            </div>
                            <div class="row">
                                
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="DivErr">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <script src="../WebScripts/SrcCargaPerfil.js" type="text/javascript"></script>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
