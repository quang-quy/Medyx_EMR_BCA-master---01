<template>
  <el-dialog
    title="Chi tiết phiếu khám dinh dưỡng"
    :visible.sync="dialog"
    width="40%"
    height="30%"
  >
    <form-options
      :dataForm="currentRowData"
      :fields="fields"
      :actions="actions"
      @update="handleUpdate"
    >
    </form-options>
  </el-dialog>
</template>
<script>
import formOptions from "./components/formOptions.vue";
import * as ApiDd from "@/api/phieu-kham-dinh-duong";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import { store, update } from "@/api/phieu-kham-dinh-duong";
import { formatDate, formatDatetime } from "@/utils/formatters";
export default {
  components: { formOptions },

  data: (vm) => ({
    formatDatetime,
    fields: [
      {
        label: "Số phiếu",
        type: "text",
        fromValue: "soPhieu",
        placeholder: "Số phiếu",
        action: true,
        disable: false,
        value: "soPhieu",
      },
      {
        label: "Khoa",
        type: "select-async",
        fromValue: "sttkhoa",
        placeholder: "Khoa",
        disable: false,
        action: true,
        value: "sttKhoa",
        keyValue: "stt",
        apiFunc: ApiDd.dsKhoaDieuTri,
        defaultParams: {
          idba: window.location.href.split("/").at(-1),
          huy: false,
        },
        labelselect: (item) =>
          `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
            item.ngayVaoKhoa
          )}`,
      },
      {
        label: "Ngày đánh giá",
        type: "datetime",
        fromValue: "ngayDg",
        placeholder: "Ngày đánh giá",
        disable: false,
        action: true,
        value: "ngayDg",
      },
      {
        label: "Cân nặng (kg)",
        type: "number",
        fromValue: "canNang",
        placeholder: "Cân nặng",
        min: 0,
        max: 300,
        disable: false,
        action: true,
        value: "canNang",
      },
      {
        label: "Chiều cao (cm)",
        type: "number",
        fromValue: "chieuCao",
        placeholder: "Chiều cao",
        disable: false,
        action: true,
        min: 0,
        max: 300,
        value: "chieuCao",
      },
      {
        label: "BMI",
        type: "text",
        fromValue: "bmi",
        placeholder: "Bmi",
        disable: true,
        action: true,
        value: "bmi",
      },
      {
        label: "Có sụt cân không",
        type: "select",
        fromValue: "coSutCan",
        placeholder: "Có sụt cân không",
        disable: false,
        action: true,
        value: "coSutCan",
        category: [
          {
            text: "Không sụt cân",
            value: 0,
          },
          {
            text: "Có sụt cân",
            value: 1,
          },
          {
            text: "Không rõ",
            value: 2,
          },
        ],
      },
      {
        label: "Số cân bị sụt",
        type: "select",
        fromValue: "diemSutCan",
        placeholder: "Số cân bị sụt",
        disable: true,
        action: true,
        value: "diemSutCan",
        category: [
          {
            text: "1-1.5kg",
            value: 1,
          },
          {
            text: "6-10kg",
            value: 2,
          },
          {
            text: "11-15kg",
            value: 3,
          },
          {
            text: ">15kg",
            value: 4,
          },
        ],
      },
      {
        label: "Chỉ số sụt cân",
        type: "text",
        fromValue: "chiSoSutCan",
        placeholder: "Chỉ số sụt cân",
        disable: true,
        action: true,
        value: "chiSoSutCan",
      },
      {
        label: "Ăn kém do giảm cảm giác thèm ăn",
        type: "select",
        fromValue: "diemNgonMieng",
        placeholder: "Ăn kém do giảm cảm giác thèm ăn",
        disable: false,
        action: true,
        value: "diemNgonMieng",
        category: [
          {
            text: "Không",
            value: 0,
          },
          {
            text: "Có",
            value: 1,
          },
        ],
      },
      {
        label: "Chỉ số ngon miệng",
        type: "text",
        fromValue: "chiSoNgonMieng",
        placeholder: "Chỉ số ngon miệng",
        disable: true,
        action: true,
        value: "chiSoNgonMieng",
      },
      {
        label: "Chỉ số MST",
        type: "text",
        fromValue: "chiSoMst",
        placeholder: "Chỉ số MST",
        disable: true,
        action: true,
        value: "chiSoMst",
      },
      {
        label: "Đánh giá theo chỉ số MST",
        type: "text",
        fromValue: "danhGiaTheoMst",
        placeholder: "Đánh giá theo chỉ số MST",
        disable: true,
        action: true,
        value: "danhGiaTheoMst",
      },
      {
        label: "Can thiệp dinh dưỡng",
        type: "textarea",
        fromValue: "canThiepDd",
        placeholder: "Can thiệp dinh dưỡng",
        disable: false,
        action: true,
        value: "canThiepDd",
      },
      {
        label: "Người đánh giá",
        type: "select-async",
        placeholder: "Người đánh giá",
        disable: false,
        action: true,
        fromValue: "nguoiDg.maNv",
        value: "NguoiDg",
        keyValue: "maNv",
        apiFunc: getNhanVien,
        labelselect: (item) =>
          `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ""}`,
      },
      {
        label: "Bác sỹ điều trị",
        type: "select-async",
        placeholder: "Bác sỹ điều trị",
        disable: false,
        action: true,
        fromValue: "bsdieutri.maNv",
        value: "Bsdieutri",
        keyValue: "maNv",
        apiFunc: getNhanVien,
        labelselect: (item) =>
          `${item.maNv}-${item.hoTen}-${item.khoa ? item.khoa.tenKhoa : ""}`,
      },
      {
        label: "Hủy",
        type: "boolean",
        fromValue: "huy",
        placeholder: "Hủy",
        disable: false,
        action: true,
        value: "huy",
      },
    ],
    actions: [
      {
        title: "Lưu",
        type: "primary",
        event: "update",
        disabled: !vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/phieudinhduong/modify"
        )
      },
    ],
  }),
  props: {
    currentRowData: Object,
    showFile: Boolean,
    permission:{ type: Array, default: ()=>[]}
  },
  computed: {
    dialog: {
      set(value) {
        this.$emit("update:showFile", value);
      },
      get() {
        return this.showFile;
      },
    },
  },
  methods: {
    async handleUpdate(formData) {
      const { statusCode } = await update(
        this.currentRowData.idba,
        this.currentRowData.stt,
        this.currentRowData.sttkhoa,
        formData
      );
      if (statusCode == 200) {
        this.dialog = false;
        // window.location.reload();
        this.$emit("reload")
        this.$message.success("Lưu phiếu dinh dưỡng thành công !");
      } else {
        this.$message.error("Lưu phiếu dinh dưỡng lỗi !");
      }
    },
  },
};
</script>
