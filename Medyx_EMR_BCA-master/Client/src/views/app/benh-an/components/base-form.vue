<template>
  <v-form
    ref="baseForm"
    v-model="vaild"
    v-bind="$attrs"
    v-on="$listeners"
    @submit.prevent="submit"
  >
    <slot></slot>
    <button hidden type="submit" @click.prevent="submit"></button>
  </v-form>
</template>

<script>
export default {
  props: { value: Boolean },
  name: "base-form",
  inheritAttrs: false,
  computed: {
    vaild: {
      get() {
        return this.value;
      },
      set(value) {
        this.$emit("input", value);
      }
    }
  },
  methods: {
    submit(e) {
      this.$emit("submit", e);
    },
    reset() {
      return this.$refs.baseForm.reset();
    },
    resetValidation() {
      return this.$refs.baseForm.resetValidation();
    },
    validate() {
      return this.$refs.baseForm.validate();
    }
  }
};
</script>

<style scoped></style>
