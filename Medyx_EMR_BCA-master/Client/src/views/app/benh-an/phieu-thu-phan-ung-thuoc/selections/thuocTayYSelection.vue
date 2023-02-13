<template>
  <Fragment>
    <el-form-item prop="maThuoc" :style="{ 'margin-bottom': 0 }">
      <portal :to="
        isEditForm
          ? `${crudId}-editing-${this.currentEditingRowId}-maThuoc`
          : `${crudId}-creating-maThuoc`
      ">
        <base-select-async v-model="form.maThuoc" :label="
          (item) =>
            `${item.maThuoc} ${item.tenTm ? '-' + item.tenTm : ''} ${item.hamLuong ? '-' + item.hamLuong : ''
            } ${item.donViTinh.tenDvt ? '-' + item.donViTinh.tenDvt : ''}`
        " keyValue="maThuoc" :apiFunc="getThuocTayY" placeholder="Tên thuốc">
        </base-select-async>
      </portal>
    </el-form-item>

    <el-form-item prop="tenThuoc" :style="{ 'margin-bottom': 0 }">
      <portal :to="
        isEditForm
          ? `${crudId}-editing-${this.currentEditingRowId}-tenThuoc`
          : `${crudId}-creating-tenThuoc`
      ">
        <el-input v-model="form.tenThuoc" placeholder="Tên Thuốc" size="small"></el-input>
      </portal>
    </el-form-item>

    <el-form-item prop="hamLuong" :style="{ 'margin-bottom': 0 }">
      <portal :to="
        isEditForm
          ? `${crudId}-editing-${this.currentEditingRowId}-hamLuong`
          : `${crudId}-creating-hamLuong`
      ">
        <el-input v-model="form.hamLuong" disabled size="small"></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="donViTinh" :style="{ 'margin-bottom': 0 }">
      <portal :to="
        isEditForm
          ? `${crudId}-editing-${this.currentEditingRowId}-donViTinh`
          : `${crudId}-creating-donViTinh`
      ">
        <el-input v-model="form.donViTinh" disabled size="small"></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="thuocDuongDung" :style="{ 'margin-bottom': 0 }">
      <portal :to="
        isEditForm
          ? `${crudId}-editing-${this.currentEditingRowId}-thuocDuongDung`
          : `${crudId}-creating-thuocDuongDung`
      ">
        <el-input v-model="form.thuocDuongDung" disabled size="small"></el-input>
      </portal>
    </el-form-item>
  </Fragment>
</template>

<script>
import * as ApiThuocTayY from "@/api/benhAnToDieuTri/thuoc-tay-y";
import { getDanhSachThuoc } from "@/api/danh-muc.js";

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
  created() {
    this.listThuocs();
  },
  data() {
    return {
      lisThuocs: [],
    };
  },
  watch: {
    currentEditingRowId() { },
    "form.maThuoc"(newVal) {
      if (newVal) {
        const item = this.lisThuocs.find((e) => e.maThuoc == newVal);
        if (item) {
          this.form.maThuocCus = item.maThuoc;
          this.form.tenThuoc = `${item.tenTm} ${item.quocGia && item.quocGia.tenQg ? item.quocGia.tenQg : ''} ${item.hamLuong}/${item.donViTinh && item.donViTinh.tenDvt ? item.donViTinh.tenDvt : ''}`
        }
      }
    },
  },
  methods: {
    async getThuocTayY(params) {
      return await getDanhSachThuoc({
        ...params,
      });
    },
    async listThuocs() {
      const { data } = await getDanhSachThuoc();
      this.lisThuocs = data;
    },
  },
};
</script>
