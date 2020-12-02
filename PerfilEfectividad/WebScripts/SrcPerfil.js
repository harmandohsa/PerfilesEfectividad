var Editar = '';
var Imprimir = '';
var ConsultarPermisos = ''
var EditarPermisos = ''
var ImprimirPermisos = ''

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 1);
    if (Datos[0]['Insertar'] == '0')
        $("#BtnNuevo").css('display', 'none');
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    if (Editar == '0') {
        $("#BtnGrabarPerfil").css('display', 'none');
    }
    DatosPermisos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 2);
    ConsultarPermisos = DatosPermisos[0]['Consultar'];
    EditarPermisos = DatosPermisos[0]['Editar'];
    ImprimirPermisos = DatosPermisos[0]['Imprimir'];
    DibujarTablaPerfil();
}

function DibujarTablaPerfil() {

    $('#kt_table_perfiles').DataTable().destroy();
    $('#kt_table_perfiles').empty();

    $.ajax({
        type: 'POST',
        data: JSON.stringify(),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_Perfil.asmx/GetListaPerfiles",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_perfiles").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Código",
                        "data": "PerfilId",
                        "width": "5%"
                    },
                    {
                        "title": "Perfil",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" data-target="#modalNuevoPerfil"  onclick="EditarData(' + row['PerfilId'] + ',\'' + row['Perfil'] + '\')"  href="">' + row['Perfil'] + '</a>'
                        },
                        "width": "95%"
                    },
                    {
                        "title": "Permisos",
                        "data": "PerfilId",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal"  href=""  onclick="CargaPermisos(' + row['PerfilId'] + ',\'' + row['Perfil'] + '\')"><i class="fa fa-eye"></i></a>';

                        }
                    },
                    {
                        "title": "Cantidad Usuarios",
                        "data": "CntUsuarios",
                        "width": "15%"
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Listado de Perfiles',
                        text: 'Imprimir',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 3] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Listado de Perfiles',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 3] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Listado de Perfiles',
                        download: 'open',
                        enabled: true,
                        exportOptions: { columns: [0, 1, 3] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50,
                                image: ImgRep
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [0, 1, 3]
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
            $('#kt_table_perfiles tbody').on('click', 'a.ModPerfil', function () {
                var data = table.row($(this).parents('tr')).data();
                $('#txtperfilid').val(data["PerfilId"]);
                $('#txtPerfil').val(data["Perfil"]);
                $('#txtllamada').val('2');
            });
            //$('#kt_table_perfiles').on('draw.dt', function () {
            //    if (Imprimir == '1') {
            //        table.button(0).enable();
            //        table.button(1).enable();
            //        table.button(2).enable();
            //        table.button(3).enable();
            //    }
            //});
            //if (Editar == '0')
            //    table.column(2).visible(false);


        },
        error: function (result) {
            alert(result);
        }
    });

}

function EditarData(Id, Dato) {
    $('#txtperfilid').val(Id);
    $('#txtPerfil').val(Dato);
    $('#txtllamada').val('2');
}

