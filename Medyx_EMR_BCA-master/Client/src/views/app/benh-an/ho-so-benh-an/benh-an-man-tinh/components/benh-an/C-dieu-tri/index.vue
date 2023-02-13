<template>
  <div class="pt-4">
    <div style="font-size: 16px; font-weight: bold" class="mb-3 mt-4">
      C. ĐIỀU TRỊ
    </div>
    <el-form>
      <v-row>
        <v-col cols="12" class="padding-cols mt-2 mb-1">
          <label>I. Y HỌC CỔ TRUYỀN</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Điều trị đơn thuần y học cổ truyền">
            <el-radio-group
              v-model="form.dtdonThuanYhct"
              class="pl-3"
              style="width: 100%"
            >
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Pháp điều trị YHCT">
            <el-input v-model="form.ppdtyhct" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Phương dược:">
            <el-input v-model="form.phuongDuoc" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Các phương pháp khác theo YHCT:">
            <el-input v-model="form.ppkhac" size="small"></el-input>
            <div>Phương huyệt:</div>
            <div>
              <el-input v-model="form.phuongHuyet" size="small"></el-input>
            </div>
            <div>Xoa bóp bấm huyệt</div>
            <div>
              <el-input v-model="form.xoaBopBamHuyet" size="small"></el-input>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-4 pt-2 mb-1">
          <label>II. Y HỌC HIỆN ĐẠI: Hướng điều trị</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Điều trị kết hợp với YHHĐ">
            <el-radio-group v-model="form.dtketHopYhhd" style="width: 100%">
              <el-radio :label="1">Có</el-radio>
              <el-radio :label="2">Không</el-radio>
            </el-radio-group>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Phương pháp điều trị kết hợp với YHHĐ">
            <el-input
              v-model="form.ppdtyhhd"
              type="textarea"
              rows="4"
            ></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Kết quả điều trị kết hợp với YHHĐ">
            <el-input v-model="form.kqdt" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Hướng dẫn điều trị theo YHHĐ">
            <el-input
              v-model="form.huongDtyhhd"
              type="textarea"
              rows="4"
            ></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày hẹn khám lại">
            <el-date-picker
              v-model="form.ngayHenKhamLai"
              size="small"
              style="width: 100%"
            ></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày hẹn xét nghiệm lại">
            <el-date-picker
              v-model="form.ngayHenXnlai"
              size="small"
              style="width: 100%"
            ></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Chế độ chăm sóc">
            <el-select
              v-model="form.cdchamSoc"
              style="width: 100%"
              size="small"
            >
              <el-option
                v-for="item in cheDoChamsoc"
                :key="item.ma"
                :value="item.ma"
                :label="item.ten"
              ></el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Chế độ dinh dưỡng:">
            <el-checkbox
              @change="getcheckBoxMode()"
              v-for="(item, index) in cheDoDinhDuong"
              :key="index"
              v-model="item.checkbox"
              >{{ item.ten }}</el-checkbox
            >
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mt-4 pt-2 mb-1">
          <label>III. DỰ HẬU (TIÊN LƯỢNG)</label>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <el-input v-model="form.tienLuong" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>
        <!-- <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày giờ khám bệnh">
            <el-date-picker
              v-model="form.ngayKham"
              style="width: 100%"
              type="datetime"
              size="small"
            ></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thầy thuốc khám bệnh chữa bệnh">
            <base-select-async
              v-model="form.bsdieuTri"
              placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen}`"
              keyValue="maNv"
              :apiFunc="getNhanVien"
              style="width: 100%"
              size="small"
            ></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Trạng thái">
            <el-select
              v-model="form.trangThai"
              style="width: 100%"
              size="small"
            >
              <el-option
                v-for="(item, index) in trangThai"
                :key="index"
                :value="item"
              ></el-option>
            </el-select>
          </el-form-item>
        </v-col> -->
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import { getSelectBox } from "@/api/danh-muc.js";
import {
  chiTietToBenhAn,
  getTienSuBenh,
  getKhamYhhd,
  getTongKetBenhAn,
  getKhoaDieuTri,
  getKhamYhct,
} from "@/api/benh-an.js";
export default {
  data: () => ({
    form: {
      dtdonThuanYhct: null,
      ppdtyhct: null,
      phuongDuoc: null,
      phuongHuyet: null,
      xoaBopBamHuyet: null,
      dtketHopYhhd: null,
      ppkhac: null,
      ppdtyhhd: null,
      kqdt: null,
      huongDtyhhd: null,
      ngayHenKhamLai: null,
      ngayHenXnlai: null,
      cddinhDuong: null,
      cdchamSoc: null,
      tienLuong: null,
      ngayKham: null,
      bsdieuTri: null,
      trangThai: null,
    },
    trangThai: ["Đã kí", "Chưa kí"],
    cheDoDinhDuong: [
      {
        checkbox: false,
        ten: "Lỏng",
      },
      {
        checkbox: false,
        ten: "Đặc",
      },
      {
        checkbox: false,
        ten: "Kiêng",
      },
      {
        checkbox: false,
        ten: "Khác",
      },
    ],
    cheDoChamsoc: [
      {
        ma: '1',
        ten: "Cấp I",
      },
      {
        ma: '2',
        ten: "Cấp II",
      },
      {
        ma: '3',
        ten: "Cấp III",
      },
    ],
  }),
  mounted() {
    this.getData();
  },
  watch: {
    form: {
      handler(val) {
        this.$emit('get-phanC', val)
      },
      deep: true
    },
  },
  methods: {
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getKhamYhhd(id);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key];
        }
      }
      data = await getKhamYhct(id);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key];
        }
      }
      await this.getCheDoDinhDuong();
    },
    async getNhanVien(params) {
      return await apiNhanVien.index(params);
    },
    async getCheDoDinhDuong() {
      let data = await getSelectBox({ MaParent: "128" });
      this.cheDoDinhDuong = this.setCheckbox(this.form.cddinhDuong, data.data);
    },
    setCheckbox(model, checkBoxArray) {
      if (model) {
        let arrModel = model.split(",");
        arrModel = arrModel.map((item) => (item = item.trim()));
        return checkBoxArray.map((item) => {
          item.checkbox = false;
          if (arrModel.includes(item.ma)) {
            item.checkbox = true;
          }
          return item;
        });
      }
      return checkBoxArray;
    },
    getcheckBoxMode(){
      let ma="";
      this.cheDoDinhDuong.forEach(item=>{
        if(item.checkbox){
          ma=ma+item.ma+","
        }
      }) 
      this.form.cddinhDuong=ma;
    }
  },
};
</script>

<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
