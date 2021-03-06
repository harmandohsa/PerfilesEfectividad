﻿var Editar = '';
var Imprimir = '';
var Borrar = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 5);
    //alert(Datos[0]['Editar']);
    if (Datos[0]['Editar'] == '0'){
        $("#BtnActualizaInfoGeneral").css('display', 'none');
        $("#BtnActualizaFunciones").css('display', 'none');
        $('#cboTomaDesicion').prop('disabled', 'disabled');
        $('#cboEsfuerzoMental').prop('disabled', 'disabled');
        $("#BtnActualizaBienes").css('display', 'none');
        $('#cboManejoBienes').prop('disabled', 'disabled');
        $("#BtnNuevaSupervision").css('display', 'none');
        $('#cboSupervion').prop('disabled', 'disabled');
        $("#BtnNuevaRelacion").css('display', 'none');
        $("#BtnGrabarRelacion").css('display', 'none');
        $('#cboRelacionInterna').prop('disabled', 'disabled');
        $('#cboRelacionExterna').prop('disabled', 'disabled');
        $("#BtnNuevaManejoInfo").css('display', 'none');
        $("#BtnGrabarManejoInfo").css('display', 'none');
        $('#cboManejoInformacion').prop('disabled', 'disabled');
        $('#cboTipoAmbienteTrabajo').prop('disabled', 'disabled');
        $("#BtnUpdateAmbiente").css('display', 'none');
        $('#cboAmbienteTrabajo').prop('disabled', 'disabled');
        $('#cboTipoRiesgoOcupacional').prop('disabled', 'disabled');
        $("#BtnUpdateRiesgo").css('display', 'none');
        $('#cboRiesgoOcupacional').prop('disabled', 'disabled');
        $('#cboTipoEsfuerzoFisico').prop('disabled', 'disabled');
        $("#BtnUpdateEsfuerzo").css('display', 'none');
        $('#cboEsfuerzoFisico').prop('disabled', 'disabled');
        $('#cboNivelEducacional').prop('disabled', 'disabled');
        $('#cboCarrera').prop('disabled', 'disabled');
        $("#BtnUpdateNivelEducacional").css('display', 'none');
        $('#CboImopactoError').prop('disabled', 'disabled');
        $("#BtnNuevaCursoTecnico").css('display', 'none');
        $("#BtnGrabarCursoTecnico").css('display', 'none');
        $("#BtnActualizaEstudios").css('display', 'none');
        $("#BtnNuevoIdioma").css('display', 'none');
        $("#BtnGrabarIdioma").css('display', 'none');
        $("#BtnNuevaExperiencia").css('display', 'none');
        $("#BtnGrabarExperiencia").css('display', 'none');
        $('#CboExperiencia').prop('disabled', 'disabled');
    }
    if (Datos[0]['Eliminar'] == '0') {
        //$("#BtnBorrarPuesto").css('display', 'none');
    }
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    Borrar = Datos[0]['Eliminar'];
    const urlParams = new URLSearchParams(window.location.search);
    $('#lblPuesto').text(urlParams.get('Puesto'));
    $('#txtPuestoId').val(urlParams.get('PuestoId'));

    $("#cboArea").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtAreaId").val($("#cboArea").val());
        ComboSubAreas($("#txtAreaId").val())
    });

    $("#cboSubArea").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtSubAreaId").val($("#cboSubArea").val());
    });

    $("#cboTomaDesicion").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTomaDecisionId").val($("#cboTomaDesicion").val());
    });

    $("#cboEsfuerzoMental").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtEsfuerzoMentalId").val($("#cboEsfuerzoMental").val());
    });


    $("#cboRelacionExterna").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtRelacionExternalId").val($("#cboRelacionExterna").val());
    });

    $("#cboRelacionInterna").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtRelacionInternalId").val($("#cboRelacionInterna").val());
    });

    $("#cboManejoBienes").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtManejoBienesId").val($("#cboManejoBienes").val());
    });

    $("#cboSupervion").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtSupervisionId").val($("#cboSupervion").val());
    });

    $("#cboManejoInformacion").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtManejoInformacionId").val($("#cboManejoInformacion").val());
    });

    $("#cboTipoAmbienteTrabajo").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTipoAmbienteTrabajoId").val($("#cboTipoAmbienteTrabajo").val());
    });

    $("#cboAmbienteTrabajo").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtAmbienteTrabajoId").val($("#cboAmbienteTrabajo").val());
    });

    $("#cboTipoRiesgoOcupacional").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTipoRiesgoOcupacionalId").val($("#cboTipoRiesgoOcupacional").val());
    });

    $("#cboRiesgoOcupacional").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtRiesgoOcupacionalId").val($("#cboRiesgoOcupacional").val());
    });

    $("#cboTipoEsfuerzoFisico").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTipoEsfueroFisicolId").val($("#cboTipoEsfuerzoFisico").val());
    });

    $("#cboEsfuerzoFisico").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtEsfuerzoFisicolId").val($("#cboEsfuerzoFisico").val());
    });

    $("#cboTipoSupervision").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTipoSupervisionId").val($("#cboTipoSupervision").val());
    });

    $("#cboFrecuencia").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtFrecuenciaId").val($("#cboFrecuencia").val());
    });

    $("#cboTipoRelacion").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTipoRelacionId").val($("#cboTipoRelacion").val());
    });


    $("#cboNivelEducacional").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtGradoId").val($("#cboNivelEducacional").val());
        ComboCarrera($("#txtGradoId").val());
        ComboEducacionFormal(11);
        if ($("#txtGradoId").val() == 1) {
            $('#cboEducacionFormal').val(1);
            $('#txtEducacionFormalId').val(1);
        }
        else if ($("#txtGradoId").val() == 2) {
            $('#cboEducacionFormal').val(2);
            $('#txtEducacionFormalId').val(2);
        }
        else if ($("#txtGradoId").val() == 3) {
            $('#cboEducacionFormal').val(3);
            $('#txtEducacionFormalId').val(3);
        }
        else if ($("#txtGradoId").val() == 4) {
            $('#cboEducacionFormal').val(4);
            $('#txtEducacionFormalId').val(4);
        }
        else if ($("#txtGradoId").val() == 5) {
            $('#cboEducacionFormal').val(5);
            $('#txtEducacionFormalId').val(5);
        }
        else if (($("#txtGradoId").val() == 6) || ($("#txtGradoId").val() == 7)) {
            $('#cboEducacionFormal').val(6);
            $('#txtEducacionFormalId').val(6);
        }
            
        if ($("#txtGradoId").val() < 3)
            $('#DivCarrera').slideUp();
        else
            $('#DivCarrera').slideDown();
    });

    $("#cboCarrera").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtCarreraId").val($("#cboCarrera").val());
    });


    $("#cboEducacionFormal").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtEducacionFormalId").val($("#cboEducacionFormal").val());
    });

    $("#CboImopactoError").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtImpactoErrorId").val($("#CboImopactoError").val());
    });

    $("#cboIdioma").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtIdomaId").val($("#cboIdioma").val());
    });

    $("#cboDominioIdioma").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtDominioIdiomaId").val($("#cboDominioIdioma").val());
    });

    $("#CboExperiencia").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtExperienciaFactorId").val($("#CboExperiencia").val());
    });



    ComboAreas();
    ComboFactorTomaDescion(1);
    ComboFactorEsfuerzoMental(2);
    ComboFactorManejoBienes(3);
    ComboFactorSupervisiones(4);
    ComboFactorRelacionInterna(5);
    ComboFactorRelacionExterna(6);
    ComboManejoInformacion(7);
    ComboAmbienteTrabajo(8);
    ComboRiesgoOcupacional(9);
    ComboEsfuerzoFisico(10);
    ComboEducacionFormal(11);
    ComboImpactoError(12);
    ComboExperiencia(13);
    GetDataGeneral(urlParams.get('PuestoId'));
    GetDataFunciones(urlParams.get('PuestoId'));
    GetDataFactores(urlParams.get('PuestoId'));
    DibujarTablaManejoBienes(urlParams.get('PuestoId'));
    DibujarTablaSupervision(urlParams.get('PuestoId'));
    DibujarTablaRelacionesTrabajo(urlParams.get('PuestoId'));
    DibujarTablaManejoInformacion(urlParams.get('PuestoId'));
    ComboTipoAmbienteTrabajo();
    GetDataAmbienteTrabajo(urlParams.get('PuestoId'))
    ComboTipoRiesgoOcupacional();
    GetDataRiesgoOcupacional(urlParams.get('PuestoId'))
    ComboTipoEsfuerzoFisico();
    GetDataEsfuerzoFisico(urlParams.get('PuestoId'));
    ComboGrados();
    GetDataEducacionFormal(urlParams.get('PuestoId'));
    GetDataCursosTecnicos(urlParams.get('PuestoId'));
    GetDataIdiomas(urlParams.get('PuestoId'));
    ComboIdiomas();
    ComboDominioIdiomas();
    GetDataExperiencia(urlParams.get('PuestoId'));
    GetDataCarreras(urlParams.get('PuestoId'))
}

