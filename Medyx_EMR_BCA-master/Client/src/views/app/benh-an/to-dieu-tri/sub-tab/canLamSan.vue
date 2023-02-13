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
    :title="title"
    ref="table"
  >
    <template #slot-header>
      <div class="mb-2 mt-3">
        <div class="d-flex">
          <div>
            <div class="body-2 my-2 font-weight-bold">
              5.1 Danh sách gói cận lâm sàng
            </div>
            <base-select-async
              v-model="canLamSan"
              :label="(item) => `${item.maGoi} - ${item.tenGoi}`"
              keyValue="maGoi"
              :disabled="
                !permission.find(
                  (e) =>
                    e.ActionDetailsName == '/HSBA/todieutri/canlamsang/create'
                )
              "
              :apiFunc="getCanLamSans"
              placeholder="Chọn gói"
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
  store,
  update,
  destroy,
  storeGoiCls,
  ds_GoiCanLamSans,
  ds_dVCanLamSans,
} from "@/api/benhAnToDieuTri/can-lam-san";
import layoutOption from "../components/layout-option.vue";
import Crud from "@/components/crud/Index.vue";
import { getNhanVien } from "@/api/to-dieu-tri";
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
    canLamSan: {
      handler: function (newVal) {
        this.addCLs(newVal);
      },
      immediate: true,
    },
  },
  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    canLamSan: null,
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
        width: 200,
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
          apiFunc: ds_dVCanLamSans,
        },
      },
      {
        text: "Đơn vị tính",
        type: "text",
        sortable: true,
        showable: true,
        filterable: false,
        value: "dichVu.donViDo",
        searchValue: "donViDo",
        width: 120,
        align: "center",
      },
      {
        text: "Cấp cứu",
        value: "capcuu",
        searchValue: "capcuu",
        showable: true,
        filterable: false,
        filterValue: "capcuu",
        type: "bit",
        width: 120,
        sortable: true,
        formatter: function (_, __, value) {
          if (value) return true;
          else return false;
        },
        align: "center",
        form: {
          value: "capCuuBoolean",
          fromValue: "capcuu",
          default: 0,
          type: "bit",
          creatable: true,
          editable: true,
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
        width: 120,
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
        width: 170,
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
        width: 120,
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
        width: 120,
        sortable: true,
      },
      {
        text: "Người hủy",
        type: "text",
        showable: true,
        filterable: false,
        value: "nguoiHuy.hoTen",
        searchValue: "nguoiHuy",
        width: 170,
        sortable: true,
      },
    ],
    apiCategoryFunctions: {},
    actions: ["delete", "edit", "create"],
    disableActions: {
      edit: (item) =>
        (item.huy && !vm.currentUser.is_admin) ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/canlamsang/modify"
        ),
      delete: (item) =>
        item.huy ||
        !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/todieutri/canlamsang/delete"
        ),
    },
  }),
  created() {},
  methods: {
    async getCanLamSans(params) {
      return await ds_GoiCanLamSans(params);
    },
    async addCLs(code) {
      try {
        if (!code) return;
        const res = await this.$confirm(
          "Xác nhận thêm gói cận lâm sàn có mã là : " + code,
          {
            title: "Xác nhận thêm gói cận lâm sàn",
            buttonTrueText: "Đồng ý",
            buttonFalseText: "Hủy",
          }
        );
        if (res) {
          this.$loader(true);
          const resAdd = await storeGoiCls({
            maGoi: code,
            sttkhoa: this.dataDetail.sttkhoa,
            ...this.params,
          });
          if (resAdd.statusCode == 200) {
            this.canLamSan = null;
            this.$message.success("Thêm gói cận lâm sàn thành công");
            this.$refs.table.reset();
          } else {
            this.$message.error("Thêm gói cận lâm sàn thất bại");
          }
          this.$loader(false);
        } else {
          return;
        }
      } catch (error) {
        this.$message.error("Lỗi : " + error);
      }
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
          store({ sttKhoa: vm.dataDetail.sttkhoa, ...data, ...vm.params }),
        update: (...data) => update(vm.params.idba, ...data),
        destroy: (...item) => destroy(vm.params.idba, ...item),
      };
    },
  },
};
</script>
