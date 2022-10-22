$(document).ready(function() {

    $('#ctl00_content_body_linkTab2').hide();
    $('#ctl00_content_body_linkTab3').hide();
    $('#ctl00_content_body_linkTab4').hide();

    $("#tabs").tabs().addClass('ui-tabs-vertical ui-helper-clearfix');
    $("#tabs li").removeClass('ui-corner-top').addClass('ui-corner-left');

    $("input[name='ctl00$content_body$radiButtonListNumeroPaginas']").change(function() {
        if ($("input[name='ctl00$content_body$radiButtonListNumeroPaginas']:checked").val() == '1') {
            $('#ctl00_content_body_linkTab2').hide("Drop");
            $('#ctl00_content_body_linkTab3').hide("Drop");
            $('#ctl00_content_body_linkTab4').hide("Drop");
            $('#tabs').tabs({
                selected: 0
            });
        }
        else if ($("input[name='ctl00$content_body$radiButtonListNumeroPaginas']:checked").val() == '2') {
            $('#ctl00_content_body_linkTab2').show("Drop");
            $('#ctl00_content_body_linkTab3').hide("Drop");
            $('#ctl00_content_body_linkTab4').hide("Drop");
            $('#tabs').tabs({
                selected: 0
            });
        }
        else if ($("input[name='ctl00$content_body$radiButtonListNumeroPaginas']:checked").val() == '3') {
            $('#ctl00_content_body_linkTab2').show("Drop");
            $('#ctl00_content_body_linkTab3').show("Drop");
            $('#ctl00_content_body_linkTab4').hide("Drop");
            $('#tabs').tabs({
                selected: 0
            });
        }
        else if ($("input[name='ctl00$content_body$radiButtonListNumeroPaginas']:checked").val() == '4') {
            $('#ctl00_content_body_linkTab2').show("Drop");
            $('#ctl00_content_body_linkTab3').show("Drop");
            $('#ctl00_content_body_linkTab4').show("Drop");
            $('#tabs').tabs({
                selected: 0
            });
        }
    });
    $("#ctl00_content_body_radiButtonListNumeroPaginas").buttonset();

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