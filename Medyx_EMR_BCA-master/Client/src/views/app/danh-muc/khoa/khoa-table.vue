<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    primaryKey="idba"
    label-width="100px"
    title="Danh mục khoa"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail, update, detroy } from "@/api/khoa";
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
          text: "Tìm kiếm",
          filterable: true,
          value: "search",
          useCategory: "tenKhoa",
          type: "text",
          multiple: true,
        },
        {
          text: "Mã chức danh",
          filterable: true,
          value: "buongs",
          useCategory: "buong",
          type: "select",
          multiple: true,
        },
        {
          text: "Trạng thái hủy",
          filterable: true,
          value: "tenCv",
          useCategory: "tenCv",
          type: "select",
          multiple: true,
        },
        {
          text: "Ngày sử dụng",
          filterable: true,
          value: "ngaySD",
          useCategory: "ngaySD",
          type: "date",
          multiple: true,
        },

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
          text: "Mã khoa",
          sortable: true,
          showable: true,
          value: "maKhoa",
          type: "text",
          width: 200,
        },
        {
          text: "Tên khoa",
          value: "tenKhoa",
          showable: true,
          sortable: true,
          type: "text",
          width: 200,
        },
        {
          text: "Địa điểm",
          showable: true,
          value: "diaDiem",
          type: "text",
          width: 200,
        },
        {
          text: "loại",
          sortable: true,
          showable: true,
          value: "loai",
          width: 200,
          type: "boolean",
        },
        {
          text: "Mã byt",
          sortable: true,
          showable: true,
          value: "maByt",
          width: 200,
          type: "boolean",
        },
        {
          text: "Ghi chú",
          sortable: true,
          showable: true,
          value: "ghichu",
          width: 200,
          type: "boolean",
        },
        {
          text: "Bệnh án khoa điểu trị",
          sortable: true,
          showable: true,
          value: "benhAnKhoaDieuTris",
          width: 200,
          type: "boolean",
        },
        {
          text: "Bệnh án",
          sortable: true,
          showable: true,
          value: "benhAns",
          width: 200,
          type: "boolean",
        },
        {
          text: "Mã máy",
          sortable: true,
          showable: true,
          value: "maMay",
          width: 200,
          type: "boolean",
        },
        {
          text: "Mã nhân viên điều dưỡng trưởng",
          sortable: true,
          showable: true,
          value: "maNvdieuDuongTruong",
          width: 200,
          type: "boolean",
        },
        {
          text: "Mã nhân viên trưởng khoa",
          sortable: true,
          showable: true,
          value: "maNvtruongKhoa",
          width: 200,
          type: "boolean",
        },
        {
          text: "Ngày sử dụng",
          sortable: true,
          showable: true,
          value: "ngaySd",
          formatter: function (_, __, value) {
            return formatDate(value);
          },
          width: 200,
        },
        {
          text: "Người sử dụng",
          sortable: true,
          showable: true,
          value: "nguoiSd",
          width: 200,
          type: "boolean",
        },
        {
          text: "Số giường",
          sortable: true,
          showable: true,
          value: "sogiuong",
          width: 200,
          type: "boolean",
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
