export default {
  props: {
    fields: Array,
    apiCrudFunctions: Object,
    apiCategoryFunctions: Object,
    tableHeight: String,
    customCreateForm: Object,
    customEditForm: Object,
    labelWidth: {
      type: String,
      default: "120px",
    },
    relations: {
      type: Array,
      default: () => [],
    },
    actions: {
      type: Array,
      default: () => [],
    },
    disableActions: {
      type: Object,
      default: () => ({}),
    },
    primaryKey: {
      type: String,
      default: "id",
    },
    title: {
      type: String,
      default: "Danh sách",
    },
    hasCheckbox: {
      type: Boolean,
      default: false,
    },
  },

  data() {
    return {
      showFile: false,
      showDialog: false,
      editing: false,
      dialogEditing: false,
      filterParams: {},
      isSearching: false,
      creating: false,
      defaultFilterParams: {
        pageNumber: 1,
        pageSize: 20,
      },
      pagination: {
        totalRecords: 0,
        pageNumber: 1,
        pageSize: 20,
      },
      tableData: [],
      form: {},
      createForm: {},
      categories: {},
      defaultForm: {},
      loading: null,
      loadingOptions: {
        lock: true,
        background: "rgba(0, 0, 0, 0.5)",
      },
      currentEditingRowId: null,
      currentRowData: null,
    };
  },
  computed: {
    creatableFields() {
      return this.fields.filter((f) => f.form && f.form.creatable);
    },
    editableFields() {
      return this.fields.filter((f) => f.form && f.form.editable);
    },
    formFields() {
      return this.editing ? this.editableFields : this.creatableFields;
    },
    headers() {
      return this.fields.filter((f) => !f.hidden);
    },
  },
  watch: {
    isSearching(value) {
      if (value) {
        this.tableData.unshift({});
      } else {
        this.tableData.shift();
      }
    },
  },
  methods: {
    initForm() {
      for (const field of this.fields) {
        if (!field.form) continue;
        if (field.form.creatable) {
          this.defaultForm[field.form.value] = field.form.defaultValue || null;
        }
        if (field.form.editable) {
          this.form[field.form.value] = field.form.defaultValue || null;
        }
      }
      this.createForm = JSON.parse(
        JSON.stringify(this.customCreateForm || this.defaultForm)
      );
      this.form = JSON.parse(JSON.stringify(this.customEditForm || this.form));
    },
    initFilterParams() {
      for (const field of this.fields) {
        if (field.filter) {
          this.defaultFilterParams[field.filter.value] =
            field.filter.default || null;
        }
      }
      this.filterParams = { ...this.defaultFilterParams };
    },
    async getData(pageNumber = null) {
      this.editing = false;
      try {
        this.loading = this.$loading(this.loadingOptions);
        if (pageNumber) this.filterParams.pageNumber = pageNumber;
        const { data, meta } = await this.apiCrudFunctions.index(
          this.filterParams
        );
        const keys = this.primaryKey.split(".");
        data.forEach((item) => {
          item[this.primaryKey] = keys
            .reduce((v, k) => {
              v.push(item[k]);
              return v;
            }, [])
            .join(".");

          if (this.disableActions.edit) {
            item.editable = !this.disableActions.edit(item);
          }
          if (this.disableActions.print) {
            item.printable = !this.disableActions.print(item);
          }
          if (this.disableActions.delete) {
            item.deletable = !this.disableActions.delete(item);
          }
          if (this.disableActions.detail) {
            item.showable = !this.disableActions.detail(item);
          }
        });
        if (this.actions.includes("create"))
          data.unshift({ [this.primaryKey]: 0 });
        if (this.isSearching) data.unshift({});
        this.tableData = data;
        this.tableData = this.tableData.map((x, index) => ({
          ...x,
          active: false,
          keyIndex: index,
        }));
        this.pagination = meta;
      } catch (error) {
        console.log(error);
      } finally {
        this.loading.close();
      }
    },

    async getCategories() {
      try {
        const categories = {};
        const results = (
          await Promise.all(
            Object.values(this.apiCategoryFunctions).map((c) =>
              c.func(c.filterParams)
            )
          )
        ).map((item) => item.data);

        Object.keys(this.apiCategoryFunctions).forEach((item, key) => {
          categories[item] = results[key].map((value) => ({
            text: transformerValue(
              this.apiCategoryFunctions[item].textField,
              value
            ),
            value: transformerValue(
              this.apiCategoryFunctions[item].valueField,
              value
            ),
            code: transformerValue(
              this.apiCategoryFunctions[item].codeField,
              value
            ),
          }));
        });
        this.categories = { ...categories };
      } catch (error) {
        console.log(error);
      }
    },

    showCreateForm() {
      this.creating = true;
      this.dialogEditing = false;
      this.showDialog = true;
    },
    showFileDialog(data) {
      this.showFile = true;
      this.currentRowData = JSON.parse(JSON.stringify(data));
    },
    showEditForm(data) {
      this.currentRowData = JSON.parse(JSON.stringify(data));
      this.editing = false;
      for (const field in this.form) {
        this.form[field] = null;
      }
      this.$nextTick(() => {
        for (const field of this.editableFields) {
          this.form[field.form.value] = Object.byString(
            data,
            field.form.fromValue
          );
        }
        this.form[this.primaryKey] = data[this.primaryKey];
        this.currentEditingRowId = data[this.primaryKey];
        this.editing = true;
        this.dialogEditing = true;
        this.showDialog = true;
      });
    },

    reset() {
      this.filterParams = { ...this.defaultFilterParams };
      this.getData();
    },
    resetCreateForm() {
      this.createForm = JSON.parse(JSON.stringify(this.defaultForm));
    },
    sort({ sortBy, sortOrder }) {
      if (sortBy) {
        this.filterParams.sortBy = `${sortOrder}${sortBy}`;
      } else
        this.filterParams.sortBy =
          this.defaultFilterParams.sortBy || `${this.primaryKey}`;
      this.getData(1);
    },

    async exportData() {
      // this.$loader(true);
      const { page, perPage, ...filterParams } = this.filterParams;
      const data = await this.apiCrudFunctions.exportData(filterParams);
      const url = URL.createObjectURL(
        new Blob([data], {
          type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        })
      );
      const link = document.createElement("a");
      link.href = url;
      link.setAttribute("download", `${this.model || "export"}.xlsx`);
      document.body.appendChild(link);
      link.click();
      // this.$loader(false);
    },
    handleGetCheckBox(type) {
      var dataCheck = this.tableData.filter((e) => e.active);
      this.$emit("dataCheck", {
        data: dataCheck,
        type: type,
      });
      // this.tableData.map((x) => (x.active = false));
    },
  },

  created() {
    this.crudId = (Math.random() + 1).toString(36).substring(7);
    this.getCategories();
    this.initFilterParams();
    this.initForm();
    this.sort({ sortBy: this.primaryKey, sortOrder: "" });
  },
};

function transformerValue(key, value) {
  if (typeof key === "function") {
    return key(value);
  }
  return value[key];
}
