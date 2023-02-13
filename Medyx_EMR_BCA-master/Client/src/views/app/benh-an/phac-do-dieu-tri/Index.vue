<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="stt"
    label-width="100px"
    tableHeight="calc(100vh - 450px)"
    title="Phác đồ điều trị"
    :dialogComponent="dialogComponent"
    :permission="permission"
    :headerComponent="headerComponent"
  >
  </Crud>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, update, destroy } from "@/api/phac-do-dieu-tri";
import { formatDate, formatDatetime } from "@/utils/formatters";
import dialog from "./dialog";
import Header from "./Header.vue";
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
      default: () => [],
    },
  },
  data(vm) {
    return {
      headerComponent: Header,
      dialogComponent: dialog,
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      fields: [
        {
          text: "STT",
          value: "stt",
          searchValue: "stt",
          showable: true,
          filterable: false,
          filterValue: "stt",
          type: "text",
          sortable: true,
          align: "center",
          width: 100,
        },
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "khoa.tenKhoa",
          showable: true,
          filterable: false,
          filterValue: "khoa.tenKhoa",
          type: "text",
          sortable: true,
          width: 200,
        },
        {
          text: "Mã bệnh",
          value: "maBenh",
          searchValue: "maBenh",
          showable: true,
          filterable: false,
          filterValue: "maBenh",
          type: "text",
          sortable: true,
          width: 100,
        },
        {
          text: "Tên bệnh",
          value: "tenBenh",
          searchValue: "tenBenh",
          showable: true,
          filterable: false,
          filterValue: "tenBenh",
          type: "text",
          sortable: true,
          width: 350,
        },
        {
          text: "Ngày áp dụng",
          type: "datetime",
          showable: true,
          filterable: false,
          value: "ngayAdphacDo",
          searchValue: "ngayAdphacDo",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
        },
        {
          text: "Bác sỹ điều trị",
          type: "text",
          showable: true,
          filterable: false,
          value: "bsdieuTri.hoTen",
          searchValue: "bsdieuTri",
          filterValue: "bsdieuTri",
          width: 200,
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
        "detail:/HSBADS/ChiTietPhacDoDT/:idba/chi-tiet/:stt",
        "delete",
        "create:dialog",
        "header-create",
      ],
      disableActions: {
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/PhacDoDieuTri/delete"
          ),
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
        store: (data) =>
          store({
            idba: this.id,
            ...data,
          }),
        update: (...data) => update(...data),
        destroy: (...item) => destroy(...item),
        print: (...item) => print(...item),
      };
    },
  },
};
</script>
