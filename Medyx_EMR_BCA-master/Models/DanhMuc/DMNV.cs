using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMNV
    {
        #region State Fields
        private String _maNV = String.Empty;
        private String _maNV1 = String.Empty;
        private string _idnhanvien = String.Empty;
        private string _hoTen = string.Empty;
        private String _maChucVu = String.Empty;
        private String _tenChucVu = String.Empty;
        //private String _maLoaiHD = String.Empty;
        private String _maChuyenMon = String.Empty;
        private string _tenChuyenMon = String.Empty;
        private String _maCD = String.Empty;
        private String _maKhoa = String.Empty;
        private String _TenKhoa = String.Empty;
        private String _maMay = String.Empty;
        private Boolean _huy = false;
        private Boolean _khongsd = false;
        private Boolean _QAdmin = false;
        private DateTime? _ngaySD;
        private String _nguoiSD = String.Empty;
        private String _TenNguoiSD = String.Empty;
       
        
        
        private String _tenCD = String.Empty;
        private String _tentat = String.Empty;
        private String _ghichu = String.Empty;
        
        //private int _OrderNumber;
        //private String _dienThoai = String.Empty;
        //private String _maChungChiHanhNghe = String.Empty;
        //private String _NguoiGiamHo = String.Empty;
        //private String _TenNguoiGiamHo = String.Empty;
        //private String _TenLoaiHD = String.Empty;
        //private String _DienThoaiKhoa = String.Empty;
        //private string _ChuKy = String.Empty;
        public Int32 TotalRows { get; set; }
        private string _Account = String.Empty;
        private string _Password = String.Empty;
        private string _MaRole = String.Empty;
        private string _TenRole = String.Empty;
        private int _MaQL;
        #endregion
        #region Business Properties and Methods
        //public string ChuKy
        //{
        //    get
        //    {
        //        return _ChuKy;
        //    }
        //    set
        //    {
        //        if (_ChuKy != value)
        //        {
        //            _ChuKy = value;
        //        }
        //    }
        //}
        //public String DienThoaiKhoa
        //{
        //    get
        //    {
        //        return _DienThoaiKhoa;
        //    }
        //    set
        //    {
        //        if (_DienThoaiKhoa != value)
        //        {
        //            _DienThoaiKhoa = value;
        //        }
        //    }
        //}
        //public String TenLoaiHD
        //{
        //    get
        //    {
        //        return _TenLoaiHD;
        //    }
        //    set
        //    {
        //        if (_TenLoaiHD != value)
        //        {
        //            _TenLoaiHD = value;
        //        }
        //    }
        //}
        //public String TenNguoiGiamHo
        //{
        //    get
        //    {
        //        return _TenNguoiGiamHo;
        //    }
        //    set
        //    {
        //        if (_TenNguoiGiamHo != value)
        //        {
        //            _TenNguoiGiamHo = value;
        //        }
        //    }
        //}
        //public String NguoiGiamHo
        //{
        //    get
        //    {
        //        return _NguoiGiamHo;
        //    }
        //    set
        //    {
        //        if (_NguoiGiamHo != value)
        //        {
        //            _NguoiGiamHo = value;
        //        }
        //    }
        //}
        //public String DienThoai
        //{
        //    get
        //    {
        //        return _dienThoai;
        //    }
        //    set
        //    {
        //        if (_dienThoai != value)
        //        {
        //            _dienThoai = value;
        //        }
        //    }
        //}
        //public String MaChungChiHanhNghe
        //{
        //    get
        //    {
        //        return _maChungChiHanhNghe;
        //    }
        //    set
        //    {
        //        if (_maChungChiHanhNghe != value)
        //        {
        //            _maChungChiHanhNghe = value;
        //        }
        //    }
        //}
        public String tentat
        {
            get
            {
                return _tentat;
            }
            set
            {
                if (_tentat != value)
                {
                    _tentat = value;
                }
            }
        }
        public String macd
        {
            get
            {
                return _maCD;
            }
            set
            {
                if (_maCD != value)
                {
                    _maCD = value;
                }
            }
        }
        public String idnhanvien
        {
            get
            {
                return _idnhanvien;
            }
            set
            {
                if (_idnhanvien != value)
                {
                    _idnhanvien = value;
                }
            }
        }
        public String MaNV
        {
            get
            {
                return _maNV;
            }
            set
            {
                if (_maNV != value)
                {
                    _maNV = value;
                }
            }
        }
        public String MaNV1
        {
            get
            {
                return _maNV1;
            }
            set
            {
                if (_maNV1 != value)
                {
                    _maNV1 = value;
                }
            }
        }
        public String MaNVHoTen
        {
            get
            {
                return _hoTen + "-" + _maNV;
            }
            set
            {
                if (value != null)
                {
                    string[] words = value.Split('-');
                    if (words.Count() > 0)
                    {
                        _hoTen = words[0];
                        _maNV = words[1];
                    }
                }
                //if (_maNV != value)
                //{
                //    _maNV = value;
                //}
            }
        }
        public String ghichu
        {
            get
            {
                return _ghichu;
            }
            set
            {
                if (_ghichu != value)
                {
                    _ghichu = value;
                }
            }
        }
        public string HoTen
        {
            get
            {
                return _hoTen;
            }
            set
            {
                if (_hoTen != value)
                {
                    _hoTen = value;
                }
            }
        }
        //public String MaLoaiHD
        //{
        //    get
        //    {
        //        return _maLoaiHD;
        //    }
        //    set
        //    {
        //        if (_maLoaiHD != value)
        //        {
        //            _maLoaiHD = value;
        //        }
        //    }
        //}
        public String MaChucVu
        {
            get
            {
                return _maChucVu;
            }
            set
            {
                if (_maChucVu != value)
                {
                    _maChucVu = value;
                }
            }
        }
        public String MaCD
        {
            get
            {
                return _maCD;
            }
            set
            {
                if (_maCD != value)
                {
                    _maCD = value;
                }
            }
        }
        public string MaChuyenMon
        {
            get
            {
                return _maChuyenMon;
            }
            set
            {
                if (_maChuyenMon != value)
                {
                    _maChuyenMon = value;
                }
            }
        }
        public String MaKhoa
        {
            get
            {
                return _maKhoa;
            }
            set
            {
                if (_maKhoa != value)
                {
                    _maKhoa = value;
                }
            }
        }
        public String MaMay
        {
            get
            {
                return _maMay;
            }
            set
            {
                if (_maMay != value)
                {
                    _maMay = value;
                }
            }
        }
        public Boolean Huy
        {
            get
            {
                return _huy;
            }
            set
            {
                if (_huy != value)
                {
                    _huy = value;
                }
            }
        }
        public Boolean KhongSD
        {
            get
            {
                return _khongsd;
            }
            set
            {
                if (_khongsd != value)
                {
                    _khongsd = value;
                }
            }
        }
        public Boolean QAdmin
        {
            get
            {
                return _QAdmin;
            }
            set
            {
                if (_QAdmin != value)
                {
                    _QAdmin = value;
                }
            }
        }
        public DateTime NgaySD
        {
            get
            {
                return (DateTime)_ngaySD;
            }
            set
            {
                if (_ngaySD != value)
                {
                    _ngaySD = value;
                }
            }
        }
        public String NguoiSD
        {
            get
            {
                return _nguoiSD;
            }
            set
            {
                if (_nguoiSD != value)
                {
                    _nguoiSD = value;
                }
            }
        }
        public String TenNguoiSD
        {
            get
            {
                return _TenNguoiSD;
            }
            set
            {
                if (_TenNguoiSD != value)
                {
                    _TenNguoiSD = value;
                }
            }
        }
        public String TenKhoa
        {
            get
            {
                return _TenKhoa;
            }
            set
            {
                if (_TenKhoa != value)
                {
                    _TenKhoa = value;
                }
            }
        }
        public String TenChuyenMon
        {
            get
            {
                return _tenChuyenMon;
            }
            set
            {
                if (_tenChuyenMon != value)
                {
                    _tenChuyenMon = value;
                }
            }
        }
        public String TenCV
        {
            get
            {
                return _tenChucVu;
            }
            set
            {
                if (_tenChucVu != value)
                {
                    _tenChucVu = value;
                }
            }
        }
        public String TenCD
        {
            get
            {
                return _tenCD;
            }
            set
            {
                if (_tenCD != value)
                {
                    _tenCD = value;
                }
            }
        }
        //public int OrderNumber
        //{
        //    get
        //    {
        //        return _OrderNumber;
        //    }
        //    set
        //    {
        //        //CanWriteProperty(true);
        //        if (!_OrderNumber.Equals(value))
        //        {
        //            _OrderNumber = value;
        //            //PropertyHasChanged();
        //        }
        //    }
        //}
        public String Account
        {
            get
            {
                return _Account;
            }
            set
            {
                if (_Account != value)
                {
                    _Account = value;
                }
            }
        }
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                }
            }
        }
        public String MaRole
        {
            get
            {
                return _MaRole;
            }
            set
            {
                if (_MaRole != value)
                {
                    _MaRole = value;
                }
            }
        }
        public String TenRole
        {
            get
            {
                return _TenRole;
            }
            set
            {
                if (_TenRole != value)
                {
                    _TenRole = value;
                }
            }
        }
        public int MaQL
        {
            get
            {
                return _MaQL;
            }
            set
            {
                if (_MaQL != value)
                {
                    _MaQL = value;
                }
            }
        }
        protected String GetIdValue()
        {
            return _maNV;
        }

        #endregion
    }
}
