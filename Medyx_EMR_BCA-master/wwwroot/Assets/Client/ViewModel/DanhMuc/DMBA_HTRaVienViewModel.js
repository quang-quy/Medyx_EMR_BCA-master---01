/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMBA_HTRaVienViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempTenHTRaVien;
    var tempghichu;
    var tempmabyte;
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
    self.DMBA_HTRaViens = ko.observableArray();
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
    // sưửa lại chỗỗ này 
    self.columns = ko.observableArray([
        { property: "ThaoTac", header: "", type: "", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: '', search: '' },
        { property: "STT", header: "STT", type: "number", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "MaHTRaVien", header: "Mã Hình Thức Ra Viện", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "TenHTRaVien", header: "Tên Hình Thức Ra Viện", type: "string", state: ko.observable(""), width: '27%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "MaMay", header: "Mã máy", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "Huy", header: "Hủy", type: "", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "NguoiSD", header: "Người SD", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "NgaySD", header: "Ngày SĐ", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: '', search: 'date' },
        { property: "Ghichu", header: "Ghi Chú", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "mabyte", header: "Mã Byte", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(true), field: 'input', search: 'string' },
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
        self.DMBA_HTRaVienViewModel(self.DMBA_HTRaVienViewModel().sort(function (a, b) {
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
        self.DMBA_HTRaViens(self.DMBA_HTRaViens().sort(function (a, b) {
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
        self.DMBA_HTRaViens(self.DMBA_HTRaViens().sort(function (a, b) {
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
        self.DMBA_HTRaViens(self.DMBA_HTRaViens().sort(function (a, b) {
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
    self.displayMode = function (DMBA_HTRaVien) {
        return DMBA_HTRaVien.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMBA_HTRaVien, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMBA_HTRaVien.TenHTRaVien = $('#txtTenHTRaVien_Edit').val();
            DMBA_HTRaVien.Ghichu = $('#txtGhichu_Edit').val();
            DMBA_HTRaVien.mabyte = $('#txtmabyte_Edit').val();
            self.done(DMBA_HTRaVien);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DMBA_HTRaVien, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMBA_HTRaVien.Huy = !DMBA_HTRaVien.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMBA_HTRaVien.TenHTRaVien = $('#txtTenHTRaVien_Edit').val();
            DMBA_HTRaVien.Ghichu = $('#txtGhichu_Edit').val();
            DMBA_HTRaVien.mabyte = $('#txtmabyte_Edit').val();
            self.done(DMBA_HTRaVien);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMBA_HTRaVien) {
        if ($('#txtQuyenXem').val() == 'true') {
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMBA_HTRaVien;
            tempTenHTRaVien = DMBA_HTRaVien.TenHTRaVien;
            tempghichu = DMBA_HTRaVien.Ghichu;
            tempmabyte = DMBA_HTRaVien.mabyte;
            tempHuy = DMBA_HTRaVien.Huy;
            self.AddNew(false);
            DMBA_HTRaVien.Edit(true);
            //$('#' + self.selectedItem().MaHTRaVien).focus();
            $('#txtTenHTRaVien_Edit').focus();
            $('#txtGhichu_Edit').focus();
            $('#txtmabyte_Edit').focus();
            //$("tbody").css("overflow-y", "hidden");
            //$("body").css("overflow-y", "hidden");
            //Extention.autoResizeTable();
        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMBA_HTRaVien) {
        if (DMBA_HTRaVien.TenHTRaVien.trim() == "") {
            DMBA_HTRaVien.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMBA_HTRaVien.Edit(false);
            if (!self.AddNew()) {
                self.updateDMBA_HTRaVien(DMBA_HTRaVien);
            }
            temp = null;
            tempTenHTRaVien = "";
            tempghichu = "";
            tempmabyte = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMBA_HTRaVien) {
        for (var i = 0; i < self.DMBA_HTRaViens().length; i++) {
            if (self.DMBA_HTRaViens()[i].MaHTRaVien == DMBA_HTRaVien.MaHTRaVien) {
                self.DMBA_HTRaViens()[i].TenHTRaVien = tempTenHTRaVien;
                self.DMBA_HTRaViens()[i].Ghichu = tempghichu;
                self.DMBA_HTRaViens()[i].mabyte = tempmabyte;
                self.DMBA_HTRaViens()[i].Huy = tempHuy;
            }
        }
        DMBA_HTRaVien.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    self.cancel = function (DMBA_HTRaVien) {
        self.subCancel(DMBA_HTRaVien);
        temp = null;
        tempTenHTRaVien = "";
        tempghichu = "";
        tempmabyte = "";
        tempHuy = false;
        var item = self.DMBA_HTRaViens()[0];
        if (self.AddNew()) {
            self.DMBA_HTRaViens.remove(DMBA_HTRaVien);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMBA_HTRaVien) {
        if ($('#txtQuyenXem').val() == 'true') {
            if (confirm('Bạn chắc chắn muốn xóa hình thức ra viện "' + DMBA_HTRaVien.MaHTRaVien + ' - ' + DMBA_HTRaVien.TenHTRaVien + '" ?')) {
                DMBA_HTRaVien.Huy = true;
                self.deleteChucVu(DMBA_HTRaVien);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DMBA_HTRaVien) {
        self.selectedItem(DMBA_HTRaVien);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMBA_HTRaViens().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMBA_HTRaViens().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMBA_HTRaViens()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaHTRaVien), 31);
        $('#' + self.selectedItem().MaHTRaVien).focus();
    };
    self.selectNext = function () {
        //var index = self.DMBA_HTRaViens().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined) { index = self.DMBA_HTRaViens().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMBA_HTRaViens().length) index = self.DMBA_HTRaViens().length - 1;
        self.selectedItem(self.DMBA_HTRaViens()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaHTRaVien), 31);
        $('#' + self.selectedItem().MaHTRaVien).focus();
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
                $('#' + self.selectedItem().MaHTRaVien).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaHTRaVien).focus();
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
            $('#' + self.selectedItem().MaHTRaVien).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaHTRaVien).focus();
            }
            if (this.MaHTRaVien != self.selectedItem().MaHTRaVien) {
                var index = self.DMBA_HTRaViens().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMBA_HTRaViens().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaHTRaVien).focus();
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
        //bắt sự kiện nhấn enter ở nút nhập tên hình thức ra viện
        $('#txtiTenHTRaVien').keypress(function (e) {
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
        //set focus vào ô nhập mới tên hình thức ra viện khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenHTRaVien').focus();
        }
        else {
            $('#txtiTenHTRaVien').attr('disabled', 'disabled');
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
        var add = 0;
        if (self.checkAdd() == true) {
            add = 1;
        }
        var ngay = $('#txtsNgaySD').val();
        if (ngay == '') {
            ngay = undefined;
        }
        else if (ngay != undefined) {
            ngay = Extention.convertToMMDDYYYY(ngay);
        }
        var data1 = {
            MaHTRaVien: $('#txtsMaHTRaVien').val(),
            TenHTRaVien: $('#txtsTenHTRaVien').val(),
            maMay: $('#txtsMaMay').val(),
            ngaySD: ngay,
            nguoiSD: $('#txtsNguoiSD').val(),
            index: self.pageIndex,
            pageSize: self.pageSize,
            add: add,
            ghichu: $('#txtsGhichu').val(),
            mabyte: $('#txtsmabyte').val()
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMBA_HTRaVien/LoadData', data1, function (data) {
            self.tongSoBanGhi(data.totalCounts);
            self.tongSoTrang = data.totalPages;
            self.DMBA_HTRaViens(ko.utils.arrayMap(data.items, function (DMBA_HTRaVien) {
                STT += 1;
                var objDMBA_HTRaVien = {
                    STT: STT,
                    Edit: ko.observable(false),
                    MaHTRaVien: DMBA_HTRaVien.maHTRaVien,
                    TenHTRaVien: DMBA_HTRaVien.tenHTRaVien,
                    MaMay: (DMBA_HTRaVien.maMay == undefined) ? "" : DMBA_HTRaVien.maMay,
                    Huy: DMBA_HTRaVien.huy,
                    NguoiSD: (DMBA_HTRaVien.nguoiSD == undefined) ? "" : DMBA_HTRaVien.nguoiSD,
                    NgaySD: Extention.ConvertSQLDateTimeToStringFormat(DMBA_HTRaVien.ngaySD),
                    Ghichu: DMBA_HTRaVien.ghiChu,
                    mabyte: DMBA_HTRaVien.mabyte
                }
                return objDMBA_HTRaVien;

                if (DMBA_HTRaVien.Huy == false) {
                    $('#chkHuy_read').checked(true);
                }
            }));
            if (self.DMBA_HTRaViens().length != 0) {
                if (self.LoadLanDau())
                    self.paging();
                if (self.selectedItem() != undefined) {
                    self.selectedItem().Edit(false);
                    self.selectItem(self.selectedItem());
                    $('#' + self.selectedItem().MaHTRaVien).focus().addClass('danger');
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
    self.insert = function (DMBA_HTRaVien) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenHTRaVien').val().trim() != '') {
                $.ajax({
                    url: '/DMBA_HTRaVien/CreateHTRaVien',
                    type: 'POST',
                    data: {
                        TenHTRaVien: $('#txtiTenHTRaVien').val().trim(),
                        ghichu: $('#txtiGhichu').val().trim(),
                        mabyte: $('#txtimabyte').val().trim()
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
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên hình thức ra viện');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên hình thức ra viện');
                Extention.errorBorder('txtiTenHTRaVien');
                self.cancelInsert();
                $('#txtiTenHTRaVien').focus();
            }
        }
    }
    //xóa bản ghi
    self.deleteChucVu = function (DMBA_HTRaVien) {
        $.ajax({
            url: '/DMBA_HTRaVien/DeleteHTRaVien',
            type: 'POST',
            data: { MaHTRaVien: DMBA_HTRaVien.MaHTRaVien },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    alert("Xóa hình thức ra viện thành công!");
                    self.loadData();
                }
            },
            error: function (error) {
                alert("Xóa hình thức ra viện không thành công!");
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
                    url: '/DMBA_HTRaVien/ImportDanhMuc',
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
                window.open('/DMBA_HTRaVien/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/DMBA_HTRaVien/ExportDMBA_HTRaVien',
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
    self.updateDMBA_HTRaVien = function (DMBA_HTRaVien) {
        $.ajax({
            url: '/DMBA_HTRaVien/Modify',
            type: 'POST',
            data: { HTRaVien: DMBA_HTRaVien },
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
        $('#txtiTenHTRaVien').val('');
        $('#txtiGhichu').val('');
        $('#txtimabyte').val('');
    }

    //sự kiện hiển thị các cột trong bảng
    self.CreateVisibleColumn = function () {
        var cotExport = '';
        //event.preventDefault();
        var mang = [];
        $('#cboColumn input:checked').each(function (index, value) {
            if (value.id == "All") { }
            else {
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
ko.applyBindings(new DMBA_HTRaVienViewModel());