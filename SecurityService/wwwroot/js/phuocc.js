function ValidateEmail(email) {
    if (email != "") {
        var mailformat = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if (email.match(mailformat)) {
            return true;
        } else {
            $('#error_email').replaceWith("<span id='error_email' style='color: red; font-size: 13px;'>Email not a valid</span>");
            return false;
        }
    }
}
function regexEmail(email) {
    if (email != "") {
        var mailformat = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if (email.match(mailformat)) {
            return true;
        } else {
            $('#error_email').replaceWith("<span id='error_email' style='color: red; font-size: 13px;'>Email not a valid</span>");
            return false;
        }
    }
}

function checkPhone(phone) {
    var count = 0;
    $.ajax({
        type: 'get',
        url: 'http://localhost:44383/api/employees',
        dataType: 'json',
        contentType: "application/json; charset=utf8",
        success: function (data) {
            $.each(data, function (index, value) {
                if (value.phone == phone) {
                    count++;
                }
            });
            if (count > 0) {
                setTimeout(function () {
                    $('#error_phone').replaceWith("<span id='error_phone' style='color: red; font-size: 13px;'>Phone already exits</span>");
                }, 600)
            } else {
                $('#error_phone').replaceWith("<span id='error_phone' style='color: red; font-size: 13px;'></span>");
            }
        }
    })
}
/*function load_aboutus_emp() {
    $.ajax({
        type: 'get',
        url: 'http://localhost:54396/api/about_us_employee',
        dataType: 'json',
        contentType: "application/json; charset=utf8",
        success: function (data) {
            var rows = "";
            $.each(data, function (index, value) {
                rows += "<div class='service-item'>"
                    + "<div class='service-item-background'>"
                    + "<div style='position: relative; height: 100 %; background: rgba(0, 0, 0, 0.3);'>"
                    + "<h2> Manned Guarding </h2>"
                    + "<div class='service-item-title-background'>"
                    + "<div class='service-item-title'>"
                    + "<h3> hello world</h3>"
                    + "<a href='../MannedGuarding/Index' class='myBtn'> View more <i class='bi bi-arrow-right'></i> </a>"
                    + "</div></div></div></div></div>";
                $('#slide').append(rows);
            });
        }
    })
}*/