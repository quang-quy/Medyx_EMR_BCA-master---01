<template>
  <app-wrapper :idba="id">
    <div class="ma-5">
      <div>
        <div class="d-flex justify-space-between align-flex-end mb-3">
          <div class="d-flex align-center mb-3">
            <v-btn
              class="mr-5"
              fab
              small
              color="primary"
              depressed
              outlined
              @click="goback()"
            >
              <v-icon dark> mdi-arrow-left </v-icon>
            </v-btn>
            <div style="font-size: 20px; font-weight: bold">Phiếu duyệt mổ</div>
          </div>
          <div>
            <div class="d-flex mb-3">
              <v-btn
                class="mr-5"
                color="primary"
                @click="print"
                small
                :disabled="!disableActions.export"
              >
                <i class="el-icon-printer mr-2"></i>In phiếu duyệt mổ
              </v-btn>
              <v-btn
                class="mr-5"
                color="primary"
                @click="submit('form')"
                small
                :disabled="
                  form.idba ? !disableActions.modify : !disableActions.create
                "
              >
                <i class="el-icon-edit mr-2"></i
                >{{ form.idba ? "Cập nhật" : "Thêm mới" }}
              </v-btn>
            </div>
          </div>
        </div>
        <v-progress-linear
          color="primary"
          rounded
          value="100"
          height="2"
        ></v-progress-linear>
        <br />
      </div>
      <el-form :model="form" ref="form" :rules="rules">
        <v-row>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khoa">
              <el-input
                :disabled="true"
                size="small"
                v-model="form.khoa.tenKhoa"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tên dịch vụ phẫu thuật">
              <el-input
                size="small"
                :disabled="true"
                v-model="form.phauThuat.tenPt"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày chỉ định">
              <el-input
                size="small"
                :disabled="true"
                v-model="form.ngayChiDinh"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ chỉ định">
              <el-input
                size="small"
                :disabled="true"
                v-model="form.bsChiDinh.hoTen"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khoa phòng thực hiện" prop="khoa">
              <base-select-async
                placeholder="Tìm kiếm theo mã khoa"
                :label="
                  (item) =>
                    `${item.khoa.maKhoa}${
                      item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
                    }`
                "
                keyValue="maKhoa"
                v-model="form.khoaThucHien"
                :apiFunc="getKhoaDieuTri"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Lý do vào viện">
              <el-input
                v-model="form.lyDoVv"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử ngoại khoa">
              <el-input
                v-model="form.tienSuNgoaiKhoa"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử nội Khoa">
              <el-input
                v-model="form.tienSuNoiKhoa"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử dị ứng">
              <el-input
                v-model="form.tienSuDiUng"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử khác">
              <el-input
                v-model="form.tienSuKhac"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bệnh sử">
              <el-input
                v-model="form.benhSu"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Mô tả hiện tại khác">
              <el-input
                v-model="form.moTaHienTaiKhac"
                placeholder="Nhập ..."
                type="textarea"
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="mini"
                show-word-limit
                maxlength="5000"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="Mạch">
              <br />
              <el-input
                type="number"
                v-model="form.mach"
                size="small"
                style="width: 100%"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="Huyết áp">
              <el-input
                v-model="form.huyetAp"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="Nhiệt độ">
              <br />
              <el-input
                v-model="form.nhietDo"
                size="small"
                type="number"
                style="width: 100%"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="Nhóm máu">
              <el-input
                v-model="form.nhomMau"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="HC">
              <el-input
                v-model="form.hc"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="HCT">
              <el-input
                v-model="form.hct"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="BC">
              <el-input
                v-model="form.bc"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="TC">
              <el-input
                v-model="form.tc"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="PT">
              <el-input
                v-model="form.pt"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="APT">
              <el-input
                v-model="form.apt"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="4" class="padding-cols">
            <el-form-item label="Kết quả huyết học khác">
              <el-input
                v-model="form.kqhhkhac"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-0"
                :autosize="{ minRows: 2, maxRows: 5 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Kết quả sinh hóa">
              <el-input
                v-model="form.kqsh"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Kết quả chẩn đoán hình ảnh">
              <el-input
                v-model="form.kqcdha"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Kết quả xét nghiệm khác">
              <el-input
                v-model="form.kqxnkhac"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Chẩn đoán">
              <el-input
                v-model="form.maBenh"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tên phẫu thuật">
              <el-input
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                v-model="form.phauThuat.tenPt"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Phương pháp phẫu thuật">
              <el-input
                v-model="form.phuongPhapPhauThuat"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Phương pháp vô cảm">
              <el-input
                v-model="form.phuongPhapVoCam"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Kíp phẫu thuật">
              <el-input
                v-model="form.kipPhauThuat"
                size="small"
                placeholder="Nhập ..."
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày giờ phẫu thuật">
              <el-date-picker
                v-model="form.ngayPt"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
                type="datetime"
                value-format="yyyy-MM-ddTHH:mm:ss"
                format="dd/MM/yyyy HH:mm"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dự trù máu">
              <el-input
                v-model="form.duTruMau"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khó khăn">
              <el-input
                v-model="form.khoKhan"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Chuẩn bị chuyên biệt, các vấn đề khác">
              <el-input
                v-model="form.vanDeKhac"
                size="small"
                placeholder="Nhập ..."
                class="flex-grow-1"
                :autosize="{ minRows: 5, maxRows: 10 }"
                show-word-limit
                maxlength="5000"
                type="textarea"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ phẫu thuật">
              <base-select-async
                v-model="form.bspt"
                placeholder="Chọn bác sỹ phẫu thuật"
                :label="
                  (item) =>
                    `${item.maNv} - ${item.hoTen} ${
                      item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
                    }`
                "
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày bác sĩ phẫu thuật ký">
              <el-date-picker
                v-model="form.ngayKyBspt"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
                value-format="yyyy-MM-dd"
                format="dd/MM/yyyy "
                type="date"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ gây mê">
              <base-select-async
                v-model="form.bsgayMe"
                placeholder="Tìm kiếm theo tên"
                :label="
                  (item) =>
                    `${item.maNv} - ${item.hoTen} ${
                      item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
                    }`
                "
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày bác sĩ gây mê ký">
              <el-date-picker
                v-model="form.ngayKyBsgm"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
                value-format="yyyy-MM-dd"
                format="dd/MM/yyyy "
                type="date"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Lãnh đạo khoa">
              <base-select-async
                v-model="form.truongKhoa"
                placeholder="Lãnh đạo khoa"
                :label="
                  (item) =>
                    `${item.maNv} - ${item.hoTen} ${
                      item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
                    }`
                "
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày lãnh đạo khoa ký">
              <el-date-picker
                v-model="form.ngayKyBsldkhoa"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
                value-format="yyyy-MM-dd"
                format="dd/MM/yyyy "
                type="date"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Lãnh đạo bệnh viện">
              <base-select-async
                v-model="form.lanhDaoBv"
                placeholder="Lãnh đạo bệnh viện"
                :label="
                  (item) =>
                    `${item.maNv} - ${item.hoTen} ${
                      item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
                    }`
                "
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày lãnh đạo bệnh viện kí">
              <el-date-picker
                v-model="form.ngayKyLdbv"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
                value-format="yyyy-MM-dd"
                format="dd/MM/yyyy "
                type="date"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
        </v-row>
      </el-form>
    </div>
  </app-wrapper>
