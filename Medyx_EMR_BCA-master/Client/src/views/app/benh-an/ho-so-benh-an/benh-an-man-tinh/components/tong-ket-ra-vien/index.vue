<template>
  <div>
    <div style="width: 100%; font-size: 18px; font-weight: bold" class="d-flex justify-center">
      TỔNG KẾT RA VIỆN
    </div>
    <el-form>
      <v-row>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Lý do vào viện">
            <el-input placeholder="Lý do vào viện" size="small" v-model="form.lyDoVv"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Quá trình bệnh lý và diễn biến lâm sàng">
            <el-input type="textarea" :rows="2" size="small" v-model="form.quaTrinhBenhLy"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tóm Tắt kết quả cận lâm sàng">
            <el-input size="small" v-model="form.tomTatKetQuaCls"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Vào Viện"></el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
            <v-row>
              <v-col cols="12" class="padding-cols mb-2 pt-3">
                <div style="font-weight: 600" class="pb-1">Y học hiện đại</div>
                <hr />
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh chính">
                  <base-select-async v-model="form2.benhChinh.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 1">
                  <base-select-async v-model="form2.benhKem1.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 2">
                  <base-select-async v-model="form2.benhKem2.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 3">
                  <base-select-async v-model="form2.benhKem3.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenh"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Phương pháp điều trị">
                  <el-input v-model="form.ppdttheoYhhd" size="small"></el-input>
                </el-form-item>
              </v-col>
            </v-row>
          </div>
        </v-col>
        <v-col cols="6" class="padding-cols">
          <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
            <v-row>
              <v-col cols="12" class="padding-cols mb-2 pt-3">
                <div style="font-weight: 600" class="pb-1">Y học cổ truyền</div>
                <hr />
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh chính">
                  <base-select-async v-model="form2.maBenhChinhVvyhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 1">
                  <base-select-async v-model="form2.maBenhKemVv1yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 2">
                  <base-select-async v-model="form2.maBenhKemVv2yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 3">
                  <base-select-async v-model="form2.maBenhKemVv3yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Phương pháp điều trị">
                  <el-input v-model="form.ppdttheoYhct" size="small"></el-input>
                </el-form-item>
              </v-col>
            </v-row>
          </div>
        </v-col>
        <v-col cols="6" class="padding-cols mt-3">
          <el-form-item label="Kết quả điều trị">
            <el-select size="small" style="width: 100%" v-model="form.kqdt">
              <el-option v-for="item in ketQuaDieuTri" :key="item.ma" :label="item.ten" :value="item.ma">
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Ra viện"></el-form-item>
        </v-col>
        <v-col cols="6" class="padding-cols mb-3">
          <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
            <v-row>
              <v-col cols="12" class="padding-cols mb-2 pt-3">
                <div style="font-weight: 600" class="pb-1">Y học hiện đại</div>
                <hr />
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh chính">
                  <base-select-async v-model="form2.maBenhChinhRv" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh" :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 1">
                  <base-select-async v-model="form2.maBenhKemRv1" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh" :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 2">
                  <base-select-async v-model="form2.maBenhKemRv2" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh" :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 3">
                  <base-select-async v-model="form2.maBenhKemRv3" :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh" :apiFunc="getChanDoanBenh" placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
            </v-row>
          </div>
        </v-col>
        <v-col cols="6" class="padding-cols mb-3">
          <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
            <v-row>
              <v-col cols="12" class="padding-cols mb-2 pt-3">
                <div style="font-weight: 600" class="pb-1">Y học cổ truyền</div>
                <hr />
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh chính">
                  <base-select-async v-model="form2.maBenhChinhRvyhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 1">
                  <base-select-async v-model="form2.maBenhKemRv1yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 2">
                  <base-select-async v-model="form2.maBenhKemRv2yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Bệnh kèm theo 3">
                  <base-select-async v-model="form2.maBenhKemRv3yhct"
                    :label="(item) => `${item.maBenh} - ${item.tenBenhBhyt}`" keyValue="maBenh" :apiFunc="getChanDoanBenhCT"
                    placeholder="" style="width: 100%" size="small">
                  </base-select-async>
                </el-form-item>
              </v-col>
            </v-row>
          </div>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Tình trạng người bệnh khi ra viện">
            <el-input size="small" v-model="form.tinhTrangBnrv"></el-input>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Hướng điều trị và các chế độ tiếp theo">
            <el-input v-model="form.huongDt" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ X-Quang">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToXquang">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ CT Scanner">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToCt">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ MRI">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToMri">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ siêu âm">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToSa">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ xét nghiệm">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToXn">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Khác">
            <el-input size="small" v-model="form.khac"></el-input>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ khác">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToKhac">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Số tờ toàn bộ hồ sơ">
            <el-input-number style="width: 100%" size="small" controls-position="right" v-model="form.soToToanBoHs">
            </el-input-number>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Người giao hồ sơ">
            <base-select-async v-model="form.nguoiGiaoHs" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen} - ${item.maNv} - ${item.khoa.tenKhoa}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Người nhận hồ sơ">
            <base-select-async v-model="form.nguoiNhanHs" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen} - ${item.maNv} - ${item.khoa.tenKhoa}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Ngày tháng năm ký">
            <el-date-picker type="datetime" style="width: 100%" size="small" v-model="form.ngayKy" format="dd/mm/yyyy HH:mm:ss" value-format="yyyy-MM-ddTHH:mm:ss"
              placeholder="dd/mm/yyyy HH:mm"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col xl="3" lg="3" md="4" cols="3" class="padding-cols">
          <el-form-item label="Bác sĩ khám, chữa bệnh">
            <base-select-async v-model="form.bsdieuTri" placeholder="Tìm kiếm theo tên"
              :label="(item) => `${item.hoTen} - ${item.maNv} - ${item.khoa.tenKhoa}`" keyValue="maNv" :apiFunc="getNhanVien" style="width: 100%"
              size="small"></base-select-async>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiNhanVien from "@/api/nhan-vien.js";
