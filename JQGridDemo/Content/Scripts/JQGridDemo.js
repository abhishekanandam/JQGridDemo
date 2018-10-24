var JQGridDemo = JQGridDemo || {

    allowedImageLinkCheck: function (value, colname) {
        var pattern = /((ht|f)tp(s?)\:\/\/){1}\S+\.(png|bmp|jpg)/;
        if (pattern.test(value)) {
            return [true, ""];
        }
        else {
            return [false, "Invalid image link"];
        }
    },

    usaUkPhoneNumberCheck: function (value, colname) {
        var pattern = /^([0-9]( |-)?)?(\(?[0-9]{2,3}\)?|[0-9]{2,3})( |-)?[0-9]{3}( |-)?[0-9]{4}$/;
        if (pattern.test(value)) {
            return [true, ""];
        }
        else {
            return [false, "Neither USA nor UK phone #"];
        }
    },

    wrapText: function (rowId, tv, rawObject, cm, rdata) {
        return 'style="white-space: normal;"';
    },

    displayCustomErrorMessage: function () {
        url = document.URL;
        if (url[url.length - 1] == '/') {
            url = url.substring(0, url.length - 1);
        }
        url = url.substring(0, url.substring(0, url.lastIndexOf('/')).lastIndexOf('/'));
        url = url + "/Home/GetCustomErrorMessage";

        $.ajax({
            cache: false,
            type: "GET",
            url: url,
            dataType: 'json',
            data: {},
            success: function (data) {
                alert(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve states.');
            }
        }); // $.ajax({
    },

    getParameterByName: function (name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    },

    // Displays the response text if a page fails to load
    jqGrid_aspnet_loadErrorHandler: function (xht, st, handler) {
        jQuery(document.body).css('font-size', '100%');
        jQuery(document.body).html(xht.responseText);
    },

    stateArray : {
        0: "Select State", 5: "Connecticut", 1: "Delaware", 4: "Georgia", 7: "Maryland", 6: "Massachusetts",
        9: "New Hampshire", 3: "New Jersey", 11: "New York", 12: "North Carolina", 2: "Pennsylvania",
        13: "Rhode Island", 8: "South Carolina", 10: "Virginia"
    },

    stateString: "0:Select State;5:Connecticut;1:Delaware;4:Georgia;7:Maryland;6:Massachusetts;" +
        "9:New Hampshire;3:New Jersey;11:New York;12:North Carolina;2:Pennsylvania;" +
        "13:Rhode Island;8:South Carolina;10:Virginia",

    customFormatter: function (value) {
        return JQGridDemo.stateArray[value];
        }

};