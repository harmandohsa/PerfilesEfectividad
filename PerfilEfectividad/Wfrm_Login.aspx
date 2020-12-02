﻿
<!DOCTYPE html>
<!--
Template Name: Metronic - Bootstrap 4 HTML, React, Angular 9 & VueJS Admin Dashboard Theme
Author: KeenThemes
Website: http://www.keenthemes.com/
Contact: support@keenthemes.com
Follow: www.twitter.com/keenthemes
Dribbble: www.dribbble.com/keenthemes
Like: www.facebook.com/keenthemes
Purchase: https://1.envato.market/EA4JP
Renew Support: https://1.envato.market/EA4JP
License: You must have a valid license purchased only from themeforest(the above link) in order to legally use the theme for your project.
-->
<html lang="en" >
    <!--begin::Head-->
    <head><base href="../../../">
                <meta charset="utf-8"/>
        <title>Perfiles de Efectividad</title>
        <meta name="description" content="Login page example"/>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

        <!--begin::Fonts-->
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"/>        <!--end::Fonts-->


                    <!--begin::Page Custom Styles(used by this page)-->
                             <link href="assets/css/pages/login/login-2.css" rel="stylesheet" type="text/css"/>
                        <!--end::Page Custom Styles-->

        <!--begin::Global Theme Styles(used by all pages)-->
                    <link href="assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css"/>
                    <link href="assets/plugins/custom/prismjs/prismjs.bundle.css" rel="stylesheet" type="text/css"/>
                    <link href="assets/css/style.bundle.css" rel="stylesheet" type="text/css"/>
                <!--end::Global Theme Styles-->

        <!--begin::Layout Themes(used by all pages)-->

<link href="assets/css/themes/layout/header/base/light.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/themes/layout/header/menu/light.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/themes/layout/brand/dark.css" rel="stylesheet" type="text/css"/>
<link href="assets/css/themes/layout/aside/dark.css" rel="stylesheet" type="text/css"/>        <!--end::Layout Themes-->

        <link rel="shortcut icon" href="assets/media/logos/favicon.ico"/>

            </head>
    <!--end::Head-->

    <!--begin::Body-->
    <body  id="kt_body"  class="header-fixed header-mobile-fixed subheader-enabled subheader-fixed aside-enabled aside-fixed aside-minimize-hoverable"  >

    	<!--begin::Main-->
	<div class="d-flex flex-column flex-root">
		<!--begin::Login-->
<div class="login login-2 login-signin-on d-flex flex-column flex-lg-row flex-column-fluid bg-white" id="kt_login">
    <!--begin::Aside-->
    <div class="login-aside order-2 order-lg-1 d-flex flex-row-auto position-relative overflow-hidden">
        <!--begin: Aside Container-->
        <div class="d-flex flex-column-fluid flex-column justify-content-between py-9 px-7 py-lg-13 px-lg-35">
            <!--begin::Logo-->
            <a  class="text-center pt-2">
                <img src="assets/media/logos/logo.png" class="max-h-75px" alt=""/>
            </a>
            <!--end::Logo-->

            <!--begin::Aside body-->
            <div class="d-flex flex-column-fluid flex-column flex-center">
                <!--begin::Signin-->
                <div class="login-form login-signin py-11">
                    <!--begin::Form-->
                    <div>
                        <!--begin::Title-->
                        <div class="text-center pb-8">
                            <h2 class="font-weight-bolder text-dark font-size-h2 font-size-h1-lg">Ingresar al sistema</h2>
                            
                        </div>
                        <!--end::Title-->

                        <!--begin::Form group-->
                        <div class="form-group">
                            <label class="font-size-h6 font-weight-bolder text-dark">Usuario</label>
                            <input class="form-control form-control-solid h-auto py-7 px-6 rounded-lg" id="TxtUsuario" type="text"/>
                        </div>
                        <!--end::Form group-->

                        <!--begin::Form group-->
                        <div class="form-group">
                            <div class="d-flex justify-content-between mt-n5">
                                <label class="font-size-h6 font-weight-bolder text-dark pt-5">Clave</label>

                                <%--<a  class="text-primary font-size-h6 font-weight-bolder text-hover-primary pt-5" id="kt_login_forgot">
            						Olvido su Clave
            					</a>--%>
                            </div>

                            <input class="form-control form-control-solid h-auto py-7 px-6 rounded-lg" id="TxtClave" type="password" autocomplete="off"/>
                        </div>
                        <!--end::Form group-->

                        <!--begin::Action-->
                        <div class="text-center pt-2">
                            <button onclick="login()" class="btn btn-dark font-weight-bolder font-size-h6 px-8 py-4 my-3">Ingresar</button>
                            <button data-toggle="modal" data-target="#modalDatos" class="btn btn-dark font-weight-bolder font-size-h6 px-8 py-4 my-3">Olvido su Clave</button>
                        </div>
                        <!--end::Action-->
                    </div>
                    <!--end::Form-->
                </div>
                <!--end::Signin-->

                <!--begin::Forgot-->
                <div class="login-form login-forgot pt-11">
                    <!--begin::Form-->
                    <form class="form" novalidate="novalidate" id="kt_login_forgot_form">
                        <!--begin::Title-->
                        <div class="text-center pb-8">
                            <h2 class="font-weight-bolder text-dark font-size-h2 font-size-h1-lg">Forgotten Password ?</h2>
                            <p class="text-muted font-weight-bold font-size-h4">Enter your email to reset your password</p>
                        </div>
                        <!--end::Title-->

                        <!--begin::Form group-->
                        <div class="form-group">
                            <input class="form-control form-control-solid h-auto py-7 px-6 rounded-lg font-size-h6" type="email" placeholder="Email" name="email" autocomplete="off"/>
                        </div>
                        <!--end::Form group-->

                        <!--begin::Form group-->
                        <div class="form-group d-flex flex-wrap flex-center pb-lg-0 pb-3">
                            <button type="button" id="kt_login_forgot_submit" class="btn btn-primary font-weight-bolder font-size-h6 px-8 py-4 my-3 mx-4">Submit</button>
                            <button type="button" id="kt_login_forgot_cancel" class="btn btn-light-primary font-weight-bolder font-size-h6 px-8 py-4 my-3 mx-4">Cancel</button>
                        </div>
                        <!--end::Form group-->
                    </form>
                    <!--end::Form-->
                </div>
                <!--end::Forgot-->
            </div>
            <!--end::Aside body-->

           
        </div>
        <!--end: Aside Container-->
    </div>
    <!--begin::Aside-->

    <!--begin::Content-->
    <div class="content order-1 order-lg-2 d-flex flex-column w-100 pb-0" style="background-color: #B1DCED;">
        <!--begin::Title-->
        <div class="d-flex flex-column justify-content-center text-center pt-lg-40 pt-md-5 pt-sm-5 px-lg-0 pt-5 px-7">
            <h3 class="display4 font-weight-bolder my-7 text-dark" style="color: #986923;">Perfiles de Efectividad</h3>
            <p class="font-weight-bolder font-size-h2-md font-size-lg text-dark opacity-70">
                <%--User Experience & Interface Design, Product Strategy<br/>
                Web Application SaaS Solutions--%>
            </p>
        </div>
        <!--end::Title-->

        <!--begin::Image-->
        <div class="content-img d-flex flex-row-fluid bgi-no-repeat bgi-position-y-bottom bgi-position-x-center" style="background-image: url(assets/media/svg/illustrations/login-visual-2.svg);"></div>
        <!--end::Image-->
    </div>
    <!--end::Content-->
