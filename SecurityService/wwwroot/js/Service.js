
$('#div_btn_save_service').click(function () {
        $.validator.addMethod("valueNotEquals", function (value, element, arg) {
            return arg !== value;
        }, "Value must not equal arg.");
        $('#form_service').validate({
            ignore: [],
            rules: {
                name_service: "required",
                price_service: {
                    required: true,
                    number: true
                },
                description_service: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                }
            },
            messages: {
                name_service: "Please enter field !",
                price_service: {
                    required: "Please enter field !",
                    number: "This is not the price !"
                },
                description_service: {
                    required: "Please enter field !"
                },
            }
        });
        CKEDITOR.instances.description_service.on('change', function () {
            $('#description_service-error').css("display", "none");
        });
        if ($('#form_service').valid()) {
            var infor_service = new Object();
            var name_service = $('#name_service').val();
            var price_service = $('#price_service').val();
            var status = $("#status_service").prop("checked");
            var description = CKEDITOR.instances['description_service'].getData();

            infor_service.price = price_service;
            infor_service.description = description;
            infor_service.name = name_service;
            if (status == true) {
                infor_service.status = true;
            } else {
                infor_service.status = false;
            }
            var q = JSON.stringify(infor_service);
            $.ajax({
                type: 'Post',
                url: 'http://localhost:44383/api/services',
                data: q,
                contentType: "application/json; charset=utf8",
                dataType: 'json',
                success: function (data) {
                    alert("Success");
                    clear_form_service();
                    load_data_service();
                },
                error: function (data) {
                    clear_form_service();
                }
            });
        } else {


        }
    })
function load_data_service() {
    $.ajax({
        method: "Get",
        url: 'http://localhost:44383/api/services',
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            var tr_service = "<tbody id='table_service'>"
            $.each(data, function (i, item) {
                tr_service += "<tr>"
                    + "<td class='td_hidden' id='id_service" + item.id + "'>" + item.id + "</td>"
                    + "<td>" + item.name + "</td>"
                    + "<td>" + item.price + "</td>"
                    + "<td>" + item.description + "</td>"
                    + "<td>" + item.status + "</td>"
                    + "<td>"
                    + "<div class='div_icon_delete' onclick='icon_delete_service(this);' data_id_delete_service='" + item.id + "'>"
                    + "<span><i class='fa fa-trash'></i></span>"
                    + "</div>"
                    + "<div class='div_icon_edit' onclick='icon_edit_service(this);' data_id_edit_service='" + item.id + "'>"
                    + "<span><i class='fa fa-edit'></i></span>"
                    + "</div>"
                    + "</td>"
                    + "</tr>"
            });
            tr_service += "</tbody>";
            $('#table_service').replaceWith(tr_service);
        },
        error: function () {
            alert("error")
        }
    })
}
function icon_delete_service(a) {
    clear_label_service();
    var id = $(a).attr('data_id_delete_service');
    alert(id);
    $.ajax({
        type: "Delete",
        url: 'http://localhost:44383/api/services/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            alert("Success");
            load_data_service();
            clear_form_service();
        }, error: function (data) {
            alert("Erorr");
        }
    })
}
function icon_edit_service(a) {
    clear_label_service();
    var id = $(a).attr('data_id_edit_service');
    $('#div_btn_edit_service').css('display', 'block');
    $('#div_btn_save_service').css('display', 'none');
    $.ajax({
        type: "Get",
        url: 'http://localhost:44383/api/services/' + id,
        dataType: 'json',
        contentType: "application/json, charset=utf8",
        success: function (data) {
            JSON.stringify(data);
            $('#id_service').val(data.id);
            $('#name_service').val(data.name);
            $('#price_service').val(data.price);
            CKEDITOR.instances.description_service.setData(data.description);
            if (data.status == true) {
                $('#status_service').prop('checked', true);
            } else {
                $('#status_service').prop('checked', false);
            }
        }, error: function (data) {
            alert("Erorr");
        }
    });

    $('#div_btn_edit_service').click(function () {
        $.validator.addMethod("valueNotEquals", function (value, element, arg) {
            return arg !== value;
        }, "Value must not equal arg.");
        $('#form_service').validate({
            ignore: [],
            rules: {
                name_service: "required",
                price_service: {
                    required: true,
                    number: true
                },
                description_service: {
                    required: function (textarea) {
                        CKEDITOR.instances[textarea.id].updateElement();
                        var editorcontent = textarea.value.replace(/<[^>]*>/gi, '');
                        return editorcontent.length === 0;
                    }
                }
            },
            messages: {
                name_service: "Please enter field !",
                price_service: {
                    required: "Please enter field !",
                    number: "This is not the price !"
                },
                description_service: {
                    required: "Please enter field !"
                }
            }
        });
        CKEDITOR.instances.description_service.on('change', function () {
            $('#description_service-error').css("display", "none");
        });
        if ($('#form_service').valid()) {
            var edit_service = new Object();
            var name_service = $('#name_service').val();
            var price_service = $('#price_service').val();
            var id_service = $('#id_service').val();
            var description = CKEDITOR.instances['description_service'].getData();
            edit_service.id = id_service;
            edit_service.name = name_service;
            edit_service.price = price_service;
            edit_service.description = description;
            var status_service = $('#status_service').prop('checked');
            if (status_service == true) {
                edit_service.status = true;
            } else {
                edit_service.status = false;
            }
            var q = JSON.stringify(edit_service);
            $.ajax({
                type: "Put",
                url: 'http://localhost:44383/api/services/' + edit_service.id,
                data: q,
                dataType: 'json',
                contentType: "application/json, charset=utf8",
                success: function (data) {
                    alert("Success");
                    load_data_service();
                    clear_form_service();
                    $('#div_btn_edit_service').off('click');
                },
                erorr: function (data) {
                    alert("Erorr")
                }
            })
        } else {

        }

    })
}