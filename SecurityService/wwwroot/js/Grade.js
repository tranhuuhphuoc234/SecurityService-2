
function btn_save_grade() {
    $('#form_grade').validate({
        rules: {
            name_grade: "required",
        },
        messages: {
            name_grade: "Please enter field !",
        }
    });
    if ($('#form_grade').valid()) {
        var infor_grade = new Object();
        var name_grade = $('#name_grade').val();
        var status = $("#status_grade").prop("checked");
        infor_grade.name = name_grade;
        if (status == true) {
            infor_grade.status = true;
        } else {
            infor_grade.status = false;
        }
        var q = JSON.stringify(infor_grade);
        $.ajax({
            type: 'Post',
            url: 'http://localhost:44383/api/grades',
            data: q,
            contentType: "application/json; charset=utf8",
            dataType: 'json',
            success: function (data) {
                alert("Success");
                clear_form_grade();
                load_data_grade();
            },
            error: function (data) {
                alert("Error");
                clear_form_grade();
            }
        });
    } else {
            
    }
        
    }
function load_data_grade() {
    $.ajax({
        method: "Get",
        url: 'http://localhost:44383/api/grades',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var content_table_grade = "<tbody id='table_grade'>"
            $.each(data, function (i, item) {
                content_table_grade += "<tr id='content_tr'>"
                    + "<td class='td_hidden' id='id_grade" + item.id + "'>" + item.id + "</td>"
                    + "<td>" + item.name + "</td>"
                    + "<td>" + item.status + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete' onclick='icon_delete_grade(this);' data_id_delete_grade='" + item.id + "'>"
                    + "<span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit' onclick='icon_edit_grade(this);' data_id_edit_grade='" + item.id + "'>"
                    + "<span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            });
            content_table_grade += "</tbody>";
            $('#table_grade').replaceWith(content_table_grade);
        },
        error: function () {
            alert("error")
        }
    })
}
function icon_delete_grade(a) {
    clear_label_grade();
    var id = $(a).attr('data_id_delete_grade');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/grades/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_grade();
            clear_form_grade();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}
function icon_edit_grade(a) {
    clear_label_grade();
    var id = $(a).attr('data_id_edit_grade');
    $('#div_btn_edit_grade').css('display', 'block');
    $('#div_btn_save_grade').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/grades/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#id_grade').val(data.id);
            $('#name_grade').val(data.name);
            if (data.status == true) {
                $('#status_grade').prop('checked', true);
            } else {
                $('#status_grade').prop('checked', false);
            }
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_grade').click(function () {
        $('#form_grade').validate({
            rules: {
                name_grade: "required",
            },
            messages: {
                name_grade: "Please enter field !",
            }
        });
        if ($('#form_grade').valid()) {
            var edit_grade = new Object();
            var name_grade = $('#name_grade').val();
            var id_grade = $('#id_grade').val();
            edit_grade.id = id_grade;
            edit_grade.name = name_grade;
            var status_grade = $('#status_grade').prop('checked');
            if (status_grade == true) {
                edit_grade.status = true;
            } else {
                edit_grade.status = false;
            }
            var q = JSON.stringify(edit_grade);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/grades/' + edit_grade.id,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_data_grade();
                    clear_form_grade();
                    $('#div_btn_edit_grade').css('display', 'none');
                    $('#div_btn_save_grade').css('display', 'block');
                    $('#div_btn_edit_grade').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                    $('#div_btn_edit_grade').css('display', 'none');
                    $('#div_btn_save_grade').css('display', 'block');
                }
            })
        } else {

        }
       
    })
}