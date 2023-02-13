/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DeNghiTrichLucViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempTenCD;
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
    self.DeNghiTrichLucs = ko.observableArray();
    //mang luu danh sach HSBA
    self.HSBAs = ko.observableArray();
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
        { property: "Chon", header: "Chọn", type: "", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "SoPhieu", header: "Số phiếu", type: "number", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "TenLoaiDeNghi", header: "Loại đơn", type: "string", state: ko.observable(""), width: '30%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "MaBA", header: "Mã bệnh án", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "MaMay", header: "Mã máy", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "Huy", header: "Hủy", type: "", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "TenNguoiSD", header: "Người SD", type: "string", state: ko.observable(""), width: '15%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "NgaySD", header: "Ngày SĐ", type: "string", state: ko.observable(""), width: '15%', visible: ko.observable(true), field: '', search: 'date' },
        { property: "LoaiDeNghi", header: "LoaiDeNghi", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "Duyet", header: "Duyet", type: "", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: 'checkbox', search: '' },
        { property: "NgayDuyet", header: "NgayDuyet", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'date' },
        { property: "HoTenNguoiDeNghi", header: "HoTenNguoiDeNghi", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "NgaySinhNguoiDN", header: "NgaySinhNguoiDN", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'date' },
        { property: "SoCMT", header: "SoCMT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "NgayCapCMT", header: "NgayCapCMT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'date' },
        { property: "NoiCapCMT", header: "NoiCapCMT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "QHBN", header: "QHBN", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "HoTenBN", header: "HoTenBN", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "DiaChi", header: "DiaChi", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "TGVQ", header: "TGVQ", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "MaKhoaDT", header: "MaKhoaDT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "TenKhoaDT", header: "TenKhoaDT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "TuNgayDT", header: "TuNgayDT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'date' },
        { property: "DenNgayDT", header: "DenNgayDT", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'date' },
        { property: "LyDo", header: "LyDo", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "NgayLap", header: "NgayLap", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'date' },
        { property: "NguoiLap", header: "NguoiLap", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "NguoiSD", header: "NguoiSD", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "LoaiDeNghi", header: "LoaiDeNghi", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(false), field: '', search: 'string' },

    ]);
    self.columnBNs = ko.observableArray([
        { property: "ID", header: "ID", type: "number", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "MaBA", header: "Mã bệnh án", type: "string", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "MaBN", header: "Mã bệnh nhân", type: "string", state: ko.observable(""), width: '7%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "Hoten", header: "Tên bệnh nhân", type: "string", state: ko.observable(""), width: '20%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "GT", header: "Giới tính", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "NgaySinh", header: "Ngày Sinh", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'date' },
        { property: "KhoaDT", header: "Khoa điều trị", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenBenh", header: "Tên bệnh", type: "string", state: ko.observable(""), width: '15%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "NgayVV", header: "Ngày vào viện", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'date' },
        { property: "NgayRV", header: "Ngày ra viện", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'date' }
    ]);
    //Khởi tạo mảng lưu các cột được export
    var cot = "";
    $(self.columns()).each(function (index, value) {
        if (value.visible) {
            if (value.property == 'ThaoTac' || value.property == 'STT') { }
            else {
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
        self.DeNghiTrichLucs(self.DeNghiTrichLucs().sort(function (a, b) {
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
        self.DeNghiTrichLucs(self.DeNghiTrichLucs().sort(function (a, b) {
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
        self.DeNghiTrichLucs(self.DeNghiTrichLucs().sort(function (a, b) {
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
        self.DeNghiTrichLucs(self.DeNghiTrichLucs().sort(function (a, b) {
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
    self.displayMode = function (DeNghiTrichLuc) {
        return DeNghiTrichLuc.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DeNghiTrichLuc, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DeNghiTrichLuc.TenCD = $('#txtTenCD_Edit').val();
            self.done(DeNghiTrichLuc);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DeNghiTrichLuc, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DeNghiTrichLuc.Huy = !DeNghiTrichLuc.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DeNghiTrichLuc.TenCD = $('#txtTenCD_Edit').val();
            self.done(DeNghiTrichLuc);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DeNghiTrichLuc) {
        if ($('#txtQuyenXem').val() == 'true') {
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DeNghiTrichLuc;
            tempTenCD = DeNghiTrichLuc.SoPhieu;
            tempHuy = DeNghiTrichLuc.Huy;
            self.AddNew(false);
            self.LoadDN();
            $('#ThongTinTrichLucPopUp').modal("show");

            //DeNghiTrichLuc.Edit(true);
            //$('#' + self.selectedItem().MaCD).focus();
            //$('#txtTenCD_Edit').focus();
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();
        }
    }
    //chon 1 HSBA de de nghi trich luc
    self.editBA = function (HSBA) {
        if ($('#txtQuyenXem').val() == 'true') {
            //if (temp != undefined) {
            //    self.cancel(temp);
            //}
            //temp = DeNghiTrichLuc;
            //tempTenCD = DeNghiTrichLuc.TenCD;
            //tempHuy = DeNghiTrichLuc.Huy;
            //self.AddNew(false);
            //DeNghiTrichLuc.Edit(true);
            //$('#' + self.selectedItem().MaCD).focus();
            //$('#txtTenCD_Edit').focus();
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();
            $('#txtHoTenBN').val(HSBA.Hoten);
            $('#txtMaBA').val(HSBA.MaBA);
            //var d = new Date();
            //var vv = HSBA.NgayVV.substring(0, 10);
            //var dd = vv.substring(0, 2);
            //var mm = vv.substring(3, 5);
            //var yyyy = vv.substring(6, 10);
            //d = dd + '/' + mm + '/' + yyyy;
            //$('#dtTuNgay').val(d);
            $("#dtTuNgay").datepicker("update", Extention.strToDate2(HSBA.NgayVV.substring(0, 10)));
            //var rv = HSBA.NgayRV.substring(0, 10);
            //dd = rv.substring(0, 2);
            //mm = rv.substring(3, 5);
            //yyyy = rv.substring(6, 10);
            //d = dd + '/' + mm + '/' + yyyy;
            //$('#dtDenNgay').val(d);
            $("#dtDenNgay").datepicker("update", Extention.strToDate2(HSBA.NgayRV.substring(0, 10)));
        }
    }
    //RefreshDN
    self.RefreshDN = function () {
        $("#cboLoaiDeNghi").select2("val", "");
        $("#txtMaBA").val('');
        $("#txtHoTenNguoiDeNghi").val('');
        $('#dtNgaySinh').val('').datepicker('update');
        $("#txtSoCMT").val('');
        $('#dtNgayCapCMT').val('').datepicker('update');
        $("#txtNoiCapCMT").val('');
        $("#txtQHBN").val('');
        $("#txtHoTenBN").val('');
        $("#txtDiaChi").val('');
        $("#txtTGVQ").val('');
        $("#txtDVCT").val('');
        $("#txtNhamLan").val('');
        $("#txtCMNhamLan").val('');
        $("#txtMatRach").val('');
        $("#cboKhoa").select2("val", "");
        $('#dtTuNgay').val('').datepicker('update');
        $('#dtDenNgay').val('').datepicker('update');
        $("#txtLyDo").val('');
        self.HSBAs.removeAll();
        $('#chkHuy').checked = false;
        $('#chkDuyet').checked = false;
        $('#dtNgayDuyet').val('').datepicker('update');
    }
    //load DN
    self.LoadDN = function () {
        if (temp != undefined) {
            $("#cboLoaiDeNghi").select2("val", temp.LoaiDeNghi);
            $("#txtMaBA").val(temp.MaBA);
            $("#txtHoTenNguoiDeNghi").val(temp.HoTenNguoiDeNghi);
            if (temp.NgaySinhNguoiDN != undefined && temp.NgaySinhNguoiDN.length > 0)
                $('#dtNgaySinh').datepicker('update', Extention.strToDate2(temp.NgaySinhNguoiDN.substring(0, 10)));
            $("#txtSoCMT").val(temp.SoCMT);
            if (temp.NgayCapCMT != undefined && temp.NgayCapCMT.length > 0)
                $('#dtNgayCapCMT').datepicker('update', Extention.strToDate2(temp.NgayCapCMT.substring(0, 10)));
            $("#txtNoiCapCMT").val(temp.NoiCapCMT);
            $("#txtQHBN").val(temp.QHBN);
            $("#txtHoTenBN").val(temp.HoTenBN);
            $("#txtDiaChi").val(temp.DiaChi);
            $("#txtTGVQ").val(temp.TGVQ);
            $("#txtDVCT").val(temp.DVCT);
            $("#txtNhamLan").val(temp.NhamLan);
            $("#txtCMNhamLan").val(temp.CMNhamLan);
            $("#txtMatRach").val(temp.MatRach);
            $("#cboKhoa").select2("val", temp.MaKhoaDT);
            if (temp.TuNgayDT != undefined && temp.TuNgayDT.length > 0)
                $('#dtTuNgay').datepicker('update', Extention.strToDate2(temp.TuNgayDT.substring(0, 10)));
            if (temp.DenNgayDT != undefined && temp.DenNgayDT.length > 0)
                $('#dtDenNgay').datepicker('update', Extention.strToDate2(temp.DenNgayDT.substring(0, 10)));
            $("#txtLyDo").val(temp.LyDo);
            $('#chkHuy').prop('checked', temp.Huy);
            $('#chkDuyet').prop('checked', temp.Duyet);
            if (temp.Duyet == true) {
                $("#lblNgayDuyet").css("visibility", "visible");
                $("#dtNgayDuyet").css("visibility", "visible");
            }
            if (temp.NgayDuyet != undefined && temp.NgayDuyet.length > 0 && temp.NgayDuyet !='01/01/1900 00:00:00')
                $('#dtNgayDuyet').datepicker('update', Extention.strToDate2(temp.NgayDuyet.substring(0, 10)));
            else
                $('#dtNgayDuyet').datepicker('update', Extention.GetCurrentDateFormat());
        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DeNghiTrichLuc) {
        if (DeNghiTrichLuc.TenCD.trim() == "") {
            DeNghiTrichLuc.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DeNghiTrichLuc.Edit(false);
            if (!self.AddNew()) {
                self.updateDeNghiTrichLuc(DeNghiTrichLuc);
            }
            temp = null;
            tempTenCD = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DeNghiTrichLuc) {
        for (var i = 0; i < self.DeNghiTrichLucs().length; i++) {
            if (self.DeNghiTrichLucs()[i].MaCD == DeNghiTrichLuc.MaCD) {
                self.DeNghiTrichLucs()[i].TenCD = tempTenCD;
                self.DeNghiTrichLucs()[i].Huy = tempHuy;
            }
        }
        DeNghiTrichLuc.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }

    self.cancel = function (DeNghiTrichLuc) {
        self.subCancel(DeNghiTrichLuc);
        temp = null;
        tempTenCD = "";
        tempHuy = false;
        var item = self.DeNghiTrichLucs()[0];
        if (self.AddNew()) {
            self.DeNghiTrichLucs.remove(DeNghiTrichLuc);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DeNghiTrichLuc) {
        if ($('#txtQuyenXem').val() == 'true') {
            if (confirm('Bạn chắc chắn muốn xóa chức danh "' + DeNghiTrichLuc.MaCD + ' - ' + DeNghiTrichLuc.TenCD + '" ?')) {
                DeNghiTrichLuc.Huy = true;
                self.deleteChucDanh(DeNghiTrichLuc);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DeNghiTrichLuc) {
        self.selectedItem(DeNghiTrichLuc);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DeNghiTrichLucs().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DeNghiTrichLucs().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DeNghiTrichLucs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaCD), 31);
        $('#' + self.selectedItem().MaCD).focus();
    };

    self.selectNext = function () {
        //var index = self.DeNghiTrichLucs().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined) { index = self.DeNghiTrichLucs().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DeNghiTrichLucs().length) index = self.DeNghiTrichLucs().length - 1;
        self.selectedItem(self.DeNghiTrichLucs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaCD), 31);
        $('#' + self.selectedItem().MaCD).focus();
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
                $('#' + self.selectedItem().MaCD).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaCD).focus();
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
            $('#' + self.selectedItem().MaCD).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaCD).focus();
            }
            if (this.MaCD != self.selectedItem().MaCD) {
                var index = self.DeNghiTrichLucs().indexOf(self.selectedItem()) + 1;
                if (index >= self.DeNghiTrichLucs().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaCD).focus();
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
        //bắt sự kiện nhấn enter ở nút nhập tên chức danh
        $('#txtiTenCD').keypress(function (e) {
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
        //set focus vào ô nhập mới tên chức danh khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenCD').focus();
        }
        else {
            $('#txtiTenCD').attr('disabled', 'disabled');
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
        $('#dtNgaySinh,#dtNgayDuyet,#dtNgayCapCMT,#dtTuNgay,#dtDenNgay,#dtTuNgayDN,#dtDenNgayDN').datepicker({
            // dateFormat: 'dd-mm-yy',
            //dateFormat: 'dd/mm/yy HH:mm:ss'
            format: 'dd/mm/yyyy',
            language: 'vi'
        });
        $("#dtNgaySinh,#dtNgayDuyet,#dtNgayCapCMT,#dtTuNgay,#dtDenNgay,#dtTuNgayDN,#dtDenNgayDN").mask("99/99/9999");
        $("#lblNgayDuyet").css("visibility", "hidden");
        $("#dtNgayDuyet").css("visibility", "hidden");
        $("#chkDuyet").change(function () {
            if (this.checked) {
                $("#lblNgayDuyet").css("visibility", "visible");
                $("#dtNgayDuyet").css("visibility", "visible");
            }
            else {
                $("#lblNgayDuyet").css("visibility", "hidden");
                $("#dtNgayDuyet").css("visibility", "hidden");
            }
        });
    });
    //load dữ liệu
    self.loadData = function () {
        var tungay = $('#dtTuNgayDN').val().trim();
        var denngay = $('#dtDenNgayDN').val().trim();
        var tenLoaiDeNghi = $('#txtsTenLoaiDeNghi').val();
        var cboldn = $('#cboLoaiDeNghiF').val();
        if (tenLoaiDeNghi == '' || tenLoaiDeNghi == undefined)
            tenLoaiDeNghi = cboldn;
        var Duyet = $("#chkDuyetF").is(":checked");
        if (Duyet == undefined)
            Duyet = false;
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        var kt = urlParams.get('KhaiThac') == null ? 'False' : urlParams.get('KhaiThac');
        if (kt == "True")
            Duyet = true;
        if (tungay == '' || tungay == undefined) {
            alert('Chọn từ ngày lập phiếu để tìm kiếm!');
            $('#dtTuNgayDN').focus();
        }
        //else if (!Extention.dateIsValid(tungay)) {
        //    alert('Chọn từ ngày lập phiếu để tìm kiếm không đúng định dạng!');
        //    $('#dtTuNgayDN').focus();
        //}
        else if (denngay == '' || denngay == undefined) {
            alert('Chọn đến ngày lập phiếu để tìm kiếm!');
            $('#denngay').focus();
        }
        //else if (!Extention.dateIsValid(denngay))
        //{
        //    alert('Chọn đến ngày lập phiếu để tìm kiếm không đúng định dạng!');
        //    $('#denngay').focus();
        //}
        else {
            var add = false;
            if (self.checkAdd() == true) {
                add = true;
            }
            tungay = Extention.convertToMMDDYYYY(tungay);
            denngay = Extention.convertToMMDDYYYY(denngay);
            var ngay = $('#txtsNgaySD').val();
            if (ngay == '') {
                ngay = undefined;
            }
            else if (ngay != undefined) {
                ngay = Extention.convertToMMDDYYYY(ngay);
            }
            var data = {
                sophieu: $('#txtsSoPhieu').val(),
                tenLoaiDeNghi: tenLoaiDeNghi,
                maba: $('#txtstenLoaiDeNghi').val(),
                tungay: tungay,
                denngay: denngay,
                Duyet: Duyet,
                maMay: $('#txtsMaMay').val(),
                ngaySD: ngay,
                nguoiSD: $('#txtsNguoiSD').val(),
                pageIndex: self.pageIndex,
                pageSize: self.pageSize,
                add: add
            };
            STT = self.pageSize() * (self.pageIndex() - 1);
            $.getJSON('/TrichLucHSBA/LoadData', data, function (data) {
                self.tongSoBanGhi(data.totalCounts);
                self.tongSoTrang = data.totalPages;
                self.DeNghiTrichLucs(ko.utils.arrayMap(data.items, function (DeNghiTrichLuc) {
                    var objDeNghiTrichLuc = {
                        Edit: ko.observable(false),
                        Chon: ko.observable(false),
                        SoPhieu: DeNghiTrichLuc.soPhieu,
                        MaBA: DeNghiTrichLuc.maBA,
                        LoaiDeNghi: DeNghiTrichLuc.loaiDeNghi,
                        TenLoaiDeNghi: DeNghiTrichLuc.tenLoaiDeNghi,
                        Duyet: DeNghiTrichLuc.duyet,
                        NgayDuyet: DeNghiTrichLuc.ngayDuyet != undefined ? Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.ngayDuyet):'',
                        HoTenNguoiDeNghi: DeNghiTrichLuc.hoTenNguoiDeNghi,
                        NgaySinhNguoiDN: DeNghiTrichLuc.ngaySinhNguoiDN != undefined ?Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.ngaySinhNguoiDN):'',
                        SoCMT: DeNghiTrichLuc.soCMT,
                        NgayCapCMT: DeNghiTrichLuc.ngayCapCMT != undefined ?Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.ngayCapCMT):'',
                        NoiCapCMT: DeNghiTrichLuc.noiCapCMT,
                        QHBN: DeNghiTrichLuc.qhbn,
                        HoTenBN: DeNghiTrichLuc.hoTenBN,
                        DiaChi: DeNghiTrichLuc.diaChi,
                        TGVQ: DeNghiTrichLuc.tgvq,
                        MaKhoaDT: DeNghiTrichLuc.maKhoaDT,
                        TenKhoaDT: DeNghiTrichLuc.tenKhoaDT,
                        TuNgayDT: DeNghiTrichLuc.tuNgayDT != undefined ?Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.tuNgayDT):'',
                        DenNgayDT: DeNghiTrichLuc.denNgayDT != undefined ?Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.denNgayDT):'',
                        LyDo: DeNghiTrichLuc.lyDo,
                        MaMay: (DeNghiTrichLuc.maMay == undefined) ? "" : DeNghiTrichLuc.maMay,
                        Huy: DeNghiTrichLuc.huy,
                        NguoiSD: (DeNghiTrichLuc.nguoiSD == undefined) ? "" : DeNghiTrichLuc.nguoiSD,
                        TenNguoiSD: (DeNghiTrichLuc.tenNguoiSD == undefined) ? "" : DeNghiTrichLuc.tenNguoiSD,
                        NguoiLap: (DeNghiTrichLuc.nguoiLap == undefined) ? "" : DeNghiTrichLuc.nguoiLap,
                        NgayLap: DeNghiTrichLuc.ngayLap != undefined ?Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.ngayLap):'',
                        NgaySD: DeNghiTrichLuc.ngaySD != undefined ? Extention.ConvertSQLDateTimeToStringFormat(DeNghiTrichLuc.ngaySD) : '',
                        DVCT: DeNghiTrichLuc.dvct,
                        NhamLan: DeNghiTrichLuc.nhamLan,
                        CMNhamLan: DeNghiTrichLuc.cmNhamLan,
                        MatRach: DeNghiTrichLuc.matRach
                    }
                    return objDeNghiTrichLuc;

                    if (DeNghiTrichLuc.Huy == false) {
                        $('#chkHuy_read').checked(true);
                    }
                }));
                if (self.DeNghiTrichLucs().length != 0) {
                    if (self.LoadLanDau())
                        self.paging();
                    if (self.selectedItem() != undefined) {
                        self.selectedItem().Edit(false);
                        self.selectItem(self.selectedItem());
                        $('#' + self.selectedItem().MaCD).focus().addClass('danger');
                    }
                }
                else {
                    alert('Không có dữ liệu để hiển thị!');
                }
            });
        }
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
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        var duyet = urlParams.get('Duyet') == null ? 'false' : urlParams.get('Duyet');

        if (duyet == 'true') {
            $("#chkDuyet").removeAttr("disabled");
            $("#divDuyetF").show();

        } else {
            $("#chkDuyet").attr("disabled", true);
            $("#divDuyetF").hide();
        }
        //var today = new Date();
        //var dd = String(today.getDate()).padStart(2, '0');
        //var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        //var yyyy = today.getFullYear();

        //today = dd + '/' + mm + '/' + yyyy;
        var today = Extention.GetCurrentDateFormat();
        $('#dtTuNgayDN').val(today);
        $('#dtDenNgayDN').val(today);
        //self.regestEvent();
        self.loadData();
    }
    self.init();
    //thêm mới bản ghi
    self.insert = function (DeNghiTrichLuc) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenCD').val().trim() != '') {
                $.ajax({
                    url: '/TrichLucHSBA/CreateChucDanh',
                    type: 'POST',
                    data: { tenCD: $('#txtiTenCD').val().trim() },
                    success: function (response) {
                        if (response != null && response.success == false)
                            if (response != null && response.success == false)
                                alert(response.message);
                            else {
                                alert('Thêm mới thành công!');
                                self.cancelInsert();
                                self.loadData();
                            }
                    },
                    error: function (error) {
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên chức danh');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên chức danh');
                Extention.errorBorder('txtiTenCD');
                self.cancelInsert();
                $('#txtiTenCD').focus();
            }
        }
    }
    //xóa bản ghi
    self.delete = function (DeNghiTrichLuc) {
        var answerm = confirm("Xác nhận hủy phiếu?")
        if (answerm) {
            $.ajax({
                url: '/TrichLucHSBA/DeleteDN',
                type: 'POST',
                data: { sophieu: DeNghiTrichLuc.SoPhieu },
                success: function (response) {
                    if (response != null && response.success == false)
                        alert(response.message);
                    else {
                        if (response != null && response.success == false)
                            alert(response.message);
                        else {
                            alert("Xóa phiếu thành công!");
                            self.loadData();
                        }
                    }
                },
                error: function (error) {
                    alert("Xóa phiếu không thành công!");
                }
            })
        }
    }
    //Import dữ liệu
    self.Import = function () {
        if (temp != undefined) {
            self.cancel(temp);
        }
        self.RefreshDN();
        $('#ThongTinTrichLucPopUp').modal("show");

        //GeneralCategory.CreateSearchTemplate('theadBN', self.columnBNs());
        //GeneralCategory.CreateReadTemplate('tableDSBN', self.columnBNs(), '');
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
                    url: '/TrichLucHSBA/ImportDanhMuc',
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
    //tim kiem hsba
    self.findHSBA = function () {
        var hotenbn = $('#txtHoTenBN').val();
        if (hotenbn.trim().length == 0) {
            alert('Chưa nhập họ tên bệnh nhân cần tìm kiếm!');
            $('#txtHoTenBN').focus();
        }
        else {
            var tungay = $('#dtTuNgay').val();
            if (tungay == '') {
                tungay = undefined;
                alert('Chưa nhập ngày vào viện của bệnh nhân cần tìm kiếm!');
                $('#dtTuNgay').focus();
            }
            else if (tungay != undefined) {
                tungay = Extention.convertToMMDDYYYY(tungay);
                var denngay = $('#dtDenNgay').val();
                if (denngay == '') {
                    denngay = undefined;
                    alert('Chưa nhập ngày ra viện của bệnh nhân cần tìm kiếm!');
                    $('#dtDenNgay').focus();
                }
                else if (tungay != undefined) {
                    denngay = Extention.convertToMMDDYYYY(denngay);
                    var khoa = $('#cboKhoa').val();
                    if (khoa.length == 0) {
                        alert('Chưa chọn khoa nằm viện của bệnh nhân cần tìm kiếm!');
                        $('#cboKhoa').focus();
                    }
                    else {
                        var data = {
                            hotenbn: hotenbn,
                            tungay: tungay,
                            denngay: denngay,
                            khoa: khoa
                        };
                        $.getJSON('/TrichLucHSBA/FindHSBA', data, function (data) {
                            //self.tongSoBanGhi(data.totalCounts);
                            //self.tongSoTrang = data.totalPages;
                            self.HSBAs(ko.utils.arrayMap(data.items, function (HSBA) {
                                var objHSBA = {
                                    ID: HSBA.id,
                                    Edit: ko.observable(false),
                                    MaBA: HSBA.maBA,
                                    MaBN: HSBA.mabn,
                                    Hoten: HSBA.hoTen,
                                    GT: HSBA.gt,
                                    //MaMay: (DeNghiTrichLuc.maMay == undefined) ? "" : DeNghiTrichLuc.maMay,
                                    //NguoiSD: (DeNghiTrichLuc.nguoiSD == undefined) ? "" : DeNghiTrichLuc.nguoiSD,
                                    NgaySinh: Extention.ConvertSQLDateTimeToStringFormat(HSBA.ngaySinh),
                                    KhoaDT: HSBA.khoaDT,
                                    MaKhoaDT: HSBA.maKhoaDT,
                                    TenBenh: HSBA.tenBenh,
                                    NgayVV: Extention.ConvertSQLDateTimeToStringFormat(HSBA.ngayVV),
                                    NgayRV: Extention.ConvertSQLDateTimeToStringFormat(HSBA.ngayRV)
                                }
                                return objHSBA;
                            }));
                            if (self.HSBAs().length != 0) {
                                //if (self.LoadLanDau())
                                //    self.paging();
                                if (self.selectedItem() != undefined) {
                                    self.selectedItem().Edit(false);
                                    self.selectItem(self.selectedItem());
                                    $('#' + self.selectedItem().ID).focus().addClass('danger');
                                }
                            }
                            else {
                                alert('Không có dữ liệu để hiển thị!');
                            }
                        });
                    }
                }
            }
        }
    }
    //luu phieu DN
    self.SaveDN = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            var cboLoaiDeNghi = $('#cboLoaiDeNghi').val();
            if (cboLoaiDeNghi.length == 0) {
                alert('Chưa chọn loại đơn!');
                $('#cboLoaiDeNghi').focus();
            }
            else {
                var MaBA = $('#txtMaBA').val();
                if (MaBA.length == 0) {
                    alert('Chưa chọn mã bệnh án!');
                    $('#txtMaBA').focus();
                }
                else {
                    var txtHoTenNguoiDeNghi = $('#txtHoTenNguoiDeNghi').val();
                    if (txtHoTenNguoiDeNghi.trim().length == 0) {
                        alert('Chưa nhập họ tên người đề nghị!');
                        $('#txtHoTenNguoiDeNghi').focus();
                    }
                    else {
                        var txtSoCMT = $('#txtSoCMT').val();
                        if (txtSoCMT.trim().length == 0) {
                            alert('Chưa nhập số CMT người đề nghị!');
                            $('#txtSoCMT').focus();
                        }
                        else {
                            var hotenbn = $('#txtHoTenBN').val();
                            if (hotenbn.trim().length == 0) {
                                alert('Chưa nhập họ tên bệnh nhân!');
                                $('#txtHoTenBN').focus();
                            }
                            else {
                                var dtNgaySinh = $('#dtNgaySinh').val();
                                if (dtNgaySinh == '') {
                                    dtNgaySinh = undefined;
                                    alert('Chưa nhập ngày sinh của người đề nghị!');
                                    $('#dtNgaySinh').focus();
                                }
                                else if (dtNgaySinh != undefined) {
                                    dtNgaySinh = Extention.convertToMMDDYYYY(dtNgaySinh);
                                    var tungay = $('#dtTuNgay').val();
                                    if (tungay == '') {
                                        tungay = undefined;
                                        alert('Chưa nhập ngày vào viện của bệnh nhân!');
                                        $('#dtTuNgay').focus();
                                    }
                                    else if (tungay != undefined) {
                                        tungay = Extention.convertToMMDDYYYY(tungay);
                                        var denngay = $('#dtDenNgay').val();
                                        if (denngay == '') {
                                            denngay = undefined;
                                            alert('Chưa nhập ngày ra viện của bệnh nhân!');
                                            $('#dtDenNgay').focus();
                                        }
                                        else if (tungay != undefined) {
                                            denngay = Extention.convertToMMDDYYYY(denngay);
                                            var khoa = $('#cboKhoa').val();
                                            if (khoa.length == 0) {
                                                alert('Chưa chọn khoa nằm viện của bệnh nhân!');
                                                $('#cboKhoa').focus();
                                            }

                                            else {
                                                var sophieu;
                                                if (tempTenCD != undefined) {
                                                    sophieu = tempTenCD;
                                                }
                                                else
                                                    sophieu = "";
                                                var huy = $('#chkHuy').is(":checked");
                                                var duyet = $('#chkDuyet').is(":checked");
                                                var dtNgayCapCMT = $('#dtNgayCapCMT').val();
                                                if (dtNgayCapCMT != '')
                                                    dtNgayCapCMT = Extention.convertToMMDDYYYY(dtNgayCapCMT);
                                                var dtNgayDuyet = $('#dtNgayDuyet').val();
                                                if (dtNgayDuyet != '')
                                                    dtNgayDuyet = Extention.convertToMMDDYYYY(dtNgayDuyet);
                                                else dtNgayDuyet = "";
                                                var data = {
                                                    LoaiDeNghi: cboLoaiDeNghi,
                                                    MaBA: MaBA,
                                                    HoTenNguoiDeNghi: txtHoTenNguoiDeNghi,
                                                    NgaySinhNguoiDN: dtNgaySinh,
                                                    SoCMT: txtSoCMT,
                                                    NgayCapCMT: dtNgayCapCMT,
                                                    NoiCapCMT: $('#txtNoiCapCMT').val() == undefined ? "" : $('#txtNoiCapCMT').val(),
                                                    QHBN: $('#txtQHBN').val() == undefined ? "" : $('#txtQHBN').val(),
                                                    HoTenBN: hotenbn,
                                                    DiaChi: $('#txtDiaChi').val() == undefined ? "" : $('#txtDiaChi').val(),
                                                    TGVQ: $('#txtTGVQ').val() == undefined ? "" : $('#txtTGVQ').val(),
                                                    MaKhoaDT: khoa,
                                                    TuNgayDT: tungay,
                                                    DenNgayDT: denngay,
                                                    LyDo: $('#txtLyDo').val() == undefined ? "" : $('#txtLyDo').val(),
                                                    sophieu: sophieu,
                                                    Duyet: duyet,
                                                    ngayduyet: dtNgayDuyet,
                                                    huy: huy,
                                                    dvct: $('#txtDVCT').val() == undefined ? "" : $('#txtDVCT').val(),
                                                    NhamLan: $('#txtNhamLan').val() == undefined ? "" : $('#txtNhamLan').val(),
                                                    CMNhamLan: $('#txtCMNhamLan').val() == undefined ? "" : $('#txtCMNhamLan').val(),
                                                    MatRach: $('#txtMatRach').val() == undefined ? "" : $('#txtMatRach').val()
                                                };
                                                $.ajax({
                                                    url: '/TrichLucHSBA/CreateOrUpdateDN',
                                                    type: 'POST',
                                                    data: data,
                                                    success: function (response) {
                                                            if (response != null && response.success == false)
                                                                alert(response.message);
                                                            else {
                                                                alert('Thêm mới thành công!');
                                                                $('#ThongTinTrichLucPopUp').modal("hide");
                                                                self.cancelInsert();
                                                                self.loadData();

                                                            }
                                                    },
                                                    error: function (error) {
                                                        console.log(error);
                                                        alert('Thêm mới không thành công!');
                                                    }
                                                });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    //in phieu DN
    self.printDN = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            var cboLoaiDeNghi = $('#cboLoaiDeNghi').val();
            if (cboLoaiDeNghi.length == 0) {
                alert('Chưa chọn loại đơn!');
                $('#cboLoaiDeNghi').focus();
            }
            else {
                var MaBA = $('#txtMaBA').val();
                if (MaBA.length == 0) {
                    alert('Chưa chọn mã bệnh án!');
                    $('#txtMaBA').focus();
                }
                else {
                    var txtHoTenNguoiDeNghi = $('#txtHoTenNguoiDeNghi').val();
                    if (txtHoTenNguoiDeNghi.trim().length == 0) {
                        alert('Chưa nhập họ tên người đề nghị!');
                        $('#txtHoTenNguoiDeNghi').focus();
                    }
                    else {
                        var txtSoCMT = $('#txtSoCMT').val();
                        if (txtSoCMT.trim().length == 0) {
                            alert('Chưa nhập số CMT người đề nghị!');
                            $('#txtSoCMT').focus();
                        }
                        else {
                            var hotenbn = $('#txtHoTenBN').val();
                            if (hotenbn.trim().length == 0) {
                                alert('Chưa nhập họ tên bệnh nhân!');
                                $('#txtHoTenBN').focus();
                            }
                            else {
                                var dtNgaySinh = $('#dtNgaySinh').val();
                                if (dtNgaySinh == '') {
                                    dtNgaySinh = undefined;
                                    alert('Chưa nhập ngày sinh của người đề nghị!');
                                    $('#dtNgaySinh').focus();
                                }
                                else if (dtNgaySinh != undefined) {
                                    dtNgaySinh = Extention.convertToMMDDYYYY(dtNgaySinh);
                                    var tungay = $('#dtTuNgay').val();
                                    if (tungay == '') {
                                        tungay = undefined;
                                        alert('Chưa nhập ngày vào viện của bệnh nhân!');
                                        $('#dtTuNgay').focus();
                                    }
                                    else if (tungay != undefined) {
                                        tungay = Extention.convertToMMDDYYYY(tungay);
                                        var denngay = $('#dtDenNgay').val();
                                        if (denngay == '') {
                                            denngay = undefined;
                                            alert('Chưa nhập ngày ra viện của bệnh nhân!');
                                            $('#dtDenNgay').focus();
                                        }
                                        else if (tungay != undefined) {
                                            denngay = Extention.convertToMMDDYYYY(denngay);
                                            var khoa = $('#cboKhoa').val();
                                            if (khoa.length == 0) {
                                                alert('Chưa chọn khoa nằm viện của bệnh nhân!');
                                                $('#cboKhoa').focus();
                                            }

                                            else {
                                                var sophieu;
                                                if (tempTenCD != undefined) {
                                                    sophieu = tempTenCD;
                                                }
                                                var huy = $('#chkHuy').is(":checked");
                                                var duyet = $('#chkDuyet').is(":checked");
                                                var dtNgayCapCMT = $('#dtNgayCapCMT').val();
                                                if (dtNgayCapCMT != '')
                                                    dtNgayCapCMT = Extention.convertToMMDDYYYY(dtNgayCapCMT);
                                                var dtNgayDuyet = $('#dtNgayDuyet').val();
                                                if (dtNgayDuyet != '')
                                                    dtNgayDuyet = Extention.convertToMMDDYYYY(dtNgayDuyet);
                                                var data = {
                                                    LoaiDeNghi: cboLoaiDeNghi,
                                                    MaBA: MaBA,
                                                    HoTenNguoiDeNghi: txtHoTenNguoiDeNghi,
                                                    NgaySinhNguoiDN: dtNgaySinh,
                                                    SoCMT: txtSoCMT,
                                                    NgayCapCMT: dtNgayCapCMT,
                                                    NoiCapCMT: $('#txtNoiCapCMT').val(),
                                                    QHBN: $('#txtQHBN').val(),
                                                    HoTenBN: hotenbn,
                                                    DiaChi: $('#txtDiaChi').val(),
                                                    TGVQ: $('#txtTGVQ').val(),
                                                    MaKhoaDT: khoa,
                                                    TuNgayDT: tungay,
                                                    DenNgayDT: denngay,
                                                    LyDo: $('#txtLyDo').val(),
                                                    sophieu: sophieu,
                                                    Duyet: duyet,
                                                    ngayduyet: dtNgayDuyet,
                                                    huy: huy,
                                                    dvct: $('#txtDVCT').val(),
                                                    NhamLan: $('#txtNhamLan').val(),
                                                    CMNhamLan: $('#txtCMNhamLan').val(),
                                                    MatRach: $('#txtMatRach').val()
                                                };
                                                window.open('/TrichLucHSBA/CreateOrUpdateDNPrint?LoaiDeNghi=' + cboLoaiDeNghi + '&&MaBA=' + MaBA + '&&HoTenNguoiDeNghi=' + txtHoTenNguoiDeNghi + '&&NgaySinhNguoiDN=' + dtNgaySinh + '&&SoCMT=' + txtSoCMT + '&&NgayCapCMT=' + dtNgayCapCMT + '&&NoiCapCMT=' + $('#txtNoiCapCMT').val() + '&&QHBN=' + $('#txtQHBN').val() + '&&HoTenBN=' + hotenbn + '&&DiaChi=' + $('#txtDiaChi').val() + '&&TGVQ=' + $('#txtTGVQ').val() + '&&MaKhoaDT=' + khoa + '&&TuNgayDT=' + tungay + '&&DenNgayDT=' + denngay + '&&LyDo=' + $('#txtLyDo').val() + '&&sophieu=' + sophieu + '&&Duyet=' + duyet + '&&ngayduyet=' + dtNgayDuyet + '&&huy=' + huy + '&&dvct=' + $('#txtDVCT').val()+'&&NhamLan='+ $('#txtNhamLan').val()+'&&CMNhamLan='+ $('#txtCMNhamLan').val()+'&&MatRach='+ $('#txtMatRach').val());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        $('#ThongTinTrichLucPopUp').modal("hide");
    }
    self.printListDN = function () {
        var DNlist = '';
        $('.chkChon_read').each(function () {
            if (this.checked == true) {
                //var menuid = this.id.replace('chkChon_read', '');
                var DN = this.parentNode.parentNode.id;
                DNlist += DN + ',';
            }
        });
        if (DNlist.length == 0) {
            alert('Chưa chọn số phiếu để in!');
        }
        else {
            //var data = {
            //    sophieulist: DNlist
            //};
            //$.ajax({
            //    url: '/TrichLucHSBA/DNPrint',
            //    type: 'POST',
            //    data: data,
            //    success: function (response) {
            //        if (response != null && response.success == false)
            //            alert(response.message);
            //        else if (response != null && response.success == true) {
            //            window.open('/TrichLucHSBA/GetReport?ReportURL=' + response.message + ', "_blank"');
            //        }
            //    },
            //    error: function (error) {
            //        alert('Xảy ra lỗi:' + error + ' khi in phiếu!');
            //    }
            //});
            window.open('/TrichLucHSBA/DNPrint?sophieulist=' + DNlist.substring(0, DNlist.length-1));
        }
    }
    self.printListHSBA = function () {
        var DNlist = '';
        $('.chkChon_read').each(function () {
            if (this.checked == true) {
                //var menuid = this.id.replace('chkChon_read', '');
                var DN = this.parentNode.parentNode.id;
                DNlist += DN + ',';
            }
        });
        if (DNlist.length == 0) {
            alert('Chưa chọn số phiếu để in!');
        }
        else {
            var data = {
                sophieulist: DNlist
            };
            //$.ajax({
            //    url: '/TrichLucHSBA/PrintHSBA',
            //    type: 'POST',
            //    data: data,
            //    success: function (response) {
            //        if (response != null && response.success == false)
            //            alert(response.message);
            //        else if (response != null && response.success == true) {
            //            window.open('/TrichLucHSBA/GetReport?ReportURL=' + response.message + ', "_blank"');
            //        }
            //    },
            //    error: function (error) {
            //        alert('Xảy ra lỗi:' + error + ' khi in phiếu!');
            //    }
            //});
            window.open('/TrichLucHSBA/PrintHSBA?sophieulist=' + DNlist.substring(0, DNlist.length - 1));
        }
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
                window.open('/TrichLucHSBA/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/TrichLucHSBA/ExportDeNghiTrichLuc',
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
    self.updateDeNghiTrichLuc = function (DeNghiTrichLuc) {
        $.ajax({
            url: '/TrichLucHSBA/Modify',
            type: 'POST',
            data: { chucDanh: DeNghiTrichLuc },
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
        $('#txtiTenCD').val('');

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
        //$(self.columnBNs()).each(function (index, value) {
        //    if (value.property == mang[i]) {
        //        value.visible(true);
        //        i++;
        //    }
        //    else value.visible(false);
        //});
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
        //GeneralCategory.CreateSearchTemplate('theadBN', self.columnBNs());
    }
    self.CreateSearchTemplate();
    //Create read Template
    self.CreateReadTemplate = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.CreateReadTemplate1('boxBody', self.columns(), '');
        }
        else {
            GeneralCategory.CreateReadTemplate1('boxBody', self.columns(), 'disabled');
        }
        //GeneralCategory.CreateReadTemplate('boxBody', self.columnBNs(), '');
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
    //self.CreateInsertTemplate();
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
        GeneralCategory.LoadDMKhoa('cboKhoa', false, '');
    }
    self.LoadDMKhoa();
    //Load danh mục loai De nghi trich luc
    self.LoadDMLoaiDNTL = function () {
        GeneralCategory.LoadDMLoaiDNTL('cboLoaiDeNghi', false, '');
        GeneralCategory.LoadDMLoaiDNTL('cboLoaiDeNghiF', false, '');
    }
    self.LoadDMLoaiDNTL();
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
ko.applyBindings(new DeNghiTrichLucViewModel());
function readcheck(e) {
    //if (e.checked) {
    //    $('#chkCThem').prop('checked', false);
    //    $('#chkCSua').prop('checked', false);
    //    $('#chkCXoa').prop('checked', false);
    //    $('#chkCImport').prop('checked', false);
    //    $('#chkCExport').prop('checked', false);
    //}
}