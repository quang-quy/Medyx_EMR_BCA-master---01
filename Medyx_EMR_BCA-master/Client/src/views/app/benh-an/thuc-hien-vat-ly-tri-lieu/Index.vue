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
    title="Thực hiện vật lý trị liệu"
    :permission="permission"
    :dialogComponent="dialogComponent"
    :headerComponent="headerComponent"
  >
  </Crud>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, destroy } from "@/api/dot-dieu-tri-vltl";
import { formatDate, formatDatetime } from "@/utils/formatters";
import dialog from "./dialog.vue";
import IndexHeader from "./IndexHeader.vue";
export default {
  components: {
    Crud,
    dialog,
  },
  props: {
    id: {
      type: [Number, Array],
      required: true,
    },
    permission: {
      type: Array,
      required: true,
    },
  },
  methods: {},

  data(vm) {
    return {
      dialogComponent: dialog,
      headerComponent: IndexHeader,
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      fields: [
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "khoaDieuTri",
          showable: true,
          filterable: false,
          filterValue: "khoaDieuTri",
          type: "text",
          sortable: true,
          align: "center",
          width: 200,
          form: {
            type: "custom",
            creatable: true,
            default: null,
            value: "khoa",
            fromValue: "khoa",
          },
        },
        {
          text: "Ngày vào điều trị",
          type: "date",
          showable: true,
          filterable: false,
          value: "ngayVaoDieuTri",
          searchValue: "ngayVaoDieuTri",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
          form: {
            type: "custom",
            creatable: true,
            default: null,
            value: "ngayVaoDieuTri",
            fromValue: "ngayVaoDieuTri",
          },
        },
        {
          text: "Bác sỹ điều trị",
          type: "text",
          showable: true,
          filterable: false,
          value: "bsdieuTri.maNv",
          searchValue: "bsdieuTri",
          filterValue: "bsdieuTri",
          width: 200,
          sortable: true,
          form: {
            type: "custom",
            value: "bsdieuTri",
            fromValue: "bsdieuTri.maNv",
            default: 0,
            creatable: true,
            editable: true,
          },
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
        "detail:/HSBADS/ChiTietThucHienVatLyTriLieu/:idba/chi-tiet/:stt",
      ],
      disableActions: {
        edit: (item) => item.huy && !vm.currentUser.is_admin,
        delete: (item) => item.huy,
      },
    };
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return index({ ...params, idba: this.id });
          } else {
            return index({ ...params, idba: this.id, huy: false });
          }
        },
        destroy: (...item) => destroy(...item),
      };
    },
  },
};
</script>
