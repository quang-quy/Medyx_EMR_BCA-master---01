/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMKhoa_GiuongViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempTenGiuong;
    var tempMaKhoa = "";
    var tempMaKhoa_Edit = "";
    var tempMaBuong = "";
    var tempMaBuong_Edit = "";
    var tempHuy;
    var self = this;
    //biến lưu từ khóa để load dữ liệu
    //self.keyWord = ko.observable('');
    //biến để kiểm tra trạng thái load đầu tiên của trang, nếu trang load lần đầu thì sẽ thực hiện phân trang, nếu không thì không phân trang lại
    self.LoadLanDau = ko.observable(true);
    //biến lưu trang hiện tại
    self.pageIndex = ko.observable(1);
    //biến lưu số lượng bản ghi trong một trang
    self.pageSize = ko.observable(20);
    //biến lưu tổng số bản ghi 
    self.tongSoBanGhi = ko.observable(0);
    self.tongSoTrang = ko.observable(0);
    //mảng lưu danh mục
    self.DMKhoa_Giuongs = ko.observableArray();
    //biến loading để hiển thị div loading khi trang đang load
    self.loading = ko.observable(false);
    //biến lưu trạng thái có thêm mới hay không? Sử dụng để hiển thị bản ghi mới thêm lên dòng đầu tiên của bảng 
    self.AddNew = ko.observable(false);
    //biến lưu bản ghi đang được chọn
    self.selectedItem = ko.observable();
    self.checkAdd = ko.observable(false);
    //biến lưu trạng thái search
    self.filter = ko.observable(false);
    //#region Knockout Observables
    // Observable array that represents each column in the table
    self.columns = ko.observableArray([
        { property: "ThaoTac", header: "", type: "", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: '', search: '' },
        { property: "STT", header: "STT", type: "number", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "MaGiuong", header: "Mã giường", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenGiuong", header: "Tên giường(*)", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenKhoa", header: "Khoa(*)", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenBuong", header: "Buồng", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "MaMay", header: "Mã máy", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "Huy", header: "Hủy", type: "", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "NguoiSD", header: "Người SD", type: "string", state: ko.observable(""), width: '15%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "NgaySD", header: "Ngày SĐ", type: "string", state: ko.observable(""), width: '15%', visible: ko.observable(true), field: '', search: 'date' }
    ]);
    //Khởi tạo mảng lưu các cột được export
    var cot = "";
    $(self.columns()).each(function (index, value) {
        if (value.visible) {
            if (value.property == 'ThaoTac' || value.property == 'STT')
            { }
            else
            {
                cot += ' ' + value.property + ',';
            }
        }
    });
    cot = cot.substring(0, cot.length - 1);
    self.colExport = ko.observable(cot);

    self.sortClick = function (column) {
        try {
            // Call this method to clear the state of any columns OTHER than the target
            // so we can keep track of the ascending/descending
            clearColumnStates(column);

            // Get the state of the sort type
            if (column.state() === "" || column.state() === descending) {
                column.state(ascending);
            }
            else {
                column.state(descending);
            }

            switch (column.type) {
                case "":
                    break;
                case "number":
                    self.numberSort(column);
                    break;
                case "date":
                    self.dateSort(column);
                    break;
                case "object":
                    self.objectSort(column);
                    break;
                case "string":
                default:
                    self.stringSort(column);
                    break;
            }
        }
        catch (err) {
            alert(err);
        }
    };
    // Generic sort method for numbers and strings
    self.stringSort = function (column) { // Pass in the column object
        self.DMKhoa_Giuongs(self.DMKhoa_Giuongs().sort(function (a, b) {
            // Set strings to lowercase to sort properly
            var playerA = a[column.property].toLowerCase(),
                playerB = b[column.property].toLowerCase();
            if (column.state() === ascending) {
                return playerA.localeCompare(playerB);
            }
            else {
                return playerB.localeCompare(playerA);
            }
        }));
    };
    // Sort by number
    self.numberSort = function (column) {
        self.DMKhoa_Giuongs(self.DMKhoa_Giuongs().sort(function (a, b) {
            var playerA = a[column.property], playerB = b[column.property];
            if (column.state() === ascending) {
                return playerA - playerB;
            }
            else {
                return playerB - playerA;
            }
        }));

    };
    // Sort by date
    self.dateSort = function (column) {
        self.DMKhoa_Giuongs(self.DMKhoa_Giuongs().sort(function (a, b) {
            if (column.state() === ascending) {
                return new Date(a[column.property]) - new Date(b[column.property]);
            }
            else {
                return new Date(b[column.property]) - new Date(a[column.property]);
            }
        }));
    };
    // Using a deep get method to find nested object properties
    self.objectSort = function (column) {
        self.DMKhoa_Giuongs(self.DMKhoa_Giuongs().sort(function (a, b) {
            var playerA = deepGet(a, column.property),
                playerB = deepGet(b, column.property);
            if (playerA < playerB) {
                return (column.state() === ascending) ? -1 : 1;
            }
            else if (playerA > playerB) {
                return (column.state() === ascending) ? 1 : -1;
            }
            else {
                return 0
            }
        }));
    };
    //#endregion
    //#region Utility Methods
    clearColumnStates = function (selectedColumn) {
        var otherColumns = self.columns().filter(function (col) {
            return col != selectedColumn;
        });
        for (var i = 0; i < otherColumns.length; i++) {
            otherColumns[i].state("");
        }
    };
    //hàm để xác định trạng thái sửa/xem của dòng đang chọn 
    self.displayMode = function (DMKhoa_Giuong) {
        return DMKhoa_Giuong.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMKhoa_Giuong, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMKhoa_Giuong.TenGiuong = $('#txtTenGiuong_Edit').val();
            DMKhoa_Giuong.MaKhoa = (tempMaKhoa_Edit == "") ? DMKhoa_Giuong.MaKhoa : tempMaKhoa_Edit;
            DMKhoa_Giuong.MaBuong = (tempMaBuong_Edit == "") ? DMKhoa_Giuong.MaBuong : tempMaBuong_Edit;
            self.done(DMKhoa_Giuong);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DMKhoa_Giuong, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMKhoa_Giuong.Huy = !DMKhoa_Giuong.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMKhoa_Giuong.TenGiuong = $('#txtTenGiuong_Edit').val();
            self.done(DMKhoa_Giuong);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMKhoa_Giuong) {
        if ($('#txtQuyenXem').val()=='true')
        {
            tempMaKhoa_Edit = "";
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMKhoa_Giuong;
            tempTenGiuong = DMKhoa_Giuong.TenGiuong;
            tempMaKhoa = DMKhoa_Giuong.MaKhoa;
            tempMaBuong = DMKhoa_Giuong.MaBuong;
            tempHuy = DMKhoa_Giuong.Huy;
            self.AddNew(false);
            DMKhoa_Giuong.Edit(true);
            //$('#' + self.selectedItem().MaGiuong).focus();
            GeneralCategory.LoadDMKhoa('cboTenKhoa_Edit', false, DMKhoa_Giuong.MaKhoa);
            GeneralCategory.LoadDMKhoa_BuongByKhoa('cboTenBuong_Edit', DMKhoa_Giuong.MaBuong, DMKhoa_Giuong.MaKhoa);
            $('#cboTenKhoa_Edit').on("select2-selected", function (e) {
                tempMaKhoa_Edit = $('#cboTenKhoa_Edit').select2('data').id;
            });
            $('#cboTenBuong_Edit').on("select2-selected", function (e) {
                tempMaBuong_Edit = $('#cboTenBuong_Edit').select2('data').id;
            });
            $('#txtTenGiuong_Edit').focus();
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();
        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMKhoa_Giuong) {
        if (DMKhoa_Giuong.TenGiuong.trim() == "") {
            DMKhoa_Giuong.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMKhoa_Giuong.Edit(false);
            if (!self.AddNew()) {
                DMKhoa_Giuong.MaKhoa = (tempMaKhoa_Edit == "") ? DMKhoa_Giuong.MaKhoa : tempMaKhoa_Edit;
                self.updateDMKhoa_Giuong(DMKhoa_Giuong);
            }
            temp = null;
            tempTenGiuong = "";
            tempMaKhoa_Edit = "";
            tempMaKhoa = "";
            tempMaBuong_Edit = "";
            tempMaBuong = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMKhoa_Giuong) {
        for (var i = 0; i < self.DMKhoa_Giuongs().length; i++) {
            if (self.DMKhoa_Giuongs()[i].MaGiuong == DMKhoa_Giuong.MaGiuong) {
                self.DMKhoa_Giuongs()[i].TenGiuong = tempTenGiuong;
                self.DMKhoa_Giuongs()[i].MaKhoa = tempMaKhoa;
                self.DMKhoa_Giuongs()[i].MaBuong = tempMaBuong;
                self.DMKhoa_Giuongs()[i].Huy = tempHuy;
            }
        }
        DMKhoa_Giuong.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }

    self.cancel = function (DMKhoa_Giuong) {
        self.subCancel(DMKhoa_Giuong);
        temp = null;
        tempTenGiuong = "";
        tempMaKhoa = "";
        tempMaBuong_Edit = "";
        tempMaBuong = "";
        tempHuy = false;
        var item = self.DMKhoa_Giuongs()[0];
        if (self.AddNew()) {
            self.DMKhoa_Giuongs.remove(DMKhoa_Giuong);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMKhoa_Giuong) {
        if ($('#txtQuyenXem').val() == 'true')
        {
            if (confirm('Bạn chắc chắn muốn xóa giường "' + DMKhoa_Giuong.MaGiuong + ' - ' + DMKhoa_Giuong.TenGiuong + '" ?')) {
                DMKhoa_Giuong.Huy = true;
                self.deleteKhoa_Giuong(DMKhoa_Giuong);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DMKhoa_Giuong) {
        self.selectedItem(DMKhoa_Giuong);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMKhoa_Giuongs().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMKhoa_Giuongs().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMKhoa_Giuongs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaGiuong), 31);
        $('#' + self.selectedItem().MaGiuong).focus();
    };

    self.selectNext = function () {
        //var index = self.DMKhoa_Giuongs().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined)
        { index = self.DMKhoa_Giuongs().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMKhoa_Giuongs().length) index = self.DMKhoa_Giuongs().length - 1;
        self.selectedItem(self.DMKhoa_Giuongs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaGiuong), 31);
        $('#' + self.selectedItem().MaGiuong).focus();
    };
    //tìm kiếm
    //self.search = function () {
    //    self.keyWord($('#txtsearch').val());
    //    self.pageIndex(1);
    //    self.LoadLanDau(true);
    //    self.loadData();
    //}
    //sự kiện nhấn phím trong bảng
    self.upAndDown = function (data, e) {
        //e.preventDefault();
        //nhấn up, down arrow
        if (e.keyCode == 38) {
            if (self.selectedItem().Edit() == false) {
                self.selectPrevious();
            }
            else {
                $('#' + self.selectedItem().MaGiuong).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaGiuong).focus();
            event.stopPropagation();
            return false;
        }
        else if (event.keyCode == 13) {
            if (self.selectedItem() != undefined) {
                if (self.selectedItem().Edit() == false) {
                    self.edit(self.selectedItem());
                }
                return false;
            }
            else return true;
        }
        else if (e.keyCode == 27) {
            self.subCancel(self.selectedItem());
            self.selectNext();
            $('#' + self.selectedItem().MaGiuong).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaGiuong).focus();
            }
            if (this.MaGiuong != self.selectedItem().MaGiuong) {
                var index = self.DMKhoa_Giuongs().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMKhoa_Giuongs().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaGiuong).focus();
            }
            return false;
        }
        else return true;
    }

    $(document).ready(function () {
        //thay đổi giá trị của combo tỉnh
        var Tinh = "";
        $('#cbofKhoa').on("select2-selected", function (e) {
            self.LoadDMKhoa_BuongByKhoa();
            //self.loadData();
        });
        $('#cboiTenKhoa').on("select2-selected", function (e) {
            self.LoadDMKhoa_BuongByKhoa();
            //self.loadData();
        });
        //thay đổi số lượng bản ghi hiển thị trên một trang
        $("#txtPageSize").change(function () {
            if (self.pageSize() == "")
                self.pageSize(20);
            self.LoadLanDau(true);
            self.loadData();
        });
        //sự kiện nhấn phím trong ô search để search các bản ghi
        //$('#txtsearch').keypress(function (e) {
        //    var code;
        //    if (document.all) {
        //        e = window.event;
        //        code = e.keyCode;
        //    }
        //    if (e.which) {
        //        code = e.which;
        //    }
        //    //nhấn enter để tìm kiếm trong sql
        //    if (code == 13) {// Enter
        //        self.search();
        //    }
        //});
        $('#txtPageSize').keypress(function (e) {
            var code;
            if (document.all) {
                e = window.event;
                code = e.keyCode;
            }
            if (e.which) {
                code = e.which;
            }
            if (code == 13) {// Enter
                self.pageSize($('#txtPageSize').val());
                self.LoadLanDau(true);
                self.loadData();
            }
        });
        //bắt sự kiện nhấn enter ở nút nhập tên giường
        $('#txtiTenGiuong').keypress(function (e) {
            var code;
            if (document.all) {
                e = window.event;
                code = e.keyCode;
            }
            if (e.which) {
                code = e.which;
            }
            if (code == 13) {// Enter
                self.insert();
            }
        });
        //set focus vào ô nhập mới tên giường khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenGiuong').focus();
        }
        else {
            $('#txtiTenGiuong').attr('disabled','disabled');
        }
        //$(":checkbox").focus(function () {
        //    $(this).css('outline-color', 'red');
        //});
        $('.btnFilter').click(function () {
            self.filter(!self.filter());
            if (self.filter() == true) {
                $('#txtsSTT').focus();
            }
            else {
                clearFilter();
                self.loadData();
            }
        });
        $('#SearchTemplate :input').keypress(function (e) {
            var code;
            if (document.all) {
                e = window.event;
                code = e.keyCode;
            }
            if (e.which) {
                code = e.which;
            }
            //nhấn enter để tìm kiếm trong sql
            if (code == 13) {// Enter
                self.pageIndex(1);
                self.LoadLanDau(true);
                self.loadData();
            }
        });
    });
    //load dữ liệu
    self.loadData = function () {
        var STT = 0;
        var add = false;
        if (self.checkAdd() == true) {
            add = true;
        }
        var ngay = $('#txtsNgaySD').val();
        if (ngay == '') {
            ngay = undefined;
        }
        else if (ngay != undefined) {
            ngay = Extention.convertToMMDDYYYY(ngay);
        }
        var khoa = $('#txtsTenKhoa').val();
        if (khoa == undefined && $('#cbofKhoa').select2('data') != undefined)
            khoa = $('#cbofKhoa').select2('data').text;
        var tenBuong = $('#txtsTenBuong').val();
        if (tenBuong == undefined && $('#cbofBuong').select2('data') != undefined)
            tenBuong = $('#cbofBuong').select2('data').text;
        var data = {
            maGiuong: $('#txtsMaGiuong').val(),
            tenGiuong: $('#txtsTenGiuong').val(),
            tenKhoa: khoa,
            tenBuong: tenBuong,
            maMay: $('#txtsMaMay').val(),
            ngaySD: ngay,
            nguoiSD: $('#txtsNguoiSD').val(),
            pageIndex: self.pageIndex,
            pageSize: self.pageSize,
            add: add
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMKhoa_Giuong/LoadData', data, function (data) {
            self.tongSoBanGhi(data.totalCounts);
            self.tongSoTrang = data.totalPages;
            self.DMKhoa_Giuongs(ko.utils.arrayMap(data.items, function (DMKhoa_Giuong) {
                STT += 1;
                var objDMKhoa_Giuong = {
                    STT: STT,
                    Edit: ko.observable(false),
                    MaGiuong: DMKhoa_Giuong.maGiuong,
                    TenGiuong: DMKhoa_Giuong.tenGiuong,
                    MaBuong: DMKhoa_Giuong.maBuong,
                    TenBuong: DMKhoa_Giuong.tenBuong,
                    MaKhoa: DMKhoa_Giuong.maKhoa,
                    TenKhoa: DMKhoa_Giuong.tenKhoa,
                    MaMay: (DMKhoa_Giuong.maMay == undefined) ? "" : DMKhoa_Giuong.maMay,
                    Huy: DMKhoa_Giuong.huy,
                    NguoiSD: (DMKhoa_Giuong.nguoiSD == undefined) ? "" : DMKhoa_Giuong.nguoiSD,
                    NgaySD: (DMKhoa_Giuong.ngaySD == undefined) ? "" :Extention.ConvertSQLDateTimeToStringFormat(DMKhoa_Giuong.ngaySD)
                }
                return objDMKhoa_Giuong;

                if (DMKhoa_Giuong.Huy == false) {
                    $('#chkHuy_read').checked(true);
                }
            }));
            if (self.DMKhoa_Giuongs().length != 0) {
            if (self.LoadLanDau())
                self.paging();
            if (self.selectedItem() != undefined) {
                self.selectedItem().Edit(false);
                self.selectItem(self.selectedItem());
                $('#' + self.selectedItem().MaGiuong).focus().addClass('danger');
            }
            }
            else {
                alert('Không có dữ liệu để hiển thị!');
            }
        });
    }
    
    //phân trang
    self.paging = function () {
        $('.pagination-custom').empty().removeData("twbs-pagination").unbind("page").twbsPagination({
            totalPages: parseInt(self.tongSoTrang), //Giá trị này sẽ được lấy từ hàm LoadData 
            visiblePages: 3,
            first: 'Đầu Trang',
            last: 'Cuối Trang',
            next: 'Trang tiếp',
            prev: 'Quay lại',
            initiateStartPageClick: true,
            onPageClick: function (event, page) {
                self.pageIndex(page); // Set pageIndex
                if (page > 1)
                    self.LoadLanDau(false); // first Trùng tên từ khóa
                if (self.LoadLanDau() == false) {
                    self.loadData();
                    return;
                }
            }

        });
    }
    //khởi tạo
    self.init = function () {
        Extention.backToHome();
        self.loadData();
        //self.regestEvent();
    }
    self.init();
    //thêm mới bản ghi
    self.insert = function (DMKhoa_Giuong) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenGiuong').val().trim() != '') {
                $.ajax({
                    url: '/DMKhoa_Giuong/CreateKhoa_Giuong',
                    type: 'POST',
                    data: {
                        tenGiuong: $('#txtiTenGiuong').val().trim(),
                        maKhoa: ($('#cboiTenKhoa').select2('data') == undefined) ? "" : $('#cboiTenKhoa').select2('data').id,
                        maBuong: ($('#cboiTenBuong').select2('data') == undefined) ? "" : $('#cboiTenBuong').select2('data').id,
                    },
                    success: function (response) {
                        if (response != null && response.success == false)
                            alert(response.message);
                        else {
                            alert('Thêm mới thành công!');
                            self.cancelInsert();
                            self.loadData();
                        }
                    },
                    error: function (error) {
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên giường');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên giường');
                Extention.errorBorder('txtiTenGiuong');
                self.cancelInsert();
                $('#txtiTenGiuong').focus();
            }
        }
    }
    //xóa bản ghi
    self.deleteKhoa_Giuong = function (DMKhoa_Giuong) {
        $.ajax({
            url: '/DMKhoa_Giuong/DeleteKhoa_Giuong',
            type: 'POST',
            data: { maGiuong: DMKhoa_Giuong.MaGiuong },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    if (response != null && response.success == false)
                        alert(response.message);
                    else {
                        alert("Xóa giường thành công!");
                        self.loadData();
                    }
                }
            },
            error: function (error) {
                alert("Xóa giường không thành công!");
            }
        })
    }
    //Import dữ liệu
    self.Import = function () {
        $('#importPopUp').modal("show");
    }
    self.submitImport = function () {
        //var myFile = $('#importFile').prop('files');
        var fileUpload = $("#importFile").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        fileData.append('insert', $('#importNhapMoi').is(":checked"));
        if ($('#txtQuyenXem').val() == 'true') {
            //self.checkAdd(true);
            if ($('#importFile').val().trim() != '') {
                $.ajax({
                    url: '/DMKhoa_Giuong/ImportDanhMuc',
                    type: 'POST',
                    contentType: false, // Not to set any content header  
                    processData: false, // Not to process data  
                    data: fileData,
                    success: function (response) {
                        if (response != null && response.success == false)
                            alert(response.message);
                        else {
                            alert('Import dữ liệu thành công!');
                            self.loadData();
                        }
                    },
                    error: function (error) {
                        alert('Import dữ liệu không thành công! Kiểm tra lại file import');
                    }
                });
            }
        }
        $('#importPopUp').modal("hide");
    }
    //Export dữ liệu
    self.Export = function () {
        if (self.tongSoBanGhi() <= 1048570) {
            if (self.colExport().length > 0) {
                var dk = generateDK().replace('%', '%25');
                var obj = {
                    key: dk,
                    columns: self.colExport()
                }
                window.open('/DMKhoa_Giuong/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/DMKhoa_Giuong/ExportDMKhoa_Giuong',
                //    type: 'POST',
                //    data: { key: generateDK(), columns: self.colExport() },
                //    success: function (response) {
                //        alert('Export dữ liệu thành công!');
                //    },
                //    error: function (error) {
                //        alert("Export dữ liệu không thành công!");
                //    }
                //})
            }
            else {
                alert("Không thể export dữ liệu! Vui lòng chọn lại cột hiển thị");
            }
        }
        else {
            alert("Số lượng bản ghi quá lớn! Không thể export dữ liệu! Vui lòng hạn chế số lượng bản ghi <= 1,048,500 bản ghi!");
        }
    }
    //cập nhật thông tin của bản ghi
    self.updateDMKhoa_Giuong = function (DMKhoa_Giuong) {
        $.ajax({
            url: '/DMKhoa_Giuong/Modify',
            type: 'POST',
            data: { Khoa_Giuong: DMKhoa_Giuong },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    self.loadData();
                    alert('Update thành công!');
                }
            },
            error: function (error) {
                alert('Update không thành công!');
            }
        });
    }
    //reset ô nhập thông tin thêm mới
    self.cancelInsert = function () {
        $('#txtiTenGiuong').val('');

    }
    
    //sự kiện hiển thị các cột trong bảng
    self.CreateVisibleColumn = function () {
        var cotExport = '';
        //event.preventDefault();
        var mang = [];
        $('#cboColumn input:checked').each(function (index, value) {
            if (value.id == "All") { }
            else
            {
                mang.push(value.id);
                if (value.id == "ThaoTac" || value.id == "STT") { }
                else {
                    cotExport += ' ' + value.id + ',';
                }
            }
        });
        var i = 0;
        $(self.columns()).each(function (index, value) {
            if (value.property == mang[i]) {
                value.visible(true);
                i++;
            }
            else value.visible(false);
        });
        cotExport = cotExport.substring(0, cotExport.length - 1);
        self.colExport(cotExport);
    }
    //Load combo columns
    self.LoadDMColumn = function () {
        GeneralCategory.LoadDMColumn('cboColumn', self.columns());
        $('#cboColumn .dropdown-menu a').click(function (event) {
            self.CreateVisibleColumn();
            //Căn chỉnh lại kích thước cột
            Extention.autoResizeTable();
        });
        $('#cboColumn input[type=checkbox]').change(function () {
            if ($(this).attr('id') == "All") {
                if ($('#All').is(":checked") == true) {
                    $('#All').prop('checked', true);
                    $('#cboColumn input[type=checkbox]').each(function (index, value) {
                        $(value).prop('checked', true);
                    });
                }
                else {
                    $('#All').prop('checked', false);
                    $('#cboColumn input[type=checkbox]').each(function (index, value) {
                        $(value).prop('checked', false);
                    });
                }
            }
            else {
                if ($('#All').is(":checked") == true) {
                    $('#All').prop('checked', false);
                }
            }
            self.CreateVisibleColumn();
            //Căn chỉnh lại kích thước cột
            Extention.autoResizeTable();
        });
    }
    self.LoadDMColumn();
    //Create insert Template
    self.CreateSearchTemplate = function () {
        GeneralCategory.CreateSearchTemplate('thead', self.columns());
    }
    self.CreateSearchTemplate();
    //Create read Template
    self.CreateReadTemplate = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.CreateReadTemplate('boxBody', self.columns(), '');
        }
        else {
            GeneralCategory.CreateReadTemplate('boxBody', self.columns(), 'disabled');
        }
    }
    self.CreateReadTemplate();
    //Create insert Template
    self.CreateInsertTemplate = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.CreateInsertTemplate('thead', self.columns(), '');
        }
        else {
            GeneralCategory.CreateInsertTemplate('thead', self.columns(), 'disabled');
        }
    }
    self.CreateInsertTemplate();
    //Create edit Template
    self.CreateEditTemplate = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.CreateEditTemplate('thead', self.columns(), '');
        }
        else {
            GeneralCategory.CreateEditTemplate('thead', self.columns(), 'disabled');
        }
    }
    self.CreateEditTemplate();
    //Load danh mục khoa
    self.LoadDMKhoa = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMKhoa('cboiTenKhoa', false, '');
        }
        GeneralCategory.LoadDMKhoa('cbofKhoa', false, '');
    }
    self.LoadDMKhoa();
    //Load danh mục buong
    self.LoadDMKhoa_BuongByKhoa = function () {
        var makhoa = "";
        if ($('#cbofKhoa').select2('data') != undefined) makhoa = $('#cbofKhoa').select2('data').id;
        if (makhoa == 'All') makhoa = '';
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMKhoa_BuongByKhoa('cboiTenBuong', '', makhoa);
        }
        GeneralCategory.LoadDMKhoa_BuongByKhoa('cbofBuong', '', makhoa);
    }
    self.LoadDMKhoa_BuongByKhoa();
}
//custom binding ngăn không cho click vào checkbox
ko.bindingHandlers.preventBubble = {
    init: function (element, valueAccessor) {
        var eventName = ko.utils.unwrapObservable(valueAccessor());
        ko.utils.registerEventHandler(element, eventName, function (event) {
            event.cancelBubble = true;
            if (event.stopPropagation) {
                event.stopPropagation();
            }
        });
    }
};
ko.applyBindings(new DMKhoa_GiuongViewModel());