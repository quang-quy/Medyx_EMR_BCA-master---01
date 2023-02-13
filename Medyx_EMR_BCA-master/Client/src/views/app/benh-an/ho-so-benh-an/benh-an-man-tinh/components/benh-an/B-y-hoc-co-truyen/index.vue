<template>
  <div class="pt-2">
    <div style="font-size: 16px; font-weight: bold" class="mb-3 mt-4">
      B. Y HỌC CỔ TRUYỀN
    </div>
    <el-form>
      <v-row>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Mô tả vọng chẩn">
            <el-input v-model="form.moTaVongChan" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Mô tả văn chẩn">
            <el-input v-model="form.moTaVanChan" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Mô tả xúc chẩn">
            <el-input v-model="form.moTaXucChan" size="small"></el-input>
            <div>Mạch tay trái</div>
            <div>
              <el-input v-model="form.machTrai" size="small"></el-input>
            </div>
            <div>Mạch tay phải</div>
            <div>
              <el-input v-model="form.machPhai" size="small"></el-input>
            </div>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Tóm tắt tứ chẩn">
            <el-input v-model="form.tomTatTuChan" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Biện chứng luận trị">
            <el-input v-model="form.bienChungLuanTri" size="small"></el-input>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Chẩn đoán">
            <base-select-async v-model="form.maBenhDanhTheoYhct" :label="(item) => `${item.maBenh} - ${item.tenBenh} - ${item.maBenhIcd}`"
                keyValue="maBenh" :apiFunc="getChanDoanBenhCT" placeholder="" style="width: 100%" size="small">
              </base-select-async>
          </el-form-item>
        </v-col>
        <v-col cols="12" class="padding-cols">
          <el-form-item label="Bát cương">
            <el-input v-model="form.batCuong" size="small"></el-input>
            <div>Mô tả nguyên nhân</div>
            <div>
              <el-input v-model="form.moTaNguyenNhan" size="small"></el-input>
            </div>
            <div>Mô tả tạng phủ</div>
            <div>
              <el-input v-model="form.moTaTangPhu" size="small"></el-input>
            </div>
            <div>Mô tả kinh mạch</div>
            <div>
              <el-input v-model="form.moTaKinhMach" size="small"></el-input>
            </div>
          </el-form-item>
        </v-col>
      </v-row>
    </el-form>
  </div>
</template>

<script>
import * as apiBenhTat from "@/api/benh-tat.js";
import * as apiBenhTatCT from "@/api/benh-tat-yhct.js";
import { chiTietToBenhAn, getTienSuBenh, getKhamYhhd, getTongKetBenhAn, getKhoaDieuTri, getKhamYhct } from "@/api/benh-an.js";
export default {
  data: () => ({
    form:{
      moTaVongChan:null,
      moTaVanChan:null,
      moTaXucChan:null,
      machTrai:null,
      machPhai:null,
      bienChungLuanTri:null,
      maBenhDanhTheoYhct:null,
      batCuong:null,
      moTaNguyenNhan:null,
      moTaTangPhu:null,
      moTaKinhMach:null,
      tomTatTuChan:null,
    },
    chanDoan: [
      {
        maChanDoan: null,
        tenChanDoan: null,
      },
    ],
  }),
  mounted() {
    this.getData();
  },
  watch: {
    form: {
      handler(val) {
        this.$emit('get-phanB', val, this.benhAnYhct)
      },
      deep: true
    },
  },
  methods: {
    async getData() {
      const id = window.location.href.split("/").at(-1);
      let data = await getKhamYhct(id);
      for (let key in this.form) {
        if (data && data.data && data.data.hasOwnProperty(key)) {
          this.form[key] = data.data[key];
        }
      }
    },
    async getChanDoanBenh(params) {
      return await apiBenhTat.index(params);
    },
    async getChanDoanBenhCT(params) {
      return await apiBenhTatCT.index(params);
    },
  },
};
</script>

<style>
.padding-cols {
  padding-bottom: 0px !important;
  padding-top: 0px !important;
}
.title-group-checkbox {
  font-weight: 500;
  line-height: 20px;
}
.width-checkbox {
  width: 200px;
}
.sub-label-ba {
  font-weight: 500;
  font-style: italic;
  border-bottom: 1px solid #bdc3c7;
  width: 80px;
  line-height: auto;
}
</style>
