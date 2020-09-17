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
                            Cookies.set('UsuarioId', Encriptar('1'));
                            //Cookies.set('NombreUsuario', Encriptar(data.d[0]['Nombre']));
                            window.location = "../WebForms/Wfrm_Inicio.aspx";
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