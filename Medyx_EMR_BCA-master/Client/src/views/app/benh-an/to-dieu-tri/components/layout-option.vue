<template>
  <div class="full-height px-3 mb-3">
    <div class="d-flex justify-space-between align-center">
      <div class="d-flex">
        <!-- <v-icon left small>mdi-view-grid</v-icon> -->
        <div class="body-1">
          {{ title }}
        </div>
      </div>
      <div class="d-flex flex-grow-0 mr-5">
        <v-icon
          :color="upload.color"
          class="mr-2"
          @click="handle(upload.event)"
          v-if="hasUpload"
          :title="upload.title"
          >{{ upload.icon }}</v-icon
        >
        <v-icon
          :color="download.color"
          class="mr-2"
          @click="handle(download.event)"
          v-if="hasDownload"
          :title="download.title"
          >{{ download.icon }}</v-icon
        >
        <v-icon
          :color="export_.color"
          @click="handle(export_.event)"
          v-if="hasExport"
          :title="export_.title"
          >{{ export_.icon }}</v-icon
        >
      </div>
    </div>
    <div>
      <slot name="data-table"></slot>
    </div>
    <slot />
  </div>
</template>
<script>
export default {
  component: {},
  props: {
    hasUpload: { type: Boolean },
    hasDownload: { type: Boolean },
    hasExport: { type: Boolean },
    title: { type: String, default: null },
  },
  data: (vm) => ({
    upload: {
      icon: "mdi-cloud-upload",
      color: "primary",
      event: "on:Upload",
      title: "Tải lên",
    },
    download: {
      icon: "mdi-cloud-download",
      color: "green",
      event: "on:Dowload",
      title: "Tải xuống",
    },
    export_: {
      icon: "mdi-file-export",
      color: "blue",
      event: "on:Export",
      title: "Xuất dữ liệu",
    },
  }),
  methods: {
    handle(event) {
      return this.$emit(event);
    },
  },
};
</script>

<style></style>
