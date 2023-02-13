/// <reference path="../client/select2Jsonp/jquery-2.0.3.js" />
/// <reference path="Initial.js" />
/// <reference path="../libs/knockoutJs/knockout-3.4.0.js" />
//mảng lưu tên và id của các danh mục phục vụ tìm kiếm tên của các object mà không cần load lại combo
//gọi trực tiếp bằng tên mảng 
var NhomDVarray = [];
var NoiTHarray = [];
var BenhPhamarray = [];
var ChuyenKhoaarray = [];
var ChungLoaiarray = [];
var LoaiHinhArray = [];
var KhoaArray = [];
var LoaiKQArray = [];
var NhanVienArray = [];
var CoQuanArray = [];
//biến lưu class hình mũi tên lên và xuống khi kích vào header của bảng để sort các bản ghi trong bảng
var descending = "fa fa-arrow-down";
var ascending = "fa fa-arrow-up";
deepGet = function (object, path) {
        var paths = path.split('.'),
            current = object;
        for (var i = 0; i < paths.length; ++i) {
            if (current[paths[i]] == undefined) {
                return undefined;
            } else {
                current = current[paths[i]];
            }
        }

        // If the value of current is not a number, return a lowercase string. If it is, return a number.
        return (isNaN(current)) ? current.toLowerCase() : new Number(current);
};
//hàm để reset các giá trị của các ô tìm kiếm trong dòng filter để khi người dùng ẩn filter đi thì các ô này được reset 
clearFilter = function () { 
    $('#SearchTemplate :input').each(function (index,value) {
        $(value).val('');
    });
};
//hàm sinh điều kiện filter
generateDK = function ()
{
    var dk = "";
    $('#SearchTemplate :input').each(function (index, value) {
        if ($(this).val().trim().length > 0) {
            if ($(this).attr('id').startsWith('txtsNgay'))
            {
                dk += "and " + $(this).attr('id').substring(4, $(this).attr('id').length) + " >=convert(datetime, '" + Extention.convertToMMDDYYYY($(this).val().trim()) + "', 102)";
            }
            else {
                dk += "and " + $(this).attr('id').substring(4, $(this).attr('id').length) + " like N'%" + $(this).val() + "%'";
            }
        }
    });
    if (dk.startsWith("and")) {
        dk = dk.substring(4, dk.length);
    }
    return dk;
};
$(document).ready(function () {
    //$('#txtsearch').keyup(function () {
    //        var rex = new RegExp(Extention.bodauTiengViet($(this).val()), 'i');
    //        $('.searchable tr').hide();
    //        $('.searchable tr').filter(function () {
    //            return rex.test(Extention.bodauTiengViet($(this).text()));
    //        }).show();
    //});
    //thay đổi độ rộng của các cột
    $('.datepicker').datepicker({
        language: 'vi', autoclose: true,
        format: "dd/mm/yyyy"
    }).focus(function () {
        $(this).mask('00/00/0000');
        $(this).placeholder = "dd/MM/yyyy";
    });
    $('#SearchTemplate :input').keyup(function (e) {
        //var inputContent = $(this).val().toLowerCase();
        //var index = $('#SearchTemplate').children().index($(this).closest("th"));
        //var rex = new RegExp(Extention.bodauTiengViet($(this).val()), 'i');
        //if (e.keyCode == 8)
        //{
        //    $('.searchable tr').filter(':hidden').filter(function () {
        //        var value = $(this).find('td').eq(index).text().toLowerCase();
        //        return value.indexOf(inputContent) !== -1;
        //    }).show();
        //}
        //else {
        //    //$('.searchable tr').hide();
        //    $('.searchable tr').filter(':visible').filter(function () {
        //        var value = $(this).find('td').eq(index).text().toLowerCase();
        //        return value.indexOf(inputContent) === -1;
        //    }).hide();
        //}
        var inputValue = [];
        for (var i = 0; i < $('#SearchTemplate :input').length; i++) {
            var index = $('#SearchTemplate').children().index($('#SearchTemplate :input').eq(i).closest("th"));
            inputValue.push({
                gt: $('#SearchTemplate :input').eq(i).val().toLowerCase(),
                order: index
            });
        }
        $('.searchable tr').hide();
        $('.searchable tr').filter(function () {
            var kq = false;
            for (var i = 0; i < inputValue.length; i++) {
                if ($(this).find('td').eq(inputValue[i].order).text().toLowerCase().indexOf(inputValue[i].gt) === -1) {
                    if (kq == false) {
                        kq = true;
                    }
                }
            }
            if (kq == false) {
                return $(this);
            }
        }).show();
    });
    $('#SearchTemplate :input').change(function () {
        //var inputContent = $(this).val().toLowerCase();
        //var index = $('#SearchTemplate').children().index($(this).closest("th"));
        //var rex = new RegExp(Extention.bodauTiengViet($(this).val()), 'i');
        //$('.searchable tr').hide();
        //$('.searchable tr').filter(function () {
        //    var value = $(this).find('td').eq(index).text().toLowerCase();
        //    return value.indexOf(inputContent) !== -1;
        //}).show();
        var inputValue = [];
        for (var i = 0; i < $('#SearchTemplate :input').length; i++)
        {
            var index = $('#SearchTemplate').children().index($('#SearchTemplate :input').eq(i).closest("th"));
            inputValue.push({
                gt: $('#SearchTemplate :input').eq(i).val().toLowerCase(),
                order: index
            });
        }
        $('.searchable tr').hide();
        $('.searchable tr').filter(function () {
            var kq = false;
            for (var i = 0; i < inputValue.length; i++)
            {
                if ($(this).find('td').eq(inputValue[i].order).text().toLowerCase().indexOf(inputValue[i].gt) === -1) {
                    if (kq == false) {
                        kq = true;
                    }
                }
            }
            if (kq == false) {
                return $(this);
            }
        }).show();
    });
});
var GeneralCategory = {
    //Load danh mục tỉnh
    //element id: cboTinh, id mặc định của combo: defaultID
    LoadDMTinh: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllTinh',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenTinh,
                            id: value.MaTinh
                        }
                    });
                    dataResults.unshift({ id: 'All', text: 'Tất cả' });
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                        width: '100%',
                        placeholder: 'Chọn tên tỉnh',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tỉnh' + ex)
                }
            });
        })
    },
    //Load danh mục quận huyện
    //element id: cboQuanHuyen, id mặc định của combo: defaultID
    LoadDMQuanHuyen: function (Tinh) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllQH',
                dataType: 'json',
                width: '100%',
                data: { maTinh: Tinh },
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenQH,
                            id: value.MaQH
                        }
                    });
                    dataResults.unshift({ id: 'All', text: 'Tất cả' });
                    $('#cboQuanHuyen').select2({
                        width: '100%',
                        placeholder: 'Chọn tên quận huyện',
                        data: dataResults,
                    });
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tỉnh' + ex)
                }
            });
        })
    },
    //Load danh mục dịch vụ
    //element id: , id mặc định của combo: defaultID
    LoadDMDichVu: function (idCombo, defaultID, nhomDV) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetDichVuByNhom',
                dataType: 'json',
                width: '100%',
                data: { nhomDV: nhomDV },
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenDV,
                            id: value.MaDV
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn tên dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tỉnh' + ex)
                }
            });
        })
    },
    //Load danh mục dịch vụ ngoại trừ một id
    //element id: , id mặc định của combo: defaultID
    LoadDMDichVuExceptID: function (idCombo, defaultID, nhomDV, id) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetDichVuExceptID',
                dataType: 'json',
                width: '100%',
                data: { nhomDV: nhomDV, id: id },
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenDV,
                            id: value.MaDV
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn tên dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tỉnh' + ex)
                }
            });
        })
    },
    //Load danh mục chủng loại
    //element id: cboChungLoai, id mặc định của combo: defaultID
    LoadDMChungLoai: function (defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllChungLoai',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    ChungLoaiarray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenChungLoai,
                            id: value.MaChungLoai
                        }
                    });
                    ChungLoaiarray = dataResults.concat();
                    dataResults.unshift({ id: 'All', text: 'Tất cả' });
                    $('#cboChungLoai').select2({
                        width: '100%',
                        placeholder: 'Chọn tên chủng loại',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chủng loại' + ex)
                }
            });
        })
    },
    //Load danh mục kết quả
    //Element id: cboKetQua, id mặc định của combo: defaultID
    LoadDMKetQua: function (defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllKetQua',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    LoaiKQArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenKQ,
                            id: value.MaKQ
                        }
                    });
                    LoaiKQArray = dataResults.concat();
                    $('.cboKetQua').select2({
                        width: '100%',
                        placeholder: 'Chọn kết quả',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục kết quả' + ex)
                }
            });
        })
    },
    //Load danh mục chuyên môn
    //Element id: cboChuyenMon, id mặc định của combo: defaultID
    LoadDMChuyenMon: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllChuyenMon',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenChuyenMon,
                            id: value.maChuyenMon
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn chuyên môn',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chuyên môn' + ex)
                }
            });
        })
    },
    //Load danh mục chức vụ
    //Element id: cboChucVu, id mặc định của combo: defaultID
    LoadDMChucVu: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllChucVu',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenCV,
                            id: value.maCV
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn chức vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chức vụ' + ex)
                }
            });
        })
    },
    //Load danh mục nhóm dịch vụ
    //Element id: cboNhomDV, id mặc định của combo: defaultID
    LoadDMNhomDV: function (idCombo, defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllNhomDV',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    NhomDVarray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenNhomDV,
                            id: value.MaNhomDV
                        }
                    });
                    dataResults.unshift({ id: 'All', text: 'Tất cả' });
                    NhomDVarray = dataResults.concat();
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn nhóm dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhóm dịch vụ' + ex)
                }
            });
        })
    },
    //Load danh mục bệnh phẩm
    //Element id=cboBenhPham, id mặc định của combo: defaultID
    LoadDMBenhPham: function (defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllBenhPham',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    BenhPhamarray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenBP,
                            id: value.MaBP
                        }
                    });
                    BenhPhamarray = dataResults.concat();
                    $('.cboBenhPham').select2({
                        width: '100%',
                        placeholder: 'Chọn bệnh phẩm',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục bệnh phẩm' + ex)
                }
            });
        })
    },
    //Load danh mục chuyên khoa
    //Element id=cboChuyenKhoa, id mặc định của combo: defaultID
    LoadDMChuyenKhoa: function (defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllChuyenKhoa',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    ChuyenKhoaarray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenCK,
                            id: value.MaCK
                        }
                    });
                    ChuyenKhoaarray = dataResults.concat();
                    $('.cboChuyenKhoa').select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn chuyên khoa',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chuyên khoa' + ex)
                }
            });
        })
    },
    //Load danh mục loại hình
    //Element id=cboLoaiHinh, id mặc định của combo: defaultID
    LoadDMLoaiHinh: function (defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllLoaiHinh',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    LoaiHinhArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenLH,
                            id: value.MaLH
                        }
                    });
                    LoaiHinhArray = dataResults.concat();
                    $('.cboLoaiHinh').select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn loại hình',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục loại hình' + ex)
                }
            });
        })
    },
    //Load danh mục loại hình
    //Element id=cboLoaiHinh, id mặc định của combo: defaultID
    LoadDMLoaiHinhByChungLoai: function (idCombo, defaultID, maChungLoai) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetLoaiHinhByChungLoai',
                dataType: 'json',
                width: '100%',
                data: { maChungLoai: maChungLoai },
                success: function (regions) {
                    LoaiHinhArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenLH,
                            id: value.MaLH
                        }
                    });
                    LoaiHinhArray = dataResults.concat();
                    $('.cboLoaiHinh').select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn loại hình',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục loại hình' + ex)
                }
            });
        })
    },
    //Load danh mục nơi thực hiện
    //Element id=cboNoiThucHien, id mặc định của combo: defaultID
    LoadDMNoiThucHien: function (defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllNoiThucHien',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    NoiTHarray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenNoiTH,
                            id: value.MaNoiTH
                        }
                    });
                    NoiTHarray = dataResults.concat();
                    $('.cboNoiThucHien').select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn nơi thực hiện',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nơi thực hiện' + ex)
                }
            });
        })
    },
    //Load danh mục Khoa
    //Element id=cboKhoa, id mặc định của combo: defaultID
    LoadDMKhoa: function (idCombo, qAdmin, defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllKhoa',
                dataType: 'json',
                width: '100%',
                data: { qAdmin: qAdmin },
                success: function (regions) {
                    KhoaArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenKhoa,
                            id: value.maKhoa
                        }
                    });
                    KhoaArray = dataResults.concat();
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn khoa',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục khoa' + ex)
                }
            });
        })
    },
    //Load danh mục Buong
    //Element id: cboKhoa_Buong, id mặc định của combo: defaultID
    LoadDMKhoa_Buong: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllKhoa_Buong',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenBuong,
                            id: value.maBuong
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn buồng',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục buồng' + ex)
                }
            });
        })
    },
    //Load danh mục buong
    //element id: cboKhoa_Buong, id mặc định của combo: defaultID
    LoadDMKhoa_BuongByKhoa: function (idCombo, defaultID, makhoa) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetKhoa_BuongByKhoa',
                dataType: 'json',
                width: '100%',
                data: { makhoa: makhoa },
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenBuong,
                            id: value.maBuong
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn buồng',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục buồng' + ex)
                }
            });
        })
    },
    //Load danh mục nhóm thuốc
    //Element id: cboThuoc_Nhom, id mặc định của combo: defaultID
    LoadDMThuoc_Nhom: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_Nhom',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenNhom,
                            id: value.maNhom
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn nhóm thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhóm thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục phân loại thuốc
    //Element id: cboThuoc_PhanLoai, id mặc định của combo: defaultID
    LoadDMThuoc_PhanLoai: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_PhanLoai',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenPL,
                            id: value.maPL
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        placeholder: 'Chọn phân loại thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục phân loại thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục chủng loại thuốc
    //Element id: cboThuoc_ChungLoai, id mặc định của combo: defaultID
    LoadDMThuoc_ChungLoai: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_ChungLoai',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenChungLoai,
                            id: value.maChungLoai
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        ChungLoaiaceholder: 'Chọn chủng loại thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chủng loại thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục chủng loại dịch vụ
    //Element id: cboDichVu_ChungLoai, id mặc định của combo: defaultID
    LoadDMDichVu_ChungLoai: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllDichVu_ChungLoai',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenChungLoai,
                            id: value.maChungLoai
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        ChungLoaiaceholder: 'Chọn chủng loại dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chủng loại dịch vụ' + ex)
                }
            });
        })
    },
    //Load danh mục dịch vụ
    //Element id: cboDichVu, id mặc định của combo: defaultID
    LoadDMDichVu: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllDichVu',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenDV,
                            id: value.maDV
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        ChungLoaiaceholder: 'Chọn dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục dịch vụ' + ex)
                }
            });
        })
    },
    //Load danh mục loại hình dịch vụ
    //Element id: cboDichVu_LoaiHinh, id mặc định của combo: defaultID
    LoadDMDichVu_LoaiHinh: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllDichVu_LoaiHinh',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenLH,
                            id: value.maLH
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        LoaiHinhaceholder: 'Chọn loại hình dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục loại hình dịch vụ' + ex)
                }
            });
        })
    },
    //Load danh mục nhóm dịch vụ
    //Element id: cboDichVu_Nhom, id mặc định của combo: defaultID
    LoadDMDichVu_Nhom: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllDichVu_Nhom',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenNhomDV,
                            id: value.maNhomDV
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        Nhomaceholder: 'Chọn nhóm dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhóm dịch vụ' + ex)
                }
            });
        })
    },
    //Load danh mục nhóm vật tư
    //Element id: cboVTYT_Nhom, id mặc định của combo: defaultID
    LoadDMVTYT_Nhom: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllVTYT_Nhom',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenNhom,
                            id: value.maNhom
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        Nhomaceholder: 'Chọn nhóm vật tư',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhóm vật tư' + ex)
                }
            });
        })
    },
    //Load danh mục đơn vị tính vật tư
    //Element id: cboVTYT_Donvitinh, id mặc định của combo: defaultID
    LoadDMVTYT_Donvitinh: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllVTYT_Donvitinh',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenDVT,
                            id: value.maDVT
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        Nhomaceholder: 'Chọn đơn vị tính vật tư',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục đơn vị tính vật tư' + ex)
                }
            });
        })
    },
    //Load danh mục phân loại PTTT dịch vụ
    //Element id: cboDichVu_PhanLoaiPTTT, id mặc định của combo: defaultID
    LoadDMDichVu_PhanLoaiPTTT: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllDichVu_PhanLoaiPTTT',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenPLPTTT,
                            id: value.maPLPTTT
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        PhanLoaiPTTTaceholder: 'Chọn phân loại PTTT dịch vụ',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục phân loại PTTT dịch vụ' + ex)
                }
            });
        })
    },
    //Load danh mục dạng bào chế thuốc
    //Element id: cboThuoc_DangBaoChe, id mặc định của combo: defaultID
    LoadDMThuoc_DangBaoChe: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_DangBaoChe',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenDangBaoChe,
                            id: value.maDangBaoChe
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        DangBaoCheaceholder: 'Chọn dạng bào chế thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục dạng bào chế thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục đơn vị tính thuốc
    //Element id: cboThuoc_Donvitinh, id mặc định của combo: defaultID
    LoadDMThuoc_Donvitinh: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_Donvitinh',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenDVT,
                            id: value.maDVT
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        Donvitinhaceholder: 'Chọn đơn vị tính thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục đơn vị tính thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục đường dùng thuốc
    //Element id: cboThuoc_DuongDung, id mặc định của combo: defaultID
    LoadDMThuoc_DuongDung: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_DuongDung',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenDuongDung,
                            id: value.maDuongDung
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        DuongDungaceholder: 'Chọn đường dùng thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục đường dùng thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục nhà sản xuất thuốc
    //Element id: cboThuoc_NhaSX, id mặc định của combo: defaultID
    LoadDMThuoc_NhaSX: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllThuoc_NhaSX',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenNSX,
                            id: value.maNSX
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        NhaSXaceholder: 'Chọn nhà sản xuất thuốc',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhà sản xuất thuốc' + ex)
                }
            });
        })
    },
    //Load danh mục quốc gia
    //Element id: cboQuocGia, id mặc định của combo: defaultID
    LoadDMQuocGia: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllQuocGia',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenQG,
                            id: value.maQG
                        }
                    });
                    $('#' + idCombo).select2({
                        width: '100%',
                        NhaSXaceholder: 'Chọn quốc gia',
                        data: dataResults,
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục quốc gia' + ex)
                }
            });
        })
    },
    //Load danh muc loai de nghi trich luc
    //Element id=cboLoaiDeNghi, id mặc định của combo: defaultID
    LoadDMLoaiDNTL: function (idCombo, defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllLoaiDNTL',
                dataType: 'json',
                width: '100%',
                success: function (regions) {
                    KhoaArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenLoaiDN,
                            id: value.loaiDN
                        }
                    });
                    KhoaArray = dataResults.concat();
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn loại đơn',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục khoa' + ex)
                }
            });
        })
    },
    //Load danh mục chức danh
    //Element id: cboChucDanh, id mặc định của combo: defaultID
    LoadDMChucDanh: function (idCombo, defaultID, defaultText)
    {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllChucDanh',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenCD,
                            id: value.maCD
                        }
                    });
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                        width: '100%',
                        placeholder: 'Chọn chức danh',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục chức danh' + ex)
                }
            });
        })
    },
    //Load danh mục ten bang ghi log
    //Element id: cbofTenBang, id mặc định của combo: defaultID
    LoadTraceLogTableName: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllTraceLogTableName',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenBang,
                            id: value.maBang
                        }
                    });
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                        width: '100%',
                        placeholder: 'Chọn tên bảng',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tên bảng' + ex)
                }
            });
        })
    },
    //Load danh mục ten bang ghi log
    //Element id: cbofTenBang, id mặc định của combo: defaultID
    LoadTraceLogTableName: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllTraceLogTableName',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenBang,
                            id: value.maBang
                        }
                    });
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                        width: '100%',
                        placeholder: 'Chọn tên bảng',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tên bảng' + ex)
                }
            });
        })
    },
    //Load danh mục Kieu tac dong ghi log
    //Element id: cbofTenBang, id mặc định của combo: defaultID
    LoadTraceLogKieuTacDong: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllTraceLogKieuTacDong',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenKieu,
                            id: value.maKieu
                        }
                    });
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                        width: '100%',
                        placeholder: 'Chọn tên kiểu tác động',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục tên kiểu tác đông' + ex)
                }
            });
        })
    },
    //Load danh mục nhóm quyền
    //Element id: cboRole, id mặc định của combo: defaultID
    LoadDMRole: function (idCombo, defaultID, defaultText) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllRole',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.tenRole,
                            id: value.applicationRolesId
                        }
                    });
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            var data = { id: defaultID, text: defaultText }
                            callback(data);
                        },
                        width: '100%',
                        placeholder: 'Chọn nhóm quyền',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhóm quyền' + ex)
                }
            });
        })
    },
    //Load danh mục nhân viên
    //Element id: cboNhanVien, id mặc định của combo: defaultID
    LoadDMNhanVien: function (idCombo, defaultID, qAdmin) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllNhanVien',
                dataType: 'json',
                width: '100%',
                data: { qAdmin: qAdmin },
                success: function (regions) {
                    NhanVienArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.HoTen,
                            id: value.MaNV
                        }
                    });
                    NhanVienArray = dataResults.concat();
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn nhân viên',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục nhân viên' + ex)
                }
            });
        })
    },
    //Load danh mục cơ quan
    //Element id: cboCoQuan, id mặc định của combo: defaultID
    LoadDMCoQuan: function (idCombo, defaultID) {
        $(document).ready(function () {
            $.ajax({
                type: 'GET',
                url: '/GeneralCategory/GetAllCoQuan',
                dataType: 'json',
                width: '100%',
                data: {},
                success: function (regions) {
                    CoQuanArray = [];
                    var dataResults = $.map(regions, function (value, key) {
                        return {
                            text: value.TenCQ,
                            id: value.MaCQ
                        }
                    });
                    CoQuanArray = dataResults.concat();
                    $('#' + idCombo).select2({
                        initSelection: function (element, callback) {
                            for (var i = 0; i < dataResults.length; i++) {
                                if (dataResults[i].id == element.val()) {
                                    defaultID = element.val();
                                    var defaultText = dataResults[i].text;
                                }
                            }
                            callback({
                                id: defaultID, text: defaultText
                            });
                        },
                        width: '100%',
                        placeholder: 'Chọn cơ quan',
                        data: dataResults,
                    }).select2('val', defaultID);
                },
                error: function (ex) {
                    console.log('Có lỗi xảy ra khi load danh mục cơ quan' + ex)
                }
            });
        })
    },
    //Load combo để hiển thị các cột có trong một bảng
    //Element id: cboColumn
    LoadLoaiChungLoai: function (idCombo, defaultID, defaultText) {
        var data = [
            { id: 'All', text: 'Tất cả' },
            { id: 0, text: '0' },
            { id: 1, text: '1' },
            { id: 2, text: '2' },
            { id: 3, text: '3' },
            { id: 4, text: '4' },
            { id: 5, text: '5' },
            { id: 7, text: '7' },
            { id: 9, text: '9' },
            { id: 18, text: '18' }
        ];
        $("#" + idCombo).select2({
            initSelection: function (element, callback) {
                var data1 = { id: defaultID, text: defaultText }
                callback(data1);
            },
            width: '100%',
            placeholder: 'Chọn loại',
            data: data
        }).select2('val', defaultID);
    },
    //Load combo để hiển thị các cột có trong một bảng
    //Element id: cboColumn
    LoadDMColumn: function (idCombo, column) {
        //var sel = $('<select name="sel-02" id="sel-02" class="select2-multiple2">').appendTo('#' + idCombo);
        //sel.append($("<option></option>"));
        //sel.append($("<option>").attr('id', 'All').text('Tất cả'));
        //sel.append($("</option>"));
        //$(column).each(function () {
        //    sel.append($("<option>").attr('id', this.property).text(this.header));
        //    sel.append($("</option>"));
        //});
        //sel.append($("</select>"));
        //$('.select2-multiple2').select2MultiCheckboxes();
        //var i = 0;
        ////set tất cả các cột trong table được hiển thị
        //$("#" + idCombo).select2("data").find('option').each(function (index, value) {
        //    if (value.id != "")
        //    {
        //        if (value.id != "All") {
        //            if (column[i].visible) {
        //                $(value).addClass('checked');
        //                i++;
        //            }
        //        }
        //    }
        //});
        //$(document).ready(function () {
        //    $('#' + idCombo).on("change", function () {
        //        if ($('#All').hasClass('checked')) {
        //            $("#" + idCombo).select2("data").find('option').each(function (index, value) {
        //                if (value.id != "" && value.id != "All" && ($(value).hasClass('checked') == false)) {
        //                    $(value).addClass('checked');
        //                }
        //            });
        //        }
        //    });
        //});

        //Khởi tạo cboColumn
        var maxhang = 9;
        var socot = Math.floor(column.length / maxhang);
        if (socot < 1) socot = 1;
        if ((socot * maxhang) < column.length) {
            var cotrong = (socot * 2) + 1;
        }
        else {
            var cotrong = socot * 2;
        }
        var sel = '<div class="container">\
        <div class="col-lg-'+(cotrong)+'" style="float: right">\
                <div class="button-group">\
                    <button id="btnColumn" type="button" class="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown">\
                    <span class="glyphicon glyphicon-cog"></span> <span class="caret"></span>\
                    </button>';
        sel += '<ul id="drop" class="dropdown-menu">';
        if (column.length <= maxhang) {
            sel += '<li><a href="#" data-value="All" tabIndex="-1"><input id="All" type="checkbox"/>&nbsp;<b>Tất cả</b></a></li>';
            $(column).each(function () {
                sel += '<li><a href="#" data-value="' + this.property + '" tabIndex="-1"><input id="' + this.property + '" type="checkbox"/>&nbsp;<b>' + this.header + '</b></a></li>';
            });
        }
        else {
            if ((column.length % maxhang) > 0)
            {
                socot++;
            }
            sel += '<div class="row"><div class="col-xs-12">';
            var rongcot = Math.floor(12 / socot);
            for (var k = 0; k < socot; k++)
            {
                var du = maxhang;
                if (k == (socot-1)) {
                    du = column.length % maxhang;
                }
                sel += '<div class="col-sm-' + rongcot + '">\
				            <ul class="multi-column-dropdown">';
                if (k == 0) {
                    du = maxhang - 1;
                    sel += '<li><a href="#" data-value="All" tabIndex="-1"><input id="All" type="checkbox"/>&nbsp;<b>Tất cả</b></a></li>';
                }
                for (var j = 0; j < du; j++)
                {
                    if (k == 0 && j == 0) { j++; }
                    var tt = (k * maxhang) + j - 1;
                    sel += '<li><a href="#" data-value="' + column[tt].property + '" tabIndex="-1"><input id="' + column[tt].property + '" type="checkbox"/>&nbsp;<b>' + column[tt].header + '</b></a></li>';
                    if ((k == 0 && j == (du - 1)) || k == (socot - 1) && j == (du - 1))
                    {
                        tt++;
                        sel += '<li><a href="#" data-value="' + column[tt].property + '" tabIndex="-1"><input id="' + column[tt].property + '" type="checkbox"/>&nbsp;<b>' + column[tt].header + '</b></a></li>';
                    }
                }
                sel += '</ul></div>';
            }
            sel += '</div></div>';
        }
        sel += "</ul>";
        sel += "</div></div></div>";
        $(sel).appendTo('#' + idCombo);
        //Sự kiện xử lý khi kích chuột vào các label trong combo
        $('.dropdown-menu a').on('click', function (event) {
            var $target = $(event.currentTarget),
            val = $target.attr('data-value'),
            $inp = $target.find('input'),
            idx;
            //check tất cả
            if (val == 'All') {
                if ($('#All').is(":checked") == false) {
                    $inp.prop('checked', true);
                    $('#' + idCombo + ' input[type=checkbox]').each(function (index, value) {
                        $(value).prop('checked', true);
                    });
                }
                else {
                    $('#All').prop('checked', false);
                    $('#' + idCombo + ' input[type=checkbox]').each(function (index, value) {
                        $(value).prop('checked', false);
                    });
                }
            }
            else {
                if ($('#All').is(":checked") == true) {
                    $('#All').prop('checked', false);
                }
                $inp.prop('checked', !$inp.is(':checked'));
            }
            $(event.target).blur();
            return false;
        });
        $('#' + idCombo + ' input[type=checkbox]').on('click', function (event) {
            event.stopPropagation();
        });
        //khởi tạo các cột được chọn
        var i = 0;
        $('.dropdown-menu a').each(function (index, value) {
            if (column[i].visible && column[i].property == $(value).attr('data-value')) {
                $(value).click();
                i++;
            }
        });
        $('#drop').width(socot * 130);
        $(document).ready(function () {
            //$('#' + idCombo + ' input[type=checkbox]').keypress(function (event) {
            //    event.preventDefault();
            //    //nhấn phím cách trong checkbox
            //    if (event.keyCode == 32)
            //    {
            //        $(this).parent().click();
            //        return false;
            //    }
            //    return true;
            //});
            //focus vào checkbox khi thẻ a được focus
            $('.dropdown-menu a').focus(function (event) {
                $(this).children("input[type=checkbox]").focus();
            });
            // sự kiện nhấn phím trong thẻ a
            $('.dropdown-menu a').keydown(function (event) {
                event.preventDefault();
                if (event.keyCode == 32) {
                    $(this).click();
                    return false;
                }
                else if (event.keyCode == 38) {
                    //$(':focus').attr('tabindex', $(':focus').attr('tabindex') - 1).focus();
                    $(this).closest('li').prev().find('input[type=checkbox]').focus();
                    return false;
                }
                else if (event.keyCode == 40) {
                    //$(':focus').attr('tabindex', $(':focus').attr('tabindex') + 1).focus();
                    $(this).closest('li').next().find('input[type=checkbox]').focus();
                    return false;
                }
                else if (event.keyCode == 13) {
                    //$(':focus').attr('tabindex', $(':focus').attr('tabindex') + 1).focus();
                    $('#btnColumn').click();
                    return false;
                }
                return true;
            });
        });
    },
    //load combo để chọn nhiều dòng có checkbox
    LoadCheckBoxColumn: function (idCombo, column) {
        $("#" + idCombo).empty();
        var sel = $('<select name="sel-02" id="sel'+idCombo+'" class="select2-multiple2">').appendTo('#' + idCombo);
        sel.append($("<option></option>"));
        //sel.append($("<option>").attr('id', 'All').text('Tất cả'));
        sel.append($("</option>"));

        var elem = $("<option>").attr('id', 'All').text('Tất cả').val('All');
        if (this.chon)
            elem.addClass('checked');
        sel.append(elem);
        sel.append($("</option>"));

        $(column).each(function () {
            var elem = $("<option>").attr('id', this.id).text(this.text).val(this.id);
            if (this.chon)
                elem.addClass('checked');
            sel.append(elem);
            sel.append($("</option>"));
        });
        sel.append($("</select>"));
        $('.select2-multiple2').select2MultiCheckboxes({
            templateSelection: function (selected, total) {
                return "Chọn " + selected.length + " trên " + total;
            }
        });

        //var i = 0;
        //set tất cả các cột trong table được hiển thị
        //$("#" + idCombo).select2("data").find('option').each(function (index, value) {
        //    if (value.id != "")
        //    {
        //        if (value.id != "All") {
        //            if (column[i].visible) {
        //                $(value).addClass('checked');
        //                i++;
        //            }
        //        }
        //    }
        //});
        //$(document).ready(function () {
        //    $('#' + idCombo).on("change", function () {
        //        if ($('#All').hasClass('checked')) {
        //            $("#" + idCombo).select2("data").find('option').each(function (index, value) {
        //                if (value.id != "" && value.id != "All" && ($(value).hasClass('checked') == false)) {
        //                    //console.log(value);
        //                    $(value).addClass('checked');
        //                    //$('option[id="' + value.id + '"]', this.select).addClass('checked');
        //                }
        //            });
        //        }
        //    });
        //});
    },
    //Tạo read-template
    //Element id: idTemp, columns: mảng truyền vào các cột để hiển thị
    CreateReadTemplate: function (idTemp, columns, disable) {
        var sel = '<script type="text/html" id="read-template">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Sửa" class="btn btn-xs btn-info HTCEDIT" data-bind="click: $root.edit"><span class="glyphicon glyphicon-pencil"></span></button>';
                    if (disable.length > 0) {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    else{
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete, enable:!Huy" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    sel += '</td>';
                }
                else if (value.property == "Quyen") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Phân quyền nhân viên" class="btn btn-xs btn-primary HTCEDIT" data-bind="click: $root.editQ"><span class="glyphicon glyphicon-briefcase"></span></button>';
                    sel += '</div></td>';
                }
                else if (value.field == "checkbox") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
                    <input type="checkbox" id="chk' + value.property + '_read" data-bind="checked :' + value.property + ',preventBubble: \'click\'" disabled="disabled" /></td>';
                }
            }
            else {
                sel += '<td data-bind="text : ' + value.property + ', style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </td>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</script>';
        $(sel).appendTo('#' + idTemp);
    },
    CreateReadTemplate1: function (idTemp, columns, disable) {
        var sel = '<script type="text/html" id="read-template">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Sửa" class="btn btn-xs btn-info HTCEDIT" data-bind="click: $root.edit"><span class="glyphicon glyphicon-pencil"></span></button>';
                    if (disable.length > 0) {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    else {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete, enable:!Huy" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    sel += '</td>';
                }
                else if (value.property == "Quyen") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Phân quyền nhân viên" class="btn btn-xs btn-primary HTCEDIT" data-bind="click: $root.editQ"><span class="glyphicon glyphicon-briefcase"></span></button>';
                    sel += '</div></td>';
                }
                else if (value.field == "checkbox") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
                    <input type="checkbox" onclick="readcheck(this);" class="chk' + value.property + '_read" data-bind="checked :' + value.property + ',attr: {id:\'chk' + value.property + '_read\'+$data.MenuId},preventBubble: \'click\'" /></td>';

                }
                else if (value.field == "combo") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<div tabindex="1" id="cbo' + value.property + '"></div></td>';
                }
            }
            else {
                sel += '<td data-bind="text : ' + value.property + ',attr: {id:\'' + value.property +'\'+$data.MenuId}, style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </td>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</script>';
        $(sel).appendTo('#' + idTemp);
        $(columns).each(function (index, value) {
            if (value.field == "combo") {
                $('#cbo' + value.property).prop('tabindex', 1);
                $("#cbo" + value.property).on("select2-blur", function () {
                    $($("#cbo" + value.property).select2("container")).removeClass("has-error");
                });
            }
        });
    },
    CreateReadTemplate3: function (idTemp, columns, disable) {
        var sel = '<script type="text/html" id="read-template">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Sửa" class="btn btn-xs btn-info HTCEDIT" data-bind="click: $root.edit"><span class="glyphicon glyphicon-pencil"></span></button>';
                    if (disable.length > 0) {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    else {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete, enable:!Huy" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    sel += '</td>';
                }
                else if (value.property == "Quyen") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Phân quyền nhân viên" class="btn btn-xs btn-primary HTCEDIT" data-bind="click: $root.editQ"><span class="glyphicon glyphicon-briefcase"></span></button>';
                    sel += '</div></td>';
                }
                else if (value.field == "checkbox") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
                    <input type="checkbox" class="chk' + value.property + '_read" data-bind="checked :' + value.property + ',attr: {id:\'chk' + value.property + '_read\'+$data.MaKhoa},preventBubble: \'click\'" /></td>';

                }
                else if (value.field == "combo") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<div tabindex="1" id="cbo' + value.property + '"></div></td>';
                }
            }
            else {
                sel += '<td data-bind="text : ' + value.property + ',attr: {id:\'' + value.property + '\'+$data.MenuId}, style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </td>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</script>';
        $(sel).appendTo('#' + idTemp);
        $(columns).each(function (index, value) {
            if (value.field == "combo") {
                $('#cbo' + value.property).prop('tabindex', 1);
                $("#cbo" + value.property).on("select2-blur", function () {
                    $($("#cbo" + value.property).select2("container")).removeClass("has-error");
                });
            }
        });
    },
    CreateReadTemplate2: function (idTemp, columns2, disable) {
        var sel = '<script type="text/html" id="read-template2">';
        $(columns2).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns2()[' + index + '].width}, visible:$root.columns2()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Sửa" class="btn btn-xs btn-info HTCEDIT" data-bind="click: $root.edit"><span class="glyphicon glyphicon-pencil"></span></button>';
                    if (disable.length > 0) {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    else {
                        sel += '<button tabindex="1" style="margin:2px" title="Xóa" class="btn btn-xs btn-danger HTCDELETE" data-bind="click: $root.delete, enable:!Huy" ' + disable + '><span class="glyphicon glyphicon-trash"></span></button></div>';
                    }
                    sel += '</td>';
                }
                else if (value.property == "Quyen") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns2()[' + index + '].width}, visible:$root.columns2()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Phân quyền nhân viên" class="btn btn-xs btn-primary HTCEDIT" data-bind="click: $root.edit"><span class="glyphicon glyphicon-briefcase"></span></button>';
                    sel += '</div></td>';
                }
                else if (value.field == "checkbox") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns2()[' + index + '].width},visible:$root.columns2()[' + index + '].visible()">\
                    <input type="checkbox" onclick="readcheck2(this);" class="chk' + value.property + '2_read" data-bind="checked :' + value.property + ',attr: {id:\'chk' + value.property + '2_read\'+$data.MenuId},preventBubble: \'click\'"/></td>';
                }
                else if (value.field == "combo") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns2()[' + index + '].width},visible:$root.columns2()[' + index + '].visible()">\
<div tabindex="1" id="cbo' + value.property + '2"></div></td>';
                }
            }
            else {
                sel += '<td data-bind="text : ' + value.property + ',attr: {id:\'' + value.property+'2\'+$data.MenuId}, style: {width:$root.columns2()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns2()[' + index + '].visible()"> </td>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</script>';
        $(sel).appendTo('#' + idTemp);
        $(columns2).each(function (index, value) {
            if (value.field == "combo") {
                $('#cbo' + value.property).prop('tabindex', 1);
                $("#cbo" + value.property).on("select2-blur", function () {
                    $($("#cbo" + value.property).select2("container")).removeClass("has-error");
                });
            }
        });
    },
    //Tạo read-template 
    //Element id: idTemp, columns: mảng truyền vào các cột để hiển thị, text: text để hiển thị trong placeholder
    CreateInsertTemplate: function (idTemp, columns, disable) {
        var sel = '<tr id="InsertTemplate" style="background-color:ghostwhite">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<th tabindex="1" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" class="btn btn-xs btn-success HTCADD" title="Lưu" data-bind="click: $root.insert"><span class="glyphicon glyphicon-ok"></span></button>\
<button tabindex="1" ' + disable + ' style="margin:2px" class="btn btn-xs btn-default" title="Hủy" data-bind="click: $root.cancelInsert"><span class="glyphicon glyphicon-remove"></span></button></div>\
</th>';
                }
                else if (value.property == "Huy") {
                    sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"></th>';
                }
                else {
                    sel += '<th data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </th>';
                }
            }
            else if (value.field == "input") {
                if (value.type == "string") {
                    sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input type="text" class="form-control" tabindex="1" id="txti' + value.property + '" data-bind="visible:$root.columns()[' + index + '].visible()" placeholder="Nhập mới ' + value.header + '..." /></th>';
                }
                else if (value.type == "number") {
                    sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input type="number" class="form-control" tabindex="1" id="txti' + value.property + '" data-bind="visible:$root.columns()[' + index + '].visible()" onkeypress="return (event.charCode >= 48 && event.charCode <= 57)" min="0" step="1" /></th>';
                }
            }
            else if (value.field == "combo") {
                sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<div id="cboi' + value.property + '"></div></th>';
            }
            else {
                sel += '<th data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </th>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</tr>';
        $(sel).appendTo('#' + idTemp);
        $(columns).each(function (index, value) {
            if (value.field == "combo") {
                $('#cboi' + value.property).prop('tabindex', 1);
                $("#cboi" + value.property).on("select2-blur", function () {
                    $($("#cboi" + value.property).select2("container")).removeClass("has-error");
                });
            }
        });
    },
    //Tạo edit-template
    //Element id: idTemp, columns: mảng truyền vào các cột để hiển thị
    CreateEditTemplate: function (idTemp, columns, disable) {
        var sel = '<script type="text/html" id="edit-template">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
<div class="col-xs-12">\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Lưu" class="btn btn-xs btn-success HTCEDIT" data-bind="click: $root.done"><span class="glyphicon glyphicon-ok"></span></button>\
<button tabindex="1" ' + disable + ' style="margin:2px" title="Thoát" class="btn btn-xs btn-default" data-bind="click: $root.cancel"><span class="glyphicon glyphicon-remove"></span></button></div>\
</td>';
                }
                else if (value.property == "Huy") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<input tabindex="1" type="checkbox" id="chkHuy_edit" data-bind="checked :Huy, event: {\'keydown\': $root.updateEnterHuy},preventBubble: \'click\', enable:Huy,visible:$root.columns()[' + index + '].visible()"/></td>';
                }
                else if (value.property == "KhongSD") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<input tabindex="1" type="checkbox" id="chk' + value.property + '_edit" data-bind="checked :' + value.property + ', event: {\'keydown\': $root.updateEnter' + value.property + '},preventBubble: \'click\', enable:!Huy,visible:$root.columns()[' + index + '].visible()"/></td>';
                }
                else if (value.property == "QAdmin") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<input tabindex="1" type="checkbox" id="chk' + value.property + '_edit" data-bind="checked :' + value.property + ', event: {\'keydown\': $root.updateEnter' + value.property + '},preventBubble: \'click\', enable:!Huy,visible:$root.columns()[' + index + '].visible()"/></td>';
                }
                else {
                    sel += '<td data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </td>';
                }
            }
            else if (value.field == "input") {
                if (value.type == "string") {
                    sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input tabindex="1" type="text" class="form-control"  id="txt' + value.property + '_Edit" data-bind="visible:$root.columns()[' + index + '].visible(), value: ' + value.property + ', event: {keypress: $root.updateEnterInput}, style:{fontWeight: \'bold\'}"/></td>';
                }
                else if (value.type == "number") {
                    sel += '<td style="text-align: center" onkeypress="return (event.charCode >= 48 && event.charCode <= 57)" min="0" step="1" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input tabindex="1" type="number" class="form-control"  id="txt' + value.property + '_Edit" data-bind="visible:$root.columns()[' + index + '].visible(), value: ' + value.property + ', event: {keypress: $root.updateEnterInput}, style:{fontWeight: \'bold\'}"/></td>';
                }
                }
            else if (value.field == "checkbox") {
                sel += '<td style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<input tabindex="1" type="checkbox" id="chk' + value.property + '_edit" data-bind="checked :' + value.property + ', event: {\'keydown\': $root.updateEnter' + value.property + '},preventBubble: \'click\', enable:Huy,visible:$root.columns()[' + index + '].visible()"/></td>';
            }
            else if (value.field == "combo") {
                sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()">\
<div tabindex="1" id="cbo' + value.property + '_Edit"></div></th>';
            }
            else {
                sel += '<td data-bind="text : ' + value.property + ', style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </td>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</script>';
        $(sel).appendTo('#' + idTemp);
    },
    //Tạo search-template 
    //Element id: idTemp, columns: mảng truyền vào các cột để hiển thị
    CreateSearchTemplate: function (idTemp, columns) {
        var sel = '<tr id="SearchTemplate" style="background-color:ghostwhite" data-bind="visible: $root.filter">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<th tabindex="2" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
</th>';
                }
                else if (value.property == "Huy") {
                    sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"></th>';
                }
                else {
                    sel += '<th data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </th>';
                }
            }
            else if (value.search != "")
            {
                if (value.search == "number")
                {
                    sel += '<th title="Nhấn enter để tìm kiếm toàn bộ các bản ghi" style="text-align: center" onkeypress="return (event.charCode >= 48 && event.charCode <= 57)" min="0" step="1" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible(), enable:$root.filter"><input type="number" tabindex="5" class="form-control" id="txts' + value.property + '" data-bind="visible:$root.columns()[' + index + '].visible(), enable:$root.filter"/></th>';
                }
                else if (value.search == "string") {
                    sel += '<th title="Nhấn enter để tìm kiếm toàn bộ các bản ghi" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input tabindex="5" type="text" class="form-control"  id="txts' + value.property + '" data-bind="visible:$root.columns()[' + index + '].visible(), style:{fontWeight: \'bold\'}, enable:$root.filter"/></th>';
                }
                else if (value.search == "date") {
                    sel += '<th title="Nhấn enter để tìm kiếm toàn bộ các bản ghi" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input tabindex="5" type="text" class="datepicker form-control"  id="txts' + value.property + '" data-bind="visible:$root.columns()[' + index + '].visible(), style:{fontWeight: \'bold\'}, enable:$root.filter"/></th>';
                }
            }
            else {
                sel += '<th data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </th>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</tr>';
        $(sel).appendTo('#' + idTemp);
    },
    CreateSearchTemplate2: function (idTemp, columns) {
        var sel = '<tr id="SearchTemplate2" style="background-color:ghostwhite" data-bind="visible: $root.filter">';
        $(columns).each(function (index, value) {
            if (value.type == "") {
                if (value.property == "ThaoTac") {
                    sel += '<th tabindex="2" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width}, visible:$root.columns()[' + index + '].visible()">\
</th>';
                }
                else if (value.property == "Huy") {
                    sel += '<th style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"></th>';
                }
                else {
                    sel += '<th data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </th>';
                }
            }
            else if (value.search != "") {
                if (value.search == "number") {
                    sel += '<th title="Nhấn enter để tìm kiếm toàn bộ các bản ghi" style="text-align: center" onkeypress="return (event.charCode >= 48 && event.charCode <= 57)" min="0" step="1" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible(), enable:$root.filter"><input type="number" tabindex="5" class="form-control" id="txts' + value.property + '2" data-bind="visible:$root.columns()[' + index + '].visible(), enable:$root.filter"/></th>';
                }
                else if (value.search == "string") {
                    sel += '<th title="Nhấn enter để tìm kiếm toàn bộ các bản ghi" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input tabindex="5" type="text" class="form-control"  id="txts' + value.property + '2" data-bind="visible:$root.columns()[' + index + '].visible(), style:{fontWeight: \'bold\'}, enable:$root.filter"/></th>';
                }
                else if (value.search == "date") {
                    sel += '<th title="Nhấn enter để tìm kiếm toàn bộ các bản ghi" style="text-align: center" data-bind="style:{width:$root.columns()[' + index + '].width},visible:$root.columns()[' + index + '].visible()"><input tabindex="5" type="text" class="datepicker form-control"  id="txts' + value.property + '2" data-bind="visible:$root.columns()[' + index + '].visible(), style:{fontWeight: \'bold\'}, enable:$root.filter"/></th>';
                }
            }
            else {
                sel += '<th data-bind="style: {width:$root.columns()[' + index + '].width, fontWeight: \'bold\'},visible:$root.columns()[' + index + '].visible()"> </th>';
            }
        });
        //$("#" + idTemp).append(sel);
        sel += '</tr>';
        $(sel).appendTo('#' + idTemp);
    },
    //Tìm kiếm tên danh mục nhóm dịch vụ
    DMNhomDVLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < NhomDVarray.length; i++) {
            if (NhomDVarray[i].id == id) {
                kq = NhomDVarray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục nơi thực hiện
    DMNoiTHLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < NoiTHarray.length; i++) {
            if (NoiTHarray[i].id == id) {
                kq = NoiTHarray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục bệnh phẩm
    DMBenhPhamLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < BenhPhamarray.length; i++) {
            if (BenhPhamarray[i].id == id) {
                kq = BenhPhamarray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục chuyên khoa
    DMChuyenKhoaLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < ChuyenKhoaarray.length; i++) {
            if (ChuyenKhoaarray[i].id == id) {
                kq = ChuyenKhoaarray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục chủng loại
    DMChungLoaiLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < ChungLoaiarray.length; i++) {
            if (ChungLoaiarray[i].id == id) {
                kq = ChungLoaiarray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục loại hình
    DMLoaiHinhLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < LoaiHinhArray.length; i++) {
            if (LoaiHinhArray[i].id == id) {
                kq = LoaiHinhArray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục khoa
    DMKhoaLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < KhoaArray.length; i++) {
            if (KhoaArray[i].id == id) {
                kq = KhoaArray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục loại kết quả
    DMLoaiKQLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < LoaiKQArray.length; i++) {
            if (LoaiKQArray[i].id == id) {
                kq = LoaiKQArray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục nhân viên
    DMNhanVienLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < NhanVienArray.length; i++) {
            if (NhanVienArray[i].id == id) {
                kq = NhanVienArray[i].text;
            }
        }
        return kq;
    },
    //Tìm kiếm tên danh mục cơ quan
    DMCoQuanLookUp: function (id) {
        var kq = "";
        for (var i = 0; i < CoQuanArray.length; i++) {
            if (CoQuanArray[i].id == id) {
                kq = CoQuanArray[i].text;
            }
        }
        return kq;
    },
}