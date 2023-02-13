<template>
  <v-row>
    <v-col cols="12">
      <div class="d-flex mr-auto">
        <div class="mr-1 align-center">
          <v-avatar color="primary" size="30" tile>
            <v-icon small dark>mdi-table</v-icon>
          </v-avatar>
        </div>
        <div class="mt-1 ml-2" style="font-size: 19px; font-weight: bold">
          {{ title }}
        </div>
        <v-spacer></v-spacer>
        <v-btn
          depressed
          small
          class="ml-2"
          color="primary"
          @click="showFormAdd()"
        >
          <v-icon small class="mr-1">mdi-plus</v-icon> Thêm mới</v-btn
        >
        <v-btn depressed small class="ml-2" color="primary">
          <v-icon small class="mr-1">mdi-download</v-icon> Tải phiếu</v-btn
        >

        <v-btn
          small
          depressed
          @click="$emit('update:isSearching', !isSearching)"
          class="ml-2"
          color="primary"
          ><v-icon small class="mr-1"
            >mdi-{{ isSearching ? "filter-remove" : "filter" }}</v-icon
          >
          Filter</v-btn
        >
        <v-btn depressed small @click="exit" class="ml-2" color="primary" outlined
          ><v-icon small class="mr-1">mdi-reload</v-icon> Tải lại</v-btn
        >
      </div>
    </v-col>
    <CreateDialog ref="createDialog"></CreateDialog>
  </v-row>
</template>
<script>
import headerMixin from "@/mixins/crud/header";
import CreateDialog from "./create.vue";
export default {
  components: {
    CreateDialog,
  },
  mixins: [headerMixin],
  data: () => ({}),
  methods: {
    showFormAdd() {
      this.$refs.createDialog.showFormAdd();
    },
  },
};
</script>
