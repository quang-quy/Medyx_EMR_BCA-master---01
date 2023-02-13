<template>
  <div class="pt-4">
    <div style="font-size: 16px; font-weight: bold" class="mb-3 mt-4">
      C. ĐIỀU TRỊ
    </div>
    <el-form>
      <v-row>
        <v-col cols="12" class="padding-cols mt-2 mb-1">
          <label>I. Y HỌC CỔ TRUYỀN</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="1. Pháp điều trị">
            <el-input v-model="form.ppdtyhct" size="small"></el-input>
          </el-form-item>
        </v-col>

        <v-col cols="12" class="padding-cols mt-3 mb-1">
          <label>2. Phương</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Phương dược:">
            <el-input v-model="form.phuongDuoc" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Phương pháp điều trị không dùng thuốc:">
            <el-input type="textarea" rows="3" v-model="form.ppdtkhongDungThuoc"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Các phương pháp khác:">
            <el-input type="textarea" rows="3" v-model="form.ppkhac"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-4 pt-2 mb-1">
          <label>II. Y HỌC HIỆN ĐẠI: Hướng điều trị</label>
          <i class="ml-2"
            >(Phương pháp điều trị, chế độ dinh dưỡng, chế độ chăm sóc,...)</i
          >
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-input v-model="form.huongDtyhhd" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-4 pt-2 mb-1">
          <label>III. DỰ HẬU (TIÊN LƯỢNG)</label>
        </v-col>

        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-input v-model="form.tienLuong" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày giờ khám bệnh">
            <el-date-picker
              v-model="form.ngayKham"
              style="width: 100%"
              type="datetime"
              size="small"
              format="dd/mm/yyyy HH:mm"
              value-format="yyyy-MM-ddTHH:mm:ss"
              placeholder="dd/mm/yyyy HH:mm"
            ></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thầy thuốc khám bệnh chữa bệnh">
            <base-select-async v-model="form.bskham" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Trạng thái">
            <el-select style="width: 100%" size="small" v-model="form.trangThai">
              <el-option
                v-for="(item, index) in trangThai"
                :key="index"
                :value="item"
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
import { getKhamYhct, getKhamYhhd } from "@/api/benh-an.js";
export default {
  data: () => ({
    trangThai: ["Đã kí", "Chưa kí"],
    form:{
      phuongDuoc:null,
      ppdtkhongDungThuoc:null,
      ppdtyhct:null,
      ppkhac:null,
      bskham:null,
      trangThai:null,
      huongDtyhhd:null,
      tienLuong:null,
      ngayKham:null,
    }
  }),
  mounted() {
    this.getData();
  },
  watch: {
    form: {
      handler(val) {
        this.$emit('get-phanC', val)
      },
      deep: true
    },
  },
  methods:{
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getKhamYhct(id)
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
      data = await getKhamYhhd(id);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
    }
  }
};
</script>

<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
