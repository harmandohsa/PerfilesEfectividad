var Editar = '';
var Imprimir = '';
var Borrar = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 13);
    if (Datos[0]['Insertar'] == '0')
        $("#BtnNuevo").css('display', 'none');
    Editar = Datos[0]['Editar'];
    if (Editar == 0)
        $("#BtnGrabar").css('display', 'none');
    GetPermisos();
    var a = GetLogo();
    $("#profile-img-tag").attr({ src: "data:image/jpeg;base64," + a })
    $("#profile-img").change(function () {
        $.blockUI({
            message: '<h1><i class="fa fa-spinner fa-spin"></i></h1>',
            css: { color: '#fff', border: 'none', backgroundColor: 'none' }
        });
        readURL(this);
        $.unblockUI();
    });
}

function GetLogo() {
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_ConfReportes.asmx/GetLogo",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        }
    });
    return retval;
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        var bfile;
        var byteData;
        var fileName;
        var contentType;



        reader.onload = function (e) {

            var ext = input.files[0].name.split('.').pop().toLowerCase();
            if (ext != "jpg") {
                $.toast({
                    heading: 'Error',
                    text: 'Solo puede subir imagenes en formato jpg',
                    position: 'top-right',
                    stack: false,
                    icon: 'error',
                    showHideTransition: 'slide',
                    hideAfter: 3000
                })
            }
            else {
                var size = input.files[0].size;
                if (size > 5242880) {
                    $.toast({
                        heading: 'Error',
                        text: 'El Archivo no debe de exceder los 5MB',
                        position: 'top-right',
                        stack: false,
                        icon: 'error',
                        showHideTransition: 'slide',
                        hideAfter: 3000
                    })
                }
                else {
                    $('#profile-img-tag').attr('src', e.target.result);
                    bfile = e.target.result
                    //alert(bfile);   // this shows bfile
                    console.log(bfile)
                    byteData = bfile.split(';')[1].replace("base64,", "");
                    //alert(byteData);
                    fileName = input.files[0].name;
                    contentType = input.files[0].type;

                    var sentAjaxData = {
                        "Foto": byteData,
                        "fileName": fileName,
                        "ContentType": contentType
                    };
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_ConfReportes.asmx/UpdateLogo",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            toastr.success('Logo Actualizado');
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }

            }



        }
        reader.readAsDataURL(input.files[0]);
        fileName = input.files[0].name;
        contentType = input.files[0].type;
    }
}

