<template>
  <div>
    <v-dialog v-model="show_dialog" scrollable max-width="950px">
      <v-card>
        <v-card-title>Thêm phiếu dinh dưỡng</v-card-title>
        <v-card-text class="mt-4">
          <v-container>
            <v-row>
              <v-col cols="4" sm="6" class="padding-cols">
                <div class="title-field">1. Khoa</div>
                <el-select v-model="form.khoa" filterable :disabled="show">
                  <el-option
                    v-for="(item, index) in khoa_select"
                    :key="index"
                    :value="item"
                  ></el-option>
                </el-select>
                <!-- <v-autocomplete
                  dense
                  v-model="form.khoa"
                  :items="khoa_select"
                  outlined
                >
                </v-autocomplete> -->
              </v-col>
              <v-col cols="4" sm="6" class="padding-cols">
                <div class="title-field">2. Ngày đánh giá</div>
                <el-date-picker
                  v-model="form.ngay_danh_gia"
                  type="datetime"
                  :disabled="show"
                ></el-date-picker>
                <!-- <v-text-field
                  dense
                  v-model="form.ngay_danh_gia"
                  type="datetime-local"
                  outlined
                >
                </v-text-field> -->
              </v-col>
              <v-col cols="3" sm="3" class="padding-cols">
                <div class="title-field">3. Cân nặng (kg)</div>
                <el-input
                  v-model="form.can_nang"
                  type="number"
                  min="0"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field
                  dense
                  v-model="form.can_nang"
                  type="number"
                  min="0"
                  outlined
                >
                </v-text-field> -->
              </v-col>
              <v-col cols="3" sm="3" class="padding-cols">
                <div class="title-field">4. Chiều cao (cm)</div>
                <el-input
                  v-model="form.chieu_cao"
                  type="number"
                  min="0"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field
                  dense
                  v-model="form.chieu_cao"
                  type="number"
                  min="0"
                  outlined
                >
                </v-text-field> -->
              </v-col>
              <v-col cols="6" sm="6" class="padding-cols">
                <div class="title-field">5. BMI</div>
                <el-input
                  v-model="form.BMI"
                  type="number"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field dense v-model="form.BMI" type="number" outlined>
                </v-text-field> -->
              </v-col>

              <v-col cols="6" sm="6" class="padding-cols">
                <div class="title-field">6. Có sụt cân không</div>
                <v-radio-group v-model="form.sut_can" row :disabled="show">
                  <v-radio label="Có" :value="1"></v-radio>
                  <v-radio label="Không" :value="2"></v-radio>
                  <v-radio label="Không rõ" :value="3"></v-radio>
                </v-radio-group>
              </v-col>
              <v-col
                v-if="this.form.sut_can == 1"
                cols="3"
                sm="3"
                class="padding-cols"
              >
                <div class="title-field">7. Số cân bị sụt</div>
                <el-select v-model="form.so_can_sut" :disabled="show">
                  <el-option
                    v-for="(item, index) in so_can_sut_select"
                    :key="index"
                    :value="item"
                  ></el-option>
                </el-select>
                <!-- <v-select
                  dense
                  v-model="form.so_can_sut"
                  :items="so_can_sut_select"
                  outlined
                ></v-select> -->
              </v-col>
              <v-col
                v-if="this.form.sut_can == 1"
                cols="3"
                sm="3"
                class="padding-cols"
              >
                <div class="title-field">8. Chỉ số sụt cân</div>
                <el-input
                  v-model="form.chi_so_sut_can"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field dense v-model="form.chi_so_sut_can" outlined>
                </v-text-field> -->
              </v-col>
              <v-col cols="6" sm="6" class="padding-cols">
                <div class="title-field">
                  9. Ăn kém do giảm cảm giác thèm ăn
                </div>
                <v-radio-group
                  v-model="form.an_kem_do_giam_cam_gac_them_an"
                  row
                  :disabled="show"
                >
                  <v-radio label="Có" :value="true"></v-radio>
                  <v-radio label="Không" :value="false"></v-radio>
                </v-radio-group>
              </v-col>
              <v-col cols="3" sm="3" class="padding-cols">
                <div class="title-field">10. Chỉ số ngon miệng</div>
                <el-input
                  v-model="form.chi_so_sut_can"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field dense v-model="form.chi_so_sut_can" outlined>
                </v-text-field> -->
              </v-col>
              <v-col cols="3" sm="3" class="padding-cols">
                <div class="title-field">11. Chỉ số MST</div>
                <el-input v-model="form.chi_so_MST" :disabled="show"></el-input>
                <!-- <v-text-field
                  dense
                  v-model="form.chi_so_MST"
                  outlined
                ></v-text-field> -->
              </v-col>
              <v-col cols="6" sm="6" class="padding-cols">
                <div class="title-field">12. Đánh giá theo chỉ số MST</div>
                <el-input
                  v-model="form.danh_gia_theo_chi_so_MST"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field
                  dense
                  v-model="form.danh_gia_theo_chi_so_MST"
                  outlined
                >
                </v-text-field> -->
              </v-col>
              <v-col cols="6" sm="6" class="padding-cols">
                <div class="title-field">13. Can thiệp dinh dưỡng</div>
                <el-input
                  v-model="form.can_thiep_dinh_duong"
                  :disabled="show"
                ></el-input>
                <!-- <v-text-field
                  dense
                  v-model="form.can_thiep_dinh_duong"
                  outlined
                >
                </v-text-field> -->
              </v-col>
              <v-col cols="3" sm="3" class="padding-cols">
                <div class="title-field">14. Người đánh giá</div>
                <el-select v-model="form.nguoi_danh_gia" :disabled="show">
                  <el-option
                    v-for="(item, index) in nhan_vien_select"
                    :key="index"
                    :value="item"
                  ></el-option>
                </el-select>
                <!-- <v-autocomplete
                  dense
                  v-model="form.nguoi_danh_gia"
                  :items="nhan_vien_select"
                  outlined
                ></v-autocomplete> -->
              </v-col>
              <v-col cols="3" sm="3" class="padding-cols">
                <div class="title-field">15. Bác sĩ điều trị</div>
                <el-select v-model="form.bac_si_dieu_tri" :disabled="show">
                  <el-option
                    v-for="(item, index) in nhan_vien_select"
                    :key="index"
                    :value="item"
                  ></el-option>
                </el-select>
                <!-- <v-autocomplete
                  dense
                  v-model="form.bac_si_dieu_tri"
                  :items="nhan_vien_select"
                  outlined
                >
                </v-autocomplete> -->
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="huy()"> Hủy </v-btn>
          <v-btn color="blue darken-1" text @click="add()"> Thêm mới </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import { getKhoa, getNhanVien } from "@/api/phieu-kham-benh-vao-vien";
