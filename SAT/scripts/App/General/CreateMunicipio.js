$("#btnAgregarMunicipio").click(function () {
    var IDmunicipios = $("#mun_Id").val();
    var municipio = $("#mun_Descripcion").val();
    var newtr = "<tr data-id="+IDmunicipios+"><td>" + IDmunicipios + "</td>";
        newtr +="<td>" + municipio + "</td>";
        newtr+="<td><input type='button' class='btn btn-danger btn-xs' value='Quitar' id='Quitarmunicipios'</td></tr>";

     var tbMunicipio = {
        mun_Id: IDmunicipios,
        mun_Descripcion: municipio

        };

        $.ajax({
         url: "/Departamentos/AgregarMunicipio",
         method: "POST",
         dataType: "json",
         contentType: "application/json; charset = utf-8",
         data: JSON.stringify({tbMunicipio: tbMunicipio}),
        });



    $("#tblMunicipios tbody").append(newtr);
    LimpiarControles();

     });

$(document).on("click", "#tblMunicipios tbody tr td input#Quitarmunicipios", function () {
    (this).closest('tr').remove();
    // el closest agarra el tr mas cerca
    var ID = $(this).closest('tr').data('id');


})

function LimpiarControles()
{
    $("#mun_Id").val("");
    $("#mun_Descripcion").val("");
    $("#mun_id").focus();

}

/* Otra manera de usar un button y no iput siempre funciona.
newtr += "<td><button type='button' class='btn btn-danger btn-xs'  id='Quitarmunicipios'>Quitar</button></td></tr>";
*/