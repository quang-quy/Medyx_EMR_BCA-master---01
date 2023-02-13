<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    primaryKey="idba"
    label-width="100px"
    title="Danh mục nhân viên"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail, update, detroy } from "@/api/nhan-vien";
import { formatDate } from "@/utils/formatters";
export default {
  components: {
    Crud,
  },

  data() {
    return {
      fields: [
        // //Filter
        {
          text: "Tìm kiếm theo tên",
          filterable: true,
          value: "search",
          useCategory: "tenKhoa",
          type: "text",
          multiple: true,
        },
        {
          text: "Mã chức vụ",
          filterable: true,
          value: "buongs",
          useCategory: "buong",
          type: "select",
          multiple: true,
        },
        // {
        //   text: "Trạng thái hủy",
        //   filterable: true,
        //   value: "tenCD",
        //   useCategory: "tenCD",
        //   type: "select",
        //   multiple: true,
        // },
        // {
        //   text: "Ngày sử dụng",
        //   filterable: true,
        //   value: "ngaySD",
        //   useCategory: "ngaySD",
        //   type: "date",
        //   multiple: true,
        // },

        // {
        //   text: "",
        //   sortable: true,
        //   showable: true,
        //   value: "",
        //   formatter: function (_, __, value) {
        //     return formatDate(value);
        //   },
        //   width: 200,
        // },
        {
          text: "Mã nhân viên",
          sortable: true,
          showable: true,
          value: "maNv",
          type: "text",
          width: 200,
        },
        {
          text: "Họ tên",
          value: "hoTen",
          showable: true,
          sortable: true,
          type: "text",
          width: 200,
        },
        {
          text: "Tên tắt",
          value: "tenTat",
          showable: true,
          sortable: true,
          type: "text",
          width: 200,
        },
        {
          text: "Mã chức vụ",
          showable: true,
          value: "maChucVu",
          type: "text",
          width: 200,
        },
        {
          text: "Mã loại hợp đồng",
          sortable: true,
          showable: true,
          value: "maLoaiHd",
          width: 200,
          type: "text",
        },
        // {
        //   text: "Ngày sử dụng",
        //   sortable: true,
        //   showable: true,
        //   value: "ngaySd",
        //    formatter: function (_, __, value) {
        //     return formatDate(value);
        //   },
        //   width: 200,
        // },
        {
          text: "Mã chuyên môn",
          sortable: true,
          showable: true,
          value: "maChuyenMon",
          width: 200,
          type: "text",
        },
        {
          text: "Mã khoa",
          sortable: true,
          showable: true,
          value: "maKhoa",
          width: 200,
          type: "text",
        },
        {
          text: "Mã chứng chỉ nghề",
          sortable: true,
          showable: true,
          value: "maChungChiHanhNghe",
          width: 200,
          type: "text",
        },
        {
          text: "Bệnh án khoa điều trị",
          sortable: true,
          showable: true,
          value: "benhAnKhoaDieuTris",
          width: 200,
          type: "text",
        },
        // dang anh
        {
          text: "Chữ ký",
          sortable: true,
          showable: true,
          value: "chuky",
          width: 200,
          type: "text",
        },
        {
          text: "Điện thoại",
          sortable: true,
          showable: true,
          value: "dienThoai",
          width: 200,
          type: "text",
        },
        {
          text: "Điện thoại khoa",
          sortable: true,
          showable: true,
          value: "dienThoaiKhoa",
          width: 200,
          type: "text",
        },
        {
          text: "Trạng thái hủy",
          sortable: true,
          showable: true,
          value: "huy",
          width: 200,
          type: "text",
        },
        {
          text: "Mã chức danh",
          sortable: true,
          showable: true,
          value: "maCd",
          width: 200,
          type: "text",
        },
        {
          text: "Mã máy",
          sortable: true,
          showable: true,
          value: "maMay",
          width: 200,
          type: "text",
        },
        {
          text: "ngaySd",
          sortable: true,
          showable: true,
          value: "ngaySd",
          width: 200,
          formatter: function (_, __, value) {
            return formatDate(value);
          },
        },
        {
          text: "ngaySd1",
          sortable: true,
          showable: true,
          value: "ngaySd1",
          width: 200,
          formatter: function (_, __, value) {
            return formatDate(value);
          },
        },
        {
          text: "Người giám hộ",
          sortable: true,
          showable: true,
          value: "nguoiGiamHo",
          width: 200,
          type: "text",
        },
      ],
      apiCategoryFunctions: {},
      apiCrudFunctions: {
        index,
        detail,
        update,
        detroy,
      },
      actions: ["edit", "delete"],
    };
  },
};
</script>
