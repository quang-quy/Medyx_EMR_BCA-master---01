<template>
  <div class="full-height fill-height pa-5 " style="background-color: #F8F8FF">
    <div class="d-flex">
      <div class="d-flex mr-auto">
        <div class="mr-1 align-center" v-if="icon">
          <v-avatar color="#E3FCF7" size="35">
            <v-icon color="#108F6E" size>
              {{ icon }}
            </v-icon>
          </v-avatar>
        </div>
        <div class="pl-2 text-h5">{{ title }}</div>
      </div>
      <div class="d-flex flex-grow-0">
        <v-btn
          dark
          icon
          fab
          small
          :color="upload.color"
          class="mr-2"
          @click="handle(upload.event)"
          v-if="hasUpload"
          :title="upload.title"
        >
          <v-icon dense :color="upload.color">{{ upload.icon }}</v-icon>
        </v-btn>
        <v-btn
          dark
          icon
          small
          fab
          :color="download.color"
          class="mr-2"
          @click="handle(download.event)"
          v-if="hasDownload"
          :title="download.title"
        >
          <v-icon dense :color="download.color">{{ download.icon }}</v-icon>
        </v-btn>
        <v-btn
          dark
          icon
          small
          fab
          :color="export_.color"
          class="mr-2"
          @click="handle(export_.event)"
          v-if="hasExport"
          :title="export_.title"
        >
          <v-icon dense :color="export_.color">{{ export_.icon }}</v-icon>
        </v-btn>
        <v-btn
          dark
          icon
          small
          fab
          :color="refresh.color"
          class="mr-2"
          @click="handle(refresh.event)"
          v-if="hasRefresh"
          :title="refresh.title"
        >
          <v-icon dense :color="refresh.color">{{ refresh.icon }}</v-icon>
        </v-btn>
      </div>
    </div>

    <div class="my-2">
      <v-sheet class="full-width">
        <slot name="filter"></slot>
      </v-sheet>
    </div>
    <div class="hidden-overflow">
      <v-sheet class="full-width">
        <slot name="data-table"></slot>
      </v-sheet>
    </div>
    <slot />
  </div>
</template>
<script>
export default {
  component: {},
  props: {
    icon: { type: String },
    title: {
      type: String,
    },
    hasUpload: { type: Boolean },
    hasDownload: { type: Boolean },
    hasExport: { type: Boolean },
    hasRefresh: { type: Boolean },
  },
  data: (vm) => ({
    upload: {
      icon: "mdi-cloud-upload",
      color: "grey",
      event: "on:Upload",
      title: "Tải lên"
    },
    download: {
      icon: "mdi-cloud-download",
      color: "grey",
      event: "on:Dowload",
      title: "Tải xuống"
    },
    export_: {
      icon: "mdi-file-export",
      color: "grey",
      event: "on:Export",
      title: "Xuất dữ liệu"
    },
    refresh: {
      icon: "mdi-refresh",
      color: "grey",
      event: "on:Refresh",
      title: "Làm mới dữ liệu"
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
