<template>
  <fragment>
    <v-list-item dense v-loading="loading">
      <v-list-item-avatar>
        <v-avatar size="40" tile color="blue">
          <v-icon dark> mdi-account </v-icon>
        </v-avatar>
      </v-list-item-avatar>

      <v-list-item-content>
        <v-list-item-title> {{ thongTinBenhAn.loai_ba }}</v-list-item-title>
        <v-list-item-subtitle>{{ thongTinBenhAn.ma_ba }}</v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>
    <Menu :links="links" :route-name="routeName"></Menu>
  </fragment>
</template>

<script>
const links = [
  { title: "Thông tin bệnh án", url: "/HSBADS/ThongTinBenhAn" },
  //{ title: "Hồ sơ bệnh án", url: "/HSBADS/HoSoBenhAn" },
  { title: "Phiếu khám bệnh vào viện", url: "/HSBADS/PhieuKhamBenhVaoVien" },
  { title: "Khoa điều trị", url: "/HSBADS/KhoaDieuTri" },
  { title: "Tờ bệnh án", url: "/HSBADS/HoSoBenhAn" },
  { title: "Tờ điều trị", url: "/HSBADS/ToDieuTri" },
  { title: "Phiếu thử phản ứng thuốc", url: "/HSBADS/PhieuThuPhanUngThuoc" },
  { title: "Phiếu khám chuyên khoa", url: "/HSBADS/PhieuKhamChuyenKhoa" },
  { title: "Phiếu xét nghiệm", url: "/HSBADS/ThongTinPhieuXetNghiem" },
  {
    title: "Thông tin chẩn đoán hình ảnh",
    url: "/HSBADS/ThongTinChanDoanHinhAnh",
  },
  {
    title: "Thông tin thăm dò chức năng",
    url: "/HSBADS/ThongTinThamDoChucNang",
  },
  // { title: "Thông tin vật lý trị liệu", url: "/HSBADS/VatLyTriLieu" },
  { title: "Thông tin phẫu thuật thủ thuật", url: "/HSBADS/PhauThuatThuThuat" },
  { title: "Thông tin hội chẩn", url: "/HSBADS/HoiChan" },
  { title: "Sơ kết 15 ngày điều trị", url: "/HSBADS/TongKet15NgayDieuTri" },
  {
    title: "Tai biến thuốc, thủ thuật, phẫu thuật",
    url: "/HSBADS/TaiBienThuocThuThuatPhauThuat",
  },
  { title: "Phác đồ điều trị", url: "/HSBADS/PhacDoDieuTri" },
  { title: "Thực hiện vật lý trị liệu", url: "/HSBADS/ThucHienVatLyTriLieu" },
  {
    title: "Theo dõi và chăm sóc",
    url: "/HSBADS/ThongTinTheoDoiVaChamSocNguoiBenh",
  },
  {
    title: "Theo dõi truyền dịch",
    url: "/HSBADS/TheoDoiTruyenDich",
  },
  {
    title: "Theo dõi truyền máu",
    url: "/HSBADS/TheoDoiTruyenMau",
  },
  // { title: "Thông tin ra viện", url: "/HSBADS/ThongTinRaVien" },
  { title: "Thông tin tử vong", url: "/HSBADS/ThongTinTuVong" },
  { title: "Tệp tin đính kèm", url: "/HSBADS/UploadFilePhiCauTruc" },
];
import Menu from "./Menu.vue";

export default {
  components: { Menu },
  props: ["id", "routeName", "thongTinBenhAn"],
  computed: {
    links() {
      return links.map((l) => ({
        title: l.title,
        url: l.url + "/" + this.id,
      }));
    },
  },
  data: () => ({
    tenBenhAn: "-",
    maBenhAn: "-",
    loading: false,
  }),
};
</script>
