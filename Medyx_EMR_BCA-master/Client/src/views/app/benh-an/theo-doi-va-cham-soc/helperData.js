export const MA_CAP_I = '1';
export const MA_CAP_II = '2';
export const MA_CAP_III = '3'
export const form = {
    maBenh: null,
    chanDoan: null,
    sttkhoa: null,
    diUngMota: null,
    diUng: null,
    thuoc: null,
    tienSuGiaDinh: null,
    ngayChamSoc: null,
    ngayChamSocLan: null,
    ngayChamSocBd: null,
    ngayChamSocKt: null,
    mach: null,
    nhietDo: null,
    huyetAp: null,
    canNang: null,
    nhipTho: null,
    chieuCao: null,
    spO2: null,
    dienBien: null,
    ylenh: null,
    ythuc: null,
    theTrang: null,
    phu: null,
    phuVitri: null,
    phuTinhChat: null,
    daNiemMac: null,
    tuanHoan: null,
    tuanHoanTchatDauNguc: null,
    hoHap: null,
    hoHapSloxy: null,
    hoHapTchatDom: null,
    hoHapDanLuu: null,
    tieuHoa: null,
    tieuHoaVitriDauBung: null,
    daiTien: null,
    soLanTieuChay: null,
    mauSacTieuChay: null,
    tietNieu: null,
    tieuTien: null,
    tieuTienMauSac: null,
    tieuTienSoLuong: null,
    tamThanKinh: null,
    tamThanKinhKhac: null,
    tamLyNguoiBenh: null,
    ngu: null,
    nguThoiGian: null,
    vanDong: null,
    vanDongTchatLiet: null,
    coXuongKhop: null,
    vetThuongViTri: null,
    vetThuong: null,
    vetThuongKhac: null,
    vetThuongMotaDanLuu: null,
    vetThuongDanLuu: null,
    vetThuongChanDanLuu: null,
    nhanDinhKhac: null,
    capCs: MA_CAP_I,
    chanDoanChamSoc: null,
    huongDanNoiQuy: null,
    theoDoiDhst: null,
    veSinhThanThe: null,
    thucHienYlenh: null,
    thuThuatTayY: null,
    gioTruyenDichBd: null,
    gioTruyenDichKt: null,
    khiDungTanSo: null,
    testDhmmGio: null,
    testDhmmSoLan: null,
    thuThuatDy: null,
    thuThuatDyVltl: null,
    thuThuatDyThuoc: null,
    thayBang: null,
    thayBangViTriThay: null,
    veSinhCaNhan: null,
    gdsk: null,
    thucHienYlenhKhac: null,
    xuTri: null,
    dieuDuong: null,
    dinhDuong: null,
}

