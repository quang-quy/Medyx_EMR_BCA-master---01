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
            <div style="font-size: 20px; font-weight: bold">
              Phiếu khám gây mê
            </div>
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
                <i class="el-icon-printer mr-2"></i>In phiếu khám gây mê
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
                v-model="form.khoa.tenKhoa"
                :disabled="true"
                size="small"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tên dịch vụ phẫu thuật">
              <el-input
                v-model="form.phauThuat.tenPt"
                size="small"
                :disabled="true"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày chỉ định">
              <el-form-item label="Ngày chỉ định">
                <el-input
                  size="small"
                  :disabled="true"
                  v-model="form.ngayChiDinh"
                ></el-input>
              </el-form-item>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ chỉ định">
              <el-input
                v-model="form.bsChiDinh.hoTen"
                size="small"
                :disabled="true"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khoa phòng thực hiện">
              <base-select-async
                placeholder="Tìm kiếm theo mã khoa"
                :label="
                  (item) =>
                    `${item.khoa.maKhoa}${
                      item.khoa.tenKhoa ? '-' + item.khoa.tenKhoa : ''
                    }`
                "
                keyValue="maKhoa"
                :apiFunc="getKhoaDieuTri"
                 v-model="form.khoaThucHien"
                style="width: 100%"
                size="small"
              ></base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Nhóm máu">
              <el-input v-model="form.nhomMau" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="Cân nặng (Kg)" prop="canNang">
              <el-input
                v-model="form.canNang"
                type="number"
                :min="0"
                :max="300"
                size="small"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col cols="2" class="padding-cols">
            <el-form-item label="Chiều cao (cm)" prop="chieuCao">
              <el-input
                v-model="form.chieuCao"
                size="small"
                type="number"
                :min="0"
                :max="300"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="ASA">
              <el-select v-model="form.asa" style="width: 100%" size="small">
                <el-option :value="1"></el-option>
                <el-option :value="2"></el-option>
                <el-option :value="3"></el-option>
                <el-option :value="4"></el-option>
                <el-option :value="5"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Mallampati">
              <el-select
                v-model="form.mallampati"
                style="width: 100%"
                size="small"
              >
                <el-option value="I"></el-option>
                <el-option value="II"></el-option>
                <el-option value="III"></el-option>
                <el-option value="IV"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khoảng cách cằm giáp (cm)">
              <el-input
                v-model="form.khoangCachCamGiap"
                size="small"
                type="number"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Há Miệng (cm)">
              <el-input
                v-model="form.haMieng"
                size="small"
                type="number"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Răng giả">
              <el-select
                v-model="form.rangGia"
                style="width: 100%"
                size="small"
              >
                <el-option :value="0" label="Không"></el-option>
                <el-option :value="1" label="Có răng giả, tháo được"></el-option>
                <el-option :value="2" label="Có răng giả, cố định"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bữa ăn cuối trước mổ (giờ)">
              <el-input
                v-model="form.buaAnCuoiTruocMo"
                size="small"
                type="number"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Cấp cứu">
              <el-select v-model="form.capCuu" style="width: 100%" size="small">
                <el-option :value="1" label="Cấp cứu"></el-option>
                <el-option :value="2" label="Không cấp cứu"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dạ dày đầy">
              <el-select
                v-model="form.daDayDay"
                style="width: 100%"
                size="small"
              >
              <el-option :value="1" label="Đầy"></el-option>
                <el-option :value="2" label="Không Đầy"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Xét nghiệm bất thường">
              <el-input
                v-model="form.xnbatThuong"
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
              <el-input v-model="form.chanDoan" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Hướng xử trí">
              <el-input v-model="form.huongXuTri" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử nội khoa">
              <el-input v-model="form.tienSuNoiKhoa" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử ngoại khoa">
              <el-input v-model="form.tienSuNgoaiKhoa" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tiền sử gây mê">
              <el-input v-model="form.tienSuGayMe" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dị ứng">
              <el-input v-model="form.diUng" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Nghiện thuốc lá, thuốc lào">
              <el-select
                v-model="form.nghienThuocLa"
                style="width: 100%"
                size="small"
              >
                <el-option :value="1" label="Nghiện"></el-option>
                <el-option :value="2" label="Không nghiện"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Nghiện Rượu">
              <el-select
                v-model="form.nghienRuou"
                style="width: 100%"
                size="small"
              >
                <el-option :value="1" label="Nghiện"></el-option>
                <el-option :value="2" label="Không nghiện"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Nghiện ma túy">
              <el-select
                v-model="form.nghienMaTuy"
                style="width: 100%"
                size="small"
              >
                <el-option :value="1" label="Nghiện"></el-option>
                <el-option :value="2" label="Không nghiện"></el-option>
              </el-select>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Thuốc điều trị">
              <el-input v-model="form.thuocDt" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khám lâm sàng">
              <el-input v-model="form.khamLamSang" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Tuần hoàn">
              <el-input v-model="form.tuanHoan" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Mạch" prop="mach">
              <el-input
                v-model="form.mach"
                size="small"
                type="number"
                :min="0"
                :max="200"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Huyết áp">
              <el-input v-model="form.huyetAp" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="2" lg="4" md="4" class="padding-cols">
            <el-form-item label="Hô hấp">
              <el-input
                v-model="form.hoHap"
                size="small"
                type="number"
                :min="0"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Thần kinh">
              <el-input v-model="form.thanKinh" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Cột sống">
              <el-input v-model="form.cotSong" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Xét nghiệm bổ sung">
              <el-input v-model="form.yeuCauBoSung" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dự kiến cách và thuốc vô cảm">
              <el-input v-model="form.duKienCachVoCam" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dự kiến giảm đau sau mổ">
              <el-input
                v-model="form.duKienGiamDauSauMo"
                size="small"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Y lệnh trước mổ và thuốc tiền gây mê">
              <el-input v-model="form.ylenhTruocMo" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Y tá thực hiện">
              <base-select-async
                v-model="form.dieuDuong"
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
            <el-form-item label="Ngày khám">
              <el-date-picker
                v-model="form.ngayKham"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ gây mê khám">
              <base-select-async
                v-model="form.bsgayMeKham"
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
            <el-form-item label="Ngày thăm lại trước mổ">
              <el-date-picker
                v-model="form.ngayThamLaiTruocMo"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
              >
              </el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ gây mê thăm lại trước mổ">
              <base-select-async
                v-model="form.bsgayMeThamLaiTruocMo"
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
        </v-row>
      </el-form>
    </div>
  </app-wrapper>
