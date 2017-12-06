$(function () {
    // Reference the auto-generated proxy for the hub.
    var updater = $.connection.sR_firstHub;
    // Create a function that the hub can call back to display messages.
    updater.client.refreshData = function (newData) {
        // Add the message to the page.
        $('#serverValue').html('<li><strong>' + htmlEncode(newData) + '</strong></li>');
        CallPartialViewFromServer();
    };

    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#refresh').click(function () {
            // Call the Send method on the hub.
            updater.server.getLastData();
            // Clear text box and reset focus for next comment.

        });
    });
});
// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
};

function CallPartialViewFromServer() {
    var tbl = $('#messagesTable');
    $.ajax({
        url: '/home/PanelPartial',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html'
    }).done(function (result) {
        console.log(result);
        tbl.append(result);
    }).fail(function () {

    });
}