function GrabarPerfil() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtPerfil').val() == "") {
                CamposVacios = CamposVacios + 'Perfil' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                if ($('#txtllamada').val() == '2') {
                    var sentAjaxData = {
                        "PerfilId": $('#txtperfilid').val(),
                        "Perfil": $('#txtPerfil').val()
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Perfil.asmx/EditPerfil",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTablaPerfil()
                            $.unblockUI();
                            $('#modalNuevoPerfil').modal('hide');
                            toastr.success('Perfil Modificado');
                            $('#txtllamada').val('')
                            $('#txtPerfil').val('')
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "Perfil": $('#txtPerfil').val()
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Perfil.asmx/InsertPerfil",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTablaPerfil()
                            $.unblockUI();
                            $('#modalNuevoPerfil').modal('hide');
                            toastr.success('Perfil Grabado');
                            $('#txtPerfil').val('')
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

function Nuevo() {
    $('#txtllamada').val('');
    $('#txtPerfil').val('');
}


function CargaPermisos(PerfilId, Perfil) {
    if (ConsultarPermisos == 0) {
        toastr.error('No tiene permisos para ingresar a esta opción');
    }
    else {
        $('#modalPerfiles').modal('show');
        $('#lblTituloPermisos').text('Permisos del Perfil: ' + Perfil);
        DibujarTablaPermisosPerfil(PerfilId);
        $('#txtperfilid').val(PerfilId);
    }
}

function DibujarTablaPermisosPerfil(PerfilId) {

    $('#kt_table_permisosperfiles').DataTable().destroy();
    $('#kt_table_permisosperfiles').empty();


    var PerfilId = PerfilId;
    var sentAjaxData = {
        "PerfilId": PerfilId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_PermisosPerfil.asmx/GetPermisosPerfil",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_permisosperfiles").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Módulo",
                        "data": "Modulo",
                        "width": "30%"
                    },
                    {
                        "title": "Página",
                        "data": "Pagina",
                        "width": "30%"
                    },
                    {
                        "title": "Consultar",
                        "data": "Consultar",
                        "render": function (data, type, row) {
                            if (EditarPermisos == 1) {
                                if (data == 1)
                                    return '<button  onclick="CambiaEstatus(' + row['PaginaId'] + ',1,0)"  type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button   onclick="CambiaEstatus(' + row['PaginaId'] + ',1,1)"  type="button" class="btn btn-danger">Inactivo</button>';
                            }
                            else {
                                if (data == 1)
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',1,0)"  type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button  disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',1,1)"  type="button" class="btn btn-danger">Inactivo</button>';
                            }


                        }
                    },
                    {
                        "title": "Insertar",
                        "data": "Insertar",
                        "render": function (data, type, row) {
                            if (EditarPermisos == 1) {
                                if (data == 1)
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',2,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',2,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }
                            else {
                                if (data == 1)
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',2,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',2,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }


                        }

                    },
                    {
                        "title": "Editar",
                        "data": "Editar",
                        "render": function (data, type, row) {
                            if (EditarPermisos == 1) {
                                if (data == 1)
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',3,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',3,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }
                            else {
                                if (data == 1)
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',3,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',3,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }


                        }
                    },
                    {
                        "title": "Eliminar",
                        "data": "Eliminar",
                        "render": function (data, type, row) {
                            if (EditarPermisos == 1) {
                                if (data == 1)
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',4,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',4,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }
                            else {
                                if (data == 1)
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',4,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',4,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }


                        }
                    },
                    {
                        "title": "Imprimir",
                        "data": "Imprimir",
                        "render": function (data, type, row) {
                            if (EditarPermisos == 1) {
                                if (data == 1)
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',5,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button onclick="CambiaEstatus(' + row['PaginaId'] + ',5,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }
                            else {
                                if (data == 1)
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',5,0)" type="button" class="btn btn-success">Activo</button>';
                                else
                                    return '<button disabled onclick="CambiaEstatus(' + row['PaginaId'] + ',5,1)" type="button" class="btn btn-danger">Inactivo</button>';
                            }

                        }
                    }
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Listado de Permisos Perfiles',
                        text: 'Imprimir',
                        enabled: false
                    },
                    {
                        extend: 'copyHtml5',
                        title: 'Listado de Permisos Perfiles',
                        text: 'Copiar',
                        enabled: false
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Listado de Permisos Perfiles',
                        enabled: false
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Listado de Permisos Perfiles',
                        download: 'open',
                        enabled: false,
                        exportOptions: { columns: [1, 2, 3, 4, 5, 6] },
                        customize: function (doc) {
                            doc.content.splice(1, 0, {
                                margin: [0, 0, 0, 2],
                                alignment: 'left',
                                width: 150,
                                height: 50,
                                image: ImgRep
                            });
                        }
                    },
                    {
                        extend: 'colvis',
                        text: 'Columnas Visibles',
                        columns: [1, 2, 3, 4, 5, 6]
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
                order: [[0, "asc"]]
                //"createdRow": function (row, data, index) {
                //    if (Editar == 1) {
                //        $('td', row).eq(3).find("#BtnConsultarOk").attr('enabled',true);
                //        $('td', row).eq(3).find("#BtnConsultarNoOk").attr('enabled', true);
                //    }
                //    if ($('td', row).eq(5).text().trim() == '1') {
                //        $('td', row).eq(6).find("#ChkInsertar").attr("checked", true);
                //    }
                //    if ($('td', row).eq(7).text().trim() == '1') {
                //        $('td', row).eq(8).find("#ChkEditar").attr("checked", true);
                //    }
                //    if ($('td', row).eq(9).text().trim() == '1') {
                //        $('td', row).eq(10).find("#ChkEliminar").attr("checked", true);
                //    }
                //    if ($('td', row).eq(11).text().trim() == '1') {
                //        $('td', row).eq(12).find("#ChkImprimir").attr("checked", true);
                //    }
                //}

            });
            $('#kt_table_permisosperfiles').on('draw.dt', function () {
                if (ImprimirPermisos == '1') {
                    table.button(0).enable();
                    table.button(1).enable();
                    table.button(2).enable();
                    table.button(3).enable();
                }
            });

        },
        error: function (result) {
            alert(result);
        }
    });

}


function CambiaEstatus(PaginaId, Opcion, Permiso) {
    //alert(PaginaId,Opcion,Permiso)

    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var sentAjaxData = {
                "PaginaId": PaginaId,
                "PerfilId": $('#txtperfilid').val(),
                "Opcion": Opcion,
                "Permiso": Permiso
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/WS_PermisosPerfil.asmx/Update_PermisoPaginaPerfil",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {



                    swal.fire({
                        title: 'Desea heredar este cambio a todos los usuarios con este perfil?',
                        text: "Cambio de permisos",
                        type: 'warning',
                        showCancelButton: true,
                        cancelButtonText: 'No',
                        confirmButtonText: 'Si'
                    }).then(function (result) {
                        if (result.value) {
                            var sentAjaxData = {
                                "PaginaId": PaginaId,
                                "PerfilId": $('#txtperfilid').val(),
                                "Opcion": Opcion,
                                "Permiso": Permiso
                            };
                            var retval;
                            $.ajax({
                                type: "POST",
                                url: "../WebServices/WS_PermisosPerfil.asmx/HeredaPermiso",
                                dataType: "json",
                                contentType: "application/json",
                                data: JSON.stringify(sentAjaxData),
                                async: false,
                                success: function (data) {
                                },
                                error: function (request, status, error) {
                                    alert(request.responseText);
                                }
                            });
                        }
                        DibujarTablaPermisosPerfil($('#txtperfilid').val())
                        toastr.success('Permiso Modificado');
                        return false;
                    });

                    $.unblockUI();





                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
        }
    });
}