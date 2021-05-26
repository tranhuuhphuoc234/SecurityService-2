
// load aboutus
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "http://localhost:8085/api/about_us",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(".history-content").append(data[0].where);
            
        }
    });

})