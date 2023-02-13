<template>
  <app-wrapper :showThongTinChungBenhAn="false">
    <div
      class="d-flex flex-column align-center"
      style="background: #f8f9f9; position: relative"
    >
      <div class="menu-top">
        <div
          class="d-flex justify-space-around align-center"
          style="
            max-width: 1080px;
            width: 100%;
            border-bottom: 2px solid #497caf;
            height: 100%;
          "
        >
          <div style="flex: 1">
            <div style="font-size: 20px; font-weight: bold">Tờ bệnh án</div>
            <div class="mt-1" style="font-style: italic">
              Thông tin chi tiết tờ bệnh án
            </div>
          </div>

          <div class="d-flex">
            <v-btn
              color="primary"
              @click="handlePrint"
              class="mr-2"
              small
              de
              depressed
              :disabled="!disableActions.export"
            >
              <v-icon small left> mdi-printer </v-icon>In phiếu
            </v-btn>
            <v-btn
              color="primary"
              @click="updateData"
              small
              depressed
              :disabled="!disableActions.export"
              :loading="isLoading"
            >
              <v-icon small left> mdi-pencil </v-icon>Cập nhật
            </v-btn>
            <v-btn small @click="exit" class="ml-2" color="primary"
              ><v-icon>mdi-exit-to-app</v-icon> Thoát(F10)</v-btn
            >
          </div>
        </div>
      </div>
      <div class="side-content pb-4" style="flex: 1">
        <div class="pa-4" style="flex: 1">
          <div class="mb-6">
            <TieuDe :thongTinChung="thongTinChung" />
          </div>
          <div class="mb-6" id="phan-chung">
            <PhanChung
              :thongTinChung="thongTinChung"
              v-intersect="scrollPhanChung"
              @get-ThongTinBenhAn="getThongTinBenhAn"
            />
          </div>
          <div class="mb-6 mt-6 pt-6" id="benh-an" v-intersect="scrollBenhAn">
            <BanhAn @get-benhAn="getBenhAn" />
          </div>
          <div class="mt-6 pt-6" id="tong-ket" v-intersect="scrollTongKet">
            <TongKetRaVien @get-tongKetRaVien="getTongKetRaVien" />
          </div>
          <div class="mt-6 pt-6" id="file-dinh-kem" v-intersect="scrollTapTin">
            <TapTinDinhKem @get-total-files="getTotalFile" />
          </div>
        </div>
      </div>
      <div class="d-flex justify-center bottom-side-benh-an">
        <div
          class="title-tab d-flex mt-2 px-4"
          v-for="item in tabs"
          :key="item.index"
          @click="scrollToElement(item)"
          :style="{
            'border-bottom': item.index == tabView ? '4px solid #2980b9' : '',
          }"
        >
          <div
            class="d-flex align-center"
            style="height: 100%"
            :style="{ color: item.index == tabView ? '#2980B9' : '' }"
          >
            <v-badge
              color="red"
              :content="tongFile"
              v-if="item.bage"
              small
              :dot="tongFile && tongFile > 0 ? false : true"
            >
              <div class="">{{ item.name }}</div>
            </v-badge>
            <div v-else>{{ item.name }}</div>
          </div>
        </div>
      </div>
    </div>
  </app-wrapper>
</template>
<script>
import TieuDe from "./components/tieuDe.vue";
import PhanChung from "./components/phan-chung/index.vue";
import BanhAn from "./components/benh-an/index.vue";
import TongKetRaVien from "./components/tong-ket-ra-vien/index.vue";
import TapTinDinhKem from "./components/tap-tin/Index.vue";
import { update, printBa } from "@/api/benh-an.js";

export default {
  props: ["disableActions"],
  components: {
    TieuDe,
    PhanChung,
    BanhAn,
    TongKetRaVien,
    TapTinDinhKem,
  },
  data() {
    return {
      isLoading: false,
      form: {
        benhAn: null,
        benhAnKhamYhct: null,
        benhAnKhamYhhd: null,
        BenhAnKhoaDieuTri: null,
        benhantongketbenhan: null,
      },
      tabView: 1,
      tongFile: 0,
      tabs: [
        {
          name: "Phần I. Phần chung",
          index: 1,
          icon: "mdi-book-open",
          id: "phan-chung",
        },
        {
          name: "Phần II. Bệnh Án",
          index: 2,
          icon: "mdi-medical-bag",
          id: "benh-an",
        },
        {
          name: "Tổng kết ra viện",
          index: 3,
          icon: "mdi-lead-pencil",
          id: "tong-ket",
        },
        {
          name: "File đính kèm",
          index: 4,
          icon: "mdi-lead-pencil",
          id: "file-dinh-kem",
        },
      ],
      thongTinChung: {},
      idba: window.location.href.split("/").at(-1),
    };
  },
  created() {
    window.addEventListener("keydown", this.handlerKeyPress, false);
  },
  methods: {
    handlerKeyPress(e) {
      if(e.key == 'F10'){
        location.href = `${window.origin}/HSBADS/Index`;
        e.preventDefault();
      }
    },
    exit() {
      location.href = `${window.origin}/HSBADS/Index`;
    },
    scrollToElement(item) {
      this.tabView = item.index;
      const element = document.getElementById(item.id);
      element.scrollIntoView({ behavior: "smooth" });
    },
    scrollBenhAn(entries, observer) {
      if (entries[0].isIntersecting) {
        this.tabView = 2;
      }
    },
    scrollTongKet(entries, observer) {
      if (entries[0].isIntersecting) {
        this.tabView = 3;
      }
    },
    scrollPhanChung(entries, observer) {
      if (entries[0].isIntersecting) {
        this.tabView = 1;
      }
    },
    scrollTapTin(entries, observer) {
      if (entries[0].isIntersecting) {
        this.tabView = 4;
      }
    },
    getThongTinBenhAn(benhAn, benhAnkdt) {
      this.form.benhAn = benhAn;
      this.form.BenhAnKhoaDieuTri = benhAnkdt;
    },
    getBenhAn(benhAnTienSuBenh, benhAnYhhd, benhAnYhct) {
      this.form.benhAnKhamYhct = benhAnYhct;
      this.form.benhAnKhamYhhd = benhAnYhhd;
      this.form.benhAnTienSuBenh = benhAnTienSuBenh;
      // console.log(this. form)
    },
    getTongKetRaVien(data) {
      this.form.benhantongketbenhan = data;
    },
    getTotalFile(tongFile) {
      this.tongFile = tongFile;
    },
    async updateData() {
      const id = window.location.href.split("/").at(-1);
      // await update(id, this.form);
      // console.log(this.form.benhAnKhamYhhd)
      try {
        this.isLoading = true;
        await update(id, this.form);
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
      } catch (error) {
        console.log(error);
        this.$message.error("Thất bại");
      } finally{
        this.isLoading = false;
      }
    },
    handlePrint() {
      return printBa(this.idba);
    },
  },
};
</script>
<style scoped>
.bottom-side-benh-an {
  background: #f1f7fb;
  height: 60px;
  z-index: 20;
  position: sticky;
  bottom: 0px;
  width: 100%;
  border-top: 1px solid #d7dbdd;
}
.side-content {
  max-width: 1080px;
  border: 1px solid #e5e7e9;
  background: white;
}
.title-tab {
  cursor: pointer;
  font-weight: 500;
  color: black;
}
.title-tab:hover {
  background: #d6eaf8;
}
.menu-top {
  background: white;
  height: 80px;
  width: 100%;
  top: 0;
  z-index: 20;
  position: sticky;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
}
</style>