export const dataChecBox = {
    tienSuGiaDinh: [
        {
            checkbox: false,
            ten: 'BT',
            ma: "BT",
        },
        {
            checkbox: false,
            ten: 'Bệnh mãn tính',
            ma: 'Bệnh mãn tính'
        },
        {
            checkbox: false,
            ten: 'Di truyền',
            ma: 'Di truyền'
        },
    ],
    phu: [
        {
            checkbox: false,
            ten: 'Phù',
            ma: 'Phù'
        },
        {
            checkbox: false,
            ten: 'Cổ chướng',
            ma: 'Cổ trướng'
        },
    ],
    CapCS: [
        {
            ten: 'Cấp I',
            ma: '1'
        },
        {
            ten: 'Cấp II',
            ma: '2'
        },
        {
            ten: 'Cấp III',
            ma: '3'
        },
    ],
}
export const dataCheckBoxAsyn = {
    VanDong: [],

    TuanHoanCS: [],
    YThucCSCapI: [
        {
            checkbox: false,
            ten: 'Tỉnh',
        },
        {
            checkbox: false,
            ten: 'Tiếp xúc tốt',
        },
        {
            checkbox: false,
            ten: 'Lơ mơ',
        },
        {
            checkbox: false,
            ten: 'Hôn mê',
        },
        {
            checkbox: false,
            ten: 'Vật vã kích thích',
        },
    ],
    YThucCSCapII: [
        {
            checkbox: false,
            ten: 'Tỉnh',
        },
        {
            checkbox: false,
            ten: 'Tiếp xúc tốt',
        },
    ],
    TheTrangCSCapI: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Gầy',
        },
        {
            checkbox: false,
            ten: 'Béo',
        },
        {
            checkbox: false,
            ten: 'Suy kiệt',
        },
    ],
    TheTrangCSCapII: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Gầy',
        },
        {
            checkbox: false,
            ten: 'Béo',
        },
        {
            checkbox: false,
            ten: 'Trung bình',
        },
        {
            checkbox: false,
            ten: 'Suy kiệt',
        },
    ],

    DaNiemMac: [
        {
            checkbox: false,
            ten: 'Hồng',
        },
        {
            checkbox: false,
            ten: 'Hơi nhợt',
        },
        {
            checkbox: false,
            ten: 'Nhợt',
        },
        {
            checkbox: false,
            ten: 'Xanh',
        },
        {
            checkbox: false,
            ten: 'Tím Tái',
        },
        {
            checkbox: false,
            ten: 'Vàng',
        },
    ],
    HoHapCSCapI: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Tự thở',
        },
        {
            checkbox: false,
            ten: 'Thở máy',
        },
        {
            checkbox: false,
            ten: 'Khó thở',
        },
        {
            checkbox: false,
            ten: 'Ho',
        },
        {
            checkbox: false,
            ten: 'Khan',
        },
        {
            checkbox: false,
            ten: 'Đờm',
        },
    ],
    HoHapCSCapII: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Tự thở',
        },
        {
            checkbox: false,
            ten: 'Khó thở',
        },
        {
            checkbox: false,
            ten: 'Ho',
        },
        {
            checkbox: false,
            ten: 'Khan',
        },
        {
            checkbox: false,
            ten: 'Đờm',
        },
    ],
    TieuHoa: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Kém/chán ăn',
        },
        {
            checkbox: false,
            ten: 'Buồn nôn',
        },
        {
            checkbox: false,
            ten: 'Đau bụng âm ỉ',
        },
        {
            checkbox: false,
            ten: 'Đau bụng dữ dội',
        },
        {
            checkbox: false,
            ten: 'Đau bụng từng cơn',
        },
    ],
    DaiTien: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Không tự chủ',
        },
        {
            checkbox: false,
            ten: 'Táo',
        },
        {
            checkbox: false,
            ten: 'Lỏng',
        },
        {
            checkbox: false,
            ten: 'Nát',
        },
    ],
    TietNieuCSCapI: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Đau',
        },
        {
            checkbox: false,
            ten: 'Đau cơn',
        },
        {
            checkbox: false,
            ten: 'Đau âm ỉ',
        },
        {
            checkbox: false,
            ten: 'Đau dữ dội',
        },
    ],
    TietNieuCSCapII: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Đau',
        },
        {
            checkbox: false,
            ten: 'Đau cơn',
        },
        {
            checkbox: false,
            ten: 'Đau âm ỉ',
        },
        {
            checkbox: false,
            ten: 'Đau dữ dội',
        },
        {
            checkbox: false,
            ten: 'Không tự chủ',
        },
        {
            checkbox: false,
            ten: 'Ít',
        },
        {
            checkbox: false,
            ten: 'Bí',
        },
        {
            checkbox: false,
            ten: 'Vô niệu',
        },
        {
            checkbox: false,
            ten: 'Tiểu buốt dắt',
        },
        {
            checkbox: false,
            ten: 'Tiểu cặn sỏi',
        },
        {
            checkbox: false,
            ten: 'Sonde tiểu',
        },
    ],
    TieuTienCSCapI: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Không tự chủ',
        },
        {
            checkbox: false,
            ten: 'Ít',
        },
        {
            checkbox: false,
            ten: 'Bí',
        },
        {
            checkbox: false,
            ten: 'Vô niệu',
        },
        {
            checkbox: false,
            ten: 'Tiểu buốt dắt',
        },
        {
            checkbox: false,
            ten: 'Tiểu cặn sỏi',
        },
        {
            checkbox: false,
            ten: 'Sonde tiểu',
        },
    ],
    NguCS: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Không ngủ được',
        },
        {
            checkbox: false,
            ten: 'Ngủ ít',
        },
        {
            checkbox: false,
            ten: 'Ngủ kém',
        },
        {
            checkbox: false,
            ten: 'Ngủ nhiều',
        },
    ],
    CoXuongKhopCS: [
        {
            checkbox: false,
            ten: 'BT',
        },
        {
            checkbox: false,
            ten: 'Sưng',
        },
        {
            checkbox: false,
            ten: 'Nóng',
        },
        {
            checkbox: false,
            ten: 'Đỏ',
        },
        {
            checkbox: false,
            ten: 'Đau',
        },
        {
            checkbox: false,
            ten: 'Đỡ đau',
        },
        {
            checkbox: false,
            ten: 'Đau tăng',
        },
    ],
    VetThuong: [
        {
            checkbox: false,
            ten: 'Khô',
        },
        {
            checkbox: false,
            ten: 'Thấm dịch',
        },
        {
            checkbox: false,
            ten: 'Nhiễm trùng',
        },
        {
            checkbox: false,
            ten: 'Nề',
        },
        {
            checkbox: false,
            ten: 'Mủ',
        },
        {
            checkbox: false,
            ten: 'Giả mạc',
        },
    ],
    DanLuu: [
        {
            checkbox: false,
            ten: 'Thông tốt',
        },
        {
            checkbox: false,
            ten: 'Tắc',
        },
        {
            checkbox: false,
            ten: 'Có máu',
        },
        {
            checkbox: false,
            ten: 'Có mủ',
        },
        {
            checkbox: false,
            ten: 'Có dịch',
        },
    ],
    VeSinhThanThe: [
        {
            checkbox: false,
            ten: 'Tắm',
        },
        {
            checkbox: false,
            ten: 'Gội',
        },
        {
            checkbox: false,
            ten: 'Thay bỉm',
        },
    ],
    ThucHienYLenh: [
        {
            checkbox: false,
            ten: 'Thuốc tây y',
        },
        {
            checkbox: false,
            ten: 'Thuốc đông y',
        },
        {
            checkbox: false,
            ten: 'Xét nghiệm',
        },
        {
            checkbox: false,
            ten: 'Chẩn đoán hình ảnh',
        },
    ],
    ThuThuat_TayYCSCapI: [
        {
            checkbox: false,
            ten: 'Tiêm bắt',
        },
        {
            checkbox: false,
            ten: 'Tiêm tĩnh mạch',
        },
        {
            checkbox: false,
            ten: 'Truyền dịch',
        },
        {
            checkbox: false,
            ten: 'Truyền dịch an toán',
        },
        {
            checkbox: false,
            ten: 'Khí dung',
        },
        {
            checkbox: false,
            ten: 'Phụ giúp đặt nội KQ/MKQ',
        },
        {
            checkbox: false,
            ten: 'Hút đờm nhòn qua NKQ/MKQ/hầu họng',
        },
        {
            checkbox: false,
            ten: 'Đặt sonde dạ dày',
        },
        {
            checkbox: false,
            ten: 'Chăm sóc vết loét',
        },
        {
            checkbox: false,
            ten: 'Vỗ rung',
        },
        {
            checkbox: false,
            ten: 'Thay đổi tư thế',
        },
        {
            checkbox: false,
            ten: 'Test đường huyết mao mạch',
        },
    ],
    ThuThuat_TayYCSCapII: [
        {
            checkbox: false,
            ten: 'Tiếp bắp',
        },
        {
            checkbox: false,
            ten: 'Tiêm tĩnh mạch',
        },
        {
            checkbox: false,
            ten: 'Truyền dịch',
        },
        {
            checkbox: false,
            ten: 'Truyền dịch an toàn',
        },
        {
            checkbox: false,
            ten: 'Khí dung',
        },
        {
            checkbox: false,
            ten: 'Chăm sóc vết loét',
        },
        {
            checkbox: false,
            ten: 'Test đường huyết mao mạch',
        },
    ],
    ThuThuat_DYCS: [
        {
            checkbox: false,
            ten: 'Điện châm',
        },
        {
            checkbox: false,
            ten: 'Xoa bóp bấm huyệt',
        },
        {
            checkbox: false,
            ten: 'Hồng ngoại',
        },
        {
            checkbox: false,
            ten: 'Thủy châm',
        },
        {
            checkbox: false,
            ten: 'Đắp parafin',
        },
        {
            checkbox: false,
            ten: 'VLT',
        },
        {
            checkbox: false,
            ten: 'Tập vận động',
        },
        {
            checkbox: false,
            ten: 'Ngâm thuốc YHCT',
        },
    ],
    ThayBangCSCapI: [
        {
            checkbox: false,
            ten: 'Thay băng',
        },
        {
            checkbox: false,
            ten: 'Thay băng thông thường',
        },
        {
            checkbox: false,
            ten: 'Thay băng nhiễm khuẩn',
        },
    ],
    ThayBangCSCapII: [
        {
            checkbox: false,
            ten: 'Thay băng thông thường',
        },
        {
            checkbox: false,
            ten: 'Thay băng nhiễm khuẩn',
        },
    ],
    DinhDuongCS: [
        {
            checkbox: false,
            ten: 'Sữa',
        },
        {
            checkbox: false,
            ten: 'Cháo',
        },
        {
            checkbox: false,
            ten: 'Cơm',
        },
        {
            checkbox: false,
            ten: 'Súp',
        },
        {
            checkbox: false,
            ten: 'Miệng',
        },
        {
            checkbox: false,
            ten: 'Sonde',
        },
        {
            checkbox: false,
            ten: 'TM',
        },
        {
            checkbox: false,
            ten: 'Tự ăn',
        },
        {
            checkbox: false,
            ten: 'nhịn',
        },
        {
            checkbox: false,
            ten: 'Ăn lạnh',
        },
        {
            checkbox: false,
            ten: 'Ăn tốt (>75% suất ăn)',
        },
        {
            checkbox: false,
            ten: 'Kém',
        },
    ],
    GDSK: [
        {
            checkbox: false,
            ten: 'Bệnh',
        },
        {
            checkbox: false,
            ten: 'Thuốc',
        },
        {
            checkbox: false,
            ten: 'Dinh dưỡng',
        },
        {
            checkbox: false,
            ten: 'Sinh hoạt',
        },
        {
            checkbox: false,
            ten: 'Vận động',
        },
        {
            checkbox: false,
            ten: 'PHCN',
        },
        {
            checkbox: false,
            ten: 'Cách chăm sóc da',
        },
    ],
    VeSinhCaNhan: [
        {
            checkbox: false,
            ten: 'Tự làm',
        },
        {
            checkbox: false,
            ten: 'Hỗ trợ',
        },
    ]
}

