<template>
  <el-dialog :title="title" :visible.sync="show" width="25%" height="30%">
    <el-form ref="form" @submit="onSubmit">
      <div class="py-2 mb-2">
        <div class="py-1 d-flex">
          <div class="body-2 font-weight-bold mr-auto">Ngày muốn sao</div>
          <el-date-picker
            v-model="form.ngayYLenh"
            type="datetime"
            placeholder="Ngày muốn sao"
            size="small"
            style="width: 195px"
            required
            value-format="yyyy-MM-ddTHH:mm:ss"
            format="dd/MM/yyyy HH:mm:ss"
            ref="itemfirst"
          />
        </div>
        <div class="d-flex py-1">
          <div class="body-2 font-weight-bold mr-auto">Khoa điều trị</div>
          <base-select-async
            v-model="form.sttKhoa"
            :label="
              (item) =>
                `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
                  item.ngayLap
                )}`
            "
            keyValue="stt"
            :apiFunc="getSelectKhoa"
            required
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
            required
          >
          </base-select-async>
        </div>
      </div>
      <div class="d-flex py-1 flex-column">
        <div class="body-1 font-weight-bold mr-auto mb-3">
          Danh sách mục sao chép :
        </div>
        <div class="d-flex">
          <div>
            <el-checkbox
              v-model="form.hasDienBienBenh"
              label="1.Diễn biến"
              size="large"
            />
            <el-checkbox
              v-model="form.hasBenhAnThuocTayY"
              label="2.Thuốc tây y"
              size="large"
            />
            <el-checkbox
              v-model="form.hasBenhAnThuocYhct"
              label="3.Thuốc đông y"
              size="large"
            />
            <el-checkbox
              v-model="form.hasBenhAnTtvltl"
              label="4.Thủ thuật vật lý trị liệu"
              size="large"
            />
          </div>
          <div>
            <el-checkbox
              v-model="form.hasBenhAnCls"
              label="5.Bệnh án cận lâm sàng"
              size="large"
            />
            <el-checkbox
              v-model="form.hasBenhAnPhauThuat"
              label="6.Phẫu thủ thuật"
              size="large"
            />
            <el-checkbox
              v-model="form.hasBenhAnCpm"
              label="7.Chế phẩm máu"
              size="large"
            />
          </div>
        </div>
      </div>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <v-btn
        class="mr-2 text-none"
        color="primary"
        outlined
        @click="onSubmit"
        :disabled="loading"
      >
        <v-icon small left>mdi-book-plus</v-icon>
        Thực hiện
      </v-btn>
    </span>
  </el-dialog>
</template>

<script>
import baseDialog from "../components/base-dialog.vue";
import baseForm from "../components/base-form.vue";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getBenhAnKhoaDieuTri, saoToDieuTri } from "@/api/to-dieu-tri";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  components: { baseDialog, baseForm },
  props: {
    params: {
      type: Object,
      default: () => {},
    },
    dataDetail: {
      type: Object,
      default: () => {},
    },
  },
  data: (vm) => ({
    formatDatetime,
    show: false,
    loading: false,
    form: {
      ngayYLenh: null,
      sttKhoa: null,
      bsDieuTri: null,
      hasDienBienBenh: false, //
      hasBenhAnThuocTayY: false, //
      hasBenhAnThuocYhct: false, //
      hasBenhAnTtvltl: false, //
      canLamSan: false,
      hasBenhAnCls: false, //
      hasBenhAnPhauThuat: false, //
      hasBenhAnCpm: false, //
    },
    error: {},
    rules: {
      requred: [(v) => !!v || "Item is required"],
    },
  }),
  computed: {
    title() {
      return `Sao chép tờ điều trị ${formatDatetime(
        this.dataDetail.ngayYLenh
      )}`;
    },
  },
  methods: {
    async getSelectKhoa(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.dataDetail.idba,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
    async getDanhDSNhanVien(params) {
      return await getNhanVien(params);
    },
    open() {
      this.show = true;
      setTimeout(() => {
        this.$refs.itemfirst.$el.firstChild.focus();
      }, 200);
    },
    close() {
      this.show = false;
      this.loading = false;
      this.form = this.$options.data.call(this).form;
      this.error = {};
    },
    async onSubmit() {
      this.error = {};
      // if (!(await this.$refs.form.validate())) return;
      try {
        this.loading = true;
        this.form.idba = this.params.idba;
        this.form.ngaySaoChep = this.dataDetail.ngayYLenh;
        const res = await saoToDieuTri({ ...this.form });
        if (res && !res.error) {
          this.$message.success("Sao tờ điều trị thành công !");
          this.$emit("reload");
          this.close();
        }
        if (
          res &&
          res.error &&
          res.error.response &&
          res.error.response.status == 422
        ) {
          const { response } = res.error;
          this.error = response.data.errors;
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
