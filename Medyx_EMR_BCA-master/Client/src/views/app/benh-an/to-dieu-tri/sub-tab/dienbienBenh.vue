<template>
  <div class="align-center pa-2 ml-1">
    <div class="d-flex justify-space-between">
      <div class="d-flex">
        <v-icon dark color="primary">mdi-table</v-icon>
        <div class="text-h6 ml-3 align-center">{{ title }}</div>
      </div>
      <el-button
        class="mr-2 text-none"
        @click="handlerCoppy"
        type="primary"
        dark
        :disabled="
          !permission.find(
            (e) => e.ActionDetailsName == '/HSBA/todieutri/create'
          )
        "
      >
        <v-icon small left color="white">mdi-content-copy</v-icon>
        Sao tờ điều trị
      </el-button>
    </div>
    <div class="mt-1 pa-2">
      <v-form ref="form" @submit="handleSave">
        <div class="body-2 my-2 font-weight-bold">1.1 Diễn biến bệnh</div>
        <el-input
          outlined
          rows="5"
          v-model="form.dienBienBenh"
          hide-details
          type="textarea"
          size="lager"
          ref="itemfirst"
          :autosize="{ minRows: 10, maxRows: 15 }"
          class="flex-grow-1"
          show-word-limit
          maxlength="5000"
        >
        </el-input>
        <div class="body-2 my-2 font-weight-bold">1.2 Y lệnh chăm sóc</div>
        <el-input
          outlined
          rows="7"
          v-model="form.ylenh"
          hide-details
          type="textarea"
          size="lager"
          :autosize="{ minRows: 10, maxRows: 15 }"
          class="flex-grow-1"
          show-word-limit
          maxlength="5000"
        >
        </el-input>
        <v-switch v-model="form.huy" label="Trạng thái hủy" hide-details inset>
        </v-switch>
        <div class="my-2">
          <div class="d-flex justify-end">
            <v-btn class="mr-2 text-none" color="purple" @click="canCel">
              <v-icon small left color="white">mdi-close-outline</v-icon>
              <span class="white--text">Bỏ qua</span>
            </v-btn>
            <v-btn
              class="mr-2 text-none"
              color="teal"
              @click="handleSave"
              :disabled="
                !permission.find(
                  (e) => e.ActionDetailsName == '/HSBA/todieutri/modify'
                )
              "
            >
              <v-icon small left color="white">mdi-book-plus</v-icon>
              <span class="white--text">Lưu</span>
            </v-btn>
          </div>
        </div>
      </v-form>
      <hr style="color: grey" class="mt-3" />
    </div>
    <coppyToDieuTri
      ref="coppyToDieuTri"
      :dataDetail="dataDetail"
      :params="params"
      @reload="handleReset()"
    />
  </div>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";
import { show } from "@/api/to-dieu-tri";
import { update } from "@/api/benhAnToDieuTri/dien-bien-benh";
import Crud from "@/components/crud/Index.vue";
import layoutOption from "../components/layout-option.vue";
import coppyToDieuTri from "../dialog/coppyToDieuTri.vue";
export default {
  components: {
    Crud,
    layoutOption,
    coppyToDieuTri,
  },
  props: {
    title: {
      type: String,
      default: "Danh sách",
    },
    dataDetail: {
      type: Object,
      default: () => {},
    },
    params: {
      type: Object,
      default: () => {},
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  mounted() {
    this.getData();
    setTimeout(() => {
      this.$refs.itemfirst.focus();
    }, 200);
  },
  watch: {
    params: {
      handler: function (newVal) {
        Promise.all([this.getData()]);
      },
      deep: true,
    },
  },
  data: (vm) => ({
    temptForm: {},
    form: {
      dienBienBenh: null,
      ylenh: null,
      huy: false,
    },
  }),
  methods: {
    async getData() {
      if (!this.params.idba || !this.dataDetail.stt) return;
      const response = await show(this.params.idba, this.dataDetail.stt);
      this.form = Object.assign(this.form, response.data);
      this.temptForm = this.form;
    },
    canCel() {
      this.form = Object.assign(this.form, { ...this.temptForm });
    },
    async handleSave() {
      this.$loader(true);
      let tempt = Object.assign({}, this.form);
      delete tempt.bsdieuTri;
      delete tempt.khoaDieuTri;
      delete tempt.benhNhan;
      tempt.bsDieuTri = this.form.bsdieuTri.maNv;
      tempt.khoaDieuTri = this.form.khoaDieuTri.maKhoa;
      tempt.sttKhoa = this.dataDetail.sttkhoa;
      try {
        let resUpdate = await update(
          this.dataDetail.idba,
          this.dataDetail.stt,
          tempt
        );
        if (resUpdate.statusCode == 200) {
          this.$emit("reset");
          this.$message.success("Cập nhật thành công");
        } else {
          this.$message.error("Cập nhật thất bại");
        }
      } catch (error) {
        this.$message.error("Lỗi : " + error);
      }
      this.$loader(false);
    },
    handlerCoppy() {
      this.$refs.coppyToDieuTri.open();
    },
    handleReset() {
      this.$emit("reset");
    },
  },
};
</script>
