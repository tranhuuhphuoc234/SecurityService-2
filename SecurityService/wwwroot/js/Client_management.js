

$('#Check_service').click(function () {
    $('#span_Check_service').css('background', 'black');
    $('#span_Transaction_History').css('background', '#dddddd');
    $('#span_comment').css('background', '#dddddd');
    $('#display_content_Check_service').css('display', 'block');
    $('#display_content_Transaction_history').css('display', 'none');
    $('#display_content_Comment').css('display', 'none');
})

$('#Transaction_history').click(function () {
    $('#span_Transaction_History').css('background', 'black');
    $('#span_comment').css('background', '#dddddd');
    $('#span_Check_service').css('background', '#dddddd');
    $('#display_content_Transaction_history').css('display', 'block');
    $('#display_content_Check_service').css('display', 'none');
    $('#display_content_Comment').css('display', 'none');
})

$('#Comment').click(function () {
    $('#span_comment').css('background', 'black');
    $('#span_Transaction_History').css('background', '#dddddd');
    $('#span_Check_service').css('background', '#dddddd');
    $('#display_content_Comment').css('display', 'block');
    $('#display_content_Transaction_history').css('display', 'none');
    $('#display_content_Check_service').css('display', 'none');
})

function load_data_client() {
    $.ajax({
        type: "Get",
        url: "http://localhost:44383/api/requests",
        dataType: 'json',
        contentType: 'application/json, charset=uft8',
        success: function (data) {
            var table_client = "<tbody id='table_check_service'>"
            $.each(data, function (i, item) {
                table_client += "<tr>"
                    + "<td>" + item.client_name + "</td>"
                    + "<td>" + item.client_email + "</td>"
                    + "<td>" + item.service + "</td>"
                    + "<td>" + item.message + "</td>"
                    + "<td>"
                    + "<div class='div_btn_client'  >"
                    + "<span onclick='send_client_open(this);' id='open" + item.id + "' style='display:none;'><i class='fa fa-envelope-open' ></i></span>"
                    + "<span onclick='send_client(this);' id='close" + item.id + "' data_id='" + item.id + "' data_send_client='" + item.client_email + "' data_name_client='" + item.client_name + "' data_name_service='" + item.service + "'><i class='fa fa-envelope'></i></span>"
                    + "</div>"
                    + "<div class='div_btn_client'>"
                    + "<span onclick='accpet_client(this);' data_accept_client='" + item.id + "'><i class='fa fa-check'></i></span>"
                    + "</div>"
                    + "<div class='div_btn_client'>"
                    + "<span  onclick='click_remove_client(this);' data_remove_client='" + item.id + "'><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            })
            table_client += "</tbody>";
            $('#table_check_service').replaceWith(table_client);
        },
        erorr: function (data) {
            alert("Erorr");
        }
    })
}

function load_data_history() {
    $.ajax({
        type: "Get",
        url: "http://localhost:44383/api/Check_request",
        dataType: 'json',
        contentType: 'application/json, charset=uft8',
        success: function (data) {
            var table_history = "<tbody id='table_history'>"
            $.each(data, function (i, item) {
                table_history += "<tr>"
                    + "<td>" + item.client_name + "</td>"
                    + "<td>" + item.client_email + "</td>"
                    + "<td>" + item.service + "</td>"
                    + "<td>" + item.message + "</td>"
                    + "<td>"
                    + "<div class='div_icon_edit' style=width:100%;' >"
                    + "<button type='button' class='btn_delete' onclick='click_remove_client(this);' style='margin-right:0px;' data_remove_client='" + item.id + "'>Remove</button>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            })
            table_history += "</tbody>";
            $('#table_history').replaceWith(table_history);
        },
        erorr: function (data) {
            alert("Erorr");
        }
    })
}

function click_remove_client(a) {
    var id = $(a).attr('data_remove_client');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/requests/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_client();
            load_data_history();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}

function accpet_client(a) {
    var id = $(a).attr('data_accept_client');
    $.ajax({
        type: "Put",
        url: 'http://localhost:44383/api/requests/active/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_client();
            load_data_history();
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function send_client(a) {
    var id = $(a).attr('data_id');
    var email = $(a).attr('data_send_client');
    var name_client = $(a).attr('data_name_client');
    var name_service = $(a).attr('data_name_service');
    alert(id);
    alert(name_client);
    alert(name_service);
    $.ajax({
        method: "Post",
        url: "Send_mail_client",
        data: { email: email, name_client: name_client, name_service: name_service },
        success: function (data) {
            alert(data);
            $("#open" + id + "").css('display', 'block');
            $("#close" + id + "").css('display', 'none');
        },
        erorr: function (data) {
            alert("Erorr");
        }
    })
}

function send_client_open() {
    alert("Email has been sent");
}