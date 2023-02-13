<template>
  <div class="pl-2">
    <div class="mb-2">
      <div class="d-flex">
        <div class="body-1 font-weight-bold ml-1">Danh sách tệp đính kèm</div>
      </div>
      <div class="mt-2 pa-2">
        <el-input
          placeholder="Tìm kiếm ..."
          prefix-icon="el-icon-search"
          v-model="search"
          size="mini"
          class="mr-2"
        >
        </el-input>
      </div>
    </div>
    <div
      class="overflow-y-auto"
      style="width: 300px; max-height: calc(100vh - 300px)"
    >
      <div
        v-for="(item, index) in menus"
        :key="`menu_${index}`"
        class="py-2 pl-2 fill-width menu-item"
        @click="click(item, index)"
        :class="{ isActive: item.active }"
      >
        <div class="d-flex mr-1">
          <div class="d-flex flex-column flex-grow-1 ml-1 mr-1">
            <div class="d-flex ml-1">
              <div class="text-caption font-weight-bold">
                {{ `${item.maLoaiTaiLieu}-${item.tenLoaiTaiLieu}` }}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import debounce from "@/utils/debounce";
export default {
  data: (vm) => ({
    indexCur: 0,
    search: null,
  }),
  watch: {
    search: debounce(function (newVal) {
      this.$emit("on:Search", newVal);
    }, 1000),
  },
  mounted() {},
  computed: {},
  props: {
    menus: {
      type: Array,
      default: () => [],
    },
  },
  methods: {
    click(item, index) {
      this.$emit("item", item);
      this.menus.map((x, i) => {
        i == index ? (x.active = true) : (x.active = false);
      });
    },
  },
};
</script>

<style scoped>
.menu-item {
  cursor: pointer;
  border-bottom: 1px solid beige;
  border-radius: 5px;
}
.menu-item:hover {
  background-color: rgb(161, 191, 216);
}
.isActive {
  background-color: rgb(54, 100, 139) !important;
  color: rgb(233, 233, 241) !important;
}
</style>
