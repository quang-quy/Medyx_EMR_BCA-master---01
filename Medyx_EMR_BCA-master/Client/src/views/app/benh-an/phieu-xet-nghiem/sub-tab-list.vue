<template>
  <div class="flex-column mt-3" style="overflow: auto">
    <div class="f-flex flex-column" style="max-height: calc(100vh - 200px)">
      <div
        v-for="(item, index) in tabs"
        :key="`sub-tab_${index}`"
        :id="item.name"
      >
        <component
          :is="item.component"
          :params="item.detail"
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
    dataTable: toolLazyload("data-table"),
    fileDinhKem: toolLazyload("fileComponent"),
  },
  props: {
    permission: { type: Array },
    tabs: {
      type: Array,
      default: () => [],
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
  data: (vm) => ({
  }),
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
  return () => import(`./sub/${view}.vue`);
}
</script>

<style scoped></style>
