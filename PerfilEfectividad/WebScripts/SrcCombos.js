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

function ComboFactor(factor,combo,id,text) {
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
            $(combo).get(0).options.length = 0;
            $(combo).get(0).options[0] = new Option("Seleccione el factor", "-1");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i][id];
                var name = data.d[i][text];

                $(combo).append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}