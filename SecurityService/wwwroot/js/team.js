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