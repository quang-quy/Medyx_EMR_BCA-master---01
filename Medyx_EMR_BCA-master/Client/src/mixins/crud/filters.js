export default {
  props: ["filterParams", "categories", "fields"],
  computed: {
    filterFields() {
      return this.fields.filter((f) => f.filter);
    },
  },
  methods: {
    handleInputChange(e) {
      this.$emit("filter-change");
    },
  },
};
