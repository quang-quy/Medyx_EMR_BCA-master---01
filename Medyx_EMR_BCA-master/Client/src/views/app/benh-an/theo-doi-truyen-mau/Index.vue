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
    title="Thông tin theo dõi truyền máu"
  >
  </Crud>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, update, destroy } from "@/api/thong-tin-truyen-mau";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  components: {
    Crud,
  },
  props: {
    id: {
      type: [Number, Array],
      required: true,
    },
  },

  data(vm) {
    return {
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      fields: [
        {
          text: "Khoa",
          value: "khoaDieuTri.khoa.tenKhoa",
          searchValue: "khoa.tenKhoa",
          showable: true,
          filterable: false,
          filterValue: "khoa.tenKhoa",
          type: "text",
          sortable: true,
          align: "center",
          width: 100,
        },
        {
          text: "Ngày chỉ định",
          type: "datetime",
          showable: true,
          filterable: false,
          value: "ngayYlenh",
          searchValue: "ngayYlenh",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 200,
          sortable: true,
          width: 200,
          align: "center",
          form: {
            value: "ngayYlenh",
            fromValue: "ngayYlenh",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Bác sỹ chỉ định",
          type: "text",
          showable: true,
          filterable: false,
          value: "bsChiDinh.maNv",
          searchValue: "bsChiDinh",
          filterValue: "bsChiDinh",
          width: 200,
          sortable: true,
          form: {
            value: "bsChiDinh",
            fromValue: "bsChiDinh.maNv",
            default: 0,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Tên CPM",
          value: "chePhamMau.tenDV",
          searchValue: "chePhamMau",
          showable: true,
          filterable: false,
          filterValue: "chePhamMau",
          type: "text",
          sortable: true,
          align: "center",
          width: 350,
          // form: {
          //   value: "chePhamMau",
          //   fromValue: "chePhamMau",
          //   default: null,
          //   type: "custom",
          //   creatable: true,
          //   editable: true,
          // },
        },
        {
          text: "Mã số CPM",
          value: "chePhamMau.maDV",
          searchValue: "chePhamMau",
          showable: true,
          filterable: false,
          filterValue: "chePhamMau",
          type: "text",
          sortable: true,
          align: "center",
          width: 350,
          form: {
            value: "chePhamMau",
            fromValue: "chePhamMau",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Thể tích",
          value: "truyenMau.theTich",
          searchValue: "theTich",
          showable: true,
          filterable: false,
          filterValue: "theTich",
          type: "text",
          sortable: true,
          align: "center",
          width: 350,
          form: {
            value: "theTich",
            fromValue: "truyenMau.theTich",
            default: null,
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
          text: "Ngày BĐ truyền máu",
          type: "date",
          showable: true,
          filterable: false,
          value: "truyenMau.thoiGianBd",
          searchValue: "thoiGianBd",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 250,
          sortable: true,
        },
        {
          text: "Ngày KT truyền máu",
          type: "date",
          showable: true,
          filterable: false,
          value: "truyenMau.thoiGianKt",
          searchValue: "thoiGianKt",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 250,
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
      actions: ["detail:/HSBADS/ChiTietTheoDoiTruyenMau/:idba/chi-tiet/:stt"],
      disableActions: {
        detail: (item) => item.huy,
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
      };
    },
  },
};
</script>
