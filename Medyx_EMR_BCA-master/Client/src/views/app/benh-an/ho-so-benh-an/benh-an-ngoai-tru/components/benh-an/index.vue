<template>
  <div>
    <div
      class="d-flex justify-center mb-4"
      style="width: 100%; font-size: 18px; font-weight: bold"
    >
      PHẦN II. BỆNH ÁN
    </div>
    <div class="pb-4">
      <PhanA @get-phanA="getPhanA"/>
    </div>
    <div class="mt-4">
      <PhanB @get-phanB="getPhanB"/>
    </div>
    <div class="mt-4">
      <PhanC/>
    </div>
  </div>
</template>

<script>
import PhanA from "./A-y-hoc-hien-dai/index";
import PhanB from "./B-y-hoc-co-truyen/index";
import PhanC from "./C-dieu-tri/index";

export default {
  components: {
    PhanA,
    PhanB,
    PhanC,
  },
  data:()=>({
    benhAnYhct:{},
    benhAnYhhd:{},
    phan_a:{},
    phan_b:{},
    phan_c:{},
  }),
  methods:{
    getPhanA(data){
      this.phan_a=data
      this.benhAnTienSuBenh={...this.phan_a}
      this.benhAnYhhd = {...this.phan_a,...this.phan_b}
      this.$emit('get-benhAn',this.benhAnTienSuBenh, this.benhAnYhhd, this.benhAnYhct)
    },
    getPhanB(data, benhAnYhct){
      this.benhAnYhct=benhAnYhct;
      this.phan_b = data;
      this.benhAnYhhd = {...this.phan_b}
      this.benhAnYhct = {...this.phan_b}
      this.$emit('get-benhAn',this.benhAnTienSuBenh, this.benhAnYhhd, this.benhAnYhct)
    },
    // getPhanC(data){
    //   this.phan_c = data;
    //   this.benhAnYhct = {...this.phan_c, ...this.phan_b}
    //   this.benhAnYhhd = {...this.phan_c, ...this.phan_a}
    //   this.$emit('get-benhAn',this.benhAnTienSuBenh, this.benhAnYhhd, this.benhAnYhct)
    // },
  }
};
</script>

<style></style>