function GetDataGeneral(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataGeneral",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            $('#txtpuestojefe').val(data.d[0]['PuestoSuperior'])
            $('#txtAreaId').val(data.d[0]['AreaId'])
            $('#cboArea').val(data.d[0]['AreaId'])
            ComboSubAreas(data.d[0]['AreaId'])
            $('#cboSubArea').val(data.d[0]['SubAreaId'])
            $('#txtcodigopuesto').val(data.d[0]['CodigoPuesto'])
            $('#txtcategoria').val(data.d[0]['CategoriaPuesto'])
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GetDataFunciones(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataFunciones",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            $('#txtfuncprincipal').val(data.d[0]['FuncionPrincipal'])
            $('#txtfuncprincipales').val(data.d[0]['Principales'])
            $('#txtfuncdiarias').val(data.d[0]['FuncionDiaria'])
            $('#txtfuncsemquin').val(data.d[0]['FuncionSemanalQuincenal'])
            $('#txtfuncmensual').val(data.d[0]['FuncionMensual'])
            $('#txtfunctrimsem').val(data.d[0]['FuncionTrimestralSemestral'])
            $('#txtfuncanual').val(data.d[0]['FuncionAnual'])
            $('#txtfunceventual').val(data.d[0]['FuncionEventual'])
            $('#txtOtrosEstudios').val(data.d[0]['OtrosEstudios'])
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GetDataFactores(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataFactores",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            //console.log(data.d)
            $('#txtTomaDecisionId').val(data.d[0]['TomaDesicionId'])
            $('#txtEsfuerzoMentalId').val(data.d[0]['EsfuerzoMentalId'])
            $('#txtRelacionInternalId').val(data.d[0]['RelacionInternaId'])
            $('#txtRelacionExternalId').val(data.d[0]['RelacionExternaId'])
            $('#txtManejoBienesId').val(data.d[0]['ManejoBienId'])
            $('#txtSupervisionId').val(data.d[0]['SupervisionId'])
            $('#txtManejoInformacionId').val(data.d[0]['ManejoInformacionId'])
            $('#txtAmbienteTrabajoId').val(data.d[0]['AmbienteTrabajoId'])
            $('#txtRiesgoOcupacionalId').val(data.d[0]['RiesgoOcupacionalId'])
            $('#txtEsfuerzoFisicolId').val(data.d[0]['EsfuerzoFisicoId'])
            $('#txtEducacionFormalId').val(data.d[0]['EducacionFormalId'])
            $('#txtImpactoErrorId').val(data.d[0]['ImpactoErrorId'])
            $('#txtExperienciaFactorId').val(data.d[0]['ExperienciaLaboralId'])
            $('#cboTomaDesicion').val(data.d[0]['TomaDesicionId'])
            $('#cboEsfuerzoMental').val(data.d[0]['EsfuerzoMentalId'])
            $('#cboRelacionInterna').val(data.d[0]['RelacionInternaId'])
            $('#cboRelacionExterna').val(data.d[0]['RelacionExternaId'])
            $('#cboManejoBienes').val(data.d[0]['ManejoBienId'])
            $('#cboSupervion').val(data.d[0]['SupervisionId'])
            $('#cboManejoInformacion').val(data.d[0]['ManejoInformacionId'])
            $('#cboAmbienteTrabajo').val(data.d[0]['AmbienteTrabajoId'])
            $('#cboRiesgoOcupacional').val(data.d[0]['RiesgoOcupacionalId'])
            $('#cboEsfuerzoFisico').val(data.d[0]['EsfuerzoFisicoId'])
            $('#cboEducacionFormal').val(data.d[0]['EducacionFormalId'])
            $('#CboImopactoError').val(data.d[0]['ImpactoErrorId'])
            $('#CboExperiencia').val(data.d[0]['ExperienciaLaboralId'])
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function DibujarTablaManejoBienes(PuestoId) {

    $('#kt_table_ManejoBienes').DataTable().destroy();
    $('#kt_table_ManejoBienes').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataManejoBienes",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_ManejoBienes").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "ConceptoId",
                        "width": "5%"
                    },
                    {
                        "title": "Concepto",
                        "data": "Concepto",
                        "width": "5%"
                    },
                    {
                        "title": "Monto US",
                        "data": "ConceptoId",
                        "render": function (data, type, row) {
                            //return '<label class="kt-radio kt-radio--danger" ><input name="Resp' + row['PreguntaId'] + '" value="1" type="radio"><span></span></label>';
                            return '<input id="' + row['ConceptoId'] + '" type="text" value="' + row['Monto'] + '" class="form-control">'
                        }
                    },
                    {
                        "title": "Indirecta",
                        "data": "Indirecta",
                        "render": function (data, type, row) {
                            if (data == 1)
                                return '<center><input checked="checked" id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            else
                                return '<center><input id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                        }
                    },
                    {
                        "title": "Directa",
                        "data": "Directa",
                        "render": function (data, type, row) {
                            if (data == 1)
                                return '<center><input checked="checked" id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            else
                                return '<center><input id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                        }
                    },
                    {
                        "title": "Compartida",
                        "data": "Compartida",
                        "render": function (data, type, row) {                            
                            if (data == 1)
                                return '<center><input checked="checked" id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            else
                                return '<center><input id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                        }
                    },
                    
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Manejo de Bienes y Valores Económicos',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Manejo de Bienes y Valores Económicos',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Manejo de Bienes y Valores Económicos',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}


function DibujarTablaSupervision(PuestoId) {

    $('#kt_table_Supervision').DataTable().destroy();
    $('#kt_table_Supervision').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataSupervisiones",
        datatype: 'json',
        success: function (data) {

            var table = $("#kt_table_Supervision").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "SupervisionId",
                        "width": "5%"
                    },
                    {
                        "title": "Puesto",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarSupervision(' + row['SupervisionId'] + ',\'' + row['NombrePuesto'] + '\',' + row['Cantidad'] + ')" data-target="#modalSupervisiones" href="">' + row['NombrePuesto'] + '</a>'
                        },
                        "width": "25%"
                    },
                    {
                        "title": "Cantidad",
                        "data": "Cantidad",
                        "width": "25%"
                    },
                    {
                        "title": "Borrar",
                        "data": "SupervisionId",
                        "render": function (data, type, row) {
                            return '<a onclick="BorrarSupervision(' + row['SupervisionId'] + ')"><i class="fa fa-trash-alt"></i></a>'
                        }
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Supervisiones',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Supervisiones',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Supervisiones',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}

function DibujarTablaRelacionesTrabajo(PuestoId) {

    $('#kt_table_RelacionesTrabajo').DataTable().destroy();
    $('#kt_table_RelacionesTrabajo').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId,
        "Tipo": "1,2"
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataRelaciones",
        datatype: 'json',
        success: function (data) {

            var table = $("#kt_table_RelacionesTrabajo").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "RelacionId",
                        "width": "5%"
                    },
                    {
                        "title": "Tipo Relación",
                        "data": "TipoRelacion",
                        "width": "25%"
                    },
                    {
                        "title": "Puesto",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarRelacion(' + row['RelacionId'] + ',\'' + row['Puesto'] + '\', \'' + row['Proposito'] + '\', ' + row['FrecuenciaId'] + ', ' + row['TipoRelacionId'] + ')" data-target="#modalRelacionesIntExt" href="">' + row['Puesto'] + '</a>'
                        },
                        "width": "25%"
                    },
                    {
                        "title": "Proposito",
                        "data": "Proposito",
                        "width": "25%"
                    },
                    {
                        "title": "Frecuencia",
                        "data": "Frecuencia",
                        "width": "25%"
                    },
                    {
                        "title": "Borrar",
                        "data": "RelacionId",
                        "render": function (data, type, row) {
                            return '<a onclick="BorrarRelacion(' + row['RelacionId'] + ')"><i class="fa fa-trash-alt"></i></a>'
                        }
                    }
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Supervisiones',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Supervisiones',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Supervisiones',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}

function DibujarTablaManejoInformacion(PuestoId) {

    $('#kt_table_ManejoInformacion').DataTable().destroy();
    $('#kt_table_ManejoInformacion').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataManejoInformacion",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_ManejoInformacion").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "ManejoInformacionId",
                        "width": "5%"
                    },
                    {
                        "title": "Documento",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarManejoInfo(' + row['ManejoInformacionId'] + ',\'' + row['Documento'] + '\',\'' + row['AccionDocumento'] + '\',\'' + row['TipoInformacion'] + '\', ' + row['Jefe'] + ',' + row['AuditoriaInt'] + ',' + row['AuditoriaExterna'] + ')" data-target="#modalManejoInformacion" href="">' + row['Documento'] + '</a>'
                        },
                        "width": "25%"
                    },
                    {
                        "title": "Acción Documento",
                        "data": "AccionDocumento",
                        "width": "25%"
                    },
                    {
                        "title": "Tipo Información",
                        "data": "TipoInformacion",
                        "width": "25%"
                    },
                    {
                        "title": "Jefe",
                        "data": "Jefe",
                        "render": function (data, type, row) {
                            if (data == 1)
                                return '<center><input checked="checked" id="ChkManejoInfo' + row['ManejoInformacionId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            else
                                return '<center><input id="ChkManejoInfo' + row['ManejoInformacionId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                        }
                    },
                    {
                        "title": "Auditoria Interna",
                        "data": "AuditoriaInt",
                        "render": function (data, type, row) {
                            if (data == 1)
                                return '<center><input checked="checked" id="ChkManejoInfo' + row['ManejoInformacionId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            else
                                return '<center><input id="ChkManejoInfo' + row['ManejoInformacionId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                        }
                    },
                    {
                        "title": "Auditoria Externa",
                        "data": "AuditoriaExterna",
                        "render": function (data, type, row) {
                            if (data == 1)
                                return '<center><input checked="checked" id="ChkManejoInfo' + row['ManejoInformacionId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            else
                                return '<center><input id="ChkManejoInfo' + row['ManejoInformacionId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                        }
                    },
                    {
                        "title": "Borrar",
                        "data": "ManejoInformacionId",
                        "render": function (data, type, row) {
                            return '<a onclick="BorrarManejoInfo(' + row['ManejoInformacionId'] + ')"><i class="fa fa-trash-alt"></i></a>'
                        }
                    }

                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Manejo de Bienes y Valores Económicos',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Manejo de Bienes y Valores Económicos',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Manejo de Bienes y Valores Económicos',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}



function GetDataAmbienteTrabajo(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataAmbienteTrabajo",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            console.log(data.d);
            $('#txtTipoAmbienteTrabajoId').val(data.d[0]['Tipos'])
            var str = data.d[0]['Tipos'].trim();
            $("#cboTipoAmbienteTrabajo").val(str.split(",")).trigger("change");
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GetDataRiesgoOcupacional(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataRiesgoOcupacional",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            console.log(data.d);
            $('#txtTipoRiesgoOcupacionalId').val(data.d[0]['Tipos'])
            var str = data.d[0]['Tipos'].trim();
            $("#cboTipoRiesgoOcupacional").val(str.split(",")).trigger("change");
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GetDataEsfuerzoFisico(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataEsfuerzoFisico",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            console.log(data.d);
            $('#txtTipoEsfueroFisicolId').val(data.d[0]['Tipos'])
            var str = data.d[0]['Tipos'].trim();
            $("#cboTipoEsfuerzoFisico").val(str.split(",")).trigger("change");
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}


function GetDataEducacionFormal(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataEstudioFormal",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            $("#cboNivelEducacional").val(data.d[0]['GradoId']);
            $("#txtGradoId").val(data.d[0]['GradoId']);
            if (data.d[0]['GradoId'] < 3)
                $('#DivCarrera').slideUp();
            else
                $('#DivCarrera').slideDown();
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GetDataCursosTecnicos(PuestoId) {

    $('#kt_table_CursosTecnicos').DataTable().destroy();
    $('#kt_table_CursosTecnicos').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataCursosTecnicos",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_CursosTecnicos").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "CursoId",
                        "width": "5%"
                    },
                    {
                        "title": "Curso",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarCurso(' + row['CursoId'] + ',\'' + row['Curso'] + '\',\'' + row['Duracion'] + '\')" data-target="#modalCursosTecnicos" href="">' + row['Curso'] + '</a>'
                        },
                        "width": "45%"
                    },
                    {
                        "title": "Duración",
                        "data": "Duracion",
                        "width": "50%"
                    },
                    {
                        "title": "Borrar",
                        "data": "CursoId",
                        "render": function (data, type, row) {
                            return '<a onclick="BorrarCursoTecnico(' + row['CursoId'] + ')"><i class="fa fa-trash-alt"></i></a>'
                        }
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Cursos Técnicos',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Cursos Técnicos',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Cursos Técnicos',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1, 2],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}



function GetDataIdiomas(PuestoId) {

    $('#kt_table_Idiomas').DataTable().destroy();
    $('#kt_table_Idiomas').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataIdiomas",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Idiomas").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "IdiomaId",
                        "width": "5%"
                    },
                    {
                        "title": "Idioma",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarIdioma(' + row['IdiomaId'] + ',' + row['IdomaId'] + ',' + row['DominioIdiomaId'] + ')" data-target="#modalIdiomas" href="">' + row['Idioma'] + '</a>'
                        },
                        "width": "45%"
                    },
                    {
                        "title": "Dominio Idioma",
                        "data": "DominioIdioma",
                        "width": "50%"
                    },
                    {
                        "title": "Borrar",
                        "data": "IdiomaId",
                        "render": function (data, type, row) {
                            return '<a onclick="BorrarIdioma(' + row['IdiomaId'] + ')"><i class="fa fa-trash-alt"></i></a>'
                        }
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Idiomas',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Idiomas',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Idiomas',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1, 2],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}


function GetDataExperiencia(PuestoId) {

    $('#kt_table_Experiencia').DataTable().destroy();
    $('#kt_table_Experiencia').empty();

    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataExperiencia",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Experiencia").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "ExperienciaId",
                        "width": "5%"
                    },
                    {
                        "title": "Tipo de Trabajo",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarExperiencia(' + row['ExperienciaId'] + ',\'' + row['TipoTrabajo'] + '\',\'' + row['Tiempo'] + '\')" data-target="#modalExperiencia" href="">' + row['TipoTrabajo'] + '</a>'
                        },
                        "width": "45%"
                    },
                    {
                        "title": "Tiempo",
                        "data": "Tiempo",
                        "width": "50%"
                    },
                    {
                        "title": "Borrar",
                        "data": "ExperienciaId",
                        "render": function (data, type, row) {
                            return '<a onclick="BorrarExperiencia(' + row['ExperienciaId'] + ')"><i class="fa fa-trash-alt"></i></a>'
                        }
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Experiencia',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Experiencia',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Experiencia',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1, 2],
                    }

                ],
                bStateSave: true,
                orderable: true,
                responsive: true,
                dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'B>>
			        <'row'<'col-sm-12'tr>>
			        <'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
                lengthMenu: [
                    [10, 20, -1],
                    [10, 20, "Todos"]
                ],
                pageLength: 10,
                pagingType: "full_numbers",
                order: [[0, "asc"]],
            });
        },
        error: function (result) {
            alert(result);
        }
    });

}

function GrabarInfoGenral() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtAreaId').val() == "") {
                CamposVacios = CamposVacios + 'Área' + "<br />";
                Error = false;
            }
            if ($('#txtpuestojefe').val() == "") {
                CamposVacios = CamposVacios + 'Puesto del Jefe Inmediato' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                var sentAjaxData = {
                    "AreaId": $('#txtAreaId').val(),
                    "PuestoJefe": $('#txtpuestojefe').val(),
                    "PuestoId": $('#txtPuestoId').val(),
                    "SubAreaId": $('#txtSubAreaId').val(),
                    "CodigoPuesto": $('#txtcodigopuesto').val(),
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/UpdateInfoGeneral",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        $.unblockUI();
                        toastr.success('Datos Modificados');
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

function GrabarFunciones() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var sentAjaxData = {
                "FuncPrincipal": $('#txtfuncprincipal').val(),
                "FuncPrincipales": $('#txtfuncprincipales').val(),
                "FuncDiarias": $('#txtfuncdiarias').val(),
                "FuncSemanalQuin": $('#txtfuncsemquin').val(),
                "FuncMensual": $('#txtfuncmensual').val(),
                "FuncTrimSemestre": $('#txtfunctrimsem').val(),
                "FuncAnual": $('#txtfuncanual').val(),
                "FuncEventual": $('#txtfunceventual').val(),
                "PuestoId": $('#txtPuestoId').val(),
                "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/Ws_CrudPerfil.asmx/UpdateFunciones",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    $.unblockUI();
                    toastr.success('Datos Modificados');
                    return false;
                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
        }
    });
}


function GrabarFactores(factor) {
    var Id;
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            if (factor == 1)
                Id = $('#txtTomaDecisionId').val()
            if (factor == 2)
                Id = $('#txtEsfuerzoMentalId').val()
            if (factor == 3)
                Id = $('#txtManejoBienesId').val()
            if (factor == 4)
                Id = $('#txtSupervisionId').val()
            if (factor == 5)
                Id = $('#txtRelacionInternalId').val()
            if (factor == 6)
                Id = $('#txtRelacionExternalId').val()
            if (factor == 7)
                Id = $('#txtManejoInformacionId').val()
            if (factor == 8)
                Id = $('#txtAmbienteTrabajoId').val()
            if (factor == 9)
                Id = $('#txtRiesgoOcupacionalId').val()
            if (factor == 10)
                Id = $('#txtEsfuerzoFisicolId').val()
            if (factor == 12)
                Id = $('#txtImpactoErrorId').val()
            if (factor == 13)
                Id = $('#txtExperienciaFactorId').val()
            var sentAjaxData = {
                "PuestoId": $('#txtPuestoId').val(),
                "FactorId": factor,
                "Id": Id,
                "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/Ws_CrudPerfil.asmx/UpdateFactores",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    $.unblockUI();
                    toastr.success('Factor Modificado');
                    return false;
                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
            GetDataGeneral($('#txtPuestoId').val());
        }
    });
}



function GrabarManejoBienes() {
    var table = $('#kt_table_ManejoBienes').DataTable();
    var i = 0;
    var Indirecta = 0;
    var Directa = 0;
    var Compartida = 0;
    var Monto;
    var data = table
        .rows()
        .data()

        .each(function (row) {
            
            Monto = table.cell(i, 2).nodes().to$().find('input')[0].value
            if (table.cell(i, 3).nodes().to$().find('input')[0].checked == true)
                Indirecta = 1;
            if (table.cell(i, 4).nodes().to$().find('input')[0].checked == true)
                Directa = 1;
            if (table.cell(i, 5).nodes().to$().find('input')[0].checked == true)
                Compartida = 1;
            var sentAjaxData = {
                "PuestoId": $('#txtPuestoId').val(),
                "ConceptoId": row.ConceptoId,
                "Monto": Monto,
                "Indirecta": Indirecta,
                "Directa": Directa,
                "Compartida": Compartida,
                "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/Ws_CrudPerfil.asmx/UpdateDetalleManejoBientes",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    //$.unblockUI();
                    
                    return false;
                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
            i = i + 1;
            Indirecta = 0;
            Directa = 0;
            Compartida = 0;
        });
        GrabaBitacoraActividad(9, $('#txtPuestoId').val(), Desencriptar(Cookies.get('UsuarioId')))
        toastr.success('Manejo de Bienes y Valores Económicos Modificados');
}

function BorrarSupervision(SupervisionId) {
    if (Borrar == 0) {
        toastr.success('No tiene permisos para eliminar');
    }
    else {
        swal.fire({
            title: 'Eliminar',
            text: "Esta seguro de eliminar esta supervisión",
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (result) {
            if (result.value) {
                var sentAjaxData = {
                    "PuestoId": $('#txtPuestoId').val(),
                    "SupervisionId": SupervisionId,
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/DeleteDetalleSupervision",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        if (data.d == 1) {
                            toastr.success('Supervisión Eliminada');
                            DibujarTablaSupervision($('#txtPuestoId').val());
                            $.unblockUI();
                        }
                        else
                            toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

                        return false;
                    }
                });
                return retval;
            }
        });
    }

    
}

function ModificarSupervision(SupervisionId, Puesto, Cantidad) {
    $('#txtIdSupervision').val(SupervisionId)
    $('#txtPuestoSupervision').val(Puesto)
    $('#txtllamadaSupervision').val(2)
    $('#txtCantidadSupervision').val(Cantidad)
}

function LimpiarSupervision() {
    $('#txtIdSupervision').val('')
    $('#txtPuestoSupervision').val('')
    $('#txtllamadaSupervision').val('')
    $('#txtCantidadSupervision').val('')
}

function NuevaSupervision() {
    ComboTipoSupervision();
    LimpiarSupervision();
}

function GrabarSupervision() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtPuestoSupervision').val() == "") {
                CamposVacios = CamposVacios + 'Puesto (s)' + "<br />";
                Error = false;
            }
            if ($('#txtCantidadSupervision').val() == "") {
                CamposVacios = CamposVacios + 'Cantidad de Puestos' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamadaSupervision').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "SupervisionId": $('#txtIdSupervision').val(),
                        "Puesto": $('#txtPuestoSupervision').val(),
                        "Cantidad": $('#txtCantidadSupervision').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/EditDetalleSupervision",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Supervisión Modificada');
                            DibujarTablaSupervision($('#txtPuestoId').val());
                            $('#modalSupervisiones').modal('hide');
                            LimpiarSupervision();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "PuestoVer": 1,
                        "NombrePuesto": $('#txtPuestoSupervision').val(),
                        "Cantidad": $('#txtCantidadSupervision').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                        
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/Insert_DetalleSupervisiones",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Supervisión Agregada');
                            DibujarTablaSupervision($('#txtPuestoId').val());
                            $('#modalSupervisiones').modal('hide');
                            LimpiarSupervision();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
            }
        }
    });
}

