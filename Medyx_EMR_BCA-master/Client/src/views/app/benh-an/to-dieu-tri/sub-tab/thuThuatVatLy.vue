<template>
  <Crud
    :fields="fields"
    :apiCrudFunctions="apiCrudFunctions"
    :apiCategoryFunctions="apiCategoryFunctions"
    :actions="actions"
    :disableActions="disableActions"
    primaryKey="stt"
    label-width="100px"
    tableHeight="400px"
    :wrapper="false"
    onlyTable
    :hasExit="false"
    ref="table"
    :title="title"
  >
    <template #slot-header>
      <div class="mb-2">
        <div class="d-flex">
          <div>
            <div class="body-2 my-2 font-weight-bold">
              4.1 Danh sách gói thủ thuật
            </div>
            <base-select-async
              v-model="goithuThuat"
              :label="(item) => `${item.maGoi} - ${item.tenGoi}`"
              keyValue="maBthuoc"
              :apiFunc="ds_dichVuGois"
              placeholder="Chọn gói"
              :disabled="
                !permission.find(
                  (e) =>
                    e.ActionDetailsName == '/HSBA/todieutri/thuthuatvltl/create'
                )
              "
            >
            </base-select-async>
          </div>
        </div>
      </div>
    </template>
  </Crud>
</template>

<script>
import { formatDate, formatDatetime } from "@/utils/formatters";
import {
  index,
  update,
  destroy,
  store,
  storeGoi,
  ds_dichVuGoiTTVL,
  ds_dichVuTTVL,
} from "@/api/benhAnToDieuTri/thu-thuat-vat-ly";
import Crud from "@/components/crud/Index.vue";
import layoutOption from "../components/layout-option.vue";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  components: {
    Crud,
    layoutOption,
  },
  props: {
    title: {
      type: String,
      default: "Danh sách",
    },
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
    goithuThuat: {
      handler: function (newVal) {
        this.addVltl(newVal);
      },
      immediate: true,
    },
  },
  data: (vm) => ({
    goithuThuat: null,
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    fields: [
      {
        text: "STT",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "stt",
        searchValue: "stt",
        width: 70,
        align: "center",
      },
      {
        text: "Mã dịch vụ",
        value: "dichVu.maDv",
        searchValue: "maDv",
        showable: true,
        filterable: false,
        filterValue: "maDv",
        type: "text",
        width: 120,
        sortable: true,
        align: "center",
      },
      {
        text: "Tên dịch vụ",
        value: "dichVu.tenDv",
        searchValue: "tenDv",
        showable: true,
        filterable: false,
        filterValue: "tenDv",
        type: "text",
        width: 250,
        sortable: true,
        form: {
          value: "maDv",
          fromValue: "dichVu.maDv",
          default: null,
          creatable: true,
          editable: true,
          type: "select-async",
          label: (item) => item.maDv + "-" + item.tenDv,
          keyValue: "maDv",
          apiFunc: ds_dichVuTTVL,
        },
      },
      // {
      //   text: "Đơn vị đo",
      //   type: "text",
      //   sortable: true,
      //   showable: true,
      //   filterable: false,
      //   value: "dichVu.donViDo",
      //   searchValue: "dichVu.donViDo",
      //   width: 120,
      //   align: "center",
      // },
      {
        text: "Số lượng",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "soLuong",
        searchValue: "soLuong",
        width: 120,
        align: "center",
        form: {
          value: "soLuong",
          fromValue: "soLuong",
          default: 1,
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
        text: "Vị trí",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "viTri",
        searchValue: "viTri",
        width: 400,
        form: {
          value: "viTri",
          fromValue: "viTri",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
          placeholder: "Vị trí",
        },
      },
      {
        text: "Thời gian",
        value: "thoiGian",
        width: 170,
        sortable: true,
        filter: null,
        align: "center",
        // formatter: function (_, __, value) {
        //   return formatDatetime(value);
        // },
        form: {
          value: "thoiGian",
          fromValue: "thoiGian",
          default: null,
          type: "text",
          creatable: true,
          editable: true,
          placeholder: "vd: 1h,2h ...",
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
        filterValue: "nguoiLap",
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
        width: 170,
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
        value: "nguoihuy.hoTen",
        searchValue: "nguoihuy",
        width: 170,
        sortable: true,
      },
    ],
    apiCategoryFunctions: {},
    actions: ["edit", "delete", "create"],
    disableActions: {
      edit: (item) =>
        (item.huy && !vm.currentUser.is_admin) ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/thuthuatvltl/modify"
        ),
      delete: (item) =>
        item.huy ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/thuthuatvltl/delete"
        ),
    },
  }),
  created() {},
  methods: {
    async ds_dichVuGois(params) {
      return await ds_dichVuGoiTTVL(params);
    },
    async addVltl(code) {
      this.$loader(true);
      try {
        if (!code) return;
        const res = await this.$confirm(
          "Xác nhận thêm gói vật lý trị liệu có mã là : " + code,
          {
            title: "Xác nhận thêm gói vật lý trị liệu",
            buttonTrueText: "Đồng ý",
            buttonFalseText: "Hủy",
          }
        );
        if (res) {
          let resAdd = await storeGoi({
            sttkhoa: this.dataDetail.sttkhoa,
            maGoi: code,
            ...this.params,
          });
          if (resAdd.statusCode == 200) {
            this.goithuThuat = null;
            this.$message.success("Thêm gói vật lý trị liệu thành công");
            this.$refs.table.reset();
          } else {
            this.$message.error("Thêm gói vật lý trị liệu thất bại");
          }
        }
      } catch (error) {
        this.$message.error("Lỗi : " + error);
      }

      this.$loader(false);
    },
  },
  computed: {
    apiCrudFunctions() {
      const vm = this;
      return {
        index: (params) => {
          if (vm.currentUser.is_admin) {
            return index({...vm.params , ...params});
          } else {
            return index({ ...params,...vm.params, huy: false });
          }
        },
        store: (data) =>
          store({ sttKhoa: vm.dataDetail.sttkhoa, ...vm.params, ...data }),

        update: (...data) => update(vm.params.idba, ...data),

        destroy: (...item) => destroy(vm.params.idba, ...item),
      };
    },
  },
};
</script>
