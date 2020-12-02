var Editar = '';
var Imprimir = '';
var Borrar = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 11);
    $("#txtUsuarioId").val(Desencriptar(Cookies.get('UsuarioId')));
    if (Datos[0]['Insertar'] == '0')
        $("#BtnNuevo").css('display', 'none');
    if (Datos[0]['Editar'] == '0') {
        $("#BtnGrabarUsuario").css('display', 'none');
    }
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    Borrar = Datos[0]['Eliminar'];
    
    GetDatosUsuario($("#txtUsuarioId").val());
    var a = GetFotoUsuario($('#txtUsuarioId').val());
    $("#profile-img-tag").attr({ src: "data:image/jpeg;base64," + a })
    $("#profile-img").change(function () {
        $.blockUI({
            message: '<h1><i class="fa fa-spinner fa-spin"></i></h1>',
            css: { color: '#fff', border: 'none', backgroundColor: 'none' }
        });
        readURL(this);
        $.unblockUI();
    });
}


function GetDatosUsuario(UsuarioId) {
    var sentAjaxData = {
        "Usuarioid": UsuarioId
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_PerfilUsuario.asmx/GetDatosUsuario",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            $("#txtNombre").val(data.d[0]['Nombre']);
            $('#txtApellido').val(data.d[0]['Apellido'])
            $('#txtPais').val(data.d[0]['Pais'])
            $('#txtSede').val(data.d[0]['Sede'])
            $('#txtTelefono').val(data.d[0]['Telefono'])
            $('#txtCorreo').val(data.d[0]['Correo'])
            $('#txtUsuario').val(data.d[0]['Usuario'])
            $('#txtPerfil').val(data.d[0]['Perfil'])
            $('#txtCorreoOriginal').val(data.d[0]['Correo'])
            $('#txtTelefonoOriginal').val(data.d[0]['Telefono'])

        }
    });
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        var bfile;
        var byteData;
        var fileName;
        var contentType;



        reader.onload = function (e) {

            var ext = input.files[0].name.split('.').pop().toLowerCase();
            if (ext != "jpg") {
                $.toast({
                    heading: 'Error',
                    text: 'Solo puede subir imagenes en formato jpg',
                    position: 'top-right',
                    stack: false,
                    icon: 'error',
                    showHideTransition: 'slide',
                    hideAfter: 3000
                })
            }
            else {
                var size = input.files[0].size;
                if (size > 5242880) {
                    $.toast({
                        heading: 'Error',
                        text: 'El Archivo no debe de exceder los 5MB',
                        position: 'top-right',
                        stack: false,
                        icon: 'error',
                        showHideTransition: 'slide',
                        hideAfter: 3000
                    })
                }
                else {
                    $('#profile-img-tag').attr('src', e.target.result);
                    bfile = e.target.result
                    //alert(bfile);   // this shows bfile
                    console.log(bfile)
                    byteData = bfile.split(';')[1].replace("base64,", "");
                    //alert(byteData);
                    fileName = input.files[0].name;
                    contentType = input.files[0].type;

                    var sentAjaxData = {
                        "UsuarioId": $('#txtUsuarioId').val(),
                        "Foto": byteData,
                        "fileName": fileName,
                        "ContentType": contentType
                    };
                    $.ajax({
                        type: "POST",
                        url: "../WebServices/WS_PerfilUsuario.asmx/UpdateFotoUsuario",
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

            }



        }
        reader.readAsDataURL(input.files[0]);
        fileName = input.files[0].name;
        contentType = input.files[0].type;
    }
}


function GrabarUsuario() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
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
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;
            }
            else {
                var sentAjaxData = {
                    "UsuarioId": $('#txtUsuarioId').val(),
                    "Telefono": $('#txtTelefono').val(),
                    "Correo": $('#txtCorreo').val()
                };
                var retval;
                $.ajax({
                    type: "POST",
                    url: "../WebServices/WS_PerfilUsuario.asmx/EditPerfilUsuario",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        $.unblockUI();
                        toastr.success('Usuario Modificado');
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

function GetFotoUsuario(UsuarioId) {
    var sentAjaxData = {
        "UsuarioId": UsuarioId
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_PerfilUsuario.asmx/GetFotoUsuario",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            retval = data.d;
            return false;
        }
    });
    return retval;
}