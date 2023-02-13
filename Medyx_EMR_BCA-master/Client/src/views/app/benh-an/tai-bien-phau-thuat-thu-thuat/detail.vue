<template>
  <app-wrapper :idba="id">
    <div class="pa-2">
      <div class="flex-grow-1 mb-2">
        <form-option
          :options="options"
          :fields="fields"
          :actions="actions"
          :dataForm="data"
          :idba="id"
          @print="handlePrint"
          @save="handleSave"
        ></form-option>
      </div>
    </div>
  </app-wrapper>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import formOption from "./components/formOptions.vue";
import { formatDatetime } from "@/utils/formatters";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import * as ApiPhacDo from "@/api/phac-do-dieu-tri.js";
import * as ApiTaiBien from "@/api/tai-bien.js";
export default {
  props: {
    id: {
      type: [Number, String],
      required: true,
    },
    stt: {
      type: [Number, String],
      required: true,
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    Crud,
    formOption,
  },
  data(vm) {
    return {
      options: {},
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
          action: false,
          value: "maBenh",
        },
        {
          label: "Tên bệnh",
          type: "textarea",
          fromValue: "benhTat.tenBenh",
          placeholder: "Nhập tên bệnh",
          action: false,
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
          type: "number",
          fromValue: "tinhTrang",
          placeholder: "Tình trạng người bệnh ",
          action: true,
          value: "tinhTrang",
        },
        {
          label: "Xử trí",
          type: "number",
          fromValue: "xuTri",
          placeholder: "Xử trí",
          action: true,
          value: "xuTri",
        },
        {
          label: "Tình trạng sau xử trí",
          type: "number",
          fromValue: "ketQua",
          placeholder: "Tình trạng sau xử trí",
          action: true,
          value: "ketQua",
        },
        {
          label: "Hủy",
          type: "boolean",
          fromValue: "huy",
          action: JSON.parse(localStorage.getItem("currentUser")).is_admin,
          value: "huy",
        },
      ],
      actions: [
        {
          title: "Lưu tai biến phẫu thủ thuật",
          type: "success",
          event: "save",
          icon: "mdi-pencil",
          action: vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/ThongTinTaiBienPhauThuThuat/modify"
          )
            ? true
            : false,
        },
        {
          title: "In tai biến phẫu thủ thuật",
          icon: "mdi-printer",
          type: "primary",
          event: "print",
          icon: "mdi-printer",
          action: vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/ThongTinTaiBienPhauThuThuat/export"
          )
            ? true
            : false,
        },
      ],
      data: {},
      edit: true,
    };
  },
  created() {
    this.getData();
  },
  methods: {
    async getData() {
      const { data } = await ApiTaiBien.show(this.id, this.stt);
      if (data) {
        this.data = data;
      } else {
        this.edit = false;
      }
    },
    async getNhanViens(params) {
      return await getNhanVien(params);
    },
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.id,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
    async handleSave(data) {
      const { statusCode } = await ApiTaiBien.update(this.id, this.stt, data);
      this.handleNotify(statusCode, "Cập nhật");
    },
    async handlePrint(data) {
      await ApiTaiBien.print(this.id, this.stt);
    },
    handleNotify(statusCode = true, action = null) {
      if (statusCode == 200) {
        this.getData();
        this.$message.success(`${action} thông tin tai biến phẫu thủ thuật thành công !`);
      } else {
        this.$message.error(`${action} thông tin tai biến phẫu thủ thuật lỗi !`);
      }
    },
  },
  computed: {},
};
</script>

<style lang="scss" scoped></style>
