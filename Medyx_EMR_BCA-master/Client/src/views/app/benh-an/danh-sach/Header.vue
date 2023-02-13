<template>
  <v-row>
    <v-col cols="12">
      <div class="d-flex mr-auto">
        <div class="mr-1 align-center">
          <v-avatar color="primary" size="40" tile>
            <v-icon dark>mdi-table</v-icon>
          </v-avatar>
        </div>
        <h2 style="margin-top: 3px" class="ml-2 font-weight-regular">
          {{ title }}
        </h2>
        <v-spacer></v-spacer>
        <v-btn small @click="showDialogForm" class="ml-2" color="primary" :disabled="!disableActions.create"
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
        <v-btn small @click="exit" class="ml-2" color="primary"
          ><v-icon>mdi-exit-to-app</v-icon> Thoát(F10)</v-btn
        >
      </div>
    </v-col>
    <DialogForm :showDialog.sync="showDialog" />
  </v-row>
</template>
<script>
import headerMixin from "@/mixins/crud/header";
import DialogForm from "./DialogForm.vue";
export default {
  mixins: [headerMixin],
  components: { DialogForm },
  data: (vm) => ({
    showDialog: false,
    disableActions:{
      create: vm.permission.find(
          (e) => e.ActionDetailsName == "/HSBA/thongtinbenhan/create"
        ),
    }
  }),
  created() {
    window.addEventListener("keydown", this.handlerKeyPress, false);
  },
  methods: {
    showDialogForm() {
      this.showDialog = true;
    },
    handlerKeyPress(e) {
      if(e.key == 'F10'){
        location.href = `${window.origin}/HSBADS/Index`;
        e.preventDefault();
      }
    },
  },
};
</script>
