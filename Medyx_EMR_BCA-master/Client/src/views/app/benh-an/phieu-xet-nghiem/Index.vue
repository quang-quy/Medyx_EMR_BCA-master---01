<template>
  <div class="overflow-hidden" style="min-height: 650px" v-cloak>
    <AppWrapper>
      <div class="d-flex mt-2">
        <div class="flex-grow-0">
          <tab-menu
            ref="menuTab"
            :menus="data"
            v-show="showTab"
            @on:choseTab="choseTab"
            @on:Search="handleSearch"
            @reset="getListPhieuXN"
            :idba="id"
            :permission="permission"
          ></tab-menu>
        </div>
        <div
          style="overflow: auto"
          class="flex-grow-1"
          v-if="Object.keys(dataDetail).length"
        >
          <sub-tab
            v-if="data"
            :tabs="tabs" 
            :dataDetail="dataDetail"
            @reset="handleReset()"
            :permission="permission"
          >
          </sub-tab>
        </div>
      </div>
    </AppWrapper>
  </div>
</template>

<script>
import * as apiPhieuXetNghiem from "@/api/phieu-xet-nghiem";
import Crud from "@/components/crud/Index.vue";
import AppWrapper from "@/components/AppWrapper.vue";
import tabMenu from "./menu-tab.vue";
import { formatDate, formatDatetime } from "@/utils/formatters";
import subTab from "./sub-tab-list.vue";
export default {
  components: {
    AppWrapper,
    tabMenu,
    Crud,
    subTab,
  },
  props: {
    id: {
      type: [String, Number],
    },
    permission: {
      type: Array,
      default: () => [],
    },
  },

  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    formatDatetime,
    data: [],
    dataConfig: [],
    dataDetail: {},
    tab: null,
    showTab: true,
    search: null,
    loading: null,
    tabs: [
      {
        component: "dataTable",
      },
      {
        component: "fileDinhKem",
      },
    ],
  }),
  async created() {
    await this.getListPhieuXN();
  },
  methods: {
    async getListPhieuXN() {
      if (!this.id) return;
      this.loading = this.$loading({
        lock: true,
        text: "Đang tải",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      const params = this.currentUser.is_admin
        ? { sortBy: "stt" }
        : { sortBy: "stt", huy: false };
      const { data } = await apiPhieuXetNghiem.index(this.id, params);

      this.dataConfig = data;
      if (this.dataConfig.length) {
        this.dataConfig = this.dataConfig.map((x) => ({
          ...x,
          fulltextSearch: `${x.stt}.${x.dichVu.maDv} ${formatDatetime(
            x.ngayYlenh
          )}-${x.dichVu.tenDv}`,
          check: false,
          active: false,
        }));
        this.tabs = this.tabs.map((x) => ({
          ...x,
          detail: {
            idba: Number(this.id),
            stt: this.dataConfig[0].stt,
          },
        }));
        this.data = this.dataConfig;
        this.data[0].active = true;
        this.dataDetail = { ...this.data[0] };
      } else {
        this.data = [];
        this.$message({
          message: "Không có dữ liệu",
          type: "info",
        });
      }
      this.loading.close();
      this.loading = null;
    },
    clickTab(index, item) {
      this.tab = index;
    },
    handleReset() {
      let tempt = this.tab;
      this.getListToDieuTri();
      this.tab = tempt;
    },

    addCheckList(items) {},
    async handleExport() {
      this.$refs.menuTab.export();
    },
    dowloadSuccess() {},

    async choseTab(item) {
      this.dataDetail = Object.assign(this.dataDetail, item);
      this.tabs.map((x) => {
        x.detail.stt = item.stt;
      });
      this.dataConfig.forEach((element, i) => {
        element.active = element.stt == item.stt ? true : false;
      });
    },
    handleSearch(val) {
      if (val) {
        const text = val.toLowerCase().trim();
        this.data = [];
        this.dataConfig.forEach((e) => {
          if (e.fulltextSearch.search(text) >= 0) {
            this.data.push(e);
          }
        });
        if (!this.data.length) {
          this.$message({
            message: "Không có kết quả nào trùng khớp",
            type: "infor",
          });
          return this.getListPhieuXN();
        }
        const itemCurrent = this.data.find((e) => e.stt == this.dataDetail.stt);
        this.dataDetail = itemCurrent
          ? Object.assign({}, itemCurrent)
          : Object.assign({}, this.data[0]);
      } else {
        this.data = this.dataConfig;
      }
    },
  },
};
</script>
<style scoped>
.v-tab {
  text-transform: none !important;
  padding: 3px 10px !important;
  color: rgb(15, 15, 76);
  font-size: 13px !important;
  border-radius: 2px;
}
.v-tab:not(:last-of-type) {
  border-right: 1px solid #ebebeb;
}

.v-tab:hover {
  background-color: #ebebeb;
}
.v-tabs {
  /* border-bottom: 1px solid #ebebeb; */
  margin: 0px 5px !important;
  background-color: #ebebeb;
}
</style>
