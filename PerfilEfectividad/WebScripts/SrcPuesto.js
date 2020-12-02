var Editar = '';
var Imprimir = '';
var Borrar = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 5);
    if (Datos[0]['Insertar'] == '0') {
        $("#BtnGrabarPuesto").css('display', 'none');
        $("#BtnNuevo").css('display', 'none');
    }
    if (Datos[0]['Editar'] == '0') {
        $("#BtnGrabarPuesto").css('display', 'none');
        $("#BtnNuevo").css('display', 'none');
    }
    if (Datos[0]['Eliminar'] == '0') {
        $("#BtnBorrarPuesto").css('display', 'none');
    }
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    Borrar = Datos[0]['Eliminar'];
    DibujarTablaPuesto();
}

function DibujarTablaPuesto() {

    $('#kt_table_Puestos').DataTable().destroy();
    $('#kt_table_Puestos').empty();

    $.ajax({
        type: 'POST',
        data: JSON.stringify(),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/Ws_Puestos.asmx/GetListaPuestos",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Puestos").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "PuestoId",
                        "width": "5%"
                    },
                    {
                        "title": "Puesto",
                        "render": function (data, type, row) {
                            return '<a href="../WebForms/Wfrm_EditPuestos.aspx?PuestoId=' + row['PuestoId'] + '&Puesto=' + row['Puesto'] + '">' + row['Puesto'] + '</a>'
                        },
                        "width": "50%"
                    },
                    {
                        "title": "Editar",
                        "data": "PuestoId",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarPuesto(' + row['PuestoId'] + ',\'' + row['Puesto'] + '\')" data-target="#modalEditPuesto" href=""> <i class="fa fa-edit"></i></a > '
                        }
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Puestos',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Puestos',
                        enabled: true,
                        exportOptions: { columns: [0, 1] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Puestos',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1] },
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

function NuevoPuesto() {
    $('#BtnBorrarPuesto').slideUp();
    $('#txtllamada').val('');
    $('#txtDepartamento').val('');
}

function ModificarPuesto(Id, Dato) {
    if (Borrar == 1)
        $('#BtnBorrarPuesto').slideDown();
    $('#txtPuestoId').val(Id);
    $('#txtNombrePuesto').val(Dato);
    $('#txtllamada').val('2');
}

function GrabarPuesto() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtNombrePuesto').val() == "") {
                CamposVacios = CamposVacios + 'Nombre Puesto' + "<br />";
                Error = false;
            }
            if ($('#txtllamadaCurso').val() == 2) {
                if (ValidaExistePuestoNoActual() >= 1) {
                    CamposVacios = CamposVacios + 'Nombre de puesto ya existe' + "<br />";
                    Error = false;
                }
            }
            else {
                if (ValidaExistePuesto() >= 1) {
                    CamposVacios = CamposVacios + 'Nombre de puesto ya existe' + "<br />";
                    Error = false;
                }
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamada').val() == 2) {
                    var sentAjaxData = {
                        "PuestoId": $('#txtPuestoId').val(),
                        "Puesto": $('#txtNombrePuesto').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Puestos.asmx/EditNomprePuesto",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTablaPuesto()
                            $.unblockUI();
                            $('#modalEditPuesto').modal('hide');
                            toastr.success('Puesto Modificado');
                            $('#txtllamada').val('')
                            $('#txtPuestoId').val('')
                            $('#txtNombrePuesto').val('')
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "Puesto": $('#txtNombrePuesto').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Puestos.asmx/Insert_Puesto",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTablaPuesto()
                            $.unblockUI();
                            $('#modalEditPuesto').modal('hide');
                            toastr.success('Puesto Agregado');
                            $('#txtllamada').val('')
                            $('#txtPuestoId').val('')
                            $('#txtNombrePuesto').val('')
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

function ValidaExistePuestoNoActual() {
    var sentAjaxData = {
        "PuestoId": $('#txtPuestoId').val(),
        "Puesto": $('#txtNombrePuesto').val()
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Puestos.asmx/ExistePuestoNoActual",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
    return retval;
}

function ValidaExistePuesto() {
    var sentAjaxData = {
        "Puesto": $('#txtNombrePuesto').val()
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Puestos.asmx/ExistePuesto",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
    return retval;
}


function BorrarPuesto() {
    swal.fire({
        title: 'Inactivar',
        text: "Esta seguro de inactivar este puesto",
        type: 'info',
        showCancelButton: true,
        cancelButtonText: 'No',
        confirmButtonText: 'Si'
    }).then(function (result) {
        if (result.value) {
            var sentAjaxData = {
                "PuestoId": $('#txtPuestoId').val(),
                "Estatus": 2,
                "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/Ws_Puestos.asmx/DeletePuesto",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    if (data.d == 1) {
                        toastr.success('Puesto Eliminado');
                        $('#modalEditPuesto').modal('hide');
                        DibujarTablaPuesto();
                        $('#txtNombrePuesto').val('')
                        $('#txtllamada').val('')
                        $('#txtPuestoId').val('')
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