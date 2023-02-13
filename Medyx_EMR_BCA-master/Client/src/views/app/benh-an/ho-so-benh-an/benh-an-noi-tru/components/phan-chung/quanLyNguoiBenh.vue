<template>
  <div>
    <div class="mb-4">
      <div style="font-size: 16px; font-weight: bold">
        II. QUẢN LÝ NGƯỜI BỆNH
      </div>
    </div>
    <el-form>
      <v-row :gutters="20">
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày giờ vào viện">
            <el-date-picker v-model="form.ngayVv" type="datetime" size="small" placeholder="dd/mm/yyyy hh:mm"
              style="width: 100%" format="dd/MM/yyyy HH:mm" value-format="yyyy-MM-ddTHH:mm:ss"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Trực tiếp vào">
            <el-select v-model="form.trucTiepVao" filterable clearable placeholder="Trực tiếp vào" style="width: 100%" size="small">
              <el-option v-for="item in trucTiepVaos" :key="item.ma" :label="item.ten" :value="item.ma">
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Nơi giới thiệu">
            <el-select v-model="form.noiGt" filterable clearable placeholder="Chọn nơi giới thiệu" style="width: 100%"
              size="small">
              <el-option v-for="item in noiGioiThieus" :key="item.ma" :label="item.ten" :value="item.ma">
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Vào viện do bệnh này lần thứ">
            <el-input v-model="form.vvlan" dense outlined type="number" :min="0" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Tên khoa vào viện">
            <base-select-async v-model="form.maKhoaVv" placeholder="Tìm kiếm theo tên khoa" clearable
              :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`" keyValue="maKhoa" :apiFunc="getSelectKhoa"
              style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols mb-4 mt-2">
          <el-form-item label="Chuyển khoa">
            <br />
            <el-table :data="khoaDieuTris" style="width: 99%" border size="mini">
              <el-table-column type="index" label="STT" width="80">
              </el-table-column>
              <el-table-column prop="khoa.maKhoa" label="Mã khoa" width="120">
              </el-table-column>
              <el-table-column prop="khoa.tenKhoa" label="Tên khoa chuyển đến"></el-table-column>
              <el-table-column prop="buong.tenBuong" label="Buồng" width="90">
              </el-table-column>
              <el-table-column prop="giuong.tenGiuong" label="Giường" width="90">
              </el-table-column>
              <el-table-column prop="ngayVaoKhoa" label="Thời gian">
                <template slot-scope="scope">
                  <div v-if="scope.row.ngayVaoKhoa">
                    {{
                        new Date(scope.row.ngayVaoKhoa).toLocaleString("en-GB") 
                    }}
                  </div>
                </template>
              </el-table-column>
              <el-table-column prop="soNgayDt" label="Số ngày điều trị">
                <template slot-scope="scope">
                  <div v-if="scope.row.soNgayDt">
                    {{ scope.row.soNgayDt }} (ngày)
                  </div>
                </template>
              </el-table-column>
            </el-table>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Chuyển viện">
            <el-select v-model="form.chuyenVien" clearable filterable placeholder="Chuyển viện" style="width: 100%" size="small">
              <el-option v-for="item in chuyenVien" :key="item.ma" :label="item.ten" :value="item.ma" remote>
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Nơi chuyển đến">
            <base-select-async v-model="form.maBvChuyenDen" placeholder="Tìm kiếm theo tên khoa" clearable
              :label="(item) => `${item.maBv} - ${item.tenBv}`" keyValue="maBv" :apiFunc="getBenhVien"
              style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thời gian ra viện">
            <el-date-picker v-model="form.ngayRv" type="datetime" placeholder="dd/mm/yyyy hh:mm" size="small"
              style="width: 100%" format="dd/MM/yyyy HH:mm" value-format="yyyy-MM-ddTHH:mm:ss"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Hình thức ra viện">
            <el-select v-model="form.htraVien" clearable filterable placeholder="Chọn hình thức ra viện viện" style="width: 100%"
              size="small">
              <el-option v-for="item in hinhThucRaVien" :key="item.ma" :label="item.ten" :value="item.ma">
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Tổng số ngày điều trị">
            <el-input v-model="tongSoNgayDt" type="number" min="0" size="small" :disabled="true"></el-input>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import { getKhoa } from "@/api/phieu-kham-benh-vao-vien";
import { getListBenhVien } from "@/api/danh-muc";
export default {
  props: ["benhAn", "benhAnKhoaDieuTri"],
  data: () => ({
    form: {
      ngayVv: null,
      trucTiepVao: null,
      noiGt: null,
      vvlan: null,
      maKhoaVv: null,
      ngayVaoKhoa: null,
      soNgayDt: null,
      maKhoa: null,
      chuyenVien: null,
      tenBv: null,
      ngayRv: null,
      htraVien: null,
      maBv: null,
      tongSoNgayDt: null, 
      maBvChuyenDen:null
    },

    pickerOptions: {
      disabledDate(time) {
        return time.getTime() > Date.now();
      },
    },
    noiGioiThieus: [
      {
        ma: "1",
        ten: "Cơ quan y tế",
      },
      {
        ma: "2",
        ten: "Tự đến",
      },
      {
        ma: "3",
        ten: "Khác",
      },
    ],
    trucTiepVaos: [
      {
        ma: "1",
        ten: "Cấp cứu",
      },
      {
        ma: "2",
        ten: "KKB",
      },
      {
        ma: "3",
        ten: "Khoa điều trị",
      },
    ],
    chuyenVien: [
      {
        ma: "1",
        ten: "Tuyến trên",
      },
      {
        ma: "2",
        ten: "Tuyến dưới",
      },
      {
        ma: "3",
        ten: "CK",
      },
    ],
    hinhThucRaVien: [
      {
        ma: "1",
        ten: "Ra viện",
      },
      {
        ma: "2",
        ten: "Chuyển viện",
      },
      {
        ma: "3",
        ten: "Trốn viện",
      },
      {
        ma: "4",
        ten: "Xin ra viện",
      },
    ],
    khoaDieuTris: [],
  }),
  computed: {
    tongSoNgayDt: function () {
      if (
        this.benhAnKhoaDieuTri &&
        this.benhAnKhoaDieuTri[0] &&
        this.benhAnKhoaDieuTri[0].ngayVaoKhoa &&
        this.form.ngayRv
      ) {
        var t2 = new Date(this.benhAnKhoaDieuTri[0].ngayVaoKhoa).getTime();
        var t1 = new Date(this.form.ngayRv).getTime();
        var tong = parseInt((t1 - t2) / (24 * 3600 * 1000) + 1)
        this.form.tongSoNgayDt = tong
        return tong;
      }
      return 0;
    },
  },
  watch: {
    benhAn: function (val) {
      for (let key in this.form) {
        if (val && val.hasOwnProperty(key)) {
          this.form[key] = val[key];
        }
      }
    },
    benhAnKhoaDieuTri: function (val) {
      if (val) {
        val.forEach((item, index) => {
          let a = {};
          a.khoa = item.khoa;
          a.buong = item.buong;
          a.giuong = item.giuong;
          a.ngayVaoKhoa = item.ngayVaoKhoa;
          if (index < val.length - 1) {
            a.soNgayDt = this.gettongSoNgayDieuTri(
              val[index + 1].ngayVaoKhoa,
              item.ngayVaoKhoa
            );
          } else if (index == val.length - 1) {
            if (this.form.ngayRv) {
              a.soNgayDt = this.gettongSoNgayDieuTri(
                this.form.ngayRv,
                item.ngayVaoKhoa
              );
            }
          }
          if(index!=0){
            this.khoaDieuTris.push(a);
          }
        });
      }
    },
    form: {
      handler(val) {
        this.$emit('get-quanLyNguoibenh', val)
      },
      deep: true
    }
  },
  mounted() { },
  methods: {
    async getSelectKhoa(params) {
      return await getKhoa({ ...params, loai: 1 });
    },
    gettongSoNgayDieuTri(d1, d2) {
      var t2 = new Date(d2).getTime();
      var t1 = new Date(d1).getTime();
      return parseInt((t1 - t2) / (24 * 3600 * 1000) + 1);
    },
    async getBenhVien(params) {
      return await getListBenhVien(params);
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
  margin-bottom: -6px !important;
}

.el-form-item {
  margin-bottom: 0px !important;
}

.el-form-item__label {
  font-size: 13px;
}

.el-form-item__content {
  line-height: 35px;
}
</style>
