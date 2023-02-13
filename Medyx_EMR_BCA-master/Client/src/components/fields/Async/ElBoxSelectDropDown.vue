<template>
  <el-select
    v-model="form"
    :placeholder="placeholder"
    filterable
    remote
    :remote-method="remoteMethod"
    :loading="loading"
    loading-text="Đang tải ..."
    :size="size"
    clearable
    v-bind="$attrs"
    @focus="handleFocusSelectOption"
    v-el-select-loadmore="loadmore"
    ref="elboxselect"
    @change="getItem($event)"
  >
    <el-option
      v-for="(item, index) in dataItems"
      :key="`el-option-sync-${index}`"
      :label="getLable(item)"
      :value="item[keyValue]"
    />
  </el-select>
</template>

<script>
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
    firstEmitGetItem: {type: Boolean, default: true}
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
      async handler(val) {
        if (this.firstIn && val) {
          this.SearchUnion = val;
          await this.getItems();
          if(this.firstEmitGetItem){
            this.getItem(val);
          }
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
  },
  created() {
    this.getItems();
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
  },
  methods: {
    focus(){
      this.$refs.elboxselect.focus();
    },  
    remoteMethod(query) {
      this.pageData = this.$options.data.call(this).pageData;
      if (query) {
        this.search = query;
        this.getItems({ search: this.search });
      } else {
        this.getItems({});
      }
    },
    /** Load 20 securities codes at a time */
    loadmore() {
      if (!this.pageData.hasNextPage) {
        return;
      }
      this.pageData.pageNumber++;
      this.getItems({ search: this.search }, true); //Similar to paging query
    },
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
    handleFocusSelectOption() {
      this.getItems();
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
.hiden {
  display: none;
}
</style>
