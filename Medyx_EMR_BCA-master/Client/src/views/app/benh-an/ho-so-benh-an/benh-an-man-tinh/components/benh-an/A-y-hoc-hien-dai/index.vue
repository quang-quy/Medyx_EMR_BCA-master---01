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
        <v-col cols="12" class="padding-cols">
          <el-form-item label="1. Tiền sử bản thân"></el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Bệnh tăng huyết áp:">
            <div>
              <el-radio-group v-model="form.benhTangHa" class="pl-3">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>- Thời điểm phát hiện:</div>
            <div>
              <el-input v-model="form.thoiDiemPhatHienTangHa" size="small"></el-input>
            </div>
            <div>- Nơi điều trị:</div>
            <div>
              <el-input v-model="form.noiDieuTriTangHa" size="small"></el-input>
            </div>
            <div>- Điều trị thường xuyên:</div>
            <div>
              <el-input v-model="form.dieuTriTangHathuongXuyen" size="small"></el-input>
            </div>
            <div>- Đơn trị liệu hay đa trị liệu:</div>
            <div>
              <el-input v-model="form.donDaTriLieuHa" size="small"></el-input>
            </div>
            <div>- Chỉ số huyết áp cao nhất: <i>(mmHg)</i></div>
            <div>
              <el-input v-model="form.chiSoHamax" size="small"></el-input>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12">
          <el-form-item label="Bệnh đái tháo đường">
            <div>
              <el-radio-group v-model="form.benhDtd" class="pl-3">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>- Thời điểm phát hiện:</div>
            <div>
              <el-input v-model="form.thoiDiemPhatHienDtd" size="small"></el-input>
            </div>
            <div>- Nơi điều trị:</div>
            <div>
              <el-input v-model="form.noiDieuTriDtd" size="small"></el-input>
            </div>
            <div>- Điều trị thường xuyên:</div>
            <div>
              <el-input v-model="form.dieuTriDtdthuongXuyen" size="small"></el-input>
            </div>
            <div>- Đơn trị liệu hay đa trị liệu:</div>
            <div>
              <el-input v-model="form.donDaTriLieuDtd" size="small"></el-input>
            </div>
            <div>- Chỉ số đường huyết cao nhất: <i>(Mmol/l)</i></div>
            <div>
              <el-input v-model="form.dtdmax" size="small"></el-input>
            </div>
            <div>- Thực hiện chế độ ăn cho người đái tháo đường:</div>
            <div>
              <el-radio-group v-model="form.thucHienCdanDtd" class="pl-3">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>- Uống thuốc:</div>
            <div>
              <el-radio-group v-model="form.uongThuocDtd" class="pl-3">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>- Loại thuốc:</div>
            <div>
              <el-checkbox @change="getcheckBoxMode()" v-for="(item, index) in loaiThuoc" :key="index"
                v-model="item.checkbox">{{ item.ten }}</el-checkbox>
              <!-- <el-input v-model="form.loaiThuocDtd" size="small"></el-input> -->
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="2. Tiền sử gia đình">
            <br>
            <div>Nam dưới 55 tuổi mắc bệnh tim mạch, huyết áp, đái tháo đường</div>
            <div>
              <el-radio-group v-model="form.namMacTmHaDtd" class="pl-3">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
            <div>Nữ dưới 65 tuổi mắc bệnh tim mạch, huyết áp, đái tháo đường</div>
            <div>
              <el-radio-group v-model="form.nuMacTmHaDtd" class="pl-3">
                <el-radio :label="1">Có</el-radio>
                <el-radio :label="2">Không</el-radio>
              </el-radio-group>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="3.Các yếu tố nguy cơ"></el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <v-row>
            <v-col cols="6">
              <div style="border: 1px solid #d6dbdf" class="pa-4 pb-4">
                <el-form-item label="Hút thuốc lá:">
                  <div>
                    <el-radio-group v-model="form.hutThuoc" class="pl-3">
                      <el-radio :label="1">Có</el-radio>
                      <el-radio :label="2">Không</el-radio>
                    </el-radio-group>
                  </div>
                  <div>
                    Số điếu trên ngày:
                    <el-input-number v-model="form.soDieu" size="mini" controls-position="right" class="ml-3 mr-3" :disabled="(form.hutThuoc==2) ? true : false">
                    </el-input-number>
                    <i>(điếu/ngày)</i>
                  </div>
                  <div>
                    Số bao trên ngày:
                    <el-input-number v-model="form.soBao" size="mini" controls-position="right" class="ml-3 mr-3" :disabled="(form.hutThuoc==2) ? true : false">
                    </el-input-number>
                    <i>(bao/ngày)</i>
                  </div>
                </el-form-item>
              </div>
            </v-col>
            <v-col cols="6">
              <div style="border: 1px solid #d6dbdf" class="pa-4 pb-4">
                <el-form-item label="Uống rượu:">
                  <div>
                    <el-radio-group v-model="form.uongRuou" class="pl-3">
                      <el-radio :label="1">Có</el-radio>
                      <el-radio :label="2">Không</el-radio>
                    </el-radio-group>
                  </div>
                  <div>
                    Lượng rượu uống/ngày:
                    <el-input-number v-model="form.luongRuou" size="mini" controls-position="right" class="ml-3 mr-3" :disabled="(form.uongRuou==2) ? true : false">
                    </el-input-number>
                    <i>(lít/ngày)</i>
                  </div>
                  <br>
                </el-form-item>
              </div>
            </v-col>
            <v-col cols="12" class="padding-cols">
              <el-form-item label="Các yếu tố nguy cơ khác">
                <div>
                  <el-input v-model="form.yeuToNguyCoKhac" size="small"></el-input>
                </div>
              </el-form-item>
            </v-col>
            <v-col cols="3">
              <el-form-item label="Tăng huyết áp">
                <el-radio-group v-model="form.benhPhoiHopTangHa" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3">
              <el-form-item label="Đái tháo đường">
                <el-radio-group v-model="form.benhPhoiHopDtd" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3">
              <el-form-item label="Gout">
                <el-radio-group v-model="form.benhPhoiHopGout" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3">
              <el-form-item label="Bệnh khớp mãn tính">
                <el-radio-group v-model="form.benhPhoiHopKhopManTinh" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="RLCH Lipid">
                <el-radio-group v-model="form.benhPhoiHopRlchLipid" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Bệnh thận">
                <el-radio-group v-model="form.benhPhoiHopThan" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Bệnh mạch vành">
                <el-radio-group v-model="form.benhPhoiHopMachVanh" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="3" class="padding-cols">
              <el-form-item label="Bệnh nội tiết tố">
                <el-radio-group v-model="form.benhPhoiHopNoiTietKhac" class="pl-3" style="width: 100%">
                  <el-radio :label="1">Có</el-radio>
                  <el-radio :label="2">Không</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
            <v-col cols="12">
              <el-form-item label="Bệnh lý khác">
                <div>
                  <el-input v-model="form.benhPhoiHopBenhLyKhac" size="small"></el-input>
                </div>
              </el-form-item>
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="IV. KHÁM BỆNH"></el-form-item>
        </v-col>
        <v-col cols="12">
          <v-row>
            <v-col cols="2" class="padding-cols">
              <el-form-item label="Huyết áp (mmHg):">
                <el-input v-model="form.huyetAp" size="mini" style="width: 100%"></el-input>
              </el-form-item>
            </v-col>
            <v-col cols="2" class="padding-cols">
              <el-form-item label="Cân Nặng (kg):">
                <el-input-number v-model="form.canNang" size="mini" :step="0.1" :min="0" :max="300"
                  controls-position="right" style="width: 100%"></el-input-number>
              </el-form-item>
            </v-col>
            <v-col cols="2" class="padding-cols">
              <el-form-item label="Chiều cao (cm):">
                <el-input-number v-model="form.chieuCao" size="mini" :min="0" :max="300" controls-position="right"
                  style="width: 100%">
                </el-input-number>
              </el-form-item>
            </v-col>
            <v-col cols="2" class="padding-cols">
              <el-form-item label="BMI:">
                <el-input-number v-model="form.bmi" size="mini" :step="0.1" controls-position="right"
                  style="width: 100%">
                </el-input-number>
              </el-form-item>
            </v-col>
            <v-col cols="2" class="padding-cols">
              <el-form-item label="Nhịp tim:" prop="nhipTim">
                <el-input-number v-model="form.nhipTim" size="mini" controls-position="right" style="width: 100%">
                </el-input-number>
              </el-form-item>
            </v-col>
            <v-col cols="2" class="padding-cols">
              <el-form-item label="Nhịp tim đều:">
                <el-radio-group v-model="form.nhipTimDeu" style="width:100%">
                  <el-radio :label="1" class="pb-1">Đều</el-radio>
                  <el-radio :label="2">Không đều</el-radio>
                </el-radio-group>
              </el-form-item>
            </v-col>
          </v-row>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="V. CẬN LÂM SÀNG">
            <br>
            <div>Kết quả xét nghiệm máu:</div>
            <div>
              <el-input v-model="form.kqxnmau" size="small"></el-input>
            </div>
            <div>Kết quả xét nghiệm nước tiểu:</div>
            <div>
              <el-input v-model="form.kqxnnuocTieu" size="small"></el-input>
            </div>
            <div>Kết quả chẩn đoán hình ảnh:</div>
            <div>
              <el-input v-model="form.kqcdha" size="small"></el-input>
            </div>
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
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Bệnh chính:">
            <base-select-async v-model="form.benhChinh.maBenh" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Bệnh kèm theo 1(nếu có):">
            <base-select-async v-model="form.benhKem1.maBenh" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Bệnh kèm theo 2(nếu có):">
            <base-select-async v-model="form.benhKem2.maBenh" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Bệnh kèm theo 3(nếu có):">
            <base-select-async v-model="form.benhKem3.maBenh" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <el-form-item label="Bệnh phân biệt:">
            <base-select-async v-model="form.tenBenhPhanBiet" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
              style="width: 100%" size="small"></base-select-async>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiBenhTat from "@/api/benh-tat.js";
