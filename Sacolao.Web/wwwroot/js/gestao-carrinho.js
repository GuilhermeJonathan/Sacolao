(function (gestaoCarrinho, $) {
    "use strict";

    $(".btnAdicionarNoCarrinho").button().click(function () {
        var idFruta = $(this).attr("data-id");
        var qtd = $("#Qtd_" + idFruta).val();
        var estoque = $("#Estoque_" + idFruta).text();

        if (qtd <= 0) {
            sacolaoGeral.AdicionarMensagemDeErro("Deve-se informar a quantidade de itens.");
            return false;
        }

        if (parseInt(qtd) > parseInt(estoque)) {
            sacolaoGeral.AdicionarMensagemDeErro("Não há itens suficientes em estoque.");
            return false;
        }

        window.location.href = "/Carrinho/AdicionarNoCarrinho?id=" + idFruta + "&total=" + qtd;
    });

})(window.gestaoCarrinho = window.gestaoCarrinho || {}, jQuery)