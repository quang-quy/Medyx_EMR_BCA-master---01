import Vue from "vue";
import vuetify from "./plugins/vuetify";
import "./plugins/element";
import "./plugins/fragment";
import "./plugins/portal";
import "./setup/filters";
import "./setup/axios";
import "./setup/helpers";
import "./setup/permission/guard";
import "@/scss/index.scss";
import vueDebounce from "vue-debounce";
import store from "@/store";
Vue.use(vueDebounce, {
  listenTo: ["input", "keyup"],
  defaultTime: "500ms",
});
Vue.config.productionTip = false;
Vue.component("AppWrapper", () => import("@/components/AppWrapper.vue"));
Vue.component("ElDatePicker", () => import("@/components/DatePicker.vue"));

Vue.component("BaseSelectAsync", () =>
  import("@/components/fields/Async/ElBoxSelectDropDown.vue")
);
Vue.component("EditerFill", () =>
  import("@/components/fields/field-quill.vue")
);

Object.byString = function (o, s) {
  s = s.replace(/\[(\w+)\]/g, ".$1"); // convert indexes to properties
  s = s.replace(/^\./, ""); // strip a leading dot
  var a = s.split(".");
  for (var i = 0, n = a.length; i < n; ++i) {
    var k = a[i];
    if (k in o) {
      o = o[k];
    } else {
      return;
    }
  }
  return o;
};

