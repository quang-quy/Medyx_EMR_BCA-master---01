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
            <el-date-picker
              v-model="form.ngayVv"
              type="datetime"
              size="small"
              value-format="yyyy-MM-ddTHH:mm:ss"
              format="dd/MM/yyyy HH:mm:ss"
              placeholder="dd/mm/yyyy hh:mm:ss"
              style="width: 100%"
            ></el-date-picker>
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
            <el-select
              v-model="form.noiGt"
              filterable
              placeholder="Chọn nơi giới thiệu"
              style="width: 100%"
              size="small"
            >
              <el-option
                v-for="item in noiGioiThieus"
                :key="item.ma"
                :label="item.ten"
                :value="item.ma"
              >
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>

        <v-col cols="4" class="padding-cols">
          <el-form-item label="Tên khoa vào viện">
            <base-select-async
              v-model="form.maKhoaVv"
              placeholder="Tìm kiếm theo tên khoa"
              :label="(item) => `${item.maKhoa} - ${item.tenKhoa}`"
              keyValue="maKhoa"
              :apiFunc="getSelectKhoa"
              style="width: 100%"
              size="small"
            >
            </base-select-async>
          </el-form-item>
        </v-col>

        <v-col cols="4" class="padding-cols">
          <el-form-item label="Ngày vào khoa">
            <el-input v-model="ngayVaoKhoa" disabled size="mini"></el-input>
          </el-form-item>
        </v-col>

        <v-col cols="4" class="padding-cols">
          <el-form-item label="Chuyển viện">
            <el-select
              v-model="form.chuyenVien"
              filterable
              placeholder="Chuyển viện"
              style="width: 100%"
              size="small"
            >
              <el-option
                v-for="item in chuyenVien"
                :key="item.ma"
                :label="item.ten"
                :value="item.ma"
                remote
              >
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>

        <v-col cols="4" class="padding-cols">
          <el-form-item label="Nơi chuyển đến">
            <base-select-async
              v-model="form.maBvChuyenDen"
              placeholder="Tìm kiếm theo tên khoa"
              :label="(item) => `${item.maBv} - ${item.tenBv}`"
              keyValue="maBv"
              :apiFunc="getBenhVien"
              style="width: 100%"
              size="small"
            >
            </base-select-async>
          </el-form-item>
        </v-col>

        <v-col cols="4" class="padding-cols">
          <el-form-item label="Thời gian ra viện">
            <el-date-picker
              v-model="form.ngayRv"
              type="datetime"
              value-format="yyyy-MM-ddTHH:mm:ss"
              format="dd/MM/yyyy HH:mm:ss"
              placeholder="dd/mm/yyyy hh:mm:ss"
              size="small"
              style="width: 100%"
            >
            </el-date-picker>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Hình thức ra viện">
            <el-select
              v-model="form.htraVien"
              filterable
              placeholder="Chọn hình thức ra viện viện"
              style="width: 100%"
              size="small"
            >
              <el-option
                v-for="item in hinhThucRaVien"
                :key="item.ma"
                :label="item.ten"
                :value="item.ma"
              >
              </el-option>
            </el-select>
          </el-form-item>
        </v-col>
        <v-col cols="4" class="padding-cols">
          <el-form-item label="Tổng số ngày điều trị">
            <el-input
              v-model="form.tongSoNgayDt"
              type="number"
              min="0"
              size="small"
              :disabled="true"
            ></el-input>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import {
  // getNhanVien,
  // getBuongKham,
  // getBenhTat,
  getKhoa,
  // getChiTietPhieuKhamVaoVien,
} from "@/api/phieu-kham-benh-vao-vien";
import { getBenhAnKhoaDieuTri } from "@/api/to-dieu-tri";
import { getListBenhVien } from "@/api/danh-muc";
import { formatDate, formatDatetime } from "@/utils/formatters";

export default {
  props: ["benhAn", "benhAnKhoaDieuTri"],
  data: () => ({
    formatDatetime,
    form: {
      ngayVv: null,
      trucTiepVao: null,
      noiGt: null,
      vvlan: null,
      maKhoaVv: null,
      thoiGianVaoKhoa: null,
      soNgayDt: null,
      khoaChuyenDen: null,
      thoiGianChuyenDenKhoa: null,
      chuyenVien: null,
      tenBv: null,
      ngayRv: null,
      htraVien: null,
      tongSoNgayDt: null,
      maBvChuyenDen: null,
    },
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
    ngayVaoKhoa: null,
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
    noiChuyenDen: [
      {
        maBvChuyenDen: "",
        tenBv: "",
      },
    ],
  }),
  computed: {
    tongSoNgayDt: function () {
      if (this.form.ngayVv && this.form.ngayRv) {
        var t2 = new Date(this.form.ngayVv).getTime();
        var t1 = new Date(this.form.ngayRv).getTime();
        return parseInt((t1 - t2) / (24 * 3600 * 1000) + 1);
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
      for (let key in this.form) {
        if (val && val.hasOwnProperty(key)) {
          this.form[key] = val[key];
        }
      }
      var t2 = new Date(this.form.ngayVv).getTime();
      var t1 = new Date(this.form.ngayRv).getTime();
      this.form.tongSoNgayDt = parseInt((t1 - t2) / (24 * 3600 * 1000) + 1);
    },
    form: {
      handler(val) {
        this.$emit("get-quanLyNguoibenh", val);
      },
      deep: true,
    },
  },
  created() {
    this.getBenhAnKhoaDieuTris();
  },
  methods: {
    async getBenhAnKhoaDieuTris() {
      const { data } = await getBenhAnKhoaDieuTri({
        idba: window.location.href.split("/").at(-1),
        huy: false,
        forSelect: true,
        sortBy: "stt",
      });
      this.ngayVaoKhoa = data.length ? formatDatetime(data[0].ngayVaoKhoa) : "";
    },
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
