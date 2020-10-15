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
                            var state;
                            if (data == 1)
                                state = 'true'
                            else
                                state = 'false'
                            //alert(state);
                            return '<center><input checked="' + state + '" id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            //if (data == 1)
                            //    return '<center><input checked="checked" id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
                            //else
                            //    return '<center><input id="ChkConceptoIndirecta' + row['ConceptoId'] + '" onchange="CargarMapa()" type="checkbox"></center>'
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
                            return '<a data-toggle="modal" onclick="ModificarEmpresa(' + row['EmpresaId'] + ',\'' + row['Nombre'] + '\', ' + row['PaisId'] + ',' + row['UnidadNegocioId'] + ', \'' + row['Direccion'] + '\', \'' + row['Telefono'] + '\')" data-target="#modalNuevaEmpresa" href="">' + row['NombrePuesto'] + '</a>'
                        },
                        "width": "25%"
                    },
                    {
                        "title": "Cantidad",
                        "data": "Cantidad",
                        "width": "25%"
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
                            return '<a data-toggle="modal" onclick="ModificarEmpresa(' + row['EmpresaId'] + ',\'' + row['Nombre'] + '\', ' + row['PaisId'] + ',' + row['UnidadNegocioId'] + ', \'' + row['Direccion'] + '\', \'' + row['Telefono'] + '\')" data-target="#modalNuevaEmpresa" href="">' + row['Puesto'] + '</a>'
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
                            return '<a data-toggle="modal" onclick="ModificarEmpresa(' + row['EmpresaId'] + ',\'' + row['Nombre'] + '\', ' + row['PaisId'] + ',' + row['UnidadNegocioId'] + ', \'' + row['Direccion'] + '\', \'' + row['Telefono'] + '\')" data-target="#modalNuevaEmpresa" href="">' + row['Documento'] + '</a>'
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
    var data = table
        .rows()
        .data()

        .each(function (row) {
            if (table.cell(i, 2).nodes().to$().find('input')[0].value != '') {
                ResulA = table.cell(i, 2).nodes().to$().find('input')[0].value
                alert(ResulA)
                alert(table.cell(i, 3).nodes().to$().find('input')[0].value)
                alert(table.cell(i, 4).nodes().to$().find('input')[0].value)
                alert(table.cell(i, 5).nodes().to$().find('input')[0].value)
                //alert(table.cell(i, 3).nodes().to$().find('input')[1].value)
            }
            i = i + 1;
        });
}