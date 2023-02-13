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
          class="ml-2"
          color="primary"
          @click="inPhieu"
          :disabled="!disableActions.print"
        >
          <v-icon small class="mr-1">mdi-printer</v-icon>
          In phiếu
        </v-btn>
        <v-btn
          small
          @click="$emit('update:isSearching', !isSearching)"
          class="ml-2"
          color="primary"
        >
          <v-icon small class="mr-1"
            >mdi-{{ isSearching ? "filter-remove" : "filter" }}</v-icon
          >
          Filter
        </v-btn>
      </div>
    </v-col>
  </v-row>
</template>
<script>
import headerMixin from "@/mixins/crud/header";

export default {
  mixins: [headerMixin],
  props: {
    paramHeader: {
      type: Object,
      default: () => {},
    },
  },
  data: (vm) => ({
    disableActions: {
      print: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/phieuphanungthuoc/export"
      ),
    },
  }),

  methods: {
    inPhieu() {
      window.open(
        `${window.origin}/api/benh-an-thuoc-thu-phan-ung/${this.paramHeader.idba}/print-ba-file/phieu-thu-phan-ung-thuoc.pdf`,
        "_blank"
      );
    },
  },
};
</script>
