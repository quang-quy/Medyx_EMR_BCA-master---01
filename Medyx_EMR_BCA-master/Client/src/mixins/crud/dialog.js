const dialogMixin = {
  props: {
    currentRowData: Object,
    showDialog: Boolean,
    editing: Boolean,
    permission: {type: Array, default: () => []}
  },
  computed: {
    dialog: {
      set(val) {
        this.$emit("update:showDialog", val);
      },
      get() {
        return this.showDialog;
      },
    },
  },
};

export default dialogMixin;
