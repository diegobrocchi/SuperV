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


function OnGridFocusedRowChanged(e, s) {
    MyGV.GetRowValues(MyGV.GetFocusedRowIndex(), 'Code', OnGetRowValues);
};

function OnGetRowValues(Value) {
    var ID = $('#ID').val();
    var From = $('#hiddenFromField').val();
    var To = $('#hiddenToField').val();

    $.ajax({
        url: "/Home/GetProcessingStepsTable",
        type: "GET",
        data: { 'Code': Value, 'ID': ID ,'From' : From, 'To': To}
            })
            .done(function (partialViewResult) {
                $("#fasiTable").html(partialViewResult);
            });

    $.ajax({
        url: "/Home/GetAttrezzaggiTable",
        type: "GET",
        data: { 'Code': Value, 'ID': ID, 'From': From, 'To': To }
    })
    .done(function (partialViewResult) {
        $('#attrezzaggioTable').html(partialViewResult);
    });

    $.ajax({
        url: "/Home/GetFermiTable",
        type: "GET",
        data: { 'Code': Value, 'ID': ID, 'From': From, 'To': To }
    })
    .done(function (partialViewResult) {
        $('#fermiTable').html(partialViewResult);
    });
}

//jQuery('#overlay').fadeOut();