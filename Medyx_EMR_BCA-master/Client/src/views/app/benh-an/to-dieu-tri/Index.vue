<template>
  <div class="overflow-hidden" style="height: 600px" v-cloak>
    <AppWrapper>
      <div class="d-flex mt-2">
        <div class="flex-grow-0">
          <menu-tab
            ref="menuTab"
            :menus="data"
            v-show="showTab"
            @on:choseTab="choseTab"
            @on:Search="handleSearch"
            @reset="getListToDieuTri"
            :idba="id"
            :permission="permission"
          ></menu-tab>
        </div>
        <div style="overflow: auto" class="flex-grow-1">
          <div class="mb-3 pl-3 d-flex">
            <div class="d-flex">
              <v-icon
                left
                color="primary"
                @click="showTab = !showTab"
                v-if="showTab"
                >mdi-chevron-double-left</v-icon
              >
              <v-icon left color="primary" @click="showTab = !showTab" v-else
                >mdi-chevron-double-right</v-icon
              >
              <div class="body-1 font-weight-bold ml-2">
                Danh sách phiếu tờ điều trị
              </div>
            </div>
          </div>
          <div class="mx-2 mb-5" v-if="data">
            <v-tabs
              v-model="tab"
              class="flex-grow-0 mb-2"
              height="25"
              slider-size="0"
            >
              <v-tab
                v-for="(item, index) in tabs"
                :key="`tabtitle-${index}`"
                @click="clickTab(index, item)"
                :style="
                  tab == index
                    ? 'background-color:cornflowerblue; color:white'
                    : 'background-color:white; color:black'
                "
              >
                {{ item.name }}
              </v-tab>
            </v-tabs>
          </div>
          <hr class="mb-3 mx-4" />
          <sub-tab-list
            v-if="data"
            :tabs="tabs"
            :tab="tab"
            :dataDetail="dataDetail"
            :loaiBenhAn="loaiBenhAn"
            @reset="handleReset()"
            :permission="permission"
          ></sub-tab-list>
        </div>
      </div>
    </AppWrapper>
  </div>
</template>

<script>
import { index, update, destroy, show } from "@/api/to-dieu-tri";
import subTabList from "./sub-tab-list.vue";
import AppWrapper from "@/components/AppWrapper.vue";
import menuTab from "./menu-tab.vue";
import { getLoai } from "@/api/benh-an";
import { formatDatetime } from "@/utils/formatters";
export default {
  components: {
    AppWrapper,
    subTabList,
    menuTab,
  },
  props: ["id", "permission"],
  data: (vm) => ({
    currentUser: JSON.parse(localStorage.getItem("currentUser")),
    formatDatetime,
    data: [],
    dataConfig: [],
    dataDetail: {
      bsdieuTri: {},
      khoaDieuTri: {},
      nguoiHuy: {},
      nguoiLap: {},
      nguoiSd: {},
    },
    tab: null,
    tabNoiNgoaiTrus: [
      {
        name: " 1. Diễn biến bệnh",
        component: "dienbienBenh",
        params: {},
      },
      {
        name: "2. Thuốc tây y",
        component: "thuocTayYs",
        params: {},
      },
      {
        name: "3. Thuốc đông y",
        component: "thuocDongY",
        params: {},
      },
      {
        name: "4. Thủ thuật, vật lý trị liệu",
        component: "thuThuatVatLy",
        params: {},
      },
      {
        name: "5. Cận lâm sàng",
        component: "canLamSan",
        params: {},
      },
      {
        name: "6. Phẫu thủ thuật",
        component: "phauThuThuat",
        params: {},
      },
      {
        name: " 7. Chế phẩm máu",
        component: "chePhamMau",
        params: {},
      },
      {
        name: "8. File đính kèm",
        component: "fileDinhKems",
        params: {},
      },
    ],
    tabManTinhs: [
      {
        name: " 1. Diễn biến bệnh",
        component: "dienbienBenhManTinh",
        params: {},
      },
      {
        name: "2. Thuốc tây y",
        component: "thuocTayYs",
        params: {},
      },
      {
        name: "3. Thuốc đông y",
        component: "thuocDongY",
        params: {},
      },
      {
        name: "4. Thủ thuật, vật lý trị liệu",
        component: "thuThuatVatLy",
        params: {},
      },
      {
        name: "5. Cận lâm sàng",
        component: "canLamSan",
        params: {},
      },
      {
        name: "6. File đính kèm",
        component: "fileDinhKems",
        params: {},
      },
    ],
    showTab: true,
    loaiBenhAn: null,
    tabs: [],
    search: null,
    loading: null,
  }),
  async created() {
    await this.getLoaiToDieuTri();
    this.getListToDieuTri();
  },
  methods: {
    async getLoaiToDieuTri() {
      const { data } = await getLoai(this.id);
      this.loaiBenhAn = data.ma;
    },
    async getListToDieuTri() {
      if (!this.id) return;
      this.loading = this.$loading({
        lock: true,
        text: "Đang tải",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
      const params = this.currentUser.is_admin
        ? { sortBy: "-stt" }
        : { sortBy: "-stt", huy: false };
      const { data } = await index(this.id, params);
      this.dataConfig = data;
      if (this.dataConfig.length) {
        this.dataConfig = this.dataConfig.map((x) => ({
          ...x,
          fulltextSearch: `${x.stt}.${x.khoaDieuTri.tenKhoa} ${formatDatetime(
            x.ngayYLenh
          )}`,
          check: false,
          active: false,
        }));
        this.tabs =
          this.loaiBenhAn != 3 ? this.tabNoiNgoaiTrus : this.tabManTinhs;
        this.tabs = this.tabs.map((x) => ({
          ...x,
          params: {
            idba: Number(this.id),
            ngayylenh: this.dataConfig[0].ngayYLenh,
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
        x.params.ngayylenh = item.ngayYLenh;
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
          return this.getListToDieuTri();
        }
        const itemCurret = this.data.find((e) => e.stt == this.dataDetail.stt);
        this.dataDetail = itemCurret
          ? Object.assign({}, itemCurret)
          : Object.assign({}, this.data[0]);
      } else {
        this.data = this.dataConfig;
      }
    },
    exit() {
      location.href = `${window.origin}/HSBADS/Index`;
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
