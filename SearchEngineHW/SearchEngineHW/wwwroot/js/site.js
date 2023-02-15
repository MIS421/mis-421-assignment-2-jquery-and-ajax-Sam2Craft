var len;
var results = '';
var toggle = false;

$("button").button();

function apiSearch() {

        var params = {
            "q": $("#query").val(),
            "count": "50",
            "offset": "0",
            "mkt": "en-us"
            }
    


    $.ajax({
        url: "https://api.bing.microsoft.com/v7.0/search?" + $.param(params),
        beforeSend: function (xhrObj) {
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "af9c6ad42a3f4932b8b8510cd473f74b");
        },
        type: "GET",
    })
        .done(function (data) {
            len = data.webPages.value.length;
            for (i = 0; i < len; i++) {
                results += "<p><a href='" + data.webPages.value[i].url + "'>" + data.webPages.value[i].name + "</a>: " + data.webPages.value[i].snippet + "</p>";
            }
            $('#searchResults').html(results);
            $('#searchResults').dialog({
                minWidth: 800
            });
            results = '';
        })
        .fail(function () {
            alert("error");
        });
}

function toggleBackground() {
    $("body").toggleClass("backgroundOne backgroundTwo")
}

function showTime() {
    var d = new Date();
    var n = d.toLocaleTimeString([], { timeStyle: 'short' });
    console.log(n);
    $("#time").toggleClass("hidden visible");
    $("#time").text(n);
    $("#time").dialog();
}

function feelingLucky() {
    var params = {
        "q": '',
        "count": "50",
        "offset": "0",
        "mkt": "en-us"
    }

    $.ajax({
        url: "https://api.bing.microsoft.com/v7.0/search?" + $.param(params),
        beforeSend: function (xhrObj) {
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "af9c6ad42a3f4932b8b8510cd473f74b");
        },
        type: "GET",
    })
        .done(function (data) {
            len = data.webPages.value.length;
            for (i = 0; i < len; i++) {
                results = "<p><a href='" + data.webPages.value[i].url + "'>" + data.webPages.value[i].name + "</a>: " + data.webPages.value[i].snippet + "</p>";
            }
            $('#searchResults').html(results);
            $('#searchResults').dialog({
                minWidth: 800
            });
            results = '';
        })
        .fail(function () {
            alert("error");
        });

}