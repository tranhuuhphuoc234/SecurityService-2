function clear_form_order() {
    $('#email_client').val("");
    $('#phone_client').val("");
    $('#name_client').val("");
    $('#select_speciality').find('option').remove();
    $('#select_employee').find('option').remove();
    $('#select_service').find('option').remove();
}
function clear_label_orders() {
    $('#select_service-error').css('display', 'none');
    $('#select_speciality-error').css('display', 'none');
    $('#select_employee-error').css('display', 'none');
}
$('#Check_service').click(function () {
    $('#span_Check_service').css('background', 'black');
    $('#span_orders').css('background', '#dddddd');
    $('#span_Transaction_History').css('background', '#dddddd');
    $('#span_comment').css('background', '#dddddd');
    $('#display_content_Check_service').css('display', 'block');
    $('#display_content_Transaction_history').css('display', 'none');
    $('#display_content_Comment').css('display', 'none');
    $('#display_ordrers').css('display', 'none');
    clear_form_order();
    clear_label_orders();
})

$('#Orders').click(function () {
    $('#span_orders').css('background', 'black');
    $('#span_Check_service').css('background', '#dddddd');
    $('#span_Transaction_History').css('background', '#dddddd');
    $('#span_comment').css('background', '#dddddd');
    $('#display_content_Check_service').css('display', 'none');
    $('#display_content_Transaction_history').css('display', 'none');
    $('#display_content_Comment').css('display', 'none');
    $('#display_ordrers').css('display', 'block');
    clear_form_order();
    clear_label_orders();

})

$('#Transaction_history').click(function () {
    $('#span_Transaction_History').css('background', 'black');
    $('#span_comment').css('background', '#dddddd');
    $('#span_orders').css('background', '#dddddd');
    $('#span_Check_service').css('background', '#dddddd');
    $('#display_content_Transaction_history').css('display', 'block');
    $('#display_content_Check_service').css('display', 'none');
    $('#display_content_Comment').css('display', 'none');
    $('#display_ordrers').css('display', 'none');
    clear_form_order();
    clear_label_orders();

})