</template>
<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import * as apiBenhTat from "@/api/benh-tat.js";
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import { formatDate, formatDatetime } from "@/utils/formatters";
import {
  detailBenhAnDuyetMo,
  updateBenhAnDuyetMo,
  detroyBenhAnDuyetMo,
  addBenhAnDuyetMo,
} from "@/api/phau-thuat-thu-thuat";
export default {
  props: {
    id: {
      type: Number,
    },
    stt: {
      type: Number,
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data: (vm) => ({
    disableActions: {
      modify: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/PhieuDuyetMo/modify"
      ),
      create: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/PhieuDuyetMo/create"
      ),
      export: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/PhieuDuyetMo/export"
      ),
    },
    form: {
      khoa:{},
      phauThuat:{},
      bsChiDinh:{}
    },
    data: null,
    rules: {
      khoa: [{ required: true, message: "Phải chọn khoa", trigger: "change" }],
    },
  }),
  mounted() {
    this.getData();
  },
  methods: {
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },
    async getChanDoanBenhCT(params) {
      return await apiBenhTatCT.index(params);
    },
    async getKhoaDieuTri(params) {
      return await apiKhoaDT.index(this.id, params);
    },
    async getData() {
      const { data } = await detailBenhAnDuyetMo(this.id, this.stt);
      this.form = Object.assign({ khoaThucHien: null }, data);
      this.form.ngayChiDinh = formatDatetime(this.form.ngayChiDinh);
      this.form.bspt=this.form.bspt.maNv
      this.form.lanhDaoBv=this.form.lanhDaoBv.maNv
      this.form.bsgayMe=this.form.bsgayMe.maNv
      this.form.khoaThucHien=this.form.khoa.maKhoa
      this.form.truongKhoa=this.form.truongKhoa.maNv
      this.form.bsChiDinh.hoTen = this.form.bsChiDinh.hoTen
      
        ? this.form.bsChiDinh.hoTen
        : "Không có thông tin";
    },
    submit(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.updateData();
        } else {
          this.$message({
            message: `Lỗi `,
            type: "error",
          });
          return false;
        }
      });
    },
    async updateData() {
      if (Number(this.form.idba)) {
        try {
          await updateBenhAnDuyetMo(this.id, this.stt, this.form);
          this.$message({
            message: "Cập nhật thành công.",
            type: "success",
          });
        } catch (error) {
          this.$message({
            message: `Cập nhật thất bại ${error}`,
            type: "error",
          });
        }
      } else {
        try {
          this.form.idba = this.id;
          this.form.sttpt = this.stt;
          this.form.maBa = null;
          this.form.maBn = null;
          await addBenhAnDuyetMo(this.form);
          this.$message({
            message: "Thêm mới thành công.",
            type: "success",
          });
        } catch (error) {
          this.form.idba=null
          this.$message({
            message: `Thêm mới thất bại ${error}`,
            type: "error",
          });
        }
      }
    },
    goback() {
      window.location = `/HSBADS/LoaiPhieuPhauThuat/${this.id}/loai-phieu/${this.stt}`;
    },
    print() {
      window.open(
        `${window.origin}/api/benh-an-phau-thuat-duyet-mo/${this.id}/print-ba-file/${this.stt}/benh-an-phau-thuat-duyet-mo.pdf`,
        "_blank"
      );
    },
  },
};
</script>
<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}

label {
  margin-bottom: -8px !important;
}

.el-form-item {
  margin-bottom: 10px !important;
}

.el-form-item__label {
  font-size: 14px;
}

.el-form-item__content {
  line-height: 35px;
}
</style>
