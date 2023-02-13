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
    :customFormFields="customFormFields"
  >
  </Crud>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";

import {
  index,
  update,
  store,
  destroy,
  ds_thuocTayY,
} from "@/api/benhAnToDieuTri/thuoc-tay-y";

import Crud from "@/components/crud/Index.vue";
import layoutOption from "../components/layout-option.vue";
import { getNhanVien } from "@/api/to-dieu-tri";
import thuocTayYSelection from "../selections/thuocTayYSelection.vue";
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
  mounted() {
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
    customFormFields: thuocTayYSelection,
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
        text: "Mã thuốc",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.maThuoc",
        searchValue: "maThuoc",
        width: 120,
        align: "center",
      },
      {
        text: "Tên thuốc",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.tenTm",
        searchValue: "tenTm",
        width: 250,
        align: "center",
        form: {
          value: "maThuoc",
          fromValue: "thuoc.maThuoc",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Hàm lượng",
        value: "thuoc.hamLuong",
        searchValue: "hamLuong",
        showable: true,
        filterable: false,
        filterValue: "thuoc.hamLuong",
        type: "text",
        width: 300,
        sortable: true,
        form: {
          value: "hamLuong",
          fromValue: "thuoc.hamLuong",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Đơn vị tính",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.donViTinh.tenDvt",
        searchValue: "donViTinh",
        width: 120,
        align: "center",
        form: {
          value: "donViTinh",
          fromValue: "thuoc.donViTinh.tenDvt",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Đường dùng",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "thuoc.thuocDuongDung.tenDuongDung",
        searchValue: "duongDung",
        width: 200,
        align: "center",
        form: {
          value: "thuocDuongDung",
          fromValue: "thuoc.thuocDuongDung.tenDuongDung",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
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
          default: 1,
          type: "number",
          creatable: true,
          editable: true,
          rules: [
            {
              validator: (v) => v !== null && v !== undefined,
              message: "Trường này bắt buộc nhập",
            },
            {
              validator: (v) => v > 0,
              message: "Trường này bắt buộc lớn hơn 0",
            },
          ],
        },
      },
      {
        text: "Liều dùng",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "lieudung",
        searchValue: "lieudung",
        width: 200,
        align: "center",
        form: {
          value: "lieudung",
          fromValue: "lieudung",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Cách dùng",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "cachDung",
        searchValue: "cachDung",
        width: 300,
        align: "center",
        form: {
          value: "cachDung",
          fromValue: "cachDung",
          default: null,
          type: "text",
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
        filterValue: "nguoiLap",
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
        type: "text",
        showable: true,
        filterable: false,
        value: "nguoiHuy.hoTen",
        searchValue: "nguoihuy",
        width: 170,
        sortable: true,
      },
    ],
    apiCategoryFunctions: {
      nhanViens: {
        func: getNhanVien,
        textField: "maNv",
        valueField: "maNv",
      },
    },
    actions: ["edit", "delete", "create"],
    disableActions: {
      edit: (item) =>
        item.huy && !vm.currentUser.is_admin ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/thuoctayy/modify"
        ),
      delete: (item) =>
        item.huy ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/thuoctayy/delete"
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
            sttKhoa: vm.dataDetail.sttkhoa,
            ngayYLenh: vm.dataDetail.ngayYLenh,
            ...data,
          }),
        update: (...data) => update(vm.params.idba, ...data),
        destroy: (...item) => destroy(vm.params.idba, ...item),
      };
    },
  },
};
</script>
