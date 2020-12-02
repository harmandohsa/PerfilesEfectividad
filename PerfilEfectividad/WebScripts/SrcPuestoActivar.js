var Editar = '';
var Imprimir = '';
var Borrar = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 12);
    
    if (Datos[0]['Editar'] == '0') {
        $("#BtnActivarPuesto").css('display', 'none');
        $("#BtnNuevo").css('display', 'none');
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
        url: "../WebServices/Ws_Puestos.asmx/GetListaPuestosInactivos",
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
                        "data": "Puesto",
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

function ModificarPuesto(Id, Dato) {
    if (Editar == 1)
        $('#BtnBorrarPuesto').slideDown();
    $('#txtPuestoId').val(Id);
    $('#txtNombrePuesto').val(Dato);
    $('#txtllamada').val('2');
}

function ActivarPuesto() {
    swal.fire({
        title: 'Activar',
        text: "Esta seguro de activar este puesto",
        type: 'info',
        showCancelButton: true,
        cancelButtonText: 'No',
        confirmButtonText: 'Si'
    }).then(function (result) {
        if (result.value) {
            var sentAjaxData = {
                "PuestoId": $('#txtPuestoId').val(),
                "Estatus": 1,
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