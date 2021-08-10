(function (sacolaoGeral, $) {
    "use strict";

    sacolaoGeral.AdicionarMensagemDeSucesso = function (mensagem) {
        toastr.options = {
            "closeButton": true,
            "progressBar": true,
            "positionClass": "toast-top-right"
        };

        toastr.success(mensagem, "Sucesso");
    };

    sacolaoGeral.AdicionarMensagemDeErro = function (mensagem) {
        toastr.options = {
            "closeButton": true,
            "progressBar": true,
            "positionClass": "toast-top-right"
        };
        toastr.error(mensagem, "OPS! Algo deu errado");
    };     

})(window.sacolaoGeral = window.sacolaoGeral || {}, jQuery)