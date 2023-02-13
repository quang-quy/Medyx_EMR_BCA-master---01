<template>
  <v-row>
    <v-col cols="12">
      <div class="d-flex mr-auto">
        <div class="mr-1 align-center" v-if="!onlyTable">
          <v-avatar color="primary" size="40" tile>
            <v-icon dark>mdi-table</v-icon>
          </v-avatar>
        </div>
        <div
          style="font-size: 19px; font-weight: bold"
          class="ml-2 mt-2"
          v-if="!onlyTable"
        >
          {{ title }}
        </div>
        <div class="d-flex align-center" v-if="onlyTable">
          <v-icon dark color="primary">mdi-table</v-icon>
          <div class="text-h6 ml-3 align-center">{{ title }}</div>
        </div>
        <v-spacer></v-spacer>
        <v-btn
          small
          v-if="actions.includes('create:dialog')"
          @click="$emit('creating', true)"
          class="ml-2"
          color="primary"
          ><v-icon>mdi-plus</v-icon> Thêm mới</v-btn
        >
        <v-btn
          small
          @click="$emit('update:isSearching', !isSearching)"
          class="ml-2"
          color="primary"
          ><v-icon>mdi-{{ isSearching ? "filter-remove" : "filter" }}</v-icon>
          Filter</v-btn
        >
      </div>
    </v-col>
  </v-row>
</template>
<script>
import headerMixin from "@/mixins/crud/header";
export default {
  mixins: [headerMixin],
};
</script>
