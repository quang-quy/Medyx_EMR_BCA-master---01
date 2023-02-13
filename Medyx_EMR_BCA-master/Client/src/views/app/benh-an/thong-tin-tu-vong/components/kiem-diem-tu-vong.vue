<template>
  <div class="mb-2 px-2">
    <form-options
      primaryKey="idba"
      :options="options"
      :fields="fields"
      :actions="actions"
      :dataForm="dataForm"
      @update="updateData"
      @print-bb="printBb"
      @print-trich-bb="printTrichBb"
      @print-giaybt="printGbt"
    >
      <div style="width: 60vw">
        <subTable title="Thành viên tham gia" :id="idba"> </subTable>
      </div>
    </form-options>
  </div>
</template>

<script>
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import * as apiThongTinTuVong from "@/api/thong-tin-tu-vong";
import subTable from "./sub/thanhVien";
import { formatDatetime } from "@/utils/formatters";
import formOptions from "./sub/formOptions";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
export default {
  components: { formOptions, subTable },
  props: {
    title: { type: String, default: null },
    idba: { type: [String, Number], default: null },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data: (vm) => ({
    dataForm: {},
    options: {
      title: "Kiểm điểm tử vong",
    },
    fields: [
      {
        label: "Khoa",
        type: "select-async",
        fromValue: "sttkhoa",
        placeholder: "Khoa điều trị",
        action: false,
        keyValue: "stt",
        apiFunc: vm.getBenhAnKhoaDieuTris,
        labelselect: (item) =>
          `${item.khoa.maKhoa} - ${item.khoa.tenKhoa} - ${formatDatetime(
            item.ngayVaoKhoa
          )}`,
        value: "sttKhoa",
      },
      {
        label: "Số phiếu",
        type: "textarea",
        fromValue: "soPhieu",
        placeholder: "Số phiếu",
        action: true,
        value: "sophieu",
      },
      {
        label: "Ngày biên bản",
        type: "datetime",
        fromValue: "thoiGianKiemDiem",
        placeholder: "Ngày biên bản",
        action: true,
        value: "thoiGianKiemDiem",
      },
      {
        label: "Nơi họp",
        type: "textarea",
        row: 3,
        fromValue: "noiHop",
        placeholder: "Nơi họp",
        action: true,
        value: "noiHop",
      },
      {
        label: "Ngày giờ tử vong",
        type: "datetime",
        fromValue: "ngayTuVong",
        placeholder: "Ngày giờ tử vong",
        action: true,
        value: "ngayTuVong",
      },
      {
        label: "Nguyên nhân tử vong",
        type: "textarea",
        row: 4,
        fromValue: "nguyenNhanTv",
        placeholder: "Nguyên nhân tử vong",
        action: true,
        value: "nguyenNhanTv",
      },
      {
        label: "Tóm tắt tiền sử bệnh",
        type: "textarea",
        row: 4,
        fromValue: "tomTatQtbenh",
        placeholder: "Tóm tắt tiền sử bệnh",
        action: true,
        value: "tomTatQtbenh",
      },
      {
        label: "Tình trạng lúc vào viện",
        type: "textarea",
        fromValue: "tinhTrangVv",
        placeholder: "Tình trạng lúc vào viện",
        action: true,
        value: "tinhTrangVv",
      },
      {
        label: "Chẩn đoán",
        type: "textarea",
        fromValue: "chanDoan",
        placeholder: "Chẩn đoán",
        action: true,
        value: "chanDoan",
      },
      {
        label: "Tóm tắt diễn biến",
        type: "textarea",
        fromValue: "tomTatDienBien",
        placeholder: "Tóm tắt diễn biến",
        action: true,
        value: "tomTatDienBien",
      },
      {
        label: "Tiếp đón người bệnh",
        type: "textarea",
        fromValue: "tiepDonBn",
        placeholder: "Tiếp đón người bệnh",
        action: true,
        value: "tiepDonBn",
      },
      {
        label: "Thăm khám và chẩn đoán, nguyên nhân, triệu chứng, tiên lượng",
        type: "textarea",
        fromValue: "thamKham",
        placeholder: "Thăm khám và chẩn đoán",
        action: true,
        value: "thamKham",
      },
      {
        label: "Điều trị",
        type: "textarea",
        fromValue: "dieuTri",
        placeholder: "Điều trị",
        action: true,
        value: "dieuTri",
      },
      {
        label: "Chăm sóc",
        type: "textarea",
        fromValue: "chamSoc",
        placeholder: "Chăm sóc",
        action: true,
        value: "chamSoc",
      },
      {
        label: "Mối quan hệ với gia đình người bệnh",
        type: "textarea",
        fromValue: "quanHeVoiGdbn",
        placeholder: "Mối quan hệ với gia đình người bệnh",
        action: true,
        value: "quanHeVoiGdbn",
      },
      {
        label: "Ý kiến bổ sung",
        type: "textarea",
        fromValue: "ykienBoSung",
        placeholder: "Ý kiến bổ sung",
        action: true,
        value: "ykienBoSung",
      },
      {
        label: "Kết luận",
        type: "textarea",
        fromValue: "ketLuan",
        placeholder: "Kết luận",
        action: true,
        value: "ketLuan",
      },
      {
        label: "Chủ tọa",
        type: "select-async",
        fromValue: "chuToa.maNv",
        placeholder: "Chủ tọa",
        keyValue: "maNv",
        apiFunc: getNhanVien,
        labelselect: (item) =>
          `${item.maNv}-${item.hoTen}-${item.khoa.tenKhoa}`,
        action: true,
        value: "chuToa",
      },
      {
        label: "Thư ký",
        type: "select-async",
        fromValue: "thuKy.maNv",
        placeholder: "Chủ tọa",
        keyValue: "maNv",
        apiFunc: getNhanVien,
        labelselect: (item) =>
          `${item.maNv}-${item.hoTen}-${item.khoa.tenKhoa}`,
        action: true,
        value: "thuKy",
      },
    ],
    actions: [
      {
        title: "Lưu",
        type: "primary",
        icon: "mdi-pencil",
        event: "update",
        action: vm.permission.find(
          (e) =>
            e.ActionDetailsName == "/HSBA/ThongTinTuVong/KiemDiemTuVong/modify"
        ),
      },
      {
        title: "In biên bản kiểm điểm",
        type: "primary",
        icon: "mdi-printer",
        event: "print-bb",
        action: vm.permission.find(
          (e) =>
            e.ActionDetailsName ==
            "/HSBA/ThongTinTuVong/KiemDiemTuVong/bienban/export"
        ),
      },
      {
        title: "In trích biên bản kiểm điểm tử vong",
        type: "primary",
        icon: "mdi-printer",
        event: "print-trich-bb",
        action: vm.permission.find(
          (e) =>
            e.ActionDetailsName ==
            "/HSBA/ThongTinTuVong/KiemDiemTuVong/trichbienban/export"
        ),
      },
      {
        title: "In giấy báo tử",
        type: "primary",
        icon: "mdi-printer",
        event: "print-giaybt",
        action: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/ThongTinTuVong/GiayBaoTu/export"
        ),
      },
    ],
    formTempt: {},
    edit: true,
  }),
  created() {
    this.getData();
  },
  methods: {
    async getData() {
      try {
        this.getKhoaDieuTri();
        const { data } = await apiThongTinTuVong.indexKdtv(this.idba);
        if (data) {
          this.formTempt = Object.assign(this.formTempt, { ...data });
        } else {
          this.edit = false;
        }
        this.dataForm = { ...this.formTempt };
      } catch (error) {
        this.edit = false        
      }
    },
    async getKhoaDieuTri() {
      const { data } = await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
        sortBy: "-ngayVaoKhoa",
      });
      if (data.length) {
        this.formTempt.sttKhoa = data[0].stt;
      }
    },
    async getDanhDSNhanVien() {
      return await getNhanVien();
    },
    async updateData(data) {
      const { statusCode } = this.edit
        ? await apiThongTinTuVong.updateKdtv(this.idba, data)
        : await apiThongTinTuVong.storeKdtv({
            idba: this.idba,
            ...data,
          });
      if (statusCode == 200) {
        this.$emit("reset");
        this.$message.success(
          `${
            this.edit ? "Cập nhật" : "Thêm mới"
          } kiểm điểm tử vong thành công !`
        );
      } else {
        this.$message.error(
          `${this.edit ? "Cập nhật" : "Thêm mới"} kiểm điểm tử vong lỗi !`
        );
      }
    },
    printBb(data) {
      return apiThongTinTuVong.printBBKd(this.idba, data.sophieu);
    },
    printTrichBb(data) {
      return apiThongTinTuVong.printInTrich(this.idba, data.sophieu);
    },
    printGbt(data) {
      return apiThongTinTuVong.printGbt(this.idba, data.sophieu);
    },
    async getBenhAnKhoaDieuTris(params) {
      return await getBenhAnKhoaDieuTri({
        idba: this.idba,
        huy: false,
        forSelect: true,
        ...params,
      });
    },
  },
};
</script>

<style scoped>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
