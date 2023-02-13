<template>
  <div>
    <div style="font-size: 16px; font-weight: bold" class="mb-3">
      A. Y HỌC HIỆN ĐẠI
    </div>
    <el-form :model="form" :rules="rules" ref="form">
      <v-row>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="I. LÝ DO VÀO VIỆN">
            <el-input v-model="form.lyDoVv" type="textarea" rows="2"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="II. BỆNH SỬ">
            <el-input v-model="form.benhSu" type="textarea" rows="2"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="III. TIỀN SỬ"></el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="1. Bản Thân">
            <el-input v-model="form.tienSuBanThan" type="textarea" rows="2"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item>
            <br />
            <el-checkbox @change="setModelFormCheckbox(tienSuBenhAn)" v-for="(item, index) in tienSuBenhAn" :key="index" v-model="item.checkbox">{{ item.ten }}
            </el-checkbox>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Mô tả">
            <el-input v-model="form.moTaTienSu" type="textarea" rows="2"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Đặc điểm liên quan đến bệnh tất">
            <el-input v-model="form.dacDiemLienQuanBenh" type="textarea" rows="2"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="2. Gia đình">
            <el-input v-model="form.tienSuGiaDinh" type="textarea" rows="2"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="IV. KHÁM BỆNH"></el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item>
            <div>
              <div style="font-weight: 500">1. Khám toàn thân:</div>
              <div style="font-style:italic; line-height: 8px;" class="pb-4">
                (Ý thức, da niêm mạc, hệ thống hạch, tuyến giáp, vị trí, kích
                thước, số lượng, di động...)
              </div>
            </div>
            <el-input v-model="form.toanThan" type="textarea" rows="4"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12">
          <v-row>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Mạch (lần/phút):" prop="mach">
                <el-input type="number" v-model="form.mach" size="mini" controls-position="right"
                  style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Nhiệt độ (℃):">
                <el-input type="number" v-model="form.nhietDo" size="mini" :step="0.01"
                  controls-position="right" style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Huyết áp (mmHg):">
                <el-input v-model="form.huyetAp" size="mini" style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Nhịp thở (lần/phút):">
                <el-input type="number" v-model="form.nhipTho" size="mini" controls-position="right" style="width: 100%">
                </el-input>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Cân Nặng (kg):">
                <el-input type="number" v-model="form.canNang" size="mini" :step="0.01"
                  controls-position="right" style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Chiều cao (cm):">
                <el-input type="number" v-model="form.chieuCao" size="mini" :step="0.01"
                  controls-position="right" style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="BMI:">
                <el-input type="number" v-model="form.bmi" size="mini" :step="0.001" controls-position="right" 
                  style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12" class="padding-cols mt-4">
          <el-form-item label="2. Khám bộ phận"></el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tuần hoàn:">
            <el-input v-model="form.tuanHoan" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Hô hấp:"></el-form-item>
          <el-input v-model="form.hoHap" type="textarea"></el-input>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tiêu hóa:">
            <el-input v-model="form.tieuHoa" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tiết niệu-sinh dục:">
            <el-input v-model="form.thanTnieuSduc" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Thần kinh:">
            <el-input v-model="form.thanKinh" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Cơ xương khớp:">
            <el-input v-model="form.xuongKhop" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tai mũi họng:">
            <el-input v-model="form.taiMuiHong" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Răng hàm mặt:">
            <el-input v-model="form.rangHamMat" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Mắt:">
            <el-input v-model="form.mat" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Nội tiết, dinh dưỡng vã các bênh lý khác(nếu có):">
            <el-input v-model="form.noiTietDd" type="textarea"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="V. CẬN LÂM SÀNG">
            <el-input v-model="form.canLamSang" type="textarea" rows="5"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="VI. TÓM TẮT BỆNH ÁN">
            <el-input v-model="form.tomTatBenhAn" type="textarea" rows="6"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="VII. CHẨN ĐOÁN"></el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Bệnh chính:">
            <base-select-async v-model="form.benhChinh.maBenh" :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh"
              :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Bệnh kèm theo 1(nếu có):">
            <base-select-async v-model="form.benhKem1.maBenh" :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh"
              :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Bệnh kèm theo 2(nếu có):">
            <base-select-async v-model="form.benhKem2.maBenh" :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh"
              :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Bệnh kèm theo 3(nếu có):">
            <base-select-async v-model="form.benhKem3.maBenh" :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh"
              :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Bệnh phân biệt:">
            <base-select-async v-model="form.tenBenhPhanBiet" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
              keyValue="maBenh" :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiBenhTat from "@/api/benh-tat.js";
