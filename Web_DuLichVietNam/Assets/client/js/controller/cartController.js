var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click', function () {
            window.location.href = "/DiemDen/Index";
        });
    }
}
cart.init();