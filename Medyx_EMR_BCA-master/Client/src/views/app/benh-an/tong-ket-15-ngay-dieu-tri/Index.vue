<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :disableActions="disableActions"
    :actions="actions"
    :dialogComponent="dialogComponent"
    :permission="permission"
    primaryKey="stt"
    label-width="100px"
    tableHeight="calc(100vh - 450px)"
    title="Sơ kết 15 ngày điều trị"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import Header from "./Header.vue";
import { index, destroy, print } from "@/api/tong-ket-15-ngay";
import { formatDate } from "@/utils/formatters";
import dialog from "./dialog.vue";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";

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
  data(vm) {
    return {
      // headerComponent: Header,
      dialogComponent: dialog,
      fields: [
        {
          text: "STT",
          value: "stt",
          showable: true,
          // sortable: true,
          type: "text",
          width: 50,
        },
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "khoaDieuTri",
          showable: true,
          filterable: false,
          filterValue: "khoaDieuTri",
          type: "text",
          width: 150,
        },
        {
          text: "Từ ngày",
          // sortable: true,
          showable: true,
          value: "tuNgay",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
        },
        {
          text: "Đến ngày",
          // sortable: true,
          showable: true,
          value: "denNgay",

          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
        },
        {
          text: "Bác sĩ điều trị",
          value: "bsdieuTri.hoTen",
          // searchValue: "bsdieuTri",
          showable: true,
          filterable: false,
          // filterValue: "bsdieuTri",
          type: "text",
          width: 150,
          sortable: true,
        },
        {
          text: "Ngày lập",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngayLap",
          // searchValue: "ngayLap",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
          form: {
            value: "ngayLap",
            fromValue: "ngayLap",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Người lập",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiLap.hoTen",
          // searchValue: "nguoiLap",
          // filterValue: "nguoiLap",
          width: 150,
          sortable: true,
          form: {
            value: "nguoiLap",
            fromValue: "nguoiLap.hoTen",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Ngày sửa",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngaySd",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
        },
        {
          text: "Người sửa",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiSd.hoTen",
          width: 150,
          sortable: true,
        },
        {
          text: "Hủy",
          type: "text",
          showable: true,
          filterable: false,
          value: "huy",
          searchValue: "huy",
          width: 100,
          type: "boolean",
          align: "center",
          sortable: true,
        },
        {
          text: "Ngày hủy",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngayHuy",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
        },
        {
          text: "Người hủy",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiHuy.hoTen",
          width: 150,
          sortable: true,
        },
      ],
      apiCategoryFunctions: {},
      actions: ["delete", "edit:dialog", "create:dialog", "print"],
      disableActions: {
        delete: (item) => item.huy,
      },
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
    };
  },
  computed: {
    apiCrudFunctions() {
      const vm = this
      return {
        index: (params) => index(this.id, params),
        destroy: (...item) => destroy(this.id, ...item),
        print: (...item) => print(vm.id ,...item),
      };
    },
  },
};
</script>
