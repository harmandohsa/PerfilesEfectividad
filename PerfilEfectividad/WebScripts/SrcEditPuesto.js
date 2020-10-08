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
    //DibujarTablaDepartamento();
    const urlParams = new URLSearchParams(window.location.search);
    $('#lblPuesto').text(urlParams.get('Puesto'));
    $('#txtPuestoId').val(urlParams.get('PuestoId'));

    $("#cboArea").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtAreaId").val($("#cboArea").val());
    });

    $("#cboTomaDesicion").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtTomaDecisionId").val($("#cboTomaDesicion").val());
    });

    $("#cboEsfuerzoMental").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtEsfuerzoMentalId").val($("#cboEsfuerzoMental").val());
    });

    ComboAreas();
    ComboFactor(1, '#cboTomaDesicion', 'Id', 'Texto');
    ComboFactor(2, '#cboEsfuerzoMental', 'Id', 'Texto');
    GetDataGeneral(urlParams.get('PuestoId'));
    GetDataFunciones(urlParams.get('PuestoId'));
}

function GetDataGeneral(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataGeneral",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            console.log(data.d)
            $('#txtpuestojefe').val(data.d[0]['PuestoSuperior'])
            $('#txtAreaId').val(data.d[0]['AreaId'])
            $('#cboArea').val(data.d[0]['AreaId'])
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

function GetDataFunciones(PuestoId) {
    var sentAjaxData = {
        "PuestoId": PuestoId
    };

    var retval;
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_CrudPerfil.asmx/GetDataFunciones",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(sentAjaxData),
        async: false,
        success: function (data) {
            console.log(data.d)
            $('#txtfuncprincipal').val(data.d[0]['FuncionPrincipal'])
            $('#txtfuncprincipales').val(data.d[0]['Principales'])
            $('#txtfuncdiarias').val(data.d[0]['FuncionDiaria'])
            $('#txtfuncsemquin').val(data.d[0]['FuncionSemanalQuincenal'])
            $('#txtfuncmensual').val(data.d[0]['FuncionMensual'])
            $('#txtfunctrimsem').val(data.d[0]['FuncionTrimestralSemestral'])
            $('#txtfuncanual').val(data.d[0]['FuncionAnual'])
            $('#txtfunceventual').val(data.d[0]['FuncionEventual'])
            return false;
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}