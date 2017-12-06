//loader per lo script signalR.js.
//lo script è generato a runtime alla prima richiesta e non è possibile quindi aggiungerlo ad uno script bundle.
//questa funzione richiede lo script quando la pagina è pronta e poi lo tiene in cache.

(function ($) {
    $.ajax({
        url: "/signalr/hubs",
        dataType: "script",
        async:false,
        cache:true
    });
}(jQuery));