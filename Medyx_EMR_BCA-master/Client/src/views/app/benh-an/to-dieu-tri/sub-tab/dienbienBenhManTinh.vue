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

    <div class="mt-1 pa-2 ml-7">
      <el-form :model="form" :rules="rules" ref="ruleForm">
        <v-row>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="2"
            lg="2"
            xl="2"
            class="padding-cols"
          >
            <el-form-item label="1.1 Huyết áp" prop="huyetAp">
              <el-input size="small" v-model="form.huyetAp" placeholder="mHg">
              </el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="1.2 Nhịp thở (< 100 lần/phút)" prop="nhipTho">
              <el-input-number
                size="small"
                v-model="form.nhipTho"
                placeholder="lần/phút"
                style="width: 100%"
                type="number"
                :min="0"
                :max="100"
              >
              </el-input-number>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="1.3 Cân nặng (< 300kg)" prop="canNang">
              <el-input-number
                size="small"
                v-model="form.canNang"
                style="width: 100%"
                type="number"
                :min="0"
                :max="300"
              >
              </el-input-number>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="1.4 Chiều cao (< 300cm)" prop="chieuCao">
              <el-input-number
                size="small"
                v-model="form.chieuCao"
                style="width: 100%"
                type="number"
                :min="0"
                :max="300"
              >
              </el-input-number>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="1.5 BMI (kg/m2)">
              <el-input
                size="small"
                v-model="form.bmi"
                placeholder="kg/m2"
                disabled
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="5"
            lg="5"
            xl="5"
            class="padding-cols"
          >
            <el-form-item label="1.6 Triệu chứng">
              <el-input
                size="small"
                v-model="form.trieuChung"
                placeholder="Nhập triệu chứng bệnh ..."
                type="textarea"
                rows="2"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="1.7 Nhịp tim (< 200 lần/phút)" prop="nhipTim">
              <el-input-number
                size="small"
                v-model="form.nhipTim"
                placeholder="lần/phút"
                style="width: 100%"
                type="number"
                :min="0"
                :max="200"
              ></el-input-number>
            </el-form-item>
          </v-col>

          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="1.8 Kết quả xét nghiệm máu">
              <el-input
                size="small"
                v-model="form.kqxnmau"
                placeholder="Kết quả xét nghiệm máu..."
                type="textarea"
                rows="2"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="5"
            lg="5"
            xl="5"
            class="padding-cols"
          >
            <el-form-item label="1.9 Kết quả xét nghiệm nước tiểu">
              <el-input
                size="small"
                v-model="form.kqxnnuocTieu"
                placeholder="Kết quả xét nghiệm nước tiểu..."
                type="textarea"
                class="flex-grow-1"
                rows="2"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="1.10 Kết quả chẩn đoán hình ảnh">
              <el-input
                size="small"
                v-model="form.kqcdha"
                placeholder="Kết quả chẩn đoán hình ảnh ..."
                rows="2"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
          >
            <el-form-item label="1.11 Chỉ số đường huyết">
              <el-input
                size="small"
                v-model="form.csduongHuyet"
                placeholder="Nhập chỉ số đường huyết ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="1.12 Điều trị">
              <el-input
                size="small"
                v-model="form.dieuTri"
                placeholder="Nhập điều trị ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="1.13 Ngày hẹn khám lại">
              <el-date-picker
                v-model="form.ngayHenKhamLai"
                type="date"
                placeholder="VD : 01/10/2020"
                size="small"
                style="width: 100%"
                format="dd/MM/yyyy"
                value-format="yyyy-MM-ddTHH:mm:ss"
              />
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="1.14 Ngày hẹn xét nghiệm lại">
              <el-date-picker
                v-model="form.ngayHenXnlai"
                type="date"
                placeholder="VD : 01/10/2020"
                size="small"
                style="width: 100%"
                format="dd/MM/yyyy"
                value-format="yyyy-MM-ddTHH:mm:ss"
              />
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="4"
            lg="4"
            xl="4"
            class="padding-cols"
          >
            <el-form-item label="1.15 Nhịp tim đều">
              <br />
              <el-select
                v-model="form.nhipTimDeu"
                placeholder="Chọn"
                size="small"
                style="width: 80%"
              >
                <el-option
                  v-for="item in options"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"
                />
              </el-select>
            </el-form-item>
          </v-col>
          <v-col
            cols="12"
            xs="6"
            sm="6"
            md="3"
            lg="3"
            xl="3"
            class="padding-cols"
            v-if="currentUser && currentUser.is_admin"
          >
            <v-switch v-model="form.huy" label="1.16 Trạng thái hủy" inset />
          </v-col>
        </v-row>
        <div class="my-2">
          <div class="d-flex justify-end">
            <v-btn class="mr-2 text-none" color="purple" @click="canCel">
              <v-icon small left color="white">mdi-close-outline</v-icon>
              <span class="white--text">Bỏ qua</span>
            </v-btn>
            <v-btn
              class="mr-2 text-none"
              color="teal"
              @click="submit()"
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
      </el-form>
      <hr style="color: grey" class="mt-3" />
    </div>
    <coppyToDieuTri
      ref="coppyToDieuTri"
      :dataDetail="dataDetail"
      @reload="handleReset()"
      :params="params"
    />
  </div>
