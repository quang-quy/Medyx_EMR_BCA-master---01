<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="idba.stt"
    label-width="100px"
    tableHeight="calc(100vh - 400px)"
    :headerComponent="headerComponent"
    :permission="permission"
    :wrapper="false"
    ref="table"
    :title="title"
    @clickFile="handleClickFile"
    :paramHeader="{
      ...item,
      idba,
    }"
  >
  </Crud>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";
import Crud from "@/components/crud/Index.vue";
import { getNhanVien } from "@/api/to-dieu-tri";
import * as api from "@/api/tap-tin-dinh-kem";
import Header from "./Header.vue";
export default {
  components: {
    Crud,
  },
  props: {
    title: {
      type: String,
      default: "Danh sách dịch vụ",
    },
    item: {
      type: Object,
      default: () => {},
    },
    idba: {
      type: [Number, String],
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  watch: {
    item: {
      handler: function (neVal) {
        this.$refs.table.reset();
      },
      deep: true,
    },
    idba(newVal) {
      this.$refs.table.reset();
    },
  },
  data: (vm) => ({
    headerComponent: Header,
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    fields: [
      {
        text: "File đính kèm",
        type: "file",
        sortable: false,
        showable: true,
        filterable: false,
        width: 350,
        value: "ten",
      },
      {
        text: "STTDV",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "sttdv",
        searchValue: "sttdv",
        width: 120,
        align: "center",
      },
      {
        text: "Khoa",
        value: "dichVu.khoaDieuTri.tenKhoa",
        searchValue: "khoaDieuTri",
        showable: true,
        filterable: false,
        filterValue: "khoaDieuTri",
        type: "text",
        width: 150,
        sortable: true,
        align: "center",
      },
      {
        text: "Ngày chỉ định",
        type: "date",
        showable: true,
        filterable: false,
        value: "dichVu.ngayChiDinh",
        searchValue: "ngayChiDinh",
        filterValue: "ngayChiDinh",
        formatter: function (_, __, value) {
          return formatDate(value);
        },
        width: 170,
        sortable: true,
      },
      {
        text: "Tên dịch vụ",
        value: "dichVu.tenDichVu",
        searchValue: "tenDichVu",
        showable: true,
        filterable: false,
        filterValue: "tenDichVu",
        type: "text",
        width: 350,
        sortable: true,
      },
      {
        text: "Bác sỹ chỉ định",
        value: "dichVu.bsChiDinh.hoTen",
        searchValue: "bsChiDinh",
        showable: true,
        filterable: false,
        filterValue: "bsChiDinh",
        type: "text",
        width: 200,
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
    apiCategoryFunctions: {},
    actions: ["delete"],
    disableActions: {
      edit: (item) => item.huy && !vm.currentUser.is_admin,
      delete: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/delete"
        ),
    },
  }),
  methods: {
    handleClickFile(data) {
      window.open(`${window.origin}/${data.link}`, "_blank");
      return;
    },
  },
  computed: {
    apiCrudFunctions() {
      const vm = this;
      return {
        index: (params) => {
          if (vm.currentUser.is_admin) {
            return api.indexDV({
              ...params,
              loaiTaiLieu: this.item.maLoaiTaiLieu,
              idba: this.idba,
            });
          } else {
            return api.indexDV({
              ...params,
              loaiTaiLieu: this.item.maLoaiTaiLieu,
              idba: this.idba,
              huy: false,
            });
          }
        },
        destroy: (...item) => api.detroyFile(...item),
      };
    },
  },
};
</script>
