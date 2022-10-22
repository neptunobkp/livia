$(document).ready(function() {
    $("#aspnetForm").validate();

    $('#panel-mensaje-popup').dialog({
        autoOpen: false,
        width: 600,
        bgiframe: false,
        modal: true,
        buttons: {
            "Aceptar": function() {
                $(this).dialog("close");
            }
        }
    });
});