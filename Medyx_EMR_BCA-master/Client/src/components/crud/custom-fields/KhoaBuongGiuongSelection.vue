<template>
  <Fragment>
    <el-form-item prop="maKhoa" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-maKhoa`
            : `${crudId}-creating-maKhoa`
        "
      >
        <base-select-async
          v-model="form.maKhoa"
          :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`"
          keyValue="maKhoa"
          :apiFunc="getKhoa"
          placeholder="Khoa"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="maBuong" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-maBuong`
            : `${crudId}-creating-maBuong`
        "
      >
        <el-select
          style="width: 100%"
          v-model="form.maBuong"
          placeholder="Buồng"
          size="mini"
        >
          <el-option
            v-for="item in buong"
            :key="item.maBuong"
            :label="item.tenBuong"
            :value="item.maBuong"
          >
          </el-option>
        </el-select>
      </portal>
    </el-form-item>
    <el-form-item prop="maGiuong" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-maGiuong`
            : `${crudId}-creating-maGiuong`
        "
      >
        <el-select
          style="width: 100%"
          v-model="form.maGiuong"
          placeholder="Giường"
          size="mini"
        >
          <el-option
            v-for="item in giuong"
            :key="item.maGiuong"
            :label="item.tenGiuong"
            :value="item.maGiuong"
          >
          </el-option>
        </el-select>
      </portal>
    </el-form-item>
    <!-- <el-form-item prop="bsdieuTri" :style="{ 'margin-bottom': 0 }">
      <portal
        :to="
          isEditForm
            ? `editing-${this.currentEditingRowId}-bsdieuTri`
            : 'creating-bsdieuTri'
        "
      >
        <el-select
          style="width: 100%"
          v-model="form.bsdieuTri"
          placeholder="Bác sĩ"
          size="mini"
        >
          <el-option
            v-for="item in dsBs"
            :key="item.maNv"
            :label="item.hoTen"
            :value="item.maNv"
          >
          </el-option>
        </el-select>
      </portal>
    </el-form-item> -->
  </Fragment>
</template>

<script>
import { index as getKhoa } from "@/api/khoa";
import { index as getBuong } from "@/api/khoa-buong";
import { index as getGiuong } from "@/api/khoa-giuong";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  props: {
    form: Object,
    crudId: String,
    currentEditingRowId: String,
    isEditForm: {
      type: Boolean,
      default: false,
    },
  },

  data() {
    return {
      khoa: [],
      buong: [],
      giuong: [],
      dsBs: [],
    };
  },
  watch: {
    "form.maKhoa"(_, oldVal) {
      if (oldVal !== null) this.form.maBuong = null;
      this.getBuong();
      this.getDsNv();
    },
    "form.maBuong"(_, oldVal) {
      if (oldVal !== null) {
        this.form.maGiuong = null;
        // this.form.bsdieuTri = null;
      }
      this.getGiuong();
    },
    currentEditingRowId() {
      this.getBuong();
      this.getDsNv();
      this.getGiuong();
    },
  },
  methods: {
    async getKhoa(params) {
      return await getKhoa({
        ...params,
      });
    },
    async getDsNv() {
      const { data } = await getNhanVien({
        MaKhoa: this.form.maKhoa,
      });
      this.dsBs = data;
    },
    async getBuong() {
      if (!this.form.maKhoa) return (this.buong = []);
      const { data } = await getBuong({
        MaKhoa: this.form.maKhoa,
      });
      this.buong = data;
    },
    async getGiuong() {
      if (!this.form.maBuong) return (this.giuong = []);
      const { data } = await getGiuong({
        MaKhoa: this.form.maKhoa,
        MaBuong: this.form.maBuong,
      });
      this.giuong = data;
    },
  },
  created() {
    this.getKhoa();
  },
};
</script>
