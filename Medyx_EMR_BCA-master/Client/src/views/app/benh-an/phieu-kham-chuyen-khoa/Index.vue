<template>
  <Crud :fields="fields" :apiCrudFunctions="apiCrudFunctions" :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions" :headerComponent="headerComponent" primaryKey="stt" label-width="100px"
    :disableActions="disableActions" title="Phiếu khám chuyên khoa" tableHeight="calc(100vh - 400px)" />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, print, destroy } from "@/api/benh-an-can-lam-san.js";
import Header from "./Header.vue";
import { formatDate, formatDatetime } from "@/utils/formatters";
export default {
  props: {
    id: {
      type: Number,
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
          value: "stt",
          // showable: true,
          // filterable: true,
          type: "text",
          width: 50,
        },
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          // sortable: true,
          showable: true,
          filterable: true,
          type: "text",
          width: 200,
        },
        {
          text: "Tên dịch vụ khám",
          // sortable: true,
          showable: true,
          type: "text",
          value: "dichVu.tenDv",
          width: 200,
        },
        {
          text: "Ngày chỉ định",
          showable: true,
          value: "ngayYlenh",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 150,
        },
        {
          text: "Bác sĩ chỉ định",
          sortable: true,
          showable: true,
          type: "text",
          value: "bsChiDinh.hoTen",
          width: 150,
        },
        // {
        //   text: "Kết quả khám",
        //   sortable: true,
        //   showable: true,
        //   type: "text",
        //   value: "benhAnClsKq.ketLuan",
        //   width: 150,
        // },
        {
          text: "Bác sĩ khám",
          sortable: true,
          showable: true,
          type: "text",
          value: "benhAnClsKq.bschuyenKhoa.hoTen",
          width: 150,
        },
        {
          text: "Ngày lập",
          showable: true,
          value: "ngayLap",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
        },
        {
          text: "Người lập",
          sortable: true,
          showable: true,
          type: "text",
          value: "nguoiLap.hoTen",
          width: 150,
        },
        {
          text: "Ngày sửa",
          showable: true,
          value: "ngaySD",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
        },
        {
          text: "Người sửa",
          sortable: true,
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
            return formatDate(value);
          },
          width: 150,
        },
        {
          text: "Người hủy",
          sortable: true,
          showable: true,
          type: "text",
          value: "nguoiHuy.hoTen",
          width: 150,
        },
      ],

      apiCategoryFunctions: {},

      actions: ["print", "delete", "detail:/HSBADS/ChiTietPhieuKhamChuyenKhoa/:idba/chi-tiet/:stt",],
      disableActions: {
        edit: (item) => item.huy && !vm.currentUser.is_admin,
        delete: (item) => item.huy || item.idhis,
        print: (item) => item.huy,
      },
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
    }
  },
  computed: {
    apiCrudFunctions() {
      const maChungLoai = 1;
      const loaiTaiLieu = 8
      return {
        index: (params) => index({ ...params, idba: this.id, MaChungLoai: maChungLoai }),
        print: (...item) => print(this.id, ...item, maChungLoai, loaiTaiLieu),
        destroy: (...item) => destroy(this.id, ...item),
      };
    },
  },
};
</script>
<style>

</style>