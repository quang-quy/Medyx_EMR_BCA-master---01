<template>
  <app-wrapper :idba="id">
    <div class="pa-2">
      <div class="flex-grow-1 mb-2">
        <form-option
          :fields="fields"
          :actions="actions"
          :dataForm="data"
          @save="handleSave"
          @print="handlePrint"
          :idba="id"
        ></form-option>
      </div>
    </div>
  </app-wrapper>
</template>

<script>
import Crud from "@/components/crud/Index.vue";
import formOption from "./components/formOptions.vue";
import { formatDatetime } from "@/utils/formatters";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import * as ApiPhacDo from "@/api/phac-do-dieu-tri.js";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  components: {
    Crud,
    formOption,
  },
  props: {
    id: {
      type: [Number, String],
    },
    stt: {
      type: [Number, String],
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data(vm) {
    return {
      currentUser: JSON.parse(localStorage.getItem("currentUser")),
      fields: [
        {
          label: "Khoa",
          type: "select-async",
          fromValue: "sttkhoa",
          placeholder: "Chọn khoa",
          action: true,
          keyValue: "stt",
          apiFunc: vm.getBenhAnKhoaDieuTris,
          labelselect: (item) =>
            `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
              item.ngayVaoKhoa
            )}`,
          value: "Sttkhoa",
        },
        {
          label: "Tên bác sỹ điều trị",
          type: "text",
          fromValue: "bs",
          placeholder: "Tên bác sỹ điều trị",
          action: false,
          value: "bsDieuTri",
        },
        {
          label: "Mã bệnh",
          type: "select-async",
          fromValue: "maBenh",
          placeholder: "Mã bệnh",
          keyValue: "maBenh",
          apiFunc: ApiPhacDo.dsBenhs,
          labelselect: (item) => `${item.maBenh}-${item.tenBenh}`,
          action: true,
          value: "maBenh",
        },
        {
          label: "Tên bệnh",
          type: "textarea",
          fromValue: "tenBenh",
          placeholder: "Nhập tên bệnh",
          action: true,
          value: "tenBenh",
        },
        {
          label: "Giai đoạn bệnh",
          type: "textarea",
          fromValue: "giaiDoan",
          placeholder: "Giai đoạn bệnh",
          action: true,
          value: "giaiDoan",
        },
        {
          label: "Ngày áp dụng phác đồ",
          type: "date",
          fromValue: "ngayAdphacDo",
          placeholder: "Ngày áp dụng phác đồ",
          action: true,
          value: "ngayAdphacDo",
        },
        {
          label: "Giới tính áp dụng",
          type: "radio",
          fromValue: "gioiTinh",
          placeholder: "Giới tính áp dụng",
          action: true,
          value: "gioiTinh",
          category: [
            {
              text: "Nam",
              value: 1,
            },
            {
              text: "Nữ",
              value: 2,
            },
            {
              text: "Nam và nữ",
              value: 3,
            },
          ],
        },
        {
          label: "Độ tuổi áp dụng từ",
          type: "number",
          fromValue: "doTuoiTu",
          placeholder: "Độ tuổi áp dụng từ",
          action: true,
          value: "doTuoiTu",
        },
        {
          label: "Độ tuổi áp dụng đến",
          type: "number",
          fromValue: "doTuoiDen",
          placeholder: "Độ tuổi áp dụng đến",
          action: true,
          value: "doTuoiDen",
        },
        {
          label: "Vùng áp dụng",
          type: "textarea",
          fromValue: "vungApDung",
          placeholder: "Vùng áp dụng",
          action: true,
          value: "vungApDung",
        },
        {
          label: "Mô tả bệnh",
          type: "textarea",
          fromValue: "moTa",
          placeholder: "Mô tả bệnh",
          action: true,
          value: "moTa",
        },
        {
          label: "Xử trí",
          type: "textarea",
          fromValue: "xuTri",
          placeholder: "Xử trí",
          action: true,
          value: "xuTri",
        },
        {
          label: "Tình trạng người bệnh trước phác đồ",
          type: "textarea",
          fromValue: "truocPhacDo",
          placeholder: "Tình trạng người bệnh trước phác đồ",
          action: true,
          value: "truocPhacDo",
        },
        {
          label: "Tình trạng người bệnh sau phác đồ",
          type: "textarea",
          fromValue: "sauPhacDo",
          placeholder: "Tình trạng người bệnh sau phác đồ",
          action: true,
          value: "sauPhacDo",
        },
        {
          label: "Hủy",
          type: "boolean",
          fromValue: "huy",
          action: JSON.parse(localStorage.getItem("currentUser")).is_admin,
          value: "huy",
        },
      ],
      actions: [
        {
          title: "Lưu phác đồ",
          type: "success",
          event: "save",
          icon: "mdi-pencil",
          action: vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/PhacDoDieuTri/modify"
          )
            ? true
            : false,
        },
        {
          title: "In phác đồ",
          icon: "mdi-printer",
          type: "primary",
          event: "print",
          icon: "mdi-printer",
          action: vm.permission.find(
            (e) => e.ActionDetailsName == "/HSBA/PhacDoDieuTri/export"
          )
            ? true
            : false,
        },
      ],
      data: {},
      edit: true,
    };
  },
  created() {
    this.getData();
  },
  methods: {
    async getData() {
      const { data } = await ApiPhacDo.show(this.id, this.stt);
      if (data) {
        this.data = data;
      } else {
        this.edit = false;
      }
    },
    async getNhanViens(params) {
      return await getNhanVien(params);
    },
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.id,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
    async handleSave(data) {
      const { statusCode } = await ApiPhacDo.update(this.id, this.stt, data);
      this.handleNotify(statusCode, "Cập nhật");
    },
    async handlePrint(data) {
      await ApiPhacDo.print(this.id, this.stt);
    },
    handleNotify(statusCode = true, action = null) {
      if (statusCode == 200) {
        this.getData();
        this.$message.success(`${action} sơ kết thành công !`);
      } else {
        this.$message.error(`${action} sơ kết lỗi !`);
      }
    },
  },
  computed: {
    apiCrudFunctions() {
      return {};
    },
  },
};
</script>

<style lang="scss" scoped></style>