function ModificarRelacion(RelacionId, Puesto, Proposito, FrecuenciaId, TipoRelacionId) {
    $('#txtRelacionId').val(RelacionId)
    $('#txtPuestoRelacionTrabajo').val(Puesto)
    $('#txtProposito').val(Proposito)
    ComboFrecuencia();
    $('#cboFrecuencia').val(FrecuenciaId)
    ComboTipoRelacion();
    $('#cboTipoRelacion').val(TipoRelacionId)
    $('#txtllamadaRelacion').val(2)
}

function LimpiarRelacion() {
    $('#txtRelacionId').val('')
    $('#txtPuestoRelacionTrabajo').val('')
    $('#txtProposito').val('')
    $('#txtllamadaRelacion').val('')
}

function NuevaRelacion() {
    ComboFrecuencia();
    ComboTipoRelacion();
    LimpiarRelacion();
}

function GrabarRelacion() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtPuestoRelacionTrabajo').val() == "") {
                CamposVacios = CamposVacios + 'Puesto o Departamento' + "<br />";
                Error = false;
            }
            if ($('#txtProposito').val() == "") {
                CamposVacios = CamposVacios + 'Proposito' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamadaRelacion').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "RelacionId": $('#txtRelacionId').val(),
                        "Puesto": $('#txtPuestoRelacionTrabajo').val(),
                        "Proposito": $('#txtProposito').val(),
                        "FrecuenciaId": $('#txtFrecuenciaId').val(),
                        "TipoRelacionId": $('#txtTipoRelacionId').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/EditDetalleRelaciones",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Relación de Trabajo Modificada');
                            DibujarTablaRelacionesTrabajo($('#txtPuestoId').val());
                            $('#modalRelacionesIntExt').modal('hide');
                            LimpiarRelacion();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "PuestoVer": 1,
                        "NombrePuesto": $('#txtPuestoRelacionTrabajo').val(),
                        "Proposito": $('#txtProposito').val(),
                        "FrecuenciaId": $('#txtFrecuenciaId').val(),
                        "TipoRelacionId": $('#txtTipoRelacionId').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/Insert_DetalleRelaciones",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Relación de Trabajo Agregada');
                            DibujarTablaRelacionesTrabajo($('#txtPuestoId').val());
                            $('#modalRelacionesIntExt').modal('hide');
                            LimpiarRelacion();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
            }
        }
    });
}

