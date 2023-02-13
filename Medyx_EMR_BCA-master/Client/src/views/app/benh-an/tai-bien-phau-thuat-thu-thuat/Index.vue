<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="idba.stt"
    label-width="100px"
    tableHeight="calc(100vh - 450px)"
    title="Thông tin tai biến phẫu thuật thủ thuật"
    :headerComponent="headerComponent"
    :dialogComponent="dialogComponent"
    :permission="permission"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, print, destroy } from "@/api/tai-bien";
import { formatDate } from "@/utils/formatters";
import Header from "./Header.vue";
import dialog from "./dialog";
export default {
  components: {
    Crud,
    dialog,
  },
  props: {
    id: {
      type: [Number, String],
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },

  data(vm) {
    return {
      dialogComponent: dialog,
      headerComponent: Header,
      fields: [
        {
          text: "STT",
          value: "stt",
          showable: true,
          sortable: true,
          type: "text",
          width: 100,
        },
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "khoa",
          showable: true,
          filterable: true,
          filterValue: "khoa",
          type: "text",
          width: 150,
          sortable: true,
        },
        {
          text: "Loại tai biến",
          value: "loai",
          searchValue: "loai",
          showable: true,
          filterable: true,
          filterValue: "loai",
          type: "text",
          width: 150,
          sortable: true,
          formatter: function (_, __, value) {
            return value == 1 ? "Thuốc" : 2 ? "Thủ thuật" : "Phẫu thuật";
          },
        },
        {
          text: "Ngày thực hiện",
          value: "ngayThucHien",
          searchValue: "ngayThucHien",
          filterable: true,
          sortable: true,
          showable: true,
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
        },
        {
          text: "Ngày tai biến",
          value: "ngayTaiBien",
          searchValue: "ngayTaiBien",
          filterable: true,
          sortable: true,
          showable: true,
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
        },

        {
          text: "Bác sỹ điều trị",
          value: "bsdieuTri.hoTen",
          searchValue: "bsDieuTri",
          showable: true,
          filterable: false,
          filterValue: "bsDieuTri",
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
          searchValue: "ngayLap",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
        },
        {
          text: "Người lập",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiLap.hoTen",
          searchValue: "nguoiLap",
          filterValue: "nguoiSua",
          width: 150,
          sortable: true,
        },
        {
          text: "Ngày sửa",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngaySd",
          searchValue: "ngaySd",
          filterValue: "ngaySua",
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
          value: "nguoiSD.hoTen",
          searchValue: "nguoiSD",
          filterable: false,
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
          searchValue: "ngayHuy",
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
          searchValue: "nguoiHuy",
          width: 150,
          sortable: true,
        },
      ],
      apiCategoryFunctions: {},
      actions: [
        "delete",
        "detail:/HSBADS/ChiTietTaiBienPhauThuThuat/:idba/chi-tiet/:stt",
      ],
      disableActions: {
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) =>
              e.ActionDetailsName == "/HSBA/ThongTinTaiBienPhauThuThuat/delete"
          ),
      },
    };
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => index({ idba: this.id, ...params }),
        destroy: (...data) => destroy(...data),
      };
    },
  },
};
</script>