$('#Comment').click(function () {
    $('#span_comment').css('background', 'black');
    $('#span_orders').css('background', '#dddddd');
    $('#span_Transaction_History').css('background', '#dddddd');
    $('#span_Check_service').css('background', '#dddddd');
    $('#display_content_Comment').css('display', 'block');
    $('#display_content_Transaction_history').css('display', 'none');
    $('#display_content_Check_service').css('display', 'none');
    $('#display_ordrers').css('display', 'none');
    clear_form_order();
    clear_label_orders();
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
                    + "<span onclick='accpet_client(this);' data_id_client='" + item.client + "'  data_accept_client='" + item.id + "' data_name_client='" + item.client_name + "' data_email_client='" + item.client_email + "' data_phone_client='" + item.client_phone + "'><i class='fa fa-check'></i></span>"
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

function load_data_orderdetail() {
    $.ajax({
        type: "Get",
        url: "http://localhost:44383/api/orderdetails",
        dataType: 'json',
        contentType: 'application/json, charset=uft8',
        success: function (data) {
            var table_orderdetail = "<tbody id='table_orderdetail'>"
            $.each(data, function (i, item) {
                table_orderdetail += "<tr>"
                    + "<td style='width: 150px;'>" + item.name_client + "</td>"
                    + "<td style='width: 150px;'>" + item.phone_client + "</td>"
                    + "<td style='width: 150px;'>" + item.name_employee + "</td>"
                    + "<td style='width: 100px;'>" + item.date + "</td>"
                    + "<td style='width: 100px;'>" + item.total + "</td>"
                    + "<td style='width: 100px;'>"
                    + "<div class='div_icon_edit' style=width:100%;' >"
                    + "<span  onclick='click_remove_orderdetail(this);' data_remove_orderdetail='" + item.id + "'><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            })
            table_orderdetail += "</tbody>";
            $('#table_orderdetail').replaceWith(table_orderdetail);
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
                    + "<span  onclick='click_remove_client(this);' data_remove_client='" + item.id + "'><i class='fa fa-trash'></i></span>"
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

function click_remove_orderdetail(a) {
    var id = $(a).attr('data_remove_orderdetail');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/orderdetails/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_orderdetail();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}

function accpet_client(a) {
    var phone_client = $(a).attr('data_phone_client');
    var email_client = $(a).attr('data_email_client');
    var id_request = $(a).attr('data_accept_client');
    var id_client = $(a).attr('data_id_client');
    alert(id_client);
    var name_client = $(a).attr('data_name_client');
    $('#span_orders').css('background', 'black');
    $('#span_Check_service').css('background', '#dddddd');
    $('#span_Transaction_History').css('background', '#dddddd');
    $('#span_comment').css('background', '#dddddd');
    $('#display_content_Check_service').css('display', 'none');
    $('#display_content_Transaction_history').css('display', 'none');
    $('#display_content_Comment').css('display', 'none');
    $('#display_ordrers').css('display', 'block');
    $('#name_client').val(name_client);
    $('#id_client').val(id_client);
    $('#id_request').val(id_request);
    $('#email_client').val(email_client);
    $('#phone_client').val(phone_client);
    
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/services',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_service = "<select id='select_service' name='select_service'><option id='Choose_Service' value='Choose_Service'>Choose Service</option>"
            $.each(data, function (i, item) {
                select_service += "<option  value='" + item.id + "'>" + item.name + "</option>"
            })
            select_service += "</select>"
            $('#select_service').replaceWith(select_service);
            $.ajax({
                type: "Get",
                url: 'http://localhost:44383/api/specialities',
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    var select_speciality = "<select onchange='get_id_speciality(this);' id='select_speciality' name='select_speciality'><option id='Choose_Speciality' value='Choose_Speciality'>Choose Speciality</option>"
                    $.each(data, function (i, item) {
                        select_speciality += "<option  value='" + item.id + "'>" + item.name + "</option>"
                    })
                    select_speciality += "</select>"
                    $('#select_speciality').replaceWith(select_speciality);
                },
                erorr: function (data) {
                    alert("Erorr")
                }
            })
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
    $.ajax({
        method: "Post",
        url: "Send_mail_client",
        data: { email: email, name_client: name_client, name_service: name_service },
        success: function (data) {
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

function get_id_speciality(a) {
    var id = a.value;
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/employees_orders/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_employee = "<select id='select_employee' name='select_employee'><option id='Choose_Employee' value='Choose_Employee'>Choose Employee</option>"
            $.each(data, function (i, item) {
                select_employee += "<option value='" + item.id + "'>" + item.name + "</option>"
            })
            select_employee += "</select>"
            $('#select_employee').replaceWith(select_employee);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function save_orders() {
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");
    var id_client = $('#id_client').val();
    var id_employee = $('#select_employee option:selected').attr('value');
    var id_service = $('#select_service option:selected').attr('value'); 
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');
    var yyyy = today.getFullYear();
    today = yyyy + '-' + mm + '-' + dd;
    alert(id_employee);
    $('#form_orders').validate({
        ignore: [],
        rules: {
            select_service: { valueNotEquals: "Choose_Service" },
            select_speciality: { valueNotEquals: "Choose_Speciality" },
            select_employee: { valueNotEquals: "Choose_Employee" }
        },
        messages: {
            select_service: { valueNotEquals: "Please select an item!" },
            select_speciality: { valueNotEquals: "Please select an item!" },
            select_employee: { valueNotEquals: "Please select an item!" },
        }
    });
    if ($('#form_orders').valid()) {
        $.ajax({
            type: "Get",
            url: 'http://localhost:44383/api/employees/' + id_employee,
            dataType: 'json',
            contentType: "application/json, charset=utf8",
            success: function (data) {
                var discount = 0;
                var price = data.price;
                var infor_order = new Object();
                infor_order.total = price;
                infor_order.discount = discount;
                infor_order.client = id_client;
                infor_order.date = today;
                var q = JSON.stringify(infor_order);
                $.ajax({
                    type: 'Post',
                    url: 'http://localhost:44383/api/orders',
                    data: q,
                    contentType: "application/json; charset=utf8",
                    dataType: 'json',
                    success: function (data) {
                        var id_order = data.id
                        var infor_orderdetail = new Object();
                        infor_orderdetail.order = id_order;
                        infor_orderdetail.service = id_service;
                        infor_orderdetail.employee = id_employee;
                        var q_od = JSON.stringify(infor_orderdetail);
                        alert(infor_orderdetail);
                        $.ajax({
                            type: 'Post',
                            url: 'http://localhost:44383/api/orderdetails',
                            data: q_od,
                            contentType: "application/json; charset=utf8",
                            dataType: 'json',
                            success: function (data) {
                                var request_id = $('#id_request').val();
                                $.ajax({
                                    type: "Put",
                                    url: 'http://localhost:44383/api/employees/disable/' + id_employee,
                                    dataType: 'json',
                                    contentType: "application/json, charset=utf8",
                                    success: function (data) {
                                        $.ajax({
                                            type: "Put",
                                            url: 'http://localhost:44383/api/requests/disable/' + request_id,
                                            dataType: 'json',
                                            contentType: "application/json, charset=utf8",
                                            success: function (data) {
                                                alert("Order Success");
                                                load_data_client();
                                                load_data_orderdetail();
                                                clear_form_order();
                                                clear_label_orders();
                                            }, error: function (data) {
                                                alert("Erorr");
                                            }
                                        })
                                    }, error: function (data) {
                                        alert("Erorr");
                                    }
                                })
                            },
                            error: function (data) {
                                alert("Error");
                            }
                        });
                    },
                    error: function (data) {
                        alert("Error");
                    }
                });
            },
            erorr: function (data) {
                alert("Erorr")
            }
        })
    }

}