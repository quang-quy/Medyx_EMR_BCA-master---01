<template>
  <div style="background-color: #F8F8FF">
    <div class="d-flex">
      <div
        class="flex-grow-1 d-flex"
        :class="{
          'flex-wrap': canShowInSearch && !disableCreate,
        }"
      >
        <div
          v-show="showSearch"
          :class="{
            'flex-grow-0 pr-4 pt-1': canShowInSearch,
            'flex-grow-1': !canShowInSearch,
          }"
          style="max-width: 800px; min-width: 250px"
        >
          <v-text-field
            v-model="params.search"
            clearable
            dense
            hide-details
            outlined
            :placeholder="placeholder"
            prepend-inner-icon="mdi-magnify"
            single-line
          />
        </div>
        <div
          v-show="!showSearch"
          :class="{
            'flex-grow-0 pr-4 pt-1': canShowInSearch,
            'flex-grow-1': !canShowInSearch,
            'grey--text': !showSearch,
            'text-lable': !showSearch,
          }"
          style="max-width: 800px; min-width: 250px"
        >
          <v-icon left>mdi-filter</v-icon>
          Tìm kiếm theo bộ lọc
        </div>
        <div v-if="canShowInSearch" class="flex-grow-1 d-flex pt-1">
          <slot />
        </div>
      </div>
      <slot name="extra-btn" />
      <div
        v-if="!disableCreate"
        class="flex-grow-0"
        :class="{
          'pt-1': canShowInSearch,
        }"
      >
        <div class="pl-2">
          <v-btn
            fab
            dark
            small
            color="primary"
            @click="onCreateItem()"
            title="Tạo mới"
          >
            <v-icon dark dense>mdi-plus</v-icon>
          </v-btn>
        </div>
      </div>
    </div>
    <div class="d-flex mt-5 flex-wrap">
      <slot name="open"></slot>
    </div>
    <div
      v-if="$slots['default'] && !canShowInSearch"
      class="pa-4 mt-4 pb-md-0"
      style="background: #f3f6f9"
    >
      <slot />
    </div>
  </div>
</template>

<script>
export default {
  props: {
    value: {},
    disableCreate: { Boolean, default: false },
    placeholder: String,
    canShowInSearch: Boolean,
    showSearch: { type: Boolean, default: true },
  },
  data: () => ({}),
  computed: {
    params: {
      get() {
        return this.value;
      },
      set(value) {
        this.$emit("input", value);
      },
    },
  },
  methods: {
    onCreateItem() {
      return this.$emit("click:create");
    },
  },
};
</script>

<style scoped>

</style>
