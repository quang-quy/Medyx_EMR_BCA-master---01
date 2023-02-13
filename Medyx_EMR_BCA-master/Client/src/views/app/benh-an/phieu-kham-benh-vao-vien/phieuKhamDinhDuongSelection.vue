<template>
  <Fragment>
    <el-form-item prop="sttKhoa">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-sttKhoa`
            : `${crudId}-creating-sttKhoa`
        "
      >
        <base-select-async
          v-model="form.sttKhoa"
          :label="(item) => `${item.khoa.tenKhoa}`"
          keyValue="stt"
          :apiFunc="getKhoa"
          :defaultParams="{
            idba: idba,
          }"
          placeholder="Khoa điều trị"
        >
        </base-select-async>
      </portal>
    </el-form-item>

    <el-form-item prop="coSutCan">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-coSutCan`
            : `${crudId}-creating-coSutCan`
        "
      >
        <el-select v-model="form.coSutCan" class="m-2" size="small">
          <el-option
            v-for="(item, index) in dsCoSutCan"
            :key="`keys_${index}`"
            :label="`${item.text}`"
            :value="item.value"
          />
        </el-select>
      </portal>
    </el-form-item>
    <el-form-item prop="soCanBiSut">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-diemSutCan`
            : `${crudId}-creating-diemSutCan`
        "
      >
        <el-select v-model="form.diemSutCan" class="m-2" size="small">
          <el-option
            v-for="(item, index) in dsCanSut"
            :key="`keys_${index}`"
            :label="`${item.text} kg`"
            :value="item.value"
          />
        </el-select>
      </portal>
    </el-form-item>
    <el-form-item prop="chiSoTutCan">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-chiSoTutCan`
            : `${crudId}-creating-chiSoTutCan`
        "
      >
        <el-input size="select" v-model="form.chiSoTutCan" />
      </portal>
    </el-form-item>
    <el-form-item prop="Bsdieutri">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-Bsdieutri`
            : `${crudId}-creating-Bsdieutri`
        "
      >
        <base-select-async
          v-model="form.Bsdieutri"
          :label="
            (item) =>
              `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ''}`
          "
          keyValue="maNv"
          :apiFunc="getDsNv"
          placeholder="Bác sỹ"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="NguoiDg">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-NguoiDg`
            : `${crudId}-creating-NguoiDg`
        "
      >
        <base-select-async
          v-model="form.NguoiDg"
          :label="
            (item) =>
              `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ''}`
          "
          keyValue="maNv"
          :apiFunc="getDsDg"
          placeholder="Người đánh giá"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="chiSoSutCan">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-chiSoSutCan`
            : `${crudId}-creating-chiSoSutCan`
        "
      >
        <el-input v-model="form.chiSoSutCan" disabled size="small"> </el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="chiSoMst">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-chiSoMst`
            : `${crudId}-creating-chiSoMst`
        "
      >
        <el-input
          disabled
          v-model="form.chiSoMst"
          size="small"
          type="number"
          placeholder=""
        >
        </el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="DanhGiaTheoMst">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-DanhGiaTheoMst`
            : `${crudId}-creating-DanhGiaTheoMst`
        "
      >
        <el-input
          v-model="form.DanhGiaTheoMst"
          size="small"
          disabled
        ></el-input>
      </portal>
    </el-form-item>

    <el-form-item prop="canNang">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-canNang`
            : `${crudId}-creating-canNang`
        "
      >
        <el-input
          type="number"
          :min="0"
          :max="300"
          v-model="form.canNang"
          size="small"
        ></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="chieuCao">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-chieuCao`
            : `${crudId}-creating-chieuCao`
        "
      >
        <el-input
          type="number"
          :min="0"
          :max="300"
          v-model="form.chieuCao"
          size="small"
        ></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="diemNgonMieng">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-diemNgonMieng`
            : `${crudId}-creating-diemNgonMieng`
        "
      >
        <el-input v-model="form.diemNgonMieng" size="small" disabled></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="Bmi">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-Bmi`
            : `${crudId}-creating-Bmi`
        "
      >
        <el-input disabled v-model="form.Bmi" size="small"></el-input>
      </portal>
    </el-form-item>
    <el-form-item prop="anKem">
      <portal
        :to="
          isEditForm
            ? `${crudId}-editing-${this.currentEditingRowId}-anKem`
            : `${crudId}-creating-anKem`
        "
      >
        <el-select v-model="form.anKem" size="small">
          <el-option label="Không" :value="0" />
          <el-option label="Có" :value="1" />
        </el-select>
      </portal>
    </el-form-item>
  </Fragment>
</template>

<script>
import { index as getKhoa } from "@/api/khoa";
import * as ApiDd from "@/api/phieu-kham-dinh-duong";
import { getNhanVien, dsKhoaDieuTri } from "@/api/phieu-kham-benh-vao-vien";
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
      dsCanSut: [
        {
          text: "1-1.5",
          value: 1,
        },
        {
          text: "6-10",
          value: 2,
        },
        {
          text: "11-15",
          value: 3,
        },
        {
          text: ">15",
          value: 4,
        },
      ],
      dsCoSutCan: [
        {
          text: "Không sụt cân",
          value: 0,
        },
        {
          text: "Không rõ",
          value: 2,
        },
      ],
      idba: window.location.href.split("/").at(-1),
    };
  },
  watch: {
    currentEditingRowId() {},

    "form.diemNgonMieng"(newVal) {
      this.$set(this.form, "chiSoMst", newVal + this.form.chiSoSutCan);
    },
    "form.chiSoSutCan"(newVal) {
      this.$set(this.form, "chiSoMst", newVal + this.form.diemNgonMieng);
    },
    "form.anKem"(newVal) {
      this.$set(this.form, "diemNgonMieng", newVal);
    },
    "form.diemSutCan"(newVal) {
      if (this.form.diemSutCan) this.form.chiSoSutCan = this.form.diemSutCan;
    },
    "form.chiSoMst"(newVal) {
      this.form.chiSoMst <= 1
        ? this.$set(this.form, "DanhGiaTheoMst", "Không có nguy cơ")
        : this.$set(this.form, "DanhGiaTheoMst", "Có nguy cơ");
    },

    //BMi
    "form.canNang"(newVal) {
      this.form.Bmi =
        this.form.chieuCao && this.form.chieuCao * 1 > 0
          ? (newVal / Math.pow(newVal, 2)).toFixed(5)
          : 0;
    },
    "form.chieuCao"(newVal) {
      this.form.Bmi =
        newVal && newVal * 1 > 0
          ? (this.form.canNang / Math.pow(newVal, 2)).toFixed(5)
          : 0;
    },
  },
  methods: {
    async getKhoa(params) {
      return await ApiDd.dsKhoaDieuTri({
        ...params,
      });
    },
    async getDsNv(params) {
      return await getNhanVien({
        ...params,
      });
    },
    async getDsDg(params) {
      return await getNhanVien({
        ...params,
      });
    },
  },
};
</script>
