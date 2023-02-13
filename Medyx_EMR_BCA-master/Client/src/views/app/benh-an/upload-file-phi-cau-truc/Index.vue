<template>
  <div class="overflow-hidden" v-cloak>
    <AppWrapper>
      <div class="d-flex mt-1" style="width: 100% !important">
        <div class="flew-grow-1">
          <menu-tab
            :menus="data"
            @item="handleItem"
            @on:Search="onSearch"
          ></menu-tab>
        </div>
        <div class="pt-4 flex-grow-0" style="width: calc(100vw - 665px)">
          <div v-if="item.tableName == 'BenhAn'">
            <listFile :idba="id" :item="item" :permission="permission"></listFile>
          </div>
          <div v-else>
            <file-dich-vu
              :item="item"
              :idba="id"
              :permission="permission"
              :title="`Danh sách file đính kèm ${
                item.tenLoaiTaiLieu ? item.tenLoaiTaiLieu.toLowerCase() : null
              }`"
            ></file-dich-vu>
          </div>
        </div>
      </div>
    </AppWrapper>
  </div>
</template>

<script>
import { index } from "@/api/tap-tin-dinh-kem";
import listFile from "./components/file-list.vue";
import menuTab from "./menu-tab.vue";
import fileDichVu from "./components/dichvu-table.vue";
export default {
  components: { listFile, menuTab, fileDichVu },
  props: {
    id: [String, Number],
    permission: {
      type: Array,
      default: () => [],
    },
  },
  data: (vm) => ({
    item: {},
    data: [],
    dataConfig: [],
  }),
  watch: {
    params: {
      handler: function (newVal) {
        this.getList();
      },
      deep: true,
    },
  },
  created() {
    this.getList();
  },
  methods: {
    async getList() {
      var { data } = await index();
      this.dataConfig = data.map((x) => ({
        ...x,
        active: false,
        searchText: `${x.maLoaiTaiLieu}-${x.tenLoaiTaiLieu}`.toLowerCase(),
      }));
      this.data = this.dataConfig;
      this.data[0].active = true;
      this.item = data[0];
    },
    handleItem(val) {
      this.item = val;
    },
    onSearch(val) {
      if (val) {
        const text = val.toLowerCase();
        var tempt = [];
        this.dataConfig.forEach((e) => {
          e.searchText.search(text) >= 0 ? tempt.push(e) : null;
        });
        this.data = tempt;
      } else {
        this.data = this.dataConfig;
      }
    },
  },
};
</script>

<style></style>
