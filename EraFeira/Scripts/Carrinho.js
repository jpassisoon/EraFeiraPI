//var cesta = [];
//var idProduto;
//var quantidade;

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

//    // Calcula o valor da cesta
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

//    // funcao para calcular o carrinho
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

//    // identificar a quantidade e o id dos produtos > 0
//    // Varrer os elementos input
//    // Verificar se os inputs possuem um value maior > 0
//    // adicionar o id do produto + o valor dentro do cookie
//    var i = 0;
//    $(".btn-next").click(function () {

//        var dados = []

//        $(".car-quantidade").each(function () {
//            if (!isNaN(this.value)) {

//                dados[i] = this.id + "Quantidade = " + this.value
//                i++

//            };

//        })
//        document.cookie = "CarrinhoCookie = " + JSON.stringify(dados);

//    });
//})