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
        <v-col cols="12" class="py-0">
          <el-button
            :disabled="!daLuuTru"
            type="success"
            @click="restore"
            size="medium"
            >Khôi phục</el-button
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
      window.location.reload();
    },
    async restore() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang khôi phục bệnh án",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      await khoiPhuc(this.id);
      window.location = "/HSBALT/Detail/" + this.id;
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
