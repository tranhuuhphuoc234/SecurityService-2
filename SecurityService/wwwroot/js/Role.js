
function btn_save_role() {
    $('#form_role').validate({
        rules: {
            name_role: "required",
        },
        messages: {
            name_role: "Please enter field !",
        }
    });
    if ($('#form_role').valid()) {
        var infor_role = new Object();
        var name_role = $('#name_role').val();
        var status = $("#status_role").prop("checked");
        infor_role.name = name_role;
        if (status == true) {
            infor_role.status = true;
        } else {
            infor_role.status = false;
        }
        var q = JSON.stringify(infor_role);
        $.ajax({
            type: 'Post',
            url: 'http://localhost:44383/api/roles',
            data: q,
            contentType: "application/json; charset=utf8",
            dataType: 'json',
            success: function (data) {
                alert("Success");
                load_data_role();
                clear_form_role();
            },
            error: function (data) {
                alert("Error");
                clear_form_role();
            }
        });
    } else {
    }
 }
function load_data_role() {
    $.ajax({
        method: "Get",
        url: 'http://localhost:44383/api/roles',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var content_table_role = "<tbody id='table_role'>"
            $.each(data, function (i, item) {
                content_table_role += "<tr id='content_tr'>"
                    + "<td>" + item.name + "</td>"
                    + "<td>" + item.status + "</td>"
                    + "<td class='td_hidden' id='id_role" + item.id + "'>" + item.id + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete' id='icon_delete_role' onclick='icon_delete_role(this);' data_id_delete_role='" + item.id + "'>"
                    + "<span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit' id='icon_edit_role' onclick='icon_edit_role(this);' data_id_edit_role='" + item.id + "'>"
                    + "<span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            });
            content_table_role += "</tbody>";
            $('#table_role').replaceWith(content_table_role);
        },
        error: function () {
            alert("error")
        }
    })
}
function icon_delete_role(a) {
    clear_label_role();
    var id = $(a).attr('data_id_delete_role');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/roles/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_role();
            clear_form_role();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}
function icon_edit_role(a) {
    clear_label_role();
    var id = $(a).attr('data_id_edit_role');
    $('#div_btn_edit_role').css('display', 'block');
    $('#div_btn_save_role').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/roles/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#id_role').val(data.id);
            $('#name_role').val(data.name);
            if (data.status == true) {
                $('#status_role').prop('checked', true);
            } else {
                $('#status_role').prop('checked', false);
            }
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_role').click(function () {
        $('#form_role').validate({
            rules: {
                name_role: "required",
            },
            messages: {
                name_role: "Please enter field !",
            }
        });
        if ($('#form_role').valid()) {
            var edit_role = new Object();
            var name_role = $('#name_role').val();
            var id_role = $('#id_role').val();
            edit_role.id = id_role;
            edit_role.name = name_role;
            var status_role = $('#status_role').prop('checked');
            if (status_role == true) {
                edit_role.status = true;
            } else {
                edit_role.status = false;
            }
            var q = JSON.stringify(edit_role);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/roles/' + edit_role.id,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_data_role();
                    clear_form_role();
                    $('#div_btn_edit_role').css('display', 'none');
                    $('#div_btn_save_role').css('display', 'block');
                    $('#div_btn_edit_role').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                    $('#div_btn_edit_role').css('display', 'none');
                    $('#div_btn_save_role').css('display', 'block');
                }
            })
        } else {

        }
    })
}