export default {
  data: () => ({
    show_dialog: false,
    show: false,
    form: {
      khoa: null,
      ngay_danh_gia: null,
      can_nang: null,
      chieu_cao: null,
      BMI: null,
      sut_can: null,
      so_can_sut: null,
      chi_so_sut_can: null,
      an_kem_do_giam_cam_gac_them_an: null,
      chi_so_ngon_mieng: null,
      chi_so_MST: null,
      danh_gia_theo_chi_so_MST: null,
      can_thiep_dinh_duong: null,
      nguoi_danh_gia: null,
      bac_si_dieu_tri: null,
      trang_thai: true,
    },
    data: [],
    khoa_select: [],
    sut_can_select: ["Có", "Không rõ", "Không"],
    bieng_an_select: ["Có", "Không"],
    so_can_sut_select: ["1-5kg", "6-10kg", "11-15kg", "15kg trở lên"],
    nhan_vien_select: [],
  }),
  mounted() {
    //this.getDanhDSNhanVien();
    //this.getSelectKhoa();
  },
  methods: {
    async getSelectKhoa() {
      let data = await getKhoa({huy:false});
      this.khoa_select = data.data;
    },
    async getDanhDSNhanVien() {
      let data = await getNhanVien();
      this.nhan_vien_select = data.data;
    },
    addDialog() {
      this.show = false;
      this.show_dialog = true;
      this.form = {
        khoa: null,
        ngay_danh_gia: null,
        can_nang: null,
        chieu_cao: null,
        BMI: null,
        sut_can: null,
        so_can_sut: null,
        chi_so_sut_can: null,
        an_kem_do_giam_cam_gac_them_an: null,
        chi_so_ngon_mieng: null,
        chi_so_MST: null,
        danh_gia_theo_chi_so_MST: null,
        can_thiep_dinh_duong: null,
        nguoi_danh_gia: null,
        bac_si_dieu_tri: null,
        trang_thai: true,
      };
    },
    huy() {
      this.show_dialog = false;
    },
    add() {
      this.$emit("get-phieu", this.form);
      this.show_dialog = false;
    },
    editDialog(item) {
      this.show = true;
      this.form = item;
      this.show_dialog = true;
    },
  },
};
</script>
<style scoped>
.title-field {
  font-size: 16px;
  color: black;
}

.padding-cols {
  padding-bottom: 10px !important;
  padding-top: 5px !important;
}

.red-dot {
  color: red;
  font-size: 18px;
  font-weight: bold;
}
.el-select {
  width: 100%;
}
</style>
