<template>
  <fragment>
    <v-list-item>
      <v-list-item-icon>
        <v-avatar tile color="blue">
          <v-icon dark> mdi-account </v-icon>
        </v-avatar>
      </v-list-item-icon>
      <v-list-item-content>
        <v-list-item-title> Tên bệnh án </v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>
    <Menu :links="links"></Menu>
  </fragment>
</template>

<script>
import Menu from "./Menu.vue";
export default {
  components: { Menu },
  data() {
    return {
      links: [
        { title: "Hồ sơ bệnh án", name: "HoSoBenhAn" },
        // { title: "Phiếu khám bệnh vào viện", name: "Phiếu khám bệnh vào viện" },
        // { title: "Khoa điều trị", name: "Khoa điều trị" },
        { title: "Phác đồ điều trị", name: "PhacDoDieuTri" },
        // { title: "Tờ bệnh án", name: "Tờ bệnh án" },
        // { title: "Tờ điều trị", name: "Tờ điều trị" },
        // { title: "Tổng kết 15 ngày điều trị", name: "Tổng kết 15 ngày điều trị" },
        // { title: "Tai biến thuốc, TT, PT", name: "Tai biến thuốc, TT, PT" },
        // { title: "Phác đồ điều trị", name: "Phác đồ điều trị" },
        // { title: "Theo dõi và chăm sóc", name: "Theo dõi và chăm sóc" },
        { title: "Thông tin ra viện", name: "ThongTinRaVien" },
        // { title: "Thông tin tử vong", name: "Thông tin tử vong" },
      ],
    };
  },
};
</script>
