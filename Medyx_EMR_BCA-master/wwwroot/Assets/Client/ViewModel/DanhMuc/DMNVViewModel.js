/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMNVViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp = null;
    var tempIDNhanVien = "";
    var tempHoTen = "";
    var tempMaChucVu = "";
    var tempMaChuyenMon = "";
    var tempMaKhoa = "";
    var tempHuy = false;
    var tempKhongSD = false;
    var tempQAdmin = false;
    var tempMaQL = "";
    var tempMaCD = "";
    var tempMaRole = "";
    var tempGhiChu = "";
    var tempMaNV1 = "";
    var tempHoTen_Edit = "";
    var tempMaChucVu_Edit = "";
    var tempMaChuyenMon_Edit = "";
    var tempMaCD_Edit = "";
    var tempMaKhoa_Edit = "";
    var tempMaRole_Edit = "";
    var tempAccount = "";
    var tempPassword = "";
    var self = this;
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
    self.DMNVs = ko.observableArray();
    //biến loading để hiển thị div loading khi trang đang load
    self.loading = ko.observable(false);
    //biến lưu trạng thái có thêm mới hay không? Sử dụng để hiển thị bản ghi mới thêm lên dòng đầu tiên của bảng 
    self.AddNew = ko.observable(false);
    //biến lưu bản ghi đang được chọn
    self.selectedItem = ko.observable();
    self.checkAdd = ko.observable(false);
    //biến lưu trạng thái search
    self.filter = ko.observable(false);
    //mảng lưu tên của các column
    //property: tên của cột trong CSDL sử dụng để tạo id và kiểm tra các cột hoặc input khi tạo template
    //header: là text để hiển thị ra ngoài
    //type: phục vụ cho việc sort column khi kích vào header (string: sử dụng hàm self.stringSort() để so sánh giữa hai giá trị khi sort)
    //width: độ rộng của cột tính theo giá trị %
    //visible: biến lưu trạng thái hiển thị hay không của cột, biến này sẽ đượct hay đổi trong khi lựa chọn các cột hiển thị
    //field: sử dụng để xác định kiểu element trong insert template (input: textbox, combo: combobox)
    //search: sử dụng để xác định kiểu element trong search template(number: text chỉ nhận số, string: text, date: datetimepicker)
    self.columns = ko.observableArray([
        { property: "ThaoTac", header: "", type: "", state: ko.observable(""), width: '6%', visible: ko.observable(true), field: '', search: '' },
        { property: "Quyen", header: "Quyền", type: "", state: ko.observable(""), width: '4%', visible: ko.observable(true), field: '', search: '' },
        { property: "STT", header: "STT", type: "number", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "MaNV", header: "Mã NV", type: "string", state: ko.observable(""), width: '5%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "IDNhanVien", header: "ID nhân viên", type: "string", state: ko.observable(""), width: '7%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "HoTen", header: "Họ Tên nhân viên(*)", type: "string", state: ko.observable(""), width: '14%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenCV", header: "Chức vụ(*)", type: "string", state: ko.observable(""), width: '14%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenChuyenMon", header: "Chuyên môn(*)", type: "string", state: ko.observable(""), width: '14%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenKhoa", header: "Khoa(*)", type: "string", state: ko.observable(""), width: '16%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "TenCD", header: "Chức danh(*)", type: "string", state: ko.observable(""), width: '14%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "MaMay", header: "Mã máy", type: "string", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "Huy", header: "Hủy", type: "", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "NguoiSD", header: "Người SD", type: "string", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: '', search: 'string' },
        { property: "NgaySD", header: "Ngày SD", type: "string", state: ko.observable(""), width: '11%', visible: ko.observable(true), field: '', search: 'date' },
        { property: "KhongSD", header: "Không SD", type: "", state: ko.observable(""), width: '4%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "QAdmin", header: "Quyền Admin", type: "", state: ko.observable(""), width: '4%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "MaQL", header: "Mã QL", type: "number", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: 'input', search: 'number' },
        { property: "TenTat", header: "Tên tắt", type: "string", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "GhiChu", header: "Ghi chú", type: "string", state: ko.observable(""), width: '18%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "MaNV1", header: "Mã nhân viên 1", type: "string", state: ko.observable(""), width: '8%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "TenRole", header: "Tên nhóm quyền", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'combo', search: 'string' },
        { property: "Account", header: "Account", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "Password", header: "Password", type: "string", state: ko.observable(""), width: '12%', visible: ko.observable(true), field: 'input', search: 'string' },
        ]);
    //Khởi tạo mảng lưu các cột được export
    var cot = "";
    $(self.columns()).each(function (index, value) {
        if (value.visible) {
            if (value.property == 'ThaoTac' || value.property == 'STT' || value.property == 'Quyen') { }
            else if (value.property == 'TenCV') {
                cot += ' DMChucVu.TenCV,';
            }
            else if (value.property == 'TenChuyenMon') {
                cot += ' DMChuyenMon.TenChuyenMon,';
            }
            else if (value.property == 'TenKhoa') {
                cot += ' DMKhoa.TenKhoa,';
            }
            else if (value.property == 'TenCD') {
                cot += ' DMChucDanh.TenCD,';
            }
            else {
                cot += ' DMNV.' + value.property + ',';
            }
        }
    });
    cot = cot.substring(0, cot.length - 1);
    self.colExport = ko.observable(cot);

    self.sortClick = function (column) {
        try {
            // Call this method to clear the state of any columns OTHER than the target
            // so we can keep track of the ascending/descending
            self.clearColumnStates(column);

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
        self.DMNVs(self.DMNVs().sort(function (a, b) {
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
        self.DMNVs(self.DMNVs().sort(function (a, b) {
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
        self.DMNVs(self.DMNVs().sort(function (a, b) {
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
        self.DMNVs(self.DMNVs().sort(function (a, b) {
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
    self.clearColumnStates = function (selectedColumn) {
        var otherColumns = self.columns().filter(function (col) {
            return col != selectedColumn;
        });
        for (var i = 0; i < otherColumns.length; i++) {
            otherColumns[i].state("");
        }
    };
    //hàm để xác định trạng thái sửa/xem của dòng đang chọn 
    self.displayMode = function (DMNV) {
        return DMNV.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMNV, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMNV.IDNhanVien = $('#txtIDNhanVien_Edit').val();
            DMNV.HoTen = $('#txtHoTen_Edit').val();
            DMNV.MaChucVu = (tempMaChucVu_Edit == "") ? DMNV.MaChucVu : tempMaChucVu_Edit;
            DMNV.MaChuyenMon = (tempMaChuyenMon_Edit == "") ? DMNV.MaChuyenMon : tempMaChuyenMon_Edit;
            DMNV.MaKhoa = (tempMaKhoa_Edit == "") ? DMNV.MaKhoa : tempMaKhoa_Edit;
            DMNV.MaQL = $('#txtMaQL_Edit').val();
            DMNV.MaCD = (tempMaCD_Edit == "") ? DMNV.MaCD : tempMaCD_Edit;
            DMNV.TenTat = $('#txtTenTat_Edit').val();
            DMNV.GhiChu = $('#txtGhiChu_Edit').val();
            DMNV.MaNV1 = $("#txtMaNV1_Edit").val();
            DMNV.MaRole = (tempMaRole_Edit == "") ? DMNV.MaRole : tempMaRole_Edit;
            DMNV.Account = $('#txtAccount_Edit').val();
            DMNV.Password = $('#txtPassword_Edit').val();
            self.done(DMNV);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím cách trong checkbox hủy cho phép lấy lại bản ghi bị xóa và nhấn enter thì lấy lại bản ghi đã xóa 
    self.updateEnterHuy = function (DMNV, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMNV.Huy = !DMNV.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMNV.HoTen = $('#txtHoTen_Edit').val();
            self.done(DMNV);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím cách trong checkbox hủy cho phép lấy lại bản ghi bị xóa và nhấn enter thì lấy lại bản ghi đã xóa 
    self.updateEnterKhongSD = function (DMNV, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            DMNV.KhongSD = !DMNV.KhongSD;
            $('#chkKhongSD_edit').prop('checked', !$('#chkKhongSD_edit').is(":checked"));
            DMNV.QAdmin = !DMNV.QAdmin;
            $('#chkQAdmin_edit').prop('checked', !$('#chkQAdmin_edit').is(":checked"));
            return false;
        }
        else if (keyCode === 13) {
            DMNV.HoTen = $('#txtHoTen_Edit').val();
            self.done(DMNV);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMNV) {
        if ($('#txtQuyenXem').val() == 'true') {
            tempMaChucVu_Edit = "";
            tempMaChuyenMon_Edit = "";
            tempMaCD_Edit = "";
            tempMaRole_Edit = "";
            tempMaKhoa_Edit = "";
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMNV;
            tempIDNhanVien = DMNV.IDNhanVien;
            tempHoTen = DMNV.HoTen;
            tempMaChucVu = DMNV.MaChucVu;
            tempMaChuyenMon = DMNV.MaChuyenMon;
            tempMaKhoa = DMNV.MaKhoa;
            tempHuy = DMNV.Huy;
            tempKhongSD = DMNV.KhongSD;
            tempQAdmin = DMNV.QAdmin;
            tempMaQL = DMNV.MaQL;
            tempMaCD = DMNV.MaCD;
            tempMaRole = DMNV.MaRole;
            tempGhiChu = DMNV.GhiChu;
            tempMaNV1 = DMNV.MaNV1;
            tempAccount = DMNV.Account;
            tempPassword = DMNV.Password;
            self.AddNew(false);
            DMNV.Edit(true);
            GeneralCategory.LoadDMChucVu('cboTenCV_Edit', DMNV.MaChucVu, DMNV.TenCV);
            GeneralCategory.LoadDMChuyenMon('cboTenChuyenMon_Edit', DMNV.MaChuyenMon, DMNV.TenChuyenMon);
            GeneralCategory.LoadDMKhoa('cboTenKhoa_Edit', false, DMNV.MaKhoa);
            GeneralCategory.LoadDMChucDanh('cboTenCD_Edit', DMNV.MaCD, DMNV.TenCD);
            GeneralCategory.LoadDMRole('cboTenRole_Edit', DMNV.MaRole, DMNV.TenRole);
            //$('#' + self.selectedItem().MaNV).focus();
            $('#txtHoTen_Edit').focus();
            $('#cboTenCV_Edit').on("select2-selected", function (e) {
                tempMaChucVu_Edit = $('#cboTenCV_Edit').select2('data').id;
            });
            $('#cboTenChuyenMon_Edit').on("select2-selected", function (e) {
                tempMaChuyenMon_Edit = $('#cboTenChuyenMon_Edit').select2('data').id;
            });
            $('#cboTenKhoa_Edit').on("select2-selected", function (e) {
                tempMaKhoa_Edit = $('#cboTenKhoa_Edit').select2('data').id;
            });
            $('#cboTenCD_Edit').on("select2-selected", function (e) {
                tempMaCD_Edit = $('#cboTenCD_Edit').select2('data').id;
            });
            $('#cboTenRole_Edit').on("select2-selected", function (e) {
                tempMaRole_Edit = $('#cboTenRole_Edit').select2('data').id;
            });
            $('#txtHoTen_Edit').focus();
        }
    }
    //sửa thông tin phân quyền nhân viên theo khoa
    self.editQ = function (DMNV) {
        if ($('#txtQuyenXem').val() == 'true') {
            if (temp != undefined) {
                self.cancel(temp);
            }
            temp = DMNV;
            tempTenRole = DMNV.TenRole;
            tempHuy = DMNV.Huy;
            self.AddNew(false);
            window.open('/DMNVKhoa/Index?MaNV=' + DMNV.MaNV + '&TenNV=' + DMNV.HoTen);
        }
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMNV) {
        if (DMNV.HoTen.toString() == "") {
            DMNV.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMNV.Edit(false);
            if (!self.AddNew()) {
                DMNV.MaChucVu = (tempMaChucVu_Edit == "") ? DMNV.MaChucVu : tempMaChucVu_Edit;
                DMNV.MaChuyenMon = (tempMaChuyenMon_Edit == "") ? DMNV.MaChuyenMon : tempMaChuyenMon_Edit;
                DMNV.MaKhoa = (tempMaKhoa_Edit == "") ? DMNV.MaKhoa : tempMaKhoa_Edit;
                DMNV.MaCD = (tempMaCD_Edit == "") ? DMNV.MaCD : tempMaCD_Edit;
                DMNV.MaRole = (tempMaRole_Edit == "") ? DMNV.MaRole : tempMaRole_Edit;
                self.updateDMNV(DMNV);
            }
            tempMaChucVu_Edit = "";
            tempMaChuyenMon_Edit = "";
            tempMaCD_Edit = "";
            tempMaKhoa_Edit = "";
            tempMaRole_Edit = "";
            temp = null;
            tempIDNhanVien = "";
            tempHoTen = "";
            tempMaChucVu = "";
            tempMaChuyenMon = "";
            tempMaKhoa = "";
            tempHuy = false;
            tempKhongSD = false;
            tempQAdmin = false;
            tempMaQL = "";
            tempMaCD = "";
            tempMaRole = "";
            tempGhiChu = "";
            tempMaNV1 = "";
            tempAccount = "";
            tempPassword = "";
        }
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMNV) {
        for (var i = 0; i < self.DMNVs().length; i++) {
            if (self.DMNVs()[i].MaNV == DMNV.MaNV) {
                self.DMNVs()[i].IDNhanVien = tempIDNhanVien;
                self.DMNVs()[i].HoTen = tempHoTen;
                self.DMNVs()[i].MaChucVu = tempMaChucVu;
                self.DMNVs()[i].MaChuyenMon = tempMaChuyenMon;
                self.DMNVs()[i].MaKhoa = tempMaKhoa;
                self.DMNVs()[i].Huy = tempHuy;
                self.DMNVs()[i].KhongSD = tempKhongSD;
                self.DMNVs()[i].QAdmin = tempQAdmin;
                self.DMNVs()[i].MaQL = tempMaQL;
                self.DMNVs()[i].MaCD = tempMaCD;
                self.DMNVs()[i].GhiChu = tempGhiChu;
                self.DMNVs()[i].MaNV1 = tempMaNV1;
                self.DMNVs()[i].Account = tempAccount;
                self.DMNVs()[i].Password = tempPassword;
                self.DMNVs()[i].MaRole = tempMaRole;
            }
        }
        DMNV.Edit(false);
        var item = self.DMNVs()[0];
    }

    self.cancel = function (DMNV) {
        self.subCancel(DMNV);
        temp = null;
        tempIDNhanVien = "";
        tempHoTen = "";
        tempMaChucVu = "";
        tempMaChuyenMon = "";
        tempMaKhoa = "";
        tempHuy = false;
        tempKhongSD = false;
        tempQAdmin = false;
        tempMaQL = "";
        tempMaCD = "";
        tempGhiChu = "";
        tempMaNV1 = "";
        tempAccount = "";
        tempPassword = "";
        tempMaRole = "";
        var item = self.DMNVs()[0];
        if (self.AddNew()) {
            self.DMNVs.remove(DMNV);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMNV) {
        if (confirm('Bạn chắc chắn muốn xóa nhân viên "' + DMNV.MaNV + ' - ' + DMNV.HoTen + '" ?'))
            DMNV.Huy = true;
        self.deleteNhanVien(DMNV);
    }

    self.selectItem = function (DMNV) {
        self.selectedItem(DMNV);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMNVs().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMNVs().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMNVs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaNV), 31);
        $('#' + self.selectedItem().MaNV).focus();
    };

    self.selectNext = function () {
        //var index = self.DMNVs().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined) { index = self.DMNVs().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMNVs().length) index = self.DMNVs().length - 1;
        self.selectedItem(self.DMNVs()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MaNV), 31);
        $('#' + self.selectedItem().MaNV).focus();
    };
    //sự kiện nhấn phím trong bảng
    self.upAndDown = function (data, e) {
        //e.preventDefault();
        //nhấn up, down arrow
        if (e.keyCode == 38) {
            if (self.selectedItem().Edit() == false) {
                self.selectPrevious();
            }
            else {
                $('#' + self.selectedItem().MaNV).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MaNV).focus();
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
            $('#' + self.selectedItem().MaNV).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MaNV).focus();
            }
            if (this.MaNV != self.selectedItem().MaNV) {
                var index = self.DMNVs().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMNVs().length) $('#table').focusout();
                else $('#' + self.selectedItem().MaNV).focus();
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
        //bắt sự kiện nhấn enter ở nút nhập tên nhân viên
        $('#txtiHoTen').keypress(function (e) {
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
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiHoTen').focus();
        }
        else {
            $('#txtiIDNhanVien').attr('disabled', 'disabled');
            $('#txtiHoTen').attr('disabled', 'disabled');
            $('#txtiMaQL').attr('disabled', 'disabled');
            $('#txtiTenTat').attr('disabled', 'disabled');
            $('#txtiGhiChu').attr('disabled', 'disabled');
            $('#txtiMaNV1').attr('disabled', 'disabled');
            $('#cboiTenCV').select2('enable', false);
            $('#cboiTenChuyenMon').select2("enable", false);
            $('#cboiTenKhoa').select2("enable", false);
            $('#cboiTenCD').select2("enable", false);
        }

    });

    $('#cbofKhoa').on("select2-selected", function (e) {
        self.loadData();
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
        var ngay1 = $('#txtsNgaySD1').val();
        if (ngay1 == '') {
            ngay1 = undefined;
        }
        else if (ngay1 != undefined) {
            ngay1 = Extention.convertToMMDDYYYY(ngay1);
        }
        var khoa = $('#txtsMaKhoa').val();
        if (khoa == undefined && $('#cbofKhoa').select2('data') != undefined)
            khoa = $('#cbofKhoa').select2('data').text;
        var data1 = {
            maNV: $('#txtsMaNV').val() == undefined ? "" : $('#txtsMaNV').val(),
            iDNhanVien: $('#txtsIDNhanVien').val() == undefined ? "" : $('#txtsIDNhanVien').val(),
            hoTen: $('#txtsHoTen').val() == undefined ? "" : $('#txtsHoTen').val(),
            maChucVu: $('#txtsMaChucVu').val() == undefined ? "" : $('#txtsMaChucVu').val(),
            maChuyenMon: $('#txtsMaChuyenMon').val() == undefined ? "" : $('#txtsMaChuyenMon').val(),
            maKhoa: khoa,
            maMay: $('#txtsMaMay').val() == undefined ? "" : $('#txtsMaMay').val(),
            nguoiSD: $('#txtsNguoiSD').val() == undefined ? "" : $('#txtsNguoiSD').val() ,
            ngaySD: ngay,
            maQL: $('#txtsMaQL').val() == undefined ? "" : $('#txtsMaQL').val(),
            maCD: $('#txtsMaCD').val() == undefined ? "" : $('#txtsMaCD').val(),
            tenTat: $('#txtsTenTat').val() == undefined ? "" : $('#txtsTenTat').val(),
            ghiChu: $('#txtsGhiChu').val() == undefined ? "" : $('#txtsGhiChu').val(),
            maNV1: $('#txtsMaNV1').val() == undefined ? "" : $('#txtsMaNV1').val(),
            account: $('#txtsAccount').val() == undefined ? "" : $('#txtsAccount').val(),
            password: $('#txtsPassword').val() == undefined ? "" : $('#txtsPassword').val(),
            tenrole: $('#txtsTenRole').val() == undefined ? "" : $('#txtsTenRole').val(),
            pageDMNV: self.pageIndex,
            pageSize: self.pageSize,
            add: add
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMNV/LoadData', data1, function (data) {
            self.tongSoBanGhi(data.totalCounts);
            self.tongSoTrang = data.totalPages;
            self.DMNVs(ko.utils.arrayMap(data.items, function (DMNV) {
                STT += 1;
                var objDMNV = {
                    STT: STT,
                    Edit: ko.observable(false),
                    MaNV: DMNV.maNV,
                    IDNhanVien: (DMNV.idnhanvien == undefined) ? "" : DMNV.idnhanvien,
                    HoTen: DMNV.hoTen,
                    MaChucVu: (DMNV.maChucVu == undefined) ? "" : DMNV.maChucVu,
                    MaChuyenMon: (DMNV.maChuyenMon == undefined) ? "" : DMNV.maChuyenMon,
                    MaKhoa: (DMNV.maKhoa == undefined) ? "" : DMNV.maKhoa,
                    MaMay: (DMNV.maMay == undefined) ? "" : DMNV.maMay,
                    Huy: DMNV.huy,
                    NguoiSD: (DMNV.nguoiSD == undefined) ? "" : DMNV.nguoiSD,
                    NgaySD: Extention.ConvertJsonDateTimeToStringFormat(DMNV.ngaySD),
                    KhongSD: DMNV.khongSD,
                    QAdmin: DMNV.qAdmin,
                    NguoiSD1: '',
                    NgaySD1: '',
                    MaQL: (DMNV.maQL == undefined) ? "" : DMNV.maQL,
                    MaCD: (DMNV.macd == undefined) ? "" : DMNV.macd,
                    TenTat: (DMNV.tenTat == undefined) ? "" : DMNV.tenTat,
                    GhiChu: (DMNV.ghiChu == undefined) ? "" : DMNV.ghiChu,
                    MaNV1: (DMNV.maNV1 == undefined) ? "" : DMNV.maNV1,
                    TenCV: (DMNV.tenCV == undefined) ? "" : DMNV.tenCV,
                    TenChuyenMon: (DMNV.tenChuyenMon == undefined) ? "" : DMNV.tenChuyenMon,
                    TenKhoa: (DMNV.tenKhoa == undefined) ? "" : DMNV.tenKhoa,
                    TenCD: (DMNV.tenCD == undefined) ? "" : DMNV.tenCD,
                    TenRole: (DMNV.tenRole == undefined) ? "" : DMNV.tenRole,
                    Account: (DMNV.account == undefined) ? "" : DMNV.account,
                    Password: (DMNV.password == undefined) ? "" : DMNV.password,
                    MaRole: (DMNV.maRole == undefined) ? "" : DMNV.maRole,
                }
                return objDMNV;
                if (DMNV.Huy == false) {
                    $('#chkHuy_read').checked(true);
                }
                if (DMNV.KhongSD == false) {
                    $('#chkKhongSD_read').checked(true);
                }
                if (DMNV.QAmin == false) {
                    $('#chkQAdmin_read').checked(true);
                }
            }));
            if (self.DMNVs().length != 0) {
                if (self.LoadLanDau())
                    self.paging();
                if (self.selectedItem() != undefined) {
                    self.selectedItem().Edit(false);
                    self.selectItem(self.selectedItem());
                    $('#' + self.selectedItem().MaNV).focus().addClass('danger');
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
    }
    self.init();
    //thêm mới bản ghi
    self.insert = function (DMNV) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiHoTen').val().trim() != '' && $('#cboiTenCV').select2('data') != undefined && $('#cboiTenChuyenMon').select2('data') != undefined && $('#cboiTenKhoa').select2('data') != undefined && $('#cboiTenCD').select2('data') != undefined) {
                //isNaN('195')
                var maql = $('#txtiMaQL').val();
                if (isNaN(maql) == true)
                    maql = 0;
                var DMNV1 = {
                    HoTen: $('#txtiHoTen').val(),
                    MaChucVu: ($('#cboiTenCV').select2('data') == undefined) ? "" : $('#cboiTenCV').select2('data').id,
                    MaChuyenMon: ($('#cboiTenChuyenMon').select2('data') == undefined) ? "" : $('#cboiTenChuyenMon').select2('data').id,
                    MaKhoa: ($('#cboiTenKhoa').select2('data') == undefined) ? "" : $('#cboiTenKhoa').select2('data').id,
                    MaQL: maql,
                    MaCD: ($('#cboiTenCD').select2('data') == undefined) ? "" : $('#cboiTenCD').select2('data').id,
                    TenTat: $('#txtiTenTat').val(),
                    GhiChu: $('#txtiGhiChu').val(),
                    idnhanvien: $('#txtiIDNhanVien').val(),
                    manv1: $('#txtiMaNV1').val(),
                    maRole: ($('#cboiTenRole').select2('data') == undefined) ? "" : $('#cboiTenRole').select2('data').id,
                    Account: $('#txtiAccount').val(),
                    password: $('#txtiPassword').val(),
                    qadmin: true
                }
                $.ajax({
                    url: '/DMNV/CreateNhanVien',
                    type: 'POST',
                    data:  DMNV1 ,
                    success: function (response) {
                        alert('Thêm mới thành công!');
                        self.cancelInsert();
                        self.loadData();
                    },
                    error: function (error) {
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên nhân viên');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại thông tin nhập mới!');
                if ($('#txtiHoTen').val() == '') {
                    Extention.errorBorder('txtiHoTen');
                    $('#txtiHoTen').focus();
                }
                else if ($('#cboiTenCV').select2('data') == undefined) {
                    $($("#cboiTenCV").select2("container")).addClass("has-error");
                    $('#cboiTenCV').select2('focus');
                }
                else if ($('#cboiTenChuyenMon').select2('data') == undefined) {
                    $($("#cboiTenChuyenMon").select2("container")).addClass("has-error");
                    $('#cboiTenChuyenMon').select2('focus');
                }
                else if ($('#cboiTenKhoa').select2('data') == undefined) {
                    $($("#cboiTenKhoa").select2("container")).addClass("has-error");
                    $('#cboiTenKhoa').select2('focus');
                }
                else if ($('#cboiTenCD').select2('data') == undefined) {
                    $($("#cboiTenCD").select2("container")).addClass("has-error");
                    $('#cboiTenCD').select2('focus');
                }
                //self.cancelInsert();
            }
        }
    }
    //xóa bản ghi
    self.deleteNhanVien = function (DMNV) {
        $.ajax({
            url: '/DMNV/DeleteNhanVien',
            type: 'POST',
            data: { manv: DMNV.MaNV },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    if (response != null && response.success == false)
                        alert(response.message);
                    else {
                        alert("Xóa chức danh thành công!");
                        self.loadData();
                    }
                }
            },
            error: function (error) {
                alert("Xóa chức danh không thành công!");
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
            self.checkAdd(true);
            if ($('#importFile').val().trim() != '') {
                $.ajax({
                    url: '/DMNV/ImportDMNV',
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
                window.open('/DMNV/ExportExcel?obj=' + JSON.stringify(obj));
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
    self.updateDMNV = function (DMNV) {
        $.ajax({
            url: '/DMNV/Modify',
            type: 'POST',
            data: { nhanVien: DMNV },
            success: function (response) {
                self.loadData();
                alert('Update thành công!');
            },
            error: function (error) {
                alert('Update không thành công!');
            }
        });
    }
    //reset ô nhập thông tin thêm mới
    self.cancelInsert = function () {
        $('#txtiIDNhanVien').val('');
        $('#txtiHoTen').val('');
        $('#cboiTenCV').select2("val", null);
        $('#cboiTenChuyenMon').select2("val", null);
        $('#cboiTenKhoa').select2("val", null);
        $('#cboiTenCD').select2("val", null);
        $('#cboiTenRole').select2("val", null);
        $('#txtiMaCD').val('');
        $('#txtiGhiChu').val('');
        $('#txtiMaNV1').val('');
        $('#txtiTenTat').val('');
        $('#txtiAccount').val('');
        $('#txtiPassword').val('');
    }
    //Load danh mục chức vụ
    self.LoadDMChucVu = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMChucVu('cboiTenCV', '');
        }
    }
    //Load danh mục chuyên môn
    self.LoadDMChuyenMon = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMChuyenMon('cboiTenChuyenMon', '');
        }
    }
    //Load danh mục khoa
    self.LoadDMKhoa = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMKhoa('cboiTenKhoa', false, '');
        }
        GeneralCategory.LoadDMKhoa('cbofKhoa', false, '');
    }
    //Load danh mục chức danh
    self.LoadDMChucDanh = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMChucDanh('cboiTenCD', '');
        }
    }
    //Load danh mục nhóm quyền
    self.LoadDMRole = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.LoadDMRole('cboiTenRole', '');
        }
    }
    self.LoadDMRole();
    self.LoadDMChucVu();
    self.LoadDMChuyenMon();
    self.LoadDMKhoa();
    self.LoadDMChucDanh();
    //sự kiện hiển thị các cột trong bảng
    self.CreateVisibleColumn = function () {
        var cotExport = '';
        //event.preventDefault();
        var mang = [];
        $('#cboColumn input:checked').each(function (index, value) {
            if (value.id == "All") { }
            else {
                mang.push(value.id);
                if (value.id == "ThaoTac" || value.id == "STT" || value.id == "Quyen") { }
                else if (value.property == 'TenCV') {
                    cot += ' DMChucVu.TenCV,';
                }
                else if (value.property == 'TenChuyenMon') {
                    cot += ' DMChuyenMon.TenChuyenMon,';
                }
                else if (value.property == 'TenKhoa') {
                    cot += ' DMKhoa.TenKhoa,';
                }
                else if (value.property == 'TenCD') {
                    cot += ' DMChucDanh.TenCD,';
                }
                else {
                    cotExport += ' DMNV.' + value.id + ',';
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
ko.applyBindings(new DMNVViewModel());