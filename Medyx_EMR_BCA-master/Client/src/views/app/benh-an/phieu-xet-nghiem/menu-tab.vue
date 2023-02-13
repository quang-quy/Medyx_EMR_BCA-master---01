<template>
  <div class="pl-2">
    <div class="mb-2">
      <div class="d-flex">
        <v-icon dark color="black">mdi-table</v-icon>
        <div class="body-1 font-weight-bold ml-2">
          Chỉ định xét nghiệm</div>
        <el-checkbox
          class="ml-auto"
          v-model="checkAll"
          label="Tất cả"
        ></el-checkbox>
      </div>
      <div class="mt-2 pa-0">
        <v-toolbar dense outlined class="mt-1 boxLag">
          <el-input
            placeholder="Tìm kiếm ..."
            prefix-icon="el-icon-search"
            v-model="searchValue"
            size="mini"
            class="mr-2"
          >
          </el-input>
          <v-spacer></v-spacer>
          <v-btn icon small @click="handleExports()"
          :disabled="
            !permission.find(
              (e) => e.ActionDetailsName == '/HSBA/PhieuXetNghiem/export'
            )
          "
          
          >
            <v-icon title="Xuất dữ liệu">mdi-printer</v-icon>
          </v-btn>
        </v-toolbar>
      </div>
    </div>
    <div
      class="overflow-auto"
      style="width: 300px; max-height: calc(100vh - 300px)"
    >
      <div
        v-for="(item, index) in menus"
        :key="`menu_${index}`"
        class="py-2 pl-2 fill-width menu-item"
        :style="
          item.active
            ? 'background-color: #ebebeb'
            : 'background-color: #ffffff'
        "
      >
        <div class="d-flex mr-1">
          <div class="flex-grow-0">
            <el-checkbox
              class="pa-0"
              v-model="item.check"
              hide-details
              :disabled="item.huy"
            ></el-checkbox>
          </div>
          <div class="d-flex flex-column flex-grow-1 ml-1 mr-1">
            <div class="d-flex ml-1">
              <div
                class="text-caption font-weight-bold"
                :style="item.active ? ' color:#6495ED' : 'color:black'"
                @click="handleChoseTab(index, item)"
                v-if="!item.huy"
              >
                {{ item.stt || null }}. {{ item.dichVu.maDv || null }}
              </div>
              <div
                class="text-caption font-weight-bold text-decoration-line-through"
                :style="item.active ? ' color:red' : 'color:red'"
                @click="handleChoseTab(index, item)"
                v-else
              >
                {{ item.stt || null }}. {{ item.dichVu.maDv || null }}
              </div>

              <div class="ml-auto">
                <div class="d-flex">
                  <el-button
                    class="ml-1"
                    @click="onPrint(item)"
                    style="padding: 1px"
                    title="In"
                    v-if="!item.huy"
                    :disabled="
                      !permission.find(
                        (e) => e.ActionDetailsName == '/HSBA/PhieuXetNghiem/export'
                      )
                    "
                  >
                    <i class="el-icon-printer" style="font-size: initial"></i
                  ></el-button>
                </div>
              </div>
            </div>
            <div class="mb-2" @click="handleChoseTab(index, item)">
              <div class="d-flex">
                <div class="text-caption black--text ml-1">
                  Ngày Y lệnh :
                  <span class="font-weight-bold">
                    {{ formatDatetime(item.ngayYlenh) }}
                  </span>
                </div>
              </div>
              <div class="d-flex">
                <div class="text-caption black--text ml-1">
                  <div class="font-weight-bold">
                    {{ item.dichVu.tenDv || null }}
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { formatDatetime } from "@/utils/formatters";
import { destroy, exportTDT } from "@/api/to-dieu-tri";
import * as apiPhieuXetNghiem from "@/api/phieu-xet-nghiem";
import debounce from "@/utils/debounce";
export default {
  data: (vm) => ({
    tab: 0,
    searchValue: null,
    formatDatetime,
    search: false,
    checkAll: false,
    menuShow: [],
  }),
  watch: {
    searchValue: debounce(function (newVal) {
      this.$emit("on:Search", newVal);
    }, 1000),
    checkAll(val) {
      this.menus.map((e) => {
        if (!e.huy) e.check = val;
      });
    },
  },
  computed: {
    menuProcessed() {
      if (!searchValue) {
        return this.menus;
      } else {
      }
    },
  },
  props: {
    menus: {
      type: Array,
      default: () => [],
    },
    idba: {
      type: String,
    },
    permission: { type: Array },
  },
  methods: {
    onAdd() {
      this.add = !this.add;
      this.$refs.form.open();
    },
    handleChoseTab(index, item) {
      this.$emit("on:choseTab", item);
      this.menus.forEach((element, i) => {
        element.active = index == i ? true : false;
      });
    },
    async handleExports() {
      let arr = this.menus.filter((e) => e.check);
      try {
        if (!arr.length) {
          this.$message.info("Chưa chọn dịch vụ ngày nào !");
          return;
        }
        var listStt = arr.map((x) => x.stt);
        const res = await this.$confirm(
          "Xác nhận tải xuống danh sách dịch vụ ngày có số thứ tự là : " +
            listStt.join(),
          {
            title: "Xác nhận tải xuống",
            buttonTrueText: "Đồng ý",
            buttonFalseText: "Hủy",
          }
        );
        if (res) {
          var params = "";
          for (let index = 0; index < listStt.length; index++) {
            if (index != listStt.length - 1) {
              params += `Stt[]=${listStt[index]}&`;
            } else {
              params += `Stt[]=${listStt[index]}`;
            }
          }
          if (this.resetCheck()) {
            await apiPhieuXetNghiem.print(this.idba, params);
          }
          return;
        }
      } catch (error) {
        console.log(error);
      }
    },
    async onPrint(item) {
      try {
        if (!item.stt || !item.idba) {
          return;
        }
        const res = await this.$confirm(
          "Xác nhận In tờ điều trị có số thứ tự là : " + item.stt,
          {
            title: "Xác nhận In",
            buttonTrueText: "Đồng ý",
            buttonFalseText: "Hủy",
          }
        );
        if (res) {
          if (this.resetCheck()) {
            await apiPhieuXetNghiem.print(item.idba, `Stt[]=${item.stt}`);
          }
          return;
        }
      } catch (error) {
        console.log(error);
      }
    },
    resetCheck() {
      this.menus.map((e) => {
        e.check = false;
      });
      return true;
    },
    eventDone() {
      this.$emit("reset");
    },
    onUpdate(item) {
      this.$refs.formUpDate.open(item);
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
  background-color: aliceblue;
}
.isActive {
  background-color: aquamarine;
}
.v-checkbox {
  margin: 0px !important;
}
.v-toolbar {
  box-shadow: none !important;
  padding: 0px 0px !important;
}
.boxLag {
  position: relative;
}
.poti {
  position: absolute;
  top: 13px;
  left: 3px;
}
</style>