new Vue({
  vuetify,
  store,
  components: {
    ThongTinBenhAn: () =>
      import("@/views/app/benh-an/thong-tin-benh-an/Index.vue"),
    DanhSachBenhAn: () => import("@/views/app/benh-an/danh-sach/Index.vue"),
    LuuTruBenhAn: () => import("@/views/app/benh-an/luu-tru/Index.vue"),
    ChiTietLuuTruBenhAn: () => import("@/views/app/benh-an/luu-tru/Detail.vue"),
    PhucHoiBenhAn: () => import("@/views/app/benh-an/phuc-hoi/Index.vue"),
    ChiTietPhucHoiBenhAn: () =>
      import("@/views/app/benh-an/phuc-hoi/Detail.vue"),
    HoSoBenhAn: () => import("@/views/app/benh-an/ho-so-benh-an/Index.vue"),
    PhieuKhamBenhVaoVien: () =>
      import("@/views/app/benh-an/phieu-kham-benh-vao-vien/Index.vue"),
    KhoaDieuTri: () => import("@/views/app/benh-an/khoa-dieu-tri/Index.vue"),
    ThongTinToBenhAn: () =>
      import("@/views/app/benh-an/thong-tin-to-benh-an/Index.vue"),
    ToDieuTri: () => import("@/views/app/benh-an/to-dieu-tri/Index.vue"),
    PhieuThuPhanUngThuoc: () =>
      import("@/views/app/benh-an/phieu-thu-phan-ung-thuoc/Index.vue"),
    PhieuKhamChuyenKhoa: () =>
      import("@/views/app/benh-an/phieu-kham-chuyen-khoa/Index.vue"),
    ThongTinPhieuXetNghiem: () =>
      import("@/views/app/benh-an/phieu-xet-nghiem/Index.vue"),
    ThongTinChanDoanHinhAnh: () =>
      import("@/views/app/benh-an/chan-doan-hinh-anh/Index.vue"),
    ChiTietChanDoanHinhAnh: () =>
      import("@/views/app/benh-an/chan-doan-hinh-anh/detail.vue"),
    ThemChanDoanHinhAnh: () =>
      import("@/views/app/benh-an/chan-doan-hinh-anh/detail.vue"),
    ThongTinThamDoChucNang: () =>
      import("@/views/app/benh-an/tham-do-chuc-nang/Index.vue"),
    PhauThuatThuThuat: () =>
      import("@/views/app/benh-an/phau-thuat-thu-thuat/Index.vue"),
    LoaiPhieuPhauThuat: () =>
      import("@/views/app/benh-an/phau-thuat-thu-thuat/LoaiPhieu.vue"),
    HoiChan: () => import("@/views/app/benh-an/hoi-chan/Index.vue"),
    TongKet15NgayDieuTri: () =>
      import("@/views/app/benh-an/tong-ket-15-ngay-dieu-tri/Index.vue"),
    TaiBienThuocThuThuatPhauThuat: () =>
      import("@/views/app/benh-an/tai-bien-phau-thuat-thu-thuat/Index.vue"),
    PhacDoDieuTri: () =>
      import("@/views/app/benh-an/phac-do-dieu-tri/Index.vue"),
    TheoDoiVaChamSoc: () =>
      import("@/views/app/benh-an/theo-doi-va-cham-soc/Index.vue"),
    ThemMoiTheoDoiVaChamSoc: () =>
      import("@/views/app/benh-an/theo-doi-va-cham-soc/detail.vue"),
    ChiTietTheoDoiVaChamSoc: () =>
      import("@/views/app/benh-an/theo-doi-va-cham-soc/detail.vue"),
    ThongTinRaVien: () =>
      import("@/views/app/benh-an/thong-tin-ra-vien/Index.vue"),
    TheoDoiTruyenDich: () =>
      import("@/views/app/benh-an/theo-doi-truyen-dich/Index.vue"),
    TheoDoiTruyenMau: () =>
      import("@/views/app/benh-an/theo-doi-truyen-mau/Index.vue"),
    ThucHienVatLyTriLieu: () =>
      import("@/views/app/benh-an/thuc-hien-vat-ly-tri-lieu/Index.vue"),
    ChiTietTheoDoiTruyenMau: () =>
      import("@/views/app/benh-an/theo-doi-truyen-mau/detail.vue"),
    ChiTietPhacDoDT: () =>
      import("@/views/app/benh-an/phac-do-dieu-tri/detail.vue"),
    ChiTietTaiBienPhauThuThuat: () =>
      import("@/views/app/benh-an/tai-bien-phau-thuat-thu-thuat/detail.vue"),
    ChiTietThucHienVatLyTriLieu: () =>
      import("@/views/app/benh-an/thuc-hien-vat-ly-tri-lieu/detail.vue"),

    ThongTinTuVong: () =>
      import("@/views/app/benh-an/thong-tin-tu-vong/Index.vue"),
    ChiTietThongTinRaVien: () =>
      import("@/views/app/benh-an/thong-tin-ra-vien/Details.vue"),
    UploadFilePhiCauTruc: () =>
      import("@/views/app/benh-an/upload-file-phi-cau-truc/Index.vue"),
    ThemMoiThamDoChucNang: () =>
      import("@/views/app/benh-an/tham-do-chuc-nang/detail.vue"),
    ChiTietThamDoChucNang: () =>
      import("@/views/app/benh-an/tham-do-chuc-nang/detail.vue"),
    ThemMoiPhieuKhamChuyenKhoa: () =>
      import("@/views/app/benh-an/phieu-kham-chuyen-khoa/detail.vue"),
    ChiTietPhieuKhamChuyenKhoa: () =>
      import("@/views/app/benh-an/phieu-kham-chuyen-khoa/detail.vue"),
    PhieuPhauThuat: () =>
      import("@/views/app/benh-an/phau-thuat-thu-thuat/PhieuPhauThuat.vue"),
    PhieuDuyetMo: () =>
      import("@/views/app/benh-an/phau-thuat-thu-thuat/PhieuDuyetMo.vue"),
    CamKetPhauThuat: () =>
      import("@/views/app/benh-an/phau-thuat-thu-thuat/CamKetPhauThuat.vue"),
    PhieuKhamGayMe: () =>
      import("@/views/app/benh-an/phau-thuat-thu-thuat/PhieuKhamGayMe.vue"),
  },
}).$mount("#app");
