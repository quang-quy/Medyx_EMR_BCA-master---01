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
          small
          @click="$emit('creating', true)"
          class="ml-2"
          color="primary"
          :disabled="
            permission.find(
              (e) => e.ActionDetailsName == '/HSBA/PhacDoDieuTri/create'
            )
              ? false
              : true
          "
        >
          <v-icon>mdi-plus</v-icon>
          Thêm mới
        </v-btn>
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
  components: {},
  mixins: [headerMixin],
  data: () => ({}),
  methods: {
  },
};
</script>
