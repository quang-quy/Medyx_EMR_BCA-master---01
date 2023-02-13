/// <reference path="../admin/libs/jquery/dist/jquery.min.js" />

/// <reference path="../lib/vitalets-bootstrap-datepicker-c7af15b/js/bootstrap-datepicker.js" />
/// <reference path="jquery.mask.js" />
/// <reference path="Extention.js" />

var Init = {
    init: function () {
        $.fn.datepicker.dates['vi'] = {
            days: ["Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7"],
            daysShort: ["C.Nhật", "T.Hai", "T.Ba", "T.Tư", "T.Năm", "T.Sáu", "T.Bảy"],
            daysMin: ["CN", "T2", "T3", "T4", "T5", "T6", "T7"],
            months: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
            monthsShort: ["Th.Một", "Th.Hai", "Th.3", "Th.4", "Th.5", "Th.6", "Th.7", "Th.8", "Th.9", "Th.10", "Th.11", "Th.12"],
            today: "Hôm nay",
            clear: "Clear",
            format: "dd/mm/yyyy",
            titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
            weekStart: 0
        };
        $('.datepicker').datepicker({
            language: 'vi', autoclose: true,
            format: "dd/mm/yyyy"

        }).focus(function () {
            $(this).mask('00/00/0000');
            $(this).placeholder = "dd/MM/yyyy";
        });
        $(".float").mask("99.99");
        $(".age").mask("999");
        $(".number").mask("9999");// Đang để max là 4 chữ số :(
        $(".HuyetAp").mask("999/999");
        $('.money').mask('000.000.000.000.000,00', { reverse: true });
        $('.money2').mask("#.##0,00", { reverse: true });
        $('.time').mask("00:00", {placeholder: "__:__"});
        //XX-X-XX-XX-XXX-XXXXX
        $('.TheBHYT').mask("AA-9-99-99-AAA-99999", { placeholder: "__-_-__-__-___-_____" });
        Init.regesterEvent();
        $('.datepicker').focus(function () {
            $(this).select();
        });
        $('.select2').focus(function () {
            $(this).select();
        });
    },
    regesterEvent: function () {
        $('.TheBHYT').blur(function () {
            Extention.validaterTheBaoHiemYTe();
          
        });
        $('.TheBHYT').change(function () {
            // console.log('Đang nhập...');
            var str = $(this).val();
            var res = str.toLocaleUpperCase();
           
            $(this).val(res);
        });
        function parseDate(str) {
            var mdy = str.split('/');
            return new Date(mdy[2], mdy[1], mdy[0]);
        }
        //kiểm tra ngày bắt đầu
        $('.checkTuNgay').change(function () {
            var tuNgay = $('.checkTuNgay').val();
            var toDay = Extention.GetCurrentDateFormat();
            var startDate = parseDate(tuNgay).getTime();
            re = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/;
            if (tuNgay != '') {
                if (regs = tuNgay.match(re)) {
                    if (regs[1] < 1 || regs[1] > 31) {
                        Extention.displayMessageError("Ngày nhập không đúng: " + regs[1]);
                        //alert("Ngày nhập không đúng: " + regs[1]);
                        $('.checkTuNgay').removeClass('successValidator').addClass('WarningValidator');
                        $('.checkTuNgay').focus();
                        return false;
                    }
                    if (regs[2] < 1 || regs[2] > 12) {
                        $('.checkTuNgay').focus();
                        Extention.displayMessageError("Tháng nhập không đúng: " + regs[2]);
                        //alert("Tháng nhập không đúng: " + regs[2]);
                        $('.checkTuNgay').removeClass('successValidator').addClass('WarningValidator');
                        return false;
                    }
                    if (regs[3] < 1900 || regs[3] > (new Date()).getFullYear()) {
                        Extention.displayMessageError("Năm không đúng: " + regs[3] + " - Năm nằm trong khoảng từ 1900 đến " + (new Date()).getFullYear());
                        //alert("Năm không đúng: " + regs[3] + " - Năm nằm trong khoảng từ 1900 đến " + (new Date()).getFullYear());
                        $('.checkTuNgay').removeClass('successValidator').addClass('WarningValidator');
                        $('.checkTuNgay').focus();
                        return false;
                    }
                } else {
                    Extention.displayMessageError("Sai định dạng ngày tháng: " + tuNgay);
                    //alert("Sai định dạng ngày tháng: " + tuNgay);
                    $('.checkTuNgay').removeClass('successValidator').addClass('WarningValidator');
                    return false;
                }
                if (startDate > toDay) {
                    Extention.displayMessageError("Ngày bắt đầu phải trước ngày hiện tại");
                    //alert('Ngày bắt đầu phải trước ngày hiện tại');
                    $('.checkTuNgay').focus();
                    return false;
                }
            }
            $('.checkTuNgay').removeClass('WarningValidator').addClass('successValidator');
            return true;
        });

        //Kiểm tra ngày kết thúc
        $('.checkDenNgay').change(function () {
            var denNgay = $('.checkDenNgay').val();
            var tuNgay = $('.checkTuNgay').val();
            var startDate = parseDate(tuNgay).getTime();
            var endDate = parseDate(denNgay).getTime();
            re = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/;
            if (denNgay != '') {
                if (regs = denNgay.match(re)) {
                    if (regs[1] < 1 || regs[1] > 31) {
                        Extention.displayMessageError("Ngày nhập không đúng: " + regs[1]);
                        $('.checkDenNgay').removeClass('successValidator').addClass('WarningValidator');
                        $('.checkDenNgay').focus();
                        return false;
                    }
                    if (regs[2] < 1 || regs[2] > 12) {
                        $('.checkDenNgay').focus();
                        Extention.displayMessageError("Tháng nhập không đúng: " + regs[2]);
                        $('.checkDenNgay').removeClass('successValidator').addClass('WarningValidator');
                        return false;
                    }
                    if (regs[3] < 1900 || regs[3] > (new Date()).getFullYear()) {
                        Extention.displayMessageError("Năm không đúng: " + regs[3] + " - Năm nằm trong khoảng từ 1900 đến " + (new Date()).getFullYear());
                        $('.checkDenNgay').removeClass('successValidator').addClass('WarningValidator');
                        $('.checkDenNgay').focus();
                        return false;
                    }
                } else {
                    Extention.displayMessageError("Sai định dạng ngày tháng: " + denNgay);
                    $('.checkDenNgay').removeClass('successValidator').addClass('WarningValidator');
                    return false;
                }
                if (startDate > endDate) {
                    Extention.displayMessageError("Ngày kết thức phải sau ngày bắt đầu");
                    $('.checkDenNgay').focus();
                    return false;
                }
            }
            $('.checkDenNgay').removeClass('WarningValidator').addClass('successValidator');
            return true;
        });

        // Kiểm tra chỉ cho phép nhập số
        $('.numeric').keypress(function (evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                Extention.displayMessageError('Chỉ cho phép nhập số!');
                return false;
            }
            return true;
        });

        //Chỉ cho phép nhập số 
        $('.checkNumber').keypress(function (evt) {
            if (window.event.keyCode < 48 || 57 < window.event.keyCode) {
                Extention.displayMessageError("Chỉ cho phép nhập số");
                return false;
            }
            return true;
        });

        //Kiểm tra ngày đến khám 
        $('#txtNgayDK').change(function () {
            var ngayDK = $('#txtNgayDK').val();
            var ngayHT = Extention.GetCurrentDateFormat();
            re = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/;
            if (ngayDK != '') {
                if (regs = ngayDK.match(re)) {
                    if (regs[1] < 1 || regs[1] > 31) {
                        Extention.displayMessageError("Ngày ĐK nhập không đúng: " + regs[1]);
                        $('#txtNgayDK').removeClass('successValidator').addClass('WarningValidator');
                        $('#txtNgayDK').focus();
                        return false;
                    }
                    if (regs[2] < 1 || regs[2] > 12) {
                        $('#txtNgayDK').focus();
                        Extention.displayMessageError("Tháng ĐK nhập không đúng: " + regs[2]);
                        $('#txtNgayDK').removeClass('successValidator').addClass('WarningValidator');
                        return false;
                    }
                    if (regs[3] < 1900 || regs[3] > (new Date()).getFullYear()) {
                        Extention.displayMessageError("Năm không đúng: " + regs[3] + " - Năm nằm trong khoảng từ 1900 đến " + (new Date()).getFullYear());
                        $('#txtNgayDK').removeClass('successValidator').addClass('WarningValidator');
                        $('#txtNgayDK').focus();
                        return false;
                    }
                } else {
                    Extention.displayMessageError("Sai định dạng ngày tháng: " + denNgay);
                    $('#txtNgayDK').removeClass('successValidator').addClass('WarningValidator');
                    return false;
                }
                var applyDate = parseDate(ngayDK).getTime();
                var currentDate = parseDate(ngayHT).getTime();
                console.log(ngayDK + '  ' + ngayHT);
                console.log(applyDate + '  ' + currentDate);
                console.log(applyDate - currentDate);
                if (applyDate < currentDate) {
                    Extention.displayMessageError("Ngày ĐK không được trước ngày hiện tại!");
                    $('#txtNgayDK').focus();
                    return false;
                }
            }
            $('#txtNgayDK').removeClass('WarningValidator').addClass('successValidator');
            return true;
        });
    }
}
Init.init();