function load_combobox_service() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/services',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_services = "<select id='select_services' name='select_services'><option id='Choose_Services' value='Choose_Services'>Choose Services</option>"
            $.each(data, function (i, item) {
                select_services += "<option id='" + item.id + "'  value='" + item.name + "'>" + item.name + "</option>"
            })
            select_services += "</select>"
            $('#select_services').replaceWith(select_services);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function load_combobox_region() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/regions',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_regions_team = "<select onchange='get_idregion(this);' id='select_regions_team' name='select_regions_team'><option id='Choose_Region' value='Choose_Region'>Choose Region</option>"
            $.each(data, function (i, item) {
                select_regions_team += "<option id='" + item.id + "'  value='" + item.id + "'>" + item.name + "</option>"
            })
            select_regions_team += "</select>"
            $('#select_regions_team').replaceWith(select_regions_team);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}
function onclick_save_team() {
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");
    $('#form_team').validate({
        ignore: [],
        rules: {
            name_team: "required",
            select_departments: { valueNotEquals: "Choose_Department" },
            select_regions_team: { valueNotEquals: "Choose_Region" },
            select_services: { valueNotEquals: "Choose_Services" }
        },
        messages: {
            name_trainning: "Please enter field !",
            select_departments: { valueNotEquals: "Please select an item!" },
            select_regions_team: { valueNotEquals: "Please select an item!" },
            select_services: { valueNotEquals: "Please select an item!" }

        }
    });
    if ($('#form_team').valid()) {
        var infor_team = new Object();
        var name = $('#name_team').val();
        var id_service = $('#select_services option:selected').attr('id');
        var id_department = $('#select_departments option:selected').attr('id');
        var status = $("#status_team").prop("checked");
        if (status == true) {
            infor_team.status = true;
        } else {
            infor_team.status = false;
        }
        infor_team.name = name;
        infor_team.service = id_service;
        infor_team.department = id_department;
        var q = JSON.stringify(infor_team);
        $.ajax({
            type: 'Post',
            url: 'http://localhost:44383/api/teams',
            data: q,
            contentType: "application/json; charset=utf8",
            dataType: 'json',
            success: function (data) {
                alert("Success");
                clear_form_team();
                load_combobox_region();
                load_combobox_service();
            },
            error: function (data) {
                alert("Erorr");
                clear_form_team();
                load_combobox_region();
                load_combobox_service();
            }
        });
    }
}

function get_idregion(a) {
    var id = a.value;
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/departments_addteam/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var select_departments = "<select id='select_departments' name='select_departments'><option id='Choose_Department' value='Choose_Department'>Choose Department</option>"
            $.each(data, function (i, item) {
                select_departments += "<option id='" + item.id + "' value='" + item.id + "'>" + item.name + "</option>"
            })
            select_departments += "</select>"
            $('#select_departments').replaceWith(select_departments);
        },
        erorr: function (data) {
            alert("Erorr")
        }
    })
}

function clear_form_team() {
    $('#select_team').find('option').remove();
    $('#status_team').prop("checked", false);
    $('#name_team').val("");
    $('#select_departments').find('option').remove();
    $('#select_regions_team').find('option').remove();
    $('#select_services').find('option').remove();
}
function clear_label_team() {
    $('#name_team-error').css('display', 'none');
    $('#select_regions_team-error').css('display', 'none');
    $('#select_services-error').css('display', 'none');
    $('#select_departments-error').css('display', 'none');
}

function load_table_team() {
    $.ajax({
        method: "Get",
        url: 'http://localhost:44383/api/teams',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var table_team = "<tbody id='table_team'>"
            $.each(data, function (i, item) {
                table_team += "<tr>"
                    + "<td class='td_hidden' id='id_team" + item.id + "'>" + item.id + "</td>"
                    + "<td>" + item.name + "</td>"
                    + "<td>" + item.name_department + "</td>"
                    + "<td>" + item.name_region + "</td>"
                    + "<td>" + item.name_service + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete' onclick='icon_delete_team(this);' data_id_delete_team='" + item.id + "'>"
                    + "<span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit' onclick='icon_edit_team(this);' data_id_edit_team='" + item.id + "'>"
                    + "<span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            });
            table_team += "</tbody>";
            $('#table_team').replaceWith(table_team);
        },
        error: function () {
            alert("error")
        }
    })
}

function icon_delete_team(a) {
    clear_label_team();
    var id = $(a).attr('data_id_delete_team');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/teams/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_table_team();
            clear_label_team();
            clear_table_region();
            clear_label_department();
            clear_form_region();
            load_combobox_region();
            load_combobox_service();
        }, error: function (data) {
            alert("Erorr");
            load_table_team();
            clear_label_team();
            clear_table_region();
            clear_label_department();
            clear_form_region();
            load_combobox_region();
            load_combobox_service();
        }
    })
}

function icon_edit_team(a) {
    clear_label_team();
    var id = $(a).attr('data_id_edit_team');
    $('#div_btn_edit_team').css('display', 'block');
    $('#div_btn_save_team').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/teams/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#id_teams').val(data.id);
            $('#name_team').val(data.name);
            if (data.status == true) {
                $('#status_team').prop('checked', true);
            } else {
                $('#status_team').prop('checked', false);
            }
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_team').click(function () {
        $.validator.addMethod("valueNotEquals", function (value, element, arg) {
            return arg !== value;
        }, "Value must not equal arg.");
        $('#form_team').validate({
            ignore: [],
            rules: {
                name_team: "required",
                select_departments: { valueNotEquals: "Choose_Department" },
                select_regions_team: { valueNotEquals: "Choose_Region" },
                select_services: { valueNotEquals: "Choose_Services" }
            },
            messages: {
                name_trainning: "Please enter field !",
                select_departments: { valueNotEquals: "Please select an item!" },
                select_regions_team: { valueNotEquals: "Please select an item!" },
                select_services: { valueNotEquals: "Please select an item!" }

            }
        });
        if ($('#form_team').valid()) {
            var edit_team = new Object();
            var name_team = $('#name_team').val();
            var id_team = $('#id_teams').val();
            var id_service = $('#select_services option:selected').attr('id');
            var id_department = $('#select_departments option:selected').attr('id');
            edit_team.id = id_team;
            edit_team.service = id_service;
            edit_team.department = id_department;
            edit_team.name = name_team;
            var status_team = $('#status_role').prop('checked');
            if (status_team == true) {
                edit_team.status = true;
            } else {
                edit_team.status = false;
            }
            var q = JSON.stringify(edit_team);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/teams/' + edit_team.id ,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_table_team();
                    clear_form_team();
                    load_table_team();
                    clear_label_team();
                    clear_table_region();
                    clear_label_department();
                    clear_form_region();
                    load_combobox_region();
                    load_combobox_service();
                    $('#div_btn_edit_team').css('display', 'none');
                    $('#div_btn_save_team').css('display', 'block');
                    $('#div_btn_edit_team').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                    $('#div_btn_edit_team').css('display', 'none');
                    $('#div_btn_save_team').css('display', 'block');
                    load_table_team();
                    clear_label_team();
                    clear_table_region();
                    clear_label_department();
                    clear_form_region();
                    load_combobox_region();
                    load_combobox_service();
                }
            })
        } else {

        }
    })
}