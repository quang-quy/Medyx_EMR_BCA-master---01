<template>
  <div>
    <div>
      <div
        style="width: 100%; font-size: 18px; font-weight: bold"
        class="d-flex justify-center"
      >
        PHẦN I: PHẦN CHUNG
      </div>
    </div>
    <div>
      <div class="mb-6">
        <HanhChinh />
      </div>
      <div style="margin-top: 50px">
        <QuanLyNguoiBenh
          :benhAn="benhAn"
          :benhAnKhoaDieuTri="benhAnKhoaDieuTri"
          @get-quanLyNguoibenh="getQuanLyNguoibenh"
        />
      </div>
      <div style="margin-top: 50px">
        <ChanDoan 
          :benhAn="benhAn" 
          :benhAnKhoaDieuTri="benhAnKhoaDieuTri[0]" 
          @get-chanDoan="getChanDoan"
          />
      </div>
      <div style="margin-top: 50px">
        <TinhTrangRaVien 
          :benhAn="benhAn" 
          @get-tinhTrangRaVien="getTinhTrangRaVien"
          />
      </div>
    </div>
  </div>
</template>

<script>
import HanhChinh from "./hanhChinh.vue";
import QuanLyNguoiBenh from "./quanLyNguoiBenh.vue";
import ChanDoan from "./chanDoan.vue";
import TinhTrangRaVien from "./tinhTrangRaVien.vue";
import {
  chiTietToBenhAn,
  getTienSuBenh,
  getKhamYhhd,
  getKhoaDieuTri,
  getTongKetBenhAn,
  getKhamYhct,
} from "@/api/benh-an.js";
export default {
  components: {
    HanhChinh,
    QuanLyNguoiBenh,
    ChanDoan,
    TinhTrangRaVien,
  },
  data: () => ({
    benhAn: {},
    benhAnKhoaDieuTri: {
    },
    benhAnkdt:{
      idba: null,
      stt: null,
      idhis: null,
      maBa: null,
      maBn: null,
      maKhoa: null,
      ngayVaoKhoa: null,
      soNgayDt: null,
      huy: false,
      maMay: null,
      ngayLap: null,
      ngaySd: null,
      ngayHuy: null,
      buong: null,
      giuong: null,
      MaBenhChinhVk: null,
      MaBenhKemVk1: null,
      MaBenhKemVk2: null,
      MaBenhKemVk3: null,
      BsdieuTri: null,
    },
  }),
  mounted() {
    this.getBenhAn();
  },
  methods: {
    async getBenhAn() {
      const id = window.location.href.split("/").at(-1);
      let data = await chiTietToBenhAn(id);
      this.benhAn = data.data;
      data = await getKhoaDieuTri({ idba: id, forSelect: true});
      this.benhAnKhoaDieuTri = data.data;
      for (let key in this.benhAnkdt) {
        if (this.benhAnKhoaDieuTri[0] && this.benhAnKhoaDieuTri[0].hasOwnProperty(key)) {
          this.benhAnkdt[key] = this.benhAnKhoaDieuTri[0][key];
        }
      }
      this.benhAnkdt.MaBenhChinhVk=this.benhAnKhoaDieuTri[0].benhChinh.maBenh
      this.benhAnkdt.MaBenhKemVk1=this.benhAnKhoaDieuTri[0].benhKem1.maBenh
      this.benhAnkdt.MaBenhKemVk2=this.benhAnKhoaDieuTri[0].benhKem2.maBenh
      this.benhAnkdt.MaBenhKemVk3=this.benhAnKhoaDieuTri[0].benhKem3.maBenh
      this.benhAnkdt.BsdieuTri=this.benhAnKhoaDieuTri[0].bsdieuTri.maNv
      this.benhAnkdt.buong=this.benhAnKhoaDieuTri[0].buong.maBuong
      this.benhAnkdt.giuong=this.benhAnKhoaDieuTri[0].giuong.maGiuong
    },
    getQuanLyNguoibenh(data){
      for (let key in this.benhAn) {
        if (data && data.hasOwnProperty(key)) {
          this.benhAn[key] = data[key];
        }
      }
      this.$emit('get-ThongTinBenhAn',this.benhAn, this.benhAnkdt)
    },
    getChanDoan(data){
      for (let key in this.benhAn) {
        if (data && data.hasOwnProperty(key)) {
          this.benhAn[key] = data[key];
        }
      }
      for (let key in this.benhAnkdt) {
        if (data && data.hasOwnProperty(key)) {
          this.benhAnkdt[key] = data[key];
        }
      }
      this.benhAnkdt.MaBenhChinhVk=data.benhChinh.maBenh
      this.benhAnkdt.MaBenhKemVk1=data.benhKem1.maBenh
      this.benhAnkdt.MaBenhKemVk2=data.benhKem2.maBenh
      this.benhAnkdt.MaBenhKemVk3=data.benhKem3.maBenh
      // this.benhAnkdt.BsdieuTri=data.bsdieuTri.maNv
      // this.benhAnkdt.buong=data.buong.maBuong
      // this.benhAnkdt.giuong=data.giuong.maGiuong
      this.$emit('get-ThongTinBenhAn',this.benhAn, this.benhAnkdt)
    },
    getTinhTrangRaVien(data){
      for (let key in this.benhAn) {
        if (data && data.hasOwnProperty(key)) {
          this.benhAn[key] = data[key];
        }
      }
      this.$emit('get-ThongTinBenhAn',this.benhAn, this.benhAnkdt)
    }
  },
};
</script>

<style></style>
