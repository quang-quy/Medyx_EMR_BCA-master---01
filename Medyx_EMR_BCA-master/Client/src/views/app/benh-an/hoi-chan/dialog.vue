<template>
  <el-dialog :visible.sync="dialog" width="900px">
    <template slot="title">
      <div class="px-3">
        <div style="font-size: 16px; font-weight: bold" class="mb-3">
          {{
          editing
          ? "Cập nhật bệnh án hội chẩn"
          : "Thêm mới bệnh án hội chẩn"
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
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Khoa" prop="sttkhoa">
            <base-select-async v-model="form.sttkhoa" placeholder="Tìm kiếm khoa điều trị"
              :label="(item) => `${item.stt} - ${item.khoa.tenKhoa}`" keyValue="stt" :apiFunc="getKhoa"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Tên phiếu hội chẩn">
            <el-input size="small" v-model="form.tenBienBanHoiChan"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày hội chẩn" prop="ngayHoiChan">
            <el-date-picker type="datetime" format="HH:mm dd:MM:yyyy" size="small" v-model="form.ngayHoiChan" style="width: 100%">
            </el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Chủ trì">
            <base-select-async v-model="form.chuToa" placeholder="Tìm kiếm theo tên" :label="(item) => `${item.hoTen}`"
              keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thư ký">
            <base-select-async v-model="form.thuKy" placeholder="Tìm kiếm theo tên" :label="(item) => `${item.hoTen}`"
              keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thành viên tham gia">
            <el-input v-model="form.thanhVien" size="small"></el-input>
            <!-- <base-select-async v-model="form.thanhVien" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async> -->
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tóm tắt diễn bién">
            <el-input size="small" v-model="form.tomTatDienBienBenh"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Kết luận">
            <el-input size="small" v-model="form.ketLuan"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Hướng điều trị">
            <el-input size="small" v-model="form.huongDt"></el-input>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
    <span slot="footer" class="dialog-footer">
      <el-button size="small" @click="dialog = false">Hủy</el-button>
      <el-button size="small" icon="el-icon-plus" type="primary" @click="submit('form')" :disabled="(editing ? !disableActions.modify : !disableActions.create) || idhis">
        {{editing?'Cập nhật':'Thêm mới'}}
      </el-button>
    </span>
  </el-dialog>
</template>
<script>
import dialogMixin from "@/mixins/crud/dialog";
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiKhoaDT from "@/api/khoa-dieu-tri.js";
import { create, update } from "@/api/ba-hoi-chuan";

export default {
  mixins: [dialogMixin],
  data:(vm) =>({
      disableActions: {
        create: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/HoiChan/create"
        ),
        modify: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/HoiChan/modify"
        ),
      },
      form: {
        sttkhoa: null,
        tenBienBanHoiChan: null,
        ngayHoiChan: null,
        chuToa: null,
        thuKy: null,
        thanhVien: null,
        tomTatDienBienBenh: null,
        ketLuan: null,
        huongDt: null,
        huy:false,
      },
      idba:null,
      stt:null,
      idhis: false,
      rules: {
        sttkhoa: [
          { required: true, message: "Phải chọn khoa", trigger: "change" },
        ],
        ngayHoiChan: [
          { required: true, message: "Phải chọn khoa", trigger: "change" },
        ]
      },
    }),
  watch: {
    dialog() {
      if (this.editing) {
        console.log(this.currentRowData)
        for (let key in this.form) {
          if (this.currentRowData && this.currentRowData.hasOwnProperty(key)) {
            this.form[key] = this.currentRowData[key]
          }
        }
        this.form.chuToa = this.currentRowData.chuToa.maNv
        this.form.thuKy = this.currentRowData.thuKy.maNv
        this.idba = this.currentRowData.idba
        this.stt = this.currentRowData.stt
        this.huy=this.currentRowData.huy ? this.currentRowData.huy : false
        this.idhis = this.currentRowData.idhis ? true : false
      }
      else {
        this.idhis = false
        this.form = {
          sttkhoa: null,
          tenBienBanHoiChan: null,
          ngayHoiChan: null,
          chuToa: null,
          thuKy: null,
          thanhVien: null,
          tomTatDienBienBenh: null,
          ketLuan: null,
          huongDt: null,
          huy:false
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
            this.updateBenhAnHoiChan();
          }
          else {
            this.addBenhAnHoiChan();
          }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    async addBenhAnHoiChan() {
      const id = window.location.href.split("/").at(-1);
      try {
        await create(id, this.form);
        this.$message({
          message: "Thêm mới thành công.",
          type: "success",
        });
        location.reload()
      } catch (error) {
        console.log(error);
      }
      this.dialog = false;
    },
    async updateBenhAnHoiChan() {
      try {
        console.log(this.idba, this.stt, this.form)
        await update(this.idba, this.stt, this.form);
        this.$message({
          message: "Cập nhật thành công.",
          type: "success",
        });
        location.reload()
      } catch (error) {
        console.log(error);
      }
      this.dialog = false;
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
