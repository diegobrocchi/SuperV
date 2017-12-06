$(function () {
    // Reference the auto-generated proxy for the hub.
    var updater = $.connection.signalRHub;
    // Create a function that the hub can call back to display messages.
    //updater.client.refreshData = function (newData) {
    //    // Add the message to the page.
    //    $('#serverValue').html('<li><strong>' + htmlEncode(newData) + '</strong></li>');
    //    CallPartialViewFromServer();
    //};
    updater.client.refreshData = refreshDateTime;
    updater.client.reloadPartial = callPartialViewToServer;

    // Start the connection.
    $.connection.hub.start().done(function () {
         
            // Call the Send method on the hub.
            updater.server.getLastData();
            // Clear text box and reset focus for next comment.

         
    });
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
};

function refreshDateTime(data) {
    $('#serverValue').html('<li><strong>' + htmlEncode(data) + '</strong></li>');
}

function callPartialViewToServer() {
    var tbl = $('#messagesTable');
    $.ajax({
        url: '/home/PanelPartial',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html'
    }).done(function (result) {
        tbl.empty().append(result);
    }).fail(function () {

    });
}