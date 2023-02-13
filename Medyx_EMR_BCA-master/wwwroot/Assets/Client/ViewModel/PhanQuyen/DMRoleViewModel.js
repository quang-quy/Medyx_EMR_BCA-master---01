/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../libs/knockoutJs/knockout.mapping-latest.js" />
/// <reference path="../../../Extention/GeneralCategory.js" />
/// <reference path="../../../Extention/Extention.js" />
/// <reference path="../../select2jsonp/select2.multi-checkboxes.js" />
/// <reference path="../../admin/libs/jquery/dist/jquery.min.js" />
var DMRoleViewModel = function () {
    //khởi tạo tham số
    //biến trung gian để lưu thông tin của bản ghi được chọn trước khi thay đổi thông tin 
    var temp;
    var tempTenRole;
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
    self.DMRolesC = ko.observableArray();
    self.DMRolesD = ko.observableArray();
    self.Action = ko.observableArray();
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
        { property: "STT", header: "STT", type: "number", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "Chon", header: "Chọn", type: "", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "MenuId", header: "Mã nhóm quyền", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "ApplicationActionId", header: "number", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "MenuName", header: "Tên nhóm quyền(*)", type: "string", state: ko.observable(""), width: '20%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "tenaction", header: "Action", type: "string", state: ko.observable(""), width: '14%', visible: ko.observable(true), field: '', search: 'string' },
    ]);
    self.columns2 = ko.observableArray([
        { property: "STT", header: "STT", type: "number", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: '', search: 'number' },
        { property: "Chon", header: "Chọn", type: "", state: ko.observable(""), width: '3%', visible: ko.observable(true), field: 'checkbox', search: '' },
        { property: "MenuId", header: "Mã nhóm quyền", type: "string", state: ko.observable(""), width: '10%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "ApplicationActionId", header: "", type: "number", state: ko.observable(""), width: '10%', visible: ko.observable(false), field: '', search: 'string' },
        { property: "MenuName", header: "Tên nhóm quyền(*)", type: "string", state: ko.observable(""), width: '20%', visible: ko.observable(true), field: 'input', search: 'string' },
        { property: "tenaction", header: "Action", type: "string", state: ko.observable(""), width: '14%', visible: ko.observable(true), field: '', search: 'string' },
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
    var cot2 = "";
    $(self.columns2()).each(function (index, value) {
        if (value.visible) {
            if (value.property == 'ThaoTac' || value.property == 'STT') { }
            else {
                cot2 += ' ' + value.property + ',';
            }
        }
    });
    cot2 = cot2.substring(0, cot2.length - 1);
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
        self.DMRoles(self.DMRoles().sort(function (a, b) {
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
        self.DMRoles(self.DMRoles().sort(function (a, b) {
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
        self.DMRoles(self.DMRoles().sort(function (a, b) {
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
        self.DMRoles(self.DMRoles().sort(function (a, b) {
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
    self.displayMode = function (DMRole) {
        return DMRole.Edit() ? 'edit-template' : 'read-template';
    }
    //sự kiện nhấn phím khi đang sửa thông tin bản ghi
    self.updateEnterInput = function (DMRole, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 13) {
            DMRole.TenRole = $('#txtTenRole_Edit').val();
            self.done(DMRole);
            return false;
        }
        return true;
    }
    //sự kiện nhấn phím trong checkbox hủy cho phép lấy lại bản ghi bị xóa
    self.updateEnterHuy = function (DMRole, event) {
        var keyCode = (event.which ? event.which : event.keyCode);
        if (keyCode === 32) {
            if ($('#chkHuy_edit').is(":checked")) {
                DMRole.Huy = !DMRole.Huy;
                $('#chkHuy_edit').prop('checked', !$('#chkHuy_edit').is(":checked"));
            }
            return false;
        }
        else if (keyCode === 13) {
            DMRole.TenRole = $('#txtTenRole_Edit').val();
            self.done(DMRole);
            return false;
        }
        return true;
    }
    //sửa thông tin
    self.edit = function (DMRole) {
        //if ($('#txtQuyenXem').val() == 'true') {
        //    if (temp != undefined) {
        //        self.cancel(temp);
        //    }
        //    temp = DMRole;
        //    tempTenRole = DMRole.TenRole;
        //    tempHuy = DMRole.Huy;
        //    self.AddNew(false);
        //    DMRole.Edit(true);
        //    $('#' + self.selectedItem().MenuId).focus();
        //    $('#txtTenRole_Edit').focus();
        //    //$("tbody").css("overflow-y", "hidden");
        //    //$("body").css("overflow-y", "hidden");
        //    //Extention.autoResizeTable();
        //}
        //console.log(DMRole);
        var actionRole = self.Action().filter(st => st.applicationActionId == DMRole.ApplicationActionId);
        self.LoadDMAction('cboCAction', actionRole);
    }
    self.edit2 = function (DMRole) {
        //if ($('#txtQuyenXem').val() == 'true') {
        //    if (temp != undefined) {
        //        self.cancel(temp);
        //    }
        //    temp = DMRole;
        //    tempTenRole = DMRole.TenRole;
        //    tempHuy = DMRole.Huy;
        //    self.AddNew(false);
        //    DMRole.Edit(true);
        //    $('#' + self.selectedItem().MenuId).focus();
        //    $('#txtTenRole_Edit').focus();
        //    //$("tbody").css("overflow-y", "hidden");
        //    //$("body").css("overflow-y", "hidden");
        //    //Extention.autoResizeTable();
        //}
        //console.log(DMRole);
        var actionRole = self.Action().filter(st => st.applicationActionId == DMRole.ApplicationActionId);
        self.LoadDMAction('cboDAction', actionRole);
    }
    //xác nhận thông tin đã thay dổi
    self.done = function (DMRole) {
        if (DMRole.TenRole.trim() == "") {
            DMRole.Edit(false);
            alert('Update không thành công!');
        }
        else {
            self.checkAdd(false);
            DMRole.Edit(false);
            if (!self.AddNew()) {
                self.updateDMRole(DMRole);
            }
            temp = null;
            tempTenRole = "";
            tempHuy = false;
        }
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    //hủy thông tin đã thay đổi
    self.subCancel = function (DMRole) {
        for (var i = 0; i < self.DMRoles().length; i++) {
            if (self.DMRoles()[i].MenuId == DMRole.MenuId) {
                self.DMRoles()[i].TenRole = tempTenRole;
                self.DMRoles()[i].Huy = tempHuy;
            }
        }
        DMRole.Edit(false);
        //$("tbody").css("overflow-y", "auto");
        //Extention.autoResizeTable();
    }
    self.cancel = function (DMRole) {
        self.subCancel(DMRole);
        temp = null;
        tempTenRole = "";
        tempHuy = false;
        var item = self.DMRoles()[0];
        if (self.AddNew()) {
            self.DMRoles.remove(DMRole);
            self.AddNew(false)
        }
    }
    //xóa bản ghi
    self.delete = function (DMRole) {
        if ($('#txtQuyenXem').val() == 'true') {
            if (confirm('Bạn chắc chắn muốn xóa nhóm quyền "' + DMRole.ApplicationRolesId + ' - ' + DMRole.TenRole + '" ?')) {
                DMRole.Huy = true;
                self.deleteRole(DMRole);
            }
        }
    }
    //hàm xác định bản ghi đang được chọn
    self.selectItem = function (DMRole) {
        self.selectedItem(DMRole);
    };
    //searchResults = dmTinhs --- selectResult = selectItem --- selectedResult = selectedItem
    //move row up and down in table
    self.selectPrevious = function () {
        //var index = self.DMRoles().indexOf(self.selectedItem()) - 1;
        var index = 0;
        if (self.selectedItem() != undefined) {
            if (self.selectedItem().STT > 1 && self.selectedItem().STT % self.pageSize() == 0) {
                index = self.pageSize() - 2;
            }
            else
                index = self.DMRoles().indexOf(self.selectedItem()) - 1;
        }
        if (index < 0) index = 0;
        self.selectedItem(self.DMRoles()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MenuId), 31);
        $('#' + self.selectedItem().MenuId).focus();
    };
    self.selectNext = function () {
        //var index = self.DMRoles().indexOf(self.selectedItem()) + 1;
        var index = 0;
        if (self.selectedItem() != undefined) { index = self.DMRoles().indexOf(self.selectedItem()) + 1; }
        if (index >= self.DMRoles().length) index = self.DMRoles().length - 1;
        self.selectedItem(self.DMRoles()[index]);
        Extention.selectHeaderRow($('#' + self.selectedItem().MenuId), 31);
        $('#' + self.selectedItem().MenuId).focus();
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
                $('#' + self.selectedItem().MenuId).focus();
            }
            event.stopPropagation();
            return false;
        }
        else if (e.keyCode == 40) {
            if (self.selectedItem().Edit() == false) {
                self.selectNext();
            }
            else
                $('#' + self.selectedItem().MenuId).focus();
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
            $('#' + self.selectedItem().MenuId).focus();
            return false;
        }
        else if (e.keyCode == 9) {
            if (self.selectedItem() == undefined) {
                self.selectNext();
                $('#' + self.selectedItem().MenuId).focus();
            }
            if (this.MenuId != self.selectedItem().MenuId) {
                var index = self.DMRoles().indexOf(self.selectedItem()) + 1;
                if (index >= self.DMRoles().length) $('#table').focusout();
                else $('#' + self.selectedItem().MenuId).focus();
            }
            return false;
        }
        else return true;
    }
    $(document).ready(function () {
        $('.btnExit').click(function () {
            //var url = '/Home/Index';
            //window.location.href = url;
            window.opener = self;
            window.close();
        })
        $(document).keydown(function (e) {
            //e.preventDefault();
            //nhấn F10
            if (e.keyCode == '121') {
                //var pathname = window.location.pathname.split('/');
                //var url = '/Home/Index';
                //window.location.href = url;
                window.opener = self;
                window.close();
                return false;
            }
        });
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
        //bắt sự kiện nhấn enter ở nút nhập tên nhóm quyền
        $('#txtiTenRole').keypress(function (e) {
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
        //set focus vào ô nhập mới tên nhóm quyền khi trang được load
        if ($('#txtQuyenXem').val() == 'true') {
            $('#txtiTenRole').focus();
        }
        else {
            $('#txtiTenRole').attr('disabled', 'disabled');
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
            //if (code == 13) {// Enter
            //    self.pageIndex(1);
            //    self.LoadLanDau(true);
            //    self.loadData();
            //}
            //lay id cua input filter
            var id = e.currentTarget.id;
            var value = ($('#' + id + '').val() + e.key).toLowerCase();
            $('#tbody tr').filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
        $('#SearchTemplate2 :input').keypress(function (e) {
            var code;
            if (document.all) {
                e = window.event;
                code = e.keyCode;
            }
            if (e.which) {
                code = e.which;
            }
            //nhấn enter để tìm kiếm trong sql
            //if (code == 13) {// Enter
            //    self.pageIndex(1);
            //    self.LoadLanDau(true);
            //    self.loadData();
            //}
            var id = e.currentTarget.id;
            var value = ($('#' + id + '').val() + e.key).toLowerCase();
            //if (value != undefined && value.length > 0) {
            $('#tbody2 tr').filter(function () {
                //var f = ($(this).text().toLowerCase().indexOf(value));
                //console.log(f);
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
        $('#chkCChonAll').on('click', function () {
            if (this.checked) {
                $('.chkChon_read').each(function () {
                    this.checked = true;
                });
            } else {
                $('.chkChon_read').each(function () {
                    this.checked = false;
                });
            }
        });
        $('#chkDChonAll').on('click', function () {
            if (this.checked) {
                $('.chkChon2_read').each(function () {
                    this.checked = true;
                });
            } else {
                $('.chkChon2_read').each(function () {
                    this.checked = false;
                });
            }
        });
        $('#chkDThem').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon2_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon2_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesD().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'thêm');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesD().indexOf(element);
                self.DMRolesD()[index].tenaction = action;
                $('#tenaction2' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkDSua').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon2_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon2_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesD().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'sửa');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesD().indexOf(element);
                self.DMRolesD()[index].tenaction = action;
                $('#tenaction2' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkDXoa').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon2_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon2_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesD().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'xóa');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesD().indexOf(element);
                self.DMRolesD()[index].tenaction = action;
                $('#tenaction2' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkDImport').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon2_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon2_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesD().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'import');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesD().indexOf(element);
                self.DMRolesD()[index].tenaction = action;
                $('#tenaction2' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkDExport').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon2_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon2_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesD().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'export');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesD().indexOf(element);
                self.DMRolesD()[index].tenaction = action;
                $('#tenaction2' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkCThem').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesC().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'thêm');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesC().indexOf(element);
                self.DMRolesC()[index].tenaction = action;
                $('#tenaction' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkCSua').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesC().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'sửa');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesC().indexOf(element);
                self.DMRolesC()[index].tenaction = action;
                $('#tenaction' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkCXoa').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesC().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'xóa');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesC().indexOf(element);
                self.DMRolesC()[index].tenaction = action;
                $('#tenaction' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkCImport').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesC().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'import');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesC().indexOf(element);
                self.DMRolesC()[index].tenaction = action;
                $('#tenaction' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#chkCExport').on('click', function () {
            var checked = this.checked;
            var menuidlist = [];
            $('.chkChon_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesC().filter(item => menuidlist.includes(item.MenuId));
            var selectedMenuAId = selectedMenu.map(a => a.ApplicationActionId);
            var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            var selectedActionThem = selectedAction.filter(item => item.buttonName.toLowerCase() == 'export');
            selectedActionThem.forEach((element) => {
                var i = self.Action().indexOf(element);
                self.Action()[i].chon = checked;
            });
            var selectedAction2 = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
            selectedMenu.forEach((element) => {
                var action = "";
                var selectedAction3 = selectedAction2.filter(item => item.applicationActionId == element.ApplicationActionId && item.chon == true);
                selectedAction3.forEach((e) => {
                    action = action + ',' + e.buttonName;
                });
                var index = self.DMRolesC().indexOf(element);
                self.DMRolesC()[index].tenaction = action;
                $('#tenaction' + element.MenuId).html(action);
            });
            self.Action(self.Action());
        });
        $('#cboDAction').on("change", function () {
            var action = "";
            //var selectedItems = new Array();
            var all = false;
            $("#cboDAction").select2("data").find('option').each(function (index, value) {
                var check = $(value).hasClass('checked');
                var id = value.id;
                if (id == 'All') {
                    all = check;
                }
                else {
                    var text = value.text;
                    if (check||all) {
                        action = action + ',' + text;
                        if (check == false) {
                            check = true;
                            //selectedItems.push(value.value);
                            $("#cboDAction option[id='" + id + "']").addClass('checked');
                        }
                    }
                    var i = self.Action().findIndex(st => st.maAction == id);
                    //var i = self.Action().indexOf(actionRole);
                    //console.log(actionRole);
                    if (i > -1 && self.Action()[i].chon != check)
                        self.Action()[i].chon = check;
                    //ko.mapping.fromJS(self.Action(), actionRole);
                }
            });
            //var index = self.DMRolesD().indexOf(self.selectedItem());
            //self.DMRolesD()[index].tenaction = action;
            $('#tenaction2' + self.selectedItem().MenuId).html(action);
            self.Action(self.Action());
            //$('#cboDAction').select2MultiCheckboxes();
            //if (all) {
            //    $("#cboDAction > option").prop("selected", "selected");
            //} else {
            //    $("#cboDAction > option").removeAttr("selected");
            //}
        });
        $('#cboCAction').on("change", function () {
            var action = "";
            $("#cboCAction").select2("data").find('option').each(function (index, value) {
                var check = $(value).hasClass('checked');
                var id = value.id;
                var text = value.text;
                if (check) {
                    action = action + ',' + text;
                }
                var i = self.Action().findIndex(st => st.maAction == id);
                //var i = self.Action().indexOf(actionRole);
                //console.log(actionRole);
                if (i > -1 && self.Action()[i].chon != check)
                    self.Action()[i].chon = check;
                //ko.mapping.fromJS(self.Action(), actionRole);
            });
            //var index = self.DMRolesD().indexOf(self.selectedItem());
            //self.DMRolesC()[index].tenaction = action;
            $('#tenaction' + self.selectedItem().MenuId).html(action);
            self.Action(self.Action());
        });
        $('#btnMoveD').click(function () {
            var menuidlist = [];
            $('.chkChon_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesC().filter(item => menuidlist.includes(item.MenuId));
            selectedMenu.forEach((element) => {
                var index = self.DMRolesC().indexOf(element);
                element.Chon = false;
                var maxSTT = 0;
                if (self.DMRolesD().length > 0) maxSTT = Math.max.apply(Math, self.DMRolesD().map(function (o) { return o.STT; }));
                element.STT = maxSTT + 1;
                self.DMRolesD().push(element);
                self.DMRolesC().splice(index, 1);
            });
            //load lai table
            self.DMRolesD(self.DMRolesD());
            self.DMRolesC(self.DMRolesC());
        });
        $('#btnMoveC').click(function () {
            var menuidlist = [];
            $('.chkChon2_read').each(function () {
                if (this.checked == true) {
                    var menuid = this.id.replace('chkChon2_read', '');
                    menuidlist.push(menuid);
                }
            });
            var selectedMenu = self.DMRolesD().filter(item => menuidlist.includes(item.MenuId));
            selectedMenu.forEach((element) => {
                var index = self.DMRolesD().indexOf(element);
                element.Chon = false;
                var maxSTT = 0;
                if (self.DMRolesC().length > 0)
                    maxSTT = Math.max.apply(Math, self.DMRolesC().map(function (o) { return o.STT; }));
                element.STT = maxSTT + 1;
                self.DMRolesC().push(element);
                self.DMRolesD().splice(index, 1);
            });
            //load lai table
            self.DMRolesD(self.DMRolesD());
            self.DMRolesC(self.DMRolesC());
        });
    });
    //self.removePlayer = function (Name) {
    //    self.players.remove(function (player) {
    //        return player.name == Name;
    //    });

    //}
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
        var queryString = window.location.search;
        var urlParams = new URLSearchParams(queryString);
        var maRole = urlParams.get('MaRole');
        if (maRole == undefined || maRole == null)
            maRole = "";
        var data1 = {
            //ApplicationRolesId: $('#txtsApplicationRolesId').val(),
            //TenRole: $('#txtsTenRole').val(),
            //maMay: $('#txtsMaMay').val(),
            //ngaySD: ngay,
            //nguoiSD: $('#txtsNguoiSD').val(),
            //index: self.pageIndex,
            //pageSize: self.pageSize,
            //add: add
            MaRole: maRole
        };
        STT = self.pageSize() * (self.pageIndex() - 1);
        $.getJSON('/DMRole/LoadData', data1, function (data) {
            //self.tongSoBanGhi(data.totalCounts);
            //self.tongSoTrang = data.totalPages;
            if (data.applicationRolesId != undefined)
                $('#txtMaRole').val(data.applicationRolesId);
            else $('#txtMaRole').val('');
            if (data.tenRole != undefined)
                $('#txtTenRole').val(data.tenRole);
            else $('#txtTenRole').val('');
            if (data.ngaySD != undefined)
                $('#txtNgaySD').val(Extention.ConvertSQLDateTimeToStringFormat(data.ngaySD));
            else $('#txtNgaySD').val('');
            if (data.nguoiSD != undefined)
                $('#txtNguoiSD').val(data.nguoiSD);
            else $('#txtNguoiSD').val(data.nguoiSD);
            if (data.huy != undefined)
                $("#chkHuy").prop("checked", data.huy);
            else $("#chkHuy").prop("checked", false);
            if (data.actionRole != undefined)
                self.Action = ko.observableArray(data.actionRole);
            //console.log(self.Action());
            self.DMRolesC(ko.utils.arrayMap(data.menuRoleC, function (DMRole) {

                STT += 1;
                var objDMRole = {
                    STT: STT,
                    Chon: DMRole.chon,
                    MenuId: DMRole.menuId,
                    MenuName: DMRole.menuName,
                    tenaction: DMRole.tenaction,
                    ApplicationActionId: DMRole.applicationActionId
                }
                return objDMRole;
                //self.LoadDMAction('cboAction', data.actionRole.filter(st => st.applicationActionId > DMRole.applicationActionId));
                //var ageLess20 = students.filter(st -> st.Age > 22);
                //if (DMRole.Huy == false) {
                //    $('#chkHuy_read').checked(true);
                //}
            }));
            STT = 0;
            self.DMRolesD(ko.utils.arrayMap(data.menuRoleD, function (DMRole) {

                STT += 1;
                var objDMRole = {
                    STT: STT,
                    Chon: false,
                    MenuId: DMRole.menuId,
                    MenuName: DMRole.menuName,
                    tenaction: DMRole.tenaction,
                    ApplicationActionId: DMRole.applicationActionId
                }
                return objDMRole;

                //if (DMRole.Huy == false) {
                //    $('#chkHuy_read').checked(true);
                //}
            }));
            //if (self.DMRolesC().length != 0) {
            //    //if (self.LoadLanDau())
            //    //    self.paging();
            //    if (self.selectedItem() != undefined) {
            //        self.selectedItem().Edit(false);
            //        self.selectItem(self.selectedItem());
            //        $('#' + self.selectedItem().menuId).focus().addClass('danger');
            //    }
            //}
            //else {
            //    alert('Không có dữ liệu để hiển thị!');
            //}
        });
    }
    //save
    self.Save = function () {
        if ($('#txtQuyenXem').val() == 'true') {
            //self.checkAdd(true);
            if ($('#txtTenRole').val().trim() != '') {
                var url = '/DMRole/CreateRole';
                if ($('#txtMaRole').val().trim() != '') {
                    url = '/DMRole/Modify';
                }
                var tenrole = $('#txtTenRole').val().trim();
                var marole = $('#txtMaRole').val().trim();
                if (marole == undefined)
                    marole = '';
                var huy = $('#chkHuy').is(":checked");
                var selectedMenuAId = self.DMRolesC().map(a => a.ApplicationActionId);
                var selectedAction = self.Action().filter(item => selectedMenuAId.includes(item.applicationActionId));
                selectedAction.forEach((element) => {
                    var i = self.Action().indexOf(element);
                    self.Action()[i].chon = false;
                });
                self.Action(self.Action());
                var data1 = {
                    ApplicationRolesId: marole,
                    TenRole: tenrole,
                    Huy: huy,
                    MenuRole: self.DMRolesD(),
                    ActionRole: self.Action()
                };
                $.ajax({
                    url: url,
                    type: 'POST',
                    dataType: "json",
                    type: "POST",
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify(data1),
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
                        if (error.status == 200) {
                            alert('Thêm mới thành công!');
                            self.cancelInsert();
                            self.loadData();
                        }
                        else
                            alert('Lưu thông tin không thành công! Kiểm tra lại thông tin nhóm quyền');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên nhóm quyền');
                //Extention.errorBorder('txtiTenRole');
                //self.cancelInsert();
                $('#txtTenRole').focus();
            }
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
        //Extention.backToHome();
        self.loadData();
        //self.regestEvent();
    }
    self.init();
    //thêm mới bản ghi
    self.insert = function (DMRole) {
        if ($('#txtQuyenXem').val() == 'true') {
            self.checkAdd(true);
            if ($('#txtiTenRole').val().trim() != '') {
                $.ajax({
                    url: '/DMRole/CreateRole',
                    type: 'POST',
                    data: { TenRole: $('#txtiTenRole').val().trim() },
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
                        alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên nhóm quyền');
                    }
                });
            }
            else {
                alert('Thêm mới không thành công! Kiểm tra lại trường nhập tên nhóm quyền');
                Extention.errorBorder('txtiTenRole');
                self.cancelInsert();
                $('#txtiTenRole').focus();
            }
        }
    }
    //xóa bản ghi
    self.deleteRole = function (DMRole) {
        $.ajax({
            url: '/DMRole/DeleteRole',
            type: 'POST',
            data: { ApplicationRolesId: DMRole.ApplicationRolesId },
            success: function (response) {
                if (response != null && response.success == false)
                    alert(response.message);
                else {
                    alert("Xóa nhóm quyền thành công!");
                    self.loadData();
                }
            },
            error: function (error) {
                alert("Xóa nhóm quyền không thành công!");
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
                    url: '/DMRole/ImportDanhMuc',
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
                window.open('/DMRole/ExportExcel?obj=' + JSON.stringify(obj));
                //$.ajax({
                //    url: '/DMRole/ExportDMRole',
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
    self.updateDMRole = function (DMRole) {
        $.ajax({
            url: '/DMRole/Modify',
            type: 'POST',
            data: { Role: DMRole },
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
        $('#txtiTenRole').val('');

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
    //load combo Action
    self.LoadDMAction = function (idCombo, regions) {
        var dataResults = $.map(regions, function (value, key) {
            return {
                text: value.buttonName,
                id: value.maAction,
                chon: value.chon
            }
        });
        GeneralCategory.LoadCheckBoxColumn(idCombo, dataResults);
        
    }
    //Create insert Template
    self.CreateSearchTemplate = function () {
        GeneralCategory.CreateSearchTemplate('thead', self.columns());
        GeneralCategory.CreateSearchTemplate2('thead2', self.columns2());
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
        if ($('#txtQuyenXem').val() == 'true') {
            GeneralCategory.CreateReadTemplate2('boxBody', self.columns2(), '');
        }
        else {
            GeneralCategory.CreateReadTemplate2('boxBody', self.columns2(), 'disabled');
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
ko.applyBindings(new DMRoleViewModel());
function readcheck(e) {
    if (e.checked) {
        $('#chkCThem').prop('checked', false);
        $('#chkCSua').prop('checked', false);
        $('#chkCXoa').prop('checked',false);
        $('#chkCImport').prop('checked',false);
        $('#chkCExport').prop('checked',false);
    }
}
function readcheck2(e) {
    if (e.checked) {
        $('#chkDThem').prop('checked', false);
        $('#chkDSua').prop('checked', false);
        $('#chkDXoa').prop('checked', false);
        $('#chkDImport').prop('checked', false);
        $('#chkDExport').prop('checked', false);
    }
}