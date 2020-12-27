var Editar = '';
var Imprimir = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 14);
    if (Datos[0]['Imprimir'] == '0')
        $("#BtnGenerar").css('display', 'none');
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    Borrar = Datos[0]['Eliminar'];

    $("#cboUsuario").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtUsuarios").val($("#cboUsuario").val());
    });

    $("#cboActividad").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtActividades").val($("#cboActividad").val());
    });

    $("#cboPuesto").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtPuestos").val($("#cboPuesto").val());
    });

    //DibujarTabla();
    ComboUsuarios();
    ComboActividades();
    ComboPuestos();
}

function GenerarData() {
    DibujarTabla();
}

function DibujarTabla() {
    var sentAjaxData = {
        "FecIni": $('#txtFechaDesde').val(),
        "FecFin": $('#txtFechaHasta').val(),
        "Usuarios": $('#txtUsuarios').val(),
        "Actividades": $('#txtActividades').val(),
        "Puestos": $('#txtPuestos').val()
    };

    $('#kt_table_Data').DataTable().destroy();
    $('#kt_table_Data').empty();

    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/Ws_Bitacoras.asmx/GetBitacorasActividades",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Data").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Fecha",
                        "render": function (data, type, row) {
                            return '<td><span Style="display:none">' + row['FechaLong'] + '</span>' + row['Fecha'] + '</td>';

                        },
                        "width": "10%"
                    },
                    {
                        "title": "Puesto",
                        "data": "Puesto",
                        "width": "30%"
                    },
                    {
                        "title": "Actividad",
                        "data": "Actividad",
                        "width": "30%"
                    },
                    {
                        "title": "Usuario",
                        "data": "Nombre",
                        "width": "30%"
                    },
                    
                    
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Bitacora Actividades',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Bitacora Actividades',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 2, 3] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Bitacora Actividades',
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
                        columns: [0, 1, 2, 3],
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