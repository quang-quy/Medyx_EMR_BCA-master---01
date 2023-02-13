<template>
  <el-dialog
    :title="editing ? 'Chỉnh sửa' : 'Thêm mới'"
    :visible.sync="dialog"
    width="30%"
  >
    <span>{{ currentRowData }}</span>
    <span slot="footer" class="dialog-footer">
      <el-button @click="dialog = false">Cancel</el-button>
      <el-button type="primary" @click="dialog = false">Confirm</el-button>
    </span>
  </el-dialog>
</template>
<script>
import dialogMixin from "@/mixins/crud/dialog";
export default {
  mixins: [dialogMixin],
};
</script>
