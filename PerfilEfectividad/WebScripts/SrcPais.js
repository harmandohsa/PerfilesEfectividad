var Editar = '';
var Imprimir = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 9);
    if (Datos[0]['Insertar'] == '0')
        $("#BtnNuevo").css('display', 'none');
    if (Datos[0]['Editar'] == '0')
        $("#BtnGrabarDepartamento").css('display', 'none');
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    Borrar = Datos[0]['Eliminar'];


    DibujarTabla();
}

function DibujarTabla() {

    $('#kt_table_Data').DataTable().destroy();
    $('#kt_table_Data').empty();

    $.ajax({
        type: 'POST',
        data: JSON.stringify(),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/Ws_Pais.asmx/GetListaPais",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Data").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "PaisId",
                        "width": "5%"
                    },
                    {
                        "title": "País",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="Modificar(' + row['PaisId'] + ',\'' + row['Pais'] + '\')" data-target="#modalDatos" href="">' + row['Pais'] + '</a>'
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
                        title: 'Países',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Países',
                        enabled: true,
                        exportOptions: { columns: [0, 1] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Países',
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

function Modificar(Id, Dato) {
    if (Editar == 0)
        $('#BtnGrabar').slideUp();
    $('#BtnBorrar').slideDown();
    if (Borrar == 0)
        $('#BtnBorrar').slideUp();
    $('#txtDatoId').val(Id);
    $('#txtNombre').val(Dato);
    $('#txtllamada').val('2');
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
                CamposVacios = CamposVacios + 'Nombre País' + "<br />";
                Error = false;
            }
            //if (ValidaExistePuestoNoActual() >= 1) {
            //    CamposVacios = CamposVacios + 'Nombre de puesto ya existe' + "<br />";
            //    Error = false;
            //}
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamada').val() == 2) {
                    var sentAjaxData = {
                        "PaisId": $('#txtDatoId').val(),
                        "Pais": $('#txtNombre').val()
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Pais.asmx/EditPais",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTabla()
                            $.unblockUI();
                            $('#modalDatos').modal('hide');
                            toastr.success('Páis Modificado');
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
                        "Pais": $('#txtNombre').val()
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Pais.asmx/Insert_Pais",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTabla()
                            $.unblockUI();
                            $('#modalDatos').modal('hide');
                            toastr.success('País Agregado');
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
        text: "Esta seguro de eliminar este país, esto es irreversible",
        type: 'info',
        showCancelButton: true,
        cancelButtonText: 'No',
        confirmButtonText: 'Si'
    }).then(function (result) {
        if (result.value) {
            var sentAjaxData = {
                "PaisId": $('#txtDatoId').val()
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/WS_Pais.asmx/DeletePais",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    if (data.d == 1) {
                        toastr.success('País Eliminado');
                        $('#modalDatos').modal('hide');
                        DibujarTabla();
                        Nuevo();
                        $.unblockUI();
                    }
                    else {
                        toastr.error('Este país no se puede eliminar ya que esta asociado a algún puesto');
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