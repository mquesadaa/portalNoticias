function AgregarComentario() {

    var texto = document.getElementById("Comentario").value;
    var idNoticia = document.getElementById("Noticia").value;

    if (texto != null && texto.length > 0)
    {
        $.ajax({

            url: "/Comentarios/SaveDetailedInfo",
            type: "POST",
            data: JSON.stringify({
                txt: texto,
                id: idNoticia
            }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data)
            {
                if (data.status == "Success")
                {
                    document.getElementById("Comentario").value = "";
                    alert(data.message);
                    location.reload();
                } else
                {
                  
                   
                    //location.reload();
                    $("#_Comentarios").html(objOperations);
                    alert(data.message);
                }
            },
            error: function ()
            {
                alert("Para poder agregar comentarios debe estar registrado y ser usuario de sitema");
            }
        });
    } else
        {
            alert("Debe de agregar al menos una palabra")
        }
    
}