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

// NOTIFICACIONES PUSH

if ('serviceWorker' in navigator) {
    window.addEventListener("load", () => {
        navigator.serviceWorker.register("/ServiceWorker.js");
    });
}
if ('serviceWorker' in navigator) {
    window.addEventListener("load", () => {
        navigator.serviceWorker.register("/ServiceWorker.js")
            .then((reg) => {
                if (Notification.permission === "granted") {
                    getSubscription(reg);
                } else if (Notification.permission === "denied") {
                    blockSubscription();
                } else {
                    requestNotificationAccess(reg);
                }
            });
    });
}

function requestNotificationAccess(reg) {
    Notification.requestPermission(function (status) {
        if (status == "granted") {
            getSubscription(reg);
        } else if (status == "denied") {
            blockSubscription();
        }
    });
}

function blockSubscription() {
    var urlPeticion = location.protocol + "//" + location.host + "/PeticionesAJAX/DesuscribirseNotificacionesPush";

    GnossPeticionAjax(
        urlPeticion,
        null,
        true
    ).done(function (data) {

    }).fail(function (data) {

    }).always(function () {

    });
}

function fillSubscribeFields(sub) {
    var endpoint = sub.endpoint;
    var p256dh = arrayBufferToBase64(sub.getKey("p256dh"));
    var auth = arrayBufferToBase64(sub.getKey("auth"));
    var urlPeticion = location.protocol + "//" + location.host + "/Peticiones/SuscribirseNotificacionesPush";

    var datapost =
    {
        pEndpoint: endpoint,
        pP256dh: p256dh,
        pAuth: auth
    };

    $.ajax({
        method: "POST",
        url: urlPeticion,
        data: datapost
    });
}

function arrayBufferToBase64(buffer) {
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}
// FIN NOTIFICACIONES PUSH