<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    primaryKey="idba"
    label-width="100px"
    title="Danh sách bệnh án"
  />
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import { index, getLoaiBenhAn, getKhoa } from "@/api/benh-an";
import { formatDate } from "@/utils/formatters";
export default {
  components: {
    Crud,
  },

  data() {
    return {
      fields: [
        {
          text: "Stt",
          sortable: true,
          showable: true,
          value: "stt",
        },
        {
          text: "Tên hồ sơ",
          sortable: true,
          showable: true,
          value: "nameHS",
        },
      ],
      apiCrudFunctions: {
        index: () =>
          Promise.resolve({
            data: [
              {
                stt: 1,
                nameHS: "Hồ sơ 1",
              },
              {
                stt: 2,
                nameHS: "Hồ sơ 2",
              },
              {
                stt: 3,
                nameHS: "Hồ sơ 3",
              },
              {
                stt: 4,
                nameHS: "Hồ sơ 4",
              },
            ],
            meta: {
              totalRecords: 0,
              pageNumber: 1,
              pageSize: 10,
            },
          }),
      },
      apiCategoryFunctions: {
        loaiBenhAn: {
          func: getLoaiBenhAn,
          textField: "tenLoaiBa",
          valueField: "maLoaiBa",
        },
        khoa: {
          func: getKhoa,
          textField: "maKhoa",
          valueField: "maKhoa",
          codeField: "tenKhoa",
        },
      },
      actions: ["edit", "delete", "detail:/HSBADS/HoSoBenhAn/:id"],
    };
  },
};
</script>
