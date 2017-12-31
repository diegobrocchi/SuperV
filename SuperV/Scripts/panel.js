function callPartialViewToServer() {
    var tbl = $('#messagesTable');
    $.ajax({
        cache: false,
        url: baseUrl + 'home/PanelPartial',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html'
    }).done(function (result) {
        tbl.empty().append(result);
    }).fail(function () {

    });
}