<template>
  <el-dialog
    title="Thêm mới bệnh án"
    :visible.sync="dialogVisible"
    width="80%"
    top="50px"
  >
    <ThongTinBenhAn :edit="false" @on-done="onCreate" />
  </el-dialog>
</template>

<script>
import ThongTinBenhAn from "../thong-tin-benh-an/Index.vue";

export default {
  props: {
    showDialog: Boolean,
  },

  components: { ThongTinBenhAn },
  computed: {
    dialogVisible: {
      set(val) {
        this.$emit("update:showDialog", val);
      },
      get() {
        return this.showDialog;
      },
    },
  },
  methods: {
    onCreate() {
      this.dialogVisible = false;
    },
  },
};
</script>
