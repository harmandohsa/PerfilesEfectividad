function ComboAreas() {
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Areas.asmx/GetListaPuestos",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $("#cboArea").get(0).options.length = 0;
            $("#cboArea").get(0).options[0] = new Option("Seleccione el área", "-1");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['AreaId'];
                var name = data.d[i]['Area'];

                $("#cboArea").append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}


function ComboFactorTomaDescion(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboTomaDesicion').get(0).options.length = 0;
            $('#cboTomaDesicion').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboTomaDesicion').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboFactorEsfuerzoMental(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboEsfuerzoMental').get(0).options.length = 0;
            $('#cboEsfuerzoMental').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboEsfuerzoMental').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboFactorRelacionInterna(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboRelacionInterna').get(0).options.length = 0;
            $('#cboRelacionInterna').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboRelacionInterna').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboFactorRelacionExterna(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboRelacionExterna').get(0).options.length = 0;
            $('#cboRelacionExterna').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboRelacionExterna').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}


function ComboFactorManejoBienes(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboManejoBienes').get(0).options.length = 0;
            $('#cboManejoBienes').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboManejoBienes').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboFactorSupervisiones(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboSupervion').get(0).options.length = 0;
            $('#cboSupervion').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboSupervion').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboManejoInformacion(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboManejoInformacion').get(0).options.length = 0;
            $('#cboManejoInformacion').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboManejoInformacion').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboTipoAmbienteTrabajo() {
    

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_TipoAmbienteTrabajo.asmx/GetTipoAmbienteTrabajo",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            //$('#cboTipoAmbienteTrabajo').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['TipoAmbienteTrabajoId'];
                var name = data.d[i]['TipoAmbienteTrabajo'];

                $('#cboTipoAmbienteTrabajo').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboAmbienteTrabajo(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboAmbienteTrabajo').get(0).options.length = 0;
            $('#cboAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboAmbienteTrabajo').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboTipoRiesgoOcupacional() {


    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_TipoRiesgoOcupacional.asmx/GetTipoRiesgoOcupacional",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            //$('#cboTipoAmbienteTrabajo').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['TipoRiesgoOcupacionalId'];
                var name = data.d[i]['TipoRiesgoOcupacional'];

                $('#cboTipoRiesgoOcupacional').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboRiesgoOcupacional(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboRiesgoOcupacional').get(0).options.length = 0;
            $('#cboRiesgoOcupacional').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboRiesgoOcupacional').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboTipoEsfuerzoFisico() {


    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_TipoEsfuerzoFisico.asmx/GetTipoEsfuerzoFisico",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            //$('#cboTipoAmbienteTrabajo').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['TipoEsfuerzoFisicoId'];
                var name = data.d[i]['EsfuerzoFisico'];

                $('#cboTipoEsfuerzoFisico').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboEsfuerzoFisico(factor) {
    var sentAjaxData = {
        "FactorId": factor
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Factor.asmx/GetListaFactor",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboEsfuerzoFisico').get(0).options.length = 0;
            $('#cboEsfuerzoFisico').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboEsfuerzoFisico').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}