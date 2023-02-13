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
            <el-date-picker v-model="form.ngayVv" value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy HH:mm:ss"
              type="datetime" size="small" placeholder="dd/mm/yyyy hh:mm:ss" style="width: 100%"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Nơi giới thiệu">
            <el-select v-model="form.noiGt" filterable placeholder="Chọn nơi giới thiệu" style="width: 100%"
              size="small">
              <el-option v-for="item in noiGioiThieus" :key="item.ma" :label="item.ten" :value="item.ma">
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Tên khoa vào viện">
            <base-select-async v-model="form.maKhoaVv" placeholder="Tìm kiếm theo tên khoa"
              :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`" keyValue="maKhoa" :apiFunc="getSelectKhoa"
              style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Khoa chuyển đến">
            <base-select-async v-model="maKhoa" placeholder="Tìm kiếm theo tên khoa" :disabled="true"
              :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`" keyValue="maKhoa" :apiFunc="getSelectKhoa"
              style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Nơi chuyển đến">
            <base-select-async v-model="form.maBvChuyenDen" placeholder="Tìm kiếm theo tên khoa"
              :label="(item) => `${item.maBv} - ${item.tenBv}`" keyValue="maBv" :apiFunc="getBenhVien"
              style="width: 100%" size="small">
            </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thời gian ra viện">
            <el-date-picker v-model="form.ngayRv" value-format="yyyy-MM-ddTHH:mm:ss" format="dd/MM/yyyy HH:mm:ss"
              type="datetime" placeholder="dd/mm/yyyy hh:mm:ss" size="small" style="width: 100%"></el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Hình thức ra viện">
            <el-select v-model="form.htraVien" filterable placeholder="Chọn hình thức ra viện viện" style="width: 100%"
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
import {
  getNhanVien,
  getBuongKham,
  getBenhTat,
  getKhoa,
  getChiTietPhieuKhamVaoVien,
} from "@/api/phieu-kham-benh-vao-vien";
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
      chuyenVien: null,
      maBv: null,
      maBvChuyenDen: null,
      ngayRv: null,
      htraVien: null,
      tongSoNgayDt: null,
    },
    maKhoa:null,
    pickerOptions: {
      disabledDate(time) {
        return time.getTime() > Date.now();
      },
    },
    noiGioiThieus: [
      {
        ma: '1',
        ten: "Cơ quan y tế",
      },
      {
        ma: '2',
        ten: "Tự đến",
      },
      {
        ma: '3',
        ten: "Khác"
      },
    ],
    trucTiepVaos: [
      {
        ma: '1',
        ten: "Cấp cứu"
      },
      {
        ma: '2',
        ten: "KKB",
      },
      {
        ma: '3',
        ten: "Khoa điều trị"
      }
    ],
    chuyenVien: [
      {
        ma: '1',
        ten: 'Tuyến trên',
      },
      {
        ma: '2',
        ten: 'Tuyến dưới',
      },
      {
        ma: '3',
        ten: 'CK',
      }
    ],
    hinhThucRaVien: [
      {
        ma: '1',
        ten: 'Ra viện',
      },
      {
        ma: '2',
        ten: 'Chuyển viện',
      },
      {
        ma: '3',
        ten: 'Trốn viện',
      },
      {
        ma: '4',
        ten: 'Xin ra viện'
      }
    ],
    noiChuyenDen: [
      {
        maBvChuyenDen: null,
        tenBv: null,
      },
    ],
  }),
  computed: {
    tongSoNgayDt: function () {
      if (
        this.form.ngayVv &&
        this.form.ngayRv
      ) {
        var t2 = new Date(this.form.ngayVv).getTime();
        var t1 = new Date(this.form.ngayRv).getTime();
        var tong = parseInt((t1 - t2) / (24 * 3600 * 1000) + 1);
        this.form.tongSoNgayDt = tong;
        return tong;
      }
      return 0;
    },
  },
  watch: {
    benhAn: function (val) {
      for (let key in this.form) {
        if (val && val.hasOwnProperty(key)) {
          this.form[key] = val[key]
        }
      }
    },
    benhAnKhoaDieuTri: function (val) {
      if(val.length>1){
        this.maKhoa=val[1].maKhoa
      }
      // this.maKhoa=val.maKhoa
      // for (let key in this.form) {
      //   if (val && val.hasOwnProperty(key)) {
      //     this.form[key] = val[0][key]
      //   }
      // }
    },
    form: {
      handler(val) {
        this.$emit('get-quanLyNguoibenh', val)
      },
      deep: true
    }
  },
  mounted() {
  },
  methods: {
    async getSelectKhoa(params) {
      return await getKhoa({ ...params, loai: 1 });
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