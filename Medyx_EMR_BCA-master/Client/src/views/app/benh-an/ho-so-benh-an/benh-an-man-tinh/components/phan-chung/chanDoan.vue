<template>
  <div>
    <div style="font-size: 16px; font-weight: bold" class="mb-4">
      III. CHẨN ĐOÁN
    </div>
    <el-form>
      <div style="border: 1px solid #d6dbdf" class="pa-4 pb-8">
        <v-row class="mt-0">
          <v-col cols="12" class="padding-cols mb-2">
            <div style="font-weight: 600" class="pb-1">CHẨN ĐOÁN THEO YHHĐ</div>
            <hr />
          </v-col>
          <v-col cols="6" class="padding-cols">
            <el-form-item label="Chẩn đoán của nơi chuyển đến">
              <base-select-async
                v-model="form.maBenhNoiChuyenDenYhhd"
                :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="maBenh"
                :apiFunc="getChanDoanBenh"
                placeholder=""
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col cols="6" class="padding-cols">
            <el-form-item label="Chẩn đoán KKB/cấp cứu">
              <base-select-async
                v-model="form.maBenhKkbyhhd"
                :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                keyValue="maBenh"
                :apiFunc="getChanDoanBenh"
                placeholder=""
                style="width: 100%"
                size="small"
              >
              </base-select-async>
            </el-form-item>
          </v-col>
          <v-col cols="6" class="padding-cols">
            <v-row>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Vào khoa điều trị - Bệnh chính">
                  <base-select-async
                    v-model="form.benhChinh.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Vào khoa điều trị - Bệnh kèm theo 1">
                  <base-select-async
                    v-model="form.benhKem1.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Vào khoa điều trị - Bệnh kèm theo 2">
                  <base-select-async
                    v-model="form.benhKem2.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Vào khoa điều trị - Bệnh kèm theo 3">
                  <base-select-async
                    v-model="form.benhKem3.maBenh"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Thủ thuật">
                  <el-radio-group
                    v-model="form.thuThuatYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Phẫu thuật">
                  <el-radio-group
                    v-model="form.phauThuatYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
            </v-row>
          </v-col>
          <v-col cols="6" class="padding-cols">
            <v-row>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Ra viện - Bệnh chính">
                  <base-select-async
                    v-model="form.maBenhChinhRv"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Ra viện - Bệnh kèm theo 1">
                  <base-select-async
                    v-model="form.maBenhKemRv1"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  >
                  </base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Ra viện - Bệnh kèm theo 2">
                  <base-select-async
                    v-model="form.maBenhKemRv2"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  ></base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="12" class="padding-cols">
                <el-form-item label="Ra viện - Bệnh kèm theo 3">
                  <base-select-async
                    v-model="form.maBenhKemRv3"
                    :label="(item) => `${item.maBenh} - ${item.tenBenh}`"
                    keyValue="maBenh"
                    :apiFunc="getChanDoanBenh"
                    placeholder=""
                    style="width: 100%"
                    size="small"
                  ></base-select-async>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Tai biến">
                  <el-radio-group
                    v-model="form.taiBienYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
              <v-col cols="6" class="padding-cols">
                <el-form-item label="Biến chứng">
                  <el-radio-group
                    v-model="form.bienChungYhhd"
                    style="width: 100%"
                  >
                    <el-radio :label="1">Có</el-radio>
                    <el-radio :label="2">Không</el-radio>
                  </el-radio-group>
                </el-form-item>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
      </div>
    </el-form>
  </div>
</template>

<script>
import * as apiBenhTat from "@/api/benh-tat.js";
import store from "@/store";

export default {
  props: ["benhAn", "benhAnKhoaDieuTri"],
  data: () => ({
    form: {
      maBenhNoiChuyenDenYhhd: null,
      maBenhKkbyhhd: null,
      maBenhChinhRv: null,
      maBenhKemRv1: null,
      maBenhKemRv2: null,
      maBenhKemRv3: null,
      phauThuatYhhd: null,
      taiBienYhhd: null,
      thuThuatYhhd: null,
      bienChungYhhd: null,
      maBenhChinhRvyhct: null,
      maBenhKemRv1yhct: null,
      maBenhKemRv2yhct: null,
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
    },
    chanDoan: [
      {
        maChanDoan: null,
        tenChanDoan: null,
      },
    ],
  }),
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
    },
    form: {
      handler(val) {
        this.$emit("get-chanDoan", val);
        store.dispatch("hosobenhan/setChanDoan", val);
      },
      deep: true,
    },
    CHANDOAN: {
      handler(val) {
        for (let key in this.form) {
          if (val && val.hasOwnProperty(key)) {
            this.form[key] = val[key];
          }
        }
      },
      deep: true,
    },
    TONGKETRAVIEN: {
      handler(val) {
        for (let key in this.form) {
          if (val && val.hasOwnProperty(key)) {
            this.form[key] = val[key];
          }
        }
      },
      deep: true,
    },
  },
  computed: {
    TONGKETRAVIEN() {
      return this.$store.state.hosobenhan.tongKetRaVien;
    },
    CHANDOAN() {
      return this.$store.state.hosobenhan.chanDoanYHHD;
    },
  },
  mounted() {},
  methods: {
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },
  },
};
</script>

<style scoped>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
</style>
