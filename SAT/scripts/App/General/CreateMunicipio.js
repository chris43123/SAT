function pad2(number) {
    return (number < 10 ? '0' : '') + number
}

function FechaFormato(pFecha) {
    var fechaString = pFecha.substr(6);
    var fechaActual = new Date(parseInt(fechaString));
    var mes = fechaActual.getMonth() + 1;
    var dia = pad2(fechaActual.getDate());
    var anio = fechaActual.getFullYear();
    var hora = pad2(fechaActual.getHours());
    var minutos = pad2(fechaActual.getMinutes());
    var segundos = pad2(fechaActual.getSeconds().toString());
    var FechaFinal = dia + "/" + mes + "/" + anio + " " + hora + ":" + minutos + ":" + segundos;
    return FechaFinal;
}

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

$(document).on("click", "#tblIndexDep tbody tr td button#btnExpandir", function () {
    var dep = $(this).data('id');
    var fila = $("#fila-" + dep);
    console.log(dep);
    if (fila.css('display') == 'none') {
   
        fila.css('display', 'table-row');
        $(this).text('-');

    }
    else {
        fila.css('display', 'none');
        $(this).text('+');
    }

});

$(document).on("click", "#tlb tbody tr td input#EditarMunicipio", function () {
    var mun = $(this).closest('tr').data('id');
    $.ajax({
        url: "/Departamentos/_EditarMunicipio",
        method: "POST",
        dataType: "json",
        contentType: "application/json; charset = utf-8",
        data: JSON.stringify({ mun_Id: mun }),
    })
    .done(function (data) {
        if(data.length>0)
        {
            $.each(data, function(i, item){
                $("#modalEditarMun").modal();
                var Fecha = FechaFormato(item.mun_FechaCrea);
                console.log(Fecha);
                $("#mun_Descripcion").val(item.mun_Descripcion);
                $("#mun_Id").val(item.mun_Id);
            })
        }
        
    });
});

$("#btnGuardarMun").click(function () {
    var dataMun = $("#frmEditarMun").serializeArray();

    console.log("Hola", dataMun);
    $.ajax({
        url: "/Departamentos/UpdateMun",
        method: "POST",
        data: dataMun,
    });
});