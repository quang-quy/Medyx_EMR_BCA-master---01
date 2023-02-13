<template>
  <div style="border: 1px solid #2874a6" class="pa-6">
    <div style="width: 100%">
      <div
        style="width: 100%; font-size: 20px; font-weight: bold"
        class="d-flex justify-center"
      >
        {{
          thongTinChung.loaiBenhAn
            ? thongTinChung.loaiBenhAn.tenLoaiBa.toUpperCase()
            : ""
        }}
      </div>
      <div class="d-flex justify-space-between">
        <div style="width: 250px">
          <div class="d-flex align-end mt-1">
            <div class="mr-2 tilte-benhan">Khoa:</div>
            <div class="content-ba">
              {{ thongTinChung.khoa ? thongTinChung.khoa.tenKhoa : "" }}
            </div>
          </div>
          <div class="d-flex align-end mt-1">
            <div class="mr-2 tilte-benhan">Buồng:</div>
            <div class="content-ba">
              {{ thongTinChung.buong ? thongTinChung.buong.tenBuong : "" }}
            </div>
          </div>
          <div class="d-flex align-end mt-1">
            <div class="mr-2 tilte-benhan">Giường:</div>
            <div class="content-ba">
              {{ thongTinChung.giuong ? thongTinChung.giuong.tenGiuong : "" }}
            </div>
          </div>
        </div>
        <div style="width: 300px">
          <div class="d-flex align-end">
            <div class="mr-2 tilte-benhan">Sổ vào viện:</div>
            <div class="content-ba">
              {{ thongTinChung.soVaoVien }}
            </div>
          </div>
          <div class="d-flex align-end">
            <div class="mr-2 tilte-benhan">Sổ lưu trữ:</div>
            <div class="content-ba">
              {{ thongTinChung.soLuuTru }}
            </div>
          </div>
          <div class="d-flex align-end">
            <div class="mr-2 tilte-benhan">Mã người bệnh:</div>
            <div class="content-ba">
              {{ thongTinChung.maBa }}
            </div>
          </div>
          <div class="d-flex align-end">
            <div class="mr-2 tilte-benhan">Mã YT:</div>
            <div class="content-ba">
              {{ thongTinChung.maYt }}
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- <v-progress-linear value="100" height="1" class="mt-6"></v-progress-linear> -->
  </div>
</template>

<script>
import { getDetailBenhAn } from "@/api/benh-an.js";

export default {
  data: () => ({
    thongTinChung: {},
  }),
  mounted() {
    this.getThongTinChung();
  },
  methods: {
    async getThongTinChung() {
      let res = null;
      const id = window.location.href.split("/").at(-1);
      res = await getDetailBenhAn(id);
      this.thongTinChung = res.data;
    },
  },
};
</script>

<style scoped>
.tilte-benhan {
  font-weight: 400;
  font-size: 14px;
}
.content-ba {
  font-weight: 500;
  border-bottom: 1px solid #cacfd2;
  min-width: 100px;
}
</style>
