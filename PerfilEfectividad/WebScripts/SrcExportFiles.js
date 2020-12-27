var Editar = '';
var Imprimir = '';

function OpcionesInicioLocal() {
    Datos = GetPermisosUsuarioPagina(Desencriptar(Cookies.get('UsuarioId')), 15);
    if (Datos[0]['Imprimir'] == '0') {
        $("#BtnGenerar").css('display', 'none');
        $("#BtnGenerarAreas").css('display', 'none');
        $("#BtnGenerarPuestos").css('display', 'none');
    }
    Editar = Datos[0]['Editar'];
    Imprimir = Datos[0]['Imprimir'];
    Borrar = Datos[0]['Eliminar'];


    $("#cboArea").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtAreas").val($("#cboArea").val());
    });

    $("#cboPuesto").select2({
        width: '100%',
        placeholder: "",
        allowClear: true,
        modal: true,
        //dropdownParent: $("#modalNuevaPregunta")
    }).on("change", function () {
        $("#txtPuestos").val($("#cboPuesto").val());
    });

    //DibujarTabla();
    ComboAreas();
    ComboPuestos();
}

function PrintAreas() {
    var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
    var Error = true;
    if ($('#txtAreas').val() == "") {
        CamposVacios = CamposVacios + 'Debe seleccionar al menos un área' + "<br />";
        Error = false;
        toastr.error(CamposVacios);
    }
    else {
        PrintPerfil(2)
    }
}

function PrintPuestos() {
    var CamposVacios = "<b>" + "Campos Invalidos: " + "</b>" + "<br />";
    var Error = true;
    if ($('#txtPuestos').val() == "") {
        CamposVacios = CamposVacios + 'Debe seleccionar al menos un puesto' + "<br />";
        Error = false;
        toastr.error(CamposVacios);
    }
    else {
        PrintPerfil(3)
    }
}

function PrintPerfil(Opcion) {
    $.blockUI({
        message: 'Generando Perfiles',
        css: { border: 'none', padding: '15px', backgroundColor: '#000', '-webkit-border-radius': '10px', '-moz-border-radius': '10px', opacity: .5, color: '#fff' },
        onBlock: function () {
            var sentAjaxData = {
                "Opcion": Opcion,
                "UsuarioId": Desencriptar(Cookies.get('UsuarioId')),
                "Titulo": 'Perfil de Efectividad',
                "Areas": $('#txtAreas').val(),
                "Puestos": $('#txtPuestos').val()
            };
            var retval;
            $.ajax({
                type: "POST",
                url: "../WebServices/WS_ExportPerfil.asmx/SavePerfil",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(sentAjaxData),
                async: false,
                success: function (data) {
                    retval = data.d;
                    $.unblockUI();
                    toastr.success('Perfiles Generados');

                    var bytes = new Uint8Array(data.d[0]['Archivo']);
                    var blob = new Blob([bytes], { type: data.d[0]['ContentType'] });
                    var link = document.createElement('a');
                    link.href = window.URL.createObjectURL(blob);
                    var fileName = data.d[0]['NombreArchivo'];
                    link.download = fileName;
                    link.click();




                    //var bytes = new Uint8Array(data.d[0]['Archivo']); // pass your byte response to this constructor
                    //var blob = new Blob([bytes], { type: data.d[0]['ContentType'] });// change resultByte to bytes
                    //window.open(window.URL.createObjectURL(blob))
                    return false;
                },
                error: function (request, status, error) {
                    alert(request.responseText);
                }
            });
            return retval;
            $.unblockUI();
        }
    });
    
}