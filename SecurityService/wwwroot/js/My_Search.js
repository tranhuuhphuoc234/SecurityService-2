$(document).ready(function () {
    $("#search_view_about_us").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_view_about_us tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#search_service").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_service tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#search_trainning").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_trainning tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#search_role").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_role tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#search_grade").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_grade tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $("#search_speciality").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_speciality tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_client").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_check_service tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_employee").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_employee tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_feedback").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_feedback tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_region").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_region tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_department").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_department tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });


    $("#search_history").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_history tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_recruitment").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_recruitment tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $("#search_orderdetail").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table_orderdetail tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
}); 