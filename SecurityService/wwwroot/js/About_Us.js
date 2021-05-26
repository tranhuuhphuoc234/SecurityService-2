    
function btn_save_about_us() {
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");
    $('#form_about_us').validate({
        ignore: [],
        rules: {
            where_aboutus: {
                required: function (textarea) {
                    CKEDITOR.instances[textarea.id].updateElement();
                    var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                    return editorcontent.length === 0;
                }
            },
            when_aboutus: {
                required: function (textarea) {
                    CKEDITOR.instances[textarea.id].updateElement();
                    var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                    return editorcontent.length === 0;
                }
            }, how_aboutus: {
                required: function (textarea) {
                    CKEDITOR.instances[textarea.id].updateElement();
                    var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                    return editorcontent.length === 0;
                }
            }
        },
        messages: {

            where_aboutus: {
                required: "Please enter field !"
            },
            when_aboutus: {
                required: "Please enter field !"
            },
            how_aboutus: {
                required: "Please enter field !"
            }
        }
    });
    CKEDITOR.instances.description_service.on('change', function () {
        $('#where_aboutus-error').css("display", "none");
        $('#when_aboutus-error').css("display", "none");
        $('#how_aboutus-error').css("display", "none");
    });
    if ($('#form_about_us').valid()) {
        var infor_aboutus = new Object();
        var content_where = CKEDITOR.instances['where_aboutus'].getData();
        var content_when = CKEDITOR.instances['when_aboutus'].getData();
        var content_how = CKEDITOR.instances['how_aboutus'].getData();
        infor_aboutus.where = content_where;
        infor_aboutus.when = content_when;
        infor_aboutus.how = content_how;
        var q = JSON.stringify(infor_aboutus);
        $.ajax({
            type: 'Post',
            url: 'http://localhost:44383/api/about_us',
            data: q,
            contentType: "application/json; charset=utf8",
            dataType: 'json',
            success: function (data) {
                alert("Success");
            },
            error: function (data) {
                alert("Error");
            }
        });

    } else {

    }
}
function load_data_about_us() {
    $.ajax({
        method: "Get",
        url: "http://localhost:44383/api/about_us",
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var about_us = "<tbody id='table_view_about_us'>"
            $.each(data, function (i, item) {
                about_us += "<tr>"
                    + "<td>" + item.where + "</td>"
                    + "<td>" + item.when + "</td>"
                    + "<td>" + item.how + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete'  onclick='icon_delete_about_us(this);' data_id_delete_about_us='" + item.id + "'>"
                    + " <span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit'  onclick='icon_edit_about_us(this);' data_id_edit_about_us='" + item.id + "'>"
                    + " <span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            })
            about_us += "</tbody>";
            $('#table_view_about_us').replaceWith(about_us);
        },
        error: function (data) {
            alert("Erorr");
        }

    })
}
function icon_delete_about_us(a) {
    var id = $(a).attr('data_id_delete_about_us');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/about_us/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_about_us();
            clear_form_about_us();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}
function icon_edit_about_us(a) {
    $('#content_about_us').css('display', 'block');
    $('#view_table_about_us').css('display', 'none');
    var id = $(a).attr('data_id_edit_about_us');
    $('#div_btn_edit_about_us').css('display', 'block');
    $('#div_btn_edit_about_us').css('float', 'left');
    $('#div_btn_view_about_us').css('float', 'left');
    $('#div_btn_save_about_us').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/about_us/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            CKEDITOR.instances.where_aboutus.setData(data.where);
            CKEDITOR.instances.when_aboutus.setData(data.when);
            CKEDITOR.instances.how_aboutus.setData(data.how);
            $('#id_about_us').val(data.id);
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_about_us').click(function () {
        $.validator.addMethod("valueNotEquals", function (value, element, arg) {
            return arg !== value;
        }, "Value must not equal arg.");
        $('#form_about_us').validate({
            ignore: [],
            rules: {
                where_aboutus: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                },
                when_aboutus: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                }, how_aboutus: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                }
            },
            messages: {

                where_aboutus: {
                    required: "Please enter field !"
                },
                when_aboutus: {
                    required: "Please enter field !"
                },
                how_aboutus: {
                    required: "Please enter field !"
                }
            }
        });
        CKEDITOR.instances.description_service.on('change', function () {
            $('#where_aboutus-error').css("display", "none");
            $('#when_aboutus-error').css("display", "none");
            $('#how_aboutus-error').css("display", "none");
        });
        if ($('#form_about_us').valid()) {
            var edit_about_us = new Object();
            var where_about_us = CKEDITOR.instances['where_aboutus'].getData();
            var when_about_us = CKEDITOR.instances['when_aboutus'].getData();
            var how_about_us = CKEDITOR.instances['how_aboutus'].getData();
            var id_about_us = $('#id_about_us').val();
            edit_about_us.id = id_about_us;
            edit_about_us.where = where_about_us;
            edit_about_us.when = when_about_us;
            edit_about_us.how = how_about_us;

            var q = JSON.stringify(edit_about_us);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/about_us/' + edit_about_us.id,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_data_about_us();
                    clear_form_about_us();
                    $('#div_btn_edit_about_us').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                }
            })
        } else {
        }
    })
}