</template>

<script>
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
  },
  watch: {
    params: {
      handler: function (newVal) {
        Promise.all([this.getData()]);
      },
      deep: true,
    },
    "form.chieuCao": {
      handler: function (newVal) {
        if (newVal > 0) {
          this.form.bmi = (
            this.form.canNang / Math.pow(this.form.chieuCao / 100, 2)
          ).toFixed(2);
        } else {
          this.form.bmi = 0;
        }
      },
    },
    "form.canNang": {
      handler: function (newVal) {
        if (this.form.chieuCao > 0) {
          this.form.bmi = (
            this.form.canNang / Math.pow(this.form.chieuCao / 100, 2)
          ).toFixed(2);
        } else {
          this.form.bmi = 0;
        }
      },
    },
  },
  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    temptForm: null,
    form: {
      huyetAp: null,
      nhipTho: 0,
      canNang: 0,
      chieuCao: 0,
      bmi: 0,
      trieuChung: null,
      nhipTim: 0,
      kqxnmau: null,
      kqxnnuocTieu: null,
      kqcdha: null,
      csduongHuyet: null,
      dieuTri: null,
      ngayHenKhamLai: null,
      ngayHenXnlai: null,
      nhipTimDeu: false,
      huy: false,
    },
    loading: false,
    rules: {
      // nhipTho: [
      //   {
      //     message: "Nhịp thở phải lớn hơn 0 và nhỏ hơn 100",
      //     trigger: "blur",
      //     required: true,
      //   },
      // ],
      // canNang: [
      //   {
      //     min: 0,
      //     max: 300,
      //     message: "cân nặng phải lớn hơn 0 và nhỏ hơn 300",
      //     trigger: "blur",
      //   },
      // ],
      // chieuCao: [
      //   {
      //     min: 0,
      //     max: 300,
      //     message: "chiều cao phải lớn hơn 0 và nhỏ hơn 300",
      //     trigger: "blur",
      //   },
      // ],
      // nhipTim: [
      //   {
      //     min: 0,
      //     max: 200,
      //     message: "Nhịp tim phải lớn hơn 0 và nhỏ hơn 200",
      //     trigger: "blur",
      //   },
      // ],
    },
    options: [
      {
        value: 1,
        label: "Nhịp tim đều",
      },
      {
        value: 2,
        label: "Nhịp tim không đều",
      },
    ],
  }),
  methods: {
    async getData() {
      const response = await show(this.params.idba, this.dataDetail.stt);
      this.form = Object.assign(this.form, { ...response.data });
      this.temptForm = response.data;
    },
    canCel() {
      this.form = Object.assign(this.form, { ...this.temptForm });
    },
    submit() {
      this.$refs.ruleForm.validate((valid) => {
        if (valid) {
          this.createData();
        } else {
          return false;
        }
      });
    },
    async createData() {
      try {
        var data = this.form;
        delete data.benhNhan;
        delete data.bsdieuTri;
        delete data.khoaDieuTri;
        this.form.sttKhoa = this.dataDetail.sttkhoa;
        this.form.BsdieuTri = this.dataDetail.bsdieuTri.maNv;
        let resUpdate = await update(
          this.dataDetail.idba,
          this.dataDetail.stt,
          this.form
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
<style scoped>
.v-text-field {
  width: 200px;
}
</style>
