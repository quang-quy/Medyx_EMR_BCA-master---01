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
              Phiếu phẫu thuật thủ thuật
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
                <i class="el-icon-printer mr-2"></i>In phiếu phẫu thuật thủ thuật
              </v-btn>
              <v-btn
                class="mr-5"
                color="primary"
                @click="updateData"
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
      <el-form>
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
              <el-input
                size="small"
                :disabled="true"
                v-model="form.ngayChiDinh"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ chỉ định">
              <base-select-async
                v-model="form.bsChiDinh"
                placeholder="Tìm kiếm theo tên"
                :label="(item) => `${item.hoTen}`"
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
                :disabled="true"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày giờ PT/TT">
              <el-date-picker
                v-model="form.ngayPt"
                type="datetime"
                format="dd/MM/yyyy HH:mm"
                value-format="yyyy-MM-ddTHH:mm:ss"
                placeholder="DD/MM/YYYY HH:mm"
                style="width: 100%"
                size="small"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Mã chẩn đoán trước PT/TT">
              <base-select-async
                v-model="form.chanDoanTruocPt"
                :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="maBenh"
                :apiFunc="getChanDoanBenh"
                placeholder="Tìm kiếm theo mã bênh"
                style="width: 100%"
                clearable
                size="small"
                @get-item="chanDoanTruoc"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Chẩn đoán trước PT/TT">
              <el-input
                v-model="form.chanDoanTruocPtTenBenh"
                size="small"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Mã chẩn đoán sau PT/TT">
              <base-select-async
                v-model="form.chanDoanSauPt"
                :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="maBenh"
                :apiFunc="getChanDoanBenh"
                placeholder="Tìm kiếm theo mã bệnh"
                style="width: 100%"
                clearable
                size="small"
                @get-item="chanDoanSau"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Chẩn đoán sau PT/TT">
              <el-input
                v-model="form.chanDoanSauPtTenBenh"
                size="small"
              ></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Phương pháp PT/TT">
              <el-input v-model="form.phuongPhap" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Loại phẫu thuật/ thủ thuật">
              <base-select-async
                v-model="form.phanLoaiPt"
                placeholder="Tìm kiếm theo tên"
                :label="(item) => `${item.maPlpttt} - ${item.tenPlpttt}`"
                keyValue="maPlpttt"
                :apiFunc="getLoaiPhauThuat"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Phương pháp vô cảm">
              <el-input v-model="form.phuongPhapVoCam" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Phẫu thuật/thủ thuật viên">
              <base-select-async
                v-model="form.bspt"
                placeholder="Tìm kiếm theo tên"
                :label="(item) => `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`"
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Phụ phẫu thuật/thủ thuật">
              <base-select-async
                v-model="form.bsphuMo"
                placeholder="Tìm kiếm theo tên"
                :label="(item) => `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`"
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bác sĩ gây mê hồi sức">
              <base-select-async
                v-model="form.bsgayMe"
                placeholder="Tìm kiếm theo tên"
                :label="(item) => `${item.maNv} - ${item.hoTen} - ${item.khoa.tenKhoa}`"
                keyValue="maNv"
                :apiFunc="getNhanVien"
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Lược đồ PT/TT">
              <el-input v-model="form.luocDoPt" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Dẫn lưu">
              <el-input v-model="form.danLuu" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Bấc">
              <el-input v-model="form.bac" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày rút">
              <el-date-picker
                v-model="form.ngayRutChi"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày cắt chỉ">
              <el-date-picker
                v-model="form.ngayCatChi"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
              ></el-date-picker>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Khác">
              <el-input v-model="form.khac" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Trình tự PT/TT">
              <el-input v-model="form.trinhTuPt" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Vị trí phương thức phẫu thuật">
              <el-input v-model="form.viTriPt" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Cách thức phẫu thuật">
              <el-input v-model="form.cachThucPt" size="small"></el-input>
            </el-form-item>
          </v-col>
          <v-col xl="3" lg="4" md="4" class="padding-cols">
            <el-form-item label="Ngày ký">
              <el-date-picker
                v-model="form.ngayKy"
                placeholder="VD:07/09/2022"
                style="width: 100%"
                size="small"
              ></el-date-picker>
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
import {
  detailPhieuPhauThuat,
  updatePhieuPhauThuat,
  detroyPhieuPhauThuat,
  addPhieuPhauThuat,
} from "@/api/phau-thuat-thu-thuat";
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import { getDanhMucPhauThuat, getDmDichVuPhauThuat } from "@/api/danh-muc.js";
import { getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
import { formatDate, formatDatetime } from "@/utils/formatters";
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
    return {
      disableActions: {
        modify: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhieuPhauThuat/modify"
        ),
        create: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhieuPhauThuat/create"
        ),
        export: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/PhieuPhauThuat/export"
        ),
      },
      form: {
        khoa:{
            tenKhoa: ""
        },
        phauThuat:{
            tenPt: ""
        }
      },
    };
  },
  mounted() {
    this.getData();
    // this.getLoaiPhauThuat()
  },
  methods: {
    async getLoaiPhauThuat(params) {
      // console.log(await getDanhMucPhauThuat(params)) ;
      return await getDmDichVuPhauThuat(params);
    },
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },
    async getChanDoanBenhCT(params) {
      return await apiBenhTatCT.index(params);
    },
    async getData() {
      const { data } = await detailPhieuPhauThuat(this.id, this.stt);
      data.bspt = data.bspt.maNv;
      data.bsgayMe = data.bsgayMe.maNv;
      data.bsphuMo = data.bsphuMo.maNv;
      data.bsChiDinh = data.bsChiDinh.maNv;
      data.chanDoanTruocPtTenBenh = data.chanDoanTruocPt.tenBenh;
      data.chanDoanTruocPt = data.chanDoanTruocPt.maBenh;
      data.chanDoanSauPtTenBenh = data.chanDoanSauPt.tenBenh;
      data.chanDoanSauPt = data.chanDoanSauPt.maBenh;
      data.phanLoaiPt = data.loaiPhauThuat.maPlpttt;
      this.form = Object.assign({}, data);


      this.form.ngayChiDinh = formatDatetime(this.form.ngayChiDinh);
      console.log({...this.form});
    },
    async updateData() {
      console.log(this.form)
      if (this.form.idba) {
        try {
          await updatePhieuPhauThuat(this.id, this.stt, this.form);
          this.$message({
            message: "Cập nhật thành công.",
            type: "success",
          });
        } catch (error) {
          console.log(error);
        }
      } else {
        this.form.sttpt = this.stt;
        this.form.idba = this.id;
        this.form.maBa = null;
        this.form.maBn = null;
        try {
          await addPhieuPhauThuat(this.form);
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
    chanDoanTruoc(item) {
      if (item) {
        this.form.chanDoanTruocPtTenBenh = item.tenBenh;
      } else {
        this.form.chanDoanTruocPtTenBenh = null;
      }
    },
    chanDoanSau(item) {
      if (item) {
        this.form.chanDoanSauPtTenBenh = item.tenBenh;
      } else {
        this.form.chanDoanSauPtTenBenh = null;
      }
    },
    goback() {
      window.location = `/HSBADS/LoaiPhieuPhauThuat/${this.id}/loai-phieu/${this.stt}`;
    },
    print() {
      window.open(
        `${window.origin}/api/benh-an-phau-thuat-phieu-pttt/${this.id}/print-ba-file/${this.stt}/phieu-phau-thuat-thu-thuat.pdf`,
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
