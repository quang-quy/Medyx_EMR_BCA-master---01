<template>
  <el-dialog :title="title" :visible.sync="show" width="650px" height="30%">
    <el-form ref="form" @submit="onSubmit">
      <div class="d-flex py-1">
        <div class="body-2 font-weight-bold mr-auto">Khoa điều trị</div>
        <base-select-async
          v-model="form.sttKhoa"
          :label="
            (item) =>
              `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
                item.ngayVaoKhoa
              )}`
          "
          keyValue="stt"
          :apiFunc="getSelectKhoa"
           style="width: 450px"
        >
        </base-select-async>
      </div>
      <div class="d-flex py-1">
        <div class="body-2 font-weight-bold mr-auto">Bác sỹ điều trị</div>
        <base-select-async
          v-model="form.bsDieuTri"
          :label="
            (item) =>
              `${item.maNv} - ${item.hoTen} ${
                item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
              }`
          "
          keyValue="maNv"
          :apiFunc="getDanhDSNhanVien"
           style="width: 450px"
        >
        </base-select-async>
      </div>
      <div class="d-flex py-1">
        <div class="body-2 font-weight-bold mr-auto">Ngày Y lệnh</div>
        <el-date-picker
          v-model="form.ngayYLenh"
          type="datetime"
          style="width: 450px"
          size="small"
          value-format="yyyy-MM-ddTHH:mm:ss"
          format="dd/MM/yyyy HH:mm"
        >
        </el-date-picker>
      </div>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <v-btn
        class="mr-2 text-none"
        color="primary"
        outlined
        @click="onSubmit"
        :loading="loading"
      >
        <v-icon small left>mdi-book-plus</v-icon>
        {{ isCreate ? "Thêm mới" : "Cập nhật" }}
      </v-btn>
    </span>
  </el-dialog>
</template>

<script>
import baseDialog from "../components/base-dialog.vue";
import baseForm from "../components/base-form.vue";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { update, getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { getNhanVien, getKhoa } from "@/api/phieu-kham-benh-vao-vien";
import { show } from "@/api/to-dieu-tri";
export default {
  components: { baseDialog, baseForm },
  props: {
    idba: {
      type: String,
    },
  },
  data: (vm) => ({
    formatDatetime,
    show: false,
    loading: false,
    form: {
      sttKhoa: null,
      ngayYLenh: null,
      bsDieuTri: null,
    },
    tempt: {},
    error: {},
    isCreate: false,
  }),
  computed: {
    title() {
      return this.isCreate ? "Thêm mới tờ điều trị" : "Cập nhật tờ điều trị";
    },
  },
  methods: {
    async getDetail(idba, stt) {
      const { data } = await show(idba, stt);
      this.form = Object.assign(this.form, data);
    },
    async getSelectKhoa(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
    async getDanhDSNhanVien(params) {
      return await getNhanVien(params);
    },
    async open(item) {
      this.tempt = { ...item };
      this.form = Object.assign(this.form, { ...item });
      this.form.sttKhoa = item.sttkhoa;
      this.form.bsDieuTri = item.bsdieuTri.maNv;
      this.form.ngayYLenh = item.ngayYLenh;

      delete this.form.bsdieuTri;
      delete this.form.khoaDieuTri;
      delete this.form.sttkhoa;
      delete this.form.nguoiHuy;
      delete this.form.nguoiLap;
      delete this.form.nguoiSd;

      await this.getDetail(item.idba, item.stt);
      this.isCreate = false;
      this.show = true;
    },
    fileChange(file) {
      this.form.file = file;
    },
    close() {
      this.show = false;
      this.loading = false;
      this.tempt = {};
      this.form = this.$options.data.call(this).form;
      this.error = {};
    },
    async onSubmit() {
      this.error = {};
      try {
        this.loading = true;
        delete this.form.bsdieuTri;
        delete this.form.khoaDieuTri;
        delete this.form.sttkhoa;
        delete this.form.nguoiHuy;
        delete this.form.nguoiLap;
        delete this.form.nguoiSd;
        const res = await update(this.tempt.idba, this.tempt.stt, this.form);
        if (res.statusCode == 200 && !res.error) {
          this.$message.success("Cập nhật tờ điều trị thành công !");
          this.close();
          this.$emit("reload");
        } else if (
          res &&
          res.error &&
          res.error.response &&
          res.error.response.status == 422
        ) {
          this.$message.error("Lỗi : " + res.error);
        }
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>

<style scoped>
.div {
  padding-bottom: 5px !important;
  font-weight: bold !important;
}
</style>
