var Editar = '';
var Imprimir = '';
var Borrar = '';
var ConsultarPermisos = ''
var EditarPermisos = ''
var ImprimirPermisos = ''

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 3);
    if (Datos[0]['Insertar'] == '0')
        $("#BtnNuevo").css('display', 'none');
    if (Datos[0]['Editar'] == '0') {
        $("#BtnGrabarUsuario").css('display', 'none');
    }
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    //Borrar = 0;
    Borrar = Datos[0]['Eliminar'];

    DatosPermisos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 4);
    ConsultarPermisos = DatosPermisos[0]['Consultar'];
    EditarPermisos = DatosPermisos[0]['Editar'];
    ImprimirPermisos = DatosPermisos[0]['Imprimir'];

    DibujarTablaUsuarios();

    

    $("#cboPerfil").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        dropdownParent: $("#modalNuevaUsuario")
    }).on("change", function () {
        $("#txtPerfilId").val($("#cboPerfil").val());
    });

    $("#cboPais").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        dropdownParent: $("#modalNuevaUsuario")
    }).on("change", function () {
        $("#txtPaisId").val($("#cboPais").val());
        ComboSedes($("#txtPaisId").val());
    });

    $("#cboSede").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        dropdownParent: $("#modalNuevaUsuario")
    }).on("change", function () {
        $("#txtSedeId").val($("#cboSede").val());
    });


    ComboPerfiles();
    ComboPais();
}

