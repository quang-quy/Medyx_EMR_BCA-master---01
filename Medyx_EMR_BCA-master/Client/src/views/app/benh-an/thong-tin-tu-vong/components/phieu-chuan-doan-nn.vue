<template>
  <div class="mb-2 px-2">
    <form-options
      primaryKey="idba"
      :options="options"
      :fields="fields"
      :actions="actions"
      :dataForm="dataForm"
      @update="updateData"
      @print-chuandoan="printChuanDoan"
    ></form-options>
  </div>
</template>

<script>
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import * as apiThongTinTuVong from "@/api/thong-tin-tu-vong";
import { index } from "@/api/benh-tat";

import formOptions from "./sub/formOptions";
export default {
  components: { formOptions },
  props: {
    title: { type: String, default: null },
    idba: { type: [String, Number], default: null },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data: (vm) => ({
    options: {
      title: "Phiếu chẩn đoán nguyên nhân tử vong",
    },
    fields: [
      {
        label: "Số phiếu",
        type: "text",
        fromValue: "soPhieu",
        placeholder: "Số phiếu",
        action: true,
        value: "soPhieu",
      },
      {
        label: "Ngày tử vong",
        type: "datetime",
        fromValue: "ngayTv",
        placeholder: "Ngày tử vong",
        action: true,
        value: "ngayTv",
      },
      {
        label: "Chẩn đoán nguyên nhân tử vong (a)",
        type: "textarea",
        fromValue: "nguyenNhanA",
        placeholder: "Chẩn đoán nguyên nhân tử vong (a)",
        action: true,
        value: "nguyenNhanA",
      },
      {
        label: "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (a)",
        type: "textarea",
        fromValue: "thoiGianA",
        placeholder:
          "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (a)",
        action: true,
        value: "thoiGianA",
      },
      {
        label: "Chẩn đoán nguyên nhân tử vong (b)",
        type: "textarea",
        fromValue: "nguyenNhanB",
        placeholder: "Chẩn đoán nguyên nhân tử vong (b)",
        action: true,
        value: "nguyenNhanB",
      },
      {
        label: "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (b)",
        type: "textarea",
        fromValue: "thoiGianB",
        placeholder:
          "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (b)",
        action: true,
        value: "thoiGianB",
      },
      {
        label: "Chẩn đoán nguyên nhân tử vong (c)",
        type: "textarea",
        fromValue: "nguyenNhanC",
        placeholder: "Chẩn đoán nguyên nhân tử vong (c)",
        action: true,
        value: "nguyenNhanC",
      },
      {
        label: "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (c)",
        type: "textarea",
        fromValue: "thoiGianC",
        placeholder:
          "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (c)",
        action: true,
        value: "thoiGianC",
      },
      {
        label: "Chẩn đoán nguyên nhân tử vong (d)",
        type: "textarea",
        fromValue: "nguyenNhanD",
        placeholder: "Chẩn đoán nguyên nhân tử vong (d)",
        action: true,
        value: "nguyenNhanD",
      },
      {
        label: "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (d)",
        type: "textarea",
        fromValue: "thoiGianD",
        placeholder:
          "Khoảng thời gian từ khi khởi phát sự kiện đến khi tử vong  (d)",
        action: true,
        value: "thoiGianD",
      },
      {
        label: "Chẩn đoán nguyên nhân tử vong (Mục 2)",
        placeholder: "Chẩn đoán nguyên nhân tử vong (Mục 2)",
        type: "textarea",
        fromValue: "nguyenNhan2",
        action: true,
        value: "nguyenNhan2",
      },
      {
        label: "Khoảng thời gian phát đến khi tử vong (Mục 2)",
        placeholder: "Khoảng thời gian phát đến khi tử vong (Mục 2)",
        fromValue: "thoiGian2",
        type: "textarea",
        action: true,
        value: "thoiGian2",
      },
      {
        label: "Phẫu thuật trong 4 tuần qua",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        placeholder: "Phẫu thuật trong 4 tuần qua",
        action: true,
        fromValue: "phauThuat",
        value: "phauThuat",
      },
      {
        label: "Ngày phẫu thuật",
        placeholder: "Ngày phẫu thuật",
        type: "date",
        fromValue: "ngayPhauThuat",
        action: false,
        value: "ngayPhauThuat",
      },
      {
        label: "Lý do phẫu thuật",
        placeholder: "Lý do phẫu thuật",
        type: "textarea",
        fromValue: "lyDoPt",
        action: false,
        value: "lyDoPt",
      },
      {
        label: "Khám nghiệm tử thi",
        placeholder: "Khám nghiệm tử thi",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        fromValue: "kntt",
        action: true,
        value: "kntt",
      },
      {
        label: "Kết quả khám nghiệm ghi trong phiếu",
        placeholder: "Kết quả khám nghiệm",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        fromValue: "sdkq",
        action: true,
        value: "sdkq",
      },
      {
        label: "Hình thức tử vong",
        placeholder: "Hình thức tử vong",
        type: "select",
        category: [
          {
            text: "Bệnh",
            value: 1,
          },
          {
            text: "Tai nạn",
            value: 2,
          },
          {
            text: "Bị tấn công",
            value: 3,
          },
          {
            text: "liên quan đến pháp luật",
            value: 4,
          },
          {
            text: " không xác định",
            value: 5,
          },
          {
            text: "chờ điều tra",
            value: 6,
          },
          {
            text: "Cố ý làm hại bản thân ",
            value: 7,
          },
          {
            text: "Chiến tranh",
            value: 8,
          },
          {
            text: "Không biết",
            value: 9,
          },
        ],
        fromValue: "hinhThucTv",
        action: true,
        value: "hinhThucTv",
      },
      {
        label: "Ngày chấn thương",
        placeholder: "Ngày chấn thương",
        type: "date",
        fromValue: "ngayChanThuong",
        action: true,
        value: "ngayChanThuong",
      },
      {
        label: "Nguyên nhân chấn thương",
        placeholder: "Nguyên nhân chấn thương",
        type: "textarea",
        fromValue: "nguyenNhanChanThuong",
        action: true,
        value: "nguyenNhanChanThuong",
      },
      {
        label: "Mô tả nguyên nhân chấn thương",
        placeholder: "Mô tả nguyên nhân chấn thương",
        type: "textarea",
        fromValue: "moTaNguyenNhanChanThuong",
        action: true,
        value: "moTaNguyenNhanChanThuong",
      },
      {
        label: "Nơi xảy ra tử vong do nguyên nhân bên ngoài",
        placeholder: "Nơi xảy ra tử vong do nguyên nhân bên ngoài",
        type: "select",
        multiple: true,
        fromValue: "noiTuVong",
        action: true,
        value: "noiTuVong",
        category: [
          {
            text: "Tại nhà",
            value: 1,
          },
          {
            text: "Khu dân cư",
            value: 2,
          },
          {
            text: "Trường học khu hành chính khác",
            value: 3,
          },
          {
            text: "Khu thể thao",
            value: 4,
          },
          {
            text: "Trên đường đi",
            value: 5,
          },
          {
            text: "Khu thương mại và dịch vụ",
            value: 6,
          },
          {
            text: "Khu công nghiệp",
            value: 7,
          },
          {
            text: "Nông trại",
            value: 8,
          },
          {
            text: "Địa điểm khác",
            value: 9,
          },
          {
            text: "Không rõ",
            value: 10,
          },
        ],
      },
      {
        label: "Nơi tử vong khác",
        placeholder: "Nơi tử vong khác",
        type: "textarea",
        fromValue: "noiTv",
        action: true,
        value: "noiTv",
      },
      {
        label: "Đa thai",
        placeholder: "Đa thai",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        fromValue: "daThai",
        action: true,
        value: "daThai",
      },
      {
        label: "Sinh non",
        placeholder: "Sinh non",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        fromValue: "sinhNon",
        action: true,
        value: "sinhNon",
      },
      {
        label: "Giờ sống sót sau sinh",
        placeholder: "Giờ sống sót sau sinh",
        type: "number",
        fromValue: "gioSongSauSinh",
        action: true,
        value: "gioSongSauSinh",
        min: 0,
      },
      {
        label: "Cân nặng khi sinh",
        placeholder: "gam",
        type: "number",
        fromValue: "canNang",
        action: true,
        value: "canNang",
        min: 0,
        max: 10000,
      },
      {
        label: "Số tuần mang thai",
        placeholder: "Tuần",
        type: "number",
        fromValue: "soTuanMangThai",
        action: true,
        value: "soTuanMangThai",
        min: 0,
        max: 47,
      },
      {
        label: "Tuổi mẹ",
        placeholder: "Năm",
        type: "number",
        fromValue: "tuoiMe",
        action: true,
        value: "tuoiMe",
        min: 0,
        max: 70,
      },
      {
        label: "Chu sinh, tình trạng mẹ ảnh hưởng đến thai nhi và trẻ sơ sinh",
        placeholder:
          "Chu sinh, tình trạng mẹ ảnh hưởng đến thai nhi và trẻ sơ sinh",
        type: "textarea",
        fromValue: "chuSinh",
        action: true,
        value: "chuSinh",
      },
      {
        label: "Người chết mang thai",
        placeholder: "Người chết mang thai",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        fromValue: "mangThai",
        action: true,
        value: "mangThai",
      },
      {
        label: "Thời điểm mang thai",
        placeholder: "Thời điểm mang thai",
        type: "radio",
        fromValue: "thoiDiemMangThai",
        action: true,
        value: "thoiDiemMangThai",
        category: [
          {
            text: "Tại thời điểm mang thai",
            value: 1,
          },
          {
            text: "Trong vòng 42 ngày trước khi tử vong",
            value: 2,
          },
          {
            text: "Từ 43 ngày đến 1 năm",
            value: 3,
          },
          {
            text: "Không biết",
            value: 4,
          },
        ],
      },
      {
        label: "Mang thai gây tử vong",
        placeholder: "Mang thai gây tử vong",
        type: "select",
        category: [
          {
            text: "Có",
            value: 1,
          },
          {
            text: "Không",
            value: 2,
          },
          {
            text: "Không biết",
            value: 3,
          },
        ],
        fromValue: "mangThaiGayTv",
        action: true,
        value: "mangThaiGayTv",
      },
      {
        label: "Tử vong tại",
        placeholder: "Tử vong tại",
        type: "select",
        category: [
          {
            text: "Cơ sở khám chữa bệnh",
            value: 1,
          },
          {
            text: "Tiên lượng nặng xin về",
            value: 2,
          },
          {
            text: "Trên đường đến CSKCB",
            value: 3,
          },
        ],
        fromValue: "tvcc",
        action: true,
        value: "tvcc",
      },
      {
        label: "Chẩn đoán",
        placeholder: "Chẩn đoán",
        type: "select-async",
        keyValue: "maBenh",
        apiFunc: index,
        labelselect: (item) => `${item.maBenh}-${item.tenBenh}`,
        fromValue: "chanDoan.maBenh",
        action: true,
        value: "maBenhNntv",
      },
      {
        label: "Tên nguyên nhân tử vong",
        placeholder: "Tên nguyên nhân tử vong",
        type: "textarea",
        fromValue: "tenNntv",
        action: true,
        value: "tenNntv",
      },
      {
        label: "Người lập phiếu",
        placeholder: "Người lập phiếu",
        type: "select-async",
        fromValue: "nguoiLapPhieu.maNv",
        keyValue: "maNv",
        apiFunc: getNhanVien,
        labelselect: (item) =>
          `${item.maNv}-${item.hoTen}-${item.khoa.tenKhoa}`,
        action: true,
        value: "nguoiLapPhieu",
      },
      {
        label: "Lãnh đạo ký",
        placeholder: "Lãnh đạo ký",
        type: "select-async",
        fromValue: "thutruong.maNv",
        keyValue: "maNv",
        apiFunc: getNhanVien,
        labelselect: (item) =>
          `${item.maNv}-${item.hoTen}-${item.khoa.tenKhoa}`,
        action: true,
        value: "thutruong",
      },
      {
        label: "Ngày ký",
        type: "date",
        placeholder: "Ngày ký",
        fromValue: "ngayKy",
        action: true,
        value: "ngayKy",
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
            e.ActionDetailsName ==
            "/HSBA/ThongTinTuVong/ChanDoanNguyenNhanTuVong/modify"
        ),
      },
      {
        title: "In chẩn đoán nguyên nhân tử vong",
        type: "primary",
        icon: "mdi-printer",
        event: "print-chuandoan",
        action: vm.permission.find(
          (e) =>
            e.ActionDetailsName ==
            "/HSBA/ThongTinTuVong/ChanDoanNguyenNhanTuVong/export"
        ),
      },
    ],
    dataForm: {},
    edit: true,
  }),
  created() {
    this.getData();
  },
  methods: {
    async getData() {
      try {
        const res = await apiThongTinTuVong.indexCdnn(this.idba);
        this.dataForm = res && res.data ? res.data : {};
        if (Object.keys(this.dataForm).length) {
          if(this.dataForm.noiTuVong){
            this.dataForm.noiTuVong = this.dataForm.noiTuVong
            .split(",")
            .map((e) => e * 1);
          }
        } else {
          this.edit = false;
        }
      } catch (error) {
        this.edit = false;
      }
    },
    async updateData(data) {
      if (data && data.noiTuVong && typeof data.noiTuVong != "string") {
        data.noiTuVong
          ? (data.noiTuVong = JSON.stringify(data.noiTuVong)
              .replace("[", "")
              .replace("]", ""))
          : null;
      }
      const { statusCode } = this.edit
        ? await apiThongTinTuVong.updateCdnn(this.idba, data)
        : await apiThongTinTuVong.storeCdnn({
            ...data,
            idba: this.idba,
          });
      if (statusCode == 200) {
        this.$emit("reset");
        this.$message.success("Lưu phiếu nguyên nhân tử vong thành công !");
      } else {
        this.$message.error("Lưu phiếu nguyên nhân tử vong lỗi !");
      }
    },
    printChuanDoan(data) {
      apiThongTinTuVong.printChuanDoan(this.idba, data.soPhieu);
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
