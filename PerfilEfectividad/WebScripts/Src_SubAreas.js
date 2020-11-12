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
    $("#cboArea").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtAreaId").val($("#cboArea").val());
    });

    DibujarTabla();
    ComboAreas();
}

function DibujarTabla() {

    $('#kt_table_Data').DataTable().destroy();
    $('#kt_table_Data').empty();

    $.ajax({
        type: 'POST',
        data: JSON.stringify(),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/Ws_SubAreas.asmx/GetListaSubAreas",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Data").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "SubareaId",
                        "width": "5%"
                    },
                    {
                        "title": "Área",
                        "data": "Area",
                        "width": "30%"
                    },
                    {
                        "title": "Sub área",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="Modificar(' + row['SubareaId'] + ',\'' + row['SubArea'] + '\',' + row['AreaId'] + ',\'' + row['Area'] + '\')" data-target="#modalDatos" href="">' + row['SubArea'] + '</a>'
                        },
                        "width": "50%"
                    }
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Sub áreas',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Sub áreas',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Sub áreas',
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

function Modificar(Id, Dato, AreaId, Area) {
    $('#BtnBorrar').slideDown();
    $('#txtDatoId').val(Id);
    $('#txtNombre').val(Dato);
    $('#txtllamada').val('2');
    $('#txtAreaId').val(AreaId);
    ComboAreas();
    $('#cboArea').val(AreaId);
}

function Nuevo() {
    $('#BtnBorrar').slideUp();
    $('#txtllamada').val('');
    $('#txtNombre').val('');
    $('#txtDatoId').val('');
}

function Grabar() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtNombre').val() == "") {
                CamposVacios = CamposVacios + 'Nombre Sub área' + "<br />";
                Error = false;
            }
            if ($('#txtAreaId').val() == "") {
                CamposVacios = CamposVacios + 'Área' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamada').val() == 2) {
                    var sentAjaxData = {
                        "AreaId": $('#txtAreaId').val(),
                        "SubAreaId": $('#txtDatoId').val(),
                        "Subarea": $('#txtNombre').val(),
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_SubAreas.asmx/EditSubArea",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTabla()
                            $.unblockUI();
                            $('#modalDatos').modal('hide');
                            toastr.success('Subárea Modificada');
                            Nuevo();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "Subarea": $('#txtNombre').val(),
                        "AreaId": $('#txtAreaId').val()
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_SubAreas.asmx/Insert_SubArea",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTabla()
                            $.unblockUI();
                            $('#modalDatos').modal('hide');
                            toastr.success('Subárea Agregada');
                            Nuevo();
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

function Borrar() {
    swal.fire({
        title: 'Eliminar',
        text: "Esta seguro de eliminar esta sub-área, esto es irreversible",
        type: 'info',
        showCancelButton: true,
        cancelButtonText: 'No',
        confirmButtonText: 'Si'
    }).then(function (result) {
        if (result.value) {
            var sentAjaxData = {
                "SubAreaId": $('#txtDatoId').val()
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/WS_SubAreas.asmx/DeleteSubArea",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    if (data.d == 1) {
                        toastr.success('Sub área Eliminada');
                        $('#modalDatos').modal('hide');
                        DibujarTabla();
                        Nuevo();
                        $.unblockUI();
                    }
                    else {
                        toastr.error('Esta sub área no se puede eliminar ya que esta asociado a algún puesto');
                        $('#modalDatos').modal('hide');
                        Nuevo();
                        $.unblockUI();
                    }


                    return false;
                }
            });
            return retval;
        }
    });
}