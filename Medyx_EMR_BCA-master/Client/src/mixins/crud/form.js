const formMixin = {
  props: {
    form: Object,
    createForm: Object,
    showDialog: Boolean,
    categories: Object,
    store: Function,
    update: Function,
    editableFields: Array,
    creatableFields: Array,
    primaryKey: String,
    labelWidth: String,
    currentEditingRowId: String,
    editing: Boolean,
    creating: Boolean,
    currentRowData: Object,
    crudId: String,
  },
  computed: {
    showFormDialog: {
      set() {
        this.$emit("update:editing", false);
        this.$emit("update:creating", false);
      },
      get() {
        return this.editing | this.creating;
      },
    },
    ruledFields() {
      const fields =
        this.formType === "edit" ? this.editableFields : this.creatableFields;
      return fields
        .filter((f) => f.form.rules)
        .map((f) => ({ ...f.form, label: f.text }));
    },
  },
  data: () => ({
    dialog: true,
    loading: false,
    valid: false,
  }),
  methods: {
    resetForm() {
      this.$refs["form"].resetFields();
      this.$emit("update:creating", false);
    },
    validateForm() {
      this.valid = true;
      const errors = [];
      const form = this.formType === "edit" ? this.form : this.createForm;
      for (const field of this.ruledFields) {
        for (const rule of field.rules) {
          if (!rule.validator(form[field.value])) {
            errors.push({
              label: field.label,
              message: rule.message,
            });
          }
        }
      }
      if (errors.length > 0) {
        this.valid = false;
        for (const error of errors) {
          setTimeout(
            () => this.$message.error(`${error.label}: ${error.message}`),
            100
          );
        }
      }
    },
    closeDialog() {
      this.$nextTick(() => this.$refs.form.resetFields());
      this.$emit("update:showDialog", false);
    },
    async createData() {
      try {
        await this.validateForm();
        if (!this.valid) return;
        this.loading = true;
        await this.store(this.createForm);
        this.reload();
        this.$message.success("Thêm mới thành công");
      } catch (error) {
        console.log(error);
        this.loading = false;
      }
    },
    async updateData() {
      await this.validateForm();
      if (!this.valid) return;
      try {
        for (const field in this.form) {
          if (field !== this.primaryKey) {
            if (this.form[field] === undefined) this.form[field] = null;
          }
        }
        this.loading = true;
        await this.update(...this.form[this.primaryKey].split("."), {
          ...this.form,
          [this.primaryKey]: undefined,
        });
        this.$message.success("Cập nhật thành công");
        this.reload();
      } catch (error) {
        console.log(error);
        this.loading = false;
      }
    },
    reload() {
      this.loading = false;

      this.$message.success(
        this.editing ? "Cập nhật thành công" : "Thêm mới thành công"
      );

      this.$emit("reload");
    },
    cancel() {
      this.$emit("editing-cancelled");
    },
  },
};

export default formMixin;
