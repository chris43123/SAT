$("#btnAgregarMunicipio").click(function () {
    var IDMunicipio = $("#mun_Id").val();
    var Municipio = $("#mun_Descripcion").val();

    var newTr = "<tr><td data-id=" + Municipio + ">" + IDMunicipio + "</td>"
    newTr += "<td>" + Municipio + "</td>"
    newTr += "<td><input type='button' class='btn btn-danger btn-xs' value='-' id='btnRetirarMunicipio' /></td></tr>"

    var tbMunicipio = {
        mun_Id: IDMunicipio,
        mun_Descripcion: Municipio
    }

    $.ajax({
        url: "/Departamentos/AgregarMunicipio",
        method: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ tbMunicipio: tbMunicipio}),
    });
    $("#tblMunicipios ").append(newTr);
    LimpiarControles();
});
$(document).on("click", "#tblMunicipios tbody tr td input#btnRetirarMunicipio", function () {
    $(this).closest('tr').remove();
});
function LimpiarControles(){
    $("#mun_Id").val("");
    $("#mun_Descripcion").val("");
    $("#mun_Id").focus();
}
function mayus(e) {
    e.value = e.value.toUpperCase();
}