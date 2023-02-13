<template>
  <app-wrapper
    :benhAn="false"
    :showTenBenhAn="false"
    :showThongTinChungBenhAn="false"
  >
    <Crud
      :fields="fields"
      :apiCrudFunctions="apiCrudFunctions"
      :apiCategoryFunctions="apiCategoryFunctions"
      :actions="actions"
      :customFormFields="customFormFields"
      :headerComponent="headerComponent"
      :disableActions="disableActions"
      primaryKey="idba"
      label-width="100px"
      tableHeight="calc(100vh - 310px)"
      title="Danh sách bệnh án"
      :wrapper="false"
      :permission="permission"
    />
  </app-wrapper>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
    //import { index, getLoaiBenhAn, getKhoa, destroy } from "@/api/benh-an";
    import { index, getLoaiBenhAn, GetByAccount, destroy } from "@/api/benh-an";
import { formatDate, formatDatetime } from "@/utils/formatters";
import AppWrapper from "../../../../components/AppWrapper.vue";
import Header from "./Header.vue";
import KhoaBuongGiuongSelection from "@/components/crud/custom-fields/KhoaBuongGiuongSelection";
export default {
  props: {
    permission: { type: Array, default: () => [] },
  },
  components: {
    Crud,
    AppWrapper,
  },
  data: (vm) => ({
    customFormFields: KhoaBuongGiuongSelection,
    headerComponent: Header,
    fields: [
      // column filter hiden
      {
        text: "Loại bệnh án",
        hidden: true,
        filter: {
          value: "loaiBenhAn",
          default: null,
          type: "select",
          useCategory: "loaiBenhAn",
          multiple: true,
          placeholder: "Loại bệnh án",
        },
      },
      {
        text: "Khoa phòng",
        hidden: true,
        filter: {
          value: "maKhoa",
          default: null,
          type: "select",
          useCategory: "khoa",
          multiple: true,
          placeholder: "Khoa phòng",
        },
      },
      {
        text: "Ngày vào viện từ ngày",
        hidden: true,
        filter: {
          value: "tuNgayVaoVien",
          default: vm.startMonth(),
          type: "datetime",
          placeholder: "Ngày vào viện từ ngày",
        },
      },
      {
        text: "Ngày vào viện đến ngày",
        hidden: true,
        filter: {
          value: "denNgayVaoVien",
          default: vm.currenTime(),
          type: "datetime",
          placeholder: "Ngày vào viện đến ngày",
        },
      },
      {
        text: "Ngày ra viện từ ngày",
        hidden: true,
        filter: {
          value: "tuNgayRaVien",
          default: null,
          type: "datetime",
          placeholder: "Ngày ra viện từ ngày",
        },
      },
      {
        text: "Ngày ra viện đến ngày",
        hidden: true,
        filter: {
          value: "denNgayRaVien",
          default: null,
          type: "datetime",
          placeholder: "Ngày ra viện đến ngày",
        },
      },
      {
        text: "Đã đóng hồ sơ",
        value: "xacNhanKetThucHs",
        type: "bit",
        width: 110,
        sortable: false,
        searchValue: "idba",
        formatter: null,
        filter: null,
        align: "center",
      },
      {
        text: "IDBA",
        value: "idba",
        width: 80,
        sortable: true,
        searchValue: "idba",
        formatter: null,
        filter: null,
        align: "center",
      },
      {
        text: "Số vào viện",
        value: "soVaoVien",
        width: 130,
        sortable: true,
        searchValue: "soVaoVien",
        formatter: null,
        filter: null,
      },
      {
        text: "Mã người bệnh",
        value: "benhNhan.maBn",
        width: 140,
        sortable: true,
        searchValue: "idba",
        formatter: null,
        filter: null,
      },
      {
        text: "Họ tên người bệnh",
        value: "benhNhan.hoTen",
        width: 160,
        sortable: true,
        searchValue: "tenBenhNhan",
        formatter: null,
        filter: null,
      },
      {
        text: "Tuổi",
        value: "benhNhan.tuoi",
        width: 75,
        sortable: true,
        align: "right",
        searchValue: "tuoiBenhNhan",
        formatter: null,
        filter: null,
        form: {
          value: "tuoi",
          fromValue: "benhNhan.tuoi",
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
              validator: (v) => v > 5,
              message: "Trường này bắt buộc lớn hơn 5",
            },
          ],
        },
      },
      {
        text: "Năm sinh",
        value: "benhNhan.ngaySinh",
        width: 130,
        sortable: true,
        searchValue: "ngaySinhBenhNhan",
        filter: null,
        formatter: function (_, __, value) {
          return formatDate(value);
        },
      },
      {
        text: "Giới tính",
        value: "benhNhan.gioiTinh",
        width: 100,
        sortable: true,
        searchValue: "gioiTinh",
        filter: null,
        formatter: function (_, __, value) {
          return value == 2 ? "Nữ" : "Nam";
        },
      },
      {
        text: "Khoa vào viện",
        value: "khoa.tenKhoa",
        width: 200,
        sortable: true,
        searchValue: "tenKhoa",
        formatter: null,
        filter: null,
        // form: {
        //   value: "maKhoa",
        //   fromValue: "khoa.maKhoa",
        //   default: null,
        //   useCategory: "khoa",
        //   type: "select",
        //   creatable: true,
        //   editable: true,
        // },
      },
      {
        text: "Số buồng",
        value: "buong.tenBuong",
        width: 110,
        sortable: true,
        align: "right",
        searchValue: "tenBuong",
        formatter: null,
        filter: null,
        // form: {
        //   value: "maBuong",
        //   fromValue: "buong.maBuong",
        //   default: null,
        //   type: "custom",
        //   creatable: true,
        //   editable: true,
        // },
      },
      {
        text: "Số giường",
        value: "giuong.tenGiuong",
        width: 110,
        sortable: true,
        align: "right",
        searchValue: "tenGiuong",
        formatter: null,
        filter: null,
        // form: {
        //   value: "maGiuong",
        //   fromValue: "giuong.maGiuong",
        //   default: null,
        //   type: "custom",
        //   creatable: true,
        //   editable: true,
        // },
      },
      {
        text: "Ngày giờ vào viện",
        value: "ngayVv",
        width: 150,
        sortable: true,
        formatter: function (_, __, value) {
          return formatDatetime(value);
        },
        filter: null,
      },
      {
        text: "Ngày giờ ra viện",
        value: "ngayRv",
        width: 150,
        sortable: true,
        formatter: function (_, __, value) {
          return formatDatetime(value);
        },
        filter: null,
      },
      {
        text: "Địa chỉ",
        value: "benhNhan",
        width: 400,
        sortable: true,
        searchValue: "diaChiBenhNhan",
        filter: null,
        formatter: function (_, __, value) {
          return `
          ${value.soNha ? value.soNha + "," : ""} 
          ${value.quanHuyen.tenQh ? value.quanHuyen.tenQh : ""} 
          ${value.phuongXa.tenPxa ? "," + value.phuongXa.tenPxa : ""}
          ${value.tinh.tenTinh ? "," + value.tinh.tenTinh : ""} 
          ${value.quocGia.tenQg ? "," + value.quocGia.tenQg : ""}`;
        },
      },
      {
        text: "Mã YT",
        value: "maYt",
        width: 120,
        sortable: true,
        searchValue: "maYt",
        formatter: null,
        filter: null,
      },
      {
        text: "Số lưu trữ",
        value: "soLuuTru",
        width: 120,
        sortable: true,
        searchValue: "soLuuTru",
        formatter: null,
        filter: null,
      },
      {
        text: "Ngày lập",
        value: "ngayLap",
        searchValue: "ngayLap",
        width: 150,
        sortable: true,
        formatter: function (_, __, value) {
          return formatDate(value);
        },
        filter: null,
      },
      {
        text: "Người lập",
        value: "nguoiLap.hoTen",
        width: 150,
        sortable: true,
        searchValue: "nguoiLap",
        formatter: null,
        filter: null,
      },
      {
        text: "Hủy",
        value: "huy",
        width: 100,
        sortable: false,
        searchValue: "huy",
        type: "boolean",
        align: "center",
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
        value: "ngayHuy",
        width: 150,
        sortable: false,
        formatter: function (_, __, value) {
          return formatDate(value);
        },
        filter: null,
      },
      {
        text: "Người hủy",
        value: "nguoiHuy.hoTen",
        width: 150,
        sortable: true,
        searchValue: "nguoiHuy",
        formatter: null,
        filter: null,
      },
    ],
    apiCrudFunctions: {
      index: (params) => index({ ...params, xacNhanLuuTru: 0 }),
      destroy,
    },
    apiCategoryFunctions: {
      loaiBenhAn: {
        func: getLoaiBenhAn,
        textField: "tenLoaiBa",
        valueField: "maLoaiBa",
      },
      khoa: {
        //func: getKhoa,
          func: GetByAccount,
        textField: "maKhoa",
        valueField: "maKhoa",
        codeField: "tenKhoa",
      },
    },
    actions: [
      "delete",
      // "edit",
      // "create",
      // "print",
      "detail:/HSBADS/ThongTinBenhAn/:idba",
    ],
    disableActions: {
      delete: (item) => item.huy || item.xacNhanKetThucHs,
      create: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/thongtinbenhan/create"
      ),
    },
  }),
  methods: {
    startMonth() {
      const date = new Date();
      return (
        new Date(
          date.getFullYear(),
          date.getMonth(),
          1,
          0,
          0
        ).toLocaleDateString("en-CA") +
        " " +
        "00:00:00"
      );
    },
    currenTime() {
      return (
        new Date().toLocaleDateString("en-CA") +
        " " +
        new Date().toLocaleTimeString("en-GB")
      );
    },
  },
};
</script>
