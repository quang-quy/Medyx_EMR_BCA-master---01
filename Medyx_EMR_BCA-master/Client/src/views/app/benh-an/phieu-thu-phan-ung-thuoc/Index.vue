<template>
  <Crud :fields="fields" :apiCrudFunctions="apiCrudFunctions" :apiCategoryFunctions="apiCategoryFunctions"
    :disableActions="disableActions" :actions="actions" :headerComponent="headerComponent" :permission="permission"
    :paramHeader="{ idba: id }" primaryKey="stt" label-width="100px" title="Phiếu thử phản ứng thuốc"
    tableHeight="calc(100vh - 400px)" :customFormFields="customFormFields" />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import {
  index,
  addPhieuThuPhanUngThuoc,
  xoaPhieuThuPhanUngThuoc,
  updatePhieuThuPhanUngThuoc,
} from "@/api/phieu-thu-phan-ung-thuoc";
import { formatDate, formatDatetime } from "@/utils/formatters";
import Header from "./Header.vue";
import { getKhoa } from "@/api/benh-an";
import { index as getNhanVien } from "@/api/nhan-vien";
import { index as getKhoaDT } from "@/api/khoa-dieu-tri.js";
import { getDanhSachThuoc } from "@/api/danh-muc.js";
import thuocTayYSelection from "./selections/thuocTayYSelection.vue";

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
  data: (vm) => ({
    headerComponent: Header,
    customFormFields: thuocTayYSelection,
    fields: [
      {
        text: "STT",
        sortable: true,
        showable: true,
        type: "text",
        value: "stt",
        width: 70,
      },
      {
        text: "Tên khoa điều trị",
        value: "khoaDieuTri.khoa.tenKhoa",
        showable: true,
        type: "text",
        width: 180,
        form: {
          value: "sttKhoa",
          fromValue: "khoaDieuTri.stt",
          default: null,
          type: "select-async",
          creatable: true,
          editable: true,
          label: (item) => `${item.maKhoa} - ${item.khoa.tenKhoa}`,
          keyValue: "stt",
          apiFunc: (...params) => getKhoaDT(vm.id, ...params),
          rules: [
            {
              validator: (v) => v !== null && v !== undefined,
              message: "Hãy chọn khoa",
            },
          ],
        },
      },
      {
        text: "Ngày bắt đầu",
        sortable: true,
        showable: true,
        value: "ngayBatDau",
        width: 200,
        formatter: function (_, __, value) {
          return formatDatetime(value);
        },
        form: {
          value: "ngayBatDau",
          fromValue: "ngayBatDau",
          default: null,
          type: "datetime",
          creatable: true,
          editable: true,
        },
      },
      {
        text: "Mã Thuốc",
        showable: true,
        value: "maThuoc",
        type: "text",
        width: 250,
        form: {
          value: "maThuoc",
          fromValue: "maThuoc",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Tên Thuốc",
        showable: true,
        value: "tenThuoc",
        type: "text",
        width: 350,
        form: {
          value: "tenThuoc",
          fromValue: "tenThuoc",
          default: null,
          creatable: true,
          editable: true,
          type: "custom",
        },
      },
      {
        text: "Phương pháp thử",
        filterable: true,
        showable: true,
        value: "phuongPhapThu",
        type: "text",
        width: 150,
        multiple: true,
        width: 200,
        form: {
          value: "phuongPhapThu",
          fromValue: "phuongPhapThu",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
        },
      },

      {
        text: "Bác sĩ chỉ định",
        showable: true,
        value: "bschiDinh.hoTen",
        type: "text",
        width: 200,
        form: {
          value: "bschiDinh",
          fromValue: "bschiDinh.maNv",
          default: null,
          creatable: true,
          editable: true,
          type: "select-async",
          label: (item) => `${item.maNv} - ${item.hoTen}`,
          keyValue: "maNv",
          apiFunc: getNhanVien,
        },
      },
      {
        text: "Người thử",
        showable: true,
        filterable: true,
        value: "nguoiThu.hoTen",
        type: "text",
        width: 200,
        form: {
          value: "nguoiThu",
          fromValue: "nguoiThu.maNv",
          default: null,
          creatable: true,
          editable: true,
          type: "select-async",
          label: (item) => `${item.maNv} - ${item.hoTen}`,
          keyValue: "maNv",
          apiFunc: getNhanVien,
        },
      },
      {
        text: "Người đọc kết quả",
        showable: true,
        filterable: true,
        value: "bsdocKq.hoTen",
        type: "text",
        width: 200,
        form: {
          value: "bsdocKq",
          fromValue: "bsdocKq.maNv",
          default: null,
          creatable: true,
          editable: true,
          type: "select-async",
          label: (item) => `${item.maNv} - ${item.hoTen}`,
          keyValue: "maNv",
          apiFunc: getNhanVien,
        },
      },
      {
        text: "Kết quả",
        showable: true,
        filterable: true,
        value: "ketQua",
        type: "text",
        width: 300,
        form: {
          value: "ketQua",
          fromValue: "ketQua",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
        },
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
        text: "Ngày sửa",
        showable: true,
        value: "ngaySd",
        formatter: function (_, __, value) {
          return formatDate(value);
        },
        width: 150,
      },
      {
        text: "Người sửa",
        showable: true,
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
        showable: true,
        value: "nguoiHuy.hoTen",
        width: 150,
      },
    ],

    apiCategoryFunctions: {
      khoas: {
        func: getKhoa,
        textField: "maKhoa",
        valueField: "maKhoa",
        codeField: "tenKhoa",
      },
      nhanViens: {
        func: getNhanVien,
        textField: "hoTen",
        valueField: "maNV",
        codeField: "hoTen",
      },
    },

    actions: ["create", "edit", "delete"],
    disableActions: {
      edit: (item) => item.huy && !vm.currentUser.is_admin,
      delete: (item) => item.huy || !vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/phieuphanungthuoc/delete"
      ),
      print: (item) => item.huy,
    },
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
  }),

  computed: {
    apiCrudFunctions() {
      return {
        index: (params) => index(this.id, params),
        store: (...data) => addPhieuThuPhanUngThuoc({ idba: this.id, ...data[0] }),
        destroy: (...item) => xoaPhieuThuPhanUngThuoc(this.id, ...item),
        update: (...data) => updatePhieuThuPhanUngThuoc(this.id, ...data, data)
      };
    },
  },
  methods: {},
};
</script>
<style>

</style>
