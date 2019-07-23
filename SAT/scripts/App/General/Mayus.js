$(document).ready(function () {

    $("input[type=text]").keyup(function () {
        $(this).val($(this).val().toUpperCase());
    });
});