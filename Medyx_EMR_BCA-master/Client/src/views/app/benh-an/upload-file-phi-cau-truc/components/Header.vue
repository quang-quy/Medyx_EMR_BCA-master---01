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
        <v-btn small class="ml-2" color="primary" @click="addFile" :disabled="!disableActions.import">
          <v-icon small class="mr-1">mdi-plus</v-icon>
          Thêm file
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
    <dialogForm ref="dialogForm" :params="paramHeader" @reset="handleReset" />
  </v-row>
</template>
<script>
import headerMixin from "@/mixins/crud/header";
import dialogForm from "./dialog.vue";

export default {
  props:["permission"],
  mixins: [headerMixin],
  data: (vm) => ({
    disableActions:{
        import: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/import"
        ),
        export: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/export"
        ),
        delete: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/TepDinhKem/delete"
        ),
      }
  }),
  components: { dialogForm },
  methods: {
    addFile() {
      this.$refs.dialogForm.open();
    },
    handleReset() {
      this.$emit("reset");
    },
  },
};
</script>
