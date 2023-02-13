export default {
  props: {
    tableData: Array,
    destroy: Function,
    print: Function,
    headers: [],
    pagination: Object,
    actions: {
      type: Array,
      default: () => [],
    },
    primaryKey: String,
    isSearching: Boolean,
    tableHeight: String,
    editing: Boolean,
    filterParams: Object,
    currentEditingRowId: String,
    rowDelete: {
      type: String,
      default: null,
    },
    crudId: String,
  },

  watch: {
    tableData() {
      this.filterTableData();
      setTimeout(() => this.$refs.elTable.doLayout(), 500);
    },
    isSearching() {
      this.filterTableData();
    },
    sort() {
      this.filterTableData();
    },
    editing() {
      this.$refs.elTable.doLayout();
    },
  },
  data() {
    return {
      options: {},
      filters: {},
      filteredData: [],
      sort: {
        prop: "",
        order: null,
      },
    };
  },

  methods: {
    handleCellDbClick(row) {
      if (row.editable === false) return;
      if (this.editing) return;
      if (row[this.primaryKey] === 0) return;
      this.$emit("editing", row);
    },
    handleSort({ prop, order }) {
      this.sort = {
        prop,
        order: order ? (order === "ascending" ? 1 : -1) : null,
      };
    },
    applySort(data) {
      data.sort(this.dynamicSort(this.sort.prop, this.sort.order));
    },

    handleEdit(row) {
      this.$emit("editing", row);
    },
    dynamicSort(prop, order) {
      return function (a, b) {
        const result =
          Object.byString(a, prop) < Object.byString(b, prop)
            ? -1
            : Object.byString(a, prop) > Object.byString(b, prop)
            ? 1
            : 0;
        return result * order;
      };
    },

    async handleDelete(item) {
      try {
        const res = await this.$confirm(
          "Bạn có chắc chắn muốn xóa bản ghi này?",
          {
            title: "Xác nhận xóa",
            buttonTrueText: "Đồng ý",
            buttonFalseText: "Hủy",
          }
        );

        if (res) {
          const responseDelete = await this.destroy(
            ...item[this.primaryKey].split(".")
          );
          if (responseDelete && responseDelete.statusCode == 200) {
            this.$message.success("Xóa dữ liệu thành công");
            this.$emit("deleted");
          }
        }
      } catch (error) {
        console.log(error);
      }
    },

    async handlePrint(item) {
      // api function open new tab handledowload
      await this.print(...item[this.primaryKey].split("."));
    },
    handleSortChange(data) {
      const { prop, order } = data;
      this.$emit("sort-change", {
        sortBy: order ? prop : null,
        sortOrder: order == "ascending" ? "" : "-",
      });
    },
    goToDetailPage(url, row) {
      const paths = url.split("/");
      for (const idx in paths) {
        if (paths[idx].startsWith(":")) paths[idx] = row[paths[idx].substr(1)];
      }
      window.location = paths.join("/");
    },
    handleSearchChange() {
      this.$emit("search-change");
    },
    filterTableData() {
      if (this.isSearching) {
        let filteredData = this.tableData.slice(
          this.actions.includes("create") ? 2 : 1
        );
        for (const filter in this.filters) {
          if (!this.filters[filter].value) continue;
          filteredData = filteredData.filter((item) => {
            let value = eval(`item.${filter}`);
            if (this.filters[filter].formatter)
              value = this.filters[filter].formatter(null, null, value);
            if (!value && value !== 0) return false;
            return String(value)
              .toLowerCase()
              .includes(this.filters[filter].value.toLowerCase());
          });
        }
        this.applySort(filteredData);
        if (this.actions.includes("create"))
          filteredData.unshift({ [this.primaryKey]: 0 });
        filteredData.unshift({});
        this.filteredData = filteredData;
      } else {
        const data = this.tableData.slice(
          this.actions.includes("create") ? 1 : 0
        );
        if (this.actions.includes("create"))
          data.unshift({ [this.primaryKey]: 0 });
        this.applySort(data);
        this.filteredData = data;
      }
    },
  },

  created() {
    for (const header of this.headers) {
      this.filters[header.value] = {
        value: null,
        formatter: header.formatter,
      };
    }
  },
};
