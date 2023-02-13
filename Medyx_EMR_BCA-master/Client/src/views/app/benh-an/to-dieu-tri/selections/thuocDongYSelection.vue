<template>
  <Fragment>
    <el-form-item prop="maThuoc" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-maThuoc`
            : `${crudId}-creating-maThuoc`
        "
      >
        <base-select-async
          v-model="form.maThuoc"
          :label="
            (item) =>
              `${item.maThuoc} ${item.tenTm ? '-' + item.tenTm : ''} ${
                item.hamLuong ? '-' + item.hamLuong : ''
              } ${item.donViTinh.tenDvt ? '-' + item.donViTinh.tenDvt : ''}`
          "
          keyValue="maThuoc"
          :apiFunc="getThuocDongY"
          placeholder="Tên thuốc"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="donViTinh" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-donViTinh`
            : `${crudId}-creating-donViTinh`
        "
      >
        <el-input
          v-model="form.donViTinh"
          placeholder="Đơn vị tính"
          disabled
          size="small"
        ></el-input>
      </portal>
    </el-form-item>
  </Fragment>
</template>

<script>
import * as ApiThucDongY from "@/api/benhAnToDieuTri/thuoc-dong-y";
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
    currentEditingRowId() {},
    "form.maThuoc"(newVal) {
      if (newVal) {
        const item = this.lisThuocs.find((e) => e.maThuoc == newVal);
        if (item) {
          this.form.maThuocCus = item.maThuoc;
          this.form.donViTinh = item.donViTinh.tenDvt;
        }
      }
    },
  },
  methods: {
    async getThuocDongY(params) {
      return await ApiThucDongY.ds_thuocDongY({
        ...params,
      });
    },
    async listThuocs() {
      const { data } = await ApiThucDongY.ds_thuocDongY({
        isWithRelation: true,
      });
      this.lisThuocs = data;
    },
  },
};
</script>
