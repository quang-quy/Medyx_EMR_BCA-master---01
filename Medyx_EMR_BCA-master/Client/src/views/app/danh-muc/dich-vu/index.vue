<template>
  <page-option title="Chức danh" icon="mdi-account" hasUpload @on:Upload="handleUpload">
    <template #filter>
      <FilterSearch
        v-model="params"
        @click:create="onCreateItem()"
        placeholder="Tìm kiếm theo tên"
        canShowInSearch
      >
        <div class="d-flex flex-sm-row flex-column flex-warp">
          <div class="filter-item">
            <!-- Cac select search -->
          </div>
        </div>
      </FilterSearch>
    </template>
    <template #data-table>
      <!-- bang -->
      <base-data-table
        :headers="headers"
        :data="data"
        :itemsPerPage="itemsPerPage"
        :isLoading="isLoading"
        hasDelete
        @on:Delete="handleDelete"
        hasUpdate
        @on:Update="handleUpdate"
      >
      </base-data-table>
    </template>
  </page-option>
</template>
<script>
import PageOption from "../components/page-option.vue";
import FilterSearch from "../components/filter.vue";
import BaseDataTable from "../components/base-data-table.vue";
export default {
  components: { PageOption, FilterSearch, BaseDataTable },
  data: (vm) => ({
    data: [
      {
        name: "12",
      },
    ],
    itemsPerPage: 5,
    isLoading: false,
    params: {},
    headers: [
      {
        text: "name",
        align: "start",
        sortable: true,
        value: "name",
      },
      {
        text: "Tên",
        align: "start",
        sortable: false,
        value: "name",
      },
      {
        text: "Chức danh",
        align: "start",
        sortable: false,
        value: "name",
      },
      {
        text: "Phòng",
        align: "start",
        sortable: false,
        value: "name",
      },
      {
        text: "Hành động",
        sortable: false,
        align: "start",
        value: "actions",
      },
    ],
  }),
  methods: {
    onCreateItem() {
      //dialog create
    },
    handleUpdate(item) {
      console.log("🚀 ~ file: Index.vue ~ line 74 ~ handleUpdate ~ item", item);
    },
    handleDelete(item) {
      console.log("🚀 ~ file: Index.vue ~ line 77 ~ handleDelete ~ item", item);
    },
    handleUpload(){
      
    }
  },
};
</script>

<style></style>