import { getSelectBox } from "@/api/danh-muc.js";
import store from '@/store'
import { chiTietToBenhAn, getTienSuBenh, getKhamYhhd, getTongKetBenhAn, getKhoaDieuTri, getKhamYhct } from "@/api/benh-an.js";
import { getChiTietPhieuKhamVaoVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  data() {
    var checkNhipTim = (rule, value, callback) => {
      if (!value) {
        return callback(new Error('Mục bắt buộc'));
      }
      setTimeout(() => {
        if (value < 0) {
          callback(new Error('Giá trị nhập lớn hơn 0'));
        } else {
          callback();
        }
      }, 1000);
    };
    return {
      form: {
        lyDoVv: null,
        benhSu: null,
        benhTangHa: null,
        thoiDiemPhatHienTangHa: null,
        noiDieuTriTangHa: null,
        dieuTriTangHathuongXuyen: null,
        donDaTriLieuHa: null,
        chiSoHamax: null,
        benhDtd: null,
        thoiDiemPhatHienDtd: null,
        noiDieuTriDtd: null,
        dieuTriDtdthuongXuyen: null,
        donDaTriLieuDtd: null,
        dtdmax: null,
        thucHienCdanDtd: null,
        uongThuocDtd: null,
        loaiThuocDtd: null,
        namMacTmHaDtd: null,
        nuMacTmHaDtd: null,
        hutThuoc: null,
        soDieu: null,
        soBao: null,
        uongRuou: null,
        luongRuou: null,
        yeuToNguyCoKhac: null,
        benhPhoiHopTangHa: null,
        benhPhoiHopDtd: null,
        benhPhoiHopGout: null,
        benhKhopManTinh: null,
        benhPhoiHopRlchLipid: null,
        benhPhoiHopMachVanh: null,
        benhPhoiHopThan: null,
        benhPhoiHopKhopManTinh: null,
        benhPhoiHopNoiTietKhac: null,
        benhPhoiHopBenhLyKhac: null,
        huyetAp: null,
        canNang: null,
        chieuCao: null,
        bmi: null,
        nhipTim: null,
        nhipTimDeu: null,
        kqxnmau: null,
        kqxnnuocTieu: null,
        kqcdha: null,
        tomTatBenhAn: null,
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
        tenBenhPhanBiet: null,
      },
      benhAn: [],
      benh_khac: [
        {
          ten_benh: null,
          ma_benh: null,
        },
      ],
      rules: {
        nhipTim:
        {
          validator: checkNhipTim,
          trigger: "blur",
        },
      },
      loaiThuoc: [
        {
          ten: 'Sulfonylue',
          ma: '192001',
          checkbox: false
        },
        {
          ten: 'Biguanid',
          ma: '192002',
          checkbox: false
        },
        {
          ten: 'Accarbose',
          ma: '192003',
          checkbox: false
        },
        {
          ten: 'Insulin',
          ma: '192004',
          checkbox: false
        },
        {
          ten: 'Thuốc khác',
          ma: '192005',
          checkbox: false
        },
      ],
    }
  },
  mounted() {
    this.getData();
    // this.getLoaiThuoc()
  },
  watch: {
    form: {
      handler(val) {
        this.$emit('get-phanA', val)
        store.dispatch("hosobenhan/setChanDoanYHHD", val)
      },
      deep: true
    },
    "form.canNang": function (val) {
      if (val && this.form.chieuCao) {
        this.form.bmi = (val / ((this.form.chieuCao / 100) * (this.form.chieuCao / 100))).toFixed(2)
      }
    },
    "form.chieuCao": function (val) {
      if (this.form.canNang && val) {
        this.form.bmi = (this.form.canNang / ((val / 100) * (val / 100))).toFixed(2)
      }
    },
    // "form.uongRuou": function(val){

    // },
    // "form.hutThuoc": function(val){

    // },
    CHANDOAN: {
      handler(val) {
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
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getKhamYhhd(id);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
      if (this.form.canNang && this.form.chieuCao) {
        this.form.bmi = (this.form.canNang / ((this.form.chieuCao / 100) * (this.form.chieuCao / 100))).toFixed(2)
      }
      data = await getTienSuBenh(id)
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
      data = await getChiTietPhieuKhamVaoVien(id)
      if (this.form.lyDoVv == null && data && data.data) {
        this.form.lyDoVv = data.data.lyDoVv
      }
      if (this.form.canLamSang == null && data && data.data) {
        this.form.canLamSang = data.data.tomTatKqcls
      }
      this.getLoaiThuoc()
    },
    async getLoaiThuoc() {
      let data = await getSelectBox({ MaParent: "192" });
      this.loaiThuoc = this.setCheckbox(this.form.loaiThuocDtd, data.data);
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
    getcheckBoxMode() {
      let ma = "";
      this.loaiThuoc.forEach(item => {
        if (item.checkbox) {
          ma = ma + item.ma + ","
        }
      })
      this.form.loaiThuocDtd = ma;
    },
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },

  },
};
</script>

<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>