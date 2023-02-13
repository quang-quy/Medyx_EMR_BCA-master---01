<template>
  <v-row class="align-center mt-1">
    <v-col cols="12">
      <el-pagination
        background
        layout="total, prev, pager, next, sizes"
        :total="pagination.totalRecords"
        :page-size.sync="filterParams.pageSize"
        :current-page.sync="filterParams.pageNumber"
        @size-change="$emit('per-page-changed')"
        @current-change="$emit('page-changed', $event)"
        :page-sizes="[10, 20, 50, 100, 200]"
      >
      </el-pagination
    ></v-col>
  </v-row>
</template>
<script>
import paginationMixin from "@/mixins/crud/pagination";
export default {
  mixins: [paginationMixin],
};
</script>

<style lang="css">
.el-pager {
  padding-left: unset !important;
}
</style>
