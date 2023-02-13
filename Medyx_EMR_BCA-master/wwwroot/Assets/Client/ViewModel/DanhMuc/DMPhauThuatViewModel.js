/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMPhauThuatViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempTenPT;
    var tempMaNhomDV = "";
    var tempMaNhomDV_Edit = "";
    var tempMaPLPTTT = "";
    var tempMaPLPTTT_Edit = "";
    var tempMaChungLoai = "";
    var tempMaChungLoai_Edit = "";
    var tempTenTat = "";
    var tempMaBYT = "";
    var tempTenBYT = "";
    var tempGhiChu = "";
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
    self.DMPhauThuats = ko.observableArray();
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
        { property: "MaPT", header: "Mã dịch vụ", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenPT", header: "Tên dịch vụ(*)", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenNhomDV", header: "Nhóm DV", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenPLPTTT", header: "Phân Loại", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenChungLoai", header: "Chủng Loại", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenTat", header: "Tên tắt", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "MaBYT", header: "Mã BYT", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenBYT", header: "Tên BYT", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "GhiChu", header: "Ghi chú", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "MaMay", header: "Mã máy", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "Huy", header: "Hủy", type: "", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "NguoiSD", header: "Người SD", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "NgaySD", header: "Ngày SĐ", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'date' }
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
        self.DMPhauThuats(self.DMPhauThuats().sort(function (a, b) {
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
        self.DMPhauThuats(self.DMPhauThuats().sort(function (a, b) {
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
        self.DMPhauThuats(self.DMPhauThuats().sort(function (a, b) {
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
        self.DMPhauThuats(self.DMPhauThuats().sort(function (a, b) {
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
    self.displayMode = function (DMPhauThuat) {
        return DMPhauThuat.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMPhauThuat, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMPhauThuat.MaNhomDV = (tempMaNhomDV_Edit == "") ? DMPhauThuat.MaNhomDV : tempMaNhomDV_Edit;
            DMPhauThuat.MaPLPTTT = (tempMaPLPTTT_Edit == "") ? DMPhauThuat.MaPLPTTT : tempMaPLPTTT_Edit;
            DMPhauThuat.MaChungLoai = (tempMaChungLoai_Edit == "") ? DMPhauThuat.MaChungLoai : tempMaChungLoai_Edit;
            DMPhauThuat.TenPT = $('#txtTenPT_Edit').val();
            DMPhauThuat.TenTat = $('#txtTenTat_Edit').val();
            DMPhauThuat.MaBYT = $('#txtMaBYT_Edit').val();
            DMPhauThuat.TenBYT = $('#txtTenBYT_Edit').val();
            DMPhauThuat.GhiChu = $('#txtGhiChu_Edit').val();
            self.done(DMPhauThuat);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DMPhauThuat, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMPhauThuat.Huy = !DMPhauThuat.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMPhauThuat.TenPT = $('#txtTenPT_Edit').val();
            self.done(DMPhauThuat);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMPhauThuat) {
        if ($('#txtQuyenXem').val()=='true')
        {
            tempMaNhomDV_Edit = "";
            tempMaPLPTTT_Edit = "";
            tempMaChungLoai_Edit = "";
            tempMaLH_Edit = "";
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMPhauThuat;
            tempTenPT = DMPhauThuat.TenPT;
            tempTenTat = DMPhauThuat.TenTat;
            tempMaBYT = DMPhauThuat.MaBYT;
            tempTenBYT = DMPhauThuat.TenBYT;
            tempGhiChu = DMPhauThuat.GhiChu;
            tempHuy = DMPhauThuat.Huy;
            self.AddNew(false);
            DMPhauThuat.Edit(true);
            //$('#' + self.selectedItem().MaPT).focus();
            GeneralCategory.LoadDMDichVu_Nhom('cboTenNhomDV_Edit', DMPhauThuat.MaNhomDV, DMPhauThuat.TenNhomDV);
            GeneralCategory.LoadDMDichVu_PhanLoaiPTTT('cboTenPLPTTT_Edit', DMPhauThuat.MaPLPTTT, DMPhauThuat.TenPLPTTT);
            GeneralCategory.LoadDMDichVu_ChungLoai('cboTenChungLoai_Edit', DMPhauThuat.MaChungLoai, DMPhauThuat.TenChungLoai);
            $('#txtTenPT_Edit').focus();
            $('#cboTenNhomDV_Edit').on("select2-selected", function (e) {
                tempMaNhomDV_Edit = $('#cboTenNhomDV_Edit').select2('data').id;
            });
            $('#cboTenPLPTTT_Edit').on("select2-selected", function (e) {
                tempMaPLPTTT_Edit = $('#cboTenPLPTTT_Edit').select2('data').id;
            });
            $('#cboTenChungLoai_Edit').on("select2-selected", function (e) {
                tempMaChungLoai_Edit = $('#cboTenChungLoai_Edit').select2('data').id;
            });
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();
        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMPhauThuat) {
        if (DMPhauThuat.TenPT.trim() == "") {
            DMPhauThuat.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMPhauThuat.Edit(false);
            if (!self.AddNew()) {
                DMPhauThuat.MaNhomDV = (tempMaNhomDV_Edit == "") ? DMPhauThuat.MaNhomDV : tempMaNhomDV_Edit;
                DMPhauThuat.MaPLPTTT = (tempMaPLPTTT_Edit == "") ? DMPhauThuat.MaPLPTTT : tempMaPLPTTT_Edit;
                DMPhauThuat.MaChungLoai = (tempMaChungLoai_Edit == "") ? DMPhauThuat.MaChungLoai : tempMaChungLoai_Edit;
                DMPhauThuat.MaLH = (tempMaLH_Edit == "") ? DMPhauThuat.MaLH : tempMaLH_Edit;
                self.updateDMPhauThuat(DMPhauThuat);
            }
            temp = null;
            tempTenPT = "";
            tempMaNhomDV = "";
            tempMaNhomDV_Edit = "";
            tempMaPLPTTT = "";
            tempMaPLPTTT_Edit = "";
            tempMaChungLoai = "";
            tempMaChungLoai_Edit = "";
            tempTenTat = "";
            tempMaBYT = "";
            tempTenBYT = "";
            tempGhiChu = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMPhauThuat) {
        for (var i = 0; i < self.DMPhauThuats().length; i++) {
            if (self.DMPhauThuats()[i].MaPT == DMPhauThuat.MaPT) {
                self.DMPhauThuats()[i].MaNhomDV = tempMaNhomDV;
                self.DMPhauThuats()[i].MaPLPTTT = tempMaPLPTTT;
                self.DMPhauThuats()[i].MaChungLoai = tempMaChungLoai;
                self.DMPhauThuats()[i].TenPT = tempTenPT;
                self.DMPhauThuats()[i].TenTat = tempTenTat;
                self.DMPhauThuats()[i].MaBYT = tempMaBYT;
                self.DMPhauThuats()[i].TenBYT = tempTenBYT;
                self.DMPhauThuats()[i].GhiChu = tempGhiChu;
                self.DMPhauThuats()[i].Huy = tempHuy;
            }
        }
        DMPhauThuat.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }

    self.cancel = function (DMPhauThuat) {
        self.subCancel(DMPhauThuat);
        temp = null;
        tempTenPT = "";
        tempMaNhomDV = "";
        tempMaNhomDV_Edit = "";
        tempMaPLPTTT = "";
        tempMaPLPTTT_Edit = "";
        tempMaChungLoai = "";
        tempMaChungLoai_Edit = "";
        tempTenTat = "";
        tempMaBYT = "";
        tempTenBYT = "";
        tempGhiChu = "";
        tempHuy = false;
        var item = self.DMPhauThuats()[0];
        if (self.AddNew()) {
            self.DMPhauThuats.remove(DMPhauThuat);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMPhauThuat) {
        if ($('#txtQuyenXem').val() == 'true')
        {
            if (confirm('Bạn chắc chắn muốn xóa dịch vụ "' + DMPhauThuat.MaPT + ' - ' + DMPhauThuat.TenPT + '" ?')) {
                DMPhauThuat.Huy = true;
                self.deletePhauThuat(DMPhauThuat);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DMPhauThuat) {
        self.selectedItem(DMPhauThuat);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMPhauThuats().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMPhauThuats().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMPhauThuats()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaPT), 31);
        $('#' + self.selectedItem().MaPT).focus();
    };

    self.selectNext = function () {
        //var index = self.DMPhauThuats().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined)
        { index = self.DMPhauThuats().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMPhauThuats().length) index = self.DMPhauThuats().length - 1;
        self.selectedItem(self.DMPhauThuats()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaPT), 31);
        $('#' + self.selectedItem().MaPT).focus();
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
                $('#' + self.selectedItem().MaPT).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaPT).focus();
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
            $('#' + self.selectedItem().MaPT).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaPT).focus();
            }
            if (this.MaPT != self.selectedItem().MaPT) {
                var index = self.DMPhauThuats().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMPhauThuats().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaPT).focus();
            }
            return false;
        }
        else return true;
    }

    $(document).ready(function () {
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
        //bắt sự kiện nhấn enter ở nút nhập tên dịch vụ
        $('#txtiTenPT').keypress(function (e) {
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
        //set focus vào ô nhập mới tên dịch vụ khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenPT').focus();
        }
        else {
            $('#txtiTenPT').attr('disabled','disabled');
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
        var TenNhomDV = $('#txtsTenNhomDV').val();
        if (TenNhomDV == undefined && $('#cbofNhomDV').select2('data') != undefined)
            TenNhomDV = $('#cbofNhomDV').select2('data').text;
        var TenPLPTTT = $('#txtsTenPLPTTT').val();
        if (TenPLPTTT == undefined && $('#cbofPhanLoaiDV').select2('data') != undefined)
            TenPLPTTT = $('#cbofPhanLoaiDV').select2('data').text;
        var TenChungLoai = $('#txtsTenChungLoai').val();
        if (TenChungLoai == undefined && $('#cbofChungLoaiDV').select2('data') != undefined)
            TenChungLoai = $('#cbofChungLoaiDV').select2('data').text;
        var data = {
            maPT: $('#txtsMaPT').val(),
            TenPT: $('#txtsTenPT').val(),
            TenNhomDV: TenNhomDV,
            TenPLPTTT: TenPLPTTT,
            TenTat: $('#txtsTenTat').val(),
            TenChungLoai: TenChungLoai,
            MaBYT: $('#txtsMaBYT').val(),
            TenBYT: $('#txtsTenBYT').val(), 
            GhiChu: $('#txtsGhiChu').val(),
            maMay: $('#txtsMaMay').val(),
            ngaySD: ngay,
            nguoiSD: $('#txtsNguoiSD').val(),
            pageIndex: self.pageIndex,
            pageSize: self.pageSize,
            add: add
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMPhauThuat/LoadData', data, function (data) {
            self.tongSoBanGhi(data.totalCounts);
            self.tongSoTrang = data.totalPages;
            self.DMPhauThuats(ko.utils.arrayMap(data.items, function (DMPhauThuat) {
                STT += 1;
                var objDMPhauThuat = {
                    STT: STT,
                    Edit: ko.observable(false),
                    MaPT: DMPhauThuat.maPT,
                    TenPT: DMPhauThuat.tenPT,
                    MaChungLoai: DMPhauThuat.maChungLoai,
                    TenChungLoai: DMPhauThuat.tenChungLoai,
                    MaPLPTTT: DMPhauThuat.maPLPTTT,
                    TenPLPTTT: DMPhauThuat.tenPLPTTT,
                    TenTat: DMPhauThuat.tenTat,
                    MaBYT: DMPhauThuat.maBYT,
                    TenBYT: DMPhauThuat.tenBYT,
                    MaNhomDV: DMPhauThuat.maNhomDV,
                    TenNhomDV: DMPhauThuat.tenNhomDV,
                    GhiChu: DMPhauThuat.ghiChu,
                    MaMay: (DMPhauThuat.maMay == undefined) ? "" : DMPhauThuat.maMay,
                    Huy: DMPhauThuat.huy,
                    NguoiSD: (DMPhauThuat.nguoiSD == undefined) ? "" : DMPhauThuat.nguoiSD,
                    NgaySD: (DMPhauThuat.ngaySD == undefined) ? "" :Extention.ConvertSQLDateTimeToStringFormat(DMPhauThuat.ngaySD)
                }
                return objDMPhauThuat;

                if (DMPhauThuat.Huy == false) {
                    $('#chkHuy_read').checked(true);
                }
            }));
            if (self.DMPhauThuats().length != 0) {
            if (self.LoadLanDau())
                self.paging();
            if (self.selectedItem() != undefined) {
                self.selectedItem().Edit(false);
                self.selectItem(self.selectedItem());
                $('#' + self.selectedItem().MaPT).focus().addClass('danger');
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
    self.insert = function (DMPhauThuat) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenPT').val().trim() != '') {
                $.ajax({
                    url: '/DMPhauThuat/CreatePhauThuat',
                    type: 'POST',
                    data: {
                        TenPT: $('#txtiTenPT').val().trim(),
                        MaNhomDV: ($('#cboiTenNhomDV').select2('data') == undefined) ? "" : $('#cboiTenNhomDV').select2('data').id,
                        MaPLPTTT: ($('#cboiTenPLPTTT').select2('data') == undefined) ? "" : $('#cboiTenPLPTTT').select2('data').id,
                        TenTat: $('#txtiTenTat').val().trim(),
                        MaChungLoai: ($('#cboiTenChungLoai').select2('data') == undefined) ? "" : $('#cboiTenChungLoai').select2('data').id,
                        MaBYT: $('#txtiMaBYT').val().trim(),
                        TenBYT: $('#txtiTenBYT').val().trim(),
                        GhiChu: $('#txtiGhiChu').val().trim(),
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
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên dịch vụ');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên dịch vụ');
                Extention.errorBorder('txtiTenPT');
                self.cancelInsert();
                $('#txtiTenPT').focus();
            }
        }
    }
    //xóa bản ghi
    self.deletePhauThuat = function (DMPhauThuat) {
        $.ajax({
            url: '/DMPhauThuat/DeletePhauThuat',
            type: 'POST',
            data: { MaPT: DMPhauThuat.MaPT },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    if (response != null && response.success == false)
                        alert(response.message);
                    else {
                        alert("Xóa dịch vụ thành công!");
                        self.loadData();
                    }
                }
            },
            error: function (error) {
                alert("Xóa dịch vụ không thành công!");
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
                    url: '/DMPhauThuat/ImportDanhMuc',
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
                window.open('/DMPhauThuat/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/DMPhauThuat/ExportDMPhauThuat',
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
    self.updateDMPhauThuat = function (DMPhauThuat) {
        $.ajax({
            url: '/DMPhauThuat/Modify',
            type: 'POST',
            data: { PhauThuat: DMPhauThuat },
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
        $('#txtiTenPT').val('');

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
    //Load danh mục nhóm dịch vụ
    self.LoadDMDichVu_Nhom = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMDichVu_Nhom('cboiTenNhomDV', false, '');
        }
        GeneralCategory.LoadDMDichVu_Nhom('cbofNhomDV', false, '');
    }
    self.LoadDMDichVu_Nhom();
    //Load danh mục phân loại dịch vụ
    self.LoadDMDichVu_PhanLoaiPTTT = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMDichVu_PhanLoaiPTTT('cboiTenPhanLoaiPTTT', false, '');
        }
        GeneralCategory.LoadDMDichVu_PhanLoaiPTTT('cbofPhanLoaiDV', false, '');
    }
    self.LoadDMDichVu_PhanLoaiPTTT();
    //Load danh mục chủng loại dịch vụ
    self.LoadDMDichVu_ChungLoai = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMDichVu_ChungLoai('cboiTenChungLoai', false, '');
        }
        GeneralCategory.LoadDMDichVu_ChungLoai('cbofChungLoaiDV', false, '');
    }
    self.LoadDMDichVu_ChungLoai();
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
ko.applyBindings(new DMPhauThuatViewModel());