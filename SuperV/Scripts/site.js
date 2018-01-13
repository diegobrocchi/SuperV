(function ($) {
    $("div.navbar-fixed-top").autoHidingNavbar();
    //$(document).ajaxStart(function () {
    //    $("#overlay").show();
    //}).ajaxStop(function () {
    //    $("#overlay").hide();
    //});
    $(document).ajaxStop(function () {
        $("#overlay").hide();
    });
}(jQuery));

//jQuery('#overlay').fadeOut();