<template>
  <Crud :fields="fields" :apiCrudFunctions="apiCrudFunctions" :apiCategoryFunctions="apiCategoryFunctions"
    :disableActions="disableActions" :actions="actions" primaryKey="stt" label-width="100px"
    tableHeight="calc(100vh - 450px)" :dialogComponent="dialogComponent" :permission="permission" title="Bệnh án hội chẩn" />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail, update, destroy, print } from "@/api/ba-hoi-chuan";
import { formatDate, formatDatetime } from "@/utils/formatters";
import dialog from "./dialog.vue";

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
      dialogComponent: dialog,
      fields: [
        {
          text: "STT",
          type: "text",
          sortable: true,
          showable: true,
          filterable: false,
          value: "stt",
          // searchValue: "stt",
          width: 70,
          align: "center",
        },
        {
          text: "Khoa",
          type: "text",
          value: "khoaDieuTri.khoa.tenKhoa",
          // searchValue: "khoaDieuTri.khoa.tenKhoa",
          showable: true,
          sortable: true,
          width: 150,
          // form: {
          //   value: "khoaDieuTri",
          //   fromValue: "khoaDieuTri",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Ngày hội chẩn",
          type: "date",
          showable: true,
          value: "ngayHoiChan",
          // searchValue: "ngayHoiChan",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 150,
          sortable: true,
          // form: {
          //   value: "ngayhoichuan",
          //   fromValue: "ngayhoichuan",
          //   default: null,
          //   type: "date",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Tên biên bản hội chẩn",
          value: "tenBienBanHoiChan",
          type: "text",
          multiple: true,
          // searchValue: "tenBienBanHoiChan",
          showable: true,
          width: 200,
          sortable: true,
          // form: {
          //   value: "tenBienBanHoiChan",
          //   fromValue: "tenBienBanHoiChan",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },


        {
          text: "Chủ tọa",
          value: "chuToa.hoTen",
          type: "text",
          multiple: true,
          // searchValue: "chuToa.hoTen",
          showable: true,
          width: 150,
          sortable: true,
          // form: {
          //   value: "chuToa.hoTen",
          //   fromValue: "chuToa.hoTen",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },

        {
          text: "Tóm tắt diễn biến",
          value: "tomTatDienBienBenh",
          type: "text",
          // searchValue: "tomTatDienBienBenh",
          showable: true,
          width: 200,
          sortable: true,
          // form: {
          //   value: "tomTatDienBienBenh",
          //   fromValue: "tomTatDienBienBenh",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Hướng điều trị",
          value: "huongDt",
          type: "text",
          multiple: true,
          // searchValue: "huongDt",
          showable: true,
          width: 150,
          sortable: true,
          // form: {
          //   value: "huongDt",
          //   fromValue: "huongDt",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Kết luận",
          value: "ketLuan",
          type: "text",
          multiple: true,
          // searchValue: "ketLuan",
          showable: true,
          width: 150,
          sortable: true,
          // form: {
          //   value: "ketLuan",
          //   fromValue: "ketLuan",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Mã máy",
          value: "maMay",
          type: "text",
          multiple: true,
          // searchValue: "maMay",
          showable: true,
          width: 150,
          sortable: true,
          // form: {
          //   value: "maMay",
          //   fromValue: "maMay",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Người lập",
          type: "text",
          showable: true,
          value: "nguoiLap.hoTen",
          // searchValue: "nguoiLap",
          width: 150,
          sortable: true,
          // form: {
          //   value: "nguoiLap",
          //   fromValue: "nguoiLap.hoTen",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Ngày sửa",
          type: "date",
          showable: true,
          value: "ngaySd",
          // searchValue: "ngaySd",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
          // form: {
          //   value: "ngaySd",
          //   fromValue: "ngaySd",
          //   default: null,
          //   type: "date",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Người sửa",
          type: "text",
          showable: true,
          value: "nguoiSd.hoTen",
          // searchValue: "nguoiSd",
          width: 150,
          sortable: true,
          // form: {
          //   value: "nguoiSd",
          //   fromValue: "nguoiSd.hoTen",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Hủy",
          type: "text",
          showable: true,
          value: "huy",
          // searchValue: "huy",
          width: 100,
          type: "boolean",
          align: "center",
          sortable: true,
          // form: {
          //   value: "huy",
          //   fromValue: "huy",
          //   default: null,
          //   type: "boolean",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Ngày hủy",
          type: "date",
          showable: true,
          value: "ngayHuy",
          // searchValue: "ngayHuy",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 150,
          sortable: true,
          // form: {
          //   value: "ngayHuy",
          //   fromValue: "ngayHuy",
          //   default: null,
          //   type: "date",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Người hủy",
          type: "text",
          showable: true,
          value: "nguoiHuy.hoTen",
          // searchValue: "nguoiHuy",
          width: 150,
          sortable: true,
          // form: {
          //   value: "nguoiHuy",
          //   fromValue: "nguoiHuy.hoTen",
          //   default: null,
          //   type: "text",
          //   creatable: true,
          //   editable: true,
          // },
        },
      ],
      apiCategoryFunctions: {},
      actions: ["delete", "edit:dialog", "create:dialog", "print"],
      disableActions: {
        edit: (item) => item.huy && !vm.currentUser.is_admin,
        delete: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/HoiChan/delete"
        ),
        // create: !vm.permission.find(
        //   (e) => e.ActionDetailsName == "/HSBA/HoiChan/create"
        // ),
        print: (item) => item.huy || !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/HoiChan/export"
        ),
      },
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
    };
  },
  computed: {
    apiCrudFunctions() {
      const vm = this
      return {
        index: (params) => index(this.id, params),
        update,
        destroy: (...item) => destroy(this.id, ...item),
        print: (...item) => print(vm.id, ...item),
      };
    },
  },
};
</script>
