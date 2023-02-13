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
        <v-btn small class="ml-2" color="primary" @click="showFormAdd()" :disabled="!disableActions.create">
          <v-icon small class="mr-1">mdi-plus</v-icon> Thêm mới
        </v-btn>
        <v-menu offset-y>
          <template v-slot:activator="{ on, attrs }">
            <v-btn small class="ml-2" color="primary" dark v-bind="attrs" v-on="on">
              <v-icon small class="mr-1">mdi-printer</v-icon>
              In phiếu
            </v-btn>
          </template>
          <v-list>
            <v-list-item link @click="$emit('getDataCheck', 'phieuChamSoc')" :disabled="!disableActions.print">
              <v-list-item-title>Phiếu chăm sóc</v-list-item-title>
            </v-list-item>
            <v-list-item link @click="$emit('getDataCheck', 'bieuDo')" :disabled="!disableActions.print">
              <v-list-item-title>Biểu đồ</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>

        <v-btn small class="ml-2" color="primary" @click="showFormCopy()" :disabled="!disableActions.create">
          <v-icon small class="mr-1">mdi-content-copy</v-icon> Sao chép
        </v-btn>
        <v-btn small @click="$emit('update:isSearching', !isSearching)" class="ml-2" color="primary">
          <v-icon small class="mr-1">mdi-{{ isSearching ? "filter-remove" : "filter" }}</v-icon>
          Filter
        </v-btn>
      </div>
    </v-col>
    <CreateDialog ref="createDialog"></CreateDialog>
    <CopyDialog ref="copyDialog"></CopyDialog>
  </v-row>
</template>
<script>
import headerMixin from "@/mixins/crud/header";
import CreateDialog from "./create.vue";
import CopyDialog from "./dialogCopy.vue";
export default {
  components: {
    CreateDialog,
    CopyDialog,
  },
  mixins: [headerMixin],
  
  data: (vm) => ({
    disableActions: {
      create: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/create"
      ),
      print: vm.permission.find(
        (e) => e.ActionDetailsName == "/HSBA/TheoDoiVaChamSoc/export"
      ),
    },
  }),
  methods: {
    showFormAdd() {
      const idba = window.location.href.split("/").at(-1);
      window.location = `/HSBADS/ThemMoiTheoDoiVaChamSoc/${idba}`;
    },
    showFormCopy() {
      this.$refs.copyDialog.showFormCopy();
    },
  },
};
</script>
