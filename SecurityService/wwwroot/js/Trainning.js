
    $('#div_btn_save_trainning').click(function () {
        $.validator.addMethod("valueNotEquals", function (value, element, arg) {
            return arg !== value;
        }, "Value must not equal arg.");
        $('#form_trainning').validate({
            ignore: [],
            rules: {
                name_trainning: "required",
                detail_trainning: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                },
                trainer_trainning: "required",
                select_duration: { valueNotEquals: "Choose_Duration" }
            },
            messages: {
                name_trainning: "Please enter field !",
                detail_trainning: {
                    required: "Please enter field !"
                },
                trainer_trainning: "Please enter field !",
                select_duration: { valueNotEquals: "Please select an item!" }
            }
        });
        CKEDITOR.instances.detail_trainning.on('change', function () {
            $('#detail_trainning-error').css("display", "none");
        });
        if ($('#form_trainning').valid()) {
            var infor_trainning = new Object();
            var name_trainning = $('#name_trainning').val();
            var content_detail = CKEDITOR.instances['detail_trainning'].getData();
            var trainers = $('#trainer_trainning').val();
            var content_duration = $('#select_duration option:selected').text();
            var status = $("#status_trainning").prop("checked");
            infor_trainning.name = name_trainning;
            infor_trainning.detail = content_detail;
            infor_trainning.duration = content_duration;
            infor_trainning.trainer = trainers;
            if (status == true) {
                infor_trainning.status = true;
            } else {
                infor_trainning.status = false;
            }
            var q = JSON.stringify(infor_trainning);
            $.ajax({
                type: 'Post',
                url: 'http://localhost:44383/api/trainnings',
                data: q,
                contentType: "application/json; charset=utf8",
                dataType: 'json',
                success: function (data) {
                    alert("Success");
                    clear_form_trainning();
                    load_data_trainning();
                },
                error: function (data) {
                    alert("Error");
                    clear_form_trainning();
                }
            });
        } else {

        }
    })
function load_data_trainning() {
    $.ajax({
        method: "Get",
        url: 'http://localhost:44383/api/trainnings',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var tr_trainning = "<tbody id='table_trainning'>"
            $.each(data, function (i, item) {
                tr_trainning += "<tr>"
                    + "<td>" + item.name + "</td>"
                    + "<td>" + item.detail + "</td>"
                    + "<td>" + item.duration + "</td>"
                    + "<td>" + item.trainer + "</td>"
                    + "<td>" + item.status + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete' onclick='icon_delete_trainning(this);' data_id_delete_trainning='" + item.id + "'>"
                    + "<span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit' onclick='icon_edit_trainning(this);' data_id_edit_trainning='" + item.id + "'>"
                    + "<span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            });
            tr_trainning += "</tbody>";
            $('#table_trainning').replaceWith(tr_trainning);
        },
        error: function () {
            alert("error")
        }
    })
}
function icon_delete_trainning(a) {
    clear_label_trainning();
    var id = $(a).attr('data_id_delete_trainning');
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/trainnings/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_trainning();
            clear_form_trainning();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}
function icon_edit_trainning(a) {
    clear_label_trainning();
    $("#select_duration option:selected").removeAttr("selected");
    var id = $(a).attr('data_id_edit_trainning');
    $('#div_btn_edit_trainning').css('display', 'block');
    $('#div_btn_save_trainning').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/trainnings/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#id_trainning').val(data.id);
            $('#name_trainning').val(data.name);
            $("#select_duration option[data-value=" + JSON.stringify(data.duration) + "]").attr("selected", "selected");
            $('#trainer_trainning').val(data.trainer);
            CKEDITOR.instances.detail_trainning.setData(data.detail);
            if (data.status == true) {
                $('#status_trainning').prop('checked', true);
            } else {
                $('#status_trainning').prop('checked', false);
            }
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_trainning').click(function () {
        $.validator.addMethod("valueNotEquals", function (value, element, arg) {
            return arg !== value;
        }, "Value must not equal arg.");
        $('#form_trainning').validate({
            ignore: [],
            rules: {
                name_trainning: "required",
                detail_trainning: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                },
                trainer_trainning: "required",
                select_duration: { valueNotEquals: "Choose_Duration" }
            },
            messages: {
                name_trainning: "Please enter field !",
                detail_trainning: {
                    required: "Please enter field !"
                },
                trainer_trainning: "Please enter field !",
                select_duration: { valueNotEquals: "Please select an item!" }
            }
        });
        CKEDITOR.instances.detail_trainning.on('change', function () {
            $('#detail_trainning-error').css("display", "none");
        });
        if ($('#form_trainning').valid()) {
            var edit_trainning = new Object();
            var name_trainning = $('#name_trainning').val();
            var id_trainning = $('#id_trainning').val();
            var trainer = $('#trainer_trainning').val();
            var duration = $('#select_duration option:selected').text();
            var detail = CKEDITOR.instances['detail_trainning'].getData();
            edit_trainning.trainer = trainer;
            edit_trainning.id = id_trainning;
            edit_trainning.name = name_trainning;
            edit_trainning.duration = duration;
            edit_trainning.detail = detail;
            var status_trainning = $('#status_trainning').prop('checked');
            if (status_trainning == true) {
                edit_trainning.status = true;
            } else {
                edit_trainning.status = false;
            }
            var q = JSON.stringify(edit_trainning);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/trainnings/' + edit_trainning.id,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_data_trainning();
                    clear_form_trainning();
                    $('#div_btn_edit_trainning').css('display', 'none');
                    $('#div_btn_save_trainning').css('display', 'block');
                    $('#div_btn_edit_trainning').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                    $('#div_btn_edit_trainning').css('display', 'none');
                    $('#div_btn_save_trainning').css('display', 'block');
                }
            })
        }
    })
}

