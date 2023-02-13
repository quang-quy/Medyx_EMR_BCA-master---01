<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="uuid.sttdv.maCs"
    label-width="100px"
    title="Danh sách các chỉ số xét nghiệm"
    tableHeight="calc(100vh - 550px)"
    :wrapper="false"
    onlyTable
    ref="table"
  >
  </Crud>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import * as apiPhieuXetNghiem from "@/api/phieu-xet-nghiem";
import { formatDate, formatDatetime } from "@/utils/formatters";
import { getKhoas, getNhanVien } from "@/api/phieu-xet-nghiem.js";
export default {
  components: {
    Crud,
  },
  props: {
    params: {
      type: Object,
      default: () => {},
    },
    dataDetail: {
      type: Object,
      default: () => {},
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  watch: {
    params: {
      handler: function (neVal) {
        this.$refs.table.reset();
      },
      deep: true,
    },
  },
  data(vm) {
    return {
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
          width: 70,
          sortable: true,
          align: "center",
          form: {
            value: "stt",
            fromValue: "stt",
            default: null,
            type: "text",
            show: false,
            creatable: false,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Cấp cứu",
          value: "capcuu",
          searchValue: "capcuu",
          showable: true,
          filterable: false,
          filterValue: "capcuu",
          type: "bit",
          width: 100,
          sortable: true,
          align: "center",
          form: {
            value: "capcuu",
            fromValue: "capcuu",
            default: null,
            type: "boolean",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Ngày tiếp nhận",
          value: "ngayTiepNhan",
          type: "datetime",
          showable: true,
          filterable: false,
          searchValue: "ngayTiepNhan",
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          width: 160,
          sortable: true,
          form: {
            value: "ngayTiepNhan",
            fromValue: "ngayTiepNhan",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Số phiếu",
          value: "soPhieu",
          searchValue: "soPhieu",
          showable: true,
          filterable: false,
          filterValue: "soPhieu",
          type: "text",
          width: 200,
          sortable: true,
          form: {
            value: "soPhieu",
            fromValue: "soPhieu",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Tên chỉ số",
          value: "dichVuCs.tenCs",
          searchValue: "tenCs",
          showable: true,
          filterable: false,
          filterValue: "tenCs",
          type: "text",
          width: 300,
          sortable: true,
          form: {
            value: "tenCs",
            fromValue: "dichVuCs.tenCs",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Kết quả",
          value: "kq",
          searchValue: "kq",
          showable: true,
          filterable: false,
          filterValue: "kq",
          type: "text",
          width: 150,
          sortable: true,
          form: {
            value: "kq",
            fromValue: "kq",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Đơn vị đo",
          value: "dichVuCs.donViDo",
          searchValue: "donViDo",
          showable: true,
          filterable: false,
          filterValue: "donViDo",
          type: "text",
          width: 150,
          sortable: true,
          form: {
            value: "donViDo",
            fromValue: "dichVuCs.donViDo",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Giá trị tham chiếu Nam",
          value: "dichVuCs",
          searchValue: "dichVuCs",
          showable: true,
          filterable: false,
          filterValue: "dichVuCs",
          type: "text",
          width: 200,
          sortable: true,
          formatter: function (_, __, value) {
            return `${value.chisothapNam ? value.chisothapNam : ""}${
              value.chisocaoNam ? "-" + value.chisocaoNam : ""
            }`;
          },
          form: {
            value: "chisothapNam",
            fromValue: "dichVuCs.chisothapNam",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Giá trị tham chiếu Nữ",
          value: "dichVuCs",
          searchValue: "dichVuCs",
          showable: true,
          filterable: false,
          filterValue: "dichVuCs",
          type: "text",
          width: 200,
          sortable: true,
          formatter: function (_, __, value) {
            return `${value.chisothapNu ? value.chisothapNu : ""}${
              value.chisocaoNu ? "-" + value.chisocaoNu : ""
            }`;
          },
          form: {
            value: "chisothapNu",
            fromValue: "dichVuCs.chisothapNu",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Bất thường",
          value: "batThuong",
          searchValue: "batThuong",
          showable: true,
          filterable: false,
          filterValue: "batThuong",
          type: "text",
          width: 150,
          sortable: true,
          form: {
            value: "batThuong",
            fromValue: "batThuong",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Kĩ thuật viên",
          type: "text",
          showable: true,
          filterable: false,
          value: "ktv.hoTen",
          searchValue: "ktv",
          filterValue: "ktv",
          width: 170,
          sortable: true,
          form: {
            value: "ktv",
            fromValue: "ktv.maNv",
            default: null,
            creatable: true,
            editable: true,
            type: "select-async",
            label: (item) =>
              `${item.maNv} - ${item.hoTen} ${
                item.khoa.tenKhoa ? "-" + item.khoa.tenKhoa : ""
              }`,
            keyValue: "maNv",
            apiFunc: getNhanVien,
          },
        },
        {
          text: "Bác sỹ duyệt kết quả",
          type: "text",
          showable: true,
          filterable: false,
          value: "nguoiDuyetKq.hoTen",
          searchValue: "nguoiDuyetKq",
          filterValue: "nguoiDuyetKq",
          width: 200,
          sortable: true,
          form: {
            value: "nguoiDuyetKq",
            fromValue: "nguoiDuyetKq.maNv",
            default: null,
            creatable: true,
            editable: true,
            type: "select-async",
            label: (item) =>
              `${item.maNv} - ${item.hoTen} ${
                item.khoa.tenKhoa ? "-" + item.khoa.tenKhoa : ""
              }`,
            keyValue: "maNv",
            apiFunc: getNhanVien,
          },
        },
        {
          text: "Ngày giờ trả kết quả",
          value: "ngayTraKq",
          searchValue: "ngayTraKq",
          showable: true,
          filterable: false,
          filterValue: "ngayTraKq",
          type: "time",
          width: 200,
          sortable: true,
          formatter: function (_, __, value) {
            return formatDatetime(value);
          },
          form: {
            value: "ngayTraKq",
            fromValue: "ngayTraKq",
            default: null,
            type: "datetime",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Kết luận",
          value: "ketLuan",
          searchValue: "ketLuan",
          showable: true,
          filterable: false,
          filterValue: "ketLuan",
          type: "text",
          width: 150,
          sortable: true,
          form: {
            value: "ketLuan",
            fromValue: "ketLuan",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Khoa thực hiện",
          type: "text",
          showable: true,
          filterable: true,
          value: "khoaThucHien.tenKhoa",
          searchValue: "khoaThucHien",
          filterValue: "khoaThucHien",
          width: 170,
          sortable: true,
          form: {
            value: "MaKhoaThucHien",
            fromValue: "khoaThucHien.maKhoa",
            default: null,
            creatable: true,
            editable: true,
            type: "select-async",
            label: (item) => item.maKhoa + "-" + item.tenKhoa,
            keyValue: "maKhoa",
            apiFunc: getKhoas,
          },
        },
        {
          text: "Máy thực hiện",
          value: "maMayThucHien",
          searchValue: "maMayThucHien",
          showable: true,
          filterable: false,
          filterValue: "maMayThucHien",
          type: "text",
          width: 150,
          sortable: true,
          form: {
            value: "maMayThucHien",
            fromValue: "maMayThucHien",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
          },
        },
        {
          text: "Bác sĩ chỉ định",
          value: "bschiDinh.hoTen",
          searchValue: "bschiDinh",
          showable: true,
          filterable: false,
          filterValue: "bschiDinh",
          type: "text",
          width: 200,
          sortable: true,
          align: "center",
          form: {
            value: "bschiDinhhoTen",
            fromValue: "bschiDinh.hoTen",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "IDHIS",
          value: "idhis",
          searchValue: "idhis",
          showable: true,
          filterable: false,
          filterValue: "idhis",
          type: "text",
          width: 150,
          sortable: true,
          align: "center",
          form: {
            value: "idhis",
            fromValue: "idhis",
            default: null,
            type: "text",
            creatable: true,
            editable: true,
            disabled: true
          },
        },
        {
          text: "Đường link xem kết quả từ hệ thống LIS",
          value: "linkPacsLis",
          searchValue: "linkPacsLis",
          showable: true,
          filterable: false,
          filterValue: "linkPacsLis",
          type: "link",
          width: 300,
          sortable: true,
          form: {
            value: "linkPacsLis",
            fromValue: "linkPacsLis",
            default: null,
            creatable: true,
            editable: true,
            type: "text",
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
          width: 170,
          sortable: true,
          form: {
            value: "ngayLap",
            fromValue: "ngayLap",
            default: null,
            creatable: true,
            editable: true,
            type: "datetime",
            disabled: true
          },
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
          form: {
            value: "nguoiLaphoTen",
            fromValue: "nguoiLap.hoTen",
            default: null,
            creatable: true,
            editable: true,
            type: "text",
            disabled: true
          },
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
          form: {
            value: "ngaySd",
            fromValue: "ngaySd",
            default: null,
            creatable: true,
            editable: true,
            type: "datetime",
            disabled: true
          },
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
          form: {
            value: "nguoiSDhoTen",
            fromValue: "nguoiSD.hoTen",
            default: null,
            creatable: true,
            editable: true,
            type: "text",
            disabled: true
          },
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
            creatable: true,
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
          width: 170,
          sortable: true,
          form: {
            value: "ngayHuy",
            fromValue: "ngayHuy",
            default: null,
            creatable: true,
            editable: true,
            type: "datetime",
            disabled: true
          },
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
          form: {
            value: "nguoiHuyhoTen",
            fromValue: "nguoiHuy.hoTen",
            default: null,
            creatable: true,
            editable: true,
            type: "text",
            disabled: true
          },
        },
      ],
      apiCategoryFunctions: {},
      actions: ["delete", "edit"],
      disableActions: {
        edit: (item) =>
          (item.huy && !vm.currentUser.is_admin) ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/PhieuXetNghiem/modify"
          ) ||
          item.idhis,
        delete: (item) =>
          item.huy ||
          !vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/PhieuXetNghiem/delete"
          ) ||
          !item.stt ||
          item.idhis,
      },
    };
  },
  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => {
          if (this.currentUser.is_admin) {
            return apiPhieuXetNghiem.detail({
              idba: this.params.idba,
              sttdv: this.params.stt,
              sortBy: 'stt',
              ...params,
            });
          } else {
            return apiPhieuXetNghiem.detail({
              idba: this.params.idba,
              sttdv: this.params.stt,
              huy: false,
              sortBy: 'stt',
              ...params,
            });
          }
        },
        update: (...data) => apiPhieuXetNghiem.handleUpDateCrete({
          sttdv: data[1],
          maCs: data[2],
          ...data[3],
          idba: this.params.idba,
        }),

        destroy: (...item) => {
          if (!item[1]) {
            return this.$message.error("Chưa có số thứ tự không thể xóa");
          }
          return apiPhieuXetNghiem.destroy(this.params.idba, item[1]);
        },
      };
    },
  },
};
</script>

<style scoped></style>
