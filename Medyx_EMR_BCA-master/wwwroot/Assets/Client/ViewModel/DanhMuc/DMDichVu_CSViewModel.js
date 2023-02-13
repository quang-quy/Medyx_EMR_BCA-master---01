/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMDichVu_CSViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempTenCS;
    var tempMaDV = "";
    var tempMaDV_Edit = "";
    var tempMaXN = "";
    var tempChisocaoNu = "";
    var tempChisocaoNam = "";
    var tempChisothapNu = "";
    var tempChisothapNam = "";
    var tempDonViDo = "";
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
    self.DMDichVu_CSs = ko.observableArray();
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
        { property: "MaCS", header: "Mã chỉ số", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenCS", header: "Tên chỉ số(*)", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenDV", header: "Dịch vụ", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "MaXN", header: "Mã XN", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "ChisocaoNu", header: "CS cao nữ", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "ChisocaoNam", header: "CS cao nam", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "ChisothapNu", header: "CS thấp nữ", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "ChisothapNam", header: "CS thấp nam", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "DonViDo", header: "Đơn vị đo", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
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
        self.DMDichVu_CSs(self.DMDichVu_CSs().sort(function (a, b) {
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
        self.DMDichVu_CSs(self.DMDichVu_CSs().sort(function (a, b) {
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
        self.DMDichVu_CSs(self.DMDichVu_CSs().sort(function (a, b) {
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
        self.DMDichVu_CSs(self.DMDichVu_CSs().sort(function (a, b) {
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
    self.displayMode = function (DMDichVu_CS) {
        return DMDichVu_CS.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMDichVu_CS, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMDichVu_CS.MaDV = (tempMaDV_Edit == "") ? DMDichVu_CS.MaDV : tempMaDV_Edit;
            DMDichVu_CS.TenCS = $('#txtTenCS_Edit').val();
            DMDichVu_CS.MaXN = $('#txtMaXN_Edit').val();
            DMDichVu_CS.ChisocaoNu = $('#txtChisocaoNu_Edit').val();
            DMDichVu_CS.ChisocaoNam = $('#txtChisocaoNam_Edit').val();
            DMDichVu_CS.ChisothapNu = $('#txtChisothapNu_Edit').val();
            DMDichVu_CS.ChisothapNam = $('#txtChisothapNam_Edit').val();
            DMDichVu_CS.DonViDo = $('#txtDonViDo_Edit').val();
            DMDichVu_CS.GhiChu = $('#txtGhiChu_Edit').val();
            self.done(DMDichVu_CS);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DMDichVu_CS, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMDichVu_CS.Huy = !DMDichVu_CS.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMDichVu_CS.TenCS = $('#txtTenCS_Edit').val();
            self.done(DMDichVu_CS);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMDichVu_CS) {
        if ($('#txtQuyenXem').val()=='true')
        {
            tempMaDV_Edit = "";
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMDichVu_CS;
            tempTenCS = DMDichVu_CS.TenCS;
            tempMaXN = DMDichVu_CS.MaXN;
            tempChisocaoNu = DMDichVu_CS.ChisocaoNu;
            tempChisocaoNam = DMDichVu_CS.ChisocaoNam;
            tempChisothapNu = DMDichVu_CS.ChisothapNu;
            tempChisothapNam = DMDichVu_CS.ChisothapNam;
            tempDonViDo = DMDichVu_CS.DonViDo;
            tempGhiChu = DMDichVu_CS.GhiChu;
            tempHuy = DMDichVu_CS.Huy;
            self.AddNew(false);
            DMDichVu_CS.Edit(true);
            //$('#' + self.selectedItem().MaDV).focus();
            GeneralCategory.LoadDMDichVu_CS_Nhom('cboTenDV_Edit', DMDichVu_CS.MaDV, DMDichVu_CS.TenDV);
            $('#txtTenCS_Edit').focus();
            $('#cboTenDV_Edit').on("select2-selected", function (e) {
                tempMaDV_Edit = $('#cboTenDV_Edit').select2('data').id;
            });
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();
        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMDichVu_CS) {
        if (DMDichVu_CS.TenCS.trim() == "") {
            DMDichVu_CS.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMDichVu_CS.Edit(false);
            if (!self.AddNew()) {
                DMDichVu_CS.MaDV = (tempMaDV_Edit == "") ? DMDichVu_CS.MaDV : tempMaDV_Edit;
                DMDichVu_CS.MaPLPTTT = (tempMaPLPTTT_Edit == "") ? DMDichVu_CS.MaPLPTTT : tempMaPLPTTT_Edit;
                DMDichVu_CS.MaChungLoai = (tempMaChungLoai_Edit == "") ? DMDichVu_CS.MaChungLoai : tempMaChungLoai_Edit;
                DMDichVu_CS.MaLH = (tempMaLH_Edit == "") ? DMDichVu_CS.MaLH : tempMaLH_Edit;
                self.updateDMDichVu_CS(DMDichVu_CS);
            }
            temp = null;
            tempTenCS = "";
            tempMaDV = "";
            tempMaDV_Edit = "";
            tempMaXN = "";
            tempChisocaoNu = "";
            tempChisocaoNam = "";
            tempChisothapNu = "";
            tempChisothapNam = "";
            tempDonViDo = "";
            tempGhiChu = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMDichVu_CS) {
        for (var i = 0; i < self.DMDichVu_CSs().length; i++) {
            if (self.DMDichVu_CSs()[i].MaCS == DMDichVu_CS.MaCS) {
                self.DMDichVu_CSs()[i].MaDV = tempMaDV;
                self.DMDichVu_CSs()[i].TenCS = tempTenCS;
                self.DMDichVu_CSs()[i].MaXN = tempMaXN;
                self.DMDichVu_CSs()[i].ChisocaoNu = tempChisocaoNu;
                self.DMDichVu_CSs()[i].ChisocaoNam = tempChisocaoNam;
                self.DMDichVu_CSs()[i].ChisothapNu = tempChisothapNu;
                self.DMDichVu_CSs()[i].ChisothapNam = tempChisothapNam;
                self.DMDichVu_CSs()[i].DonViDo = tempDonViDo;
                self.DMDichVu_CSs()[i].GhiChu = tempGhiChu;
                self.DMDichVu_CSs()[i].Huy = tempHuy;
            }
        }
        DMDichVu_CS.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }

    self.cancel = function (DMDichVu_CS) {
        self.subCancel(DMDichVu_CS);
        temp = null;
        tempTenCS = "";
        tempMaDV = "";
        tempMaDV_Edit = "";
        tempMaXN = "";
        tempChisocaoNu = "";
        tempChisocaoNam = "";
        tempChisothapNu = "";
        tempChisothapNam = "";
        tempDonViDo = "";
        tempGhiChu = "";
        tempHuy = false;
        var item = self.DMDichVu_CSs()[0];
        if (self.AddNew()) {
            self.DMDichVu_CSs.remove(DMDichVu_CS);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMDichVu_CS) {
        if ($('#txtQuyenXem').val() == 'true')
        {
            if (confirm('Bạn chắc chắn muốn xóa chỉ số "' + DMDichVu_CS.MaDV + ' - ' + DMDichVu_CS.TenCS + '" ?')) {
                DMDichVu_CS.Huy = true;
                self.deleteDichVu_CS(DMDichVu_CS);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DMDichVu_CS) {
        self.selectedItem(DMDichVu_CS);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMDichVu_CSs().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMDichVu_CSs().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMDichVu_CSs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaDV), 31);
        $('#' + self.selectedItem().MaDV).focus();
    };

    self.selectNext = function () {
        //var index = self.DMDichVu_CSs().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined)
        { index = self.DMDichVu_CSs().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMDichVu_CSs().length) index = self.DMDichVu_CSs().length - 1;
        self.selectedItem(self.DMDichVu_CSs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaDV), 31);
        $('#' + self.selectedItem().MaDV).focus();
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
                $('#' + self.selectedItem().MaDV).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaDV).focus();
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
            $('#' + self.selectedItem().MaDV).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaDV).focus();
            }
            if (this.MaDV != self.selectedItem().MaDV) {
                var index = self.DMDichVu_CSs().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMDichVu_CSs().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaDV).focus();
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
        //bắt sự kiện nhấn enter ở nút nhập tên chỉ số
        $('#txtiTenCS').keypress(function (e) {
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
        //set focus vào ô nhập mới tên chỉ số khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenCS').focus();
        }
        else {
            $('#txtiTenCS').attr('disabled','disabled');
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
        var TenDV = $('#txtsTenDV').val();
        if (TenDV == undefined && $('#cbofDichVu').select2('data') != undefined)
            TenDV = $('#cbofDichVu').select2('data').text;
        var data = {
            maCS: $('#txtsMaCS').val(),
            TenCS: $('#txtsTenCS').val(),
            TenDV: TenDV,
            ChisocaoNu: $('#txtsChisocaoNu').val(),
            ChisocaoNam: $('#txtsChisocaoNam').val(),
            ChisothapNu: $('#txtsChisothapNu').val(),
            ChisothapNam: $('#txtsChisothapNam').val(),
            DonViDo: $('#txtsDonViDo').val(),
            MaXN: $('#txtsMaXN').val(),
            GhiChu: $('#txtsGhiChu').val(),
            maMay: $('#txtsMaMay').val(),
            ngaySD: ngay,
            nguoiSD: $('#txtsNguoiSD').val(),
            pageIndex: self.pageIndex,
            pageSize: self.pageSize,
            add: add
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMDichVu_CS/LoadData', data, function (data) {
            self.tongSoBanGhi(data.totalCounts);
            self.tongSoTrang = data.totalPages;
            self.DMDichVu_CSs(ko.utils.arrayMap(data.items, function (DMDichVu_CS) {
                STT += 1;
                var objDMDichVu_CS = {
                    STT: STT,
                    Edit: ko.observable(false),
                    MaCS: DMDichVu_CS.maCS,
                    TenCS: DMDichVu_CS.TenCS,
                    MaDV: DMDichVu_CS.maDV,
                    TenDV: DMDichVu_CS.tenDV,
                    MaXN: DMDichVu_CS.maXN,
                    ChisocaoNu: DMDichVu_CS.chisocaoNu,
                    ChisocaoNam: DMDichVu_CS.chisocaoNam,
                    ChisothapNu: DMDichVu_CS.chisothapNu,
                    ChisothapNam: DMDichVu_CS.chisothapNam,
                    DonViDo: DMDichVu_CS.donViDo,
                    GhiChu: DMDichVu_CS.ghiChu,
                    MaMay: (DMDichVu_CS.maMay == undefined) ? "" : DMDichVu_CS.maMay,
                    Huy: DMDichVu_CS.huy,
                    NguoiSD: (DMDichVu_CS.nguoiSD == undefined) ? "" : DMDichVu_CS.nguoiSD,
                    NgaySD: (DMDichVu_CS.ngaySD == undefined) ? "" :Extention.ConvertSQLDateTimeToStringFormat(DMDichVu_CS.ngaySD)
                }
                return objDMDichVu_CS;

                if (DMDichVu_CS.Huy == false) {
                    $('#chkHuy_read').checked(true);
                }
            }));
            if (self.DMDichVu_CSs().length != 0) {
            if (self.LoadLanDau())
                self.paging();
            if (self.selectedItem() != undefined) {
                self.selectedItem().Edit(false);
                self.selectItem(self.selectedItem());
                $('#' + self.selectedItem().MaDV).focus().addClass('danger');
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
    self.insert = function (DMDichVu_CS) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenCS').val().trim() != '') {
                $.ajax({
                    url: '/DMDichVu_CS/CreateDichVu_CS',
                    type: 'POST',
                    data: {
                        TenCS: $('#txtiTenCS').val().trim(),
                        MaDV: ($('#cboiTenDV').select2('data') == undefined) ? "" : $('#cboiTenDV').select2('data').id,
                        ChisocaoNu: $('#txtiChisocaoNu').val().trim(),
                        ChisocaoNam: $('#txtiChisocaoNam').val().trim(),
                        ChisothapNu: $('#txtiChisothapNu').val().trim(),
                        ChisothapNam: $('#txtiChisothapNam').val().trim(),
                        DonViDo: $('#txtiDonViDo').val().trim(),
                        MaXN: $('#txtiMaXN').val().trim(),
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
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên chỉ số');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên chỉ số');
                Extention.errorBorder('txtiTenCS');
                self.cancelInsert();
                $('#txtiTenCS').focus();
            }
        }
    }
    //xóa bản ghi
    self.deleteDichVu_CS = function (DMDichVu_CS) {
        $.ajax({
            url: '/DMDichVu_CS/DeleteDichVu_CS',
            type: 'POST',
            data: { MaCS: DMDichVu_CS.MaCS },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    if (response != null && response.success == false)
                        alert(response.message);
                    else {
                        alert("Xóa chỉ số thành công!");
                        self.loadData();
                    }
                }
            },
            error: function (error) {
                alert("Xóa chỉ số không thành công!");
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
                    url: '/DMDichVu_CS/ImportDanhMuc',
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
                window.open('/DMDichVu_CS/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/DMDichVu_CS/ExportDMDichVu_CS',
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
    self.updateDMDichVu_CS = function (DMDichVu_CS) {
        $.ajax({
            url: '/DMDichVu_CS/Modify',
            type: 'POST',
            data: { DichVu_CS: DMDichVu_CS },
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
        $('#txtiTenCS').val('');

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
    //Load danh mục dịch vụ
    self.LoadDMDichVu = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMDichVu('cboiTenDV', false, '');
        }
        GeneralCategory.LoadDMDichVu('cbofDichVu', false, '');
    }
    self.LoadDMDichVu();
    
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
ko.applyBindings(new DMDichVu_CSViewModel());