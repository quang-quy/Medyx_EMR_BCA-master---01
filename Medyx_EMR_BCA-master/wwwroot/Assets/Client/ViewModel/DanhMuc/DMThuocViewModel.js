/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMThuocViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempMaNhom = "";
    var tempMaNhom_Edit = "";
    var tempMaPL = "";
    var tempMaPL_Edit = "";
    var tempMaChungLoai = "";
    var tempMaChungLoai_Edit = "";
    var tempMaDangBaoChe = "";
    var tempMaDangBaoChe_Edit = "";
    var tempTenGoc = "";
    var tempTenTM = "";
    var tempHamLuong = "";
    var tempMaDVT = "";
    var tempMaDVT_Edit = "";
    var tempMaNSX = "";
    var tempMaNSX_Edit = "";
    var tempGhiChu = "";
    var tempMaQG = "";
    var tempMaQG_Edit = "";
    var tempMaDuongDung = "";
    var tempMaDuongDung_Edit = "";
    var tempMaBYT = "";
    var tempTenBYT = "";
    var tempSoDangKy = "";
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
    self.DMThuocs = ko.observableArray();
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
        { property: "MaThuoc", header: "Mã thuốc", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenNhom", header: "Nhóm", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenPL", header: "Phân loại", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenChungLoai", header: "Chủng loại", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenDangBaoChe", header: "Dạng bào chế", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenGoc", header: "Tên gốc(*)", type: "string", state: ko.observable(""), width: '11%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenTM", header: "Tên TM", type: "string", state: ko.observable(""), width: '11%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "HamLuong", header: "Hàm lượng", type: "string", state: ko.observable(""), width: '11%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenDVT", header: "Đơn vị", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenNSX", header: "Nhà SX", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "GhiChu", header: "Ghi chú", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenQG", header: "Quốc gia", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenDuongDung", header: "Đường dùng", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "MaBYT", header: "Mã BYT", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenBYT", header: "Tên BYT", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
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
        self.DMThuocs(self.DMThuocs().sort(function (a, b) {
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
        self.DMThuocs(self.DMThuocs().sort(function (a, b) {
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
        self.DMThuocs(self.DMThuocs().sort(function (a, b) {
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
        self.DMThuocs(self.DMThuocs().sort(function (a, b) {
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
    self.displayMode = function (DMThuoc) {
        return DMThuoc.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMThuoc, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMThuoc.MaNhom = (tempMaNhom_Edit == "") ? DMThuoc.MaNhom : tempMaNhom_Edit;
            DMThuoc.MaPL = (tempMaPL_Edit == "") ? DMThuoc.MaPL : tempMaPL_Edit;
            DMThuoc.MaChungLoai = (tempMaChungLoai_Edit == "") ? DMThuoc.MaChungLoai : tempMaChungLoai_Edit;
            DMThuoc.MaDangBaoChe = (tempMaDangBaoChe_Edit == "") ? DMThuoc.MaDangBaoChe : tempMaDangBaoChe_Edit;
            DMThuoc.MaDVT = (tempMaDVT_Edit == "") ? DMThuoc.MaDVT : tempMaDVT_Edit;
            DMThuoc.MaNSX = (tempMaNSX_Edit == "") ? DMThuoc.MaNSX : tempMaNSX_Edit;
            DMThuoc.MaQG = (tempMaQG_Edit == "") ? DMThuoc.MaQG : tempMaQG_Edit;
            DMThuoc.MaDuongDung = (tempMaDuongDung_Edit == "") ? DMThuoc.MaDuongDung : tempMaDuongDung_Edit;
            DMThuoc.TenGoc = $('#txtTenGoc_Edit').val();
            DMThuoc.TenTM = $('#txtTenTM_Edit').val();
            DMThuoc.HamLuong = $('#txtHamLuong_Edit').val();
            DMThuoc.GhiChu = $('#txtGhiChu_Edit').val();
            DMThuoc.MaBYT = $('#txtMaBYT_Edit').val();
            DMThuoc.TenBYT = $('#txtTenBYT_Edit').val();
            DMThuoc.SoDangKy = $('#txtSoDangKy_Edit').val();
            self.done(DMThuoc);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DMThuoc, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMThuoc.Huy = !DMThuoc.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMThuoc.TenGoc = $('#txtTenGoc_Edit').val();
            DMThuoc.GhiChu = $('#txtGhiChu_Edit').val();
            self.done(DMThuoc);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMThuoc) {
        if ($('#txtQuyenXem').val()=='true')
        {
            tempMaNhom_Edit = "";
            tempMaPL_Edit = "";
            tempMaChungLoai_Edit = "";
            tempMaDangBaoChe_Edit = "";
            tempMaDVT_Edit = "";
            tempMaNSX_Edit = "";
            tempMaQG_Edit = "";
            tempMaDuongDung_Edit = "";
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMThuoc;
            tempTenGoc = DMThuoc.TenGoc;
            tempTenTM = DMThuoc.TenTM;
            tempHamLuong = DMThuoc.HamLuong;
            tempGhiChu = DMThuoc.GhiChu;
            tempMaBYT = DMThuoc.MaBYT;
            tempTenBYT = DMThuoc.TenBYT;
            tempSoDangKy = DMThuoc.SoDangKy;
            tempHuy = DMThuoc.Huy;
            self.AddNew(false);
            DMThuoc.Edit(true);
            GeneralCategory.LoadDMThuoc_Nhom('cboTenNhom_Edit', DMThuoc.MaNhom, DMThuoc.TenNhom);
            GeneralCategory.LoadDMThuoc_PhanLoai('cboTenPL_Edit', DMThuoc.MaPL, DMThuoc.TenPL);
            GeneralCategory.LoadDMThuoc_ChungLoai('cboTenChungLoai_Edit', DMThuoc.MaChungLoai, DMThuoc.TenChungLoai);
            GeneralCategory.LoadDMThuoc_DangBaoChe('cboTenDangBaoChe_Edit', DMThuoc.MaDangBaoChe, DMThuoc.TenDangBaoChe);
            GeneralCategory.LoadDMThuoc_Donvitinh('cboTenDVT_Edit', DMThuoc.MaDVT, DMThuoc.TenDVT);
            GeneralCategory.LoadDMThuoc_DuongDung('cboTenDuongDung_Edit', DMThuoc.MaDuongDung, DMThuoc.TenDuongDung);
            GeneralCategory.LoadDMThuoc_NhaSX('cboTenNSX_Edit', DMThuoc.MaNSX, DMThuoc.TenNSX);
            GeneralCategory.LoadDMQuocGia('cboTenQG_Edit', DMThuoc.MaQG, DMThuoc.TenQG);
            //$('#' + self.selectedItem().MaThuoc).focus();
            $('#cboTenNhom_Edit').on("select2-selected", function (e) {
                tempMaNhom_Edit = $('#cboTenNhom_Edit').select2('data').id;
            });
            $('#cboTenPL_Edit').on("select2-selected", function (e) {
                tempMaPL_Edit = $('#cboTenPL_Edit').select2('data').id;
            });
            $('#cboTenChungLoai_Edit').on("select2-selected", function (e) {
                tempMaChungLoai_Edit = $('#cboTenChungLoai_Edit').select2('data').id;
            });
            $('#cboTenDangBaoChe_Edit').on("select2-selected", function (e) {
                tempMaDangBaoChe_Edit = $('#cboTenDangBaoChe_Edit').select2('data').id;
            });
            $('#cboTenDVT_Edit').on("select2-selected", function (e) {
                tempMaDVT_Edit = $('#cboTenDVT_Edit').select2('data').id;
            });
            $('#cboTenDuongDung_Edit').on("select2-selected", function (e) {
                tempMaDuongDung_Edit = $('#cboTenDuongDung_Edit').select2('data').id;
            });
            $('#cboTenNSX_Edit').on("select2-selected", function (e) {
                tempMaNSX_Edit = $('#cboTenNSX_Edit').select2('data').id;
            });
            $('#cboTenQG_Edit').on("select2-selected", function (e) {
                tempMaQG_Edit = $('#cboTenQG_Edit').select2('data').id;
            });
            $('#txtTenGoc_Edit').focus();
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();

        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMThuoc) {
        if (DMThuoc.TenGoc.trim() == "") {
            DMThuoc.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMThuoc.Edit(false);
            if (!self.AddNew()) {
                DMThuoc.MaNhom = (tempMaNhom_Edit == "") ? DMThuoc.MaNhom : tempMaNhom_Edit;
                DMThuoc.MaPL = (tempMaPL_Edit == "") ? DMThuoc.MaPL : tempMaPL_Edit;
                DMThuoc.MaChungLoai = (tempMaChungLoai_Edit == "") ? DMThuoc.MaChungLoai : tempMaChungLoai_Edit;
                DMThuoc.MaDangBaoChe = (tempMaDangBaoChe_Edit == "") ? DMThuoc.MaDangBaoChe : tempMaDangBaoChe_Edit;
                DMThuoc.MaDVT = (tempMaDVT_Edit == "") ? DMThuoc.MaDVT : tempMaDVT_Edit;
                DMThuoc.MaDuongDung = (tempMaDuongDung_Edit == "") ? DMThuoc.MaDuongDung : tempMaDuongDung_Edit;
                DMThuoc.MaNSX = (tempMaNSX_Edit == "") ? DMThuoc.MaNSX : tempMaNSX_Edit;
                DMThuoc.MaQG = (tempMaQG_Edit == "") ? DMThuoc.MaQG : tempMaQG_Edit;
                self.updateDMThuoc(DMThuoc);
            }
            temp = null;
            tempMaNhom = "";
            tempMaNhom_Edit = "";
            tempMaPL = "";
            tempMaPL_Edit = "";
            tempMaChungLoai = "";
            tempMaChungLoai_Edit = "";
            tempMaDangBaoChe = "";
            tempMaDangBaoChe_Edit = "";
            tempTenGoc = "";
            tempTenTM = "";
            tempHamLuong = "";
            tempMaDVT = "";
            tempMaDVT_Edit = "";
            tempMaNSX = "";
            tempMaNSX_Edit = "";
            tempGhiChu = "";
            tempMaQG = "";
            tempMaQG_Edit = "";
            tempMaDuongDung = "";
            tempMaDuongDung_Edit = "";
            tempMaBYT = "";
            tempTenBYT = "";
            tempSoDangKy = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMThuoc) {
        for (var i = 0; i < self.DMThuocs().length; i++) {
            if (self.DMThuocs()[i].MaThuoc == DMThuoc.MaThuoc) {
                self.DMThuocs()[i].MaNhom = tempMaNhom;
                self.DMThuocs()[i].MaPL = tempMaPL;
                self.DMThuocs()[i].MaChungLoai = tempMaChungLoai;
                self.DMThuocs()[i].MaDangBaoChe = tempMaDangBaoChe;
                self.DMThuocs()[i].MaDVT = tempMaDVT;
                self.DMThuocs()[i].MaNSX = tempMaNSX;
                self.DMThuocs()[i].MaQG = tempMaQG;
                self.DMThuocs()[i].MaDuongDung = tempMaDuongDung;
                self.DMThuocs()[i].TenGoc = tempTenGoc;
                self.DMThuocs()[i].TenTM = tempTenTM;
                self.DMThuocs()[i].HamLuong = tempHamLuong;
                self.DMThuocs()[i].GhiChu = tempGhiChu;
                self.DMThuocs()[i].MaBYT = tempMaBYT;
                self.DMThuocs()[i].TenBYT = tempTenBYT;
                self.DMThuocs()[i].SoDangKy = tempSoDangKy;
                self.DMThuocs()[i].Huy = tempHuy;
            }
        }
        DMThuoc.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }

    self.cancel = function (DMThuoc) {
        self.subCancel(DMThuoc);
        temp = null;
        tempMaNhom = "";
        tempMaNhom_Edit = "";
        tempMaPL = "";
        tempMaPL_Edit = "";
        tempMaChungLoai = "";
        tempMaChungLoai_Edit = "";
        tempMaDangBaoChe = "";
        tempMaDangBaoChe_Edit = "";
        tempTenGoc = "";
        tempTenTM = "";
        tempHamLuong = "";
        tempMaDVT = "";
        tempMaDVT_Edit = "";
        tempMaNSX = "";
        tempMaNSX_Edit = "";
        tempGhiChu = "";
        tempMaQG = "";
        tempMaQG_Edit = "";
        tempMaDuongDung = "";
        tempMaDuongDung_Edit = "";
        tempMaBYT = "";
        tempTenBYT = "";
        tempSoDangKy = "";
        tempHuy = false;
        var item = self.DMThuocs()[0];
        if (self.AddNew()) {
            self.DMThuocs.remove(DMThuoc);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMThuoc) {
        if ($('#txtQuyenXem').val() == 'true')
        {
            if (confirm('Bạn chắc chắn muốn xóa phân loại thuốc "' + DMThuoc.MaThuoc + ' - ' + DMThuoc.TenGoc + '" ?')) {
                DMThuoc.Huy = true;
                self.deleteThuoc(DMThuoc);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DMThuoc) {
        self.selectedItem(DMThuoc);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMThuocs().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMThuocs().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMThuocs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaThuoc), 31);
        $('#' + self.selectedItem().MaThuoc).focus();
    };

    self.selectNext = function () {
        //var index = self.DMThuocs().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined)
        { index = self.DMThuocs().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMThuocs().length) index = self.DMThuocs().length - 1;
        self.selectedItem(self.DMThuocs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaThuoc), 31);
        $('#' + self.selectedItem().MaThuoc).focus();
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
                $('#' + self.selectedItem().MaThuoc).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaThuoc).focus();
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
            $('#' + self.selectedItem().MaThuoc).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaThuoc).focus();
            }
            if (this.MaThuoc != self.selectedItem().MaThuoc) {
                var index = self.DMThuocs().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMThuocs().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaThuoc).focus();
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
        //bắt sự kiện nhấn enter ở nút nhập tên phân loại thuốc
        $('#txtiTenPL').keypress(function (e) {
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
        //set focus vào ô nhập mới tên phân loại thuốc khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenPL').focus();
        }
        else {
            $('#txtiTenPL').attr('disabled','disabled');
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
        var TenNhom = $('#txtsTenNhom').val();
        if (TenNhom == undefined && $('#cbofNhom').select2('data') != undefined)
            TenNhom = $('#cbofNhom').select2('data').text;
        var TenPL = $('#txtsTenPL').val();
        if (TenPL == undefined && $('#cbofPhanLoai').select2('data') != undefined)
            TenPL = $('#cbofPhanLoai').select2('data').text;
        var TenChungLoai = $('#txtsTenChungLoai').val();
        if (TenChungLoai == undefined && $('#cbofChungLoai').select2('data') != undefined)
            TenChungLoai = $('#cbofChungLoai').select2('data').text;
        var TenDangBaoChe = $('#txtsTenDangBaoChe').val();
        if (TenDangBaoChe == undefined && $('#cbofDangBaoChe').select2('data') != undefined)
            TenDangBaoChe = $('#cbofDangBaoChe').select2('data').text;
        var TenDVT = $('#txtsTenDVT').val();
        if (TenDVT == undefined && $('#cbofDonvitinh').select2('data') != undefined)
            TenDVT = $('#cbofDonvitinh').select2('data').text;
        var TenNSX = $('#txtsTenNSX').val();
        if (TenNSX == undefined && $('#cbofNhaSX').select2('data') != undefined)
            TenNSX = $('#cbofNhaSX').select2('data').text;
        var TenQG = $('#txtsTenQG').val();
        if (TenQG == undefined && $('#cbofQuocGia').select2('data') != undefined)
            TenQG = $('#cbofQuocGia').select2('data').text;
        var TenDuongDung = $('#txtsTenDuongDung').val();
        if (TenDuongDung == undefined && $('#cbofDuongDung').select2('data') != undefined)
            TenDuongDung = $('#cbofDuongDung').select2('data').text;
        var data = {
            MaThuoc: $('#txtsMaThuoc').val(),
            TenNhom: TenNhom,
            TenPL: TenPL,
            TenChungLoai: TenChungLoai,
            TenDangBaoChe: TenDangBaoChe,
            TenGoc: $('#txtsTenGoc').val(),
            TenTM: $('#txtsTenTM').val(),
            HamLuong: $('#txtsHamLuong').val(),
            TenDVT: TenDVT,
            TenNSX: TenNSX,
            GhiChu: $('#txtsGhiChu').val(),
            TenQG: TenQG,
            TenDuongDung: TenDuongDung,
            MaBYT: $('#txtsMaBYT').val(),
            TenBYT: $('#txtsTenBYT').val(),
            SoDangKy: $('#txtsSoDangKy').val(),
            MaMay: $('#txtsMaMay').val(),
            NgaySD: ngay,
            NguoiSD: $('#txtsNguoiSD').val(),
            pageIndex: self.pageIndex,
            pageSize: self.pageSize,
            add: add,
            
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMThuoc/LoadData', data, function (data) {
            self.tongSoBanGhi(data.totalCounts);
            self.tongSoTrang = data.totalPages;
            self.DMThuocs(ko.utils.arrayMap(data.items, function (DMThuoc) {
                STT += 1;
                var objDMThuoc = {
                    STT: STT,
                    Edit: ko.observable(false),
                    MaThuoc: DMThuoc.maThuoc,
                    MaNhom: DMThuoc.maNhom,
                    TenNhom: DMThuoc.tenNhom,
                    MaPL: DMThuoc.maPL,
                    TenPL: DMThuoc.tenPL,
                    TenChungLoai: DMThuoc.tenChungLoai,
                    MaChungLoai: DMThuoc.maChungLoai,
                    TenDangBaoChe: DMThuoc.tenDangBaoChe,
                    MaDangBaoChe: DMThuoc.maDangBaoChe,
                    TenGoc: DMThuoc.tenGoc,
                    TenTM: DMThuoc.tenTM,
                    HamLuong: DMThuoc.hamLuong,
                    MaDVT: DMThuoc.maDVT,
                    TenDVT: DMThuoc.tenDVT,
                    MaNSX: DMThuoc.maNSX,
                    TenNSX: DMThuoc.tenNSX,
                    GhiChu: DMThuoc.ghiChu,
                    MaQG: DMThuoc.maQG,
                    TenQG: DMThuoc.tenQG,
                    MaDuongDung: DMThuoc.maDuongDung,
                    TenDuongDung: DMThuoc.tenDuongDung,
                    MaBYT: DMThuoc.maBYT,
                    TenBYT: DMThuoc.tenBYT,
                    SoDangKy: DMThuoc.soDangKy,
                    MaMay: (DMThuoc.maMay == undefined) ? "" : DMThuoc.maMay,
                    Huy: DMThuoc.huy,
                    NguoiSD: (DMThuoc.nguoiSD == undefined) ? "" : DMThuoc.nguoiSD,
                    NgaySD: (DMThuoc.ngaySD == undefined) ? "" :Extention.ConvertSQLDateTimeToStringFormat(DMThuoc.ngaySD)
                }
                return objDMThuoc;

                if (DMThuoc.Huy == false) {
                    $('#chkHuy_read').checked(true);
                }
            }));
            if (self.DMThuocs().length != 0) {
            if (self.LoadLanDau())
                self.paging();
            if (self.selectedItem() != undefined) {
                self.selectedItem().Edit(false);
                self.selectItem(self.selectedItem());
                $('#' + self.selectedItem().MaThuoc).focus().addClass('danger');
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
    self.insert = function (DMThuoc) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenPL').val().trim() != '') {
                $.ajax({
                    url: '/DMThuoc/CreateThuoc',
                    type: 'POST',
                    data: {
                        MaNhom: ($('#cboiTenNhom').select2('data') == undefined) ? "" : $('#cboiTenNhom').select2('data').id,
                        MaPL: ($('#cboiTenPL').select2('data') == undefined) ? "" : $('#cboiTenPL').select2('data').id,
                        MaChungLoai: ($('#cboiTenChungLoai').select2('data') == undefined) ? "" : $('#cboiTenChungLoai').select2('data').id,
                        MaDangBaoChe: ($('#cboiTenDangBaoChe').select2('data') == undefined) ? "" : $('#cboiTenDangBaoChe').select2('data').id,
                        TenGoc: $('#txtiTenGoc').val().trim(),
                        TenTM: $('#txtiTenTM').val().trim(),
                        HamLuong: $('#txtiHamLuong').val().trim(),
                        MaDVT: ($('#cboiTenDVT').select2('data') == undefined) ? "" : $('#cboiTenDVT').select2('data').id,
                        MaNSX: ($('#cboiTenNSX').select2('data') == undefined) ? "" : $('#cboiTenNSX').select2('data').id,
                        GhiChu: $('#txtiGhiChu').val().trim(),
                        MaQG: ($('#cboiTenQG').select2('data') == undefined) ? "" : $('#cboiTenQG').select2('data').id,
                        MaDuongDung: ($('#cboiTenDuongDung').select2('data') == undefined) ? "" : $('#cboiTenDuongDung').select2('data').id,
                        MaBYT: $('#txtiMaBYT').val().trim(),
                        TenBYT: $('#txtiTenBYT').val().trim(),
                        SoDangKy: $('#txtiSoDangKy').val().trim(),
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
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên phân loại thuốc');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên phân loại thuốc');
                Extention.errorBorder('txtiTenPL');
                self.cancelInsert();
                $('#txtiTenPL').focus();
            }
        }
    }
    //xóa bản ghi
    self.deleteThuoc = function (DMThuoc) {
        $.ajax({
            url: '/DMThuoc/DeleteThuoc',
            type: 'POST',
            data: { maThuoc: DMThuoc.MaThuoc },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    if (response != null && response.success == false)
                        alert(response.message);
                    else {
                        alert("Xóa phân loại thuốc thành công!");
                        self.loadData();
                    }
                }
            },
            error: function (error) {
                alert("Xóa phân loại thuốc không thành công!");
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
                    url: '/DMThuoc/ImportDanhMuc',
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
                window.open('/DMThuoc/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/DMThuoc/ExportDMThuoc',
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
    self.updateDMThuoc = function (DMThuoc) {
        $.ajax({
            url: '/DMThuoc/Modify',
            type: 'POST',
            data: { Thuoc: DMThuoc },
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
        $('#txtiTenGoc').val('');

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
    //Load danh mục nhóm thuốc
    self.LoadDMThuoc_Nhom = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_Nhom('cboiTenNhom', false, '');
        }
        GeneralCategory.LoadDMThuoc_Nhom('cbofNhom', false, '');
    }
    self.LoadDMThuoc_Nhom();
    //Load danh mục phân loại thuốc
    self.LoadDMThuoc_PhanLoai = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_PhanLoai('cboiTenPL', false, '');
        }
        GeneralCategory.LoadDMThuoc_PhanLoai('cbofPhanLoai', false, '');
    }
    self.LoadDMThuoc_PhanLoai();
    //Load danh mục chủng loại thuốc
    self.LoadDMThuoc_ChungLoai = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_ChungLoai('cboiTenChungLoai', false, '');
        }
        GeneralCategory.LoadDMThuoc_ChungLoai('cbofChungLoai', false, '');
    }
    self.LoadDMThuoc_ChungLoai();
    //Load danh mục dạng bào chế thuốc
    self.LoadDMThuoc_DangBaoChe = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_DangBaoChe('cboiTenDangBaoChe', false, '');
        }
        GeneralCategory.LoadDMThuoc_DangBaoChe('cbofDangBaoChe', false, '');
    }
    self.LoadDMThuoc_DangBaoChe();
    //Load danh mục đơn vị tính thuốc
    self.LoadDMThuoc_Donvitinh = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_Donvitinh('cboiTenDVT', false, '');
        }
        GeneralCategory.LoadDMThuoc_Donvitinh('cbofDonvitinh', false, '');
    }
    self.LoadDMThuoc_Donvitinh();
    //Load danh mục đường dùng thuốc
    self.LoadDMThuoc_DuongDung = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_DuongDung('cboiTenDuongDung', false, '');
        }
        GeneralCategory.LoadDMThuoc_DuongDung('cbofDuongDung', false, '');
    }
    self.LoadDMThuoc_DuongDung();
    //Load danh mục nhà sản xuất thuốc
    self.LoadDMThuoc_NhaSX = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMThuoc_NhaSX('cboiTenNSX', false, '');
        }
        GeneralCategory.LoadDMThuoc_NhaSX('cbofNhaSX', false, '');
    }
    self.LoadDMThuoc_NhaSX();
    //Load danh mục quốc gia
    self.LoadDMQuocGia = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMQuocGia('cboiTenQG', false, '');
        }
        GeneralCategory.LoadDMQuocGia('cbofQuocGia', false, '');
    }
    self.LoadDMQuocGia();
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
ko.applyBindings(new DMThuocViewModel());