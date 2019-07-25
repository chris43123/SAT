$("#btnAgregarGrados").click(function () {
    var IDGrados = $("#grad_Id").val();
    var grados = $("#grad_Descripcion").val();
    var newtr = "<tr data-id=" + grados + "><td>" + grados + "</td>";
    newtr += "<td><input type='button' class='btn btn-danger btn-xs' value='Quitar' id='Quitargrados'</td></tr>";

    var tbGradoss = {
        grad_Id: IDGrados,
        grad_Descripcion: grados
    };

    $.ajax({
        url: "/Jornadas/AgregarGrados",
        method: "POST",
        dataType: "json",
        contentType: "application/json; charset = utf-8",
        data: JSON.stringify({ tbGrado: tbGradoss }),
    });

    $("#tblGrados tbody").append(newtr);
    LimpiarControles();
});

$(document).on("click", "#tblGrados tbody tr td input#Quitargrados", function () {
    (this).closest('tr').remove();
    // el closest agarra el tr mas cerca
    var ID = $(this).closest('tr').data('id');


    $.ajax({
        url: "/Jornadas/AgregarGrados",
        method: "POST",
        dataType: "json",
        contentType: "application/json; charset = utf-8",
        data: JSON.stringify({ grad_Id: ID }),
    });
})


function LimpiarControles() {
    $("#jor_Descripcion").val("");
    $("#grad_Descripcion").val("");
    $("#grad_Descripcion").focus();
}


$(document).on("click", "#tblIndexJornada tbody tr td button#btnExpandir", function () {

    var jorId = $(this).data('id');
    var fila = $("#fila-" + jorId);

    if (fila.css('display') == 'none') {
        fila.css('display', 'table-row');
        $(this).text('-');
        $(this).removeClass('btn btn-primary btn-xs');
        $(this).addClass('btn btn-danger btn-xs');

    }
    else {
        fila.css('display', 'none');
        $(this).text('+');
        $(this).removeClass('btn btn-danger btn-xs');
        $(this).addClass('btn btn-primary btn-xs');
    }
});