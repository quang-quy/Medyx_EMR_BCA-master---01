<template>
  <el-dialog
    title="Danh sách file đính kèm"
    :visible.sync="dialog"
    width="40%"
    height="30%"
  >
    <fileList :data="currentRowData"  />
    <span slot="footer" class="dialog-footer">
      <el-button type="primary" @click="dialog = false">Xong</el-button>
    </span>
  </el-dialog>
</template>
<script>
import fileList from "./fileComponent.vue";
export default {
  components: {
    fileList,
  },
  data: (vm) => ({}),
  props: {
    currentRowData: Object,
    showFile: Boolean,
  },
  computed: {
    dialog: {
      set(value) {
        this.$emit("update:showFile", value);
      },
      get() {
        return this.showFile;
      },
    },
  },
  methods: {},
};
</script>
