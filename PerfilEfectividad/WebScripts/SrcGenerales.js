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
            //GetPermisosUsuario();
            //$('#lblNomUsrA').text(Desencriptar(Cookies.get('NombreUsuario')));
            //$('#lblNomUsrB').text(Desencriptar(Cookies.get('NombreUsuario')));
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