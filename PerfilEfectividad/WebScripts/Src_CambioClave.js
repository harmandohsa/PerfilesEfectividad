function OpcionesInicioLocal() {

}

function GetClaveActual() {
    var sentAjaxData = {
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId'))
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
    return Clave;
}

function CambiaClave() {
    var Clave = GetClaveActual();
    $.blockUI({
        
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            
            var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
            var Error = true;
            if ($('#txtClave').val() == "") {
                CamposVacios = CamposVacios + 'Clave Actual' + "<br />";
                Error = false;
            }
            if ($('#txtClave').val() != "") {
                if ($('#txtClave').val() != Clave) {
                    CamposVacios = CamposVacios + 'Clave Anterior no coincide' + "<br />";
                    Error = false;
                }
            }
            if ($('#txtNuevaClave').val() == "") {
                CamposVacios = CamposVacios + 'Clave Nueva' + "<br />";
                Error = false;
            }
            if ($('#txtConfirmarClave').val() == "") {
                CamposVacios = CamposVacios + 'Confirmación Nueva Clave' + "<br />";
                Error = false;
            }
            if ($('#txtConfirmarClave').val() != $('#txtNuevaClave').val()) {
                CamposVacios = CamposVacios + 'Clave nueva no confirmada' + "<br />";
                Error = false;
            }
            if (Error == false) {
                toastr.error(CamposVacios);
                $.unblockUI();
                return Error;

            }
            else {
                var sentAjaxData = {
                    "UsuarioId": Desencriptar(Cookies.get('UsuarioId')),
                    "Clave": $('#txtNuevaClave').val(),
                    "CambiaClave": 0
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
    });
}