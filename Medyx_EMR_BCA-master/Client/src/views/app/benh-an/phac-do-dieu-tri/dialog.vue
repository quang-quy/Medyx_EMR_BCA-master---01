<template>
  <el-dialog :visible.sync="dialog" width="1050px">
    <template slot="title">
      <div class="px-3">
        <div style="font-size: 16px; font-weight: bold" class="mb-3">
          Thêm mới phác đồ điều trị
        </div>
        <v-progress-linear
          color="primary"
          rounded
          value="100"
          height="2"
        ></v-progress-linear>
      </div>
    </template>
    <!-- form -->
    <form-option
      :create="true"
      :dataForm="data"
      :fields="fields"
      :actions="actions"
      :idba="idba"
      @create="handleCreate"
    >
    </form-option>
  </el-dialog>
</template>
<script>
import dialogMixin from "@/mixins/crud/dialog";
import formOption from "./components/formOptions";
import * as ApiPhacDo from "@/api/phac-do-dieu-tri.js";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { formatDatetime } from "@/utils/formatters";
export default {
  mixins: [dialogMixin],
  components: {
    formOption,
  },
  data(vm) {
    return {
      idba: window.location.href.split("/").at(-1),
      data: {},
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
      ],
      actions: [
        {
          title: "Thêm mới phiếu",
          type: "primary",
          event: "create",
          icon: "mdi-plus",
          action: true,
        },
      ],
      isLoading: false,
    };
  },
  watch: {},
  methods: {
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
        ...params,
      });
    },

    async handleCreate(data) {
      const { statusCode } = await ApiPhacDo.store({
        idba: this.idba,
        huy: false,
        ...data,
      });
      if (statusCode == 200) {
        this.dialog = false;
        this.$emit("reload");
        this.data = {};
        this.$message.success(`Thêm mới phác đồ điều trị thành công !`);
      } else {
        this.$message.error(`Thêm mới phác đồ điều trị lỗi !`);
      }
    },
  },
};
</script>
<style></style>
