var Editar = '';
var Imprimir = '';

function OpcionesInicioLocal() {
    //Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 8);
    //if (Datos[0]['Insertar'] == '0')
    //    $("#BtnNuevo").css('display', 'none');
    //if (Datos[0]['Editar'] == '0')
    //    $("#BtnGrabarDepartamento").css('display', 'none');
    //Editar = Datos[0]['Editar'];
    //Imprimir = Datos[0]['Imprimir'];
    //DibujarTablaDepartamento();
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
                        "title": "Monto",
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
                        "title": "Tipo Supervision",
                        "data": "TipoSupervision",
                        "width": "25%"
                    },
                    {
                        "title": "Puesto",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarSupervision(' + row['SupervisionId'] + ',\'' + row['NombrePuesto'] + '\', ' + row['TipoSupervisionId'] + ',' + row['Cantidad'] + ')" data-target="#modalSupervisiones" href="">' + row['NombrePuesto'] + '</a>'
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
                        exportOptions: { columns: [0, 1, 2, 3] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Supervisiones',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Supervisiones',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3] },
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
        "PuestoId": PuestoId
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
                    "PuestoId": $('#txtPuestoId').val()
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
                "PuestoId": $('#txtPuestoId').val()
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
            var sentAjaxData = {
                "PuestoId": $('#txtPuestoId').val(),
                "FactorId": factor,
                "Id": Id
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
                "Compartida": Compartida
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
        toastr.success('Manejo de Bienes y Valores Económicos Modificados');
}

function BorrarSupervision(SupervisionId) {
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
                "SupervisionId": SupervisionId
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

function ModificarSupervision(SupervisionId, Puesto, TipoSupervisionId, Cantidad) {
    $('#txtIdSupervision').val(SupervisionId)
    $('#txtPuestoSupervision').val(Puesto)
    $('#txtllamadaSupervision').val(2)
    $('#txtCantidadSupervision').val(Cantidad)
    ComboTipoSupervision();
    $('#cboTipoSupervision').val(TipoSupervisionId)
    $('#txtTipoSupervisionId').val(TipoSupervisionId)
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
                        "TipoSupervision": $('#txtTipoSupervisionId').val(),
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
                        "TipoSupervisionId": $('#txtTipoSupervisionId').val(),
                        "NombrePuesto": $('#txtPuestoSupervision').val(),
                        "Cantidad": $('#txtCantidadSupervision').val(),
                        
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
                "RelacionId": RelacionId
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
                        "AuditoriaExt": AuditoriaExt
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
                        "AuditoriaExt": AuditoriaExt

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
                "ManejoInformacionId": ManejoInformacionId
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

function ActualizaAmiente() {
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "TipoAmbienteTrabajo": $('#txtTipoAmbienteTrabajoId').val()
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
        "TipoRiesgoOcupacional": $('#txtTipoRiesgoOcupacionalId').val()
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
        "TipoEsfuerzoFisico": $('#txtTipoEsfueroFisicolId').val()
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