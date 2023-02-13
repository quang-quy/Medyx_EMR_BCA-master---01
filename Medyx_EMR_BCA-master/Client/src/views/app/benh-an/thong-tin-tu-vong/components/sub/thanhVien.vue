<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="stt"
    label-width="100px"
    tableHeight="250px"
    :wrapper="false"
    onlyTable
    title="Thành viên tham gia"
    ref="table"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import * as apiThongTinTuVong from "@/api/thong-tin-tu-vong";
export default {
  props: {
    id: {
      type: Number,
    },
  },
  components: {
    Crud,
  },
  watch: {
    id(newVal) {
      this.$refs.table.reset();
    },
  },
  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    fields: [
    {
        text: "Mã thành viên",
        type: "text",
        showable: true,
        filterable: false,
        value: "thanhVien.maNv",
        searchValue: "thanhVien",
        filterValue: "thanhVien",
        width: 200,
        sortable: true,
        form: {
          value: "maNv",
          fromValue: "thanhVien.maNv",
          default: null,
          type: "select-async",
          label: (item) =>
            item.maNv + "-" + item.hoTen + "-" + item.khoa.tenKhoa,
          keyValue: "maNv",
          apiFunc: getNhanVien,
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Tên thành viên",
        value: "thanhVien.hoTen",
        searchValue: "hoTenThanhVien",
        showable: true,
        filterable: false,
        filterValue: "hoTenThanhVien",
        type: "text",
        sortable: true,
        align: "center",
        width: 350,
      },
      {
        text: "Vai trò",
        value: "vaiTro",
        searchValue: "vaiTro",
        showable: true,
        filterable: false,
        filterValue: "vaiTro",
        type: "text",
        sortable: true,
        align: "center",
        width: 350,
        form: {
          value: "vaiTro",
          fromValue: "vaiTro",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
        },
      },
    
      {
        text: "Người hủy",
        showable: true,
        filterable: false,
        value: "nguoiHuy.hoTen",
        searchValue: "nguoiHuy",
        type: "text",
        sortable: true,
        width: 250,
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
        width: 200,
        sortable: true,
      },
    ],
    apiCategoryFunctions: {},
    actions: ["edit", "create", "delete"],
    disableActions: {
      edit: (item) => item.huy && !vm.currentUser.is_admin,
      delete: (item) => item.huy,
    },
  }),
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return apiThongTinTuVong.indexTvtg({
              idba: this.id,
            });
          } else {
            return apiThongTinTuVong.indexTvtg({
              idba: this.id,
              huy: false,
            });
          }
        },
        update: (...data) => apiThongTinTuVong.updateTvtg(this.id, ...data),
        destroy: (...item) => apiThongTinTuVong.destroyTvtg(this.id, ...item),
        store: (data) =>
          apiThongTinTuVong.storeTvtg({
            ...data,
            idba: this.id,
          }),
      };
    },
  },
};
</script>
<style></style>
