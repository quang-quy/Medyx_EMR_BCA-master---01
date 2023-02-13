<template>
  <el-dialog :title="title" :visible.sync="show" width="650px" height="30%">
    <el-form @submit="onSubmit">
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
          ref="khoaSelect"
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
          size="small"
          value-format="yyyy-MM-ddTHH:mm:ss"
          format="dd/MM/yyyy HH:mm"
          style="width: 450px"
        >
        </el-date-picker>
      </div>
      <div class="d-flex py-1">
        <div class="body-2 font-weight-bold mr-auto mt-3">Trạng thái hủy</div>
        <v-switch v-model="form.Huy" inset></v-switch>
      </div>

      <div class="d-flex py-1">
        <div class="body-2 font-weight-bold mr-auto">Diễn biến</div>
        <el-input
          size="small"
          v-model="form.dienBienBenh"
          placeholder="Diễn biến bệnh"
          rows="4"
          type="textarea"
          style="width: 80%"
        ></el-input>
      </div>
      <div class="d-flex py-1">
        <div class="body-2 font-weight-bold mr-auto">Y lệnh</div>
        <el-input
          size="small"
          v-model="form.Ylenh"
          placeholder="Y lệnh chăm sóc"
          rows="4"
          type="textarea"
          style="width: 80%"
        ></el-input>
      </div>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <v-btn
        class="mr-2 text-none justify-end text-end"
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
import { store, getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { getNhanVien, getKhoa } from "@/api/phieu-kham-benh-vao-vien";
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
      idba: vm.idba,
      sttKhoa: null, //sttKhoa
      ngayYLenh: null,
      Huy: false,
      Ylenh: null,
      dienBienBenh: null,
      bsDieuTri: null,
    },
    error: {},
    isCreate: false,
  }),
  computed: {
    title() {
      return this.isCreate ? "Thêm mới tờ điều trị" : "Cập nhật tờ điều trị";
    },
  },
  methods: {
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
    open() {
      this.isCreate = true;
      this.show = true;
      this.$nextTick(() => {
        this.$refs.khoaSelect.focus();
      }, 100)
    },
    fileChange(file) {
      this.form.file = file;
    },
    close() {
      this.show = false;
      this.loading = false;
      this.form = {};
      this.error = {};
    },
    async onSubmit() {
      this.error = {};
      try {
        this.loading = true;
        this.form.idba = this.idba;
        const res = await store(this.form);
        if (res.statusCode == 200 && !res.error) {
          this.$message.success("Thêm mới tờ điều trị thành công !");
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