function GetPermisos() {
    
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_ConfReportes.asmx/GetConfReportes",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            var len = data.d.length;
            if (data.d[0]['InfoGeneral'] == 1)
                $("#ChkInfoGeneral").prop('checked', true);
            else
                $("#ChkInfoGeneral").prop('checked', false);
            if (data.d[0]['Tareas'] == 1)
                $("#ChkTareas").prop('checked', true);
            else
                $("#ChkTareas").prop('checked', false);
            if (data.d[0]['TomaDesiciones'] == 1)
                $("#ChkTomaDesciones").prop('checked', true);
            else
                $("#ChkTomaDesciones").prop('checked', false);
            if (data.d[0]['EsfuerzoMental'] == 1)
                $("#ChkEsfuerzoMental").prop('checked', true);
            else
                $("#ChkEsfuerzoMental").prop('checked', false);
            if (data.d[0]['ManejoBienes'] == 1)
                $("#ChkManejoBienes").prop('checked', true);
            else
                $("#ChkManejoBienes").prop('checked', false);
            if (data.d[0]['Supervision'] == 1)
                $("#ChkSupervision").prop('checked', true);
            else
                $("#ChkSupervision").prop('checked', false);
            if (data.d[0]['RelacionesTrabajo'] == 1)
                $("#ChkRelaciones").prop('checked', true);
            else
                $("#ChkRelaciones").prop('checked', false);
            if (data.d[0]['ManejoInfo'] == 1)
                $("#ChkManejoInformacion").prop('checked', true);
            else
                $("#ChkManejoInformacion").prop('checked', false);
            if (data.d[0]['AmbienteTrabajo'] == 1)
                $("#ChkAmbienteTrabajo").prop('checked', true);
            else
                $("#ChkAmbienteTrabajo").prop('checked', false);
            if (data.d[0]['RiesgoOcupacional'] == 1)
                $("#ChkRiesgoOcupacional").prop('checked', true);
            else
                $("#ChkRiesgoOcupacional").prop('checked', false);
            if (data.d[0]['EsfuerzoFisico'] == 1)
                $("#ChkEsfuerzoFisico").prop('checked', true);
            else
                $("#ChkEsfuerzoFisico").prop('checked', false);
            if (data.d[0]['EducacionFormal'] == 1)
                $("#ChkEducacionFormal").prop('checked', true);
            else
                $("#ChkEducacionFormal").prop('checked', false);
            if (data.d[0]['ImpactoError'] == 1)
                $("#ChkImpactoError").prop('checked', true);
            else
                $("#ChkImpactoError").prop('checked', false);
            if (data.d[0]['CursosTecnicos'] == 1)
                $("#ChkCursosTecnicos").prop('checked', true);
            else
                $("#ChkCursosTecnicos").prop('checked', false);
            if (data.d[0]['OtrasEstudios'] == 1)
                $("#ChkOtrosEstudios").prop('checked', true);
            else
                $("#ChkOtrosEstudios").prop('checked', false);
            if (data.d[0]['Idiomas'] == 1)
                $("#ChkIdiomas").prop('checked', true);
            else
                $("#ChkIdiomas").prop('checked', false);
            if (data.d[0]['Experiencia'] == 1)
                $("#ChkExperiencia").prop('checked', true);
            else
                $("#ChkExperiencia").prop('checked', false);
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Grabar() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            //if ($('#txtNombre').val() == "") {
            //    CamposVacios = CamposVacios + 'Nombre Área' + "<br />";
            //    Error = false;
            //}
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                var InfoGeneral = 0;
                var Tareas = 0;
                var TomaDesiciones = 0;
                var EsfuerzoMental = 0;
                var ManejoBienes = 0;
                var Supervision = 0;
                var RelacionesTrabajo = 0;
                var ManejoInfo = 0;
                var AmbienteTrabajo = 0;
                var RiesgoOcupacional = 0;
                var EsfuerzoFisico = 0;
                var EducacionFormal = 0;
                var ImpactoError = 0;
                var CursosTecnicos = 0;
                var OtrasEstudios = 0;
                var Idiomas = 0;
                var Experiencia = 0;
                if ($("#ChkInfoGeneral").is(":checked"))
                    InfoGeneral = 1
                if ($("#ChkTareas").is(":checked"))
                    Tareas = 1
                if ($("#ChkTomaDesciones").is(":checked"))
                    TomaDesiciones = 1
                if ($("#ChkEsfuerzoMental").is(":checked"))
                    EsfuerzoMental = 1
                if ($("#ChkManejoBienes").is(":checked"))
                    ManejoBienes = 1
                if ($("#ChkSupervision").is(":checked"))
                    Supervision = 1
                if ($("#ChkRelaciones").is(":checked"))
                    RelacionesTrabajo = 1
                if ($("#ChkManejoInformacion").is(":checked"))
                    ManejoInfo = 1
                if ($("#ChkAmbienteTrabajo").is(":checked"))
                    AmbienteTrabajo = 1
                if ($("#ChkRiesgoOcupacional").is(":checked"))
                    RiesgoOcupacional = 1
                if ($("#ChkEsfuerzoFisico").is(":checked"))
                    EsfuerzoFisico = 1
                if ($("#ChkEducacionFormal").is(":checked"))
                    EducacionFormal = 1
                if ($("#ChkImpactoError").is(":checked"))
                    ImpactoError = 1
                if ($("#ChkCursosTecnicos").is(":checked"))
                    CursosTecnicos = 1
                if ($("#ChkOtrosEstudios").is(":checked"))
                    OtrasEstudios = 1
                if ($("#ChkIdiomas").is(":checked"))
                    Idiomas = 1
                if ($("#ChkExperiencia").is(":checked"))
                    Experiencia = 1
                var sentAjaxData = {
                    "InfoGeneral": InfoGeneral,
                    "Tareas": Tareas,
                    "TomaDesiciones": TomaDesiciones,
                    "EsfuerzoMental": EsfuerzoMental,
                    "ManejoBienes": ManejoBienes,
                    "Supervision": Supervision,
                    "RelacionesTrabajo": RelacionesTrabajo,
                    "ManejoInfo": ManejoInfo,
                    "AmbienteTrabajo": AmbienteTrabajo,
                    "RiesgoOcupacional": RiesgoOcupacional,
                    "EsfuerzoFisico": EsfuerzoFisico,
                    "EducacionFormal": EducacionFormal,
                    "ImpactoError": ImpactoError,
                    "CursosTecnicos": CursosTecnicos,
                    "OtrasEstudios": OtrasEstudios,
                    "Idiomas": Idiomas,
                    "Experiencia": Experiencia
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/WS_ConfReportes.asmx/EditConfReportes",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        toastr.success('Configuración Modificada');
                        $.unblockUI();
                        return false;
                    },
                    error: function (request, status, error) {
                        alert(request.responseText);
                    }
                });

            }
        }
    });
}