function BorrarRelacion(RelacionId) {
    if (Borrar == 0) {
        toastr.success('No tiene permiso para eliminar');
    }
    else {
        swal.fire({
            title: 'Eliminar',
            text: "Esta seguro de eliminar esta relación de trabajo",
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (result) {
            if (result.value) {
                var sentAjaxData = {
                    "PuestoId": $('#txtPuestoId').val(),
                    "RelacionId": RelacionId,
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/DeleteDetalleRelacion",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        if (data.d == 1) {
                            toastr.success('Relación de Trabajo Eliminada');
                            DibujarTablaRelacionesTrabajo($('#txtPuestoId').val());
                            $.unblockUI();
                        }
                        else
                            toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

                        return false;
                    }
                });
                return retval;
            }
        });
    }
    
}

function ModificarManejoInfo(ManejoInformacionId, Documento, AccionDocumento, TipoInformacion, Jefe, AuditoriaInt, AuditoriaExterna) {
    $('#txtManejoInfoId').val(ManejoInformacionId)
    $('#txtDocuemento').val(Documento)
    $('#txtAccionDoc').val(AccionDocumento)
    $('#txtTipoInfo').val(TipoInformacion)
    if (Jefe == 1)
        $("#ChkJefe").prop("checked", true);
    else
        $("#ChkJefe").prop("checked", false);

    if (AuditoriaInt == 1)
        $("#ChkAuditInterna").prop("checked", true);
    else
        $("#ChkAuditInterna").prop("checked", false);

    if (AuditoriaExterna == 1)
        $("#ChkAuditExterna").prop("checked", true);
    else
        $("#ChkAuditExterna").prop("checked", false);
    $('#txtllamadaManejoInfo').val(2)
}

