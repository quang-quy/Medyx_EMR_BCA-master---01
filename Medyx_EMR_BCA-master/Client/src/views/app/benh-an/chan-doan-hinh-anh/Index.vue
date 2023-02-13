<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :headerComponent="headerComponent"
    :disableActions="disableActions"
    :actions="actions"
    primaryKey="stt"
    label-width="100px"
    title="Chẩn đoán hình ảnh"
    tableHeight="calc(100vh - 400px)"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import Header from "./Header.vue";
import { index, print, destroy } from "@/api/benh-an-can-lam-san.js";
import { formatDate, formatDatetime } from "@/utils/formatters";
import dialog from "./dialog.vue";
export default {
  props: {
    id: {
      type: Number,
    },
    permission: { 
      type: Array,
      default: () => [],
    },
  },
  components: {
    Crud,
  },
  data: (vm) => ({
    headerComponent: Header,
    // dialogComponent: dialog,
    fields: [
      {
        text: "Số thứ tự",
        sortable: true,
        showable: true,
        type: "text",
        value: "stt",
        width: 150,
      },
      {
        text: "Khoa",
        value: "khoaDieuTri.khoa.tenKhoa",
        sortable: true,
        showable: true,
        filterable: true,
        type: "text",
        width: 120,
      },
      {
        text: "Ngày chỉ định",
        sortable: true,
        showable: true,
        value: "ngayYlenh",
        formatter: function (_, __, value) {
          return formatDatetime(value);
        },
        width: 150,
      },
      {
        text: "Tên dịch vụ",
        sortable: true,
        showable: true,
        value: "dichVu.tenDv",
        width: 400,
      },
      {
        text: "Bác sĩ chỉ định",
        sortable: true,
        showable: true,
        value: "bsChiDinh.hoTen",
        width: 150,
      },
      {
        text: "Hủy",
        sortable: true,
        showable: true,
        value: "huy",
        type: "boolean",
        align: "center",
        width: 70,
      },
      {
        text: "Ngày lập",
        sortable: true,
        showable: true,
        formatter: function (_, __, value) {
          return formatDate(value);
        },
        value: "ngayLap",
        width: 150,
      },
      {
        text: "Người lập",
        sortable: true,
        showable: true,
        value: "nguoiLap.hoTen",
        type: "text",
        width: 150,
      },
      {
        text: "Ngày sửa đổi",
        sortable: true,
        showable: true,
        value: "ngaySD",
        type: "text",
        width: 150,
      },
      {
        text: "Người sửa đổi",
        sortable: true,
        showable: true,
        value: "nguoiSD.hoTen",
        type: "text",
        width: 150,
      },
      {
        text: "Ngày Hủy",
        sortable: true,
        showable: true,
        value: "NgayHuy",
        formatter: function (_, __, value) {
          return formatDate(value);
        },
        type: "text",
        width: 150,
      },
      {
        text: "Người Hủy",
        sortable: true,
        showable: true,
        value: "nguoiHuy.hoTen",
        type: "text",
        width: 150,
      },
    ],

    apiCategoryFunctions: {},

    actions: ["delete","print", "detail:/HSBADS/ChiTietChanDoanHinhAnh/:idba/chi-tiet/:stt",],
    disableActions: {
      edit: (item) => item.huy && !vm.currentUser.is_admin || item.idhis,
      delete: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/chuandoanhindexhanh/delete"
        ) || item.idhis,
      print: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/ChuanDoanHinhAnh/export"
        ),
    },
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
  }),
  computed: {
    apiCrudFunctions() {
      const maChungLoai = 3;
      const loaiTaiLieu = 10
      return {
        index: (params) => index({ ...params, idba: this.id, MaChungLoai: maChungLoai }),
        print: (...item) => print(this.id, ...item, maChungLoai, loaiTaiLieu),
        destroy: (...item) => destroy(this.id ,...item ),
      };
    },
  },
};
</script>
<style></style>