function DibujarTablaUsuarios() {

    $('#kt_table_Usuarios').DataTable().destroy();
    $('#kt_table_Usuarios').empty();

    $.ajax({
        type: 'POST',
        data: JSON.stringify(),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_Usuarios.asmx/GetListaUsuarios",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_Usuarios").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Foto",
                        "render": function (data, type, row) {
                            return '<img width="35px" height="35px" alt="Pic" src="WebForms/Wfrm_FotoUsuarioCat.aspx?UsuarioId=' + row['UsuarioId'] + '" />'
                        },
                        "width": "5%"
                    },
                    {
                        "title": "Nombre",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal" onclick="ModificarUsuario(' + row['UsuarioId'] + ',\'' + row['Nombre'] + '\',\'' + row['Apellido'] + '\',\'' + row['PaisId'] + '\', ' + row['SedeId'] + ', \'' + row['Telefono'] + '\',\'' + row['Correo'] + '\', \'' + row['Usuario'] + '\',' + row['PerfilId'] + ')" data-target="#modalNuevaUsuario" href="">' + row['Nombres'] + '</a>'
                        },
                        "width": "25%"
                    },
                    {
                        "title": "Sede",
                        "data": "Sede",
                        "width": "25%"
                    },
                    {
                        "title": "Telefono",
                        "data": "Telefono",
                        "width": "25%"
                    },
                    {
                        "title": "Correo",
                        "data": "Correo",
                        "width": "25%"
                    },
                    {
                        "title": "Usuario",
                        "data": "Usuario",
                        "width": "25%"
                    },
                    {
                        "title": "Estatus",
                        "data": "EstatusUsuario",
                        "width": "25%"
                    },
                    {
                        "title": "Perfil",
                        "data": "Perfil",
                        "width": "25%"
                    },
                    {
                        "title": "Permisos",
                        "data": "PerfilId",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal"  href=""  onclick="CargaPermisos(' + row['UsuarioId'] + ',\'' + row['Nombre'] + '\',\'' + row['Apellido'] + '\')"><i class="fa fa-eye"></i></a>';

                        }
                    },
                    {
                        "title": "Cantidad Ingresos",
                        "data": "CntIngresos",
                        "width": "25%"
                    },
                    {
                        "title": "Enviar Correo",
                        "data": "UsuarioId",
                        "render": function (data, type, row) {
                            var Nombres = row['Nombre'] + ' ' + row['Apellido'];
                            return '<a data-toggle="modal"  href=""  onclick="EnviarNotificacion(' + row['UsuarioId'] + ',\'' + Nombres + '\')"><i class="fa fa-mail-bulk"></i></a>';

                        }
                    },
                    {
                        "title": "Resetar Clave",
                        "data": "UsuarioId",
                        "render": function (data, type, row) {
                            return '<a data-toggle="modal"  href=""  onclick="ResetClave(' + row['UsuarioId'] + ')"><i class="fa fa-lock"></i></a>';

                        }
                    },
                    {
                        "title": "Cambiar Estatus",
                        "data": "UsuarioId",
                        "render": function (data, type, row) {
                            var Estatus = row['EstatusUsuarioId']
                            if (Estatus == 1)
                                Estatus = 2;
                            else
                                Estatus = 1;
                            return '<a data-toggle="modal"  href=""  onclick="CambiarEstatus(' + row['UsuarioId'] + ',' + Estatus + ')"><i class="fa fa-exchange-alt"></i></a>';

                        }
                    },
                ],
                oLanguage: {

                    "sUrl": "../DataTable-ES.txt"
                },
                buttons: [
                    {
                        extend: 'print',
                        title: 'Listado de Usuarios',
                        text: 'Imprimir',
                        enabled: false,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 8] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Listado de Usuarios',
                        enabled: false,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 8] }
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Listado de Usuarios',
                        download: 'open',
                        enabled: false,
                        orientation: 'landscape',
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 8] },
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
                        columns: [0, 1, 2, 3, 4, 5, 6, 8]
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
            $('#kt_table_Usuarios').on('draw.dt', function () {
                if (Imprimir == '1') {
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

//function HabilitarBotonos() {
//    var table = $("#kt_table_Usuarios").DataTable({
//        table.button(0).enable();
//        table.button(1).enable();
//        table.button(2).enable();
//        table.button(3).enable();
//    });
//}

function NuevoUsuario() {
    $('#txtllamada').val('');
    $('#txtNombre').val('');
    $('#txtApellido').val('');
    $('#txtTelefono').val('');
    $('#txtCorreo').val('');
    $('#txtUsuario').val('');
    $('#txtPaisId').val('');
    $('#txtPerfilId').val('');
    $('#txtSedeId').val('');
    $('#cboPais').val('');
    $('#cboSede').val('');
    $('#cboPerfil').val('');
    ComboPais();
    ComboPerfiles();
}

function GrabarUsuario() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtNombre').val() == "") {
                CamposVacios = CamposVacios + 'Nombres' + "<br />";
                Error = false;
            }
            if ($('#txtApellido').val() == "") {
                CamposVacios = CamposVacios + 'Apellidos' + "<br />";
                Error = false;
            }
            if ($('#cboPais').val() == "") {
                CamposVacios = CamposVacios + 'País' + "<br />";
                Error = false;
            }
            if ($('#cboSede').val() == "") {
                CamposVacios = CamposVacios + 'Sede' + "<br />";
                Error = false;
            }
            if ($('#txtTelefono').val() == "") {
                CamposVacios = CamposVacios + 'Teléfono' + "<br />";
                Error = false;
            }
            if ($('#txtTelefono').val() != $('#txtTelefonoOriginal').val()) {
                if ($('#txtTelefono').val() != "") {
                    var HayDato = ExisteTelefono($("#txtTelefono").val());
                    if (HayDato > 0) {
                        CamposVacios = CamposVacios + 'Teléfono ya existe' + "<br />";
                        Error = false;
                    }
                }
            }


            if ($('#txtCorreo').val() == "") {
                CamposVacios = CamposVacios + 'Correo' + "<br />";
                Error = false;
            }
            if ($('#txtCorreo').val() != $('#txtCorreoOriginal').val()) {
                if ($('#txtCorreo').val() != "") {
                    if (validateEmail($('#txtCorreo').val()) == false) {
                        CamposVacios = CamposVacios + 'Correo Invalido' + "<br />";
                        Error = false;
                    }
                    else {
                        var HayDato = ExisteCorreo($("#txtCorreo").val());
                        if (HayDato > 0) {
                            CamposVacios = CamposVacios + 'Correo electrónico ya existe' + "<br />";
                            Error = false;
                        }
                    }
                }
            }
            if ($('#txtUsuario').val() == "") {
                CamposVacios = CamposVacios + 'Usuario' + "<br />";
                Error = false;
            }
            if ($('#txtUsuario').val() != $('#txtUsuarioOriginal').val()) {
                if ($('#txtUsuario').val() != "") {
                    var HayDato = ExisteUsuario($("#txtUsuario").val());
                    if (HayDato > 0) {
                        CamposVacios = CamposVacios + 'Usuario ya existe' + "<br />";
                        Error = false;
                    }
                }
            }

            if ($('#cboPerfil').val() == "") {
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
                    var CambiaPermiso = 0;
                    if ($('#txtPerfilId').val() != $('#txtPerfilIdOriginal').val())
                        CambiaPermiso = 1;
                    var sentAjaxData = {
                        "UsuarioId": $('#txtUsuarioId').val(),
                        "Nombres": $('#txtNombre').val(),
                        "Apellidos": $('#txtApellido').val(),
                        "Correo": $('#txtCorreo').val(),
                        "Usuario": $('#txtUsuario').val(),
                        "PerfilId": $('#txtPerfilId').val(),
                        "SedeId": $('#txtSedeId').val(),
                        "Telefono": $('#txtTelefono').val(),
                        "CambiaPermisos": CambiaPermiso,
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Usuarios.asmx/EditUsuario",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTablaUsuarios()
                            $.unblockUI();
                            $('#modalNuevaUsuario').modal('hide');
                            toastr.success('Usuario Modificado');
                            NuevoUsuario();
                            return false;
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }
                    });
                }
                else {
                    var sentAjaxData = {
                        "Nombres": $('#txtNombre').val(),
                        "Apellidos": $('#txtApellido').val(),
                        "Correo": $('#txtCorreo').val(),
                        "Usuario": $('#txtUsuario').val(),
                        "PerfilId": $('#txtPerfilId').val(),
                        "SedeId": $('#txtSedeId').val(),
                        "Telefono": $('#txtTelefono').val(),
                        "UsuarioId": Desencriptar(Cookies.get('UsuarioId')),
                    };
                    var retval;
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_Usuarios.asmx/InsertUsuario",
                        dataType: "json",
                        contentType: "application/json",
                        data: JSON.stringify(sentAjaxData),
                        async: false,
                        success: function (data) {
                            DibujarTablaUsuarios()
                            $.unblockUI();
                            $('#modalNuevaUsuario').modal('hide');
                            toastr.success('Usuario Grabado');
                            NuevoUsuario();
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

function ExisteCorreo(Correo) {
    var sentAjaxData = {
        "Correo": Correo
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Usuarios.asmx/ExisteCorreo",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        },
        error: function (data) {
            retval = data.d;
            return false;
        }
    });
    return retval;
}



function ExisteTelefono(Telefono) {
    var sentAjaxData = {
        "Telefono": Telefono
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Usuarios.asmx/ExisteTelefono",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        },
        error: function (data) {
            retval = data.d;
            return false;
        }
    });
    return retval;
}

