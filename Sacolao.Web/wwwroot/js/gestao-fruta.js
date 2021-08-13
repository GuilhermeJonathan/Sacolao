(function (gestaoFruta, $) {
    "use strict";

    $(".btnExcluirFruta").button().click(function () {
        var idFruta = $(this).attr("data-id");
        $(".Id").val(idFruta);

        var form = $("#modalConfirmacao");
        $(".btnConfirmacao").attr('href', '/Fruta/Excluir/' + idFruta);
        form.modal('show');
    });

})(window.gestaoFruta = window.gestaoFruta || {}, jQuery)