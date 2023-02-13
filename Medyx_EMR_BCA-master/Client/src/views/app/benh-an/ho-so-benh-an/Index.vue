<template>
  <div>
    <BenhAnNoiTru v-if="loaiBenhAn == 1" :disableActions="disableActions" />
    <BenhAnNgoaiTru v-if="loaiBenhAn == 2" :disableActions="disableActions" />
    <BenhAnManTinh v-if="loaiBenhAn == 3" :disableActions="disableActions" />
    <BenhAnNoiTru v-if="loaiBenhAn == 4" :disableActions="disableActions" />
  </div>
</template>

<script>
import BenhAnNoiTru from "./benh-an-noi-tru/Index.vue";
import BenhAnNgoaiTru from "./benh-an-ngoai-tru/Index.vue";
import BenhAnManTinh from "./benh-an-man-tinh/Index.vue";
import { getLoai } from "@/api/benh-an.js";
export default {
  props: {
    id: {
      type: [Number, String],
      required: true,
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },
  components: {
    BenhAnNoiTru,
    BenhAnNgoaiTru,
    BenhAnManTinh,
},
  data: (vm) => ({
    // loaiBenhAn: 3,
    loaiBenhAn: null,
    disableActions: {
      modify: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/tobenhan/modify"
        ),
      export: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/tobenhan/export"
        ),
    },
  }),
  mounted() {
    this.getLoaiBenhAn();
  },
  methods: {
    async getLoaiBenhAn() {
      let data = await getLoai(this.id);
      this.loaiBenhAn = data.data.ma
    },
  },
};
</script>

<style></style>
