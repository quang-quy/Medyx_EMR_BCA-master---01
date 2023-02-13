<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    primaryKey="idba"
    label-width="100px"
    title="Danh mục bệnh tật YHCT"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail, update, detroy } from "@/api/benh-tat-yhct";
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
          text: "Tên loại",
          filterable: true,
          value: "buongs",
          useCategory: "buong",
          type: "select",
          multiple: true,
        },
        {
          text: "Tên chương",
          filterable: true,
          value: "tenCv",
          useCategory: "tenCv",
          type: "select",
          multiple: true,
        },
        {
          text: "Tên nhóm chính",
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
          text: "Tên chương",
          sortable: true,
          showable: true,
          value: "chapterName",
          type: "text",
          width: 200,
        },
        {
          text: "diseaseName",
          value: "diseaseName",
          showable: true,
          sortable: true,
          type: "text",
          width: 200,
        },
        {
          text: "Mã bệnh",
          showable: true,
          value: "maBenh",
          type: "text",
          width: 200,
        },
        {
          text: "Mã bệnh không dấu",
          showable: true,
          value: "maBenhKhongdau",
          type: "text",
          width: 200,
        },
        {
          text: "Mã Chương",
          showable: true,
          value: "maChuong",
          type: "text",
          width: 200,
        },
        {
          text: "Mã loại",
          showable: true,
          value: "maLoai",
          type: "text",
          width: 200,
        },
        {
          text: "Mã Nhóm Bcbyt",
          showable: true,
          value: "maNhomBcbyt",
          type: "text",
          width: 200,
        },
        {
          text: "Mã nhóm chính",
          showable: true,
          value: "maNhomChinh",
          type: "text",
          width: 200,
        },
        {
          text: "Mã nhóm có chi tiết",
          showable: true,
          value: "maNhomCoChiTiet",
          type: "text",
          width: 200,
        },
        {
          text: "Mã nhóm phụ 1",
          showable: true,
          value: "maNhomPhu1",
          type: "text",
          width: 200,
        },
        {
          text: "Mã nhóm phụ 2",
          showable: true,
          value: "maNhomPhu2",
          type: "text",
          width: 200,
        },
        {
          text: "mainGroupName1",
          showable: true,
          value: "mainGroupName1",
          type: "text",
          width: 200,
        },
        {
          text: "Stt chương",
          showable: true,
          value: "sttchuong",
          type: "text",
          width: 200,
        },
        {
          text: "subGroupName1",
          showable: true,
          value: "subGroupName1",
          type: "text",
          width: 200,
        },
        {
          text: "subGroupName2",
          showable: true,
          value: "subGroupName2",
          type: "text",
          width: 200,
        },
        {
          text: "Tên bệnh",
          showable: true,
          value: "tenBenh",
          type: "text",
          width: 200,
        },
        {
          text: "Tên chương",
          showable: true,
          value: "tenChuong",
          type: "text",
          width: 200,
        },
        {
          text: "Tên loại",
          showable: true,
          value: "tenLoai",
          type: "text",
          width: 200,
        },
        {
          text: "Tên nhóm chính",
          showable: true,
          value: "tenNhomChinh",
          type: "text",
          width: 200,
        },
        {
          text: "Tên nhóm phụ 1",
          showable: true,
          value: "tenNhomPhu1",
          type: "text",
          width: 200,
        },
        {
          text: "Tên nhóm phụ 2",
          showable: true,
          value: "tenNhomPhu2",
          type: "text",
          width: 200,
        },
        {
          text: "Loại",
          showable: true,
          value: "typeName",
          type: "text",
          width: 200,
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
