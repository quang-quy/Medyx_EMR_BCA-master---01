<template>
  <el-select
    class="el-box-select-input"
    popper-class="el-box-select-sync"
    v-model="form"
    :placeholder="placeholder"
    filterable
    default-first-option
    v-el-select-loadmore="loadmore"
    v-el-select-forcus
    v-el-select-keyup="keyUphandler"
    v-el-select-enter="keyEnterhandler"
    :size="size"
    v-bind="$attrs"
    @focus="handlerFocus"
    @change="getItem"
    clearable
  >
    <div id="fill">
      <el-option
        class="option-search mb-3"
        id="options-search"
        value="search"
        disabled
      >
        <div style="width: 100%; text-align: center">
          <el-input
            v-model="search"
            placeholder="Tìm kiếm"
            :size="size"
            ref="el-search-select"
            suffix-icon="el-icon-search"
            style="width: 100%; z-index: 99999"
          ></el-input>
        </div>
      </el-option>
      <el-option
        v-for="(item, index) in dataItems"
        :ref="`el-option-sync-${index}`"
        :key="`el-option-sync-${index}`"
        :label="getLable(item)"
        :value="item[keyValue]"
        :class="[trackKeyup == index ? 'hover' : null]"
      />

      <el-option v-if="loading" value="loading" disabled>
        <div style="width: 100%; text-align: center">
          <i class="el-icon-loading"></i>
        </div>
      </el-option>
    </div>
  </el-select>
</template>