import store from '@/store'
import { getSelectBox } from '@/api/danh-muc.js';
import { chiTietToBenhAn, getTienSuBenh, getKhamYhhd, getTongKetBenhAn, getKhoaDieuTri, getKhamYhct } from "@/api/benh-an.js";
import {getChiTietPhieuKhamVaoVien}from "@/api/phieu-kham-benh-vao-vien";

export default {
  data() {
    var checkMach = (rule, value, callback) => {
      if (!value) {
        return callback(new Error("Phải nhập mạch"));
      }
      setTimeout(() => {
        if (value > 226 || value < 0) {
          callback(new Error("Giá trị nhập lớn hơn 0 và nhỏ hơn 226"));
        } else {
          callback();
        }
      }, 1000);
    };
    return{
      form: {
        benhSu: null,
        bmi: null,
        canLamSang: null,
        canNang: null,
        cdchamSoc: null,
        cddinhDuong: null,
        chieuCao: null,
        dtketHopYhhd: null,
        hoHap: null,
        huyetAp: null,
        idba: null,
        kqcdha: null,
        kqdt: null,
        kqxnmau: null,
        kqxnnuocTieu: null,
        lyDoVv: null,
        mach: null,
        mat: null,
        nhietDo: null,
        nhipTho: null,
        noiTietDd: null,
        rangHamMat: null,
        taiMuiHong: null,
        tenBenhPhanBiet: null,
        thanKinh: null,
        thanTnieuSduc: null,
        tieuHoa: null,
        toanThan: null,
        tomTatBenhAn: null,
        tuanHoan: null,
        xuongKhop: null,
        maTienSu: null,
        moTaTienSu: null,
        tienSuBanThan: null,
        tienSuGiaDinh: null,
        dacDiemLienQuanBenh: null,
        benhChinh: {
          maBenh: null,
          tenBenh: null,
        },
        benhKem1: {
          maBenh: null,
          tenBenh: null,
        },
        benhKem2: {
          maBenh: null,
          tenBenh: null,
        },
        benhKem3: {
          maBenh: null,
          tenBenh: null,
        },
      },
      benh_khac: [
        {
          ten_benh: null,
          ma_benh: null,
        },
      ],
      tienSuBenhAn: [
        { ten: "Dị ứng", checkbox: false },
        { ten: "Rượu", checkbox: false },
        { ten: "Ma Túy", checkbox: false },
        { ten: "Thuốc lá", checkbox: false },
      ],
      rules:{
        mach:[
          {
            validator: checkMach,
            trigger: "blur",
          },
        ],
      }
    }
  },
  mounted() {
    this.getData();
  },
  watch: {
    form: {
      handler(val) {
        this.$emit('get-phanA', val)
        store.dispatch("hosobenhan/setChanDoanYHHD", val)
      },
      deep: true
    },
    "form.canNang": function(val){
      if(val && this.form.chieuCao){
        this.form.bmi=(val/((this.form.chieuCao/100)*(this.form.chieuCao/100))).toFixed(2)
      }
    },
    "form.chieuCao": function(val){
      if(this.form.canNang && val){
        this.form.bmi=(this.form.canNang/((val/100)*(val/100))).toFixed(2)
      }
    },
    CHANDOAN: {
      handler(val) {
        // console.log(22222, val)
        for (let key in this.form) {
          if (val && val.hasOwnProperty(key)) {
            this.form[key] = val[key]
          }
        }
      },
      deep: true
    }
  },
  computed: {
    CHANDOAN() {
      return this.$store.state.hosobenhan.dataChanDoan
    },
  },
  methods: {
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getKhamYhhd(id);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
      data = await getTienSuBenh(id, {getModelNull: true})
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
      data = await getSelectBox({ MaParent: '017' });
      this.tienSuBenhAn = this.setCheckbox(this.form.maTienSu, data.data)
      if(this.form.canNang&&this.form.chieuCao){
        this.form.bmi=(this.form.canNang/((this.form.chieuCao/100)*(this.form.chieuCao/100))).toFixed(2)
      }
      data= await getChiTietPhieuKhamVaoVien(id)
      if(this.form.lyDoVv==null){
        this.form.lyDoVv=data.data.lyDoVv
      }
      if(this.form.canLamSang==null){
        this.form.canLamSang=data.data.tomTatKqcls
      }
    },
    setCheckbox(model, checkBoxArray) {
      if (model) {
        let arrModel = model.split(",")
        arrModel = arrModel.map(item => item = item.trim())
        return checkBoxArray.map(item => {
          item.checkbox = false;
          if (arrModel.includes(item.ma)) {
            item.checkbox = true;
          }
          return item
        })
      }
      return checkBoxArray
    },
    setModelFormCheckbox(arrCheckbox){
      let ma="";
      arrCheckbox.forEach(item=>{
        if(item.checkbox){
          ma=ma+item.ma+","
        }
      }) 
      this.form.maTienSu=ma;
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