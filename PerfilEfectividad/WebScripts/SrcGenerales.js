window.addEventListener('load', function () {
    $.blockUI({
        message: 'Cargando Datos',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            OpcionesInicio();
            OpcionesInicioLocal();
        }
    });


}, false);

function OpcionesInicio() {
    var Pagina = location.pathname.substring(1);
    //alert(Pagina);
    if (Pagina == 'Wfrm_Login') {
        //alert('Nada');


    }
    else if (Pagina == 'Wfrm_Login.aspx') {
        //alert('Nada');
    }
    else {
        if (Cookies.get('UsuarioId') == null) {
            window.location = "../Wfrm_Login.aspx";
        }
        else {
            GetPermisosUsuario();
            $('#lblNomUsrA').text(Desencriptar(Cookies.get('NombreUsuario')));
            $('#lblNomUsrB').text(Desencriptar(Cookies.get('NombreUsuario')));
        }
    }
    $.unblockUI();
}

function Encriptar(Clave) {
    var sentAjaxData = {
        "clearText": Clave
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Generales.asmx/Encrypt",
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

function Desencriptar(Clave) {
    var ClaveDes = "";
    if (typeof Clave === 'undefined') {

    }
    else {
        ClaveDes = Clave;
    }
    //alert(ClaveDes)
    var sentAjaxData = {
        "cipherText": ClaveDes
    };
    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Generales.asmx/Decrypt",
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

function GetPermisosUsuarioPagina(UsuarioId, PaginaId) {
    var sentAjaxData = {
        "UsuarioId": UsuarioId,
        "PaginaId": PaginaId,
    };
    var Datos;
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Generales.asmx/GetPermisosUsuarioPagina",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            Datos = data.d;
        },
        error: function (result) {
            alert(result);
        }
    });
    return Datos;
}

function validateEmail(email) {
    // First check if any value was actually set
    if (email.length == 0) return false;
    // Now validate the email format using Regex
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/i;
    return re.test(email);
}

function GetPermisosUsuario() {
    var sentAjaxData = {
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId')),
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Generales.asmx/GetPermisosUsuario",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                switch (data.d[i]['PaginaId']) {
                    case 1:
                        $('#MnuAreas').show();
                        break;
                    case 2:
                        $('#MnuSubAreas').show();
                        break;
                    case 3:
                        $('#MnuIdioma').show();
                        break;
                    case 4:
                        $('#MnuCarreas').show();
                        break;
                    case 5:
                        $('#MnuPuestos').show();
                    case 6:
                        $('#MnuCargaFile').show();
                        break;
                    case 7:
                        $('#MnuPerfil').show();
                        break;
                    case 8:
                        $('#MnuUsuario').show();
                        break;
                    case 9:
                        $('#MnuPais').show();
                        break;
                    case 10:
                        $('#MnuSedes').show();
                        break;
                    case 12:
                        $('#MnuActPuestos').show();
                        break;
                    default:
                        break
                }
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function Salir() {
    GrabaBitacoraSalida();
    Cookies.remove('UsuarioId');
    Cookies.remove('NombreUsuario');
    Cookies.remove('IngresoId');
    window.location = "../Wfrm_Login.aspx";
}

function GrabaBitacoraSalida() {
    var sentAjaxData = {
        "UsuarioId": Desencriptar(Cookies.get('UsuarioId')),
        "IngresoId": Desencriptar(Cookies.get('IngresoId')),
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Login.asmx/GrabaBitacoraSalida",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            return false;
        }
    });
}

function IrInicio() {
    window.location = "../WebForms/Wfrm_Inicio.aspx"
}

function GrabaBitacoraActividad(ActividadId, PuestoId, UsuarioId) {
    var sentAjaxData = {
        "ActividadId": ActividadId,
        "PuestoId": PuestoId,
        "UsuarioId": UsuarioId
        
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Generales.asmx/InsertBitacoraActividad",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            return false;
        }
    });
}