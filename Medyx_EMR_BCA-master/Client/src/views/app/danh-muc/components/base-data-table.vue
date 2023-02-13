<template>
  <div class="full-height hidden-oveflow">
    <v-data-table
      v-bind="$attrs"
      :headers="headers"
      :items="data"
      :items-per-page="itemPerPage"
      :loading="isLoading"
      hide-default-footer
    >
      <template v-slot:no-data>
        <div class="text-caption text--grey">Không có dữ liệu</div>
      </template>
      <template v-slot:item.actions="{ item }">
        <div class="d-flex justify-center">
          <v-btn
            :title="detail.title"
            :color="detail.color"
            class="mr-1"
            small
            dark
            icon
            outlined
            v-if="hasDetail"
            @click="handleAction(detail.action, item)"
          >
            <v-icon small>{{ detail.icon }}</v-icon>
          </v-btn>
          <v-btn
            :title="update.title"
            dark
            icon
            :color="update.color"
            outlined
            small
            class="mr-1"
            v-if="hasUpdate"
            @click="handleAction(update.action, item)"
          >
            <v-icon small>{{ update.icon }}</v-icon>
          </v-btn>
          <v-btn
            :title="detroy.title"
            dark
            icon
            :color="detroy.color"
            class="mr-1"
            outlined
            small
            v-if="hasDelete"
            @click="handleAction(detroy.action, item)"
          >
            <v-icon small>{{ detroy.icon }}</v-icon>
          </v-btn>

          <v-btn
            :title="upload.title"
            dark
            icon
            :color="upload.color"
            class="mr-1"
            outlined
            small
            v-if="hasUpload"
            @click="handleAction(upload.action, item)"
          >
            <v-icon small>{{ upload.icon }}</v-icon>
          </v-btn>
          <v-btn
            :title="_export.title"
            dark
            icon
            :color="_export.color"
            class="mr-1"
            outlined
            small
            v-if="hasExport"
            @click="handleAction(_export.action, item)"
          >
            <v-icon small>{{ upload.icon }}</v-icon>
          </v-btn>
          <v-btn
            :title="signature.title"
            dark
            icon
            :color="signature.color"
            class="mr-1"
            outlined
            small
            v-if="hasSignature"
            @click="handleAction(signature.action, item)"
          >
            <v-icon small>{{ signature.icon }}</v-icon>
          </v-btn>
        </div>
      </template>
      <template v-for="slot in slotItemHeader" v-slot:[slot]="props">
        <slot v-bind="props" :name="slot" />
      </template>
      <template v-for="slot in slotItemRow" v-slot:[slot]="props">
        <slot v-bind="props" :name="slot" />
      </template>
    </v-data-table>
    <div class="justify-center" v-if="data.length">
      <Paginate
        :length="length"
        @perPageChanged="handleChangePerPage"
        @pageChanged="handleChangepage"
        :itemPerPage="itemPerPage"
        :itemPage="itemPage"
      />
    </div>
  </div>
</template>

<script>
import Paginate from "../components/paginate.vue";
export default {
  props: {
    headers: { type: Array },
    data: { type: Array },
    isLoading: { type: Boolean, default: false },
    //Actions
    hasUpdate: { type: Boolean },
    hasDelete: { type: Boolean },
    hasDetail: { type: Boolean },
    hasUpload: { type: Boolean },
    hasExport: { type: Boolean },
    hasSignature: { type: Boolean },

    //paginate
    length: { type: Number, default: 1 },
    itemPerPage: { type: Number, default: 10 },
    itemPage: { type: Number, default: 1 },
    total: { type: Number, default: 0 },
  },
  components: {
    Paginate,
  },
  data: (vm) => ({
    update: {
      icon: "mdi-pencil",
      title: "Cập nhật",
      color: "primary",
      action: "on:Update",
    },
    detroy: {
      icon: "mdi-delete-outline",
      title: "Xóa",
      color: "error",
      action: "on:Delete",
    },
    detail: {
      icon: "mdi-information-variant",
      title: "Chi tiết",
      color: "green",
      action: "on:Detail",
    },
    upload: {
      icon: "mdi-download",
      title: "Tải xuống",
      color: "green",
      action: "on:Dowload",
    },
    _export: {
      icon: "mdi-file-export",
      color: "grey",
      event: "on:Export",
      title: "Xuất pdf",
    },
    signature: {
      icon: "mdi-file-export",
      color: "grey",
      event: "on:Signature",
      title: "Ký số",
    },
  }),
  methods: {
    handleAction(action, item) {
      return this.$emit(action, item);
    },
    handleChangePerPage(item) {
      console.log(
        "🚀 ~ file: base-data-table.vue ~ line 184 ~ handleChangePerPage ~ item",
        item
      );
    },
    handleChangepage(item) {
      console.log(
        "🚀 ~ file: base-data-table.vue ~ line 188 ~ handleChangepage ~ item",
        item
      );
    },
  },
  computed: {
    slotItemRow() {
      return Object.keys(this.$scopedSlots).filter((x) => x.includes("item"));
    },
    slotItemHeader() {
      return Object.keys(this.$scopedSlots).filter((x) => x.includes("header"));
    },
    slotTableRight() {
      return this.$slots["table-right"];
    },
  },
};
</script>

<style scoped>
/deep/ .v-pagination button {
  box-shadow: none !important;
  outline: 0 !important;
}
/deep/ .v-data-table .v-data-table__wrapper {
  border-radius: 4px;
  border: 1px solid #bdc6cc !important;
  overflow: hidden;
  justify-content: center;
}
/deep/ .v-data-table table th {
  color: #000 !important;
  font-family: Arial, Helvetica, sans-serif;
  font-size: 12px;
  height: 28px;
  justify-content: center;
}
/deep/.v-data-table table {
  border: none !important;
  justify-content: center;
}
/deep/.v-data-table table th {
  border-right: thin solid rgba(146, 142, 142, 0.12);
  justify-content: center;
}
/deep/.v-data-table table td {
  border-right: thin solid rgba(146, 142, 142, 0.12);
}
</style>
