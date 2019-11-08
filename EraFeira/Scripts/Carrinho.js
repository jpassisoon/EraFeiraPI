//$(document).ready(function () {

//    //-- Clique para adicionar ou retirar
//    $(".btn-menos").on("click", function () {
//        var id = "#input_" + $(this).attr("produtoID");
//        //alert(id);
//        var now = $(id).val();
//        if ($.isNumeric(now)) {
//            if (parseInt(now) - 1 >= 0) { now--; }
//            $(id).val(now);

//            soma();
//        } else {
//            $(id).val("0");
//        }
//    })
//    $(".btn-mais").on("click", function () {
//        var id = "#input_" + $(this).attr("produtoID");
//        var idH = "#h_" + $(this).attr("produtoID");

//        //alert(id);
//        //alert($(idH).attr("valor"));
//        var now = $(id).val();
//        if ($.isNumeric(now)) {
//            $(id).val(parseInt(now) + 1);

//            soma();
//        } else {
//            $(id).val("0");
//        }
//    });

//    function soma() {
//        var valor = parseFloat(0);
//        $(".car-quantidade").each(function () {
//            var pro = "#" + $(this).attr("produtoID");
//            var preco = parseFloat($(pro).attr("valor").replace(',', '.'));

//            valor = valor + parseFloat(($(this).val() * preco));

//            //alert(pro + " - " + preco + " - " + valor);
//        });
//        $(".carrinho").text(valor.toFixed(2));
//    }

//    // document.cookie = "ItensCesta = " + JSON.stringify(cestaCookie);
//})