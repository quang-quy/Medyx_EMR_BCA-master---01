<template>
  <el-dialog :title="title" :visible.sync="show" width="30%" height="30%">
    <el-form ref="form" @submit="onSubmit">
      <div class="d-flex py-1" v-if="params.maLoaiTaiLieu != 26">
        <div class="body-2 font-weight-bold mr-auto">Khoa điều trị</div>
        <base-select-async
          v-model="sttDv"
          
          :label="
            (item) =>
              `${formatDatetime(item.ngayChiDinh)} - ${item.tenDichVu}- ${
                item.bsChiDinh.hoTen
              }- ${item.khoaDieuTri.tenKhoa} `
          "
          keyValue="stt"
          :apiFunc="getLoaiDv"
          :defaultParams="{
            idba: params.idba,
            loaiTaiLieu: params.maLoaiTaiLieu,
            sortBy: 'ngayChiDinh',
            sortBy: 'stt',
          }"
        >
          <!-- - ${item.maDichVu} -->
        </base-select-async>
      </div>
      <div>
        <input type="file" @change="handleChangeFile($event)" accept=".jpg,.png,.svg,.pdf,.doc,.docx,.xlsx" name="file_name" id="file_form">
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
        Thêm mới
      </v-btn>
    </span>
  </el-dialog>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getNhanVien, getKhoa } from "@/api/phieu-kham-benh-vao-vien";
import * as api from "@/api/tap-tin-dinh-kem";
export default {
  props: {
    params: {
      type: Object,
      default: () => {},
      required: true
    },
  },
  data: (vm) => ({
    api,
    formatDatetime,
    show: false,
    loading: false,
    sttDv: null,
    file: null,
  }),
  computed: {
    title() {
      return "Thêm file";
    },
  },
  methods: {
    async getLoaiDv(params) {
      return await api.dmDvLoaiTl({...params});
    },
    async getDanhDSNhanVien() {
      return await getNhanVien();
    },
    open(item) {
      this.show = true;
    },
    fileChange(file) {
      this.form.file = file;
    },
    close() {
      this.show = false;
      this.loading = false;
    },
    async onSubmit() {
      if (!this.file) {
        return this.$message.error("Chưa chọn file đính kèm");
      }
      if (this.params.maLoaiTaiLieu != 26 && !this.sttDv) {
        return this.$message.error("Chưa chọn dịch vụ");
      }
      var formData = new FormData();
      formData.append("loaiTaiLieu", this.params.maLoaiTaiLieu);
      formData.append("idba", this.params.idba);
      if( this.params.maLoaiTaiLieu != 26){
        formData.append("sttDv",this.sttDv);
      }
      formData.append("file", this.file);
      try {
        const resUpload = await api.upLoadFile(formData);
        if (resUpload.statusCode == 200) {
          this.file= null
          this.sttDv= null
          this.$emit('reset')
          this.$message.success("Tải lên file thành công !");
          this.show = false
        } else {
          this.$message.error("Lỗi : " + resUpload.error);
        }
      } catch (error) {
        this.$message.error("Lỗi : " + error);
      }
    },
    handleChangeFile(e) {
      this.file = e.target.files[0]
    },
    handleRemove() {},
  },
};
</script>

<style scoped>
.div {
  padding-bottom: 5px !important;
  font-weight: bold !important;
}
::v-deep .el-upload__input {
  display: none !important;
}
::v-deep .el-dialog__body {
  padding-top: 0px !important;
}
</style>
