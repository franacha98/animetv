$(function () {
    $("#sidebarCollapse").on("click", function () {
        $("#sidebar, #content").toggleClass("active");
    });
});

$(function () {
    $("#pAnime").on("keydown", function (event) {
        Autocompletar($("#pAnime").val()+""+event.key);
    });
});

$(function () {
    $("#pAnime").on("blur", function (event) {
        MostrarImagen($("#pAnime").val());
    });
});

function MostrarImagen(id) {
    var url = "";
    for (var i = 0; i < listaAdmin.length; i++) {
        if (id == listaAdmin[i].mal_id) {
            url = listaAdmin[i].images.jpg.image_url;
        }
    }
    if (url == null || url == "") {
        url = "https://cdn.myanimelist.net/images/anime/7/76014.webp";
    }
    $('#imagenAnime').css("background-image", "url("+url+")");
}
var listaAdmin = [];
$('document').ready(function () {
    listaAdmin = [];
    Autocompletar("");
});
function Autocompletar(nombre) {
    if (nombre == "" || nombre.length >= 2) {
        var aux = window.location.href.toLowerCase();
        var peticion = aux.replace("videos", "PeticionAutocompletar");
        peticion = peticion.replace("borrarvideoindex", "PeticionAutocompletar");
        var dataPost = {
            pNombre: nombre
        };
        $.ajax({
            method: "POST",
            url: peticion,
            context: document.body,
            dataType: "json",
            data: dataPost,
            success: function (lista) {
                if (lista.length > 0) {
                    listaAdmin = lista;
                    $("#listaAnimes").html("");
                    for (var i = 0; i < lista.length; i++) {
                        $("#listaAnimes").append("<option value='" + lista[i].mal_id + "'>"+ lista[i].title +"</option>");
                    }
                }
            }
        }).done(function () {
        });
    }   
}