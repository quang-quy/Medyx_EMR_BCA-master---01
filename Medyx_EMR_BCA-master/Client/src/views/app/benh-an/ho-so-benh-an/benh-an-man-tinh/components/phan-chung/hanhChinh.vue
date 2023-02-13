<template>
  <div>
    <div style="font-size: 16px; font-weight: bold">I. HÀNH CHÍNH</div>
    <div class="mt-3">
      <v-row :gutters="20">
        <v-col cols="6" class="d-flex align-end padding-cols">
          <div class="mr-2 title-lable">Họ tên:</div>
          <div style="font-weight: 600" class="content-pchung">
            {{ form.hoTen }}
          </div>
        </v-col>

        <v-col cols="3" class="d-flex align-end padding-cols">
          <div class="mr-2 title-lable">Ngày sinh:</div>
          <div class="content-pchung">
            {{
              form.ngaySinh
                ? new Date(form.ngaySinh).toLocaleDateString("en-GB")
                : ""
            }}
          </div>
        </v-col>
        <v-col cols="2" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Dân tộc:</div>
          <div class="content-pchung">
            {{ form.danToc ? form.danToc.tenDanToc : "" }}
          </div>
        </v-col>
        <v-col cols="1" class="d-flex align-end padding-cols">
          <div class="mr-2 title-lable">Tuổi:</div>
          <div class="content-pchung">{{ form.tuoi }}</div>
        </v-col>

        <v-col cols="3" class="d-flex align-end padding-cols">
          <div class="mr-4 title-lable">Giới tính:</div>
          <el-radio-group
            row
            hide-details
            v-model="form.gioiTinh"
            style="padding-bottom: 6px"
          >
            <el-radio :label="1">Nam</el-radio>
            <el-radio :label="2">Nữ</el-radio>
          </el-radio-group>
        </v-col>
        <v-col cols="3" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Nghề nghiệp:</div>
          <div class="content-pchung">
            {{ form.ngheNghiep ? form.ngheNghiep.tenNn : "" }}
          </div>
        </v-col>
        <v-col cols="6" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Quốc tịch:</div>
          <div class="content-pchung">
            {{ form.quocGia ? form.quocGia.tenQg : "" }}
          </div>
        </v-col>
        <v-col cols="6" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Nơi làm việc:</div>
          <div class="content-pchung">{{ form.noiLamViec }}</div>
        </v-col>
        <v-col cols="6" class="d-flex align-end padding-cols">
          <div class="mr-2 title-lable">Đối tượng:</div>
          <el-radio-group
            row
            hide-details
            v-model="form.doiTuong.maDt"
            style="padding-bottom: 6px"
            @change="thayDoiDoiTuong()"
          >
            <el-radio label="1">BHXH</el-radio>
            <el-radio label="2">Thu phí</el-radio>
            <el-radio label="3">Miễn</el-radio>
            <el-radio label="4">Khác</el-radio>
          </el-radio-group>
        </v-col>
        <v-col cols="3" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Số thẻ BHYT:</div>
          <div class="content-pchung">{{ form.soTheBhyt }}</div>
        </v-col>
        <v-col cols="3" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Giá trị thẻ BHYT đến:</div>
          <div class="content-pchung">
            {{
              form.gtbhytdn
                ? new Date(form.gtbhytdn).toLocaleDateString("en-GB")
                : ""
            }}
          </div>
        </v-col>

        <v-col cols="6" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">
            Họ tên, địa chỉ người nhà khi cần báo tin:
          </div>
          <div class="content-pchung">{{ form.lienHe }}</div>
        </v-col>
        <v-col cols="9" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Địa chỉ hiện tại:</div>
          <div class="content-pchung">{{ diaChi }}</div>
        </v-col>
        <v-col cols="3" class="d-flex align-end padding-cols">
          <div class="mr-2 pt-4 title-lable">Số điện thoại:</div>
          <div class="content-pchung">{{ form.soDienThoai }}</div>
        </v-col>
      </v-row>
    </div>
  </div>
</template>

<script>
import { getDetailBenhAn } from "@/api/benh-an.js";
export default {
  data: () => ({
    form: {
      doiTuong: {},
    },
    diaChi: "",
  }),
  mounted() {
    this.getThongTinChung();
  },
  methods: {
    thayDoiDoiTuong(){
      this.form.gtbhytdn=null
    },
    async getThongTinChung() {
      let res = null;
      const id = window.location.href.split("/").at(-1);
      res = await getDetailBenhAn(id);
      this.form = res.data.benhNhan;
      this.getDiaChi();
    },
    getDiaChi() {
      this.diaChi = `${this.form.soNha ? (this.form.soNha) :''} ${this.form.thon? (',' + this.form.thon) : ""} ${
        this.form.phuongXa ? (this.form.phuongXa.tenPxa ? (',' + this.form.phuongXa.tenPxa) : "") :''
      }  ${this.form.quanHuyen ? (this.form.quanHuyen.tenQh ? (',' + this.form.quanHuyen.tenQh) : "") :''}  ${
        this.form.tinh ? (this.form.tinh.tenTinh ? (',' + this.form.tinh.tenTinh) : "") : ''
      } ${ this.form.quocGia ?(this.form.quocGia.tenQgtenQg ? (',' + this.form.quocGia.tenQg) : "") : ''} `;
    },
  },
};
</script>

<style scoped>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
.title-lable {
  font-weight: 500;
}
.content-pchung {
  border-bottom: 1px solid #cacfd2;
  widows: 100%;
  flex: 1;
}
</style>
