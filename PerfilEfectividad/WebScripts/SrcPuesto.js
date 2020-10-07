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
                    }
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

//function NuevoDepartamento() {
//    $('#txtllamada').val('');
//    $('#txtDepartamento').val('');
//}

function EditarPuesto(Id, Dato) {
    $('#txtDepartamentoId').val(Id);
    $('#txtDepartamento').val(Dato);
    $('#txtllamada').val('2');
}

//function GrabarDepartamento() {
//    $.blockUI({
//        message: 'Cargando Datos',
//        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
//        onBlock: function () {
//            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
//            var Error = true;
//            if ($('#txtDepartamento').val() == "") {
//                CamposVacios = CamposVacios + 'Departamento' + "<br />";
//                Error = false;
//            }
//            if (Error == false) {
//                toastr.error(CamposVacios);
//                $.unblockUI();
//                return Error;

//            }
//            else {
//                if ($('#txtllamada').val() == '2') {
//                    var sentAjaxData = {
//                        "DepartamentoId": $('#txtDepartamentoId').val(),
//                        "Departamento": $('#txtDepartamento').val()
//                    };
//                    var retval;
//                    $.ajax({
//                        type: "POST",
//                        url: "../WebServices/WS_Departamentos.asmx/EditDepartamento",
//                        dataType: "json",
//                        contentType: "application/json",
//                        data: JSON.stringify(sentAjaxData),
//                        async: false,
//                        success: function (data) {
//                            DibujarTablaDepartamento()
//                            $.unblockUI();
//                            $('#modalNuevoDepartamento').modal('hide');
//                            toastr.success('Departamento Modificado');
//                            $('#txtllamada').val('')
//                            $('#txtDepartamento').val('')
//                            return false;
//                        },
//                        error: function (request, status, error) {
//                            alert(request.responseText);
//                        }
//                    });
//                }
//                else {
//                    var sentAjaxData = {
//                        "Departamento": $('#txtDepartamento').val()
//                    };
//                    var retval;
//                    $.ajax({
//                        type: "POST",
//                        url: "../WebServices/WS_Departamentos.asmx/InsertDepartamento",
//                        dataType: "json",
//                        contentType: "application/json",
//                        data: JSON.stringify(sentAjaxData),
//                        async: false,
//                        success: function (data) {
//                            DibujarTablaDepartamento()
//                            $.unblockUI();
//                            $('#modalNuevoDepartamento').modal('hide');
//                            toastr.success('Departamento Grabado');
//                            $('#txtDepartamento').val('')
//                            return false;
//                        },
//                        error: function (request, status, error) {
//                            alert(request.responseText);
//                        }
//                    });
//                }
//            }
//        }
//    });
//}
