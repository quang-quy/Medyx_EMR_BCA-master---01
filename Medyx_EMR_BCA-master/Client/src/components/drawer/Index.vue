<template>
  <v-navigation-drawer :value="!!drawerContent && showDrawer" absolute clipped app stateless>
    <component :is="drawerContent" :thongTinBenhAn="thongTinBenhAn" :id="id" :route-name="routeName" />
  </v-navigation-drawer>
</template>
<script>
import Category from "./Category.vue";
import MedicalRecordDetail from "./MedicalRecordDetail.vue";
import MedicalRecordList from "./MedicalRecordList.vue";
export default {
  components: { Category, MedicalRecordDetail },
  props: ["thongTinBenhAn", "showDrawer"],
  data() {
    return {
      components: {
        Category: Category,
        MedicalRecordDetail: MedicalRecordDetail,
        MedicalRecordList: MedicalRecordList,
      },
      routeName: "",
      useDrawer: {
        HoSoBenhAn: MedicalRecordDetail,
        PhieuKhamBenhVaoVien: MedicalRecordDetail,
        KhoaDieuTri: MedicalRecordDetail,
        ToBenhAn: MedicalRecordDetail,
        ToDieuTri: MedicalRecordDetail,
        ThongTinChanDoanHinhAnh: MedicalRecordDetail,
        PhieuThuPhanUngThuoc: MedicalRecordDetail,
        PhieuKhamChuyenKhoa: MedicalRecordDetail,
        ThongTinPhieuXetNghiem: MedicalRecordDetail,
        VatLyTriLieu: MedicalRecordDetail,
        ThongTinThamDoChucNang: MedicalRecordDetail,
        PhauThuatThuThuat: MedicalRecordDetail,
        HoiChan: MedicalRecordDetail,
        TongKet15NgayDieuTri: MedicalRecordDetail,
        PhacDoDieuTri: MedicalRecordDetail,
        ThongTinTheoDoiVaChamSocNguoiBenh: MedicalRecordDetail,
        TheoDoiTruyenDich: MedicalRecordDetail,
        TheoDoiTruyenMau: MedicalRecordDetail,
        ThucHienVatLyTriLieu: MedicalRecordDetail,
        ChiTietTheoDoiTruyenMau: MedicalRecordDetail,
        ChiTietPhacDoDT: MedicalRecordDetail,
        ChiTietTaiBienPhauThuThuat: MedicalRecordDetail,
        ChiTietThucHienVatLyTriLieu: MedicalRecordDetail,
        TaiBienThuocThuThuatPhauThuat: MedicalRecordDetail,
        ThongTinRaVien: MedicalRecordDetail,
        ThongTinTuVong: MedicalRecordDetail,
        ThongTinBenhAn: MedicalRecordDetail,
        UploadFilePhiCauTruc: MedicalRecordDetail,
        ChiTietChanDoanHinhAnh: MedicalRecordDetail,
        ThemChanDoanHinhAnh: MedicalRecordDetail,
        ThemMoiThamDoChucNang: MedicalRecordDetail,
        ChiTietThamDoChucNang: MedicalRecordDetail,
        ThemMoiTheoDoiVaChamSoc: MedicalRecordDetail,
        ChiTietPhieuKhamChuyenKhoa: MedicalRecordDetail,
        ThemMoiPhieuKhamChuyenKhoa: MedicalRecordDetail,
        ChiTietTheoDoiVaChamSoc: MedicalRecordDetail,
        PhieuPhauThuat: MedicalRecordDetail,
        PhieuKhamGayMe: MedicalRecordDetail,
        PhieuDuyetMo: MedicalRecordDetail,
        CamKetPhauThuat: MedicalRecordDetail,
        LoaiPhieuPhauThuat: MedicalRecordDetail,
      },
    };
  },
  computed: {
    drawerContent() {
      return this.useDrawer[this.routeName];
    },
    show() {
      return !!this.drawerContent;
    },
  },
  created() {
    const url = new URL(window.location.href);
    const pathname = url.pathname;
    const [_, __, routeName, id] = pathname.split("/");
    this.routeName = routeName;
    this.id = id;
  },
};
</script>
