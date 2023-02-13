var Common = {
    init: function () {
        Common.registreEvent();
    },
    registreEvent: function () {
        $('#btnLogout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#frmLogout').submit();
        });
    }
}
Common.init();