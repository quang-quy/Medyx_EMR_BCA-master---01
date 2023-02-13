<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :disableActions="disableActions"
    :headerComponent="headerComponent"
    :permission="permission"
    :actions="actions"
    primaryKey="stt"
    label-width="100px"
    :hasCheckbox="true"
    @dataCheck="dataCheck"
    title="Phiếu theo dõi, chăm sóc"
    tableHeight="calc(100vh - 400px)"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import Header from "./Header.vue";
import {
  index,
  xoaPhieuChamSoc,
  print,
  printSoDo,
} from "@/api/benh-an-phieu-cham-soc.js";
import { formatDate, formatDatetime } from "@/utils/formatters";
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
      headerComponent: Header,
      fields: [
        {
          text: "STT",
          showable: true,
          type: "text",
          value: "stt",
          width: 50,
        },
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          showable: true,
          filterable: true,
          filterValue: "KhoaDieuTri",
          type: "text",
          width: 200,
        },
        {
          text: "Ngày giờ chăm sóc",
          sortable: true,
          showable: true,
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          value: "ngayChamSoc",
          width: 200,
        },
        {
          text: "Tên điều dưỡng",
          showable: true,
          value: "dieuDuong.hoTen",
          type: "text",
          width: 150,
        },
        {
          text: "Ngày lập",
          showable: true,
          value: "ngayLap",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 150,
        },
        {
          text: "Người lập",
          showable: true,
          type: "text",
          value: "nguoiLap.hoTen",
          width: 150,
        },
        {
          text: "Ngày sửa",
          showable: true,
          value: "ngaySd",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 150,
        },
        {
          text: "Người sửa",
          showable: true,
          type: "text",
          value: "nguoiSD.hoTen",
          width: 150,
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
          showable: true,
          value: "ngayHuy",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 150,
        },
        {
          text: "Người hủy",
          showable: true,
          type: "text",
          value: "nguoiHuy.hoTen",
          width: 150,
        },
      ],

      apiCategoryFunctions: {},
      disableActions: {
        detail: (item) => item.huy && !vm.currentUser.is_admin,
        delete: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/delete"
        ),
        print: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/export"
        ),
      },
      actions: [
        "delete",
        "detail:/HSBADS/ChiTietTheoDoiVaChamSoc/:idba/chi-tiet/:stt",
        "checkbox",
      ],
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
    };
  },
  computed: {
    apiCrudFunctions() {
      const vm = this;
      return {
        index: (params) => index({ ...params, idba: this.id }),
        destroy: (params) => xoaPhieuChamSoc(this.id, ...params),
      };
    },
  },
  methods: {
    dataCheck(data) {
      console.log()
      if (!data || !data.data || data.data.length == 0) {
        this.$message({
          message: "Vui lòng chọn ít nhất một bản ghi",
          type: "warning",
        });
        return;
      } else {
        let param = "";
        data.data.forEach((el) => {
          param = param + `Stt[]=${el.stt}&`;
        });
        if (data.type == "phieuChamSoc") {
          print(this.id, param);
        }
        if (data.type == "bieuDo") {
          printSoDo(this.id, param);
        }
      }
    },
  },
};
</script>
<style></style>
