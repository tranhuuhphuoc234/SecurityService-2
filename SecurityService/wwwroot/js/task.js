

function load_combobox_request() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/requests',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_request = "<select onchange='get_id_service(this);' id='select_request' name='select_request'><option id='Choose_Client' value='Choose_Client'>Choose Client</option>"
            $.each(data, function (i, item) {
                select_request += "<option id='" + item.id + "' address_client='" + item.client_address + "'  value='" + item.service + "'>" + item.client_name + "</option>"
            })
            select_request += "</select>"
            $('#select_request').replaceWith(select_request);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}


function get_id_service(a) {
    var id = a.value;
    var address_client = $(a).children(":selected").attr("address_client");
    $('#location').val(address_client);

    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/teams_get_id_service/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_team = "<select id='select_team' name='select_team'><option id='Choose_Team' value='Choose_Team'>Choose Team</option>"
            $.each(data, function (i, item) {
                select_team += "<option id='" + item.id + "' value='" + item.id + "'>" + item.name + "</option>"
            })
            select_team += "</select>"
            $('#select_team').replaceWith(select_team);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function onclick_send_task() {
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");
    $('#form_task').validate({
        ignore: [],
        rules: {
            name_task: "required",
            star_day: "required",
            end_day: "required"
        },
        messages: {
            name_task: "Please select an item!",
            location: "Please select an item!",
            star_day: "Please select an item!",
            end_day: "Please select an item!"
        }
    });
    $('#form_task1').validate({
        ignore: [],
        rules: {
            description_task: "required",
            select_request: { valueNotEquals: "Choose_Client" },
            select_region_task: { valueNotEquals: "Choose_Region" },
            select_department_task: { valueNotEquals: "Choose_Department" },
            select_team: { valueNotEquals: "Choose_Team" }
        },
        messages: {
            select_request: { valueNotEquals: "Please select an item!" },
            select_region_task: { valueNotEquals: "Please select an item!" },
            select_department_task: { valueNotEquals: "Please select an item!" },
            select_team: { valueNotEquals: "Please select an item!" }
        }
    });
    if ($('#form_task').valid()) {
        if ($('#form_task1').valid()) {
            var infor_task = new Object();
            var name = $('#name_task').val();
            var star_day = $('#star_day').val();
            var end_day = $('#end_day').val();
            var location = $('#location').val();
            var status_task = $("#status_task").prop("checked");
            var description_task = $('#description_task').val();
            var id_request = $('#id_request_task').val();
            var id_team = $('#select_team option:selected').attr('id');
            if (status_task == true) {
                infor_task.status = true;
            } else {
                infor_task.status = false;
            }
            infor_task.name = name;
            infor_task.task_status = "1";
            infor_task.start_day = star_day;
            infor_task.end_day = end_day;
            infor_task.location = location;
            infor_task.descripttion = description_task;
            infor_task.request = id_request;
            infor_task.team = id_team;
            var q = JSON.stringify(infor_task)
            alert(q)
            $.ajax({
                type: 'Post',
                url: 'http://localhost:44383/api/tasks',
                data: q,
                contentType: "application/json; charset=utf8",
                dataType: 'json',
                success: function (data) {
                    alert("Success");
                    clear_form_task();
                    load_combobox_request();
                },
                error: function (data) {
                    alert(JSON.stringify(data));
                    clear_form_task();
                    load_combobox_request();
                }
            });
        }
    }
}


function clear_form_task() {
    $('#name_task').val("");
    $('#name_service_in_task').val("");
    $('#status_task').prop("checked", false);
    $('#description_task').val("");
    $("input[type=date]").val("");
    $('#location').val("");
    $('#description_task').val("");
    $('#select_request').find('option').remove();
    $('#select_team').find('option').remove();
    $('#select_region_task').find('option').remove();
    $('#select_department_task').find('option').remove();
}

function clear_label_task() {
    $('#name_task-error').css('display', 'none');
    $('#star_day-error').css('display', 'none');
    $('#end_day-error').css('display', 'none');
    $('#select_request-error').css('display', 'none');
    $('#select_team-error').css('display', 'none');
}

function load_sl_task_role() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/regions',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var sl_region = "<select style='width: 95%;' onchange='get_idregion_task(this);' id='sl_region' name='sl_region'><option id='Choose_Region' value='Choose_Region'>Choose Region</option>"
            $.each(data, function (i, item) {
                sl_region += "<option id='" + item.id + "'  value='" + item.id + "'>" + item.name + "</option>"
            })
            sl_region += "</select>"
            $('#sl_region').replaceWith(sl_region);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function load_select_task_region() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/regions',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_region_task = "<select style='width: 67%;' onchange='send_idregion_task(this);' id='select_region_task' name='select_region_task'><option id='Choose_Region' value='Choose_Region'>Choose Region</option>"
            $.each(data, function (i, item) {
                select_region_task += "<option id='" + item.id + "'  value='" + item.id + "'>" + item.name + "</option>"
            })
            select_region_task += "</select>"
            $('#select_region_task').replaceWith(select_region_task);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function send_idregion_task(a) {
    $('#select_team').find('option').remove();
    $('#select_department_task').find('option').remove();
    var id = a.value;
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/departments_addteam/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_department_task = "<select style='width: 67%;' onchange='send_iddepartment_task(this);' id='select_department_task' name='select_department_task'><option id='Choose_Department' value='Choose_Department'>Choose Department</option>"
            $.each(data, function (i, item) {
                select_department_task += "<option id='" + item.id + "' value='" + item.id + "'>" + item.name + "</option>"
            })
            select_department_task += "</select>"
            $('#select_department_task').replaceWith(select_department_task);

        },
        erorr: function (data) {
            alert("Erorr")
        }
    })

}
function send_iddepartment_task(a) {
    $('#select_team').find('option').remove();
    var id_department = a.value;
    var id_servive = $('#id_service_task').val();
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/teams_get_2id/' + id_department + "/" + id_servive,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_team = "<select style='width: 67%;' id='select_team' name='select_team'><option id='Choose_Team' value='Choose_Team'>Choose Team</option>"
            $.each(data, function (i, item) {
                select_team += "<option id='" + item.id + "' value='" + item.id + "'>" + item.name + "</option>"
            })
            select_team += "</select>"
            $('#select_team').replaceWith(select_team);

        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

//---------------------------------------------------
function get_idregion_task(a) {
    $('#sl_department').find('option').remove();
    $('#sl_team').find('option').remove();

    var id = a.value;
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/departments_addteam/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var sl_department = "<select style='width: 95%;' onchange='get_iddepartment_task(this);' id='sl_department' name='sl_department'><option id='Choose_Department' value='Choose_Department'>Choose Department</option>"
            $.each(data, function (i, item) {
                sl_department += "<option id='" + item.id + "' value='" + item.id + "'>" + item.name + "</option>"
            })
            sl_department += "</select>"
            $('#sl_department').replaceWith(sl_department);
            
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })

    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/task_table_region/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var table_task = "<tbody id='table_task'>"
            $.each(data, function (i, item) {
                table_task += "<tr>"
                    + "<td>" + item.name_team + "</td>"
                    + "<td>" + item.name_task + "</td>"
                    + "<td>" + item.name_client + "</td>"
                    + "<td>" + item.name_service + "</td>"
                    + "<td>" + item.name_task_status + "</td>"
                    + "</tr>"
            });
            table_task += "</tbody>";
            $('#table_task').replaceWith(table_task);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function get_iddepartment_task(a) {
    $('#sl_team').find('option').remove();

    var id = a.value;
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/teams_get_id_department/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var sl_team = "<select style='width: 95%;' onchange='get_idteam_task(this);' id='sl_team' name='sl_team'><option id='Choose_Team' value='Choose_Team'>Choose Team</option>"
            $.each(data, function (i, item) {
                sl_team += "<option id='" + item.id + "' value='" + item.id + "'>" + item.name + "</option>"
            })
            sl_team += "</select>"
            $('#sl_team').replaceWith(sl_team);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })

    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/tasks_table_department/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var table_task = "<tbody id='table_task'>"
            $.each(data, function (i, item) {
                table_task += "<tr>"
                    + "<td>" + item.name_team + "</td>"
                    + "<td>" + item.name_task + "</td>"
                    + "<td>" + item.name_client + "</td>"
                    + "<td>" + item.name_service + "</td>"
                    + "<td>" + item.name_task_status + "</td>"
                    + "</tr>"
            });
            table_task += "</tbody>";
            $('#table_task').replaceWith(table_task);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function get_idteam_task(a) {
    var id = a.value;
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/tasks_table_team/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var table_task = "<tbody id='table_task'>"
            $.each(data, function (i, item) {
                table_task += "<tr>"
                    + "<td>" + item.name_team + "</td>"
                    + "<td>" + item.name_task + "</td>"
                    + "<td>" + item.name_client + "</td>"
                    + "<td>" + item.name_service + "</td>"
                    + "<td>" + item.name_task_status + "</td>"
                    + "</tr>"
            });
            table_task += "</tbody>";
            $('#table_task').replaceWith(table_task);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}
function load_table_task() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/tasks_table',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var table_task = "<tbody id='table_task'>"
            $.each(data, function (i, item) {
                table_task += "<tr>"
                    + "<td>" + item.name_team + "</td>"
                    + "<td>" + item.name_task + "</td>"
                    + "<td>" + item.name_client + "</td>"
                    + "<td>" + item.name_service + "</td>"
                    + "<td>" + item.name_task_status + "</td>"
                    + "</tr>"
            });
            table_task += "</tbody>";
            $('#table_task').replaceWith(table_task);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}
