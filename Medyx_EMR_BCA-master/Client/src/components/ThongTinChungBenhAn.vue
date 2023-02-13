<template>
  <div class="patient-info px-3 pt-3">
    <div class="d-flex">
      <h4 v-if="!activeTab" class="mt-0 font-weight-bold pl-3 pt-2">
        Thông tin bệnh nhân
      </h4>
      <div class="ml-auto">
        <v-btn
          small
          @click="exit"
          class="ml-2"
          color="primary"
          ><v-icon>mdi-exit-to-app</v-icon> Thoát(F10)</v-btn
        >
      </div>
    </div>
    <div style="width: 50px" class="ml-3">
      <v-progress-linear
        v-if="!activeTab"
        color="red darken-2"
        rounded
        value="100"
        height="2"
      ></v-progress-linear>
    </div>
    <el-collapse accordion v-model="activeTab" @change="handleChange">
      <el-collapse-item name="1">
        <template slot="title">
          <div
            class="d-flex justify-space-between"
            style="width: 100%"
            v-if="!activeTab"
          >
            <div class="pl-3">
              Họ tên bệnh nhân:
              <span class="font-weight-bold">{{ thongTinBenhAn.ten }}</span>
              <span style="color: gray"> ({{ thongTinBenhAn.tuoi }} tuổi)</span>
            </div>
            <div>
              Khoa:
              <span class="font-weight-bold">{{ thongTinBenhAn.khoa }}</span> /
              Buồng: <b>{{ thongTinBenhAn.buong }}</b> / Giường:
              <b>{{ thongTinBenhAn.giuong }}</b>
            </div>
            <div class="pr-6 mr-4" style="color: gray">
              <b>Thời gian: </b>{{ thongTinBenhAn.vao_vien }} <b>đến</b>
              {{ thongTinBenhAn.ra_vien }}
            </div>
          </div>
          <div v-else class="pl-3">
            <h4 class="mt-0 font-weight-bold">Thông tin bệnh nhân</h4>
          </div>
        </template>
        <el-descriptions size="medium" class="pl-3">
          <el-descriptions-item label="Khoa">{{
            thongTinBenhAn.khoa
          }}</el-descriptions-item>
          <el-descriptions-item label="Sổ vào viện:">{{
            thongTinBenhAn.so_vao_vien
          }}</el-descriptions-item>
          <el-descriptions-item label="Buồng">{{
            thongTinBenhAn.buong
          }}</el-descriptions-item>
          <el-descriptions-item label="Họ tên"
            ><span class="font-weight-bold">{{
              thongTinBenhAn.ten
            }}</span></el-descriptions-item
          >
          <el-descriptions-item label="Sổ lưu trữ">{{
            thongTinBenhAn.so_luu_tru
          }}</el-descriptions-item>
          <el-descriptions-item label="Mã YT">{{
            thongTinBenhAn.ma_yt
          }}</el-descriptions-item>

          <el-descriptions-item label="Tuổi">{{
            thongTinBenhAn.tuoi
          }}</el-descriptions-item>
          <el-descriptions-item label="Vào viện">{{
            thongTinBenhAn.vao_vien
          }}</el-descriptions-item>
          <el-descriptions-item label="Ra viện">{{
            thongTinBenhAn.ra_vien
          }}</el-descriptions-item>
          <el-descriptions-item label="Địa chỉ">{{
            thongTinBenhAn.dia_chi
          }}</el-descriptions-item>
        </el-descriptions>
      </el-collapse-item>
    </el-collapse>
  </div>
</template>

<script>
export default {
  props: {
    thongTinBenhAn: Object,
  },
  data: () => ({
    activeTab: null,
  }),
  created() {
    window.addEventListener("keydown", this.handlerKeyPress, false);
  },
  methods: {
    handleChange(val) {
      console.log(this.activeTab, val);
    },
    exit() {
      location.href = `${window.origin}/HSBADS/Index`;
    },
    handlerKeyPress(e) {
      if(e.key == 'F10'){
        location.href = `${window.origin}/HSBADS/Index`;
        e.preventDefault();
      }
    },
  },
};
</script>

<style>
.patient-info {
  position: sticky;
  top: 0;
  z-index: 500;
  background: white;
}
.el-descriptions__header {
  margin-bottom: 10px !important;
}
</style>
