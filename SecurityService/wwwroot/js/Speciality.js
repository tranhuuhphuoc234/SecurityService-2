
function btn_save_speciality() {
        $('#form_speciality').validate({
            rules: {
                name_speciality: "required",
            },
            messages: {
                name_speciality: "Please enter field !",
            }
        });
        if ($('#form_speciality').valid()) {
            var infor_speciality = new Object();
            var name_speciality = $('#name_speciality').val();
            var status = $("#status_speciality").prop("checked");
            infor_speciality.name = name_speciality;
            if (status == true) {
                infor_speciality.status = true;
            } else {
                infor_speciality.status = false;
            }
            var q = JSON.stringify(infor_speciality);
            $.ajax({
                type: 'Post',
                url: 'http://localhost:44383/api/specialities',
                data: q,
                contentType: "application/json; charset=utf8",
                dataType: 'json',
                success: function (data) {
                    alert("Success");
                    clear_form_speciality();
                    load_data_speciality();
                },
                error: function (data) {
                    alert("Error");
                    clear_form_speciality();
                }
            });
        } else {

        }
    }
function load_data_speciality() {
    $.ajax({
        method: "Get",
        url: 'http://localhost:44383/api/specialities',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var content_table_speciality = "<tbody id='table_speciality'>"
            $.each(data, function (i, item) {
                content_table_speciality += "<tr id='content_tr'>"
                    + "<td class='td_hidden' id='id_speciality" + item.id + "'>" + item.id + "</td>"
                    + "<td>" + item.name + "</td>"
                    + "<td>" + item.status + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete' onclick='icon_delete_speciality(this);' data_id_delete_speciality='" + item.id + "'>"
                    + "<span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit' onclick='icon_edit_speciality(this);' data_id_edit_speciality='" + item.id + "'>"
                    + "<span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            });
            content_table_speciality += "</tbody>";
            $('#table_speciality').replaceWith(content_table_speciality);
        },
        error: function () {
            alert("error")
        }
    })
}
function icon_delete_speciality(a) {
    clear_label_speciality();
    var id = $(a).attr('data_id_delete_speciality');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/specialities/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_speciality();
            clear_form_speciality();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}
function icon_edit_speciality(a) {
    clear_label_speciality();
    var id = $(a).attr('data_id_edit_speciality');
    $('#div_btn_edit_speciality').css('display', 'block');
    $('#div_btn_save_speciality').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/specialities/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#id_speciality').val(data.id);
            $('#name_speciality').val(data.name);
            if (data.status == true) {
                $('#status_speciality').prop('checked', true);
            } else {
                $('#status_speciality').prop('checked', false);
            }
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_speciality').click(function () {
        $('#form_speciality').validate({
            rules: {
                name_speciality: "required",
            },
            messages: {
                name_speciality: "Please enter field !",
            }
        });
        if ($('#form_speciality').valid()) {
            var edit_speciality = new Object();
            var name_speciality = $('#name_speciality').val();
            var id_speciality = $('#id_speciality').val();
            edit_speciality.id = id_speciality;
            edit_speciality.name = name_speciality;
            var status_speciality = $('#status_speciality').prop('checked');
            if (status_speciality == true) {
                edit_speciality.status = true;
            } else {
                edit_speciality.status = false;
            }
            var q = JSON.stringify(edit_speciality);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/specialities/' + edit_speciality.id,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_data_speciality();
                    clear_form_speciality();
                    $('#div_btn_edit_speciality').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                }
            })
        } else {

        }
    })
}