</template>
<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiBenhTat from "@/api/benh-tat.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import * as apiKhoa from "@/api/khoa.js";
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import { formatDate, formatDatetime } from "@/utils/formatters";
import {
  detailPhieuKhamGayMe,
  updatePhieuKhamGayMe,
  detroyPhieuKhamGayMe,
  addPhieuKhamGayMe,
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
  data(vm) {
    var checkMach = (rule, value, callback) => {
      // if (!value) {
      //   return callback(new Error("Phải nhập mạch"));
      // }
      setTimeout(() => {
        if (value && (value > 200 || value < 0)) {
          callback(new Error("Giá trị nhập lớn hơn 0 và nhỏ hơn 200"));
        } else {
          callback();
        }
      }, 1000);
    };
    var checkCanNang = (rule, value, callback) => {
      // if (!value) {
      //   return callback(new Error("Phải nhập cân nặng"));
      // }
      setTimeout(() => {
        if (value && (value > 200 || value < 0)) {
          callback(new Error("Giá trị nhập lớn hơn 0 và nhỏ hơn 300"));
        } else {
          callback();
        }
      }, 1000);
    };
    var checkChieuCao = (rule, value, callback) => {
      // if (!value) {
      //   return callback(new Error("Phải nhập cân chiều cao"));
      // }
      setTimeout(() => {
        if ( value && (value > 300 || value < 0)) {
          callback(new Error("Giá trị nhập lớn hơn 0 và nhỏ hơn 300"));
        } else {
          callback();
        }
      }, 1000);
    };
    return {
      disableActions: {
        modify: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhieuKhamGayMe/modify"
        ),
        create: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhieuKhamGayMe/create"
        ),
        export: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhieuKhamGayMe/export"
        ),
      },
      form: {},
      data: null,
      rules: {
        canNang: [
          {
            validator: checkCanNang,
            trigger: "blur",
          },
          // { required: true, message: "Phải nhập cân nặng", trigger: "change" },
        ],
        chieuCao: [
          {
            validator: checkChieuCao,
            trigger: "blur",
          },
          // { required: true, message: "Phải nhập chiều cao", trigger: "change" },
        ],
        mach: [
          {
            validator: checkMach,
            trigger: "blur",
          },
          // {
          //   required: true,
          //   message: "Phải nhập số đo mạch",
          //   trigger: "change",
          // },
        ],
      },
    };
  },
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
      const { data } = await detailPhieuKhamGayMe(this.id, this.stt);
      this.form = Object.assign({}, data);
      this.form.bsgayMeKham=this.form.dmBsgayMeKham.maNv
      this.form.bsgayMeThamLaiTruocMo=this.form.dmBsgayMeThamLaiTruocMo.maNv
      this.form.ngayChiDinh = formatDatetime(this.form.ngayChiDinh);
      this.form.khoaThucHien=this.form.khoa.maKhoa
      this.form.bsChiDinh.hoTen = this.form.bsChiDinh.hoTen
        ? this.form.bsChiDinh.hoTen
        : "Không có thông tin";
    },
    submit(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.updateData();
        } else {
          return false;
        }
      });
    },
    async updateData() {
      if (this.form.idba) {
        try {
          await updatePhieuKhamGayMe(this.id, this.stt, this.form);
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
        this.form.sttpt = this.stt;
        this.form.idba = this.id;
        this.form.maBa = null;
        this.form.maBn = null;
        try {
          await addPhieuKhamGayMe(this.form);
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
        `${window.origin}/api/benh-an-phau-thuat-phieu-kham-gay-me-truoc-mo/${this.id}/print-ba-file/${this.stt}/phieu-kham-gay-me-truoc-mo.pdf`,
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
