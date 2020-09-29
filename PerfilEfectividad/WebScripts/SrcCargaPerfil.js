function OpcionesInicioLocal() {
    $("#FileUpload").change(function () {
        $.blockUI({
            message: '<h1><i class="fa fa-spinner fa-spin"></i></h1>',
            css: { color: '#fff', border: 'none', backgroundColor: 'none' },
            baseZ: 2000
        });
        readURL(this);
        $.unblockUI();
    });
}

function readURL(input) {
    //alert(input.files[0]);
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        var bfile;
        var byteData;
        var fileName;
        var contentType;
        $("#DivErr").empty();

        reader.onload = function (e) {
            var SeccionA = $("#ChkSeccionA").is(":checked");
            var ext = input.files[0].name.split('.').pop().toLowerCase();
            var size = input.files[0].size;
            if (ext != 'xlsx') {
                toastr.error('Archivo no valido');
                $('#FileUpload').val('');
            }
            else if (size > 5242880) {
                toastr.error('Archivo no puede superar los 5MB');
                $('#FileUpload').val('');
            }
            else {
                //alert('vamos');
                bfile = e.target.result
                byteData = bfile.split(';')[1].replace("base64,", "");
                var sentAjaxData = {
                    "Archivo": byteData,
                    "Opcion": SeccionA
                };
                $.ajax({
                    type: "POST",
                    url: "../WebServices/WS_CargaPerfil.asmx/CaptureFile",
                    dataType: "json",
                    contentType: "application/json",
                    data: JSON.stringify(sentAjaxData),
                    async: false,
                    success: function (data) {
                        //alert(data.d);
                        if (data.d == "") {
                            toastr.success('Archivo Cargado');
                        }
                        else {
                            toastr.error('El Archivo tiene errores');
                            $('#DivErr').append(data.d);
                        }
                        $('#FileUpload').val('');
                    },
                    error: function (request, status, error) {
                        alert(request.responseText);
                    }
                });
            }
        }
        reader.readAsDataURL(input.files[0]);
        fileName = input.files[0].name;
        contentType = input.files[0].type;
    }
}