$(document).ready(function () {

    //-- Clique para adicionar ou retirar
    $(".btn-menos").on("click", function () {
        var id = "input_"+$(this).attr("produtoID");
        var now = $(id).val();
        if ($.isNumeric(now)) {
            if (parseInt(now) - 1 >= 0) { now--; }
            $(id).val(now);
        } else {
            $(id).val("0");
        }
    })
    $(".btn-mais").on("click", function () {
        var id = "input_" + $(this).attr("produtoID");
        var now = $(id).val();
        if ($.isNumeric(now)) {
            $(id).val(parseInt(now) + 1);
        } else {
            $(id).val("0");
        }
    })
})