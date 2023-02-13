<template>
  <app-wrapper>
    <div class="pa-2" v-if="show">
      <div
        v-for="(item, i) in tabs"
        :key="`tt_${i}`"
        :id="item.id"
        v-intersect="scroll(item.i)"
      >
        <component
          :is="item.component"
          :idba="id"
          @reset="handlerReset"
          :title="item.name"
          :permission="permission"
        />
      </div>
      <div class="d-flex justify-center bottom-side-benh-an">
        <div
          class="title-tab d-flex mt-2 px-4"
          v-for="item in tabs"
          :key="item.index"
          @click="scrollToElement(item)"
          :style="{
            'border-bottom': item.index == tab ? '4px solid #2980b9' : '',
          }"
        >
          <div
            class="d-flex align-center"
            style="height: 100%"
            :style="{ color: item.index == tab ? '#2980B9' : '' }"
          >
            <v-badge color="red" :content="tongFile" v-if="item.bage" small>
              <div class="">{{ item.name }}</div>
            </v-badge>
            <div v-else>{{ item.name }}</div>
          </div>
        </div>
      </div>
    </div>

    <div class="text-center body-1 pa-2" v-else>None</div>
  </app-wrapper>
</template>

<script>
import { getDetailBenhAn } from "@/api/benh-an.js";

export default {
  components: {
    kiemdiemtuvong: toolLazyload("kiem-diem-tu-vong"),
    phieuchuandoannn: toolLazyload("phieu-chuan-doan-nn"),
    fileDinhKem: toolLazyload("fileDinhKem"),
  },
  props: ["id", "permission"],
  data: (vm) => ({
    tab: 1,
    show: false,
    tabs: [
      {
        id: "kiemdiemtuvong",
        index: 1,
        name: "1.Kiểm điểm tử vong",
        component: "kiemdiemtuvong",
        bage: false,
      },
      {
        id: "phieuchuandoannn",
        index: 2,
        name: "2.Phiếu chẩn đoán nguyên nhân tử vong",
        component: "phieuchuandoannn",
        bage: false,
      },
      {
        id: "fileDinhKem",
        index: 3,
        name: "3.File đính kèm",
        component: "fileDinhKem",
        bage: false,
      },
    ],
    loading : null
  }),
  created() {
    this.getThongTinChungBenhAn();
  },
  methods: {
    async getThongTinChungBenhAn() {
      this.loading = this.$loading({
        lock: true,
        text: "Đang tải",
        spinner: "el-icon-loading",
        background: "rgba(0, 0, 0, 0.7)",
      });
 
      const { data } = await getDetailBenhAn(this.id);
      data.kqdt == 5 ? (this.show = !this.show) : null;
      this.loading.close();
      this.loading = null;
    },

    handlerReset() {},
    scrollToElement(item) {
      this.tab = item.index;
      const element = document.getElementById(item.id);
      element.scrollIntoView({ behavior: "smooth" });
    },
    scroll(entries, observer, index) {
    },
  },
};
function toolLazyload(view) {
  return () => import(`./components/${view}.vue`);
}
</script>
<style scoped>
.bottom-side-benh-an {
  background: #f1f7fb;
  height: 40px;
  z-index: 20;
  position: sticky;
  bottom: 0px;
  width: 100%;
  border-top: 1px solid #d7dbdd;
}
.side-content {
  max-width: 1080px;
  border: 1px solid #e5e7e9;
  background: white;
}
.title-tab {
  cursor: pointer;
  font-weight: 500;
  color: black;
  font-size: 13px;
}
.title-tab:hover {
  background: #d6eaf8;
}
.menu-top {
  background: white;
  height: 80px;
  width: 100%;
  top: 0;
  z-index: 20;
  position: sticky;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  align-items: center;
}
</style>
