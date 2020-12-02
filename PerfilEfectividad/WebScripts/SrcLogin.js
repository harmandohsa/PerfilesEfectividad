function OpcionesInicioLocal() {
    
}

function login() {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#TxtUsuario').val() == "") {
                CamposVacios = CamposVacios + 'Usuario' + "<br />";
                Error = false;
            }
            if ($('#TxtClave').val() == "") {
                CamposVacios = CamposVacios + 'Clave' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {

                var sentAjaxData = {
                    "Usuario": $('#TxtUsuario').val(),
                    "Clave": Encriptar($('#TxtClave').val())
                };

                $.ajax({
                    type: "POST",
                    url: "../WebServices/Ws_Login.asmx/ExisteUsuarioClave",
                    dataType: "json",
                    contentType: "application/json",
                    async: false,
                    data: JSON.stringify(sentAjaxData),
                    success: function (data) {
                        //var len = data.d.length;
                        //alert(data.d);
                        if (data.d == 0) {
                            toastr.error('Usuario o Clave Invalidas');
                            $.unblockUI();
                        }
                        else {
                            GetDatosUsuario($('#TxtUsuario').val());
                            GrabaBitacoraIngreso($('#TxtUsuario').val());
                            if (Desencriptar(Cookies.get('EstatusUsuario')) == 0) {
                                toastr.error('Su usuario esta inactivo');
                            }
                            else {
                                if (Desencriptar(Cookies.get('CambiaClave')) == 0)
                                    window.location = "../WebForms/Wfrm_Inicio.aspx";
                                else
                                    window.location = "../WebForms/Wfrm_CambioClave.aspx";
                            }
                            
                        }

                            
                    },
                    error: function (result) {
                        alert(result);
                    }
                });


                $.unblockUI();
            }

        }
    });
}

function GetDatosUsuario(Usuario) {
    var sentAjaxData = {
        "Usuario": Usuario
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Login.asmx/GetDatosUsuario",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            Cookies.set('UsuarioId', Encriptar(data.d[0]['UsuarioId']));
            Cookies.set('NombreUsuario', Encriptar(data.d[0]['Nombre']));
            Cookies.set('CambiaClave', Encriptar(data.d[0]['CambiaClave']));
            Cookies.set('EstatusUsuario', Encriptar(data.d[0]['EstatusUsuario']));
            return false;
        }
    });
}

function GrabaBitacoraIngreso(Usuario) {
    var sentAjaxData = {
        "Usuario": Usuario
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Login.asmx/GrabaBitacoraIngreso",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            Cookies.set('IngresoId', Encriptar(data.d));
            return false;
        }
    });
}

function Recuperar() {
    var Existe = 0;
    var sentAjaxData = {
        "Usuario": $('#txtUsuarioRecup').val()
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Usuarios.asmx/ExisteUsuario",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            Existe = data.d;
            return false;
        }
    });

    if (Existe == 1) {
        var Correo, Nombre, UsuarioId
        var sentAjaxData = {
            "Usuario": $('#txtUsuarioRecup').val()
        };
        $.ajax({
            type: "POST",
            url: "../WebServices/WS_Login.asmx/GetDatosUsuario",
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(sentAjaxData),
            async: false,
            success: function (data) {
                UsuarioId = data.d[0]['UsuarioId'];
                Correo = data.d[0]['Correo'];
                Nombre = data.d[0]['Nombre'];
                return false;
            }
        });

        var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var string_length = 8;
        var randomstring = '';
        for (var i = 0; i < string_length; i++) {
            var rnum = Math.floor(Math.random() * chars.length);
            randomstring += chars.substring(rnum, rnum + 1);
        }

        
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

            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });

        var Mensaje = "<div class=container-fluid><div class=col-md-12><div class=form-group><label>Se ha reinicializado su usuario y clave para el sistema de perfiles de puesto, acontinuación sus credenciales</label></div></div><div class=col-md-6><div class=form-group><label>Usuario: " + $('#txtUsuarioRecup').val() + "</label></div></div><div class=col-md-6><div class=form-group><label>Clave: " + randomstring + "</label></div></div></div>"
        var sentAjaxData = {
            "Mail": Correo,
            "Nombre": Nombre,
            "Asunto": "Reinicialización de Usuario y Clave",
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
                
                return false;
            }
        });



    }
    toastr.success('Si su usuario fue encontrado en nuestros registros recibira un correo electrónico con la información para ingresar al sistema');
    $('#modalDatos').modal('hide');
    $('#txtUsuarioRecup').val('')
    //$.blockUI({
    //    message: 'Cargando Datos',
    //    css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
    //    onBlock: function () {
            
    //    }
    //});


    //$.unblockUI();



    
}