<script>
import debounce from "@/utils/debounce";
export default {
  name: "ElBoxSelectDropDown",
  props: {
    value: { type: [Number, String, Array], default: "" },
    params: { type: Object, default: () => ({}) },
    apiFunc: { type: Function, required: true },
    defaultPageSize: { type: Number, default: 10 },
    label: { type: [String, Function], default: "label" },
    keyValue: { type: String, default: "value" },
    size: { type: String, default: "small" },
    defaultParams: { type: Object, default: () => ({}) },
    placeholder: { type: String, default: "Chọn" },
  },
  data: () => ({
    persistent: false,
    allData: [], //Store all data in the drop-down box
    dataItems: [], //Data displayed in the drop-down box
    pageData: {
      //Lazy loading related parameters, which means loading from the first data and loading 20 items at a time
      pageNumber: 1,
      pageSize: 20,
      hasNextPage: true,
    },
    SearchUnion: "",
    search: "",
    loading: false,
    firstIn: true,
    trackKeyup: 0,
  }),
  computed: {
    form: {
      get() {
        return this.value;
      },
      set(val) {
        this.$emit("input", val);
        this.$emit("change", val);
      },
    },
  },
  watch: {
    form: {
      immediate: true,
      handler(val) {
        if (this.firstIn && val) {
          this.SearchUnion = val;
          this.getItems();
          this.firstIn = false;
        }
      },
    },
    defaultParams: {
      deep: true,
      immediate: true,
      handler(val) {
        this.getItems();
      },
    },
    search: debounce(function (val) {
      this.pageData = this.$options.data.call(this).pageData;
      if (val) {
        //val exists
        this.search = val;
        this.getItems({ search: this.search });
      } else {
        //When val is empty, restore the array
        this.getItems({});
      }
    }, 600),
  },
  created() {
    // this.getItems();
  },
  mounted() {
    document.getElementById("fill").scrollTo({
      top: 0,
      behavior: "smooth",
    });
    // documents.getElementById("options-search").scrollTo({
    //   top: 0,
    //   behavior: "smooth",
    // });
  },
  directives: {
    /** Drop down box lazy loading */
    "el-select-loadmore": {
      bind(el, binding) {
        const SELECTWRAP_DOM = el.querySelector(
          ".el-select-dropdown .el-select-dropdown__wrap"
        );
        SELECTWRAP_DOM.addEventListener("scroll", function () {
          const condition =
            this.scrollHeight - this.scrollTop - 19 <= this.clientHeight;
          if (condition) {
            binding.value();
          }
        });
      },
    },
    "el-select-keyup": {
      bind(el, binding) {
        const SELECTWRAP_DOM = el.querySelector(
          ".el-select-dropdown .el-select-dropdown__wrap"
        );
        SELECTWRAP_DOM.addEventListener("keyup", (event) => {
          binding.value(event);
        });
      },
    },
    "el-select-enter": {
      bind(el, binding) {
        const SELECTWRAP_DOM = el.querySelector(
          ".el-select-dropdown .el-select-dropdown__wrap"
        );
        SELECTWRAP_DOM.addEventListener("keypress", (event) => {
          binding.value(event);
        });
      },
    },
    "el-select-forcus": {
      bind(el, binding) {
        const SELECT_DOM = el.querySelector(".el-box-select-input input");
        const SELECTWRAP_DOM = el.querySelector(
          ".el-select-dropdown .el-select-dropdown__wrap"
        );
        SELECT_DOM.addEventListener("focus", function () {
          SELECTWRAP_DOM.scrollTo(0, 0);
        });
      },
    },
  },
  methods: {
    handlerFocus(e) {
      this.$nextTick(() => {
        this.$refs["el-search-select"].focus();
      }, 300);
    },
    keyUphandler(event) {
      this.$refs["el-search-select"].blur();
      // if (event.code == "ArrowDown") {
      //   this.trackKeyup =
      //     this.trackKeyup >= this.dataItems.length
      //       ? this.dataItems.length - 1
      //       : ++this.trackKeyup;
      // } else if (event.code == "ArrowUp") {
      //   this.trackKeyup = this.trackKeyup <= 0 ? 0 : --this.trackKeyup;
      // }
    },
    keyEnterhandler(event) {
      if (event.code == "Enter") {
        this.$refs[`el-option-sync-${this.trackKeyup}`][0].$el.click();
      }
    },
    /** Drop down box lazy loading */
    loadmore() {
      if (!this.pageData.hasNextPage) {
        return;
      }
      this.pageData.pageNumber++;
      this.getItems({ search: this.search }, true); //Similar to paging query
    },
    /** Load 20 securities codes at a time */
    async getItems(params = {}, isLoadMore = false) {
      let fetch_params = {
        ...this.params,
        ...this.defaultParams,
        ...this.pageData,
        ...params,
        SearchUnion: params.search ? "" : this.SearchUnion,
      };
      try {
        this.loading = true;
        const res = await this.apiFunc(fetch_params);
        if (res && res.data) {
          if (isLoadMore) {
            this.dataItems = [...this.dataItems, ...res.data];
          } else {
            this.dataItems = res.data;
          }
          if (res.meta) {
            this.pageData.pageNumber = res.meta.pageNumber;
            this.pageData.pageSize = res.meta.pageSize;
            this.pageData.hasNextPage = res.meta.hasNextPage;
          }
        }
      } finally {
        this.loading = false;
      }
    },
    getLable(item) {
      if (typeof this.label == "string") {
        return item[this.label];
      }
      if (typeof this.label == "function") {
        return this.label(item);
      }
    },
    getItem(e) {
      let item = null;
      if (Array.isArray(e)) {
        item = e;
      } else {
        item = this.dataItems.find((el) => el[this.keyValue] == e);
      }
      this.$emit("get-item", item);
    },
  },
};
</script>

<style scoped>
.option-search {
  position: sticky;
  top: 6px;
  height: 60px;
  line-height: 55px;
  z-index: 100;
  background-color: rgb(255, 255, 255);
  padding-top: 10px;
  padding-left: 20px;
}
</style>
<style>
.el-box-select-sync .el-scrollbar__bar.is-horizontal {
  display: none;
}
.el-box-select-sync .el-scrollbar__bar.is-vertical {
  display: none;
}
.el-box-select-sync .el-select-dropdown__wrap {
  overflow-x: hidden !important;
  margin-right: 0px !important;
}
/* ::v-deep .el-select-dropdown__item:hover {
  color: #409eff !important;
  background-color: #ebebeb !important;
} */
.hiden {
  display: none;
}
</style>
