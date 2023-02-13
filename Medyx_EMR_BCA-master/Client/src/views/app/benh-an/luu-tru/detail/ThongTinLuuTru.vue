<template>
  <v-container fluid class="mb-4">
    <el-form
      size="medium"
      ref="form"
      :model="form"
      label-position="top"
      :rules="rules"
    >
      <v-row>
        <v-col cols="3" class="py-0">
          <el-form-item prop="soLuuTru" style="width: 100%">
            <el-input
              style="width: 100%"
              v-model="form.soLuuTru"
              placeholder="Số lưu trữ"
              :disabled="daLuuTru"
            ></el-input> </el-form-item
        ></v-col>

        <v-col cols="3" class="py-0">
          <el-form-item prop="nguoiLuuTru" style="width: 100%">
            <base-select-async
              v-model="form.nguoiLuuTru"
              placeholder="Người lưu trữ"
              keyValue="maNv"
              label="hoTen"
              :apiFunc="getNhanVien"
              style="width: 100%"
              size="medium"
              :disabled="daLuuTru"
            ></base-select-async> </el-form-item
        ></v-col>
        <v-col cols="3" class="py-0">
          <el-form-item prop="ngayLuuTru" style="width: 100%">
            <el-date-picker
              v-model="form.ngayLuuTru"
              type="date"
              placeholder="Ngày lưu trữ"
              style="width: 100%"
              :format="'dd/MM/yyyy'"
              :value-format="'yyyy-MM-dd'"
              :disabled="daLuuTru"
            >
            </el-date-picker> </el-form-item
        ></v-col>
        <v-col cols="12" class="py-0">
          <el-button
            @click="$emit('regenerate')"
            :disabled="daLuuTru"
            type="primary"
            size="medium"
            >Tạo lại bản in HSBA</el-button
          >
          <el-button
            type="success"
            :disabled="daLuuTru"
            @click="submitForm"
            size="medium"
            >Lưu trữ</el-button
          >
        </v-col>
      </v-row>
    </el-form>
  </v-container>
</template>

<script>
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import { getThongTinLuuTru, luuTru, khoiPhuc } from "@/api/luu-tru";
export default {
  props: ["id", "danhSachLoaiTaiLieu"],
  data() {
    return {
      getNhanVien,
      loading: null,
      daLuuTru: false,
      date: null,
      rules: {
        soLuuTru: [
          {
            required: true,
            message: "Trường này bắt buộc nhập",
            trigger: "blur",
          },
        ],

        nguoiLuuTru: [
          {
            required: true,
            message: "Trường này bắt buộc nhập",
            trigger: "blur",
          },
        ],
        ngayLuuTru: [
          {
            required: true,
            message: "Trường này bắt buộc nhập",
            trigger: "blur",
          },
        ],
      },
      form: {
        soLuuTru: "",
        xacNhanLuuTru: 1,
        nguoiLuuTru: null,
        ngayLuuTru: new Date().toLocaleDateString("en-CA"),
      },
    };
  },
  computed: {},
  methods: {
    async getThongTinLuuTru() {
      const { data } = await getThongTinLuuTru(this.id);
      if (!data) {
        this.daLuuTru = false;
        return;
      }
      console.log(data);
      for (const field in this.form) {
        this.form[field] = data[field];
      }
      console.log(this.form);
      this.daLuuTru = true;
    },

    validate() {
      return new Promise((resolve) => {
        this.$refs["form"].validate((valid) => {
          resolve(valid);
        });
      });
    },
    async submitForm() {
      const valid = await this.validate();
      if (!valid) return;
      this.loading = this.$loading({
        lock: true,
        text: "Đang lưu trữ bệnh án",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      await luuTru(this.id, this.form);
      window.location = "/HSBAPH/Detail/" + this.id;
    },
    async restore() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang khôi phục bệnh án",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      await khoiPhuc(this.id);
      window.location.reload();
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
  created() {
    this.getThongTinLuuTru();
  },
};
</script>
