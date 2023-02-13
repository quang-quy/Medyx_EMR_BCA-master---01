<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    :customFormFields="customFormFields"
    :headerComponent="headerComponent"
    primaryKey="idba.stt"
    label-width="100px"
    tableHeight="400px"
    title="Thông tin theo dõi truyền dịch"
  >
  </Crud>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import {
  index,
  store,
  update,
  destroy,
  print,
} from "@/api/thong-tin-truyen-dich";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import truyenDichSelection from "./truyenDichSelection.vue";
import Header from "./Header.vue";
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
      headerComponent: Header,
      customFormFields: truyenDichSelection,
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
          text: "Tên khoa điều trị",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "khoa",
          showable: true,
          filterable: false,
          filterValue: "khoa",
          type: "text",
          sortable: true,
          align: "center",
          width: 300,
          form: {
            value: "sttKhoa",
            fromValue: "sttkhoa",
            default: null,
            type: "custom",
            creatable: true,
            editable: true,
          },
        },

        {
          text: "Ngày truyền dịch",
          type: "datetime",
          showable: true,
          filterable: false,
          value: "thoiGianBatDau",
          searchValue: "thoiGianBatDau",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 220,
          sortable: true,
          align: "center",
          form: {
            value: "thoiGianBatDau",
            fromValue: "thoiGianBatDau",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Ngày kết thúc",
          type: "datetime",
          showable: true,
          filterable: false,
          value: "thoiGianKetThuc",
          searchValue: "thoiGianKetThuc",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
          form: {
            value: "thoiGianKetThuc",
            fromValue: "thoiGianKetThuc",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Mã thuốc",
          value: "maDichTruyen",
          searchValue: "maDichTruyen",
          showable: true,
          filterable: false,
          filterValue: "maDichTruyen",
          type: "text",
          sortable: true,
          align: "center",
          width: 350,
          form: {
            value: "maDichTruyen",
            fromValue: "maDichTruyen",
            default: null,
            type: "custom",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Tên thuốc",
          value: "tenDichTruyen",
          searchValue: "tenDichTruyen",
          showable: true,
          filterable: false,
          filterValue: "tenDichTruyen",
          type: "text",
          sortable: true,
          align: "center",
          width: 350,
          form: {
            value: "tenDichTruyen",
            fromValue: "tenDichTruyen",
            default: null,
            type: "custom",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Số lượng",
          value: "soLuong",
          searchValue: "soLuong",
          showable: true,
          filterable: false,
          filterValue: "soLuong",
          type: "text",
          sortable: true,
          align: "center",
          width: 350,
          form: {
            value: "soLuong",
            fromValue: "soLuong",
            default: 0,
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
          text: "Lô/Số sản xuất",
          value: "soLo",
          searchValue: "soLo",
          showable: true,
          filterable: false,
          filterValue: "soLo",
          type: "text",
          sortable: true,
          align: "center",
          width: 200,
          form: {
            value: "soLo",
            fromValue: "soLo",
            default: null,
            type: "custom",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Tốc độ truyền (giọt/phút)",
          value: "tocDo",
          searchValue: "tocDo",
          showable: true,
          filterable: false,
          filterValue: "tocDo",
          type: "text",
          sortable: true,
          align: "center",
          width: 200,
          form: {
            value: "tocDo",
            fromValue: "tocDo",
            default: 0,
            type: "number",
            creatable: true,
            editable: true,
            rules: [
              {
                validator: (v) => v !== null && v !== undefined,
                message: "Trường này bắt buộc nhập",
              },
              {
                validator: (v) => v > 1,
                message: "Trường này bắt buộc lớn hơn 1",
              },
            ],
          },
        },
        {
          text: "Bác sỹ chỉ định",
          type: "text",
          showable: true,
          filterable: false,
          value: "bschiDinh.maNv",
          searchValue: "bschiDinh",
          filterValue: "bschiDinh",
          width: 200,
          sortable: true,
          form: {
            value: "bschiDinh",
            fromValue: "bschiDinh.maNv",
            default: 0,
            type: "custom",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Điều dưỡng thực hiện",
          type: "text",
          showable: true,
          filterable: false,
          value: "dieuDuong.hoTen",
          searchValue: "dieuDuong",
          filterValue: "dieuDuong",
          width: 200,
          sortable: true,
          form: {
            fromValue: "dieuDuong.maNv",
            value: "dieuDuong",
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
      apiCategoryFunctions: {},
      actions: ["create", "edit", "delete"],
      disableActions: {
        edit: (item) =>
          (item.huy && !vm.currentUser.is_admin) ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/TheoDoiTruyenDich/modify"
          ),
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/TheoDoiTruyenDich/delete"
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
      };
    },
  },
};
</script>
