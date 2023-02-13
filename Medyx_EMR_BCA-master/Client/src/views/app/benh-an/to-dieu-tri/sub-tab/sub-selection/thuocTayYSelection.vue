<template>
  <Fragment>
    <el-form-item prop="nguoiLap">
      <portal
        :to="
          isEditForm
            ? `editing-${this.currentEditingRowId}-nguoiLap`
            : 'creating-nguoiLap'
        "
      >
        <base-select-async
          v-model="form.nguoiLap"
          :label="
            (item) =>
              `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ''}`
          "
          keyValue="maNv"
          :apiFunc="getDsNv"
          placeholder="Người lập"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="nguoiSD">
      <portal
        :to="
          isEditForm
            ? `editing-${this.currentEditingRowId}-nguoiSD`
            : 'creating-nguoiSD'
        "
      >
        <base-select-async
          v-model="form.nguoiSD"
          :label="
            (item) =>
              `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ''}`
          "
          keyValue="maNv"
          :apiFunc="getDsNv"
          placeholder="Người sửa"
        >
        </base-select-async>
      </portal>
    </el-form-item>
    <el-form-item prop="nguoiHuy">
      <portal
        :to="
          isEditForm
            ? `editing-${this.currentEditingRowId}-nguoiHuy`
            : 'creating-nguoiHuy'
        "
      >
        <base-select-async
          v-model="form.nguoiHuy"
          :label="
            (item) =>
              `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ''}`
          "
          keyValue="maNv"
          :apiFunc="getDsNv"
          placeholder="Người xóa"
        >
        </base-select-async>
      </portal>
    </el-form-item>
  </Fragment>
</template>

<script>
import { index as getKhoa } from "@/api/khoa";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  props: {
    form: Object,
    currentEditingRowId: String,
    isEditForm: {
      type: Boolean,
      default: false,
    },
  },

  data() {
    return {};
  },
  watch: {
    currentEditingRowId() {
      this.getDsNv();
    },
  },
  methods: {
    // async getThuocs(params) {
    //   return await getNhanVien({
    //     ...params,
    //   });
    // },
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
