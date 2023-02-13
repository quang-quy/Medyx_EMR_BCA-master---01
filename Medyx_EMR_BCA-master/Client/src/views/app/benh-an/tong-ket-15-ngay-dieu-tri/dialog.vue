<template>
  <el-dialog :visible.sync="dialog" width="900px">
    <template slot="title">
      <div class="px-3">
        <div style="font-size: 16px; font-weight: bold" class="mb-3">
          {{
              editing
                ? "Cập nhật phiếu sơ kết 15 ngày điều trị"
                : "Thêm mới phiếu sơ kết 15 ngày điều trị"
          }}
        </div>
        <v-progress-linear color="primary" rounded value="100" height="2"></v-progress-linear>
      </div>
    </template>
    <el-form :model="form" :rules="rules" ref="form" class="px-3">
      <v-row>
        <v-col v-if="editing" cols="12" class="padding-cols">
          <el-checkbox v-model="form.huy" :disabled="!disableActions.modify || idhis">Đã hủy</el-checkbox>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Khoa" prop="sttkhoa">
            <base-select-async v-model="form.sttkhoa" placeholder="Tìm kiếm khoa điều trị"
              :label="(item) => `${item.stt} - ${item.khoa.tenKhoa}`" keyValue="stt" :apiFunc="getKhoa"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="3" class="padding-cols">
          <el-form-item label="Từ ngày" prop="tuNgay">
            <el-date-picker v-model="form.tuNgay" format="dd/MM/yyyy" value-format="yyyy-MM-ddTHH:mm:ss"
              placeholder="VD: 09/08/2022" size="small" style="width: 100%"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="3" class="padding-cols">
          <el-form-item label="Đến ngày" prop="denNgay">
            <el-date-picker v-model="form.denNgay" value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy"
              placeholder="VD: 09/08/2022" size="small" style="width: 100%"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Diễn biến lâm sàng">
            <el-input type="textarea" rows="2" v-model="form.dienBienLamSang" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Xét nghiệm cận lâm sàng">
            <el-input type="textarea" rows="3" v-model="form.xnlamSang" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Quá trình điều trị">
            <el-input type="textarea" rows="3" v-model="form.quaTrinhDt" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Đánh giá kết quả">
            <el-input type="textarea" rows="2" v-model="form.danhGiaKq" placeholder="Tốt" size="small">
            </el-input>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Hướng điều trị">
            <el-input type="textarea" rows="2" v-model="form.huongDt" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="3" class="padding-cols">
          <el-form-item label="Ngày ký trưởng khoa">
            <el-date-picker format="dd/MM/yyyy" v-model="form.ngayKyTruongKhoa" value-format="yyyy-MM-ddTHH:mm:ss"
              placeholder="VD: 09/08/2022" size="small" style="width: 100%"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="3" class="padding-cols">
          <el-form-item label="Trưởng khoa">
            <base-select-async v-model="form.truongKhoa" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="3" class="padding-cols">
          <el-form-item label="Ngày ký bác sĩ điều trị" prop="ngayKyBsdieuTri">
            <el-date-picker v-model="form.ngayKyBsdieuTri" value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy"
              placeholder="VD: 09/08/2022" size="small" style="width: 100%"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="3" class="padding-cols">
          <el-form-item label="Bác sĩ điều trị">
            <base-select-async v-model="form.bsdieuTri" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <el-button size="small" @click="dialog = false">Hủy</el-button>
      <el-button size="small" icon="el-icon-plus" type="primary" @click="submit('form')"
        :disabled="(this.editing ? !disableActions.modify : !disableActions.create) || idhis">
        {{ this.editing ? "Cập nhật" : "Thêm mới" }}
      </el-button>
    </span>
  </el-dialog>
</template>
<script>
import dialogMixin from "@/mixins/crud/dialog";
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import { addTongKetDieuTri, updateTongKetDieuTri } from "@/api/tong-ket-15-ngay.js";
export default {
  mixins: [dialogMixin],
  data(vm) {
    return {
      disableActions: {
        create: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/SoKet15NgayDT/create"
        ),
        modify: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/SoKet15NgayDT/modify"
        ),
      },
      form: {
        sttkhoa: null,
        tuNgay: null,
        denNgay: null,
        dienBienLamSang: null,
        xnlamSang: null,
        quaTrinhDt: null,
        danhGiaKq: null,
        huongDt: null,
        ngayKyTruongKhoa: null,
        ngayKyBsdieuTri: null,
        truongKhoa: null,
        bsdieuTri: null,
        huy:false,
      },
      idba: null,
      stt: null,
      idhis: false,
      rules: {
        sttkhoa: [
          { required: true, message: "Phải chọn khoa", trigger: "change" },
        ],
        tuNgay: [
          { required: true, message: "Phải chọn ngày", trigger: "change" },
        ],
        denNgay: [
          { required: true, message: "Phải chọn ngày", trigger: "change" },
        ],
        ngayKyBsdieuTri: [
          { required: true, message: "Phải chọn ngày", trigger: "change" },
        ],
      },
    };
  },
  watch: {
    dialog() {
      if (this.editing) {
        for (let key in this.form) {
          if (this.currentRowData && this.currentRowData.hasOwnProperty(key)) {
            this.form[key] = this.currentRowData[key]
          }
        }
        this.form.bsdieuTri = this.currentRowData.bsdieuTri.maNv
        this.form.truongKhoa = this.currentRowData.truongKhoa.maNv
        this.idhis = this.currentRowData.idhis ? true : false
        this.idba = this.currentRowData.idba
        this.stt = this.currentRowData.stt
        this.form.huy = this.currentRowData.huy ? this.currentRowData.huy : false
      }
      else {
        this.idhis = false
        this.form = {
          sttkhoa: null,
          tuNgay: null,
          denNgay: null,
          dienBienLamSang: null,
          xnlamSang: null,
          quaTrinhDt: null,
          danhGiaKq: null,
          huongDt: null,
          ngayKyTruongKhoa: null,
          ngayKyBsdieuTri: null,
          truongKhoa: null,
          bsdieuTri: null,
          huy: false
        }
      }
    }
  },
  methods: {
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getKhoa(params) {
      const id = window.location.href.split("/").at(-1);
      return await apiKhoaDT.index(id, params);
    },
    submit(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          if (this.editing) {
            this.updatePhieuTongKet();
          }
          else {
            this.addPhieuTongKet();
          }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    async addPhieuTongKet() {
      const id = window.location.href.split("/").at(-1);
      try {
        await addTongKetDieuTri(id, this.form);
        this.$message({
          message: "Thêm mới thành công.",
          type: "success",
        });
        this.dialog = false;
        location.reload()
      } catch (error) {
        console.log(error);
      }
      // 
    },
    async updatePhieuTongKet() {
      try {
        await updateTongKetDieuTri(this.idba, this.stt, this.form);
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
        this.dialog = false;
        location.reload()
      } catch (error) {
        console.log(error);
      }
      // this.dialog = false;
    }
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
  margin-bottom: 8px !important;
}

.el-form-item__label {
  font-size: 13px;
}

.el-form-item__content {
  line-height: 35px;
}
</style>
