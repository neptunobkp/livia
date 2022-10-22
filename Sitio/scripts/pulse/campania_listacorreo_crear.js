$(document).ready(function() {
    $("#tabs").tabs();
    $("#format_button").buttonset();
    
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