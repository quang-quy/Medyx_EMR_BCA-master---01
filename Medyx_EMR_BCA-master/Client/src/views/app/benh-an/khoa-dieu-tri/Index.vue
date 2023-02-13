<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :customFormFields="customFormFields"
    :disableActions="disableActions"
    primaryKey="stt"
    label-width="100px"
    tableHeight="calc(100vh - 450px)"
    title="Danh sách khoa điều trị"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { indexAdmin, index, store, update, destroy } from "@/api/khoa-dieu-tri";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getKhoa } from "@/api/benh-an";
import KhoaBuongGiuongSelection from "@/components/crud/custom-fields/KhoaBuongGiuongSelection";
import { dsBenhs } from "@/api/khoa-dieu-tri";
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
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    customFormFields: KhoaBuongGiuongSelection,
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
        text: "Ngày giờ vào khoa",
        type: "datetime",
        sortable: true,
        showable: true,
        filterable: false,
        value: "ngayVaoKhoa",
        searchValue: "ngayVaoKhoa",
        formatter: function (_, __, value) {
          return formatDatetime(value);
        },
        width: 250,
        form: {
          value: "ngayVaoKhoa",
          fromValue: "ngayVaoKhoa",
          default: null,
          placeholder: "Ngày giờ vào khoa",
          type: "datetime",
          creatable: true,
          editable: true,
          rules: [
            {
              validator: (v) => v !== null && v !== undefined,
              message: "bắt buộc nhập",
            },
          ],
        },
      },
      {
        text: "Tên khoa điều trị",
        value: "khoa.tenKhoa",
        searchValue: "tenKhoa",
        showable: true,
        filterable: false,
        filterValue: "KhoaDieuTri",
        type: "text",
        width: 150,
        sortable: true,
        form: {
          value: "maKhoa",
          fromValue: "khoa.maKhoa",
          default: null,
          type: "custom",
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Buồng",
        showable: true,
        value: "buong.maBuong",
        searchValue: "maBuong",
        filterValue: "buong",
        type: "text",
        filterable: false,
        width: 100,
        sortable: true,
        form: {
          value: "maBuong",
          fromValue: "buong.maBuong",
          default: null,
          type: "custom",
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Giường",
        showable: true,
        value: "giuong.maGiuong",
        searchValue: "maGiuong",
        filterValue: "giuong",
        type: "text",
        filterable: false,
        width: 110,
        sortable: true,
        form: {
          value: "maGiuong",
          fromValue: "giuong.maGiuong",
          default: null,
          type: "custom",
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Tên bác sỹ điều trị",
        filterable: false,
        showable: true,
        value: "bsdieuTri.hoTen",
        searchValue: "bsdieuTri",
        filterValue: "bsDieuTri",
        type: "text",
        width: 200,
        sortable: true,
        form: {
          value: "bsdieuTri",
          fromValue: "bsdieuTri.maNv",
          default: null,
          creatable: true,
          editable: true,
          type: "select-async",
          label: (item) =>
            item.maNv + "-" + item.hoTen + "-" + item.khoa.tenKhoa,
          keyValue: "maNv",
          apiFunc: getNhanVien,
        },
      },
      {
        text: "Bệnh chính",
        showable: true,
        filterable: false,
        value: "benhChinh.tenBenh",
        searchValue: "benhChinh",
        filterValue: "benhChinh",
        type: "text",
        width: 170,
        sortable: true,
        form: {
          value: "maBenhChinhVk",
          fromValue: "benhChinh.maBenh",
          default: null,
          type: "select-async",
          creatable: true,
          editable: true,
          label: (item) => `${item.maBenh}-${item.tenBenh}`,
          keyValue: "maBenh",
          apiFunc: dsBenhs,
        },
      },
      {
        text: "Bệnh kèm 1",
        showable: true,
        filterable: false,
        value: "benhKem1.tenBenh",
        searchValue: "benhKem1",
        filterValue: "benhKem1",
        type: "text",
        width: 170,
        sortable: true,
        form: {
          value: "maBenhKemVk1",
          fromValue: "benhKem1.maBenh",
          default: null,
          type: "select-async",
          creatable: true,
          editable: true,
          label: (item) => `${item.maBenh}-${item.tenBenh}`,
          keyValue: "maBenh",
          apiFunc: dsBenhs,
        },
      },
      {
        text: "Bệnh kèm 2",
        showable: true,
        filterable: false,
        value: "benhKem2.tenBenh",
        searchValue: "benhKem2",
        filterValue: "benhKem2",
        type: "text",
        width: 170,
        sortable: true,
        sortable: true,
        form: {
          value: "maBenhKemVk2",
          fromValue: "benhKem2.maBenh",
          default: null,
          type: "select-async",
          creatable: true,
          editable: true,
          label: (item) => `${item.maBenh}-${item.tenBenh}`,
          keyValue: "maBenh",
          apiFunc: dsBenhs,
        },
      },
      {
        text: "Bệnh kèm 3",
        showable: true,
        filterable: false,
        value: "benhKem3.tenBenh",
        searchValue: "benhKem3",
        filterValue: "benhKem3",
        type: "text",
        width: 170,
        sortable: true,
        sortable: true,
        form: {
          value: "maBenhKemVk3",
          fromValue: "benhKem3.maBenh",
          default: null,
          type: "select-async",
          creatable: true,
          editable: true,
          label: (item) => `${item.maBenh}-${item.tenBenh}`,
          keyValue: "maBenh",
          apiFunc: dsBenhs,
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
    apiCategoryFunctions: {
      dsBenhs: {
        func: dsBenhs,
        textField: "tenBenh",
        valueField: "mabenh",
      },
    },
    actions: ["edit", "delete", "create"],
    disableActions: {
      edit: (item) =>
        (item.huy && !vm.currentUser.is_admin) ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/khoadieutri/modify"
        ),
      delete: (item) =>
        item.huy ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/khoadieutri/delete"
        ),
    },
  }),
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return indexAdmin(this.id, params);
          } else {
            return index(this.id, params);
          }
        },
        store: (data) => store(this.id, data),
        update: (...data) => update(this.id, ...data),
        destroy: (...data) => destroy(this.id, ...data),
      };
    },
  },
};
</script>