</div>
<!--end::Login-->
	</div>
<!--end::Main-->

    <div class="modal fade slide-up" id="modalDatos" tabindex="-1" role="dialog" aria-labelledby="modalSlideUpLabel" aria-hidden="false">
        <div class="modal-dialog modal-lg">
            <div class="modal-content-wrapper">
            <div class="modal-content ">
                <div class="modal-header clearfix text-left">
                    <h5>Envío de Clave</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        <i class="ik ik-arrow-down bg-blue"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="col-md-6">
                            <div class="form-group required" >
                                <label for="txtUsuarioRecup">Usuario</label>
                                <input id="txtUsuarioRecup" type="text" class="form-control" required>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" onclick="Recuperar()" id="BtnGrabar" class="btn btn-primary"><i class="fa fa-save"></i>Recuperar</button>
                    </div>
                </div>
            </div>
            </div>
            <!-- /.modal-content -->
        </div>
    </div>


        <script>var HOST_URL = "https://preview.keenthemes.com/metronic/theme/html/tools/preview";</script>
        <!--begin::Global Config(global config for global JS scripts)-->
        <script>
            var KTAppSettings = {
    "breakpoints": {
        "sm": 576,
        "md": 768,
        "lg": 992,
        "xl": 1200,
        "xxl": 1400
    },
    "colors": {
        "theme": {
            "base": {
                "white": "#ffffff",
                "primary": "#3699FF",
                "secondary": "#E5EAEE",
                "success": "#1BC5BD",
                "info": "#8950FC",
                "warning": "#FFA800",
                "danger": "#F64E60",
                "light": "#E4E6EF",
                "dark": "#181C32"
            },
            "light": {
                "white": "#ffffff",
                "primary": "#E1F0FF",
                "secondary": "#EBEDF3",
                "success": "#C9F7F5",
                "info": "#EEE5FF",
                "warning": "#FFF4DE",
                "danger": "#FFE2E5",
                "light": "#F3F6F9",
                "dark": "#D6D6E0"
            },
            "inverse": {
                "white": "#ffffff",
                "primary": "#ffffff",
                "secondary": "#3F4254",
                "success": "#ffffff",
                "info": "#ffffff",
                "warning": "#ffffff",
                "danger": "#ffffff",
                "light": "#464E5F",
                "dark": "#ffffff"
            }
        },
        "gray": {
            "gray-100": "#F3F6F9",
            "gray-200": "#EBEDF3",
            "gray-300": "#E4E6EF",
            "gray-400": "#D1D3E0",
            "gray-500": "#B5B5C3",
            "gray-600": "#7E8299",
            "gray-700": "#5E6278",
            "gray-800": "#3F4254",
            "gray-900": "#181C32"
        }
    },
    "font-family": "Poppins"
};
        </script>
        <!--end::Global Config-->

    	<!--begin::Global Theme Bundle(used by all pages)-->
    	    	   <script src="assets/plugins/global/plugins.bundle.js"></script>
		    	   <script src="assets/plugins/custom/prismjs/prismjs.bundle.js"></script>
		    	   <script src="assets/js/scripts.bundle.js"></script>
				<!--end::Global Theme Bundle-->


                    <!--begin::Page Scripts(used by this page)-->
                            <script src="assets/js/pages/custom/login/login-general.js"></script>
                        <!--end::Page Scripts-->
        <script src="assets/vendors/general/js-cookie/src/js.cookie.js" type="text/javascript"></script>
        <script src="WebScripts/SrcGenerales.js"></script>    
        <script src="WebScripts/SrcLogin.js"></script>
            
            </body>
    <!--end::Body-->
</html>