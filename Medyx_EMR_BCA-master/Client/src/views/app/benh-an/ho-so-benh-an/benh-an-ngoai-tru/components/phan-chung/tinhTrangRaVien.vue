<template>
  <div>
    <div style="font-size: 16px; font-weight: bold" class="mb-3">
      IV. TÌNH TRẠNG RA VIỆN
    </div>
    <el-form>
      <v-row>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Kết quả điều trị">
            <el-select v-model="form.kqdt" style="width: 100%" size="small">
              <el-option
                v-for="(item, index) in ketQuaDieuTri"
                :key="index"
                :value="item.ma"
                :label="item.ten"
              ></el-option>
            </el-select>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
export default {
  props: ["benhAn"],
  data: () => ({
    form: {
      kqdt: null,
    },
    ketQuaDieuTri: [
      {
        ma: "1",
        ten: "Khỏi",
      },
      {
        ma: "2",
        ten: "Đỡ",
      },
      {
        ma: "3",
        ten: "Không thay đổi",
      },
      {
        ma: "4",
        ten: "Nặng hơn",
      },
      {
        ma: "5",
        ten: "Tử Vong",
      },
    ],
  }),
  methods: {},
  watch: {
    benhAn: function (val) {
      for (let key in this.form) {
        this.form[key] = val[key];
      }
    },
    form: {
      handler(val) {
        this.$emit('get-tinhTrangRaVien', val)
      },
      deep: true
    }
  },
  mounted() {
    this.getNhanVien();
  },
  methods: {
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
  },
};
</script>

<style scoped>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