function GrabarmanejoInfo() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtDocuemento').val() == "") {
                CamposVacios = CamposVacios + 'Docuemento' + "<br />";
                Error = false;
            }
            if ($('#txtAccionDoc').val() == "") {
                CamposVacios = CamposVacios + 'Acción Documento' + "<br />";
                Error = false;
            }
            if ($('#txtTipoInfo').val() == "") {
                CamposVacios = CamposVacios + 'Tipo de Información' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                var Jefe = 0;
                var AuditoriaInt = 0;
                var AuditoriaExt = 0;
                if ($('#ChkJefe').prop('checked'))
                    Jefe = 1;
                if ($('#ChkAuditInterna').prop('checked'))
                    AuditoriaInt = 1;
                if ($('#ChkAuditExterna').prop('checked'))
                    AuditoriaExt = 1;

                if ($('#txtllamadaManejoInfo').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "ManejoInformacionId": $('#txtManejoInfoId').val(),
                        "Docuemento": $('#txtDocuemento').val(),
                        "AccionDocumento": $('#txtAccionDoc').val(),
                        "TipoInformacion": $('#txtTipoInfo').val(),
                        "Jefe": Jefe,
                        "AuditoriaInt": AuditoriaInt,
                        "AuditoriaExt": AuditoriaExt,
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/EditManjeoInfo",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Manejo de Información Modificada');
                            DibujarTablaManejoInformacion($('#txtPuestoId').val());
                            $('#modalManejoInformacion').modal('hide');
                            LimpiarManejoInfo();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "PuestoVer": 1,
                        "Documento": $('#txtDocuemento').val(),
                        "Accion": $('#txtAccionDoc').val(),
                        "TipoInformacion": $('#txtTipoInfo').val(),
                        "Jefe": Jefe,
                        "AuditoriaInt": AuditoriaInt,
                        "AuditoriaExt": AuditoriaExt,
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/Insert_DetalleManejoInfo",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Manejo de Información Agregada');
                            DibujarTablaManejoInformacion($('#txtPuestoId').val());
                            $('#modalManejoInformacion').modal('hide');
                            LimpiarManejoInfo();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
            }
        }
    });
}

