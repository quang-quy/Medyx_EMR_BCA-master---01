<template>
  <component :is="wrapperComponent">
    <v-container fluid class="overflow-auto">
      <component
        :is="headerComponent"
        :isSearching.sync="isSearching"
        :title="title"
        :onlyTable="onlyTable"
        :hasExit="hasExit"
        @creating="showCreateForm"
        :actions="actions"
        :paramHeader="paramHeader"
        @reset="reset"
        @reload="getData"
        :hasCheckbox="hasCheckbox"
        @getDataCheck="handleGetCheckBox"
        :permission="permission"
      ></component>
      <component
        :is="filtersComponent"
        :filterParams="filterParams"
        :categories="categories"
        :fields="fields"
        @filter-change="getData(1)"
      ></component>
      <slot name="slot-header"></slot>
      <component
        :is="dataTableComponent"
        ref="elTable"
        :table-data="tableData"
        :pagination="pagination"
        :headers="headers"
        :actions="actions"
        :primaryKey="primaryKey"
        :destroy="apiCrudFunctions.destroy"
        :print="apiCrudFunctions.print"
        :is-searching="isSearching"
        :tableHeight="tableHeight"
        :filter-params="filterParams"
        :editing="editing"
        :currentEditingRowId="currentEditingRowId"
        :crudId="crudId"
        @deleted="getData()"
        @search-change="getData(1)"
        @exporting="exportData"
        @editing="showEditForm($event)"
        @show-file="showFileDialog($event)"
        @current-editing-row-changed="currentEditingRowId = $event"
        @clickFile="$emit('clickFile', $event)"
      ></component>

      <component
        :is="fileComponent"
        :show-file.sync="showFile"
        :currentRowData="currentRowData"
        :permission="permission"
        @reload="getData"
      ></component>

      <component
        :is="createFormComponent"
        :store="apiCrudFunctions.store"
        :categories="categories"
        :createForm="createForm"
        :creatableFields="creatableFields"
        :primaryKey="primaryKey"
        :customFormFields="customFormFields"
        :creating.sync="creating"
        :crudId="crudId"
        @reload="
          resetCreateForm();
          getData(1);
        "
        @form-reset="resetCreateForm"
      ></component>
      <component
        :is="editFormComponent"
        :update="apiCrudFunctions.update"
        :categories="categories"
        :form="form"
        :editableFields="editableFields"
        :primaryKey="primaryKey"
        :currentEditingRowId="currentEditingRowId"
        :customFormFields="customFormFields"
        :editing.sync="editing"
        :crudId="crudId"
        @editing-cancelled="editing = false"
        @reload="getData"
      ></component>

      <component
        :is="dialogComponent"
        :currentRowData="currentRowData"
        :showDialog.sync="showDialog"
        :editing="dialogEditing"
        :permission="permission"
        @reload="getData"
      ></component>

      <component
        :is="paginationComponent"
        :pagination="pagination"
        :filter-params="filterParams"
        @page-changed="getData"
        @per-page-changed="getData(1)"
      ></component>
      <!-- v-if="!onlyTable" -->
      <div class="mt-4">
        <slot name="sub-table"></slot>
      </div>
    </v-container>
  </component>
</template>

<script>
import DataTable from "./DataTable.vue";
import Filters from "./Filters.vue";
import Pagination from "./Pagination";
import CreateForm from "./CreateForm";
import EditForm from "./EditForm";
import indexMixin from "@/mixins/crud/index";
import Header from "./Header.vue";
import AppWrapper from "../AppWrapper.vue";
export default {
  components: { AppWrapper },
  mixins: [indexMixin],
  component: {
    AppWrapper,
  },
  computed: {
    wrapperComponent() {
      return this.wrapper ? AppWrapper : "Fragment";
    },
  },
  props: {
    permission: {
      type: Array,
      default: () => [],
    },
    paramHeader: {
      type: Object,
      default: () => {},
    },
    fileComponent: {
      type: Object,
      default: () => null,
    },
    fileComponent: {
      type: Object,
      default: () => null,
    },
    headerComponent: {
      type: Object,
      default: () => Header,
    },
    filtersComponent: {
      type: Object,
      default: () => Filters,
    },
    dataTableComponent: {
      type: Object,
      default: () => DataTable,
    },
    createFormComponent: {
      type: Object,
      default: () => CreateForm,
    },
    editFormComponent: {
      type: Object,
      default: () => EditForm,
    },
    paginationComponent: {
      type: Object,
      default: () => Pagination,
    },
    wrapper: {
      type: Boolean,
      default: () => true,
    },
    onlyTable: {
      type: Boolean,
      default: () => false,
    },
    hasExit: {
      type: Boolean,
      default: () => true,
    },
    customFormFields: {
      type: Object,
    },
    dialogComponent: {
      type: Object,
    },
  },
};
</script>
