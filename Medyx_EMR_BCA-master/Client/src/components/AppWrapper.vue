<template>
  <v-app>
    <component
      :is="drawerComponent"
      :thongTinBenhAn="thongTinBenhAn"
      :showTenBenhAn="showTenBenhAn"
      :showDrawer="showDrawer"
    ></component>
    <v-main>
      <ThongTinChungBenhAn
        v-if="showThongTinChungBenhAn"
        :thongTinBenhAn="thongTinBenhAn"
      />
      <v-btn
        :style="{
          'z-index': 999999,
          position: 'fixed',
          bottom: '30px',
          left: '70px',
          opacity: 0.5,
        }"
        v-show="showTenBenhAn"
        @click="showDrawer = !showDrawer"
        class="drawer-control"
        color="primary"
        :title="`${showDrawer ? 'Đóng' : 'Mở'} menu`"
        small
        fab
      >
        <v-icon
          >mdi-{{
            showDrawer ? "chevron-double-left" : "chevron-double-right"
          }}</v-icon
        >
      </v-btn>
      <slot />
    </v-main>
  </v-app>
</template>
<script>
import Drawer from "@/components/drawer/Index.vue";
import ThongTinChungBenhAn from "./ThongTinChungBenhAn";
import { getDetailBenhAn } from "@/api/benh-an.js";
export default {
  components: { ThongTinChungBenhAn },
  watch: {
    showDrawer(val) {
      localStorage.setItem("showDrawer", +val);
    },
  },
  created() {
    window.addEventListener("keydown", this.handlerKeyPress, false);
  },
  data() {
    return {
      showDrawer:
        localStorage.getItem("showDrawer") !== undefined
          ? !!Number(localStorage.getItem("showDrawer"))
          : true,
      thongTinBenhAn: {
        khoa: "",
        buong: "",
        giuong: "",
        so_vao_vien: "",
        so_luu_tru: "",
        ma_bn: "",
        ma_yt: "",
        ten: "",
        tuoi: "",
        vao_vien: "",
        ra_vien: "",
        dia_chi: "",
        loai_ba: "",
      },
    };
  },
  props: {
    drawerComponent: {
      type: Object,
      default: () => Drawer,
    },
    showTenBenhAn: {
      type: Boolean,
      default: () => true,
    },
    showThongTinChungBenhAn: {
      type: Boolean,
      default: () => true,
    },
    idba: [Number, String],
  },
  methods: {
    handlerKeyPress(e) {
      if (e.key == "F8") {
        location.href = `${window.origin}/HSBADS/Index`;
      }
    },
    async getThongTinChungBenhAn() {
      const { data } = await getDetailBenhAn(
        this.idba ? this.idba : window.location.href.split("/").at(-1)
      );

      this.thongTinBenhAn.ten = data.benhNhan ? data.benhNhan.hoTen : null;
      this.thongTinBenhAn.loai_ba = data.loaiBenhAn
        ? data.loaiBenhAn.tenLoaiBa
        : null;
      this.thongTinBenhAn.ma_ba = data.maBa;
      this.thongTinBenhAn.khoa = data.khoa ? data.khoa.tenKhoa : null;
      this.thongTinBenhAn.buong = data.buong ? data.buong.tenBuong : null;
      this.thongTinBenhAn.giuong = data.giuong ? data.giuong.tenGiuong : null;
      this.thongTinBenhAn.so_vao_vien = data.soVaoVien;
      this.thongTinBenhAn.so_luu_tru = data.soLuuTru;
      this.thongTinBenhAn.ma_yt = data.maYt;
      this.thongTinBenhAn.ma_bn = data.benhNhan ? data.benhNhan.maBn : null;
      this.thongTinBenhAn.tuoi = data.benhNhan ? data.benhNhan.tuoi : null;
      this.thongTinBenhAn.vao_vien = new Date(data.ngayVv).toLocaleString(
        "en-GB",
        {
          year: "numeric",
          month: "numeric",
          day: "numeric",
          hour: "2-digit",
          minute: "2-digit",
        }
      );
      this.thongTinBenhAn.ra_vien = new Date(data.ngayRv).toLocaleString(
        "en-GB",
        {
          year: "numeric",
          month: "numeric",
          day: "numeric",
          hour: "2-digit",
          minute: "2-digit",
        }
      );
      this.thongTinBenhAn.dia_chi = `${
        data.benhNhan.soNha ? data.benhNhan.soNha : ""
      } ${data.benhNhan.thon ? "," + data.benhNhan.thon : ""} ${
        data.benhNhan.phuongXa
          ? data.benhNhan.phuongXa.tenPxa
            ? "," + data.benhNhan.phuongXa.tenPxa
            : ""
          : ""
      }  ${
        data.benhNhan.quanHuyen
          ? data.benhNhan.quanHuyen.tenQh
            ? "," + data.benhNhan.quanHuyen.tenQh
            : ""
          : ""
      }  ${
        data.benhNhan.tinh
          ? data.benhNhan.tinh.tenTinh
            ? "," + data.benhNhan.tinh.tenTinh
            : ""
          : ""
      } ${
        data.benhNhan.quocGia
          ? data.benhNhan.quocGia.tenQgtenQg
            ? "," + data.benhNhan.quocGia.tenQg
            : ""
          : ""
      } `;
    },
  },
  mounted() {
    if (this.showTenBenhAn || this.showThongTinChungBenhAn) {
      this.getThongTinChungBenhAn();
    }
    setTimeout((e) => {
      let forms = Array.from(
        document.querySelector(".el-form").querySelectorAll(".el-form-item")
      );
      const formInputs = forms
        .map(
          (x) =>
            x.querySelector(".el-input__inner") ||
            x.querySelector(".el-textarea__inner")
        )
        .filter((x) => x && !x.disabled);
      if (formInputs.length) {
        formInputs[0].setAttribute("id", "first-item-form");
        document.getElementById("first-item-form").focus();
      }
    }, 500);
  },
};
</script>
