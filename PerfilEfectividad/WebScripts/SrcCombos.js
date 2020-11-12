function ComboAreas() {
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_Areas.asmx/GetListaAreas",
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

function ComboSubAreas(AreaId) {
    var sentAjaxData = {
        "AreaId": AreaId
    };
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_SubAreas.asmx/GetListaSubAreasArea",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $("#cboSubArea").get(0).options.length = 0;
            $("#cboSubArea").get(0).options[0] = new Option("Seleccione el sub área", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['SubareaId'];
                var name = data.d[i]['SubArea'];

                $("#cboSubArea").append("<option value='" + id + "'>" + name + "</option>");

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

function ComboEducacionFormal(factor) {
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
            $('#cboEducacionFormal').get(0).options.length = 0;
            $('#cboEducacionFormal').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#cboEducacionFormal').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboImpactoError(factor) {
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
            $('#CboImopactoError').get(0).options.length = 0;
            $('#CboImopactoError').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#CboImopactoError').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboExperiencia(factor) {
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
            $('#CboExperiencia').get(0).options.length = 0;
            $('#CboExperiencia').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['Id'];
                var name = data.d[i]['Texto'];

                $('#CboExperiencia').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboTipoSupervision() {
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_TipoSupervision.asmx/GetListaTipoSupervision",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboTipoSupervision').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['TipoSupervisionId'];
                var name = data.d[i]['TipoSupervision'];

                $('#cboTipoSupervision').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboFrecuencia() {
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Frecuencia.asmx/GetListaFrecuencia",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboFrecuencia').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['FrecuenciaId'];
                var name = data.d[i]['Frecuencia'];

                $('#cboFrecuencia').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboTipoRelacion() {
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_TipoRelacion.asmx/GetListaFrecuencia",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboTipoRelacion').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['TipoRelacionId'];
                var name = data.d[i]['TipoRelacion'];

                $('#cboTipoRelacion').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboGrados() {
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Grado.asmx/GetListaGrados",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboNivelEducacional').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['GradoId'];
                var name = data.d[i]['Grado'];

                $('#cboNivelEducacional').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboGradosCat() {
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Grado.asmx/GetListaGradosCombo",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboNivelEducacional').get(0).options.length = 0;
            //$('#cboTipoAmbienteTrabajo').get(0).options[0] = new Option("Seleccione el factor", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['GradoId'];
                var name = data.d[i]['Grado'];

                $('#cboNivelEducacional').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboCarrera(GradoId) {
    var sentAjaxData = {
        "GradoId": GradoId
    };

    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Carreras.asmx/GetListaCarreras",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(sentAjaxData),
        success: function (data) {
            $('#cboCarrera').get(0).options.length = 0;
            $('#cboCarrera').get(0).options[0] = new Option("Seleccione la carrera", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['CarreraId'];
                var name = data.d[i]['Carrera'];

                $('#cboCarrera').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboIdiomas() {
    $.ajax({
        type: "POST",
        url: "../WebServices/WS_Idioma.asmx/GetListaIdioma",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboIdioma').get(0).options.length = 0;
            $('#cboIdioma').get(0).options[0] = new Option("Seleccione el idioma", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['IdiomaId'];
                var name = data.d[i]['Idioma'];

                $('#cboIdioma').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}

function ComboDominioIdiomas() {
    $.ajax({
        type: "POST",
        url: "../WebServices/Ws_DominioIdioma.asmx/GetListaDominioIdioma",
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: JSON.stringify(),
        success: function (data) {
            $('#cboDominioIdioma').get(0).options.length = 0;
            $('#cboDominioIdioma').get(0).options[0] = new Option("Seleccione el dominio", "0");
            var len = data.d.length;

            for (var i = 0; i < len; i++) {
                var id = data.d[i]['DominioIdiomaId'];
                var name = data.d[i]['DominioIdioma'];

                $('#cboDominioIdioma').append("<option value='" + id + "'>" + name + "</option>");

            }
        },
        error: function (result) {
            alert(result);
        }
    });
}