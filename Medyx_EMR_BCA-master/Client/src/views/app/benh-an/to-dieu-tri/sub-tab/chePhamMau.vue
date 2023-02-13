<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="stt"
    label-width="100px"
    tableHeight="400px"
    :wrapper="false"
    onlyTable
    :hasExit="false"
    ref="table"
    :title="title"
  >
  </Crud>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";
import {
  index,
  store,
  update,
  destroy,
  dsChePhamMaus,
} from "@/api/benhAnToDieuTri/che-pham-mau";
import Crud from "@/components/crud/Index.vue";
import layoutOption from "../components/layout-option.vue";
import { getNhanVien } from "@/api/to-dieu-tri";
export default {
  components: {
    Crud,
    layoutOption,
  },
  props: {
    title: {
      type: String,
      default: "Danh sách",
    },
    params: {
      type: Object,
      default: () => {},
    },
    dataDetail: {
      type: Object,
      default: () => {},
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  watch: {
    params: {
      handler: function (neVal) {
        this.$refs.table.reset();
      },
      deep: true,
    },
  },
  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    fields: [
      {
        text: "STT",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "stt",
        searchValue: "stt",
        width: 70,
        align: "center",
      },
      {
        text: "Mã chế phẩm máu",
        value: "chePhamMau.maDV",
        searchValue: "maCpM",
        showable: true,
        filterable: false,
        filterValue: "maCpM",
        type: "text",
        width: 200,
        sortable: true,
        align: "center",
      },
      {
        text: "Tên chế phẩm máu",
        value: "chePhamMau.tenDV",
        searchValue: "tenDV",
        showable: true,
        filterable: false,
        filterValue: "tenDV",
        type: "text",
        width: 200,
        sortable: true,
        form: {
          value: "maCPM",
          fromValue: "chePhamMau.maDV",
          default: null,
          creatable: true,
          editable: true,
          type: "select-async",
          label: (item) =>
            item.maCpmau + "-" + item.tenCpmau + "-" + item.tenDvt,
          keyValue: "maCpmau",
          apiFunc: dsChePhamMaus,
        },
      },
      {
        text: "Đơn vị tính",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "chePhamMau.donViTinh",
        searchValue: "chePhamMau.donViTinh",
        width: 120,
        align: "center",
      },
      {
        text: "Số lượng",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "soLuong",
        searchValue: "soLuong",
        width: 120,
        align: "center",
        form: {
          value: "soLuong",
          fromValue: "soLuong",
          default: null,
          type: "number",
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Nhóm máu",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "nhommau",
        searchValue: "nhommau",
        width: 120,
        align: "center",
        form: {
          value: "nhommau",
          fromValue: "nhommau",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
          placeholder: "nhóm máu",
        },
      },
      {
        text: "Nhóm rh",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "rh",
        searchValue: "rh",
        width: 120,
        align: "center",
        form: {
          value: "rh",
          fromValue: "rh",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
          placeholder: "nhóm rh",
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
        width: 170,
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
        width: 170,
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
        width: 170,
        sortable: true,
      },
      {
        text: "Người sửa",
        type: "text",
        showable: true,
        value: "nguoiSD.hoTen",
        searchValue: "nguoiSD",
        filterable: false,
        width: 170,
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
        form: {
          value: "huy",
          fromValue: "huy",
          default: null,
          type: "boolean",
          creatable: false,
          editable: true,
        },
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
        width: 170,
        sortable: true,
      },
      {
        text: "Người hủy",
        showable: true,
        filterable: false,
        value: "nguoiHuy.hoTen",
        searchValue: "nguoiHuy",
        type: "text",
        width: 170,
        sortable: true,
      },
    ],
    apiCategoryFunctions: {
      dsChePhamMaus: {
        func: dsChePhamMaus,
        textField: (item) => item.tenCpmau,
        valueField: "maNv",
      },
    },
    actions: ["edit", "delete", "create"],
    disableActions: {
      edit: (item) =>
        (item.huy && !vm.currentUser.is_admin) ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/chephammau/modify"
        ),
      delete: (item) =>
        item.huy ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/chephammau/delete"
        ),
    },
  }),
  methods: {},
  computed: {
    apiCrudFunctions() {
      const vm = this;
      return {
        index: (params) => {
          if (vm.currentUser.is_admin) {
            return index({...vm.params , ...params});
          } else {
            return index({ ...params,...vm.params, huy: false });
          }
        },
        store: (data) =>
          store({
            idba: vm.params.idba,
            ngayYLenh: vm.dataDetail.ngayYLenh,
            sttkhoa: vm.dataDetail.sttkhoa,
            ...data,
          }),
        update: (...data) => update(vm.params.idba, ...data),
        destroy: (...item) => destroy(vm.params.idba, ...item),
      };
    },
  },
};
</script>
