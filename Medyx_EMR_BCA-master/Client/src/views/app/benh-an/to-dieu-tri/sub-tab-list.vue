<template>
  <div class="flex-column" style="overflow: auto">
    <div
      class="f-flex flex-column"
      style="max-height: calc(100vh - 300px)"
      v-if="tabs.length && tabs[0].params.ngayylenh"
    >
      <div
        v-for="(item, index) in tabs"
        :key="`sub-tab_${index}`"
        :id="item.name"
      >
        <component
          :is="item.component"
          :title="item.name"
          :params="item.params"
          :dataDetail="dataDetail"
          @reset="handlerReset"
          :permission="permission"
        />
      </div>
    </div>
  </div>
</template>
<script>
export default {
  components: {
    dienbienBenhManTinh: toolLazyload("dienbienBenhManTinh"), //
    dienbienBenh: toolLazyload("dienbienBenh"), //
    canLamSan: toolLazyload("canLamSan"), //
    chePhamMau: toolLazyload("chePhamMau"),
    phauThuThuat: toolLazyload("phauThuThuat"),
    thuocDongY: toolLazyload("thuocDongY"), //
    thuocTayYs: toolLazyload("thuocTayYs"), //
    thuThuatVatLy: toolLazyload("thuThuatVatLy"), //
    fileDinhKems: () => import("./sub-tab/fileDinhKems.vue"),
  },
  props: {
    tabs: { type: Array },
    tab: { type: Number, default: 0 },
    permission: { type: Array},
    dataDetail: {
      type: Object,
      default: () => {},
    },
    loaiBenhAn: {
      type: Number,
    },
  },
  watch: {
    tab: {
      handler: function (newVal) {
        if (newVal >= 0 && newVal != null && this.tabs) {
          const { name } = this.tabs[newVal];
          this.clickTab(name);
        }
      },
      immediate: true,
    },
  },
  data: (vm) => ({}),
  methods: {
    clickTab(name) {
      const element = document.getElementById(name);
      if (element) {
        element.scrollIntoView();
      }
    },
    handlerReset() {
      this.$emit("reset");
    },
  },
};
function toolLazyload(view) {
  return () => import(`./sub-tab/${view}.vue`);
}
</script>

<style scoped></style>
