<template>
  <Fragment>
    <el-form-item prop="sttKhoa" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-sttKhoa`
            : `${crudId}-creating-sttKhoa`
        "
      >
        <base-select-async
          v-model="form.sttKhoa"
          :label="
            (item) =>
              `${item.khoa.tenKhoa ? item.khoa.tenKhoa : null}-${formatDatetime(
                item.ngayVaoKhoa
              )}`
          "
          keyValue="stt"
          :apiFunc="getKhoa"
          placeholder="Khoa điều trị"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="maDichTruyen" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-maDichTruyen`
            : `${crudId}-creating-maDichTruyen`
        "
      >
        <base-select-async
          v-model="form.maDichTruyen"
          :label="
            (item) =>
              `${formatDatetime(item.ngayYLenh)}-${item.maThuoc} - ${
                item.tenThuoc
              } - ${item.tenThuoc}+${item.thuoc.hamLuong} - ${
                item.thuoc.donViTinh.tenDvt
              } - ${item.bsChiDinh.hoTen}`
          "
          keyValue="maThuoc"
          :apiFunc="getThuoc"
          :defaultParams="{
            idba: idba,
            sttKhoa: form.sttKhoa,
          }"
          placeholder="Mã thuốc"
          :disabled="!form.sttKhoa"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="tenDichTruyen" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-tenDichTruyen`
            : `${crudId}-creating-tenDichTruyen`
        "
      >
        <el-input
          outlined
          hide-details
          placeholder="Tên thuốc"
          v-model="form.tenDichTruyen"
          type="text"
          size="mini"
        ></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="soLo" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-soLo`
            : `${crudId}-creating-soLo`
        "
      >
        <el-input
          outlined
          hide-details
          placeholder="Sô sản xuất"
          v-model="form.soLo"
          type="text"
          size="mini"
        ></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="bschiDinh" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-bschiDinh`
            : `${crudId}-creating-bschiDinh`
        "
      >
        <el-input
          outlined
          hide-details
          placeholder="Bác sỹ chỉ định"
          v-model="form.bschiDinh"
          type="text"
          size="mini"
          disabled
        ></el-input>
      </portal>
    </el-form-item>
  </Fragment>
</template>

<script>
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import * as apiKhoaDieuTri from "@/api/khoa-dieu-tri";
import * as apiThuoc from "@/api/benhAnToDieuTri/thuoc-tay-y";
import { formatDate, formatDatetime } from "@/utils/formatters";
export default {
  props: {
    form: Object,
    crudId: String,
    currentEditingRowId: String,
    isEditForm: {
      type: Boolean,
      default: false,
    },
  },

  data() {
    return {
      idba: window.location.href.split("/").at(-1),
      sttKhoa: null,
      formatDate,
      formatDatetime,
    };
  },
  watch: {
    "form.maDichTruyen": {
      async handler(newValue) {
        if (!newValue) return;
        const { data } = await apiThuoc.index({
          idba: this.idba,
          sttKhoa: this.form.sttKhoa,
        });
        if (data) {
          const thuocDetail = data.filter((e) => e.maThuoc == newValue)[0];
          if (thuocDetail) {
            this.form.tenDichTruyen = thuocDetail.thuoc.tenTm;
            this.form.soLo = thuocDetail.soDangKi;
            this.form.bschiDinh = thuocDetail.bsChiDinh.hoTen;
          }
        }
      },
    },
    currentEditingRowId() {},
  },
  methods: {
    async getKhoa(params) {
      return await apiKhoaDieuTri.index(this.idba, { huy: false, ...params });
    },
    async getThuoc(params) {
      return await apiThuoc.index({
        ...params,
        ForFilter: true,
      });
    },
  },
  created() {
    this.getKhoa();
  },
};
</script>
