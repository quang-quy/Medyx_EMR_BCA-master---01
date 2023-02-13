<template>
  <Crud :fields="fields" :apiCrudFunctions="apiCrudFunctions" :apiCategoryFunctions="apiCategoryFunctions"
    :disableActions="disableActions" :actions="actions" primaryKey="stt" label-width="100px"  tableHeight="400px"
    title="Thông tin phẫu thuật thủ thuật" />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail } from "@/api/benh-an-phau-thuat";
import {
  destroy,
} from "@/api/benhAnToDieuTri/phau-thu-thuat";
import { formatDatetime, formatDate } from "@/utils/formatters";
export default {
  components: {
    Crud,
  },
  props: {
    id: {
      type: Number,
    },
    permission: { 
      type: Array,
      default: () => [],
    },
  },

  data(vm) {
    return {
      fields: [
        {
          text: "STTDV",
          type: "text",
          sortable: true,
          showable: true,
          filterable: false,
          value: "stt",
          searchValue: "stt",
          width: 100,
          align: "center",
        },
        {
          text: "Khoa",
          showable: true,
          value: "khoa.tenKhoa",
          type: "text",
          width: 200,
        },
        {
          text: "Ngày chỉ định",
          sortable: true,
          showable: true,
          value: "ngayYlenh",
          type: "date",
          filterable: false,
          filterValue: "ngayYlenh",
          sortable: true,
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 200
        },
        {
          text: "Tên dịch vụ",
          sortable: true,
          showable: true,
          value: "phauThuat.tenPt",
          type: "text",
          filterable: false,
          filterValue: "phauThuat.tenPt",
          sortable: true,
          width: 300
        },
        {
          text: "Bác sĩ chỉ định",
          sortable: true,
          showable: true,
          value: "bschiDinh.hoTen",
          type: "text",
          filterable: false,
          filterValue: "bschiDinh.hoTen",
          sortable: true,
          width: 200
        },
        {
          text: "Ngày giờ phẫu thuật",
          showable: true,
          value: "",
          type: "text",
          width: 200,
        },
        {
          text: "Ngày lập",
          showable: true,
          value: "ngayLap",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          type: "text",
          width: 200,
        },
        {
          text: "Người lập",
          showable: true,
          value: "nguoiLap.hoTen",
          type: "text",
          width: 200,
        },
        {
          text: "Ngày sửa",
          showable: true,
          value: "ngaySd",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          type: "date",
          width: 200,
        },
        {
          text: "Người sửa",
          showable: true,
          value: "nguoiSD.hoTen",
          type: "text",
          width: 200,
        },
        {
          text: "Hủy",
          showable: true,
          value: "huy",
          type: "boolean",
          align: "center",
          width: 50,
        },
        {
          text: "Ngày hủy",
          showable: true,
          value: "ngayHuy",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          type: "text",
          width: 200,
        },
        {
          text: "Người hủy",
          showable: true,
          value: "nguoiHuy.hoTen",
          type: "text",
          width: 200,
        },
      ],
      apiCategoryFunctions: {},
      actions: ["delete", "detail:/HSBADS/LoaiPhieuPhauThuat/:idba/loai-phieu/:stt",],
      disableActions: {
        delete: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhauThuatThuThuat/delete"
        ),
        detail: (item) => item.huy,
      },
    };
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => index(this.id, params),
        detail,
        destroy: (...item) => destroy(this.id, ...item),
      };
    },
  },
  methods: {

  }
};
</script>
<style>
.el-button {
  padding: 0px !important;
}
</style>