export const danhMucCheckBox = [
    {
        tenParent: 'VanDong',
        model: 'vanDong',
        maParent: '157'
    },
    {
        tenParent: 'TuanHoanCS',
        model: 'tuanHoan',
        maParent: '177'
    },
    // {
    //     tenParent: 'CapCS',
    //     model: 'capCs',
    //     maParent: '129'
    // },
    {
        tenParent: 'YThucCSCapI',
        model: 'ythuc',
        maParent: '173',
    },
    {
        tenParent: 'YThucCSCapII',
        model: 'ythuc',
        maParent: '174'
    },
    {
        tenParent: 'TheTrangCSCapI',
        model: 'theTrang',
        maParent: '175'
    },
    {
        tenParent: 'TheTrangCSCapII',
        model: 'theTrang',
        maParent: '176'
    },
    {
        tenParent: 'DaNiemMac',
        model: 'daNiemMac',
        maParent: '140'
    },
    {
        tenParent: 'HoHapCSCapI',
        model: 'hoHap',
        maParent: '146'
    },
    {
        tenParent: 'HoHapCSCapII',
        model: 'hoHap',
        maParent: '178'
    },
    {
        tenParent: 'TieuHoa',
        model: 'tieuHoa',
        maParent: '142'
    },
    {
        tenParent: 'DaiTien',
        model: 'daiTien',
        maParent: '144'
    },
    {
        tenParent: 'TietNieuCSCapI',
        model: 'tietNieu',
        maParent: '179'
    },
    {
        tenParent: 'TietNieuCSCapII',
        model: 'tietNieu',
        maParent: '180'
    },
    {
        tenParent: 'TieuTienCSCapI',
        model: 'tieuTien',
        maParent: '181'
    },
    {
        tenParent: 'NguCS',
        model: 'ngu',
        maParent: '152'
    },
    {
        tenParent: 'CoXuongKhopCS',
        model: 'coXuongKhop',
        maParent: '184'
    },
    {
        tenParent: 'VetThuong',
        model: 'vetThuong',
        maParent: '154'
    },
    {
        tenParent: 'DanLuu',
        model: 'vetThuongDanLuu',
        maParent: '155'
    },
    {
        tenParent: 'VeSinhThanThe',
        model: 'veSinhThanThe',
        maParent: '185'
    },
    {
        tenParent: 'ThucHienYLenh',
        model: 'thucHienYlenh',
        maParent: '158'
    },
    {
        tenParent: 'ThuThuat_TayYCSCapI',
        model: 'thuThuatTayY',
        maParent: '186'
    },
    {
        tenParent: 'ThuThuat_TayYCSCapII',
        model: 'thuThuatTayY',
        maParent: '187'
    },
    {
        tenParent: 'ThuThuat_DYCS',
        model: 'thuThuatDy',
        maParent: '188'
    },

    {
        tenParent: 'ThayBangCSCapI',
        model: 'thayBang',
        maParent: '189'
    },
    {
        tenParent: 'ThayBangCSCapII',
        model: 'thayBang',
        maParent: '190'
    },

    {
        tenParent: 'DinhDuongCS',
        model: 'dinhDuong',
        maParent: '153'
    },
    {
        tenParent: 'GDSK',
        model: 'gdsk',
        maParent: '160'
    },
    {
        tenParent: 'VeSinhCaNhan',
        model: 'veSinhCaNhan',
        maParent: '191'
    },
]