function LimpiarManejoInfo() {
    $('#txtDocuemento').val('')
    $('#txtAccionDoc').val('')
    $('#txtTipoInfo').val('')
    $("#ChkJefe").prop("checked", false);
    $("#ChkAuditInterna").prop("checked", false);
    $("#ChkAuditExterna").prop("checked", false);
    $('#txtManejoInfoId').val('')
    $('#txtllamadaManejoInfo').val('')
}

function NuevaManejoInfo() {
    LimpiarManejoInfo();
}

function BorrarManejoInfo(ManejoInformacionId) {
    if (Borrar == 0) {
        toastr.success('No tiene permisos para eliminar');
    }
    else {
        swal.fire({
            title: 'Eliminar',
            text: "Esta seguro de eliminar el manejo de información",
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (result) {
            if (result.value) {
                var sentAjaxData = {
                    "PuestoId": $('#txtPuestoId').val(),
                    "ManejoInformacionId": ManejoInformacionId,
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/DeleteDetalleManejoInfo",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        if (data.d == 1) {
                            toastr.success('Manejo de Información Eliminada');
                            DibujarTablaManejoInformacion($('#txtPuestoId').val());
                            $.unblockUI();
                        }
                        else
                            toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

                        return false;
                    }
                });
                return retval;
            }
        });
    }
    
}

