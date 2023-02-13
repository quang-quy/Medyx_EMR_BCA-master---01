/// <reference path="../client/select2Jsonp/jquery-2.0.3.js" />

/// <reference path="../../admin/libs/jquery-ui/ui/widgets/datepicker.js" />

var Extention = {
    /* Truyền vào 1 Json Date Convert ra 1 string format dd/MM/yyyy */
    ConvertJsonDateToStringFormat: function (jsonDate) {
        //var newDate = dateFormat(jsonDate, "dd/MM/yyyy");
        var date = new Date(parseInt(jsonDate.substr(6)));
        var dd = date.getDate();
        if (dd <= 9)
            dd = '0' + dd.toString();
        var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        if (MM <= 9)
            MM = '0' + MM.toString();
        var yyyy = date.getFullYear();
        return dd + '/' + MM + '/' + yyyy;
    },

    /* Truyền vào 1 Json Date Convert ra 1 string format MM/dd/yyyy */
    ConvertJsonDateToStringFormatMMddyyyy: function (jsonDate) {
        //var newDate = dateFormat(jsonDate, "dd/MM/yyyy");
        var date = new Date(parseInt(jsonDate.substr(6)));
        var dd = date.getDate();
        if (dd <= 9)
            dd = '0' + dd.toString();
        var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        if (MM <= 9)
            MM = '0' + MM.toString();
        var yyyy = date.getFullYear();
        return MM + '/' + dd + '/' + yyyy;
    },

    /* Truyền vào 1 Json Date Convert ra 1 string format dd/MM/yyyy */
    ConvertJsonDateToStringFormatddMMyyyy: function (jsonDate) {
        //var newDate = dateFormat(jsonDate, "dd/MM/yyyy");
        var date = new Date(parseInt(jsonDate.substr(6)));
        var dd = date.getDate();
        if (dd <= 9)
            dd = '0' + dd.toString();
        var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        if (MM <= 9)
            MM = '0' + MM.toString();
        var yyyy = date.getFullYear();
        return dd + '/' + MM + '/' + yyyy;
    },

    /* Truyền vào dữ liệu kiểu bool OUT ra kiểu string Nếu True = Đang sử dụng, Nếu False = Không sử dụng */
    ConvertStatus: function (input) {
        if (input)
            return 'Đang Sử dụng';
        else
            return 'Không sử dụng';
    },

    /*
    (Format Tiền ) Truyền vào 1 số kiểu Numeric OUT ra kiểu string có format số thập phân theo kiểu x.xx,xx VNĐ 
    trong đó xx là 1 số nguyên. Dấu ( . ) là phân cách hàng nghìn, Dấu ( , ) là phân cách thập phân
    Chú ý nếu đầu vào dạng xx,xx.xx thì sẽ bị ngược :D
    */
    ConvertToMoneyVND: function (n) {
        var outPut = n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,");
        var outPutStr = outPut.toString();
        var SoThapPhan = outPutStr.substring(outPutStr.indexOf('.'), outPutStr.length).replace('.', ',');
        var SoNguyen = outPutStr.substring(0, outPutStr.indexOf('.')).replace(',', '.').replace('$', '');
        // return 'Số ban đầu : ' + outPut  + ' Vị Trí dấu . :'+ outPutStr.indexOf('.');
        //  return 'Phần Nguyên '+ SoNguyen +  ' Phần Thập  : ' + SoThapPhan;
        return SoNguyen + SoThapPhan + ' VNĐ';

    },

    /* Get ngày hiện tại theo định dạng dd/MM/yyyy */
    GetCurrentDateFormat: function () {
        var date = new Date();
        var dd = date.getDate();
        if (dd <= 9)
            dd = '0' + dd;
        var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        if (MM <= 9)
            MM = '0' + MM;
        var yyyy = date.getFullYear();
        return dd + '/' + MM + '/' + yyyy;
    },

    /* Get ngày đầu tiên của tháng hiện tại theo định dạng 01/MM/yyyy */
    GetCurrentDateOfMonthFormat: function () {
        var date = new Date();
        var dd = '01';
        var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        if (MM <= 9)
            MM = '0' + MM;
        var yyyy = date.getFullYear();
        return dd + '/' + MM + '/' + yyyy;
    },

    /* Get ngày đầu tiên của năm hiện tại theo định dạng 01/01/yyyy */
    GetFirstDateOfYearFormat: function () {
        var date = new Date();
        var dd = '01';
        var MM = '01';
        var yyyy = date.getFullYear();
        return dd + '/' + MM + '/' + yyyy;
    },

    /* Get ngày đầu tiên của năm hiện tại theo định dạng 31/12/yyyy */
    GetFinalDateOfYearFormat: function () {
        var date = new Date();
        var dd = '31';
        var MM = '12';
        var yyyy = date.getFullYear();
        return dd + '/' + MM + '/' + yyyy;
    }

    /* Chuyển True = Nam Fale Nữ */
    , ConvertGioiTinh(input) {
        if (input == true || input === 1)
            return 'Nam';
        else return 'Nữ';
    },
    // True = ẩn false = hiện
    Loading(input, element) {
        try {
            if (input) {
                $("#loader").hide();
                $('#' + element + '').show();
            }
            else {
                $("#loader").show();
                $('#' + element + '').hide();
                setTimeout(10000);
            }
        }
        catch (ex) {
            console.log('error: ' + ex);
        }
    },

    /* Truyền vào 1 Date Convert ra 1 string format MM/dd/yyyy */
    ConvertDateToTypeMMddyyyy(input) {
        if (typeof input.getMonth === "function") {
            var dd = input.getDate();
            if (dd <= 9)
                dd = '0' + dd;
            var MM = input.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
            if (MM <= 9)
                MM = '0' + MM;
            var yyyy = input.getFullYear();
            var newdate = MM + '/' + dd + '/' + yyyy;
            return newdate;
        }
        else {
            var datearray = input.split("/");

            var newdate = datearray[1] + '/' + datearray[0] + '/' + datearray[2];
            return newdate;
        }

        //var date = "24/09/1977";

        //var date = new Date(input);
        //var dd = date.getDate();
        //if (dd < 9)
        //    dd = '0' + dd;
        //var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        //if (MM < 9)
        //    MM = '0' + MM;
        //var yyyy = date.getFullYear();
        //return MM + 1 + "/" + dd + "/" + yyyy;

    },

    dissplayErrorMessage: function (message, buttonValue) {
        $('#NoiDung').html(message);
        $('#btnTaiLai').html(buttonValue);
        $('#errorModal').modal();

    },
    dissplayDeleteMessage: function (message) {
        $('#NoiDung').html(message);
        $('#deleteModal').modal('show');
        $('#btnOK').off('click').on('click', function () {
            $('#deleteModal').modal('hide');

            return true;
        });
        $('#btnCancel').off('click').on('click', function () {
            $('#deleteModal').modal('hide');

            return false;
        });
    },
    validaterTheBaoHiemYTe: function () {
        var input = $('.TheBHYT').val();
        //XX-X-XX-XX-XXX-XXXXX
        var re = /^[A-Z]{2}-[0-9]{1}-[0-9]{2}-[0-9]{2}-[A-Z|0-9]{3}-[0-9]{5}$/;
        if (re.test(input)) {
            $('.TheBHYT').removeClass('WarningValidator').addClass('successValidator');
        }
        else {
            $('.TheBHYT').removeClass('successValidator').addClass('WarningValidator');
            $('.validaterBHYT').html('Mã thẻ bảo hiểm không đúng định dạng !');
        }
    },

    displayMessageSuccess: function (message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "2000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        Command: toastr["success"](message);
    },
    displayMessageError: function (message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        Command: toastr["error"](message);
    },
    displayMessageWarning: function (message) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        Command: toastr["warning"](message);
    },

    CheckEnableElement: function (urlInput) {
        $.ajax({
            url: '' + urlInput + '',
            type: 'GET',
            data: {},
            success: function (result) {
                $.each(result, function (key, val) {
                    console.log(val);
                    var id = '#' + val['Name'];
                    $(id).addClass('hidden');
                    //  $('#' + ).enabled = val['Enable'];
                });
            },
            error: function (error) {
                console.log('Lỗi element' + error);
            }
        });
    },

    //tính tuổi
    calculateAge: function (dateString) {
        var today = Extention.ConvertDateToTypeMMddyyyy(new Date());
        var birthDate = Extention.ConvertDateToTypeMMddyyyy(dateString);
        var namHT = today.substring(6);
        var namNS = birthDate.substring(6);
        var age = namHT - namNS;
        return age;
    },

    // get URL
    getQueryVariable: function (variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == variable) { return pair[1]; }
        }
        return variable;
    },

    // chuyển về trang Home 
    backToHome: function () {
        $('.btnExit').click(function () {
            var url = '/Client/Home';
            window.location.href = url;
        })
        $(document).keydown(function (e) {
            //e.preventDefault();
            //nhấn F10
            if (e.keyCode == '121') {
                //var pathname = window.location.pathname.split('/');
                var url = '/Client/Home';
                window.location.href = url;
                return false;
            }
        });
    },   

    //back về trang trước
    backToPreviousPage: function () {
        $('.btnBack').click(function () {
            window.history.back();
        })
    },

    //hiển thị ngày sinh khi biết tuổi
    /* Note: txtTuoi: value tuổi */
    ngaySinhTinhTuoi: function (txtTuoi) {
        var d = new Date();
        if (txtTuoi.value != "")
            var result = "01/01/" + (d.getFullYear() - txtTuoi).toString();
        return result;
    },

    /* Truyền vào 1 Json Date Convert ra 1 string format dd/MM/yyyy hh:mm:ss */
    ConvertJsonDateTimeToStringFormat: function (jsonDate) {
        //var newDate = dateFormat(jsonDate, "dd/MM/yyyy");
        var date = new Date(parseInt(jsonDate.substr(6)));
        var dd = date.getDate();
        if (dd <= 9)
            dd = '0' + dd.toString();
        var MM = date.getMonth() + 1; // Tháng trong js bắt đầu từ 0->11
        if (MM <= 9)
            MM = '0' + MM.toString();
        var yyyy = date.getFullYear();
        var hh = date.getHours();
        if (hh <= 9)
            hh = '0' + hh.toString();
        var mm = date.getMinutes();
        if (mm <= 9)
            mm = '0' + mm.toString();
        var ss = date.getSeconds();
        if (ss <= 9)
            ss = '0' + ss.toString();
        return dd + '/' + MM + '/' + yyyy + ' ' + hh + ':' + mm + ':' + ss;
    },

    /* fn bỏ dấu -- str: truyền 1 chuỗi string */
    bodauTiengViet: function (str) {
        str = str.toLowerCase();
        str = str.replace(/à|á|ạ|ả|ã/g, "a");
        str = str.replace(/ầ|ấ|ậ|ẩ|ẫ/g, "â");
        str = str.replace(/ằ|ắ|ặ|ẳ|ẵ/g, "ă");
        str = str.replace(/è|é|ẹ|ẻ|ẽ/g, "e");
        str = str.replace(/ề|ế|ệ|ể|ễ/g, "ê");
        str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
        str = str.replace(/ò|ó|ọ|ỏ|õ/g, "o");
        str = str.replace(/ồ|ố|ộ|ổ|ỗ/g, "ô");
        str = str.replace(/ờ|ớ|ợ|ở|ỡ/g, "ơ");
        str = str.replace(/ù|ú|ụ|ủ|ũ/g, "u");
        str = str.replace(/ừ|ứ|ự|ử|ữ/g, "ư");
        str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
        return str;
    },

    //code cho phep khi nhan phim xuong tai row nam ngoai chieu rong cua table thi tu dong scroll table sao cho row nam o dong cuoi ma table dang hien thi
    selectRow : function(newRow) {
        // make sure the parameter is a jQuery object
        newRow = $(newRow);
        var rowTop = newRow.position().top;
        var rowBottom = rowTop + newRow.height();
        //var $table = $('tbody'); // store instead of calling twice
        var $table = $(newRow).closest('tbody');
        var tableHeight = $table.height();
        var currentScroll = $table.scrollTop() - newRow.height();
        //console.log("newRow: " + $(newRow).attr("id") + " rowTop: " + rowTop + " rowBottom: " + rowBottom + " rowHeight: " + newRow.height() + " $table: " + $table.attr("id") + " tableHeight: " + tableHeight + " currentScroll: " + currentScroll);
        if (rowTop < newRow.height()) {
            // scroll up
            $table.scrollTop(currentScroll + rowTop);
            //console.log("scroll up: " + $(newRow).attr("id") + " rowTop: " + rowTop + " rowBottom: " + rowBottom + " rowHeight: " + newRow.height() + " $table: " + $table.attr("id") + " tableHeight: " + tableHeight + " currentScroll: " + currentScroll);

        }
        else if (rowBottom > tableHeight) {
            // scroll down
            var scrollAmount = rowBottom - tableHeight;
            $table.scrollTop(currentScroll + scrollAmount + newRow.height());
            //console.log("scroll down: " + $(newRow).attr("id") + " rowTop: " + rowTop + " rowBottom: " + rowBottom + " rowHeight: " + newRow.height() + " $table: " + $table.attr("id") + " tableHeight: " + tableHeight + " currentScroll: " + currentScroll);

        }
    },
    //code cho phep khi nhan phim xuong tai row nam ngoai chieu rong cua table thi tu dong scroll table sao cho row nam o dong cuoi ma table dang hien thi
    selectHeaderRow: function (newRow,iHeader) {
        // make sure the parameter is a jQuery object
        newRow = $(newRow);
        var rowTop = newRow.position().top;
        var rowBottom = rowTop + newRow.height();
        //var $table = $('tbody'); // store instead of calling twice
        var $table = $(newRow).closest('tbody');
        var tableHeight = $table.height();
        var currentScroll = $table.scrollTop() - newRow.height();
        if (rowTop < tableHeight - currentScroll - iHeader)
        {
            // scroll up
            $table.scrollTop(currentScroll - newRow.height());
        }
        else if (rowBottom > tableHeight) {
            // scroll down
            var scrollAmount = rowBottom - tableHeight;
            $table.scrollTop(currentScroll + scrollAmount + newRow.height());
        }
    },
    //code error border color
    //Element id: idCombo
    errorBorder: function (idCombo)
    {
        $('#' + idCombo).css('border-color', 'red');
        $('#' + idCombo).focusout(function () {
            $('#' + idCombo).css('border-color', '');
        });
    },
    errorComboBorder: function (idCombo)
    {
        $($("#" + idCombo).select2("container")).addClass("has-error");
        $('#' + idCombo).on("select2-selected", function (e) {
            $($("#" + idCombo).select2("container")).removeClass("has-error");
        });
    },

    //code de tu dong can chinh lai kich thuoc table
    autoResizeTable: function () {
        $('#tbody').width($('#thead').width() + 17);
        $("#table tr").find("th").resizable(function (event) {
            autoResizeColumn($(this));
        });
    },
    autoResizeColumn: function (element) {
        var obj = $(element).siblings();
        var tt = $(element).width();
        var itt = $(element).index() + 1;
        $('#table tr td:nth-child(' + itt + ')').width(tt);
        for (var i = 0; i < obj.length; i++) {
            tt = $(obj[i]).width();
            itt = $(obj[i]).index() + 1;
            $('#table tr td:nth-child(' + itt + ')').width(tt);
        }
    },
    //Convert ddmmyyyy to mmddyyyy
    convertToMMDDYYYY: function (date) {
        var dd = date.substring(0, 2);
        var mm = date.substring(3, 5);
        var yyyy = date.substring(6, 10);
        return mm + '/' + dd + '/' + yyyy;
    },
}