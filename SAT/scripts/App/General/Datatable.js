$(document).ready(function () {
    $("table").css("width", "100%");
    $("table").removeClass().addClass("display");
    var x = $(".btn-success");
    x.removeClass();
    x.addClass("btn btn-info  btn-xs");

    var table = $("table,Table").DataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Registros a visualizar: _MENU_<br /><hr /> ",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "scrollX": true,
        dom: 'Bfrtip',
        buttons: {
            buttons: [
            { extend: 'copy', text: 'Copiar filas' },
            { extend: 'excel', text: 'Excel' },
            { extend: 'pdf', text: 'Pdf' },
            { extend: 'print', text: 'Imprimir' },
            { extend: 'colvis', text: 'Seleccionar columnas:' }
            ]
        }
    });
});