function ActualizaAmiente() {
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "TipoAmbienteTrabajo": $('#txtTipoAmbienteTrabajoId').val(),
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_CrudPerfil.asmx/AddAmbienteTrabajo",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            if (data.d == 1) {
                toastr.success('Ambiente Laboral Modificado');
                //ComboTipoAmbienteTrabajo($('#txtPuestoId').val());
                $.unblockUI();
            }
            else
                toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

            return false;
        }
    });
}

function ActualizaRiesgo() {
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "TipoRiesgoOcupacional": $('#txtTipoRiesgoOcupacionalId').val(),
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_CrudPerfil.asmx/AddRiesgoOcupacional",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            if (data.d == 1) {
                toastr.success('Riesgo Ocupacional Modificado');
                //ComboTipoAmbienteTrabajo($('#txtPuestoId').val());
                $.unblockUI();
            }
            else
                toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

            return false;
        }
    });
}

function ActualizaEsfuerzoFisico() {
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "TipoEsfuerzoFisico": $('#txtTipoEsfueroFisicolId').val(),
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_CrudPerfil.asmx/AddEsfuerzoFisico",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            if (data.d == 1) {
                toastr.success('Esfuerzo Físico Modificado');
                //ComboTipoAmbienteTrabajo($('#txtPuestoId').val());
                $.unblockUI();
            }
            else
                toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

            return false;
        }
    });
}

function ActualizaNivelEducacional() {
    
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "GradoId": $('#txtGradoId').val(),
        "EducacionFormalId": $('#txtEducacionFormalId').val(),
        "Carreras": $('#txtCarreraId').val(),
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_CrudPerfil.asmx/UpdateEducacionActual",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            if (data.d == 1) {
                toastr.success('Educación Formal Modificada');
                //ComboTipoAmbienteTrabajo($('#txtPuestoId').val());
                $.unblockUI();
            }
            else
                toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

            return false;
        }
    });
}


function ModificarCurso(CursoId, Curso, Duracion) {
    $('#txtCursoId').val(CursoId)
    $('#txtCurso').val(Curso)
    $('#txtllamadaCurso').val(2)
    $('#txtDuracion').val(Duracion)
}

function LimpiarCursosTecnicos() {
    $('#txtCursoId').val('')
    $('#txtCurso').val('')
    $('#txtllamadaCurso').val('')
    $('#txtDuracion').val('')
}

function NuevaCursoTecnico() {
    LimpiarCursosTecnicos();
}

function GrabarCursoTecnico() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtCurso').val() == "") {
                CamposVacios = CamposVacios + 'Nombre Curso' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamadaCurso').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "CursoId": $('#txtCursoId').val(),
                        "Curso": $('#txtCurso').val(),
                        "Duracion": $('#txtDuracion').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/EditCursoTecnico",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Curso Técnico Modificado');
                            GetDataCursosTecnicos($('#txtPuestoId').val());
                            $('#modalCursosTecnicos').modal('hide');
                            LimpiarCursosTecnicos();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "PuestoVer": 1,
                        "Curso": $('#txtCurso').val(),
                        "Duracion": $('#txtDuracion').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/Insert_DetalleCursoTecnico",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Curso Técnico Agregado');
                            GetDataCursosTecnicos($('#txtPuestoId').val());
                            $('#modalCursosTecnicos').modal('hide');
                            LimpiarCursosTecnicos();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
            }
        }
    });
}

function BorrarCursoTecnico(CursoId) {
    if (Borrar == 0) {
        toastr.success('No tiene permisos para eliminar');
    }
    else {
        swal.fire({
            title: 'Eliminar',
            text: "Esta seguro de eliminar este curso técnico",
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (result) {
            if (result.value) {
                var sentAjaxData = {
                    "PuestoId": $('#txtPuestoId').val(),
                    "CursoId": CursoId,
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/DeleteDetalleCursoTecnico",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        if (data.d == 1) {
                            toastr.success('Curso Técnico Eliminado');
                            GetDataCursosTecnicos($('#txtPuestoId').val());
                            $.unblockUI();
                        }
                        else
                            toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

                        return false;
                    }
                });
                return retval;
            }
        });
    }
    
}

