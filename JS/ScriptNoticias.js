$(function () {

    $("#btnCrearNoticia").click(function (e) {
        e.preventDefault();
        if ($("#TipoNoticia").val() == "0") {
            alert("Debe elegir un tipo de noticia");
        } else {
            var form = $("#frmNoticias").serialize();
            CrearNoticia(form);
        }
        
    });


    $(document).ready(function () {
        $('#Ruta').change(function (e) {
            var fileName = e.target.files[0].name;
            $("#TextoRuta").val(fileName);
        });
    });

    function CrearNoticia(datos) {
        $.ajax({
            url: "/Noticia/Crear",
            type: "POST",
            data: datos,
            success: function (resp) {
                if (resp.ok) {
                    Swal.fire({
                        title: '¡Se creó correctamente! ',
                        text: "¿Desea agregar un archivo?",
                        icon: 'success',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#96999C',
                        cancelButtonText: 'No',
                        confirmButtonText: 'Si'
                    }).then((result) => {
                        if (result.value) {
                            $("#IdNoticiaA").val(resp.idNoticia);
                            $("#modalArchivo").modal('show');
                        } else {
                            location.href = "/Noticia/Lista";
                        }
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'No se pudo guardar la noticia'
                    })
                }
            }
        });
    }
    if (($("#IdNoticia").length)!= 0) {
        $("#tipoImagen").removeClass("hidden");
        $("#tipoVideo").removeClass("hidden");
        $("#tipoImagen").hide();
        $("#tipoVideo").hide();
    }
    

    $("#Tipo").change(function () {
        if ($(this).val() == "") {
            $("#tipoImagen").hide(200);
            $("#tipoVideo").hide(200);
        } else if ($(this).val() == "0") {
            $("#tipoImagen").show(200);
            $("#tipoVideo").hide(200);
        } else if ($(this).val() == "1") {
            $("#tipoImagen").hide(200);
            $("#tipoVideo").show(200);
        }
    });

    $("#btnGuardarArchivo").click(function (e) {
        e.preventDefault();
        GuardarArchivo();
    });

    function GuardarArchivo() {
 
        var fileUpload = $("#Ruta").get(0);
        var files = fileUpload.files;

        if ($("#Tipo").val() == "") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Debe elegir un tipo de archivo'
            })
        } else if ($("#Tipo").val() == "0") {
            var fileData = new FormData();

            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }
            fileData.append("idNoticia", $("#IdNoticiaA").val());
            fileData.append("tipo", false);
            $.ajax({
                url: '/Archivo/Crear',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (resp) {
                    if (resp.ok) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Archivo agregado correctamente',
                            text: 'Se ha agregado el archivo correctamente a la noticia'
                        }).then((result) => {
                            if (result.value) {
                                location.href = "/Noticia/Lista"
                            }
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: resp.mensaje
                        })
                    }
                },
                error: function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: resp.mensaje
                    })
                }
            });
        } else if ($("#Tipo").val() == "1") {
            var datos = {
                idNoticia: $("#IdNoticiaA").val(),
                tipo: true,
                ruta: $("#TextoRutaVideo").val()
            }
            $.ajax({
                url: '/Archivo/Crear',
                type: "POST",
                data: datos,
                success: function (resp) {
                    if (resp.ok) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Archivo agregado correctamente',
                            text: 'Se ha agregado el archivo correctamente a la noticia'
                        }).then((result) => {
                            if (result.value) {
                                location.href = "/Noticia/Lista"
                            }
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: resp.mensaje
                        })
                    }
                },
                error: function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: resp.mensaje
                    })
                }
            });
        }

        
    }




    $("#btnEditarNoticia").click(function (e) {
        e.preventDefault();
        if ($("#TipoNoticia").val() == "0") {
            alert("Debe elegir un tipo de noticia");
        } else {
            var form = $("#frmNoticias").serialize();
            EditarNoticia(form);
        }

    });


    $(document).ready(function () {
        $('#Ruta').change(function (e) {
            var fileName = e.target.files[0].name;
            $("#TextoRuta").val(fileName);
        });
    });

    function EditarNoticia(datos) {
        $.ajax({
            url: "/Noticia/Actualizar",
            type: "POST",
            data: datos,
            success: function (resp) {
                if (resp.ok) {
                    Swal.fire({
                        title: '¡Se editó correctamente! ',
                        text: "¿Desea modificar el archivo de la noticia?",
                        icon: 'success',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#96999C',
                        cancelButtonText: 'No',
                        confirmButtonText: 'Si'
                    }).then((result) => {
                        if (result.value) {
                            $("#IdNoticiaA").val(resp.idNoticia);
                            $("#modalArchivo").modal('show');
                        } else {
                            location.href = "/Noticia/Lista";
                        }
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'No se pudo guardar la noticia'
                    })
                }
            }
        });
    }


    $("#btnEditarArchivo").click(function (e) {
        e.preventDefault();
        EditarArchivo();
    });

    function EditarArchivo() {

        var fileUpload = $("#Ruta").get(0);
        var files = fileUpload.files;

        if ($("#Tipo").val() == "") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Debe elegir un tipo de archivo'
            })
        } else if ($("#Tipo").val() == "0") {
            var fileData = new FormData();

            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }
            fileData.append("idArchivo", $("#IdArchivo").val());
            fileData.append("idNoticia", $("#IdNoticiaA").val());
            fileData.append("tipo", false);
            $.ajax({
                url: '/Archivo/Actualizar',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (resp) {
                    if (resp.ok) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Archivo agregado correctamente',
                            text: 'Se ha agregado el archivo correctamente a la noticia'
                        }).then((result) => {
                            if (result.value) {
                                location.href = "/Noticia/Lista"
                            }
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: resp.mensaje
                        })
                    }
                },
                error: function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: resp.mensaje
                    })
                }
            });
        } else if ($("#Tipo").val() == "1") {
            var datos = {
                idArchivo: $("#IdArchivo").val(),
                idNoticia: $("#IdNoticiaA").val(),
                tipo: true,
                ruta: $("#TextoRutaVideo").val()
            }
            $.ajax({
                url: '/Archivo/Actualizar',
                type: "POST",
                data: datos,
                success: function (resp) {
                    if (resp.ok) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Archivo agregado correctamente',
                            text: 'Se ha agregado el archivo correctamente a la noticia'
                        }).then((result) => {
                            if (result.value) {
                                location.href = "/Noticia/Lista"
                            }
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: resp.mensaje
                        })
                    }
                },
                error: function (err) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: resp.mensaje
                    })
                }
            });
        }
    }


    $(".btnRmvNoticia").click(function () {
        var id = $(this).val();

            Swal.fire({
                title: 'Confirmación del sistema ',
                text: "¿Desea eliminar la noticia? No podrá deshacer esta acción",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#96999C',
                cancelButtonText: 'No',
                confirmButtonText: 'Si, borrar'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        url: "/Noticia/Eliminar",
                        type: "POST",
                        data: { id },
                        success: function (resp) {
                            if (resp.ok) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Archivo borrado correctamente',
                                    text: 'El archivo se ha borrado del sistema'
                                }).then((result) => {
                                    if (result.value) {
                                        location.href = "/Noticia/Lista"
                                    }
                                });
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Error',
                                    text: 'No se pudo guardar la noticia'
                                })
                            }
                        }
                    });
            }
        });
    });

    $("#modalArchivo").on("hidden.bs.modal", function () {
        location.href = "/Noticia/Lista";
    });
});