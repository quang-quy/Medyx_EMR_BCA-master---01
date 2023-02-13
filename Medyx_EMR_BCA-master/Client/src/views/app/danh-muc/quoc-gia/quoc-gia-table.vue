<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    primaryKey="idba"
    label-width="100px"
    title="Danh mục quốc gia"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, detail, update, detroy } from "@/api/quoc-gia";
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
          value: "tenCD",
          useCategory: "tenCD",
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
          text: "Mã ",
          sortable: true,
          showable: true,
          value: "maCd",
          type: "text",
          width: 200,
        },
        {
          text: "Tên",
          value: "tenCd",
          showable: true,
          sortable: true,
          type: "text",
          width: 200,
        },
        {
          text: "Mã máy",
          showable: true,
          value: "maMay",
          type: "text",
          width: 200,
        },
        {
          text: "Trạng thái hủy",
          sortable: true,
          showable: true,
          value: "huy",
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