function GrabarOtrosEstudios() {
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "OtrosEstudios": $('#txtOtrosEstudios').val(),
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_CrudPerfil.asmx/UpdateOtrosEstudios",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            $.unblockUI();
            toastr.success('Otros Estudios Modificados');
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}


function ModificarIdioma(IdiomaId, IdomaId, DominioIdiomaId) {
    ComboIdiomas();
    ComboDominioIdiomas();
    $('#txtIdiomaId').val(IdiomaId)
    $('#txtIdomaId').val(IdomaId)
    $('#txtDominioIdiomaId').val(DominioIdiomaId)
    $('#cboIdioma').val(IdomaId)
    $('#cboDominioIdioma').val(DominioIdiomaId)
    $('#txtllamadaIdioma').val(2)
}

function LimpiarIdiomas() {
    $('#txtIdiomaId').val('')
    $('#txtIdomaId').val('')
    $('#txtDominioIdiomaId').val('')
    $('#txtllamadaIdioma').val('')
}

function NuevaCursoTecnico() {
    LimpiarIdiomas();
}

function GrabarIdioma() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtIdomaId').val() == "") {
                CamposVacios = CamposVacios + 'Idioma' + "<br />";
                Error = false;
            }
            if ($('#txtDominioIdiomaId').val() == "") {
                CamposVacios = CamposVacios + 'Dominio Idioma' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamadaIdioma').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "IdiomaId": $('#txtIdiomaId').val(),
                        "IdomaId": $('#txtIdomaId').val(),
                        "DominioIdiomaId": $('#txtDominioIdiomaId').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/EditIdioma",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Idioma Modificado');
                            GetDataIdiomas($('#txtPuestoId').val());
                            $('#modalIdiomas').modal('hide');
                            LimpiarIdiomas();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "PuestoVer": 1,
                        "IdomaId": $('#txtIdomaId').val(),
                        "DominioIdiomaId": $('#txtDominioIdiomaId').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/Insert_Idioma",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Idioma Agregado');
                            GetDataIdiomas($('#txtPuestoId').val());
                            $('#modalIdiomas').modal('hide');
                            LimpiarIdiomas();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
            }
        }
    });
}

function BorrarIdioma(IdiomaId) {
    if (Borrar == 0) {
        toastr.success('No tiene permisos para eliminar');
    }
    else {
        swal.fire({
            title: 'Eliminar',
            text: "Esta seguro de eliminar este idioma",
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (result) {
            if (result.value) {
                var sentAjaxData = {
                    "PuestoId": $('#txtPuestoId').val(),
                    "IdiomaId": IdiomaId,
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/DeleteIdioma",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        if (data.d == 1) {
                            toastr.success('Idioma Eliminado');
                            GetDataIdiomas($('#txtPuestoId').val());
                            $.unblockUI();
                        }
                        else
                            toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

                        return false;
                    }
                });
                return retval;
            }
        });
    }
    
}

function ModificarExperiencia(ExperienciaId, TipoTrabajo, Trabajo) {
    $('#txtExperienciaId').val(ExperienciaId)
    $('#txtTipoTrabajo').val(TipoTrabajo)
    $('#txtTiempoExperiencia').val(Trabajo)
    $('#txtllamadaExperiencia').val(2)
}

function LimpiarExperiencia() {
    $('#txtExperienciaId').val('')
    $('#txtTipoTrabajo').val('')
    $('#txtTiempoExperiencia').val('')
    $('#txtllamadaExperiencia').val('')
}

function NuevaExperiencia() {
    LimpiarExperiencia();
}

function GrabarExperiencia() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtTipoTrabajo').val() == "") {
                CamposVacios = CamposVacios + 'Tipo Trabajo' + "<br />";
                Error = false;
            }
            if ($('#txtTiempoExperiencia').val() == "") {
                CamposVacios = CamposVacios + 'Tiempo' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamadaExperiencia').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "ExperienciaId": $('#txtExperienciaId').val(),
                        "Trabajo": $('#txtTipoTrabajo').val(),
                        "Tiempo": $('#txtTiempoExperiencia').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/EditExperiencia",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Experiencia Modificada');
                            GetDataExperiencia($('#txtPuestoId').val());
                            $('#modalExperiencia').modal('hide');
                            LimpiarExperiencia();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "PuestoVer": 1,
                        "Trabajo": $('#txtTipoTrabajo').val(),
                        "Tiempo": $('#txtTiempoExperiencia').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/Ws_CrudPerfil.asmx/Insert_Experiencia",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            $.unblockUI();
                            toastr.success('Experiencia Agregada');
                            GetDataExperiencia($('#txtPuestoId').val());
                            $('#modalExperiencia').modal('hide');
                            LimpiarExperiencia();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
            }
        }
    });
}

function BorrarExperiencia(ExperienciaId) {
    if (Borrar == 0) {
        toastr.success('No tiene permisos para eliminar');
    }
    else {
        swal.fire({
            title: 'Eliminar',
            text: "Esta seguro de eliminar esta Experiencia",
            type: 'info',
            showCancelButton: true,
            cancelButtonText: 'No',
            confirmButtonText: 'Si'
        }).then(function (result) {
            if (result.value) {
                var sentAjaxData = {
                    "PuestoId": $('#txtPuestoId').val(),
                    "ExperienciaId": ExperienciaId,
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_CrudPerfil.asmx/DeleteExperiencia",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        if (data.d == 1) {
                            toastr.success('Experiencia Eliminada');
                            GetDataExperiencia($('#txtPuestoId').val());
                            $.unblockUI();
                        }
                        else
                            toastr.error('Este Item no se puede eliminar ya que esta asociado a algún proceso');

                        return false;
                    }
                });
                return retval;
            }
        });
    }
    
}

function GetDataCarreras(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };
    ComboCarrera($("#txtGradoId").val())
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataCarreras",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            console.log(data.d);
            $('#txtCarreraId').val(data.d[0]['Carreras'])
            var str = data.d[0]['Carreras'].trim();
            $("#cboCarrera").val(str.split(",")).trigger("change");
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}