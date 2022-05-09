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

$(".col-sm-3").click(function (event) {
    var sinopsis = event.currentTarget.children[0].children[0].value;
    if (sinopsis == "" || sinopsis == undefined || sinopsis == null) {
        sinopsis = "Todavía no hay una sinopsis para este Anime.";
    }
    var titulo = event.currentTarget.children[0].children[2].children[0].textContent;
    $('.modal-body').text(sinopsis);
    $("#exampleModalLongTitle").text(titulo);
    $('#modalSinopsis').modal({ show: true });
});

$(function () {
    $("#filtro-estado").on("change", function (event) {
        FiltrarListado(event);
    });
});
$(function () {
    $("#filtro-genero").on("change", function (event) {
        FiltrarListado(event);
    });
});
$(function () {
    $("#filtro-orden").on("change", function (event) {
        FiltrarListado(event);
    });
});
$(function () {
    $("#bt-pag-anterior").on("click", function (event) {
        FiltrarListado(event);
    });
});
$(function () {
    $("#bt-pag-siguiente").on("click", function (event) {
        FiltrarListado(event);
    });
});

function FiltrarListado(event) {
    var peticion = "http://localhost:8520/Directorio";
    peticion = peticion + "/Filtrar";
    var pagina = 1;
    var genero = $("#filtro-genero").val();
    var orden = $("#filtro-orden").val();
    var estado = $("#filtro-estado").val();

    peticion = peticion + "?pOrden=" + orden + "&pEstado=" + estado + "&pGenero=" + genero + "&pPagina=" + pagina;
    location.href = peticion;
}
$(function () {
    $("#btnLogin").on("click", function (event) {
        $('#modalLogin').modal({ show: true });
    });
});

function AbrirModalRegistro() {
    $('#modalRegistro').modal({ show: true });
}

$(".episodio").mouseover(function (event) {
    var bloque = event.currentTarget;
    //bloque.style.filter = "brightness(50%)";
    bloque.style.opacity = 0.5;
    //bloque.children[0].children[0].style.filter = "brightness(1.75)";
    bloque.children[0].children[0].style.opacity = 1;


});

$(".episodio").mouseleave(function (event) {
    var bloque = event.currentTarget;
    //bloque.style.filter = "brightness(1)";
    bloque.style.opacity = 1;
    bloque.children[0].children[0].style.opacity = 0;
});