import * as apiBenhTat from "@/api/benh-tat.js";
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import store from '@/store'
import { getSelectBox } from '@/api/danh-muc.js';
import {
  chiTietToBenhAn,
  getTienSuBenh,
  getKhamYhhd,
  getKhoaDieuTri,
  getTongKetBenhAn,
  getKhamYhct,
} from "@/api/benh-an.js";
export default {
  data: () => ({
    ketQuaDieuTri: [
      {
        ma: "130001",
        ten: "Khỏi",
      },
      {
        ma: "130002",
        ten: "Đỡ",
      },
      {
        ma: "130003",
        ten: "Không thay đổi",
      },
      {
        ma: "130004",
        ten: "Chuyển viện"
      },
      {
        ma: "130005",
        ten: "Tử vong"
      },
      {
        ma: "130006",
        ten: "Tiên lượng nặng gia đình xin về"
      }
    ],
    form: {
      ppdttheoYhct:null,
      ppdttheoYhhd:null,
      lyDoVv: null,
      quaTrinhBenhLy: null,
      tomTatKetQuaCls: null,
      tinhTrangBnrv: null,
      soToXquang: null,
      soToCt: null,
      soToMri: null,
      soToSa: null,
      soToXn: null,
      soToKhac: null,
      khac: null,
      soToToanBoHs: null,
      nguoiGiaoHs: null,
      nguoiNhanHs: null,
      ngayKy: null,
      bsdieuTri: null,
      kqdt: null,
      huongDt: null,
    },
    form2:{
      maBenhChinhRv: null,
      maBenhChinhRvyhct: null,
      maBenhKemRv1: null,
      maBenhKemRv1yhct: null,
      maBenhKemRv2: null,
      maBenhKemRv2yhct: null,
      maBenhKemRv3: null,
      maBenhKemRv3yhct: null,
      maBenhChinhVvyhct: null,
      maBenhKemVv1yhct: null,
      maBenhKemVv2yhct: null,
      maBenhKemVv3yhct: null,
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
    }
  }),
  watch: {
    form: {
      handler(val) {
        this.form.soToToanBoHs = this.form.soToXquang + this.form.soToCt +this.form.soToKhac + this.form.soToMri + this.form.soToSa + this.form.soToXn
        this.$emit('get-tongKetRaVien', val)
      },
      deep: true
    },
    form2: {
      handler(val) {
        store.dispatch("hosobenhan/setTongKetRaVien", val)
      },
      deep: true
    },
    CHANDOAN: {
      handler(val) {
        for (let key in this.form2) {
          if (val && val.hasOwnProperty(key)) {
            this.form2[key] = val[key]
          }
        }
      },
      deep: true
    }
  },
  computed: {
    CHANDOAN(){
      return this.$store.state.hosobenhan.dataChanDoan
    }
  },
  mounted() {
    this.getData();
    this.getKetQuaDieuTri();
  },
  methods: {
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getTongKetBenhAn(id)
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key]
        }
      }
      data = await chiTietToBenhAn(id);
      for (let key in this.form2) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form2[key] = data.data[key]
        }
      }
      data = await getKhoaDieuTri({ idba: id, forSelect: true});
      data = data.data[0]
      for (let key in this.form2) {
        if (data && data.data && data.hasOwnProperty(key)) {
          this.form2[key] = data[key]
        }
      }
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
    async getKetQuaDieuTri() {
      let data = await getSelectBox({ MaParent: '131' });
      this.ketQuaDieuTri = data.data
    },
  }
};
</script>

<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
