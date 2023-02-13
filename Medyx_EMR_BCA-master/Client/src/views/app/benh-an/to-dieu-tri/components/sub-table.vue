<template>
  <div>
    <div class="d-flex my-2 mt-2">
      <div>
        <span class="body-2 font-weight-bold mr-3"> {{ title }} </span>
      </div>
    </div>
    <el-table
      ref="subTableTDY"
      :data="tableData"
      :header-cell-style="{
        padding: '0px',
      }"
      :cell-style="{
        padding: '2px 0px',
      }"
      :row-style="{
        padding: '0px',
      }"
      border
      size="mini"
      style="flex-grow: 1"
      height="260"
      width="550px"
      lazy
    >
      <el-table-column
        prop="thuoc.maThuoc"
        label="Mã thuốc"
        width="200"
        align="center"
      >
        <template #default="scope">
          <base-select-async
            v-if="scope.$index == 0"
            v-model="scope.row.thuoc.maThuoc"
            :label="
              (item) =>
                `${item.maThuoc} - ${item.tenTm} ${
                  item.donViTinh.tenDvt ? '-' + item.donViTinh.tenDvt : ''
                }`
            "
            keyValue="maThuoc"
            :apiFunc="ds_thuocDongYs"
            placeholder="Chọn thuốc"
            @change="$emit('selectThuoc', $event)"
          >
          </base-select-async>
          <base-select-async
            v-if="scope.$index != 0"
            v-model="scope.row.thuoc.maThuoc"
            :label="
              (item) =>
                `${item.maThuoc} - ${item.tenTm} ${
                  item.donViTinh.tenDvt ? '-' + item.donViTinh.tenDvt : ''
                }`
            "
            keyValue="maThuoc"
            :apiFunc="ds_thuocDongYs"
            placeholder="Chọn thuốc"
          >
          </base-select-async>
        </template>
      </el-table-column>

      <el-table-column
        prop="thuoc.tenTm"
        label="Tên thuốc"
        width="150"
        align="center"
      />

      <el-table-column
        prop="soluong"
        label="Số lượng"
        align="center"
        width="200"
      >
        <template #default="scope">
          <el-input-number
            :min="0"
            size="small"
            v-model="scope.row.soluong"
          ></el-input-number>
        </template>
      </el-table-column>
      <el-table-column
        prop="donViTinh.maDvt"
        label="Đơn vị tính"
        align="center"
      />

      <el-table-column fixed left label="Hành động" width="100" align="center">
        <template #default="scope">
          <v-btn
            @click="$emit('handleDelete', scope.$index)"
            color="error"
            icon
            x-small
            v-if="scope.$index != 0"
          >
            <v-icon dark>mdi-delete</v-icon>
          </v-btn>
          <v-btn
            @click="$emit('handleCreate', scope.row)"
            color="green"
            icon
            x-small
            v-if="scope.$index == 0"
          >
            <v-icon dark>mdi-check</v-icon>
          </v-btn>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>
<script>
import { ds_thuocDongY } from "@/api/benhAnToDieuTri/thuoc-dong-y";
export default {
  props: {
    value: {
      type: Array,
      default: () => [],
    },
    title: {
      type: String,
      default: "Danh sách",
    },
  },
  computed: {
    tableData: {
      get() {
        return this.value;
      },
      set(value) {
        this.$emit("input", value);
      },
    },
  },
  watch: {
    value: function (newVal, oldVal) {
      this.$refs.subTableTDY.doLayout();
    },
  },
  data: (vm) => ({}),
  methods: {
    async ds_thuocDongYs(params) {
      return await ds_thuocDongY(params);
    },
  },
};
</script>

<style scoped>
.poiter {
  cursor: pointer;
}
</style>
