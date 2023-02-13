<template>
  <el-dialog :visible.sync="dialog" width="1050px">
    <template slot="title">
      <div class="px-3">
        <div style="font-size: 16px; font-weight: bold" class="mb-3">
          Thông tin tai biến phẫu thuật thủ thuật
        </div>
        <v-progress-linear
          color="primary"
          rounded
          value="100"
          height="2"
        ></v-progress-linear>
      </div>
    </template>
    <form-option
      :create="true"
      :dataForm="data"
      :fields="fields"
      :actions="actions"
      :idba="idba"
      @create="handleCreate"
    >
    </form-option>
  </el-dialog>
</template>
<script>
import dialogMixin from "@/mixins/crud/dialog";
import formOption from "./components/formOptions";
import * as ApiPhacDo from "@/api/phac-do-dieu-tri.js";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { formatDatetime } from "@/utils/formatters";
import * as ApiTaiBien from "@/api/tai-bien.js";
export default {
  mixins: [dialogMixin],
  components: {
    formOption,
  },
  data(vm) {
    return {
      idba: window.location.href.split("/").at(-1),
      data: {},
      fields: [
      {
          label: "Khoa",
          type: "select-async",
          fromValue: "sttkhoa",
          placeholder: "Chọn khoa",
          action: true,
          keyValue: "stt",
          apiFunc: vm.getBenhAnKhoaDieuTris,
          labelselect: (item) =>
            `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
              item.ngayVaoKhoa
            )}`,
          value: "Sttkhoa",
        },
        {
          label: "Tên bác sỹ điều trị",
          type: "text",
          fromValue: "bsdieuTri.hoTen",
          placeholder: "Tên bác sỹ điều trị",
          action: false,
          value: "bsDieuTri",
        },
        {
          label: "Mã bệnh",
          type: "select-async",
          fromValue: "benhTat.maBenh",
          placeholder: "Mã bệnh",
          keyValue: "maBenh",
          apiFunc: ApiPhacDo.dsBenhs,
          labelselect: (item) => `${item.maBenh}-${item.tenBenh}`,
          action: true,
          value: "maBenh",
        },
        {
          label: "Tên bệnh",
          type: "textarea",
          fromValue: "benhTat.tenBenh",
          placeholder: "Nhập tên bệnh",
          action: true,
          value: "tenBenh",
        },
        {
          label: "Loại tai biến",
          type: "select",
          placeholder: "Loại tai biến",
          action: true,
          fromValue: "loai",
          value: "loai",
          category: [
            {
              text: "Thuốc",
              value: 1,
            },
            {
              text: "Thủ thuật",
              value: 2,
            },
            {
              text: "Phẫu thuật",
              value: 3,
            },
          ],
        },
        {
          label: "Ngày thực hiện",
          type: "date",
          fromValue: "ngayThucHien",
          placeholder: "Ngày thực hiện",
          action: true,
          value: "ngayThucHien",
        },
        {
          label: "Ngày tai biến",
          type: "date",
          fromValue: "ngayTaiBien",
          placeholder: "Ngày tai biến",
          action: true,
          value: "ngayTaiBien",
        },
        {
          label: "Nguyên nhân tai biến",
          type: "textarea",
          fromValue: "nguyenNhanTaiBien",
          placeholder: "Nguyên nhân tai biến",
          action: true,
          value: "nguyenNhanTaiBien",
        },
        {
          label: "Tình trạng người bệnh ",
          type: "text",
          fromValue: "tinhTrang",
          placeholder: "Tình trạng người bệnh ",
          action: true,
          value: "tinhTrang",
        },
        {
          label: "Xử trí",
          type: "text",
          fromValue: "xuTri",
          placeholder: "Xử trí",
          action: true,
          value: "xuTri",
        },
        {
          label: "Tình trạng sau xử trí",
          type: "text",
          fromValue: "ketQua",
          placeholder: "Tình trạng sau xử trí",
          action: true,
          value: "ketQua",
        },
      ],
      actions: [
        {
          title: "Thêm mới",
          type: "primary",
          event: "create",
          icon: "mdi-plus",
          action: true,
        },
      ],
      isLoading: false,
    };
  },
  watch: {},
  methods: {
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
        ...params,
      });
    },

    async handleCreate(data) {
      const { statusCode } = await ApiTaiBien.store({
        idba: this.idba,
        huy: false,
        ...data,
      });
      if (statusCode == 200) {
        this.dialog = false;
        this.$emit("reload");
        this.data = {};
        this.$message.success(`Thêm mới phác đồ điều trị thành công !`);
      } else {
        this.$message.error(`Thêm mới phác đồ điều trị lỗi !`);
      }
    },
  },
};
</script>
<style></style>