function ExisteUsuario(Usuario) {
    var sentAjaxData = {
        "Usuario": Usuario
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Usuarios.asmx/ExisteUsuario",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        },
        error: function (data) {
            retval = data.d;
            return false;
        }
    });
    return retval;
}

function ModificarUsuario(UsuarioId, Nombres, Apellidos, PaisId, SedeId, Telefono, Correo, Usuario, PerfilId) {
    ComboPerfiles();
    ComboPais();
    ComboSedes(PaisId);
    $('#txtUsuarioId').val(UsuarioId);
    $('#txtNombre').val(Nombres);
    $('#txtApellido').val(Apellidos);
    $('#cboPais').val(PaisId);
    $('#txtPaisId').val(PaisId);
    $('#txtSedeId').val(SedeId);
    $('#cboSede').val(SedeId);
    $('#txtTelefono').val(Telefono);
    $('#txtTelefonoOriginal').val(Telefono);
    $('#txtCorreo').val(Correo);
    $('#txtCorreoOriginal').val(Correo);
    $('#txtUsuario').val(Usuario);
    $('#txtUsuarioOriginal').val(Usuario);
    $('#cboPerfil').val(PerfilId);
    $('#txtPerfilId').val(PerfilId);
    $('#txtPerfilIdOriginal').val(PerfilId);
    $('#txtllamada').val('2');
    
}

function CargaPermisos(UsuarioId, Nombre, Apellido) {
    if (ConsultarPermisos == 0) {
        toastr.error('No tiene permisos para ingresar a esta opción');
    }
    else {
        $('#modalPermisosUsuario').modal('show');
        $('#lblTituloPermisos').text('Permisos del Usuario: ' + Nombre + ' ' + Apellido);
        DibujarTablaPermisosUsuario(UsuarioId);
        $('#txtUsuarioId').val(UsuarioId);
    }
}

