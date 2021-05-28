function load_data_recruitment() {
    $.ajax({
        type: "Get",
        url: "http://localhost:44383/api/Recruitments",
        dataType: 'json',
        contentType: 'application/json, charset=uft8',
        success: function (data) {
            var table_recruitment = "<tbody id='table_recruitment'>"
            $.each(data, function (i, item) {
                table_recruitment += "<tr>"
                    + "<td>" + item.last_name + " " + item.first_name + "</td>"
                    + "<td>" + item.age + "</td>"
                    + "<td>" + item.weight + "</td>"
                    + "<td>" + item.height + "</td>"
                    + "<td>" + item.phone + "</td>"
                    + "<td>" + item.achivement + "</td>"
                    + "<td>" + item.phone + "</td>"
                    + "<td>"
                    + "<div class='div_btn_client'  >"
                    + "<span onclick='send_recruitment(this);' id='close" + item.id + "' data_id='" + item.id + "' data_send_client='" + item.client_email + "' data_name_client='" + item.client_name + "' data_name_service='" + item.service + "'><i class='fa fa-envelope'></i></span>"
                    + "</div>"
                    + "<div class='div_btn_client'>"
                    + "<span onclick='accpet_recruitment(this);' data_accept_recruitment='" + item.id + "'><i class='fa fa-check'></i></span>"
                    + "</div>"
                    + "<div class='div_btn_client'>"
                    + "<span  onclick='click_remove_recruitment(this);' data_remove_recruitment='" + item.id + "'><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            })
            table_recruitment += "</tbody>";
            $('#table_recruitment').replaceWith(table_recruitment);
        },
        erorr: function (data) {
            alert("Erorr");
        }
    })
}

function click_remove_recruitment(a) {
    var id = $(a).attr('data_remove_recruitment');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/Recruitments/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_recruitment();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}

function accpet_recruitment(a) {
    var id = $(a).attr('data_accept_recruitment')
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/Recruitments/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#content_employee').css('display', 'block');
            $('#content_client_management').css('display', 'none');
            $("#li_employee").css('background-color', '#ffffff');
            $("#li_employee").css('color', '#000000');
            $("#li_client_management").css('background-color', '#000000');
            $("#li_client_management").css('color', '#ffffff');
            $('#input_name').val(data.first_name)
            $('#input_age').val(data.age)
            $('#input_weight').val(data.weight)
            $('#input_height').val(data.height)
            $('#input_phone').val(data.phone)
            $('#input_email').val(data.email)
            $('#input_address').val(data.address)
            $('#input_achivement').val(data.achivement)
            $('#input_aboutme').val(data.introduce_yourself)

        }, error: function (data) {
            alert("Erorr");
        }
    });
}