function DibujarTablaPermisosUsuario(UsuarioId) {

    $('#kt_table_permisosUsuarios').DataTable().destroy();
    $('#kt_table_permisosUsuarios').empty();



    var sentAjaxData = {
        "UsuarioId": UsuarioId
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(sentAjaxData),
        contentType: "application/json; charset=utf-8",
        url: "../WebServices/WS_PermisosUsuario.asmx/kt_table_permisosUsuarios",
        datatype: 'json',
        success: function (data) {
            var cantidad = data.d.length

            var table = $("#kt_table_permisosUsuarios").DataTable({
                data: data.d,
                columns: [
                    {
                        "title": "Modulo",
                        "data": "Modulo",
                        "width": "30%"
                    },
                    {
                        "title": "Pagina",
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
                        title: 'Listado de Permisos Usuario',
                        text: 'Imprimir',
                        enabled: false,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6] }
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Listado de Permisos Usuario',
                        enabled: false,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6] },
                    },
                    {
                        extend: 'pdfHtml5',
                        title: 'Listado de Permisos Usuario',
                        download: 'open',
                        enabled: false,
                        exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6] },
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
                        columns: [0, 1, 2, 3, 4, 5, 6]
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
            });
            $('#kt_table_permisosUsuarios').on('draw.dt', function () {
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
                "UsuarioId": $('#txtUsuarioId').val(),
                "Opcion": Opcion,
                "Permiso": Permiso
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/WS_PermisosUsuario.asmx/Update_PermisoPaginaUsuario",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    DibujarTablaPermisosUsuario($('#txtUsuarioId').val())
                    $.unblockUI();
                    toastr.success('Permiso Modificado');
                    return false;
                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
        }
    });
}

function EnviarNotificacion(UsuarioId, Nombre) {
    var Usuario, Clave, Correo;

    var sentAjaxData = {
        "UsuarioId": UsuarioId
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Login.asmx/GetDatosUsuarioById",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            Usuario = data.d[0]['Usuario'];
            Correo = data.d[0]['Correo'];
            Clave = Desencriptar(data.d[0]['Clave']);
            return false;
        }
    });
    //alert(Usuario);
    //alert(Correo);
    //alert(Clave);
    var Mensaje = "<div class=container-fluid><div class=col-md-12><div class=form-group><label>Nos Complace informarle que se ha creado un usuario y clave para el sistema de perfiles de puesto , acontinuación sus credenciales</label></div></div><div class=col-md-6><div class=form-group><label>Usuario: " + Usuario + "</label></div></div><div class=col-md-6><div class=form-group><label>Clave: " + Clave + "</label></div></div></div>"
    var sentAjaxData = {
        "Mail": Correo,
        "Nombre": Nombre,
        "Asunto": "Creación de Usuario y Clave",
        "Mensaje": Mensaje,
        "ConAdjunto": 0,
        "RutaAdjunto": '',
        "NombreArchivo": ''
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Generales.asmx/EnvioCorreo",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            toastr.success('Correo enviado');
            return false;
        }
    });


}

function ResetClave(UsuarioId) {
    if (Editar == 0) {
        toastr.success('No tine permiso para esta opción');
    }
    else {
        var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }

        //alert(randomstring);
        var sentAjaxData = {
            "UsuarioId": UsuarioId,
            "Clave": randomstring,
            "CambiaClave": 1
        };
        var retval;
        $.ajax({
            type: "POST",
            url: "../WebServices/WS_Usuarios.asmx/EditClave",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(sentAjaxData),
            async: false,
            success: function (data) {
                $.unblockUI();
                toastr.success('Clave Modificada');
                return false;
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    }

    
}


function CambiarEstatus(UsuarioId, Estatus) {
    if (Editar == 0) {
        toastr.success('No tine permiso para esta opción');
    }
    else {
        var sentAjaxData = {
            "UsuarioId": UsuarioId,
            "Estatus": Estatus
        };
        var retval;
        $.ajax({
            type: "POST",
            url: "../WebServices/WS_Usuarios.asmx/EditEstatus",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(sentAjaxData),
            async: false,
            success: function (data) {
                $.unblockUI();
                toastr.success('Estatus Modificado');
                DibujarTablaUsuarios();
                return false;
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    }


}